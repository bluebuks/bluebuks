using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace QuantX
{
   public class stmpUtility
    {

        public Dictionary<int, StructureTestStrategies.DailyMarketWatch> MarketDictionary = new Dictionary<int, StructureTestStrategies.DailyMarketWatch>();
        public Dictionary<int, StructureTestStrategies.MarketWatch> strategyDictionary = new Dictionary<int, StructureTestStrategies.MarketWatch>();
        private Mutex _mutex = new Mutex();
        private delegate void WriteTextFromExchange(string sData, Color textColor);

        public stmpUtility() 
        {
        
        
        }


        public void TradeConfirmReceived(Vwapstrategy.Strategy_Tradebook obj, int iIndex)
        {
            try
            {

                // Vwapstrategy.Strategy_Tradebook obj = (Vwapstrategy.Strategy_Tradebook)TrdconfmRecv;
                lock (_mutex)
                {

                    DataRow row = MainModule.dtTradeBook.NewRow();
                    row["Account"] = obj.Account;

                    if (obj.buysell == 1)
                    {

                        row["BuyorSell"] = "Buy";
                    }
                    else
                    {

                        row["BuyorSell"] = "Sell";
                    }

                    row["Dispname"] = obj.Dispname;

                    if (IHost.Exchanges.NSE == obj.exch)
                    {

                        row["Exch"] = "NSE";
                    }


                    row["ExchOrdNum"] = obj.exchordnum;
                    row["Oid"] = obj.oid;
                    row["TrdQty"] = obj.tottradqty;
                    row["Token"] = obj.token;
                    row["TrdPrice"] = obj.trdprice;
                    row["TotTrdQty"] = obj.trdqty;


                    MainModule.dtTradeBook.Rows.InsertAt(row, 0);
                    MainModule.dtTradeBook.AcceptChanges();
                    UpdateNetPosition(obj.token);

                }


            }
            catch (Exception ex)
            {
                Trace.WriteLine("In Traceconfirmation Received" + ex.ToString());

            }


        }




        public void UpdateNetPosition2(int uid,int index)
        {


            lock (_mutex)
            {
                try
                {
                    //update based on startegyid
                    int _uid = uid;
                    DataRow[] rowArray = MainModule.dtNetPosition.Select("StrategyID =  '" + uid + "'");
                    if (rowArray.Length > 0)
                    {
                        DataRow row = rowArray[0];
                        DataView view = new DataView(MainModule.dtTradeBook);
                        decimal num = 0M;
                        decimal num2 = 0M;
                        decimal num3 = 1M;
                        int num4 = 0;
                        int num5 = 0;
                        view.RowFilter = "StrategyID =  '" + uid + "' AND BuyorSell = '1'";
                        DataTable table = view.ToTable();
                        table.Columns.Add("TPrice", typeof(decimal));
                        table.Columns["TPrice"].DefaultValue = 0;
                        table.Columns["TPrice"].Expression = "TrdPrice * TrdQty";
                        if (table.Rows.Count > 0)
                        {
                            num = Convert.ToDecimal(table.Compute("Sum(TPrice)", ""));
                            num4 = Convert.ToInt32(table.Compute("Sum(TrdQty)", ""));
                        }
                        view.RowFilter = "StrategyID =  '" + uid + "' AND BuyorSell = '2'";
                        table = view.ToTable();
                        table.Columns.Add("TPrice", typeof(decimal));
                        table.Columns["TPrice"].DefaultValue = 0;
                        table.Columns["TPrice"].Expression = "TrdPrice * TrdQty";
                        if (table.Rows.Count > 0)
                        {
                            num2 = Convert.ToDecimal(table.Compute("Sum(TPrice)", ""));
                            num5 = Convert.ToInt32(table.Compute("Sum(TrdQty)", ""));
                        }


                        //  num3 = (decimal)row["dmFactor"];

                        if (num > 0 && num4 > 0)
                        {
                            decimal _bprice = Convert.ToDecimal((num / num4)) / MainModule.iDivisor;

                            decimal _previousbprice = ((MainModule.objMarketWatch[index]._pstaticbuyqty * MainModule.objMarketWatch[index]._pstaticbuyprice) + (num4 * _bprice)) / (MainModule.objMarketWatch[index]._pstaticbuyqty + num4);
                            int _prevbqty = MainModule.objMarketWatch[index]._pstaticbuyqty + num4;

                            row["BuyPrice"] = _previousbprice;
                            row["BuyQuantity"] = _prevbqty;
                        }


                        if (num2 > 0 && num5 > 0)
                        {
                            decimal _sprice = Convert.ToDecimal((num2 / num5)) / MainModule.iDivisor;

                            decimal _previoussprice = ((MainModule.objMarketWatch[index]._pstaticsellqty * MainModule.objMarketWatch[index]._pstaticsellprice) + (num5 * _sprice)) / (MainModule.objMarketWatch[index]._pstaticsellqty + num5);
                            int _prevsqty = MainModule.objMarketWatch[index]._pstaticsellqty + num5;


                            row["SellPrice"] = _previoussprice;
                            row["SellQuantity"] = _prevsqty;
                        }



                        MainModule.dtNetPosition.AcceptChanges();


                    }
                    else
                    {

                        //calculate net position
                        CalculateNetposition();
                    }


                    if (MainModule.dtNetPosition.Rows.Count > 0)
                    {
                        //update M2m, total turnover, etc

                        MainModule.dBuyTurnOver = Convert.ToDecimal(MainModule.dtNetPosition.Compute("Sum(BuyQuantity)", ""));
                        MainModule.dSellTurnOver = Convert.ToDecimal(MainModule.dtNetPosition.Compute("Sum(SellQuantity)", ""));

                        MainModule.frmdlg.label_Buyshares.Text = MainModule.dBuyTurnOver.ToString();
                        MainModule.frmdlg.label_SellShares.Text = MainModule.dSellTurnOver.ToString();
                        decimal Netpos = (MainModule.dBuyTurnOver - MainModule.dSellTurnOver);
                        MainModule.frmdlg.label_Netpos.Text = Netpos.ToString();
                    }
                    else
                    {
                        Trace.WriteLine("in Net Position else");
                    }

                    MainModule.dtNetPosition.AcceptChanges();


                }
                catch (Exception ex)
                {

                    Trace.WriteLine("{0}", "Exception :" + ex.ToString());

                }

            }

        }

        public void UpdateNetPosition(int Tokennum)
        {


            lock (_mutex)
            {
                try
                {
                    //update based on startegyid

                   

                    DataRow[] rowArray = MainModule.dtNetPosition.Select("StrategyID =  '" + Tokennum + "'");

                    if (rowArray.Length > 0)
                    {
                        DataRow row = rowArray[0];
                        DataView view = new DataView(MainModule.dtTradeBook);
                        decimal num = 0M;
                        decimal num2 = 0M;
                        decimal num3 = 1M;
                        int num4 = 0;
                        int num5 = 0;
                        view.RowFilter = "StrategyID =  '" + Tokennum + "' AND BuyorSell = '1'";
                        DataTable table = view.ToTable();
                        table.Columns.Add("TPrice", typeof(decimal));
                        table.Columns["TPrice"].DefaultValue = 0;
                        table.Columns["TPrice"].Expression = "TrdPrice * TrdQty";
                        if (table.Rows.Count > 0)
                        {
                            num = Convert.ToDecimal(table.Compute("Sum(TPrice)", ""));
                            num4 = Convert.ToInt32(table.Compute("Sum(TrdQty)", ""));
                        }
                        view.RowFilter = "StrategyID =  '" + Tokennum + "' AND BuyorSell = '2'";
                        table = view.ToTable();
                        table.Columns.Add("TPrice", typeof(decimal));
                        table.Columns["TPrice"].DefaultValue = 0;
                        table.Columns["TPrice"].Expression = "TrdPrice * TrdQty";
                        if (table.Rows.Count > 0)
                        {
                            num2 = Convert.ToDecimal(table.Compute("Sum(TPrice)", ""));
                            num5 = Convert.ToInt32(table.Compute("Sum(TrdQty)", ""));
                        }


                      //  num3 = (decimal)row["dmFactor"];

                        if (num > 0 && num4 > 0)
                        {
                            double _bprice = Convert.ToDouble((num / num4))/ MainModule.iDivisor1;
                            row["BuyPrice"] = _bprice; 
                            row["BuyQuantity"] = num4 ;
                        }


                        if (num2 > 0 && num5 > 0)
                        {
                            double _sprice = Convert.ToDouble((num2 / num5)) / MainModule.iDivisor1;
                            row["SellPrice"] = _sprice;
                            row["SellQuantity"] = num5;
                        }
                        
                        

                        MainModule.dtNetPosition.AcceptChanges();


                    }
                    else
                    {

                        //calculate net position
                        CalculateNetposition();
                    }


                    if (MainModule.dtNetPosition.Rows.Count > 0)
                    {
                        //update M2m, total turnover, etc

                        MainModule.dBuyTurnOver = Convert.ToDecimal(MainModule.dtNetPosition.Compute("Sum(BuyQuantity)", ""));
                        MainModule.dSellTurnOver = Convert.ToDecimal(MainModule.dtNetPosition.Compute("Sum(SellQuantity)", ""));

                        MainModule.frmdlg.label_Buyshares.Text = MainModule.dBuyTurnOver.ToString();
                        MainModule.frmdlg.label_SellShares.Text = MainModule.dSellTurnOver.ToString();
                        decimal Netpos = (MainModule.dBuyTurnOver - MainModule.dSellTurnOver);
                        MainModule.frmdlg.label_Netpos.Text = Netpos.ToString();
                    }else{
                        Trace.WriteLine("in Net Position else");
                    }

                    MainModule.dtNetPosition.AcceptChanges();


                }
                catch (Exception ex)
                {

                    Trace.WriteLine("{0}", "Exception :" + ex.ToString());

                }

            }

        }




        public void CalculateNetposition()
        {

            try
            {
               // Trace.WriteLine("in CalculateNetposition");
                DataTable table = MainModule.dtTradeBook.DefaultView.ToTable(true, new string[] { "StrategyID" });
                
                decimal Netpos = 0.0M;
                if (table.Rows.Count > 0)
                {
                 for (int i = 0; i < table.Rows.Count; i++)
                    {

                        int num2 = Convert.ToInt32(table.Rows[i]["StrategyID"]);
                
                        DataView view = new DataView(MainModule.dtTradeBook);
                        decimal num3 = 0M;
                        decimal num4 = 0M;
                        decimal num5 = 1M;
                        int num6 = 0;
                        int num7 = 0;
                        view.RowFilter = "StrategyID =  '" + num2 + "' AND BuyorSell = '1'";
                        DataTable table2 = view.ToTable();
                        table2.Columns.Add("TPrice", typeof(decimal));
                        table2.Columns["TPrice"].DefaultValue = 0;
                        table2.Columns["TPrice"].Expression = "TrdPrice * TrdQty";

                        if (table2.Rows.Count > 0)
                        {
                
                            num3 = Convert.ToDecimal(table2.Compute("Sum(TPrice)", ""));
                            num6 = Convert.ToInt32(table2.Compute("Sum(TrdQty)", ""));
                        }
                        view.RowFilter = "StrategyID =  '" + num2 + "' AND BuyorSell = '2'";
                        table2 = view.ToTable();
                        table2.Columns.Add("TPrice", typeof(decimal));
                        table2.Columns["TPrice"].DefaultValue = 0;
                        table2.Columns["TPrice"].Expression = "TrdPrice * TrdQty";

                        if (table2.Rows.Count > 0)
                        {

                            num4 = Convert.ToDecimal(table2.Compute("Sum(TPrice)", ""));
                            num7 = Convert.ToInt32(table2.Compute("Sum(TrdQty)", ""));

                         //   Trace.WriteLine("in Sum Tprice and TrdQty" + num4 + " TPrice" + num7);
                        }


                        DataRow[] rowArray1 = MainModule.dtNetPosition.Select("StrategyID =  '" + num2 + "'");
                        if (rowArray1.Length > 0)
                        {
                            return;
                        }
                        DataRow row = MainModule.dtNetPosition.NewRow();
                        DataRow[] rowArray = MainModule.dtInstrument.Select("StrategyID =  '" + num2 + "'");

                

                        if (rowArray.Length > 0)
                        {
                            row["Token"] = rowArray[0]["Token"]; 
                            row["StrategyID"] = num2;
                            // row["Dispname"] = rowArray[0]["Token"];
                            //row["ExpiryDate"] = rowArray[0]["ExpiryDate"];
                            //row["dmFactor"] = num5 = 100;//(decimal)rowArray[0]["AveragePrice"];
                            

                        }

                        if (num6 > 0)
                        {
                           double _bprice = Convert.ToDouble((num3 / num6)) / MainModule.iDivisor1;
                           row["BuyPrice"] = _bprice;
                           row["BuyQuantity"] = num6;

                           

                        }

                        if (num7 > 0)
                        {
                            double _sprice = Convert.ToDouble((num4 / num7)) / MainModule.iDivisor1;
                            row["SellPrice"] = _sprice;
                            
                            row["SellQuantity"] = num7;
                           
                        }
                        
                       
                        MainModule.dtNetPosition.Rows.Add(row);

                    }

                    MainModule.dtNetPosition.AcceptChanges();


                }
                else
                {
                    Trace.WriteLine("CalculateNetposition.........No Rows");

                }

            }
            catch (Exception ex)
            {

                Trace.WriteLine("Exception in CalculateNetPosition" + ex.ToString());
            }


        }

        public void MarketPictureReceived(IHost.structQuote QuoteReceived, int index)
        {
            try
            {
                
                MainModule.frmdlg.dataGridView_MarketWatch.Rows[index].Cells["Bid"].Value = QuoteReceived.BidPrice1 / MainModule.iDivisor;
                MainModule.frmdlg.dataGridView_MarketWatch.Rows[index].Cells["Ask"].Value = QuoteReceived.AskPrice1 / MainModule.iDivisor;
                //Trace.WriteLine("in before  MarketPictureReceived Bid" + MainModule.objMarketWatch[index].dBid + " Ask " + MainModule.objMarketWatch[index].dAsk + " Avg Price" + QuoteReceived.);

              // Trace.WriteLine("Open " + QuoteReceived.Open + " High" + QuoteReceived.High + " L" + QuoteReceived.Low + " PC" + QuoteReceived.PClose+" ltp"+QuoteReceived.LTP);
                MainModule.objMarketWatch[index].dBid = QuoteReceived.BidPrice1 / MainModule.iDivisor1;
                MainModule.objMarketWatch[index].dAsk = QuoteReceived.AskPrice1 / MainModule.iDivisor1;
                MainModule.objMarketWatch[index].dLTP = QuoteReceived.LTP / MainModule.iDivisor1;
              //  Trace.WriteLine("in after MarketPictureReceived " + MainModule.objMarketWatch[index].dBid);
               
            }
            catch (Exception ex)
            {
                Trace.WriteLine("in MarketPictureReceived error " + ex.ToString());
            }
        }



        public void AppendTrace(string LogText, Color textColor)
        {
            try
            {
                if (MainModule.frmdlg.textBox1.InvokeRequired)
                {
                    WriteTextFromExchange method = new WriteTextFromExchange(this.AppendTrace);
                    MainModule.frmdlg.textBox1.Invoke(method, new object[] { LogText, textColor });
                }
                else
                {

                    MainModule.frmdlg.textBox1.Select(0, 0);
                    MainModule.frmdlg.textBox1.SelectionStart = 0;
                    MainModule.frmdlg.textBox1.ForeColor = textColor;
                    MainModule.frmdlg.textBox1.SelectedText = DateTime.Now.ToString("HH:mm:ss.mmm ") + LogText + Environment.NewLine;
                    if (MainModule.frmdlg.textBox1.TextLength > 200000 && MainModule.starttrading==1)
                    {
                        MainModule.frmdlg.textBox1.Text = MainModule.frmdlg.textBox1.Text.Substring(0, 200000);
                        SaveTradeLog();
                    }


                }

               // Trace.WriteLine(LogText);
            }
            catch (Exception ex)
            {

            }
            
            
        }



        public void SaveTradeLog()
        {
            try
            {

              

                string _tradelogfile = string.Format("Trade-{0:yyyy-MM-dd_hh-mm-ss-tt}.txt", DateTime.Now);

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(_tradelogfile, true))
                {
                    file.WriteLine(MainModule.frmdlg.textBox1.Text);
                    MainModule.frmdlg.textBox1.Text = String.Empty;
                }


            }
            catch (Exception ex)
            {

                Trace.WriteLine("SaveLog: " + ex.ToString());
            }
        }


        public int BallonQty(double imulti,int initQty, int inetQty, int imaxQty) 
        {
            int iballonqty = initQty;
            if (inetQty == 0)
            {
                return iballonqty;
            }
            else
            {
                for (int i = 0; i < 20; i++)
                {
                    iballonqty = Convert.ToInt32(iballonqty * imulti* (MainModule.time/MainModule.timeTick));
                    if (Math.Abs(inetQty) < iballonqty) 
                    {
                        break;
                    }
                }
            }
            return iballonqty;
        }



    }
}
