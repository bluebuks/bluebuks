using System;
using System.Collections.Generic;
using System.Text;

namespace QuantX
{
   public class Vwapstrategy
    {

        public struct Strategy_Vwap
        {

            public int StrategyId;
            public Strategy_TestOrderbook Obook;
            public Strategy_Tradebook tBook;
            
            public String Scripname;
            public int UID;
            public int Exchange;
            public int Token;
            public int BuySell;
            public int Qty;
            public int Price;
            public int OrderType;
            public String Account;
            public int trdtype;
            public int BuyQuantityTraded;
            public int SellQuantityTraded;
            public int itradedBuyQty;
            public int itradedSellQty;
            public int PreviousTradedqty;
            public int pricefrom;
            public int priceto;
            public int Maxqty;
            public int Minqty;
            public int meanval;
            public int dTicksize;
            public int dDPRHigh;
            public int dDPRLow;
            public int dTargetTicksize;
            public int mulitipler;
            public int increment;
            public int initialQty;
            public int CapitalAllocation;
            public int MaxCapitalLimit;
            public CreatedynamicObook[] _dynamicobook;

            public List<Strategy_TestOrderbook> _listorderbook;
            public List<Strategy_Tradebook> _listtradebook;

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



        }

        public struct Strategy_Tradebook
        {
            public int StrategyId;
            public int oid;
            public IHost.Exchanges exch;
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


        public struct iNetPostion
        {

            public int StrategyID;
            public int Token;
            public int dmFactor;
            public int BuyQuantity;
            public int SellQuantity;
            public int Tprice;

        }

        public struct TNetPostion
        {

            public int StrategyID;
            public int Token;
            public int dmFactor;
            public int BuyQuantity;
            public int SellQuantity;
            public int Tprice;

        }

        public struct MarketWatch
        {
            public int iStrategyId;
            public bool blActive;
            public bool blSL;
            public uint Token;
            public string sDispname;
            public DateTime dtExpiry;
            public decimal dTickSize;
            public decimal dDPRHigh;
            public decimal dDPRLow;
            public decimal dBid;
            public decimal dAsk;
            public decimal dLTP;
            public decimal dOurTradePrice;
            public int iSLTick;
            public int iProfitTick;
            public int iavgTick;
            public decimal iPricefrom;
            public decimal iPriceto;
            public int iMLotsize;
            public int iMaxQty;
            public int EqBuyQtuy;
            public int EqSellQty;
            public int iTradedQty;
            public int iDisclosedQty;
            public bool blMarketLock;
            public bool blModifyLock;
            public bool blSLPending;
            public bool blLimitPending;
            public string sExchange;
            public string sInstrumentType;
            public string sInstrumentName;
            public decimal dAveragePrice;
            public int buyorsell;
        }


        public struct CreatedynamicObook
        {
            public int bid1qty;
            public int bid2qty;
            public int bid3qty;
            public int bid4qty;
            public int bid5qty;

            public int bid1price;
            public int bid2price;
            public int bid3price;
            public int bid4price;
            public int bid5price;

            public long oid1;
            public long oid2;
            public long oid3;
            public long oid4;
            public long oid5;

            public int orderstatus;
        }


        //public struct CreatePrevObook {

        //    public int bid1qty;
        //    public int bid2qty;
        //    public int bid3qty;
        //    public int bid4qty;
        //    public int bid5qty;

        //    public decimal bid1price;
        //    public decimal bid2price;
        //    public decimal bid3price;
        //    public decimal bid4price;
        //    public decimal bid5price;

        //    public long oid1;
        //    public long oid2;
        //    public long oid3;
        //    public long oid4;
        //    public long oid5;

        //}
        //public struct CreateNextObook {

        //    public int bid1qty;
        //    public int bid2qty;
        //    public int bid3qty;
        //    public int bid4qty;
        //    public int bid5qty;

        //    public decimal bid1price;
        //    public decimal bid2price;
        //    public decimal bid3price;
        //    public decimal bid4price;
        //    public decimal bid5price;

        //    public long oid1;
        //    public long oid2;
        //    public long oid3;
        //    public long oid4;
        //    public long oid5;

        //}


    }
}
