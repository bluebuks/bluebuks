using System;
using System.Runtime.InteropServices;


namespace QuantX
{
  
    public class list
    {
        private ListType[] List;
        private int Maxindex = -1;
        private string sClientID;

        public list(int MaxConnection)
        {
            this.List = new ListType[MaxConnection];
        }

        public int Add(ref state Value)
        {
            if (this.Maxindex == -1)
            {
                if (this.List.Length >= (this.Maxindex + 2))
                {
                    this.Maxindex++;
                    this.List[this.Maxindex].state = Value;
                    return this.Maxindex;
                }
                return -1;
            }
            int index = -1;
            for (int i = 0; i <= this.Maxindex; i++)
            {
                if (this.List[i].state == null)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                if (this.List.Length >= (this.Maxindex + 2))
                {
                    this.Maxindex++;
                    this.List[this.Maxindex].state = Value;
                    return this.Maxindex;
                }
                return -1;
            }
            this.List[index].state = Value;
            return index;
        }

        public int Count()
        {
            return (this.Maxindex + 1);
        }

        private bool FindClient(ListType list)
        {
            return ((list.state != null) && (list.state.sClientID == this.sClientID));
        }

        public state Item(int nIndex)
        {
            return this.List[nIndex].state;
        }

        public state Item(string sTempClientID)
        {
            this.sClientID = sTempClientID;
            return Array.Find<ListType>(this.List, new Predicate<ListType>(this.FindClient)).state;
        }

        public void Remove(int nIndex)
        {
            this.List[nIndex].state = null;
        }

        public int MaximumIndexCheck
        {
            get
            {
                return this.Maxindex;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct ListType
        {
            public QuantX.state state;
        }
    }
}

