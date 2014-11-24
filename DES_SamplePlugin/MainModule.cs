using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text;
using System.Collections;

namespace QuantX
{
   public class MainModule
    {

       public static string DateTimeFormat = "ddMMMyyyy hh:mm:ss tt";
        public static NumberFormatInfo numberformat;
        public static stmpMainform frmdlg;
        public static TestStrategy teststg;
        

       // public static int _stopcanceltrade = 0,_startcanceltrade=0;
        public static stmpUtility _clsstmputilobj;
        public static frmBasketTrading _frmbaskettrd;
        public static int MaxoBook=6;
        public static int stoporder = 0;
       // public static int stopplacingorder = 0;
        public static int _globalsecond = 0;
        public static int _tradelogic = 0;
        public static int _showlog = 0;
        public static int _checkcepsocket = 0;
        public static int _checkdisfile = 0;
        public static bool breakFlag = false;

      //public static CapitalAllocation frmCapitalallc;
      //public static StmpOrderBook frmOrderBook;
        public static StmpNetPostion frmNetposition;
        public static DataTable dtInstrument;
        public static DataTable dtBasketBook;
        public static DataTable dtMarketCloseStats;
        public static DataTable dtNetPosition;
        public static DateTime dtNormalStopTime;
        public static DataTable dtOrderBook;
        public static DataTable dtPendingOrder;
        public static DataTable dtRdata;
        public static DataTable dtRefOrder;
        public static DataTable dtfileinputs;
        public static int _boostvalue = 0;
        //public static DataTable dtplacing_data;
        public static DataTable dtpricemax_input;
        public static DataTable dtminutes;
        public static DateTime dtTodayStopTime;
        public static DataTable dtTradeBook;
        public static DataTable dtWatch;
        public static DataTable dtExhaust;
        public static decimal dBuyTurnOver= 0.0M;
        public static decimal iDivisor = 100.0M;
        public static double iDivisor1 = 100;
        public static double dDivisor = 100.00;
        internal static TCPSocket NSETCPSocket;
        internal static TCPSocket NSETCPCepSocket;
        internal static QuantX.StructureTestStrategies.MarketWatch[] objMarketWatch;
       // internal static QuantX.StructureTestStrategies.StgExhust[] objExhust;

        internal static QuantX.StructureTestStrategies.StgBufferContainer objStgBuffercontainer;
        internal static QuantX.StructureTestStrategies.StgOrderQtyCheck objStgQtyCheck;

        public static StructureTestStrategies objStructureDataType;
        public static decimal dGrossExposure;
        public static decimal dMargin;
        public static decimal dSellTurnOver = 0.0M;
        public static double dTerminalInfo;
        public static int iMaximumScripts = 1;
        public static int iMarketOpen = 1;
        public static int startfeed = 0;
        public static int starttrading = 0;
        public static int startMoc = 0;        
        public static int updatedfixedvalue = 0;
        public static int _startBaskettrading = 0;
        public static double etffixedvalue = 0;
        public static long incfield = 0;
        public static long incstfield = 0;

        public static System.Timers.Timer heartbeatTimer;
        public static int time = 15;
        public static int timeTick = 15;

        public static List<int> _itrackList;
        public static Dictionary<int, int> _imocDictionary;

        public enum AlgoType
        {
            BASKET1 = 0,
            STOCKMM = 1,
            OPTIONS = 2,
            BASKET2 = 3,
            MOCTRADE = 6
            
        }



        public static stmpMainform StmpMainForm()
        {

            if (frmdlg == null)
                return new stmpMainform();
            else
                return frmdlg;          
        }

        public static stmpUtility CreateUtilobj() 
        {
            if (_clsstmputilobj == null)
                return new stmpUtility();
            else
                return _clsstmputilobj;

        }

        //public static TestStrategy TestStrategy() 
        //{
        //    if (teststg == null)
        //        return new TestStrategy();
        //    else
        //        return teststg;
                       
        //}


        public static StmpNetPostion GetNetposBook()
        {

            if (MainModule.frmNetposition == null)
            {
                MainModule.frmNetposition = new StmpNetPostion();


            }
            else
            {
                MainModule.frmNetposition.Focus();
            }

            return MainModule.frmNetposition;
        }



        public static frmBasketTrading GetBasketform()
        {

            if (MainModule._frmbaskettrd == null)
            {
                MainModule._frmbaskettrd = new frmBasketTrading();


            }
            else
            {
                MainModule._frmbaskettrd.Focus();
            }

            return MainModule._frmbaskettrd;
        }

        //public static StmpOrderBook GetOrderBook()
        //{

        //    if (MainModule.frmOrderBook == null)
        //    {
        //        MainModule.frmOrderBook = new StmpOrderBook();
               
               
        //    }
        //    else
        //    {
        //        MainModule.frmOrderBook.Focus();
        //    }

        //    return MainModule.frmOrderBook;
        //}

        //public static CapitalAllocation GetCapitalAllocationForm()
        //{

        //    if (MainModule.frmCapitalallc == null)
        //    {
        //        MainModule.frmCapitalallc = new CapitalAllocation();


        //    }
        //    else
        //    {
        //        MainModule.frmCapitalallc.Focus();
        //    }

        //    return MainModule.frmCapitalallc;
        //}
    }
    
}
