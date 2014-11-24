using System;
using System.Collections.Generic;
using System.Text;
using QuantX;
using System.Threading;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;

namespace QuantX
{

    public class Plugin : IPlugin
    {
       
        IHost MyHost;
        String MyPath;
        int stoporder = 0;
        int nstart_hh = 0;
        int nstart_mm = 0;
        private readonly object lockObj = new object();
        

        #region "Properties"

        public int PID
        {
            get { return 12; }
        }

        public string Name
        {
            get { return "Stmp_MOC_Plugin"; }
        }

        public System.Windows.Forms.Form Plugin_Face()
        {
            return MainModule.frmdlg;
        }

        public IHost Host
        {
            get
            {
                return MyHost;
            }
            set
            {
                MyHost = value;
            }
        }

        public string Plugin_Path
        {
            get
            {
                return MyPath;
            }
            set
            {
                MyPath = value;
            }
        }

        #endregion

        public void Initialize()
        {
            MainModule.frmdlg = new stmpMainform();
            MainModule.frmdlg.myparent = this;
            MainModule.objStructureDataType = new StructureTestStrategies();

            MainModule.heartbeatTimer = new System.Timers.Timer();
            MainModule.heartbeatTimer.Interval = 60000;
            MainModule.heartbeatTimer.AutoReset = true;
            MainModule.heartbeatTimer.Elapsed += new System.Timers.ElapsedEventHandler(heartbeatTimer_Elapsed);
            MainModule.heartbeatTimer.Enabled = false;

            MainModule._itrackList = new List<int>();
            MainModule._imocDictionary = new Dictionary<int, int>();
            //Call Client Manager
          
            //do here
            ThreadStart myThreadDelegate = new ThreadStart(myloop);
            Thread myThread = new Thread(myThreadDelegate);
            myThread.Priority = ThreadPriority.Normal;
            myThread.Start();



        }
        private void heartbeatTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                MainModule.timeTick = MainModule.timeTick - 1;
                if (MainModule.timeTick == 0) 
                {
                    MainModule.startMoc = 0;
                }
            }
            catch (Exception ex)
            {
                MainModule._clsstmputilobj.AppendTrace("HeartBeatTimer Elapsed"+ ex.ToString(), Color.Blue);
            }

        }

        public void ConnectNSETCPCepSocket() 
        {

            if (MainModule.NSETCPCepSocket == null)
            {
                
                if (!MainModule.frmdlg.ipBox.Text.Equals(null) && !MainModule.frmdlg.portBox.Text.Equals(null))
                {
                    MainModule.NSETCPCepSocket = new TCPSocket();
                    string ip = MainModule.frmdlg.ipBox.Text;
                    int port = Convert.ToInt32(MainModule.frmdlg.portBox.Text);
                    MainModule.NSETCPCepSocket.Connect(ip, port);

                    MainModule.NSETCPCepSocket.onDataArrival += new TCPSocket.socketDataArrivalHandler(this.TBTCEPSocket_onDataArrival);
                    MainModule.NSETCPCepSocket.onConnect += new TCPSocket.socketConnectHandler(this.TBTCEPSocket_onConnect);
                    MainModule.NSETCPCepSocket.onError += new TCPSocket.socketErrorHandler(this.TBTCEPSocket_onError);
                    MainModule.NSETCPCepSocket.onDisconnect += new TCPSocket.socketConnectHandler(this.TBTCEPSocket_onDisconnect);
                }
            }
        }

        public void InitializeMarketPicturetoZeros()
        {

            if ((MainModule.objMarketWatch != null) && (MainModule.objMarketWatch.Length >= 1))
            {

                for (int i = 0; i < MainModule.objMarketWatch.Length; i++)
                {
                    MainModule.objMarketWatch[i].dBid = 0;
                    MainModule.objMarketWatch[i].dAsk = 0;
                 //  Trace.WriteLine("In initialization of Market picture to zeros" + i + " Bid " + MainModule.objMarketWatch[i].dBid + " Ask " + MainModule.objMarketWatch[i].dAsk);
                    MainModule._clsstmputilobj.AppendTrace("In initialization of Market picture to zeros" + i + " Bid " + MainModule.objMarketWatch[i].dBid + " Ask " + MainModule.objMarketWatch[i].dAsk, Color.Blue);
                }
            }
        }

        public void placingfffff()
        {
            try
            { 
                for (int i = 0; i < MainModule.dtNetPosition.Rows.Count; i++)
                {
                    DataRow rowss = MainModule.dtNetPosition.Rows[i];


                    string oo_symbol = rowss["Symbol"].ToString();
                    double oo_buyqty = Convert.ToDouble(rowss["BuyQuantity"].ToString());
                    double oo_buyprice = Convert.ToDouble(rowss["BuyPrice"].ToString());
                    double oo_sellqty = Convert.ToDouble(rowss["SellQuantity"].ToString());
                    double oo_sellprice = Convert.ToDouble(rowss["SellPrice"].ToString());

                    double dd_tgts = MainModule.objMarketWatch[i].dTTickSize;

                    double dd_bidsss = MainModule.objMarketWatch[i].dBid;
                    double dd_asksss = MainModule.objMarketWatch[i].dAsk;

                    double dd_netqty = oo_buyqty-oo_sellqty;
                    double dd_netprice = ((oo_buyqty * oo_buyprice) - (oo_sellqty * oo_sellprice)) / (oo_buyqty - oo_sellqty);
                    double dd_roundtrip_pl = (Math.Min(oo_buyqty, oo_sellqty)) * dd_tgts;

                    double dd_roundtrip_avg = dd_roundtrip_pl / Math.Abs(dd_netqty);

                    double dd_remainqty_price = 0;
                    double dd_remainqty_tgtprice = 0;
                    double dd_remainqtypl = 0;
                    double dd_totalpls = 0;
                    double dd_finalpl = 0;
                    double dd_turnover=0;
                    if (dd_netqty > 0)
                    {
                        dd_remainqty_price = dd_netprice + dd_roundtrip_avg;
                        dd_remainqty_tgtprice = dd_remainqty_price + dd_tgts;
                        dd_remainqtypl = (dd_bidsss - dd_remainqty_price) * Math.Abs(dd_netqty);
                        dd_totalpls = dd_roundtrip_pl + dd_remainqtypl;
                        dd_turnover = (oo_buyqty * oo_buyprice) + (oo_sellqty * oo_sellprice) + (Math.Abs(dd_netqty) * dd_bidsss);
                        dd_turnover = dd_turnover / 2.0;
                        dd_finalpl = dd_totalpls - (dd_turnover * 0.00033265);
                    }
                    if (dd_netqty < 0)
                    {
                        dd_remainqty_price = dd_netprice - dd_roundtrip_avg;
                        dd_remainqty_tgtprice = dd_remainqty_price - dd_tgts;
                        dd_remainqtypl = (dd_remainqty_price - dd_asksss) * Math.Abs(dd_netqty);
                        dd_totalpls = dd_roundtrip_pl + dd_remainqtypl;

                        dd_turnover = (oo_buyqty * oo_buyprice) + (oo_sellqty * oo_sellprice) + (Math.Abs(dd_netqty) * dd_asksss);
                        dd_turnover = dd_turnover / 2.0;
                        dd_finalpl = dd_totalpls - (dd_turnover * 0.00033265);

                    }
                    MainModule._clsstmputilobj.AppendTrace("Symbol:" + oo_symbol + "   NetQty:" + dd_netqty + "  NetPrice:" + dd_netprice + "     roundtrippl:" + dd_roundtrip_pl + "     roundtripavg:" + dd_roundtrip_avg + "   remainQtyPrice:" + dd_remainqty_price + "    remainqtytgtprice:" + dd_remainqty_tgtprice + "  remainqtypl" + dd_remainqtypl + "   grosspl" + dd_totalpls + "   netpl:" + dd_finalpl, Color.Blue);


                }
            }
            catch (Exception ee)
            {
                MainModule._clsstmputilobj.AppendTrace("netqty pl  eeee :" + ee.ToString(), Color.Blue);
            }
        }

        public void Model_AdjustDistribution()
        {
            try
            {               
                string line = null;
                System.IO.StreamReader file = new System.IO.StreamReader(@"qty_inputs.txt");
                while ((line = file.ReadLine()) != null)
                {

                    string[] disString = line.Split(',');
                    MainModule._clsstmputilobj.AppendTrace("Adj String :" + line, Color.Blue);

                    string tt_symbol = disString[0];
                    string tt_account= disString[1];
                    double tt_price = Convert.ToDouble(disString[2]);
                    int tt_qty = Convert.ToInt32(disString[3]);

                    DataRow row = MainModule.dtfileinputs.NewRow();
                    row["symbol"] = tt_symbol;
                    row["account"] = tt_account;
                    row["price"] = tt_price;
                    row["qty"] = tt_qty;
                    MainModule.dtfileinputs.Rows.Add(row);
                }

                file.Close();

                Model_inputs_minutesqty();
             }
            catch (Exception ex)
            {

                //Trace.WriteLine("Model Distribution Adjustment"+ex);
                MainModule._clsstmputilobj.AppendTrace("Model Distribution Adjustment" + ex.ToString(), Color.Blue);

            }

        }

        public void Model_inputs_minutesqty()
        {
            try
            {
                string line = null;
                System.IO.StreamReader file = new System.IO.StreamReader(@"inputs_minutesqty.txt");
                while ((line = file.ReadLine()) != null)
                {
                    string[] disString = line.Split(',');
                    MainModule._clsstmputilobj.AppendTrace("Adj String :" + line, Color.Blue);

                    string tt_symbol = disString[0];
                    string tt_account = disString[1];
                    int tt_minqty = Convert.ToInt32(disString[2]);

                    DataRow row = MainModule.dtpricemax_input.NewRow();
                    row["symbol"] = tt_symbol;
                    row["account"] = tt_account;
                    row["minuteqty"] = tt_minqty;
                    MainModule.dtpricemax_input.Rows.Add(row);
                }
                file.Close();
            }
            catch (Exception ex)
            {                
                MainModule._clsstmputilobj.AppendTrace("Model minutesqty" + ex.ToString(), Color.Blue);
            }
        }

        private void TBTCEPSocket_onDataArrival(byte[] bReceiveData, state state)
        {
            try
            {
                string str_signal = System.Text.ASCIIEncoding.ASCII.GetString(bReceiveData);               
                string[] str_mulsignals = str_signal.Split(',');

                if (MainModule.startMoc == 1)
                {
                    int token = Convert.ToInt32(str_mulsignals[2]);
                    double dmoc = Convert.ToDouble(str_mulsignals[3]);
                
                    if (MainModule.objMarketWatch != null)
                    {
                        for (int iIndex = 0; iIndex < MainModule.objMarketWatch.Length; iIndex++)
                        {
                            int tokenid = (int)MainModule.objMarketWatch[iIndex].iInstrumentIdentifier;

                            if (tokenid == token)
                            {
                                double _moc = Convert.ToDouble(str_mulsignals[3]);
                                MainModule.objMarketWatch[iIndex].dMOC = _moc;
                                if (MainModule.starttrading != 1)
                                {
                                    Trace.WriteLine(str_mulsignals[1]+", "+str_mulsignals[2]+", "+str_mulsignals[3]);
                                }                                
                            }
                        }
                    }                                          
                }
               /* else if(MainModule.startMoc ==2)
                {
                    int token = Convert.ToInt32(str_mulsignals[0]);

                    string str_getbuysellsignal = str_mulsignals[2];
                    int _getbuysellsignal = 0;

                    if (str_getbuysellsignal == "SELL")
                    {
                        _getbuysellsignal = 2;
                    }
                    else
                    {
                        _getbuysellsignal = 1;
                    }

                    if (MainModule.startfeed == 1)
                    {

                        for (int i = 0; i < MainModule.objMarketWatch.Length; i++)
                        {
                            uint tokenid = MainModule.objMarketWatch[i].iInstrumentIdentifier;

                            IHost.structQuote _getquote = MyHost.getQuote(IHost.Exchanges.NSE, (Int32)tokenid);

                            if (MainModule.objMarketWatch[i].iInstrumentIdentifier == (int)token)
                            {
                                MainModule.objMarketWatch[i]._quantbuysell = _getbuysellsignal;
                            }
                        }
                    }
                }    */                            
            }
            catch (Exception ex)
            {
                Trace.WriteLine("TBTCEPSocket_onDataArrival "+ex.ToString());
                MyHost.Add_Log_Host("D", "In CeP", ex.ToString());
            }

        }
        
        private void TBTCEPSocket_onConnect(state state)
        {
            Trace.WriteLine("TBTCEPSocket_onConnect");
        }

        private void TBTCEPSocket_onError(string error)
        {
            Trace.WriteLine("TBTCEPSocket_onError");
            MainModule._checkcepsocket = 0;
        }

        private void TBTCEPSocket_onDisconnect(state state)
        {
            Trace.WriteLine("TBTCEPSocket_onDisconnect");
            Trace.WriteLine("TBT CEP Socket Re-Connected ! ");
        }
     

        public void myloop()
        {


            try
            {
             IHost.structQuote scripQuote;

                do
                {
                 if (MainModule.startfeed == 1)
                    {
                    if ((MainModule.objMarketWatch != null) && (MainModule.objMarketWatch.Length >= 1))
                        {
                          for (int i = 0; i < MainModule.objMarketWatch.Length; i++)
                            {
                                uint tokenid = MainModule.objMarketWatch[i].iInstrumentIdentifier;
                                int assettype = MainModule.objMarketWatch[i].aType;

                                if (MainModule.objMarketWatch[i].iInstrumentIdentifier == tokenid)
                                {
                                    //equity
                                    if (assettype == 0)
                                    {
                                        scripQuote = MyHost.getQuote(IHost.Exchanges.NSE, (int)tokenid);


                                        MainModule._clsstmputilobj.MarketPictureReceived(scripQuote, i);
                                        scripQuote.Token = (int)tokenid;
                                    
                                        IHost.structScripInfo scripinfo = MyHost.getScripInfo(IHost.Exchanges.NSE, (int)tokenid);
                                        if (MainModule.starttrading == 1)
                                        {
                                            //ProcessTradeLogic(scripQuote, i);
                                            MarketQuoteReceived(i, scripQuote, IHost.Exchanges.NSE, scripQuote.Token, scripQuote.LTP, scripQuote.LTQ, scripQuote.Volume, scripQuote.LTTime, scripQuote.BidQty1, scripQuote.BidPrice1, scripQuote.BidNum1, scripQuote.AskQty1, scripQuote.AskPrice1, scripQuote.AskNum1, scripinfo.TickSize);
                                        }
                                    }
                                    else if (assettype > 0) // derivatives
                                    {
                                        scripQuote = MyHost.getQuote(IHost.Exchanges.NSEFO, (int)tokenid);
                                        MainModule._clsstmputilobj.MarketPictureReceived(scripQuote, i);
                                        scripQuote.Token = (int)tokenid;
                                        IHost.structScripInfo scripinfo1 = MyHost.getScripInfo(IHost.Exchanges.NSE, (int)tokenid);


                                        if (MainModule.starttrading == 1)
                                        {
                                            //ProcessTradeLogic(scripQuote, i);
                                            MarketQuoteReceived(i, scripQuote, IHost.Exchanges.NSEFO, scripQuote.Token, scripQuote.LTP, scripQuote.LTQ, scripQuote.Volume, scripQuote.LTTime, scripQuote.BidQty1, scripQuote.BidPrice1, scripQuote.BidNum1, scripQuote.AskQty1, scripQuote.AskPrice1, scripQuote.AskNum1, scripinfo1.TickSize);
                                        }
                                    }




                                }
                            }
                        }

                        
                        Thread.Sleep(10);
                    }

                } while (true);

            }
            catch (Exception ex) {

                Trace.WriteLine("e: in myloop feed !");
            }
        }

        public void DataReceived(byte[] bt)
        {
            //code here
        }

 

        public void MarketQuoteReceived(int mIndex, IHost.structQuote strucquote,IHost.Exchanges Exch, int Token, int LTP, int LTQ, long Volume, long LTTime, int BidQty1, int BidPrice1, int BidNumOrd1, int AskQty1, int AskPrice1, int AskNumOrd1,int Ticksize)
        {

            try {

                String tokenstr = Token.ToString();
                try
                {
                    lock (lockObj)
                    {
                        
                        MainModule._clsstmputilobj.MarketPictureReceived(strucquote, mIndex);

                     
                      
                        if (MainModule._clsstmputilobj.MarketDictionary.ContainsKey(MainModule.objMarketWatch[mIndex].iWatchId))
                        {

                            StructureTestStrategies.DailyMarketWatch dmg1 = MainModule._clsstmputilobj.MarketDictionary[MainModule.objMarketWatch[mIndex].iWatchId];

                            dmg1.tokenid = Token;
                            dmg1.volume = Volume;
                            dmg1.bid = BidPrice1;
                            dmg1.ask = AskPrice1;
                            dmg1.ltp = LTP;

                            MainModule._clsstmputilobj.MarketDictionary[MainModule.objMarketWatch[mIndex].iWatchId] = dmg1;

                            if (MainModule._clsstmputilobj.strategyDictionary.ContainsKey(MainModule.objMarketWatch[mIndex].iWatchId))
                            {
                               ProcessTradeLogic(strucquote, mIndex,Ticksize);
                            }

                        }
                        else
                        {

                            Trace.WriteLine("Key not found for Id Market Picture Received");
                        }

                    }
                }
                catch (Exception ex)
                {
                    Trace.WriteLine("QuoteReceived...................... !" + ex.ToString());
                }
            
            
            }
            catch (Exception ex)
            {


            }


        }

        public void PlaceStgOrder(Vwapstrategy.Strategy_Vwap vwapstg, StructureTestStrategies.DailyMarketWatch dmg, int mktINdex)
        {
            try
            {

              /*  if (vwapstg.Token == dmg.tokenid)
                {
                    if (stoporder != 1)
                    {

                        // stoporder = 1;
                        if (vwapstg.Price < dmg.bid)
                        {

                            //   vwapstg.Price = dmg.bid;
                            double cbid = (double)(dmg.bid / MainModule.iDivisor);
                            cbid = (double)((dmg.bid / 100)) * 100;

                            //vwapstg._dynamicobook[1].bid1price = (int)cbid;

                          //  Trace.WriteLine("in BUY Order Placing1 " + cbid.ToString());
                            //vwapstg._dynamicobook[1].bid1qty = 1;
                            //vwapstg._dynamicobook[1].bid2qty = 1;
                            //vwapstg._dynamicobook[1].bid3qty = 1;
                            //vwapstg._dynamicobook[1].bid4qty = 1;
                            //vwapstg._dynamicobook[1].bid5qty = 1;

                            double nextprc2 = (double)((dmg.bid / 100) - 0.5) * MainModule.iDivisor1;
                            //double nextprc3 = (double)((dmg.bid / 100) - 1) * MainModule.iDivisor1;
                            //double nextprc4 = (double)((dmg.bid / 100) - 1.5) * MainModule.iDivisor1;
                            //double nextprc5 = (double)((dmg.bid / 100) - 2) * MainModule.iDivisor1;

                            //vwapstg._dynamicobook[1].bid2price = (int)nextprc2;
                            //vwapstg._dynamicobook[1].bid3price = (int)nextprc3;
                            //vwapstg._dynamicobook[1].bid4price = (int)nextprc4;
                            //vwapstg._dynamicobook[1].bid5price = (int)nextprc5;

                            MyHost.sendOrder(vwapstg.StrategyId, IHost.Exchanges.NSE, vwapstg.Token, IHost.ActionType.Buy, 1, 0, (int)cbid, IHost.OrderTypes.Normal, "AB101");
                            /*  MainModule.frmdlg.MyParent.MyHost.sendOrder(vwapstg.StrategyId, IHost.Exchanges.NSE, vwapstg.Token, IHost.ActionType.Buy, 1, 0, (int)vwapstg._dynamicobook[1].bid2price, IHost.OrderTypes.Normal, "AB101");
                              MainModule.frmdlg.MyParent.MyHost.sendOrder(vwapstg.StrategyId, IHost.Exchanges.NSE, vwapstg.Token, IHost.ActionType.Buy, 1, 0, (int)vwapstg._dynamicobook[1].bid3price, IHost.OrderTypes.Normal, "AB101");
                              MainModule.frmdlg.MyParent.MyHost.sendOrder(vwapstg.StrategyId, IHost.Exchanges.NSE, vwapstg.Token, IHost.ActionType.Buy, 1, 0, (int)vwapstg._dynamicobook[1].bid4price, IHost.OrderTypes.Normal, "AB101");
                              MainModule.frmdlg.MyParent.MyHost.sendOrder(vwapstg.StrategyId, IHost.Exchanges.NSE, vwapstg.Token, IHost.ActionType.Buy, 1, 0, (int)vwapstg._dynamicobook[1].bid5price, IHost.OrderTypes.Normal, "AB101");*/


                            /*Trace.WriteLine("in BUY Order Placing2 " + vwapstg._dynamicobook[1].bid2price.ToString());
                               Trace.WriteLine("in BUY Order Placing3 " + vwapstg._dynamicobook[1].bid3price.ToString());
                               Trace.WriteLine("in BUY Order Placing4 " + vwapstg._dynamicobook[1].bid4price.ToString());
                               Trace.WriteLine("in BUY Order Placing5 " + vwapstg._dynamicobook[1].bid5price.ToString());*/
                       /* }*/




                      /*  if (vwapstg.Price < dmg.ask)
                        {
                            // Trace.WriteLine("in Sell Order Placing");
                            //double cask = (double)(dmg.ask / MainModule.iDivisor);
                            //Trace.WriteLine("in Sell Order Placing1" + cask.ToString());
                            // MainModule.frmdlg.MyParent.MyHost.sendOrder(vwapstg.StrategyId, IHost.Exchanges.NSE, vwapstg.Token, IHost.ActionType.Sell, 1, 0, dmg.ask, IHost.OrderTypes.Normal, "AB101");
                            double nextprc = (double)((dmg.bid / 100) + 0.5) * 100;

                            MyHost.sendOrder(vwapstg.StrategyId, IHost.Exchanges.NSE, vwapstg.Token, IHost.ActionType.Sell, 1, 0, (int)nextprc, IHost.OrderTypes.Normal, "AB101");
                            // nextprc = (double)((dmg.ask / 100) + 1) * MainModule.iDivisor1;
                            // MainModule.frmdlg.MyParent.MyHost.sendOrder(vwapstg.StrategyId, IHost.Exchanges.NSE, vwapstg.Token, IHost.ActionType.Sell, 1, 0, (int)nextprc, IHost.OrderTypes.Normal, "AB101");
                            // nextprc = (double)((dmg.ask / 100) + 1.5) * MainModule.iDivisor1;

                            // MainModule.frmdlg.MyParent.MyHost.sendOrder(vwapstg.StrategyId, IHost.Exchanges.NSE, vwapstg.Token, IHost.ActionType.Sell, 1, 0, (int)nextprc, IHost.OrderTypes.Normal, "AB101");
                            // nextprc = (double)((dmg.ask / 100) + 2) * MainModule.iDivisor1;
                            // MainModule.frmdlg.MyParent.MyHost.sendOrder(vwapstg.StrategyId, IHost.Exchanges.NSE, vwapstg.Token, IHost.ActionType.Sell, 1, 0, (int)nextprc, IHost.OrderTypes.Normal, "AB101");

                        }*/



                        // vwapstg.Price = dmg.bid;
                    /*    MainModule._clsstmputilobj.strategyDictionary[vwapstg.Token] = vwapstg;


                    }
                    else
                    {


                    }

                }*/


            }
            catch (Exception eq)
            {

                //  AddText("Error : PlaceTestStgOder"+eq.ToString());
                Trace.WriteLine("Error : PlaceTestStgOder" + eq.ToString());

            }

        }

      


        public void QuoteReceived(IHost.Exchanges Exch, int Token, int LTP, int LTQ, long Volume, long LTTime, int BidQty1, int BidPrice1, int BidNumOrd1, int AskQty1, int AskPrice1, int AskNumOrd1)
        { //code here

             

        }



        public int GetBufferPrice(int _uuid,int orderprice,int orderqty,int BuySell,int totaltrdqty)
        {
            int bfp_return=0;
          try {

                

                return bfp_return;
            
            }
            catch (Exception ex)
            {
              //  Trace.WriteLine("E:GetBufferPrice");

                MainModule._clsstmputilobj.AppendTrace("E:GetBufferPrice", Color.Blue);

            }



            return 0;
        }



        public void WriteAutoDistributionFile()
        {

            for (int i = 0; i < MainModule.iMaximumScripts; i++)
            { 
            
            }
        }
        public void Trade_Confirmation(int OID, IHost.Exchanges Exch, int Token, string DispName, long ExchOrdNum, int ExchTradeNum, int BuySell, int TrdQty, int TrdPrice, int OrderQty, int TotalTrdQty, string Account, DateTime TradeTime, int UID)
        { //code here

          
            int _uid = Math.Abs(UID);

          try
            {
                IHost.strOrderInfo  _structOrderinfo = MyHost.getOrderStatus(OID);
                MainModule._clsstmputilobj.AppendTrace("TC:-" + " :Token:" + Token + ":BuySell:" + BuySell + ":TQ:" + TrdQty.ToString() + ":OP:" + _structOrderinfo.OrderPrice / MainModule.iDivisor1 + ":TP:" + TrdPrice / MainModule.iDivisor1, Color.Blue);

                /*DataRow[] chkrowArray = MainModule.dtRefOrder.Select("Oid = '" + OID + "' and ExchOrdno = 0");
                if (chkrowArray.Length > 0)
                {
                    DataRow row = chkrowArray[0];                                   
                    row["ExchOrdno"] = ExchOrdNum;
                    MainModule._clsstmputilobj.AppendTrace("OST:Ex Updated:" + ExchOrdNum, Color.Blue);
                    MainModule.dtRefOrder.AcceptChanges();                          
                } */                      

                for (int i = 0; i < MainModule.iMaximumScripts; i++)
                {
                    if (MainModule.objMarketWatch[i].iWatchId == _uid)
                    {

                        if (MainModule._imocDictionary.ContainsKey(OID))
                        {
                            if (BuySell == 1)
                            {
                                double Newprice = Math.Round(((TrdPrice) + (MainModule.objMarketWatch[i].dTTickSize * MainModule.iDivisor1)),2);
                                double newbiddif = Math.Round((Newprice / 5), 2);                                
                                Newprice = Math.Round((newbiddif * 5), 2);
                                
                                MyHost.sendOrder(MainModule.objMarketWatch[i].iWatchId, IHost.Exchanges.NSE, MainModule.objMarketWatch[i].Token, IHost.ActionType.Sell, TrdQty, 0, (int)Newprice, IHost.OrderTypes.Normal, MainModule.objMarketWatch[i].account);
                                MainModule.objMarketWatch[i].BuyQuantityTraded = MainModule.objMarketWatch[i].BuyQuantityTraded + TrdQty;
                            }
                            else
                            {
                                double Newprice = Math.Round(((TrdPrice) - (MainModule.objMarketWatch[i].dTTickSize * MainModule.iDivisor1)),2);
                                double newbiddif = Math.Round((Newprice / 5), 2);
                                Newprice = Math.Round((newbiddif * 5), 2);

                                MyHost.sendOrder(MainModule.objMarketWatch[i].iWatchId, IHost.Exchanges.NSE, MainModule.objMarketWatch[i].Token, IHost.ActionType.Buy, TrdQty, 0, (int)Newprice, IHost.OrderTypes.Normal, MainModule.objMarketWatch[i].account);
                                MainModule.objMarketWatch[i].SellQuantityTraded = MainModule.objMarketWatch[i].SellQuantityTraded + TrdQty;
                            }
                            if (OrderQty == TotalTrdQty)
                            {
                                MainModule._imocDictionary.Remove(OID);
                            }
                        }
                        else
                        {
                            if (BuySell == 1)
                            {
                                MainModule.objMarketWatch[i].BuyQuantityTraded = MainModule.objMarketWatch[i].BuyQuantityTraded + TrdQty;
                                if (MainModule.objMarketWatch[i].highprice == Math.Round(((TrdPrice / MainModule.dDivisor) + MainModule.objMarketWatch[i].dTTickSize),2))
                                {
                                    MainModule.objMarketWatch[i].highprice = 0;
                                }
                            }
                            else
                            {
                                MainModule.objMarketWatch[i].SellQuantityTraded = MainModule.objMarketWatch[i].SellQuantityTraded+ TrdQty;                       
                                if (MainModule.objMarketWatch[i].lowprice == Math.Round(((TrdPrice / MainModule.dDivisor) - MainModule.objMarketWatch[i].dTTickSize),2))
                                {
                                    MainModule.objMarketWatch[i].lowprice = 0;
                                }
                            }

                        }

                        if (MainModule._clsstmputilobj.strategyDictionary.ContainsKey(_uid))
                        {

                            StructureTestStrategies.MarketWatch vwap1 = MainModule._clsstmputilobj.strategyDictionary[_uid];

                            vwap1.tBook = new StructureTestStrategies.Strategy_Tradebook();
                            vwap1.tBook.Account = Account;
                            vwap1.tBook.token = Token;
                            vwap1.tBook.buysell = BuySell;
                            vwap1.tBook.Dispname = DispName;
                            vwap1.tBook.texch = Exch;
                            vwap1.tBook.exchordnum = ExchOrdNum;
                            vwap1.tBook.oid = OID;
                            vwap1.tBook.trdqty = TrdQty;
                            vwap1.tBook.trdprice = TrdPrice;
                            vwap1.tBook.tottradqty = TotalTrdQty;
                            vwap1.tBook.StrategyId = _uid;
                            vwap1._listtradebook.Add(vwap1.tBook);

                            for (int vm = 0; vm < vwap1._listorderbook.Count; vm++)
                            {

                                StructureTestStrategies.Strategy_TestOrderbook obj = vwap1._listorderbook[vm];

                                if (obj.oid==OID)
                                {
                                   obj.orderstatus = 20;
                                }

                                vwap1._listorderbook[vm] = obj;
                            }

                            MainModule._clsstmputilobj.strategyDictionary[_uid] = vwap1;

                            TradeConfirmReceived(vwap1.tBook, i);

                        }
                        
                    }

                }

            }
            catch (Exception ex)
            {
                //Trace.WriteLine("TC Log : "+ex.ToString());
                MainModule._clsstmputilobj.AppendTrace("TC Log : "+ex.ToString(),Color.Blue);

            }
        }


        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>



        public void TradeConfirmReceived(StructureTestStrategies.Strategy_Tradebook obj, int index)
        {
            try
            {
              
                DataRow row = MainModule.dtTradeBook.NewRow();
                row["Account"] = obj.Account;
                row["Dispname"] = obj.Dispname;

                if (IHost.Exchanges.NSE == obj.texch)
                {

                    row["Exch"] = "NSE";
                }


              
                row["ExchOrdNum"] = obj.exchordnum;
                row["BuyorSell"] = obj.buysell;
                row["Oid"] = obj.oid;
                row["TrdQty"] = obj.trdqty;
                row["Token"] = obj.token;
                row["TrdPrice"] = obj.trdprice;
                row["TotTrdQty"] = obj.tottradqty;
                row["StrategyID"] = obj.StrategyId;
              
                MainModule.dtTradeBook.Rows.InsertAt(row, 0);
                MainModule.dtTradeBook.AcceptChanges();
              
                MainModule._clsstmputilobj.UpdateNetPosition2(obj.StrategyId, index);

            }
            catch (Exception ex)
            {
                //Trace.WriteLine("In Traceconfirmation Received" + ex.ToString());
                MainModule._clsstmputilobj.AppendTrace("In Tradeconfirmation Received" + ex.ToString(), Color.Blue);

            }


        }


        public void SendOrder(int token,int _buysell,double price, string account,int qty,int exchange)
        {
            try
            {
                Trace.WriteLine("1");
                if (_buysell == 1)
                {
                    double _price = price * MainModule.iDivisor1;

                    if (exchange == 1)
                    {

                        Trace.WriteLine("2");
                        int _iwatchID = Convert.ToInt32(MainModule.frmdlg.watchidBox.Text);
                        int bsentconf = MyHost.sendOrder(_iwatchID, IHost.Exchanges.NSE, token, IHost.ActionType.Buy, qty, 0, (Int32)_price, IHost.OrderTypes.Normal, account);
                    }
                    else
                    {
                        Trace.WriteLine("3");
                        int _iwatchID = Convert.ToInt32(MainModule.frmdlg.watchidBox.Text);
                        int bsentconf = MyHost.sendOrder(_iwatchID, IHost.Exchanges.NSEFO, token, IHost.ActionType.Buy, qty, 0, (Int32)_price, IHost.OrderTypes.Normal, account);

                    }

                }
                else
                {
                    double _price = price * MainModule.iDivisor1;

                    if (exchange == 1)
                    {
                        int bsentconf = MyHost.sendOrder(1, IHost.Exchanges.NSE, token, IHost.ActionType.Sell, qty, 0, (Int32)_price, IHost.OrderTypes.Normal, account);
                    }
                    else
                    {
                        int bsentconf = MyHost.sendOrder(1, IHost.Exchanges.NSEFO, token, IHost.ActionType.Sell, qty, 0, (Int32)_price, IHost.OrderTypes.Normal, account);

                    }

                }


            }
            catch (Exception ex)
            {

                Trace.WriteLine("SendOrder...." + ex.ToString());

            }

           
            

            
        }

        public void CancelAllOrdersSelectedScript(int stgid)
        {

            try
            {
                if (MainModule._clsstmputilobj.strategyDictionary.ContainsKey(stgid))
                {

                    StructureTestStrategies.MarketWatch vwapstg = MainModule._clsstmputilobj.strategyDictionary[stgid];

                    for (int i = 0; i < vwapstg._listorderbook.Count; i++)
                    {

                        StructureTestStrategies.Strategy_TestOrderbook obj = vwapstg._listorderbook[i];

                        if (obj.orderstatus == 1)
                        {
                                        

                                MyHost.CancelOrder(obj.oid);
                                obj.orderstatus = 5;
                                //  Trace.WriteLine("S Cl:" + obj.oid + obj.orderstatus);
                                MainModule._clsstmputilobj.AppendTrace("F:CancelOrders:" + obj.oid + obj.orderstatus, Color.Blue);
                            
                        }


                        vwapstg._listorderbook[i] = obj;
                    }

                    MainModule._clsstmputilobj.strategyDictionary[stgid] = vwapstg;
                }
            }
            catch (Exception ex)
            {
                MainModule._clsstmputilobj.AppendTrace("Cancel All Orders Selected Script" + ex.ToString(), Color.Blue);
            }
            
        }

        public void CancelAllOrdersSelectedScript(int stgid,int buysellno)
        {

            try
            {
                if (MainModule._clsstmputilobj.strategyDictionary.ContainsKey(stgid))
                {

                    StructureTestStrategies.MarketWatch vwapstg = MainModule._clsstmputilobj.strategyDictionary[stgid];

                    for (int i = 0; i < vwapstg._listorderbook.Count; i++)
                    {

                        StructureTestStrategies.Strategy_TestOrderbook obj = vwapstg._listorderbook[i];

                        if (obj.orderstatus == 1 && obj.buysell == 1)
                        {
                            MyHost.CancelOrder(obj.oid);
                            obj.orderstatus = 5;
                            //  Trace.WriteLine("S Cl:" + obj.oid + obj.orderstatus);
                            MainModule._clsstmputilobj.AppendTrace("F:CancelOrders:" + obj.oid + obj.orderstatus, Color.Blue);
                        }
                        vwapstg._listorderbook[i] = obj;
                    }
                    MainModule._clsstmputilobj.strategyDictionary[stgid] = vwapstg;
                }
            }
            catch (Exception ex)
            {
                MainModule._clsstmputilobj.AppendTrace("Cancel All Orders Selected Script" + ex.ToString(), Color.Blue);
            }

        }



        public void CalculateNetProfitandLoss()
        {
       /* try{

            MainModule._clsstmputilobj.AppendTrace("CalculateNetProfitandLoss:",Color.Blue);
            DataTable table = MainModule.dtRefOrder.DefaultView.ToTable(true, new string[] { "Uid" });
                
                decimal Netpos = 0.0M;
                double _bprice = 0;
                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        
                        int num2 = Convert.ToInt32(table.Rows[i]["Uid"]);

                        DataView view = new DataView(MainModule.dtRefOrder);
                        decimal num3 = 0M;
                        decimal num4 = 0M;
                        decimal num5 = 1M;
                        int num6 = 0;
                        int num7 = 0;
                        view.RowFilter = "Uid =  '" + num2 + "' AND  COUNT(Oid) > 1 AND Tradeornot = 0";
                        DataTable table2 = view.ToTable();
                        table2.Columns.Add("TPrice", typeof(decimal));
                        table2.Columns["TPrice"].DefaultValue = 0;
                        table2.Columns["TPrice"].Expression = "TrdPrice * TrdQty";

                        if (table2.Rows.Count > 0)
                        {
                            MainModule._clsstmputilobj.AppendTrace("count:"+table2.Rows.Count+"UID"+num2,Color.Blue);
                            num3 = Convert.ToDecimal(table2.Compute("Sum(TPrice)", ""));
                            num6 = Convert.ToInt32(table2.Compute("Sum(TrdQty)", ""));
                        }

                        if (num3 > 0 && num6 > 0)
                        {
                            _bprice = Convert.ToDouble((num3 / num6));

                            double newdif = Math.Round((_bprice / 5), 2);
                            double dd_newavgprice = Math.Round((newdif * 5), 2);
                            if (dd_newavgprice <= _bprice)
                            {
                            }
                            else
                            {
                                dd_newavgprice = dd_newavgprice - MainModule.objMarketWatch[i].dTickSize;
                            }

                            _bprice = dd_newavgprice;

                            MainModule._clsstmputilobj.AppendTrace("BP:" + _bprice, Color.Blue);
                        }

                        foreach (DataRowView drv in view)
                        {

                            DataRow[] rowArray = MainModule.dtRefOrder.Select("OID =  '" + Convert.ToInt32(drv[1].ToString()) + "'");
                            MainModule._clsstmputilobj.AppendTrace("OID" + drv[1].ToString(), Color.Blue);


                            if (rowArray.Length > 0)
                            {
                                MainModule._clsstmputilobj.AppendTrace("OID" + drv[1].ToString() + "ExchOrdno " + drv[2].ToString() + " TrdPrice" + drv[4].ToString() + "TrdQty " + drv[5].ToString() + "OrgPrice" + drv[6].ToString(), Color.Blue);

                              //  if (Convert.ToDouble(rowArray[0]["OrgPrice"].ToString()) != _bprice)
                                {
                                    MainModule._clsstmputilobj.AppendTrace("MODP-" + _bprice, Color.Blue);

                                   
                                    MyHost.CancelOrder(Convert.ToInt32(drv[1].ToString()));


                                    rowArray[0]["Tradeornot"] = 1;
                                    MainModule.dtRefOrder.AcceptChanges();
                                }
                              
                            }
                        }

                        int uid = num2;
                        int iIndex=uid-1;

                        //Place new order again

                        if (num6 > 0 && _bprice > 0)
                        {


                            int Oid = MyHost.sendOrder(num2, IHost.Exchanges.NSE, MainModule.objMarketWatch[iIndex].Token, IHost.ActionType.Buy, num6, 0, (Int32)(_bprice * MainModule.iDivisor1), IHost.OrderTypes.Normal, MainModule.objMarketWatch[iIndex].account);

                            MainModule._clsstmputilobj.AppendTrace("NewOid"+Oid,Color.Blue);
                            if (Oid > 0)
                            {


                                DataRow row = MainModule.dtRefOrder.NewRow();
                                row["iIndex"] = iIndex;
                                row["Oid"] = Oid;
                                row["ExchOrdno"] = 0;
                                row["TrdPrice"] = _bprice;
                                row["TrdQty"] = num6;
                                row["OrgPrice"] = _bprice;
                                row["Tradeornot"] = 0;
                                row["Uid"] = num2;
                                MainModule.dtRefOrder.Rows.Add(row);

                                double _diffpl = ((MainModule.objMarketWatch[iIndex].dLTP / MainModule.iDivisor1) - _bprice) * num6;

                                double maxqty = _diffpl / MainModule.objMarketWatch[iIndex].dTTickSize;

                                if (maxqty > MainModule.objMarketWatch[iIndex].sMaxQty)
                                {

                                    if (maxqty > (2 * MainModule.objMarketWatch[iIndex].sMaxQty))
                                    {
                                        maxqty = 2 * MainModule.objMarketWatch[iIndex].sMaxQty;
                                    
                                    }
                                    MainModule.objMarketWatch[iIndex].sMaxQtynext = (int)maxqty;
                                    int nlocalqty = (int)((maxqty / 15) / 8);
                                    MainModule.objMarketWatch[iIndex].placingqtynext = nlocalqty;
                                    MainModule._clsstmputilobj.AppendTrace("CNPL1: diffpl" + _diffpl + " maxqty" + maxqty + "bprice" + _bprice + "nlocalqty" + nlocalqty, Color.Blue);
                                }
                                else
                                {

                                    MainModule.objMarketWatch[iIndex].placingqtynext = MainModule.objMarketWatch[iIndex].placingqty;
                                    MainModule.objMarketWatch[iIndex].sMaxQtynext = MainModule.objMarketWatch[iIndex].sMaxQty;
                                    MainModule._clsstmputilobj.AppendTrace("CNPL2: diffpl" + _diffpl + " maxqty" + maxqty + "bprice" + _bprice, Color.Blue);
                                }
                            }
                        }

                    }
                }
           }catch (Exception ex)
            {
                MainModule._clsstmputilobj.AppendTrace("CalculateNetProfitandLoss:"+ex.ToString(),Color.Blue);
            }*/


        }


        public void CancelAllOrders(int cuid)
        {

            int index = cuid - 1;
            MainModule._clsstmputilobj.AppendTrace("CancelAllOrders",Color.Blue);

         try{


             if (MainModule._clsstmputilobj.strategyDictionary.ContainsKey(cuid))
             {
                 
                 StructureTestStrategies.MarketWatch vwapstg = MainModule._clsstmputilobj.strategyDictionary[cuid];

                 for (int i = 0; i < vwapstg._listorderbook.Count; i++)
                 {

                     StructureTestStrategies.Strategy_TestOrderbook obj = vwapstg._listorderbook[i];

                     if (obj.orderstatus == 1)
                     {

                         DataRow[] rowArray = MainModule.dtRefOrder.Select("Oid = '" + obj.oid + "'");
                         if (rowArray.Length > 0)
                         {

                         }
                         else
                         {


                             MyHost.CancelOrder(obj.oid);
                             obj.orderstatus = 5;
                             MainModule.objMarketWatch[index]._stopcanceltrade++;
                             //  Trace.WriteLine("S Cl:" + obj.oid + obj.orderstatus);
                           MainModule._clsstmputilobj.AppendTrace("S Cl:" + obj.oid + obj.orderstatus, Color.Blue);
                         }
                     }


                     vwapstg._listorderbook[i] = obj;
                 }

                 MainModule._clsstmputilobj.strategyDictionary[cuid] = vwapstg;
             }
                                    
            }
            catch (Exception ex)
            {
                //Trace.WriteLine("Exception in Cancel Order" + ex.ToString());

                MainModule._clsstmputilobj.AppendTrace("Exception in Cancel Order" + ex.ToString(), Color.Blue);
            }


        }


        public void CancelRatioOrders(int cuid)
        {

            MainModule._clsstmputilobj.AppendTrace("CancelAllOrders", Color.Blue);

            try
            {


                if (MainModule._clsstmputilobj.strategyDictionary.ContainsKey(cuid))
                {

                    StructureTestStrategies.MarketWatch vwapstg = MainModule._clsstmputilobj.strategyDictionary[cuid];

                    for (int i = 0; i < vwapstg._listorderbook.Count; i++)
                    {

                        StructureTestStrategies.Strategy_TestOrderbook obj = vwapstg._listorderbook[i];

                        if (obj.orderstatus == 1)
                        {

                            DataRow[] rowArray = MainModule.dtRefOrder.Select("Oid = '" + obj.oid + "'");
                            if (rowArray.Length > 0)
                            {

                            }
                            else
                            {


                                MyHost.CancelOrder(obj.oid);
                                obj.orderstatus = 5;
                         
                                //  Trace.WriteLine("S Cl:" + obj.oid + obj.orderstatus);
                                MainModule._clsstmputilobj.AppendTrace("S ClR:" + obj.oid + obj.orderstatus, Color.Blue);
                            }
                        }


                        vwapstg._listorderbook[i] = obj;
                    }

                    MainModule._clsstmputilobj.strategyDictionary[cuid] = vwapstg;
                }

            }
            catch (Exception ex)
            {
                //Trace.WriteLine("Exception in Cancel Order" + ex.ToString());

                MainModule._clsstmputilobj.AppendTrace("E: CancelRatioOrder" + ex.ToString(), Color.Blue);
            }


        }




        public void CancelOrderId(int oid)
        {
            try {

                MyHost.CancelOrder(oid);
            }
            catch (Exception ex)
            {
                
                MainModule._clsstmputilobj.AppendTrace("Exception in Cancel Order" + ex.ToString(), Color.Blue);
            }


        }





       

        private double GetValidPrice(double PlacingPrice)
        {
            double _roundprice=0.0, _roundPricediv = 0.0;
            try
            {
                 _roundPricediv = Math.Round((PlacingPrice / 5), 2);
                _roundprice = Math.Round((_roundPricediv * 5), 2);

            }
            catch (Exception ex)
            {
                Trace.WriteLine("Not a Valid Tick Price"+ex.ToString());
            }

              

                return _roundprice;
        }



        

        private void cancel_prev_minute_oids(string oo_scrip,string oo_account)
        {
            try
            {
                for (int i = MainModule.dtminutes.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow rowss = MainModule.dtminutes.Rows[i];

                    string ob_symbol = rowss["symbol"].ToString();
                    string ob_account = rowss["account"].ToString();
                    int ob_oid = Convert.ToInt32(rowss["oid"].ToString());
                    int ob_cancesends = Convert.ToInt32(rowss["cancelsend"].ToString());

                    if (oo_scrip == ob_symbol && oo_account == ob_account && ob_cancesends == 0)
                    {
                        MainModule._clsstmputilobj.AppendTrace("sending prev not tradedoid:" + ob_symbol + " " + ob_account + ob_oid, Color.Blue);
                        MyHost.CancelOrder(ob_oid); 
                        rowss["cancelsend"] = 1;                        
                    }
                }
                MainModule.dtminutes.AcceptChanges();
            }
            catch (Exception ee)
            {
                MainModule._clsstmputilobj.AppendTrace("cancelprevoids ee:" + ee.ToString(), Color.Blue);
            }
        }

        private void boosting_qty()
        {
            try
            {
                for (int k = 0; k < MainModule.iMaximumScripts; k++)
                {

                    double dd_bid = MainModule.objMarketWatch[k].dBid;
                    double dd_ask = MainModule.objMarketWatch[k].dAsk;
                    double dd_sp = MainModule.objMarketWatch[k].startprices;

                    int nn_buyqty = MainModule.objMarketWatch[k].BuyQuantityTraded;
                    int nn_sellqty = MainModule.objMarketWatch[k].SellQuantityTraded;



                    DateTime startTime111 = DateTime.Now;
                    int lives_hh = startTime111.Hour;
                    int lives_mm = startTime111.Minute;

                    int nn_complete_min = ((lives_hh * 60) + lives_mm) - ((nstart_hh * 60) + nstart_mm);

                    int nn_qty_req_mintotal = 0;
                    int nn_qty_req_min = 0;                    
                    

                    if (nn_complete_min > 0)
                    {
                        DataRow[] qtyrowinput = MainModule.dtpricemax_input.Select("symbol = '" + MainModule.objMarketWatch[k].sInstrumentCode + "' and account = '" + MainModule.objMarketWatch[k].account + "'");
                        if (qtyrowinput.Length > 0)
                        {
                            DataRow row = qtyrowinput[0];
                            //nn_max_qty_entered = Convert.ToInt32(row["maxqty"].ToString());
                            nn_qty_req_min = Convert.ToInt32(row["minuteqty"].ToString());
                            MainModule._clsstmputilobj.AppendTrace("Token:" + MainModule.objMarketWatch[k].Token + ",MinuteQty" + nn_qty_req_min, Color.Blue);
                        }

                        nn_qty_req_mintotal = nn_complete_min * nn_qty_req_min;


                        MainModule._clsstmputilobj.AppendTrace("Token:" + MainModule.objMarketWatch[k].Token + ",BQ:" + nn_buyqty + ",SQ:" + nn_sellqty + ",reqtotal:" + nn_qty_req_mintotal, Color.Blue);

                        if (nn_qty_req_mintotal > 0)
                        {
                            if (nn_buyqty > nn_sellqty)
                            {
                                int diff_qty = nn_qty_req_mintotal - nn_buyqty;
                                if (diff_qty > 0)
                                {
                                    cancel_prev_minute_oids(MainModule.objMarketWatch[k].sInstrumentCode, MainModule.objMarketWatch[k].account);
                                    MainModule._clsstmputilobj.AppendTrace("Token:" + MainModule.objMarketWatch[k].Token + ",BQ:" + nn_buyqty + ",SQ:" + nn_sellqty + ",reqtotal:" + nn_qty_req_mintotal + ",BNew" + diff_qty + ",Minutes:" + nn_complete_min, Color.Blue);
                                    int nn_intprice = Convert.ToInt32(dd_bid * MainModule.iDivisor1);
                                    int nn_oids = MyHost.sendOrder(MainModule.objMarketWatch[k].iWatchId, IHost.Exchanges.NSE, MainModule.objMarketWatch[k].Token, IHost.ActionType.Buy, diff_qty, 0, nn_intprice, IHost.OrderTypes.Normal, MainModule.objMarketWatch[k].account);

                                    DataRow rowpp = MainModule.dtminutes.NewRow();
                                    rowpp["symbol"] = MainModule.objMarketWatch[k].sInstrumentCode;
                                    rowpp["account"] = MainModule.objMarketWatch[k].account;
                                    rowpp["oid"] = nn_oids;
                                    rowpp["cancelsend"] = 0;
                                    MainModule.dtminutes.Rows.Add(rowpp);
                                }
                            }
                            if (nn_buyqty < nn_sellqty)
                            {
                                int diff_qty = nn_qty_req_mintotal - nn_sellqty;
                                if (diff_qty > 0)
                                {
                                    cancel_prev_minute_oids(MainModule.objMarketWatch[k].sInstrumentCode, MainModule.objMarketWatch[k].account);
                                    MainModule._clsstmputilobj.AppendTrace("Token:" + MainModule.objMarketWatch[k].Token + ",BQ:" + nn_buyqty + ",SQ:" + nn_sellqty + ",reqtotal:" + nn_qty_req_mintotal + ",SNew" + diff_qty + ",Minutes:" + nn_complete_min, Color.Blue);
                                    int nn_intprice = Convert.ToInt32(dd_ask * MainModule.iDivisor1);
                                    int nn_oids = MyHost.sendOrder(MainModule.objMarketWatch[k].iWatchId, IHost.Exchanges.NSE, MainModule.objMarketWatch[k].Token, IHost.ActionType.Sell, diff_qty, 0, nn_intprice, IHost.OrderTypes.Normal, MainModule.objMarketWatch[k].account);

                                    DataRow rowpp = MainModule.dtminutes.NewRow();
                                    rowpp["symbol"] = MainModule.objMarketWatch[k].sInstrumentCode;
                                    rowpp["account"] = MainModule.objMarketWatch[k].account;
                                    rowpp["oid"] = nn_oids;
                                    rowpp["cancelsend"] = 0;
                                    MainModule.dtminutes.Rows.Add(rowpp);
                                }
                            }
                        }
                    }                    
                }


            }
            catch (Exception ee)
            {
                MainModule._clsstmputilobj.AppendTrace("boostingqty:" + ee.ToString(), Color.Blue);
                /*
                    if (nn_minutesqty_entered > 0)
                    {
                        if (dd_sp <= dd_ask)
                        {
                            //placing ask

                            DataView view = new DataView(MainModule.dtplacing_data);
                            view.RowFilter = "price= " + dd_ask + " and symbol = '" + MainModule.objMarketWatch[k].sInstrumentCode + "' and account = '" + MainModule.objMarketWatch[k].account + "'";
                            DataTable table = view.ToTable();
                            if (table.Rows.Count > 0)
                            {
                                nn_placing_max_qty = Convert.ToInt32(table.Compute("Sum(qty)", ""));
                                MainModule._clsstmputilobj.AppendTrace("Token:" + MainModule.objMarketWatch[k].Token + ",Placedatprice:" + nn_placing_max_qty, Color.Blue);
                            }

                            int nn_remainqtys = nn_max_qty_entered - nn_placing_max_qty;
                            MainModule._clsstmputilobj.AppendTrace("Token:" + MainModule.objMarketWatch[k].Token + ",MaxQtyPrice" + nn_placing_max_qty + ",Placed:" + nn_placing_max_qty + ",remain:" + nn_remainqtys + "S@" + dd_ask, Color.Blue);
                            if (nn_remainqtys > 0)
                            {
                                //storing the placing qty in DT
                                DataRow rowpp = MainModule.dtplacing_data.NewRow();
                                rowpp["symbol"] = MainModule.objMarketWatch[k].sInstrumentCode;
                                rowpp["account"] = MainModule.objMarketWatch[k].account;
                                rowpp["price"] = dd_ask;
                                rowpp["qty"] = nn_remainqtys;
                                MainModule.dtplacing_data.Rows.Add(rowpp);
                                int nn_intprice = Convert.ToInt32(dd_ask * MainModule.iDivisor1);
                                MainModule._clsstmputilobj.AppendTrace("Token:" + MainModule.objMarketWatch[k].Token + ",MaxQtyPrice" + nn_placing_max_qty + ",Placed:" + nn_placing_max_qty + ",remain:" + nn_remainqtys + "S1@" + dd_ask, Color.Blue);
                                MyHost.sendOrder(MainModule.objMarketWatch[k].iWatchId, IHost.Exchanges.NSE, MainModule.objMarketWatch[k].Token, IHost.ActionType.Sell, nn_remainqtys, 0, nn_intprice, IHost.OrderTypes.Normal, MainModule.objMarketWatch[k].account);
                            }
                        }


                        if (dd_sp >= dd_bid)
                        {
                            //placing bid

                            DataView view = new DataView(MainModule.dtplacing_data);
                            view.RowFilter = "price= " + dd_bid + " and symbol = '" + MainModule.objMarketWatch[k].sInstrumentCode + "' and account = '" + MainModule.objMarketWatch[k].account + "'";
                            DataTable table = view.ToTable();
                            if (table.Rows.Count > 0)
                            {
                                nn_placing_max_qty = Convert.ToInt32(table.Compute("Sum(qty)", ""));
                                MainModule._clsstmputilobj.AppendTrace("Token:" + MainModule.objMarketWatch[k].Token + ",Placedatprice:" + nn_placing_max_qty, Color.Blue);
                            }

                            int nn_remainqtys = nn_max_qty_entered - nn_placing_max_qty;
                            MainModule._clsstmputilobj.AppendTrace("Token:" + MainModule.objMarketWatch[k].Token + ",MaxQtyPrice" + nn_placing_max_qty + ",Placed:" + nn_placing_max_qty + ",remain:" + nn_remainqtys + "B@" + dd_bid, Color.Blue);
                            if (nn_remainqtys > 0)
                            {
                                //storing the placing qty in DT
                                DataRow rowpp = MainModule.dtplacing_data.NewRow();
                                rowpp["symbol"] = MainModule.objMarketWatch[k].sInstrumentCode;
                                rowpp["account"] = MainModule.objMarketWatch[k].account;
                                rowpp["price"] = dd_ask;
                                rowpp["qty"] = nn_remainqtys;
                                MainModule.dtplacing_data.Rows.Add(rowpp);
                                int nn_intprice = Convert.ToInt32(dd_bid * MainModule.iDivisor1);
                                MainModule._clsstmputilobj.AppendTrace("Token:" + MainModule.objMarketWatch[k].Token + ",MaxQtyPrice" + nn_placing_max_qty + ",Placed:" + nn_placing_max_qty + ",remain:" + nn_remainqtys + "B1@" + dd_bid, Color.Blue);
                                MyHost.sendOrder(MainModule.objMarketWatch[k].iWatchId, IHost.Exchanges.NSE, MainModule.objMarketWatch[k].Token, IHost.ActionType.Buy, nn_remainqtys, 0, nn_intprice, IHost.OrderTypes.Normal, MainModule.objMarketWatch[k].account);
                            }
                        }
                    }*/
            }
        }
        public void ProcessTradeLogic(IHost.structQuote QuoteReceived, int iIndex,int _Ticksize)
        {
            try
            {
                int _trackid;

                if (MainModule.objMarketWatch[iIndex].d_stgtype == (int)MainModule.AlgoType.MOCTRADE)
                {
                    if (MainModule.starttrading == 1 && MainModule.startMoc == 1 && MainModule.objMarketWatch[iIndex].dMOC != 0)
                    {
                        double moc = MainModule.objMarketWatch[iIndex].dMOC;
                        MainModule.objMarketWatch[iIndex].dMOC = 0;

                        double newbiddif = Math.Round((MainModule.objMarketWatch[iIndex].dBid / 5), 2);
                        double newaskdif = Math.Round((MainModule.objMarketWatch[iIndex].dAsk / 5), 2);                        
                        double dbidPrice = Math.Round((newbiddif * 5), 2);
                        double daskPrice = Math.Round((newaskdif * 5), 2);
                        

                        double dd_llbuyqty = MainModule.objMarketWatch[iIndex].BuyQuantityTraded;
                        double dd_llsellqty = MainModule.objMarketWatch[iIndex].SellQuantityTraded;
                        double dd_netqtyval = Math.Abs(dd_llbuyqty - dd_llsellqty);

                        
                        if (dbidPrice>=moc)
                        {

                            if (MainModule.objMarketWatch[iIndex]._Sell == 2 && MainModule.objMarketWatch[iIndex].blActive)
                            {
                                MainModule._clsstmputilobj.AppendTrace("Token:" + MainModule.objMarketWatch[iIndex].Token + "Bid:" + MainModule.objMarketWatch[iIndex].dBid + "Ask:" + MainModule.objMarketWatch[iIndex].dAsk + "MOC:" + moc + "HP:" + MainModule.objMarketWatch[iIndex].highprice + "PD:" + Math.Round(Math.Abs(MainModule.objMarketWatch[iIndex].highprice - MainModule.objMarketWatch[iIndex].dAsk), 2) + "dtik:" + MainModule.objMarketWatch[iIndex].dTickSize, Color.Blue);
                                if ((dd_netqtyval < MainModule.objMarketWatch[iIndex].iMaxQty && MainModule.objMarketWatch[iIndex].iMaxQty > 0)
                                && (Math.Round(Math.Abs(MainModule.objMarketWatch[iIndex].highprice - MainModule.objMarketWatch[iIndex].dAsk),2)>=MainModule.objMarketWatch[iIndex].dTickSize))
                                {

                                    MainModule.objMarketWatch[iIndex].highprice = daskPrice;
                                    int iprice = Convert.ToInt32(daskPrice * MainModule.iDivisor1);
                                    int iqty = MainModule._clsstmputilobj.BallonQty(MainModule.objMarketWatch[iIndex].i_multiplier, MainModule.objMarketWatch[iIndex].i_initqty, Convert.ToInt32(dd_netqtyval), MainModule.objMarketWatch[iIndex].iMaxQty);

                                    if (MainModule.objMarketWatch[iIndex].iMaxQty > (dd_netqtyval + iqty))
                                    {
                                        MainModule.objMarketWatch[iIndex]._Buy = 0;
                                        _trackid = MyHost.sendOrder(MainModule.objMarketWatch[iIndex].iWatchId, IHost.Exchanges.NSE, MainModule.objMarketWatch[iIndex].Token, IHost.ActionType.Sell, iqty, 0, iprice, IHost.OrderTypes.Normal, MainModule.objMarketWatch[iIndex].account);
                                        MainModule._imocDictionary.Add(_trackid, MainModule.objMarketWatch[iIndex].iWatchId);
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (MainModule.objMarketWatch[iIndex]._Buy == 1 && MainModule.objMarketWatch[iIndex].blActive)
                            {
                                MainModule._clsstmputilobj.AppendTrace("Token:" + MainModule.objMarketWatch[iIndex].Token + "Bid:" + MainModule.objMarketWatch[iIndex].dBid + "Ask:" + MainModule.objMarketWatch[iIndex].dAsk + "MOC:" + moc + "LP:" + MainModule.objMarketWatch[iIndex].lowprice + "PD:" + Math.Round(Math.Abs(MainModule.objMarketWatch[iIndex].lowprice - MainModule.objMarketWatch[iIndex].dAsk), 2) + "dtik:" + MainModule.objMarketWatch[iIndex].dTickSize + "netQty:" + MainModule.objMarketWatch[iIndex].BuyQuantityTraded, Color.Blue);
                                if ((dd_netqtyval < MainModule.objMarketWatch[iIndex].iMaxQty && MainModule.objMarketWatch[iIndex].iMaxQty > 0)
                                    && (Math.Round(Math.Abs(MainModule.objMarketWatch[iIndex].lowprice - MainModule.objMarketWatch[iIndex].dBid),2) >= MainModule.objMarketWatch[iIndex].dTickSize))
                                {
                                    MainModule.objMarketWatch[iIndex].lowprice = dbidPrice;
                                    int iprice = Convert.ToInt32(dbidPrice * MainModule.iDivisor1);
                                    int iqty = MainModule._clsstmputilobj.BallonQty(MainModule.objMarketWatch[iIndex].i_multiplier, MainModule.objMarketWatch[iIndex].i_initqty, Convert.ToInt32(dd_netqtyval), MainModule.objMarketWatch[iIndex].iMaxQty);

                                    if (MainModule.objMarketWatch[iIndex].iMaxQty > dd_netqtyval + iqty)
                                    {
                                        MainModule.objMarketWatch[iIndex]._Sell = 0;
                                        _trackid = MyHost.sendOrder(MainModule.objMarketWatch[iIndex].iWatchId, IHost.Exchanges.NSE, MainModule.objMarketWatch[iIndex].Token, IHost.ActionType.Buy, iqty, 0, iprice, IHost.OrderTypes.Normal, MainModule.objMarketWatch[iIndex].account);
                                        MainModule._imocDictionary.Add(_trackid, MainModule.objMarketWatch[iIndex].iWatchId);
                                    }
                                }
                            }
                        }
                    }
                    
                }
                else if (MainModule.objMarketWatch[iIndex].d_stgtype == (int)MainModule.AlgoType.BASKET1)
                {
                    
                }
                else if (MainModule.objMarketWatch[iIndex].d_stgtype == (int)MainModule.AlgoType.STOCKMM)
                {
                    if ((MainModule.objMarketWatch[iIndex].dBid <= 0) || (MainModule.objMarketWatch[iIndex].dAsk <= 0))
                    {
                        Trace.WriteLine("BIDASK");
                        return;
                    }


                    if (MainModule.starttrading == 1)
                    {

                        MainModule._clsstmputilobj.AppendTrace(MainModule.objMarketWatch[iIndex].Token + " B:" + MainModule.objMarketWatch[iIndex].dBid + "   A:" + MainModule.objMarketWatch[iIndex].dAsk + "   " + MainModule.objMarketWatch[iIndex].dLTP, Color.Blue);
                        

                        if (MainModule.objMarketWatch[iIndex].startprices == 0)
                        {
                            MainModule.objMarketWatch[iIndex].startprices = MainModule.objMarketWatch[iIndex].dLTP;
                            MainModule._clsstmputilobj.AppendTrace(MainModule.objMarketWatch[iIndex].Token + ":newstart:" + MainModule.objMarketWatch[iIndex].startprices, Color.Blue);
                        }

                        if (MainModule.objMarketWatch[iIndex]._Buy == 1
                           && MainModule.objMarketWatch[iIndex].lowprice == 0)
                        {
                            MainModule.objMarketWatch[iIndex].lowprice = MainModule.objMarketWatch[iIndex].dLTP;
                            MainModule._clsstmputilobj.AppendTrace(MainModule.objMarketWatch[iIndex].Token + ":newlow:" + MainModule.objMarketWatch[iIndex].lowprice, Color.Blue);
                        }
                        if (MainModule.objMarketWatch[iIndex]._Sell== 2
                           && MainModule.objMarketWatch[iIndex].highprice == 0)
                        {
                            MainModule.objMarketWatch[iIndex].highprice = MainModule.objMarketWatch[iIndex].dLTP;
                            MainModule._clsstmputilobj.AppendTrace(MainModule.objMarketWatch[iIndex].Token + ":newhigh:" + MainModule.objMarketWatch[iIndex].highprice, Color.Blue);
                        }


                        double dd_llbuyqty = MainModule.objMarketWatch[iIndex].BuyQuantityTraded;                        
                        double dd_llsellqty = MainModule.objMarketWatch[iIndex].SellQuantityTraded;

                        double dd_netqtyval = Math.Abs(dd_llbuyqty - dd_llsellqty);
                        MainModule._clsstmputilobj.AppendTrace("NetQty: "+dd_netqtyval.ToString(),Color.Red);

                        // buy placing
                        if (MainModule.objMarketWatch[iIndex]._Buy == 1 && MainModule.objMarketWatch[iIndex].blActive)
                        {
                            if ((dd_netqtyval < MainModule.objMarketWatch[iIndex].iMaxQty  && MainModule.objMarketWatch[iIndex].iMaxQty > 0)
                                && (MainModule.objMarketWatch[iIndex].lowprice - MainModule.objMarketWatch[iIndex].dTickSize) >= MainModule.objMarketWatch[iIndex].dBid                                
                                )
                            {
                                

                                if (nstart_hh == 0)
                                {
                                    DateTime startTimet = DateTime.Now;
                                    nstart_hh = startTimet.Hour;
                                    nstart_mm = startTimet.Minute;
                                }
                               
                                double dd_newprice1 = MainModule.objMarketWatch[iIndex].lowprice - MainModule.objMarketWatch[iIndex].dTickSize;


                                int nn_pp_qty = 1;
                                DataRow[] qtyrowinput = MainModule.dtfileinputs.Select("symbol = '" + MainModule.objMarketWatch[iIndex].sInstrumentCode + "' and account = '" + MainModule.objMarketWatch[iIndex].account + "' and price=" + dd_newprice1);
                                if (qtyrowinput.Length > 0)
                                {
                                    DataRow row = qtyrowinput[0];
                                    nn_pp_qty = Convert.ToInt32(row["qty"].ToString());
                                }    


                                MainModule.objMarketWatch[iIndex].lowprice = dd_newprice1;
                                MainModule._clsstmputilobj.AppendTrace(MainModule.objMarketWatch[iIndex].Token + ":lp:" + MainModule.objMarketWatch[iIndex].lowprice, Color.Blue);
                                int nn_intprice = Convert.ToInt32(dd_newprice1*MainModule.iDivisor1);

                                //storing the placing qty in DT
                               /* DataRow rowpp = MainModule.dtplacing_data.NewRow();
                                rowpp["symbol"] = MainModule.objMarketWatch[iIndex].sInstrumentCode;
                                rowpp["account"] = MainModule.objMarketWatch[iIndex].account;
                                rowpp["price"] = dd_newprice1;
                                rowpp["qty"] = nn_pp_qty;
                                MainModule.dtplacing_data.Rows.Add(rowpp);*/


                                MyHost.sendOrder(MainModule.objMarketWatch[iIndex].iWatchId, IHost.Exchanges.NSE, MainModule.objMarketWatch[iIndex].Token, IHost.ActionType.Buy, nn_pp_qty, 0, nn_intprice, IHost.OrderTypes.Normal, MainModule.objMarketWatch[iIndex].account);
                                
                            }
                        }
        

                        // sell placing
                        if (MainModule.objMarketWatch[iIndex]._Sell == 2 && MainModule.objMarketWatch[iIndex].blActive)
                        {
                            if ((dd_netqtyval < MainModule.objMarketWatch[iIndex].iMaxQty && MainModule.objMarketWatch[iIndex].iMaxQty > 0)
                                && (MainModule.objMarketWatch[iIndex].highprice + MainModule.objMarketWatch[iIndex].dTickSize) <= MainModule.objMarketWatch[iIndex].dAsk
                                )
                            {

                                if (nstart_hh == 0)
                                {
                                    DateTime startTimey = DateTime.Now;
                                    nstart_hh = startTimey.Hour;
                                    nstart_mm = startTimey.Minute;
                                }

                                
                                double dd_newprice1 = MainModule.objMarketWatch[iIndex].highprice + MainModule.objMarketWatch[iIndex].dTickSize;

                                int nn_pp_qty = 1;
                                DataRow[] qtyrowinput = MainModule.dtfileinputs.Select("symbol = '" + MainModule.objMarketWatch[iIndex].sInstrumentCode + "' and account = '" + MainModule.objMarketWatch[iIndex].account + "' and price=" + dd_newprice1);
                                if (qtyrowinput.Length > 0)
                                {
                                    DataRow row = qtyrowinput[0];
                                    nn_pp_qty = Convert.ToInt32(row["qty"].ToString());
                                } 


                                MainModule.objMarketWatch[iIndex].highprice = dd_newprice1;

                                MainModule._clsstmputilobj.AppendTrace(MainModule.objMarketWatch[iIndex].Token + ":hp:" + MainModule.objMarketWatch[iIndex].highprice, Color.Blue);

                                int nn_intprice = Convert.ToInt32(dd_newprice1 * MainModule.iDivisor1);

                                //storing the placing qty in DT
                               /* DataRow rowpp = MainModule.dtplacing_data.NewRow();
                                rowpp["symbol"] = MainModule.objMarketWatch[iIndex].sInstrumentCode;
                                rowpp["account"] = MainModule.objMarketWatch[iIndex].account;
                                rowpp["price"] = dd_newprice1;
                                rowpp["qty"] = nn_pp_qty;
                                MainModule.dtplacing_data.Rows.Add(rowpp);*/

                                MyHost.sendOrder(MainModule.objMarketWatch[iIndex].iWatchId, IHost.Exchanges.NSE, MainModule.objMarketWatch[iIndex].Token, IHost.ActionType.Sell, nn_pp_qty, 0, nn_intprice, IHost.OrderTypes.Normal, MainModule.objMarketWatch[iIndex].account);

                            }
                        }


                        double dd_percent_move = Math.Abs((MainModule.objMarketWatch[iIndex].dLTP - MainModule.objMarketWatch[iIndex].startprices) / MainModule.objMarketWatch[iIndex].startprices) * 100;
                        MainModule.objMarketWatch[iIndex].livepercentmove = dd_percent_move;
                        if (dd_percent_move > MainModule.objMarketWatch[iIndex].placeavgpercent &&
                            MainModule.objMarketWatch[iIndex].placeavgpercent_order==0)
                        {
                            //moves up
                            if (MainModule.objMarketWatch[iIndex].startprices <= MainModule.objMarketWatch[iIndex].dLTP && dd_llsellqty > 0)
                            {
                                MainModule.objMarketWatch[iIndex].placeavgpercent_order = 1;
                                // cancelling all buy orders... place avg price as buy tgt
                                CancelAllOrdersSelectedScript(MainModule.objMarketWatch[iIndex].iWatchId, 1);

                                double dd_buyqty = MainModule.objMarketWatch[iIndex].BuyQuantityTraded;
                                double dd_buyprice = MainModule.objMarketWatch[iIndex].BuyPrice;
                                double dd_sellqty = MainModule.objMarketWatch[iIndex].SellQuantityTraded;
                                double dd_sellprice = MainModule.objMarketWatch[iIndex].SellPrice;
                                double dd_netqty = Math.Abs(dd_sellqty - dd_buyqty);

                                double dd_netprice = ((dd_sellprice * dd_sellqty) - (dd_buyprice * dd_buyqty)) / (dd_sellqty - dd_buyqty);
                                double dd_roundtrip_price = (dd_sellqty * MainModule.objMarketWatch[iIndex].dTTickSize) / dd_netqty;
                                double dd_avgprice = dd_netprice - dd_roundtrip_price;

                                double newdif = Math.Round((dd_avgprice / 5), 2);
                                double dd_newavgprice = Math.Round((newdif * 5), 2);
                                if (dd_newavgprice <= dd_avgprice)
                                {
                                }
                                else
                                {
                                    dd_newavgprice = dd_newavgprice - MainModule.objMarketWatch[iIndex].dTickSize;
                                }

                                MainModule._clsstmputilobj.AppendTrace(MainModule.objMarketWatch[iIndex].Token + ":avgplaced1:" + dd_newavgprice, Color.Green);

                                int nn_newsprice = Convert.ToInt32(dd_newavgprice * MainModule.iDivisor1);
                                int _trackno = MyHost.sendOrder(MainModule.objMarketWatch[iIndex].iWatchId, IHost.Exchanges.NSE, MainModule.objMarketWatch[iIndex].Token, IHost.ActionType.Buy, Convert.ToInt32(dd_netqty), 0, nn_newsprice, IHost.OrderTypes.Normal, MainModule.objMarketWatch[iIndex].account);
                                DataRow row = MainModule.dtRefOrder.NewRow();
                                row["iIndex"] = iIndex;
                                row["Oid"] = _trackno;
                                row["ExchOrdno"] = 0;
                                row["TrdPrice"] = dd_newavgprice;
                                row["TrdQty"] = dd_netqty;
                                row["OrgPrice"] = dd_newavgprice;
                                row["Tradeornot"] = 0;
                                row["exitRef"] = 0;
                                row["Uid"] = MainModule.objMarketWatch[iIndex].iWatchId;
                                MainModule.dtRefOrder.Rows.Add(row);

                                MainModule._clsstmputilobj.AppendTrace(MainModule.objMarketWatch[iIndex].Token + ":avgplaced1oid:" + _trackno, Color.Green);

                            }

                            //moves dn
                            if (MainModule.objMarketWatch[iIndex].startprices >= MainModule.objMarketWatch[iIndex].dLTP && dd_llbuyqty > 0)
                            {
                                

                                MainModule.objMarketWatch[iIndex].placeavgpercent_order = 1;
                                // cancelling all sell orders... place avg price as sell tgt
                                CancelAllOrdersSelectedScript(MainModule.objMarketWatch[iIndex].iWatchId, 2);


                                double dd_buyqty = MainModule.objMarketWatch[iIndex].BuyQuantityTraded;
                                double dd_buyprice = MainModule.objMarketWatch[iIndex].BuyPrice;
                                double dd_sellqty = MainModule.objMarketWatch[iIndex].SellQuantityTraded;
                                double dd_sellprice = MainModule.objMarketWatch[iIndex].SellPrice;
                                double dd_netqty = Math.Abs(dd_sellqty - dd_buyqty);

                                double dd_netprice = ((dd_sellprice * dd_sellqty) - (dd_buyprice * dd_buyqty)) / (dd_sellqty - dd_buyqty);
                                double dd_roundtrip_price = (dd_buyqty * MainModule.objMarketWatch[iIndex].dTTickSize) / dd_netqty;
                                double dd_avgprice = dd_netprice + dd_roundtrip_price;

                                double newdif = Math.Round((dd_avgprice / 5), 2);
                                double dd_newavgprice = Math.Round((newdif * 5), 2);
                                if (dd_newavgprice <= dd_avgprice)
                                {
                                }
                                else
                                {
                                    dd_newavgprice = dd_newavgprice - MainModule.objMarketWatch[iIndex].dTickSize;
                                }
                                MainModule._clsstmputilobj.AppendTrace(MainModule.objMarketWatch[iIndex].Token + ":avgplaced2:" + dd_newavgprice, Color.Green);

                                int nn_newsprice = Convert.ToInt32(dd_newavgprice * MainModule.iDivisor1);
                                int _trackno = MyHost.sendOrder(MainModule.objMarketWatch[iIndex].iWatchId, IHost.Exchanges.NSE, MainModule.objMarketWatch[iIndex].Token, IHost.ActionType.Sell, Convert.ToInt32(dd_netqty), 0, nn_newsprice, IHost.OrderTypes.Normal, MainModule.objMarketWatch[iIndex].account);
                                DataRow row = MainModule.dtRefOrder.NewRow();
                                row["iIndex"] = iIndex;
                                row["Oid"] = _trackno;
                                row["ExchOrdno"] = 0;
                                row["TrdPrice"] = dd_newavgprice;
                                row["TrdQty"] = dd_netqty;
                                row["OrgPrice"] = dd_newavgprice;
                                row["Tradeornot"] = 0;
                                row["exitRef"] = 0;
                                row["Uid"] = MainModule.objMarketWatch[iIndex].iWatchId;
                                MainModule.dtRefOrder.Rows.Add(row);
                                MainModule._clsstmputilobj.AppendTrace(MainModule.objMarketWatch[iIndex].Token + ":avgplaced2oid:" + _trackno, Color.Green);


                            }
                        }
                    }

                    DateTime startTime = DateTime.Now;
                    int livehour = startTime.Hour;
                    int livemin = startTime.Minute;
                    int totalmin = (livehour * 60) + livemin;

                    if (MainModule.starttrading == 1 && totalmin >= 915)
                    {
                        MainModule._clsstmputilobj.AppendTrace("Live Trading is Stopped !", Color.Green);
                        MainModule.starttrading = 0;
                       
                        MainModule.frmdlg.button1.Enabled = true;
                        MainModule.frmdlg.button4.Enabled = false;

                        //MainModule.frmdlg.stopTimers();

                        for (int k = 0; k < MainModule.iMaximumScripts; k++)
                        {
                            MainModule.objMarketWatch[k].blActive = false;

                            CancelAllOrdersSelectedScript(MainModule.objMarketWatch[k].iWatchId);
                        }
                        
                    }



                }

                    
            }
            catch (Exception ex)
            {

                //   Trace.WriteLine("in Process trade logic error " + ex.ToString());
                MainModule._clsstmputilobj.AppendTrace("E:Process trade logic" + ex.ToString(), Color.Blue);
            }

        }


        public void start_new_session_bs(int iii)
        {
            try
            {
                MainModule._clsstmputilobj.AppendTrace("avgplacedorder traded: ", Color.Blue);
                CancelAllOrdersSelectedScript(MainModule.objMarketWatch[iii].iWatchId);

                MainModule.objMarketWatch[iii].startprices = 0;
                MainModule.objMarketWatch[iii].lowprice = 0;
                MainModule.objMarketWatch[iii].highprice = 0;

                MainModule.objMarketWatch[iii].placeavgpercent_order = 0;

                MainModule.objMarketWatch[iii].BuyQuantityTraded = 0;
                MainModule.objMarketWatch[iii].BuyPrice = 0;
                MainModule.objMarketWatch[iii].SellQuantityTraded = 0;
                MainModule.objMarketWatch[iii].SellPrice = 0;


                MainModule._clsstmputilobj.AppendTrace(MainModule.objMarketWatch[iii].Token + " started fresh MM", Color.Blue);

                MainModule.dtminutes.Clear();


            }
            catch (Exception ee)
            {
                MainModule._clsstmputilobj.AppendTrace("start new session : " + ee.ToString(), Color.Blue);
            }
        }
        



        public void ADScriptStatechange(int stgid, bool adval)
        {
            try
            {

                for (int i = 0; i < MainModule.iMaximumScripts; i++)
                {
                    if (MainModule.objMarketWatch[i].iWatchId == stgid)
                    {
                        MainModule.objMarketWatch[i].blActive = adval;
                        if (adval)
                        {

                            MainModule._clsstmputilobj.AppendTrace("Strategy Status True" + MainModule.objMarketWatch[i].iWatchId, Color.Blue);
                        }
                        else
                        {

                            MainModule._clsstmputilobj.AppendTrace("Strategy Status False" + MainModule.objMarketWatch[i].iWatchId, Color.Blue);
                        }

                    }
                }


            }
            catch (Exception ex)
            {
                MainModule._clsstmputilobj.AppendTrace("ADScriptStateChange" + ex.ToString(), Color.Blue);
            }


        }

        public void oneSecond()
        {
            try
            {
                   MainModule._globalsecond++;

                   if (MainModule._globalsecond % 60 == 0)
                   {
                       if (MainModule._boostvalue == 1)
                           boosting_qty();
                   }

                  /* for (int k = 0; k < MainModule.iMaximumScripts; k++)
                   {
                       if (MainModule.objMarketWatch[k].stopplacingorder == 1)
                       {

                           MainModule._clsstmputilobj.AppendTrace(MainModule.objMarketWatch[k]._startcanceltrade + "    jjj  " + MainModule.objMarketWatch[k]._stopcanceltrade, Color.Blue);
                           if (MainModule.objMarketWatch[k]._startcanceltrade == MainModule.objMarketWatch[k]._stopcanceltrade)
                           {


                               MainModule.objMarketWatch[k].stopplacingorder = 0;
                               MainModule.objMarketWatch[k]._startcanceltrade = 0;
                               MainModule.objMarketWatch[k]._stopcanceltrade = 0;

                               RestartScript(k);
                           }
                       }
                   }*/

                      

                 /*if (MainModule._globalsecond % 930 == 0) //960
                   {
                       CalculateNetProfitandLoss();
                   }*/

                  /* if (MainModule._globalsecond % 120 == 0)
                   {
                       try
                       {

                           MainModule._clsstmputilobj.AppendTrace("QtyCk:Clear Start:",Color.Blue);
                           for (int i = 0; i < MainModule.iMaximumScripts; i++)
                           {

                              
                                   StructureTestStrategies.MarketWatch vwapstg = MainModule._clsstmputilobj.strategyDictionary[MainModule.objMarketWatch[i].iWatchId];
                                   vwapstg._listQtycheck.Clear();
                                   MainModule._clsstmputilobj.strategyDictionary[MainModule.objMarketWatch[i].iWatchId] = vwapstg;
                              
                           }

                           MainModule._clsstmputilobj.AppendTrace("QtyCk:Clear Complete:", Color.Blue);
                       }
                       catch (Exception ex)
                       {
                           MainModule._clsstmputilobj.AppendTrace("QTY Check:"+ex.ToString(),Color.Blue);
                       }
                   }*/




                 /*  if (MainModule._globalsecond % 900 == 0) //900
                    {
                       

                        MinutesProcess();
                       
                    }else
                    
                    {

                   for (int i = 0; i < MainModule.iMaximumScripts; i++)
                        {
                          int ninterval = MainModule.objMarketWatch[i].interval;

                          if (MainModule._globalsecond % ninterval == 0 && MainModule.objMarketWatch[i].stopplacingorder == 0)
                            {

                                secondsProcess(i);
                            }

                    
                         }
                    }*/              

            }
            catch (Exception ex)
            {
                MainModule._clsstmputilobj.AppendTrace("oneSecond"+ex.ToString(),Color.Blue);
            }
        }

        public void secondsProcess(int i)
        { }


        public void RestartScript(int i)
        {
           
        }

        //Todolist
        public void CheckStoplossbook()
        {

          

        }


        public void MinutesProcess()
        {
            /*try
            {

            
                if (MainModule.starttrading == 0)
                    return;
                for (int i = 0; i < MainModule.iMaximumScripts; i++)
                {
                    MainModule.objMarketWatch[i].stopplacingorder = 1;
                    MainModule.objMarketWatch[i]._startcanceltrade = 0;
                    MainModule.objMarketWatch[i]._stopcanceltrade = 0;

                    if (MainModule.starttrading == 1 && MainModule.objMarketWatch[i].blActive)
                    {
                        MainModule._clsstmputilobj.AppendTrace("SC1:" + MainModule.objMarketWatch[i].Token + "T:" + MainModule.objMarketWatch[i].session_starttime, Color.Blue);

                        CancelAllOrders(MainModule.objMarketWatch[i].iWatchId);
                    }
                }

            }
            catch (Exception ex)
            {
                MainModule._clsstmputilobj.AppendTrace("E:MinutesProcess"+ex.ToString(),Color.Blue);
            }*/


        }




        public void Order_Confirmation(int OID, int OrderStatus, IHost.Exchanges Exch, int Token, string DispName, int ErrorCode, int BuySell, long ExchOrderNum, int Qty, int DisQty, int TotalTrdQty, int OrderPrice, string Account, int UID, int StopLoss, IHost.OrderTypes ordType, IHost.LegInfo LegTwo, IHost.LegInfo LegThree, int idxExch)
        {
            try
            {

                int _uid = Math.Abs(UID);

                int iIndex = _uid - 1;

                switch (OrderStatus)
                {

                    case 0:
                        //Sent
                        //MainModule.frmdlg.label3.Text = " Order Sent";
                        break;
                    case 1:
                        
                        if (MainModule._clsstmputilobj.strategyDictionary.ContainsKey(_uid))
                        {
                            StructureTestStrategies.MarketWatch vwapstg = MainModule._clsstmputilobj.strategyDictionary[_uid];

                            vwapstg.Obook = new StructureTestStrategies.Strategy_TestOrderbook();
                            vwapstg.Obook.StrategyId = _uid;
                            vwapstg.Obook.Account = Account;
                            vwapstg.Obook.buysell = BuySell;
                            vwapstg.Obook.Dispname = DispName;
                            vwapstg.Obook.disqty = DisQty;
                            vwapstg.Obook.exch = Exch;
                            vwapstg.Obook.token = Token;
                            vwapstg.Obook.qty = Qty;
                            vwapstg.Obook.token = Token;
                            vwapstg.Obook.tottradqty = TotalTrdQty;
                            vwapstg.Obook.oid = OID;
                            vwapstg.Obook.errorcode = ErrorCode;
                            vwapstg.Obook.exchordid = ExchOrderNum;
                            vwapstg.Obook.orderstatus = OrderStatus;
                            vwapstg.Obook.startTime = DateTime.Now;

                            vwapstg._listorderbook.Add(vwapstg.Obook);
                            vwapstg._listpendingorderbook.Add(vwapstg.Obook);
                            MainModule._clsstmputilobj.strategyDictionary[_uid] = vwapstg;

                            try
                            {
                                //MainModule._clsstmputilobj.AppendTrace("aaaaaa:" + OID + " :" + MainModule.objMarketWatch[iIndex].placeavgpercent_order, Color.Blue);
                                if (MainModule.objMarketWatch[iIndex].placeavgpercent_order == 1)
                                {
                                  //  MainModule._clsstmputilobj.AppendTrace("bbbbbb:" + OID + " :" + MainModule.objMarketWatch[iIndex].placeavgpercent_order, Color.Blue);

                                    DataRow[] rowArray = MainModule.dtRefOrder.Select("Oid = '" + OID + "'");
                                    if (rowArray.Length > 0)
                                    {
                                        MainModule._clsstmputilobj.AppendTrace(" ROID F:" + OID + "   Exchgno:" + ExchOrderNum, Color.Blue);
                                        MainModule.objMarketWatch[iIndex].placeavgpercent_order = 2;
                                        rowArray[0]["ExchOrdno"] = ExchOrderNum;
                                    }
                                    MainModule.dtRefOrder.AcceptChanges();
                                }
                            }
                            catch (Exception ex)
                            {
                                MainModule._clsstmputilobj.AppendTrace("E:ROID" + ex.ToString(), Color.Blue);
                            }
                        
                            MainModule._clsstmputilobj.AppendTrace("OC:"+ OID+":Token:" + Token + ":Price:" + OrderPrice / MainModule.iDivisor1 + ":Qty:" + Qty + ":AC:" + Account + ":BuySell:" + BuySell + ":EO:" + ExchOrderNum, Color.Blue);

                            /*byte[] objData = MainModule.objStructureDataType.StructureToByte(vwapstg.Obook, Marshal.SizeOf(vwapstg.Obook));
                              MainModule.NSETCPSocket.Send(objData);
                              Trace.WriteLine("SOCKET DATA SEND");*/
                        }
                        break;
                    //Confirmed
                    case 2:


                        break;
                    case 3:
                        //Rejected
                        // MainModule.frmdlg.label3.Text = " Order Rejected";

                        MainModule._clsstmputilobj.AppendTrace("Order Rejected Error Code:" + ErrorCode.ToString()+" OID: "+ OID + " For Token" + Token+" Price: "+ OrderPrice, Color.Blue);

                        break;
                    case 4:
                        //ModifySent
                        //  MainModule.frmdlg.label3.Text = " Modify Sent";

                        MainModule._clsstmputilobj.AppendTrace("Modify Sent", Color.Blue);

                        break;
                    case 5:
                        //CancelSent
                        // MainModule.frmdlg.label3.Text = " Cancel Sent";

                        MainModule._clsstmputilobj.AppendTrace("Cancel Sent", Color.Blue);
                        break;
                    case 7:
                        //freeze
                        // MainModule.frmdlg.label3.Text = " Order freeze";
                        Trace.WriteLine("freeze Sent");
                        break;
                    case 8:
                        // MainModule.frmdlg.label3.Text = " Order Cancelled";


                        MainModule.objMarketWatch[iIndex]._startcanceltrade++;
                        MainModule._clsstmputilobj.AppendTrace(DateTime.Now.ToString() + " Order Cancelled OID " + OID.ToString() + " For Token" + Token + " CStart" + MainModule.objMarketWatch[iIndex]._startcanceltrade + " BS:" + BuySell, Color.Blue);

                       /* if (MainModule._clsstmputilobj.strategyDictionary.ContainsKey(_uid))
                        {
                            // Trace.WriteLine("Canceled OID"+OID.ToString());


                            StructureTestStrategies.MarketWatch vwapstg = MainModule._clsstmputilobj.strategyDictionary[_uid];

                            for (int i = 0; i < vwapstg._listorderbook.Count; i++)
                            {

                                StructureTestStrategies.Strategy_TestOrderbook obj = vwapstg._listorderbook[i];

                                if (obj.oid == OID && obj.orderstatus == 5)
                                {
                                    // Trace.WriteLine("OIDSC:" + obj.oid + "OS:" + OrderStatus);
                                    obj.orderstatus = OrderStatus;
                                }

                                vwapstg._listorderbook[i] = obj;
                            }
                            MainModule._clsstmputilobj.strategyDictionary[_uid] = vwapstg;
                        }*/



                        //Cancelled
                        break;
                    case 9:
                        // MainModule.frmdlg.label3.Text = " Order Modified";
                        
                        MainModule._clsstmputilobj.AppendTrace("Modified OrderID " + OID.ToString(), Color.Blue);
                        try
                        {
                            DataRow[] rowArray = MainModule.dtRefOrder.Select("ExchOrdno = '" + ExchOrderNum + "'");
                                if (rowArray.Length > 0)
                                {

                                    MainModule._clsstmputilobj.AppendTrace(" MROID F:" + ExchOrderNum, Color.Blue);
                                    MainModule.objMarketWatch[iIndex].send_prev_session_order = 0;
                                    rowArray[0]["ExchOrdno"] = ExchOrderNum;
                                    rowArray[0]["Oid"] = OID;
                                }

                                MainModule.dtRefOrder.AcceptChanges();
                       }
                        catch (Exception ex)
                        {
                            MainModule._clsstmputilobj.AppendTrace("E:MROID" + ex.ToString(), Color.Blue);
                        }


                        //Modified
                        break;
                    case 11:
                        //ModifyReject
                        // MainModule.frmdlg.label3.Text = " Modify Reject";
                        //Trace.WriteLine("{0}", "ModifyReject OrderID " + OID.ToString());
                        MainModule._clsstmputilobj.AppendTrace("ModifyReject OrderID " + OID.ToString(), Color.Blue);
                        break;
                    case 12:
                        //Cancel Reject
                        // MainModule.frmdlg.label3.Text = " Cancel Reject";
                        //Trace.WriteLine("{0}", "Cancel Reject " + OID.ToString() + " For Token" + Token+" OrderID "+OID);
                        MainModule.objMarketWatch[iIndex]._startcanceltrade++;
                        MainModule._clsstmputilobj.AppendTrace("Cancel Reject " + OID.ToString() + " For Token" + Token + " OrderID " + OID, Color.Blue);
                        break;
                    case 19:
                        //stoploss triggered
                        // MainModule.frmdlg.label3.Text = " stoploss triggered";
                        //Trace.WriteLine("{0}", "stoploss triggered " + OID.ToString());
                        MainModule._clsstmputilobj.AppendTrace("stoploss triggered " + OID.ToString(), Color.Blue);


                        break;
                    case 20:
                        // MainModule.frmdlg.label3.Text = " Order Traded";
                        //Trace.WriteLine("{0}", "Order Traded " + OID.ToString() + " For Token" + Token);
                        MainModule._clsstmputilobj.AppendTrace("Order Traded " + OID.ToString() + " For Token" + Token, Color.Blue);
                        // MessageBox.Show("Order Traded");

                        break;
                }



            }
            catch (Exception ex)
            {
                Trace.WriteLine("In Order Confirmation :" + ex.ToString());
            }

        }

        public void StopLoss_Triggered(int OID)
        {
            
        }
    }
  }