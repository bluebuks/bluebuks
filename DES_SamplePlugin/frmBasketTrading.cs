using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuantX
{
    public partial class frmBasketTrading : Form
    {
        private ComboBox comboBox1;
        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private Label label3;
        private TextBox textBox2;
        private Button button1;
        private Button button2;
        private DataGridView dataGridView_Basket;
        private Button button3;
        private GroupBox groupBox1;
    
        public frmBasketTrading()
        {
            InitializeComponent();
            MainModule.dtBasketBook.Clear();
            this.dataGridView_Basket.DataSource = MainModule.dtBasketBook;

        }

        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView_Basket = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Basket)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.dataGridView_Basket);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(979, 524);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Basket Trading Parameters";
            // 
            // dataGridView_Basket
            // 
            this.dataGridView_Basket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Basket.Location = new System.Drawing.Point(5, 167);
            this.dataGridView_Basket.Name = "dataGridView_Basket";
            this.dataGridView_Basket.Size = new System.Drawing.Size(967, 260);
            this.dataGridView_Basket.TabIndex = 8;
            this.dataGridView_Basket.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView_Basket_DataError);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(241, 108);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(191, 41);
            this.button2.TabIndex = 7;
            this.button2.Text = "Load Basket Data";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button_LoadXml);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 108);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(191, 41);
            this.button1.TabIndex = 6;
            this.button1.Text = "Add to Basket";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(363, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Weight";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(359, 49);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(114, 20);
            this.textBox2.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(172, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Capital";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(168, 50);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(173, 20);
            this.textBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Stocks";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "ONGC",
            "GAIL",
            "COALINDIA",
            "RECLTD",
            "IOC",
            "PFC",
            "BHEL",
            "CONCOR",
            "OIL",
            "GNEINERSIN"});
            this.comboBox1.Location = new System.Drawing.Point(16, 49);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(129, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(454, 108);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(191, 41);
            this.button3.TabIndex = 9;
            this.button3.Text = "Save Basket Data";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // frmBasketTrading
            // 
            this.ClientSize = new System.Drawing.Size(1003, 548);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmBasketTrading";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Basket)).EndInit();
            this.ResumeLayout(false);

        }

        private void button_LoadXml(object sender, EventArgs e)
        {

            try {

                MainModule.dtWatch = LoadDStgXML();

                MainModule.dtBasketBook = LoadDsXML();

                int Rowcount = MainModule.dtWatch.Rows.Count;

                MainModule.iMaximumScripts = MainModule.dtWatch.Rows.Count;
                if (MainModule.iMaximumScripts >= 0)
                {
                    MainModule.objMarketWatch = new StructureTestStrategies.MarketWatch[MainModule.iMaximumScripts];
                    for (int j = 0; j < MainModule.iMaximumScripts; j++)
                    {

                      DataRow row = MainModule.dtWatch.Rows[j];
                      MainModule.objMarketWatch[j].blActive = true;
                      MainModule.objMarketWatch[j].iWatchId = Int32.Parse(row["Strategyid"].ToString());
                      MainModule.objMarketWatch[j].iInstrumentIdentifier = Convert.ToUInt32(Int32.Parse(row["Token"].ToString()));
                      MainModule.objMarketWatch[j].Token = Int32.Parse(row["Token"].ToString());
                      MainModule.objMarketWatch[j].sInstrumentCode = row["ScripName"].ToString().Trim();
                      MainModule.objMarketWatch[j].dDPRHigh = 0;
                      MainModule.objMarketWatch[j].iMaxQty = 100;
                      MainModule.objMarketWatch[j].dDPRLow = 0;
                      MainModule.objMarketWatch[j].dAsk = 0;
                      MainModule.objMarketWatch[j].dBid = 0;
                      MainModule.objMarketWatch[j].dLTP = 0;
                      MainModule.objMarketWatch[j].iMLot = 1000;
                      MainModule.objMarketWatch[j].d_stgtype = 0;
                      MainModule.objMarketWatch[j].d_marketvwap = 1;
                      MainModule.objMarketWatch[j]._BuyorSell = 1;
                      MainModule.objMarketWatch[j].iMaxQty = 5000;
                      MainModule.objMarketWatch[j].i_initqty = 5;
                      MainModule.objMarketWatch[j].i_multiplier = 4;
                      MainModule.objMarketWatch[j].increment = 2;
                      MainModule.objMarketWatch[j].dTickSize = (double)1;
                      MainModule.objMarketWatch[j].dTTickSize = (double)1.5;
                      MainModule.objMarketWatch[j].lowprice = 0;
                      MainModule.objMarketWatch[j].highprice = 0;
                      MainModule.objMarketWatch[j].pricefrom = 0;
                      MainModule.objMarketWatch[j].iSLTick = 10;//(int)this.dgvMarketWatch["SLTick", j].Value;
                      MainModule.objMarketWatch[j].iPTick = 20;//(int)this.dgvMarketWatch["PTIck", j].Value;
                      MainModule.objMarketWatch[j].iTradedQty = 1;// (int)this.dgvMarketWatch["TQty", j].Value;
                      MainModule.objMarketWatch[j].iDisclosedQty = 0;//(int)this.dgvMarketWatch["DisclosedQty", j].Value;
                      MainModule.objMarketWatch[j].blSL = false;
                      MainModule.objMarketWatch[j].blTSL = false;
                      MainModule.objMarketWatch[j]._finddepth = 0;
                      MainModule.iMarketOpen = 1;
                      MainModule.objMarketWatch[j]._listorderbook = new List<StructureTestStrategies.Strategy_TestOrderbook>();
                      MainModule.objMarketWatch[j]._listtradebook = new List<StructureTestStrategies.Strategy_Tradebook>();


                      MainModule._clsstmputilobj.strategyDictionary.Add(MainModule.objMarketWatch[j].Token, MainModule.objMarketWatch[j]);


                      StructureTestStrategies.DailyMarketWatch dmw = new StructureTestStrategies.DailyMarketWatch();
                      dmw.ScripName = row["ScripName"].ToString();
                      dmw.tokenid = Int32.Parse(row["Token"].ToString());
                      dmw.ask = 0;
                      dmw.bid = 0;
                      dmw.volume = 0;

                      //
                      DataRow row1 = MainModule.dtInstrument.NewRow();

                      row1["Token"] = Int32.Parse(row["Token"].ToString());
                      row1["StrategyID"] = Int32.Parse(row["Token"].ToString());

                      MainModule.dtInstrument.Rows.Add(row1);
                      MainModule.frmdlg.AddScripMarketWatch(dmw.tokenid, dmw);
                      this.dataGridView_Basket.DataSource = MainModule.dtBasketBook;


                  }
              }



              
            }
            catch (Exception ex)
            {

            }
            

        }


        private DataTable LoadDStgXML()
        {
            DataSet ds = new DataSet();

            try
            {
                ds.ReadXml(@"Strategies.xml");
                //   MainModule.dtWatch.ReadXml(@"Strategies.xml");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            return ds.Tables[0];
        }



        public DataTable LoadDsXML()
        {
            DataSet ds = new DataSet();

            try
            {
                ds.ReadXml(@"BStrategies.xml");
                //   MainModule.dtWatch.ReadXml(@"Strategies.xml");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            return ds.Tables[0];
        }

        private void dataGridView_Basket_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            DataSet ds = new DataSet();

            try
            {
             //   ds.WriteXml(@"BStrategies.xml");
                //   MainModule.dtWatch.ReadXml(@"Strategies.xml");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {


          




        }


    }
}
