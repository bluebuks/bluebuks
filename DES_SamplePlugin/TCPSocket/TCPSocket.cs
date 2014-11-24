using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;


namespace QuantX
{
   
    public class TCPSocket
    {
        private byte[] bMaximumConnectionError;
        private int iMaxConnection;
        private int index;
        public list List;
        private Socket sockMain;
        private string wsIPAddress;
        private int wsPort;
        const int ChunkSize = 1492;
        const int ReceiveTimeout = 10000;
        const int SendTimeout = 10000;
        public object mylock = new object();
        
        public event socketAcceptHandler onAccept;

        public event socketConnectHandler onConnect;

        public event socketDataArrivalHandler onDataArrival;

        public event socketConnectHandler onDisconnect;

        public event socketErrorHandler onError;

        public event socketSendCompleteHandler onSendComplete;

        public TCPSocket()
        {
            this.iMaxConnection = 5;
            this.index = -1;
        }

        public TCPSocket(string localIPAddress, int Port)
        {
            this.iMaxConnection = 5;
            this.index = -1;
            this.wsIPAddress = localIPAddress;
            this.wsPort = Port;
        }

        public TCPSocket(string localIPAddress, int Port, int MaxConnection)
        {
            this.iMaxConnection = 5;
            this.index = -1;
            this.wsIPAddress = localIPAddress;
            this.wsPort = Port;
            this.iMaxConnection = MaxConnection;
        }

        private void Accept(IAsyncResult iar)
        {
            state state = new state();
            try
            {
                Socket socket = this.sockMain.EndAccept(iar);
                socket.NoDelay = true;
                socket.DontFragment = false;
                this.index++;
                state.wSocket = socket;
                int num = this.List.Add(ref state);
                state.tag = socket.RemoteEndPoint.ToString();
                if (num == -1)
                {
                    socket.Send(this.bMaximumConnectionError);
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                    if (this.onDisconnect != null)
                    {
                        this.onDisconnect(state);
                    }
                }
                else
                {
                    state.index = num;
                    socket.BeginReceive(state.buffer, 0, state.bufferSize, SocketFlags.None, new AsyncCallback(this.sockDataArrival), state);
                }
                this.sockMain.BeginAccept(new AsyncCallback(this.Accept), this);
            }
            catch (ObjectDisposedException)
            {
                return;
            }
            catch (Exception exception)
            {
                if (this.onError != null)
                {
                    this.onError(exception.Message);
                }
                return;
            }
            if (this.onAccept != null)
            {
                this.onAccept(state);
            }
        }

        public void BroadCast(string data)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(data);
            this.SendBroadCast(bytes);
        }

        public void BroadCast(byte[] data)
        {
            this.SendBroadCast(data);
        }

        public void Connect()
        {
            this.Connect(this.wsIPAddress, this.wsPort);
        }


         //public void SendNse(ushort prefix,int seqnumber,)
        public void Send(byte[] data, int prefix,byte[] cheksum)
        {
            lock (mylock)
            {
                try
                {
                    Interlocked.Increment(ref MainModule.incfield);

                    byte[] seqdata =  BitConverter.GetBytes(MainModule.incfield);
                    byte[] prefixBytes = BitConverter.GetBytes(prefix);

                    byte[] ClientData = new byte[data.Length+22];

                    int lengthfield = ClientData.Length;
                    byte[] lenthybytes= BitConverter.GetBytes(lengthfield);
                    Buffer.BlockCopy(lenthybytes, 0, ClientData, 0, lenthybytes.Length);
                    Buffer.BlockCopy(seqdata, 0, ClientData, 2, seqdata.Length);
                    Buffer.BlockCopy(cheksum, 0, ClientData, 4, cheksum.Length);
                    Buffer.BlockCopy(data, 0, ClientData, 22, data.Length);
                    this.Send(ClientData);

                }
                catch (Exception e)
                {
                    
                }
            }
        }

        //public void SendNse(ushort prefix,int seqnumber,)
        public void Send(byte[] data, uint prefix)
        {


            lock (mylock)
            {
                try
                {

                    //business data lenth(prefix is length field) converting to bytes
                    byte[] prefixBytes = BitConverter.GetBytes(prefix);

                    byte[] ClientData = new byte[prefixBytes.Length + data.Length];
                    Buffer.BlockCopy(prefixBytes, 0, ClientData, 0, prefixBytes.Length);
                    Buffer.BlockCopy(data, 0, ClientData, 4, data.Length);
                    this.Send(ClientData);


                }
                catch (Exception e)
                {

                }
            }
        }

        public void Connect(string localIPAddress, int Port)
        {
            this.List = new list(this.iMaxConnection);
            this.wsIPAddress = localIPAddress;
            this.wsPort = Port;
            state state = new state();
            try
            {
                this.sockMain = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse(this.wsIPAddress), this.wsPort);
                this.index++;
                state.wSocket = this.sockMain;
                state.tag = remoteEP.ToString();
                int num = this.List.Add(ref state);
                if (num == -1)
                {
                    this.sockMain.Shutdown(SocketShutdown.Both);
                    this.sockMain.Close();
                    if (this.onDisconnect != null)
                    {
                        this.onDisconnect(state);
                    }
                }
                else
                {
                    state.index = num;
                }
                state.wSocket.BeginConnect(remoteEP, new AsyncCallback(this.sockConnect), state);
            }
            catch (ObjectDisposedException)
            {
            }
            catch (Exception exception)
            {
                if (this.onError != null)
                {
                    this.onError(exception.Message);
                }
            }
        }


        public void ReConnectSocket()
        {

            try {

                 


            
                }
                 catch (ObjectDisposedException) {
 


            }
        }



        public void Connect(string localIPAddress, int Port, int MaxConnection)
        {
            this.iMaxConnection = MaxConnection;
            this.List = new list(this.iMaxConnection);
            this.wsIPAddress = localIPAddress;
            this.wsPort = Port;
            state state = new state();
            try
            {
                this.sockMain = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                this.sockMain.NoDelay = true;
                this.sockMain.DontFragment = false;
                IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse(this.wsIPAddress), this.wsPort);
                this.index++;
                state.wSocket = this.sockMain;
                state.index = this.List.Add(ref state);
                state.wSocket.BeginConnect(remoteEP, new AsyncCallback(this.sockConnect), state);
            }
            catch (ObjectDisposedException)
            {
            }
            catch (Exception exception)
            {
                if (this.onError != null)
                {
                    this.onError(exception.Message);
                }
            }
        }

        public bool Connected(int Index)
        {
            state state = this.List.Item(Index);
            return ((state != null) && state.wSocket.Connected);
        }

        public void DisconnectAllClient()
        {
            try
            {
                if (this.List != null)
                {
                    int maximumIndexCheck = this.List.MaximumIndexCheck;
                    for (int i = 0; i <= maximumIndexCheck; i++)
                    {
                        state state = this.List.Item(i);
                        if (state != null)
                        {
                            try
                            {
                                state.wSocket.Shutdown(SocketShutdown.Both);
                            }
                            catch (Exception)
                            {
                                state.wSocket.Shutdown(SocketShutdown.Both);
                            }
                            state.wSocket.Close();
                            this.index--;
                            this.List.Remove(state.index);
                            if (this.onDisconnect != null)
                            {
                                this.onDisconnect(state);
                            }
                        }
                    }
                }
            }
            catch (ObjectDisposedException)
            {
            }
            catch (Exception exception)
            {
                if (this.onError != null)
                {
                    this.onError(exception.Message);
                }
            }
        }

        public void DisconnectClient(int index)
        {
            try
            {
                state state = this.List.Item(index);
                if ((state != null) && (index == state.index))
                {
                    state.wSocket.Shutdown(SocketShutdown.Both);
                    state.wSocket.Close();
                    index--;
                    this.List.Remove(state.index);
                    if (this.onDisconnect != null)
                    {
                        this.onDisconnect(state);
                    }
                }
            }
            catch (ObjectDisposedException)
            {
            }
            catch (Exception exception)
            {
                if (this.onError != null)
                {
                    this.onError(exception.Message);
                }
            }
        }

        public void DisconnectClient(string sClientID)
        {
            try
            {
                state state = this.List.Item(sClientID);
                if ((state != null) && (state.sClientID != ""))
                {
                    state.wSocket.Shutdown(SocketShutdown.Both);
                    state.wSocket.Close();
                    this.index--;
                    this.List.Remove(state.index);
                    if (this.onDisconnect != null)
                    {
                        this.onDisconnect(state);
                    }
                }
            }
            catch (ObjectDisposedException)
            {
            }
            catch (Exception exception)
            {
                if (this.onError != null)
                {
                    this.onError(exception.Message);
                }
            }
        }

        public void DisconnectClientTimeOut(int iTimeOut)
        {
            try
            {
                int maximumIndexCheck = this.List.MaximumIndexCheck;
                for (int i = 0; i <= maximumIndexCheck; i++)
                {
                    state state = this.List.Item(i);
                    if (state != null)
                    {
                        TimeSpan span = (TimeSpan) (DateTime.Now - state.dtLastPacketTime);
                        if (span.TotalMinutes >= iTimeOut)
                        {
                            state.wSocket.Shutdown(SocketShutdown.Both);
                            state.wSocket.Close();
                            this.index--;
                            this.List.Remove(state.index);
                            if (this.onDisconnect != null)
                            {
                                this.onDisconnect(state);
                            }
                        }
                    }
                }
            }
            catch (ObjectDisposedException)
            {
            }
            catch (Exception exception)
            {
                if (this.onError != null)
                {
                    this.onError(exception.Message);
                }
            }
        }

        public bool ExistClient(string sClientID)
        {
            try
            {
                state state = this.List.Item(sClientID);
                return ((state != null) && (state.sClientID != ""));
            }
            catch (ObjectDisposedException)
            {
                return false;
            }
            catch (Exception exception)
            {
                if (this.onError != null)
                {
                    this.onError(exception.Message);
                }
                return false;
            }
        }

        public void Listen(string localIPAddress, int Port)
        {
            this.wsIPAddress = localIPAddress;
            this.wsPort = Port;
            try
            {
                this.sockMain = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                this.sockMain.NoDelay = true;
                this.sockMain.DontFragment = false;
                IPEndPoint localEP = new IPEndPoint(IPAddress.Parse(this.wsIPAddress), this.wsPort);
                this.sockMain.Bind(localEP);
                this.sockMain.Listen(50);
                this.sockMain.BeginAccept(new AsyncCallback(this.Accept), this);
            }
            catch (ObjectDisposedException)
            {
            }
            catch (Exception exception)
            {
                if (this.onError != null)
                {
                    this.onError(exception.Message);
                }
            }
        }

        public void Listen(string localIPAddress, int Port, int MaxConnection)
        {
            this.iMaxConnection = MaxConnection;
            this.List = new list(this.iMaxConnection);
            this.wsIPAddress = localIPAddress;
            this.wsPort = Port;
            try
            {
                this.sockMain = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                this.sockMain.NoDelay = true;
                this.sockMain.DontFragment = false;
                IPEndPoint localEP = new IPEndPoint(IPAddress.Parse(this.wsIPAddress), this.wsPort);
                this.sockMain.Bind(localEP);
                this.sockMain.Listen(50);
                this.sockMain.BeginAccept(new AsyncCallback(this.Accept), this);
            }
            catch (ObjectDisposedException)
            {
            }
            catch (Exception exception)
            {
                if (this.onError != null)
                {
                    this.onError(exception.Message);
                }
            }
        }

        public void Send(string data)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(data);
            this.Send(bytes, 0);
        }

        public void Send(byte[] data)
        {
            this.Send(data, 0);
        }

        public void Send(byte[] data, int Index)
        {
            try
            {
                state state = this.List.Item(Index);
                if (state != null)
                {
                    state.wSocket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(this.sockSendComplete), state);
                }
            }
            catch (Exception exception)
            {
                if (this.onError != null)
                {
                    this.onError(exception.Message);
                }
            }
        }

        public void Send(string data, int Index)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(data);
            this.Send(bytes, Index);
        }

        public void SendBroadCast(byte[] data)
        {
            try
            {
                int maximumIndexCheck = this.List.MaximumIndexCheck;
                for (int i = 0; i <= maximumIndexCheck; i++)
                {
                    state state = this.List.Item(i);
                    if ((state != null) && ((state.sClientID != null) || (state.sClientID.Trim() != "")))
                    {
                        try
                        {
                            state.wSocket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(this.sockSendComplete), state);
                        }
                        catch (ObjectDisposedException)
                        {
                            return;
                        }
                        catch (Exception exception)
                        {
                            if (exception.Message.StartsWith("An existing connection was forcibly closed by the remote host") || exception.Message.StartsWith("An established connection was aborted by the software in your host machine"))
                            {
                                this.DisconnectClient(state.sClientID);
                            }
                            else
                            {
                                if (this.onError != null)
                                {
                                    this.onError(exception.Message);
                                }
                                return;
                            }
                        }
                    }
                }
            }
            catch (ObjectDisposedException)
            {
            }
            catch (Exception exception2)
            {
                if (this.onError != null)
                {
                    this.onError(exception2.Message);
                }
            }
        }

        public int SendToClient(byte[] data, string sClientID)
        {
            try
            {

                

                state state = this.List.Item(sClientID);
                if ((state != null) && (state.sClientID != ""))
                {
                    state.wSocket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(this.sockSendComplete), state);
                    return state.index;
                }
            }
            catch (ObjectDisposedException)
            {
                return -1;
            }
            catch (Exception exception)
            {
                if (this.onError != null)
                {
                    this.onError(exception.Message);
                }
                return -1;
            }
            return -1;
        }

        private void sockConnect(IAsyncResult iar)
        {
            state asyncState = (state) iar.AsyncState;
            try
            {
                asyncState.wSocket.BeginReceive(asyncState.buffer, 0, asyncState.bufferSize, SocketFlags.None, new AsyncCallback(this.sockDataArrival), asyncState);
            }
            catch (ObjectDisposedException)
            {
                return;
            }
            catch (Exception exception)
            {
                if (this.onError != null)
                {
                    this.onError(exception.Message);
                }
                this.index--;
                this.List.Remove(asyncState.index);
                return;
            }
            if (this.onConnect != null)
            {
                this.onConnect(asyncState);
            }
        }




        private void sockDataArrival(IAsyncResult iar)
        {
            state asyncState = (state) iar.AsyncState;
            byte[] sourceArray = null;
            int length = 0;
            try
            {
                length = asyncState.wSocket.EndReceive(iar);
                if (length == 0)
                {
                    return;
                }
                sourceArray = asyncState.buffer;
            }
            catch (ObjectDisposedException)
            {
                return;
            }
            catch (Exception)
            {
                if (asyncState.wSocket.Connected)
                {
                    asyncState.wSocket.Shutdown(SocketShutdown.Both);
                    asyncState.wSocket.Close();
                    this.index--;
                    this.List.Remove(asyncState.index);
                    if (this.onDisconnect != null)
                    {
                        this.onDisconnect(asyncState);
                    }
                }
                return;
            }
            byte[] destinationArray = new byte[length];
            Array.Copy(sourceArray, destinationArray, length);
            if (this.onDataArrival != null)
            {
                this.onDataArrival(destinationArray, asyncState);
            }
            try
            {
                asyncState.wSocket.BeginReceive(asyncState.buffer, 0, asyncState.bufferSize, SocketFlags.None, new AsyncCallback(this.sockDataArrival), asyncState);
            }
            catch (Exception)
            {
            }
        }

        private void sockSendComplete(IAsyncResult iar)
        {
            state asyncState = (state) iar.AsyncState;
            int bytesSent = 0;
            try
            {
                bytesSent = asyncState.wSocket.EndSend(iar);
            }
            catch (ObjectDisposedException)
            {
                return;
            }
            catch (Exception exception)
            {
                this.onError(exception.Message);
                return;
            }
            if (this.onSendComplete != null)
            {
                this.onSendComplete(bytesSent);
            }
        }

        public string localHostname
        {
            get
            {
                return Dns.GetHostName();
            }
        }

        public int MaximumConnection
        {
            get
            {
                return this.iMaxConnection;
            }
        }

        public byte[] MaximumConnectionError
        {
            get
            {
                return this.bMaximumConnectionError;
            }
            set
            {
                this.bMaximumConnectionError = value;
            }
        }

        public string remoteHostname
        {
            get
            {
                return this.wsIPAddress;
            }
        }

        public int remotePort
        {
            get
            {
                return this.wsPort;
            }
        }

        public delegate void socketAcceptHandler(state state);

        public delegate void socketConnectHandler(state state);

        public delegate void socketDataArrivalHandler(byte[] data, state state);

        public delegate void socketErrorHandler(string error);

        public delegate void socketSendCompleteHandler(int bytesSent);
    }
}

