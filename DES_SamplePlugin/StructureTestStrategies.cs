using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace QuantX
{
    public class StructureTestStrategies
    {

        
        

        [StructLayout(LayoutKind.Sequential)]
        public struct bidbook {

            public int bidprice1;
            public int bidprice2;
            public int bidprice3;
            public int bidprice4;
            public int bidprice5;


            public int bidqty1;
            public int bidqty2;
            public int bidqty3;
            public int bidqty4;
            public int bidqty5;

        }


        [StructLayout(LayoutKind.Sequential)]
        public struct askbook {

            public int askprice1;
            public int askprice2;
            public int askprice3;
            public int askprice4;
            public int askprice5;

            public int askqty1;
            public int askqty2;
            public int askqty3;
            public int askqty4;
            public int askqty5;
                    
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct StgOrderQtyCheck
        {
            public int uid;
            public int oid;
            public int qty;
            public int price;
        }


        [StructLayout(LayoutKind.Sequential)]
        public struct StgBufferContainer
        {

            public int iWatchId;
            public string Symbol;
            public int Token;
            public int Buysell;
            public int Qty;
            public int Price;
            public int Qty1;
            public int Qty2;
            public int HalfQtyTrading;
            public int Fullyplaced;
            public int updown;
            public string account;
         
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MarketWatch
        {
            public int iWatchId;
            public bool blActive;
            public bool blSL;
            public int Token;
            public bool blTSL;
            public uint iInstrumentIdentifier;
            public int aType;
            public int _quantbuysell;
            public string sInstrumentCode;
            public DateTime dtExpiry;
            public double dTickSize;
            public double dTTickSize;
            public int d_marketvwap;
            public double lowprice;
            public double highprice;
            public double startprices;            
            public int restart;
            public int d_stgtype;
            public double dDPRHigh;
            public double dDPRLow;
            public double dBid;
            public double dAsk;
            public double dLTP;
            public double dMOC;
            public decimal dDayHigh;
            public decimal dDayLow;
            public int OrderType;
            public decimal dOurTradePrice;
            public int iSLTick;
            public int iPTick;
            public int iMLot;
            public int iTradedQty;
            public int iDisclosedQty;
            public Strategy_TestOrderbook Obook;
            public Strategy_Tradebook tBook;
            public StructureTestStrategies.StgBufferContainer stgBufferBook;
            public StructureTestStrategies.StgOrderQtyCheck stgOrderqtyCheck;
            public bool blMarketLock;
            public bool blModifyLock;
            public bool blSLPending;
            public bool blLimitPending;
            public string sExchange;
            public string sInstrumentType;
            public string sInstrumentName;
            public decimal dAveragePrice;
            public int iLotSize;
            public double increment;
            public double i_multiplier;
            public int i_initqty;
            public double i_nextinitqty;            
            public int iMaxQty;
            public int pricefrom;
            public int priceto;
            public int BuyQuantityTraded;
            public int SellQuantityTraded;
            public double BuyPrice;
            public double SellPrice;
            public int _BuyorSell;
            public int _Buy;
            public int _Sell;
            public int _finddepth;
            public string account;
            public int _pstaticbuyqty;
            public int _pstaticsellqty;
            public decimal _pstaticbuyprice;
            public decimal _pstaticsellprice;
            public double vwapvalue;
            public int _onlyonce;
            
            
            public int stop_session;//0
            public string session_starttime;//default "00:00:00"
            public int session_qty;//0
            public int send_prev_session_order;//0
            public int placingqty;//225
            public double dSRange;
            public int sMaxQty;
            public int session_1;
            public int session_2;
            public int interval;
            public int checkprevordertrade;
            public int pricemaxqty;
            public int sMaxQtynext;
            public int placingqtynext;
            public int _startcanceltrade;
            public int _stopcanceltrade;
            public int stopplacingorder;
            public double refvalue;
            public double refup;
            public double placeavgpercent;
            public int placeavgpercent_order;
            public double livepercentmove;
            public List<Strategy_TestOrderbook> _listpendingorderbook;
            public List<Strategy_TestOrderbook> _listorderbook;
            public List<Strategy_Tradebook> _listtradebook;
            public List<StructureTestStrategies.StgBufferContainer> _listbufferbook;
            public List<StructureTestStrategies.StgOrderQtyCheck> _listQtycheck;
        }


        public struct bulktest
        {
            public int Exchange;
            public int Token;
            public int BuySell;
            public int Qty;
            public int Price;
            public String Account;
            public int stgid;
        }



        public struct Strategy_Test
        {

            public int StrategyId;
            //leg1
            // public Strategy_TestOrderbook Obook;
            public List<Strategy_TestOrderbook> _listorderbook;
            public List<Strategy_TestOrderbook> _listtradebook;

            public int UID1;
            public int Exchange;
            public int Token;
            public int BuySell;
            public int Qty;
            public int Price;
            public int OrderType;
            public String Account;
            //leg2

            public int UID2;
            public int token2;
            public int exchange2;
            public int Buysell2;
            public int qty2;
            public int price2;
            public int ordertype2;
        }


        public struct Strategy_TestOrderbook
        {

            public int StrategyId;
            public int oid;
            public int orderstatus;
            public IHost.Exchanges exch;
            public int token;
            public String Dispname;
            public int errorcode;
            public int buysell;
            public long exchordid;
            public int qty;
            public int disqty;
            public int tottradqty;
            public int ordprice;
            public String Account;
            public DateTime startTime;
            public int _elptrade;


        }

        public struct Strategy_Tradebook
        {

            public int StrategyId;
            public int oid;
            public int token;
            public String Dispname;
            public IHost.Exchanges texch;
            public int buysell;
            public long exchordnum;
            public int trdqty;
            public int ordqty;
            public int tottradqty;
            public int trdprice;
            public String Account;


        }

        public struct Strategywise_Tradebook
        {

            public int strategyId;
            public Strategy_Tradebook trdbook1;

        }


        public struct DailyMarketWatch
        {

            public int tokenid;
            public int watchid;
            public int bid;
            public int ask;
            public long volume;
            public int ltp;
            public String ScripName;

        }


        public struct TestOrderbook
        {


            public int oid;
            public int orderstatus;
            public IHost.Exchanges Exch;
            public int token;
            public String Dispname;
            public int errorcode;
            public int buysell;
            public long exchordid;
            public int qty;
            public int disqty;
            public int tottradqty;
            public int ordprice;
            public String Account;



        }

        public struct NormalTradebook
        {

            public int oid;
            public int exch;
            public int token;
            public String Dispname;
            public int buysell;
            public long exchordnum;
            public int trdqty;
            public int ordqty;
            public int tottradqty;
            public int trdprice;
            public String Account;


        }

        public byte[] StructureToByte(object objStructure, int iLength)
        {
            byte[] destination = new byte[iLength];
            IntPtr ptr = Marshal.AllocHGlobal(iLength);
            Marshal.StructureToPtr(objStructure, ptr, true);
            Marshal.Copy(ptr, destination, 0, iLength);
            Marshal.FreeHGlobal(ptr);
            return destination;
        }


    }
}
