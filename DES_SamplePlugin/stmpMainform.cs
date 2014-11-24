using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace QuantX
{
    public  class stmpMainform : Form
    {

        public Plugin myparent;
        private GroupBox groupBox1;
        public Label label_Buyshares;
        private Label label5;
        public Label label_Netpos;
        private Label label4;
        public Label label_SellShares;
        private Label label1;
        public DataGridView dataGridView_MarketWatch;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem loadXmlToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem orderManagementToolStripMenuItem;
        private ToolStripMenuItem capitalAllocationToolStripMenuItem;
        public TextBox textBox1;
        private IContainer components;
        private ToolStripMenuItem orderBookToolStripMenuItem;
        private ToolStripMenuItem tradeBookToolStripMenuItem;
        private ToolStripMenuItem netPositionToolStripMenuItem;
        public TestStrategy teststg;
        public Button button1;
        private Button button3;
        public Button button4;
        private Button button2;
        private Button button5;
        private Button button6;
        private Button button7;
        private TextBox textBox_Price;
        private TextBox textBox_Qty;
        private Label label2;
        private Label label3;
        private TextBox textBox_account;
        private Label label6;
        private ToolStripMenuItem loadBasketToolStripMenuItem;
        public Label label_ETF;
        private Button button8;
        private Button button9;
        private Label label9;
        private TextBox textBox2;
        private Label label10;
        private TextBox textBox_token;
        private Label label11;
        private TextBox textBox_exchange;
        private Button button10;
        private Button button11;
        private ToolStripMenuItem backUpToolStripMenuItem;
        private ToolStripMenuItem fileDistributionToolStripMenuItem;
        private ToolStripMenuItem orderBookToolStripMenuItem1;
        private ToolStripMenuItem netPostionsToolStripMenuItem;
        private TextBox textBox3;
        private ToolStripMenuItem scriptManagementToolStripMenuItem;
        private ToolStripMenuItem activateToolStripMenuItem;
        private ToolStripMenuItem deActivateToolStripMenuItem;
        private ToolStripMenuItem showLogToolStripMenuItem;
        TextBoxTraceListener _textBoxListener;

        private System.Timers.Timer _timer_1secs;
        private System.Timers.Timer _timer_15secs;
        private ToolStripMenuItem cancelStrategyToolStripMenuItem1;
        private ToolStripMenuItem resetTradingToolStripMenuItem;
        private Button button_test;
        private ToolStripMenuItem boostingMinuteQtyToolStripMenuItem;
        private ToolStripMenuItem boostQtyDeActiveToolStripMenuItem;
        public Button button12;
        public Button button13;
        public TextBox ipBox;
        public TextBox portBox;
        public TextBox watchidBox;
        private Label watchidLabel;
        private Label label7;
        private Label label8;
        private System.Timers.Timer _timer_15mins;
        public stmpMainform()
        {
            InitializeComponent();
            this.ResetTables();
            this.BindingProcess();
            InitializeTimers();
            MainModule._clsstmputilobj = MainModule.CreateUtilobj();
        }


        public void stopTimers()
        {
            this._timer_1secs.Stop();
        }

        public void InitializeTimers()
        {
            //1 sec            
            this._timer_1secs = new System.Timers.Timer();
            ((System.ComponentModel.ISupportInitialize)(this._timer_1secs)).BeginInit();
            this._timer_1secs.Interval = 1000;
            this._timer_1secs.SynchronizingObject = this;
            this._timer_1secs.Elapsed += new System.Timers.ElapsedEventHandler(this.timer_1secs_Tick);
            ((System.ComponentModel.ISupportInitialize)(this._timer_1secs)).EndInit();
            
        }




        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_Buyshares = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label_Netpos = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_SellShares = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadXmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadBasketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderBookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tradeBookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.netPositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.capitalAllocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileDistributionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderBookToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.netPostionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scriptManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deActivateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelStrategyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.resetTradingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boostingMinuteQtyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boostQtyDeActiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.textBox_Price = new System.Windows.Forms.TextBox();
            this.textBox_Qty = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_account = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label_ETF = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_token = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox_exchange = new System.Windows.Forms.TextBox();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.dataGridView_MarketWatch = new System.Windows.Forms.DataGridView();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button_test = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.ipBox = new System.Windows.Forms.TextBox();
            this.portBox = new System.Windows.Forms.TextBox();
            this.watchidBox = new System.Windows.Forms.TextBox();
            this.watchidLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_MarketWatch)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label_Buyshares);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label_Netpos);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label_SellShares);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 483);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1161, 60);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Report";
            // 
            // label_Buyshares
            // 
            this.label_Buyshares.AutoSize = true;
            this.label_Buyshares.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Buyshares.Location = new System.Drawing.Point(209, 25);
            this.label_Buyshares.Name = "label_Buyshares";
            this.label_Buyshares.Size = new System.Drawing.Size(16, 18);
            this.label_Buyshares.TabIndex = 5;
            this.label_Buyshares.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(179, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "Total Buy Shares Traded :";
            // 
            // label_Netpos
            // 
            this.label_Netpos.AutoSize = true;
            this.label_Netpos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Netpos.Location = new System.Drawing.Point(904, 25);
            this.label_Netpos.Name = "label_Netpos";
            this.label_Netpos.Size = new System.Drawing.Size(16, 18);
            this.label_Netpos.TabIndex = 3;
            this.label_Netpos.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(796, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 18);
            this.label4.TabIndex = 2;
            this.label4.Text = "Net Position :";
            // 
            // label_SellShares
            // 
            this.label_SellShares.AutoSize = true;
            this.label_SellShares.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SellShares.Location = new System.Drawing.Point(553, 25);
            this.label_SellShares.Name = "label_SellShares";
            this.label_SellShares.Size = new System.Drawing.Size(16, 18);
            this.label_SellShares.TabIndex = 1;
            this.label_SellShares.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(323, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total Sell Shares Traded :";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(3, 549);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1549, 103);
            this.textBox1.TabIndex = 15;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.orderManagementToolStripMenuItem,
            this.capitalAllocationToolStripMenuItem,
            this.backUpToolStripMenuItem,
            this.scriptManagementToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1276, 24);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadXmlToolStripMenuItem,
            this.loadBasketToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadXmlToolStripMenuItem
            // 
            this.loadXmlToolStripMenuItem.Name = "loadXmlToolStripMenuItem";
            this.loadXmlToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loadXmlToolStripMenuItem.Text = "Load Scripts";
            this.loadXmlToolStripMenuItem.Click += new System.EventHandler(this.loadXmlToolStripMenuItem_Click);
            // 
            // loadBasketToolStripMenuItem
            // 
            this.loadBasketToolStripMenuItem.Name = "loadBasketToolStripMenuItem";
            this.loadBasketToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loadBasketToolStripMenuItem.Text = "Load Basket";
            this.loadBasketToolStripMenuItem.Click += new System.EventHandler(this.loadBasketToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // orderManagementToolStripMenuItem
            // 
            this.orderManagementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.orderBookToolStripMenuItem,
            this.tradeBookToolStripMenuItem,
            this.netPositionToolStripMenuItem});
            this.orderManagementToolStripMenuItem.Name = "orderManagementToolStripMenuItem";
            this.orderManagementToolStripMenuItem.Size = new System.Drawing.Size(112, 20);
            this.orderManagementToolStripMenuItem.Text = "Order Management";
            // 
            // orderBookToolStripMenuItem
            // 
            this.orderBookToolStripMenuItem.Name = "orderBookToolStripMenuItem";
            this.orderBookToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.orderBookToolStripMenuItem.Text = "Order Book";
            this.orderBookToolStripMenuItem.Visible = false;
            // 
            // tradeBookToolStripMenuItem
            // 
            this.tradeBookToolStripMenuItem.Name = "tradeBookToolStripMenuItem";
            this.tradeBookToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.tradeBookToolStripMenuItem.Text = "Trade Book";
            this.tradeBookToolStripMenuItem.Visible = false;
            // 
            // netPositionToolStripMenuItem
            // 
            this.netPositionToolStripMenuItem.Name = "netPositionToolStripMenuItem";
            this.netPositionToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.netPositionToolStripMenuItem.Text = "Net Position";
            this.netPositionToolStripMenuItem.Click += new System.EventHandler(this.netPositionToolStripMenuItem_Click);
            // 
            // capitalAllocationToolStripMenuItem
            // 
            this.capitalAllocationToolStripMenuItem.Name = "capitalAllocationToolStripMenuItem";
            this.capitalAllocationToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.capitalAllocationToolStripMenuItem.Text = "Capital Allocation";
            // 
            // backUpToolStripMenuItem
            // 
            this.backUpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileDistributionToolStripMenuItem,
            this.orderBookToolStripMenuItem1,
            this.netPostionsToolStripMenuItem});
            this.backUpToolStripMenuItem.Name = "backUpToolStripMenuItem";
            this.backUpToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.backUpToolStripMenuItem.Text = "BackUp";
            // 
            // fileDistributionToolStripMenuItem
            // 
            this.fileDistributionToolStripMenuItem.Name = "fileDistributionToolStripMenuItem";
            this.fileDistributionToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.fileDistributionToolStripMenuItem.Text = "File Distribution";
            this.fileDistributionToolStripMenuItem.Visible = false;
            this.fileDistributionToolStripMenuItem.Click += new System.EventHandler(this.fileDistributionToolStripMenuItem_Click);
            // 
            // orderBookToolStripMenuItem1
            // 
            this.orderBookToolStripMenuItem1.Name = "orderBookToolStripMenuItem1";
            this.orderBookToolStripMenuItem1.Size = new System.Drawing.Size(158, 22);
            this.orderBookToolStripMenuItem1.Text = "Order Book";
            this.orderBookToolStripMenuItem1.Visible = false;
            // 
            // netPostionsToolStripMenuItem
            // 
            this.netPostionsToolStripMenuItem.Name = "netPostionsToolStripMenuItem";
            this.netPostionsToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.netPostionsToolStripMenuItem.Text = "Net Postions";
            this.netPostionsToolStripMenuItem.Visible = false;
            // 
            // scriptManagementToolStripMenuItem
            // 
            this.scriptManagementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.activateToolStripMenuItem,
            this.deActivateToolStripMenuItem,
            this.showLogToolStripMenuItem,
            this.cancelStrategyToolStripMenuItem1,
            this.resetTradingToolStripMenuItem,
            this.boostingMinuteQtyToolStripMenuItem,
            this.boostQtyDeActiveToolStripMenuItem});
            this.scriptManagementToolStripMenuItem.Name = "scriptManagementToolStripMenuItem";
            this.scriptManagementToolStripMenuItem.Size = new System.Drawing.Size(111, 20);
            this.scriptManagementToolStripMenuItem.Text = "Script Management";
            // 
            // activateToolStripMenuItem
            // 
            this.activateToolStripMenuItem.Name = "activateToolStripMenuItem";
            this.activateToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.activateToolStripMenuItem.Text = "Activate";
            this.activateToolStripMenuItem.Click += new System.EventHandler(this.activateToolStripMenuItem_Click);
            // 
            // deActivateToolStripMenuItem
            // 
            this.deActivateToolStripMenuItem.Name = "deActivateToolStripMenuItem";
            this.deActivateToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.deActivateToolStripMenuItem.Text = "DeActivate";
            this.deActivateToolStripMenuItem.Click += new System.EventHandler(this.deActivateToolStripMenuItem_Click);
            // 
            // showLogToolStripMenuItem
            // 
            this.showLogToolStripMenuItem.Name = "showLogToolStripMenuItem";
            this.showLogToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.showLogToolStripMenuItem.Text = "Show Log";
            this.showLogToolStripMenuItem.Click += new System.EventHandler(this.showLogToolStripMenuItem_Click);
            // 
            // cancelStrategyToolStripMenuItem1
            // 
            this.cancelStrategyToolStripMenuItem1.Name = "cancelStrategyToolStripMenuItem1";
            this.cancelStrategyToolStripMenuItem1.Size = new System.Drawing.Size(173, 22);
            this.cancelStrategyToolStripMenuItem1.Text = "Cancel Strategy";
            this.cancelStrategyToolStripMenuItem1.Click += new System.EventHandler(this.cancelStrategyToolStripMenuItem1_Click);
            // 
            // resetTradingToolStripMenuItem
            // 
            this.resetTradingToolStripMenuItem.Name = "resetTradingToolStripMenuItem";
            this.resetTradingToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.resetTradingToolStripMenuItem.Text = "Reset Trading";
            this.resetTradingToolStripMenuItem.Click += new System.EventHandler(this.resetTradingToolStripMenuItem_Click);
            // 
            // boostingMinuteQtyToolStripMenuItem
            // 
            this.boostingMinuteQtyToolStripMenuItem.Name = "boostingMinuteQtyToolStripMenuItem";
            this.boostingMinuteQtyToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.boostingMinuteQtyToolStripMenuItem.Text = "BoostQtyActive";
            this.boostingMinuteQtyToolStripMenuItem.Click += new System.EventHandler(this.boostingMinuteQtyToolStripMenuItem_Click);
            // 
            // boostQtyDeActiveToolStripMenuItem
            // 
            this.boostQtyDeActiveToolStripMenuItem.Name = "boostQtyDeActiveToolStripMenuItem";
            this.boostQtyDeActiveToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.boostQtyDeActiveToolStripMenuItem.Text = "BoostQtyDeActive";
            this.boostQtyDeActiveToolStripMenuItem.Click += new System.EventHandler(this.boostQtyDeActiveToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(770, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 20);
            this.button1.TabIndex = 19;
            this.button1.Text = "Start Trading";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(495, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(80, 20);
            this.button3.TabIndex = 21;
            this.button3.Text = "Read Qty File";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(879, 13);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 20);
            this.button4.TabIndex = 22;
            this.button4.Text = "Stop Trading";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(671, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 20);
            this.button2.TabIndex = 23;
            this.button2.Text = "Start Feed";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(503, 402);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(108, 31);
            this.button5.TabIndex = 24;
            this.button5.Text = "Cancel Order";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Visible = false;
            this.button5.Click += new System.EventHandler(this.Cancel_AllOrders);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(406, 402);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(91, 31);
            this.button6.TabIndex = 25;
            this.button6.Text = "Buy";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(406, 435);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(91, 31);
            this.button7.TabIndex = 26;
            this.button7.Text = "Sell";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // textBox_Price
            // 
            this.textBox_Price.Location = new System.Drawing.Point(327, 406);
            this.textBox_Price.Name = "textBox_Price";
            this.textBox_Price.Size = new System.Drawing.Size(73, 20);
            this.textBox_Price.TabIndex = 27;
            this.textBox_Price.Text = "0";
            // 
            // textBox_Qty
            // 
            this.textBox_Qty.Location = new System.Drawing.Point(191, 408);
            this.textBox_Qty.Name = "textBox_Qty";
            this.textBox_Qty.Size = new System.Drawing.Size(73, 20);
            this.textBox_Qty.TabIndex = 28;
            this.textBox_Qty.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(155, 410);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Qty";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(279, 409);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Price";
            // 
            // textBox_account
            // 
            this.textBox_account.Location = new System.Drawing.Point(191, 442);
            this.textBox_account.Name = "textBox_account";
            this.textBox_account.Size = new System.Drawing.Size(73, 20);
            this.textBox_account.TabIndex = 31;
            this.textBox_account.Text = "13469";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(139, 444);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "Account";
            // 
            // label_ETF
            // 
            this.label_ETF.AutoSize = true;
            this.label_ETF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ETF.Location = new System.Drawing.Point(1068, 436);
            this.label_ETF.Name = "label_ETF";
            this.label_ETF.Size = new System.Drawing.Size(10, 13);
            this.label_ETF.TabIndex = 33;
            this.label_ETF.Text = "-";
            this.label_ETF.Visible = false;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(1257, 13);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(19, 19);
            this.button8.TabIndex = 38;
            this.button8.Text = "Start Basket";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Visible = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(1253, 0);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(17, 20);
            this.button9.TabIndex = 39;
            this.button9.Text = "Stop Basket";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Visible = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 444);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 41;
            this.label10.Text = "Token";
            // 
            // textBox_token
            // 
            this.textBox_token.Location = new System.Drawing.Point(64, 442);
            this.textBox_token.Name = "textBox_token";
            this.textBox_token.Size = new System.Drawing.Size(73, 20);
            this.textBox_token.TabIndex = 40;
            this.textBox_token.Text = "13528";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 410);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 43;
            this.label11.Text = "Exchange";
            // 
            // textBox_exchange
            // 
            this.textBox_exchange.Location = new System.Drawing.Point(64, 409);
            this.textBox_exchange.Name = "textBox_exchange";
            this.textBox_exchange.Size = new System.Drawing.Size(73, 20);
            this.textBox_exchange.TabIndex = 42;
            this.textBox_exchange.Text = "1";
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(985, 13);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(100, 20);
            this.button10.TabIndex = 44;
            this.button10.Text = "Stop Feed";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(1176, 508);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(83, 32);
            this.button11.TabIndex = 46;
            this.button11.Text = "SaveTo Log";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button_SaveLog);
            // 
            // dataGridView_MarketWatch
            // 
            this.dataGridView_MarketWatch.AllowUserToAddRows = false;
            this.dataGridView_MarketWatch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_MarketWatch.Location = new System.Drawing.Point(3, 43);
            this.dataGridView_MarketWatch.Name = "dataGridView_MarketWatch";
            this.dataGridView_MarketWatch.ReadOnly = true;
            this.dataGridView_MarketWatch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_MarketWatch.Size = new System.Drawing.Size(1339, 347);
            this.dataGridView_MarketWatch.TabIndex = 17;
            this.dataGridView_MarketWatch.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView_MarketWatch_DataError);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(617, 408);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(59, 20);
            this.textBox3.TabIndex = 55;
            this.textBox3.Visible = false;
            // 
            // button_test
            // 
            this.button_test.Location = new System.Drawing.Point(581, 12);
            this.button_test.Name = "button_test";
            this.button_test.Size = new System.Drawing.Size(80, 20);
            this.button_test.TabIndex = 56;
            this.button_test.Text = "avgprice calc";
            this.button_test.UseVisualStyleBackColor = true;
            this.button_test.Click += new System.EventHandler(this.button_test_Click);
            // 
            // button12
            // 
            this.button12.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button12.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button12.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button12.Location = new System.Drawing.Point(835, 398);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(91, 31);
            this.button12.TabIndex = 57;
            this.button12.Text = "Start MOC";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(932, 398);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(91, 31);
            this.button13.TabIndex = 58;
            this.button13.Text = "Stop";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // ipBox
            // 
            this.ipBox.Location = new System.Drawing.Point(835, 437);
            this.ipBox.Name = "ipBox";
            this.ipBox.Size = new System.Drawing.Size(100, 20);
            this.ipBox.TabIndex = 59;
            this.ipBox.Text = "192.168.5.30";
            // 
            // portBox
            // 
            this.portBox.Location = new System.Drawing.Point(835, 463);
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(57, 20);
            this.portBox.TabIndex = 60;
            this.portBox.Text = "50012";
            // 
            // watchidBox
            // 
            this.watchidBox.Location = new System.Drawing.Point(327, 442);
            this.watchidBox.Name = "watchidBox";
            this.watchidBox.Size = new System.Drawing.Size(73, 20);
            this.watchidBox.TabIndex = 61;
            this.watchidBox.Text = "0";
            // 
            // watchidLabel
            // 
            this.watchidLabel.AutoSize = true;
            this.watchidLabel.Location = new System.Drawing.Point(279, 445);
            this.watchidLabel.Name = "watchidLabel";
            this.watchidLabel.Size = new System.Drawing.Size(44, 13);
            this.watchidLabel.TabIndex = 62;
            this.watchidLabel.Text = "WtchID";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(785, 438);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 63;
            this.label7.Text = "CEP IP";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(768, 467);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 64;
            this.label8.Text = "CEP PORT";
            // 
            // stmpMainform
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1276, 645);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.watchidBox);
            this.Controls.Add(this.watchidLabel);
            this.Controls.Add(this.portBox);
            this.Controls.Add(this.ipBox);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button_test);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox_exchange);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox_token);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.label_ETF);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.dataGridView_MarketWatch);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.textBox_Price);
            this.Controls.Add(this.textBox_Qty);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_account);
            this.Controls.Add(this.label3);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "stmpMainform";
            this.Text = "Stampede Low Latency Trading Platform Ver 0.0.0.7";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.stmpMainform_FormClosed);
            this.Load += new System.EventHandler(this.stmpMainform_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_MarketWatch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        /// <summary>
        /// Market Picture recevied
        /// </summary>
        public void MarketPictureReceived(IHost.structQuote QuoteReceived)
        {
            try
            {

                
            /*    String searchValue = QuoteReceived.Token.ToString();
                int rowIndex = -1;
                
                for (int rval = 0; rval < this.dataGridView_MarketWatch.Rows.Count; rval++)
                {
                    DataGridViewRow row = this.dataGridView_MarketWatch.Rows[rval];

                    if (row.Cells["Token"].Value.ToString().Equals(searchValue))
                    {

                        rowIndex = row.Index;
                        break;
                    }

                }

                
                this.dataGridView_MarketWatch.Rows[rowIndex].Cells["Bid"].Value = QuoteReceived.BidPrice1/ MainModule.iDivisor;
                this.dataGridView_MarketWatch.Rows[rowIndex].Cells["Ask"].Value = QuoteReceived.AskPrice1/ MainModule.iDivisor;*/
            }
            catch (Exception ex)
            {
                //Trace.Writeline();
            }
        }





        public void ResetTables()
        {
            try
            {
                MainModule.dtRefOrder = new DataTable();
                MainModule.dtRefOrder.Columns.Add("iIndex", typeof(int));
                MainModule.dtRefOrder.Columns.Add("Oid", typeof(int));
                MainModule.dtRefOrder.Columns.Add("ExchOrdno", typeof(long));
                MainModule.dtRefOrder.Columns.Add("Uid", typeof(int));
                MainModule.dtRefOrder.Columns.Add("TrdPrice", typeof(double));
                MainModule.dtRefOrder.Columns.Add("TrdQty", typeof(int));
                MainModule.dtRefOrder.Columns.Add("OrgPrice", typeof(double));
                MainModule.dtRefOrder.Columns.Add("Tradeornot", typeof(int));
                MainModule.dtRefOrder.Columns.Add("exitRef", typeof(double));


                MainModule.dtfileinputs = new DataTable();
                MainModule.dtfileinputs.Columns.Add("symbol", typeof(string));
                MainModule.dtfileinputs.Columns.Add("account", typeof(string));
                MainModule.dtfileinputs.Columns.Add("price", typeof(double));
                MainModule.dtfileinputs.Columns.Add("qty", typeof(int));


               /* MainModule.dtplacing_data = new DataTable();
                MainModule.dtplacing_data.Columns.Add("symbol", typeof(string));
                MainModule.dtplacing_data.Columns.Add("account", typeof(string));
                MainModule.dtplacing_data.Columns.Add("price", typeof(double));
                MainModule.dtplacing_data.Columns.Add("qty", typeof(int));
                */

                MainModule.dtpricemax_input = new DataTable();
                MainModule.dtpricemax_input.Columns.Add("symbol", typeof(string));
                MainModule.dtpricemax_input.Columns.Add("account", typeof(string));
                //MainModule.dtpricemax_input.Columns.Add("price", typeof(double));
                //MainModule.dtpricemax_input.Columns.Add("maxqty", typeof(int));
                MainModule.dtpricemax_input.Columns.Add("minuteqty", typeof(int));


                MainModule.dtminutes = new DataTable();
                MainModule.dtminutes.Columns.Add("symbol", typeof(string));
                MainModule.dtminutes.Columns.Add("account", typeof(string));
                MainModule.dtminutes.Columns.Add("oid", typeof(int));
                MainModule.dtminutes.Columns.Add("cancelsend", typeof(int));
                

                

                MainModule.dtWatch = new DataTable();
                MainModule.dtWatch.Columns.Add("StrategyID", typeof(int));
                MainModule.dtWatch.Columns.Add("Exchange", typeof(int));
                MainModule.dtWatch.Columns.Add("ScripName", typeof(string));
                MainModule.dtWatch.Columns.Add("Bid", typeof(decimal));
                MainModule.dtWatch.Columns.Add("Ask", typeof(decimal));
                MainModule.dtWatch.Columns.Add("BuyQty", typeof(int));
                MainModule.dtWatch.Columns.Add("SellQty", typeof(int));
                MainModule.dtWatch.Columns.Add("Token", typeof(int));
                MainModule.dtWatch.Columns.Add("Stgtype", typeof(int));


                MainModule.dtBasketBook = new DataTable();
                MainModule.dtBasketBook.Columns.Add("StrategyID", typeof(int));
                MainModule.dtBasketBook.Columns.Add("ScripName", typeof(string));
                MainModule.dtBasketBook.Columns.Add("Bid", typeof(decimal));
                MainModule.dtBasketBook.Columns.Add("Ask", typeof(decimal));
                MainModule.dtBasketBook.Columns.Add("Qty", typeof(int));
                MainModule.dtBasketBook.Columns.Add("Ltp", typeof(decimal));
                MainModule.dtBasketBook.Columns.Add("BamPrice", typeof(double));
                MainModule.dtBasketBook.Columns.Add("Token", typeof(int));
                MainModule.dtBasketBook.Columns.Add("Fixedvalue", typeof(double));
                MainModule.dtBasketBook.Columns.Add("Capital", typeof(double));
                MainModule.dtBasketBook.Columns.Add("StockSumbid", typeof(double));
                MainModule.dtBasketBook.Columns.Add("StockSumask", typeof(double));
                MainModule.dtBasketBook.Columns.Add("StockSumltp", typeof(double));
                MainModule.dtBasketBook.Columns.Add("etfStockSumbid", typeof(double));
                MainModule.dtBasketBook.Columns.Add("etfStockSumask", typeof(double));
                MainModule.dtBasketBook.Columns.Add("etfStockSumltp", typeof(double));
                MainModule.dtBasketBook.Columns.Add("etfbid", typeof(double));
                MainModule.dtBasketBook.Columns.Add("etfask", typeof(double));
                MainModule.dtBasketBook.Columns.Add("etfltp", typeof(double));
                MainModule.dtBasketBook.Columns.Add("EtfQty", typeof(int));




                /* MainModule.dtRefOrder = new DataTable();
                 MainModule.dtRefOrder.Columns.Add("iIndex", typeof(int));
                 MainModule.dtRefOrder.Columns.Add("OrderNo", typeof(string));
                 MainModule.dtRefOrder.Columns.Add("BuySell", typeof(string));
                 MainModule.dtRefOrder.Columns.Add("OrderType", typeof(string));
                 MainModule.dtRefOrder.Columns.Add("RefOrderNo", typeof(string));
                 MainModule.dtWatch = new DataTable();
                 MainModule.dtWatch.Columns.Add("WatchId", typeof(int));
                 MainModule.dtWatch.Columns.Add("InstrumentIdentifier", typeof(long));
                 MainModule.dtWatch.Columns.Add("InstrumentCode", typeof(string));
                 MainModule.dtWatch.Columns.Add("ExpiryDate", typeof(DateTime));
                 MainModule.dtWatch.Columns.Add("TickSize", typeof(decimal));
                 MainModule.dtWatch.Columns.Add("LotSize", typeof(int));
                 MainModule.dtWatch.Columns.Add("MaxLotSize", typeof(int));
                 MainModule.dtWatch.Columns.Add("MLot", typeof(int));
                 MainModule.dtWatch.Columns.Add("DisclosedQty", typeof(int));
                 MainModule.dtWatch.Columns.Add("SLTick", typeof(int));
                 MainModule.dtWatch.Columns.Add("PTick", typeof(int));
                 MainModule.dtWatch.Columns.Add("SL", typeof(short));
                 MainModule.dtWatch.Columns.Add("TSL", typeof(short));
                 MainModule.dtWatch.Columns.Add("TQty", typeof(int));
                 MainModule.dtWatch.Columns.Add("Exchange", typeof(string));
                 MainModule.dtWatch.Columns.Add("InstrumentName", typeof(string));
                 MainModule.dtWatch.Columns.Add("InstrumentType", typeof(string));
                 MainModule.dtWatch.Columns.Add("AveragePrice", typeof(decimal));
                 MainModule.dtWatch.Columns["ExpiryDate"].DefaultValue = DateTime.Now;
                 MainModule.dtWatch.Columns["TickSize"].DefaultValue = 0.00M;
                 MainModule.dtWatch.Columns["LotSize"].DefaultValue = 0x3e8;
                 MainModule.dtWatch.Columns["MaxLotSize"].DefaultValue = 0x2710;
                 MainModule.dtWatch.Columns["AveragePrice"].DefaultValue = 0x3e8;
                 MainModule.dtWatch.Columns["MLot"].DefaultValue = 1;
                 MainModule.dtWatch.Columns["SLTick"].DefaultValue = 1;
                 MainModule.dtWatch.Columns["PTick"].DefaultValue = 1;
                 MainModule.dtWatch.Columns["SL"].DefaultValue = 0;
                 MainModule.dtWatch.Columns["TSL"].DefaultValue = 0;
                 MainModule.dtWatch.Columns["TQty"].DefaultValue = 0;
                 MainModule.dtWatch.Columns["DisclosedQtyMainModuleDefaultValue = 0;
                 MainModule.lockDtInstrument = new object();*/
                MainModule.dtInstrument = new DataTable();

                MainModule.dtInstrument.Columns.Add("StrategyID", typeof(long));
                MainModule.dtInstrument.Columns.Add("Token", typeof(long));
                MainModule.dtInstrument.Columns.Add("Dispname", typeof(string));
                MainModule.dtInstrument.Columns.Add("ExpiryDate", typeof(DateTime));
                MainModule.dtInstrument.Columns.Add("TickSize", typeof(decimal));
                MainModule.dtInstrument.Columns.Add("LotSize", typeof(int));
                MainModule.dtInstrument.Columns.Add("High", typeof(decimal));
                MainModule.dtInstrument.Columns.Add("Low", typeof(decimal));
                MainModule.dtInstrument.Columns.Add("DPRHigh", typeof(decimal));
                MainModule.dtInstrument.Columns.Add("DPRLow", typeof(decimal));
                MainModule.dtInstrument.Columns.Add("PriceNumerator", typeof(decimal));
                MainModule.dtInstrument.Columns.Add("PriceDenominator", typeof(decimal));
                MainModule.dtInstrument.Columns.Add("GeneralNumerator", typeof(decimal));
                MainModule.dtInstrument.Columns.Add("GeneralDenominator", typeof(decimal));
                MainModule.dtInstrument.Columns.Add("LotNumerator", typeof(decimal));
                MainModule.dtInstrument.Columns.Add("LotDenominator", typeof(decimal));
                MainModule.dtInstrument.Columns.Add("AveragePrice", typeof(decimal));
                MainModule.dtInstrument.Columns["AveragePrice"].Expression = "(PriceNumerator/PriceDenominator) * (GeneralNumerator/GeneralDenominator) * LotSize";
                MainModule.dtInstrument.Columns.Add("InstrumentDescription", typeof(string));
                MainModule.dtInstrument.Columns.Add("InstrumentInfo", typeof(string));
                MainModule.dtInstrument.Columns.Add("ULAssest", typeof(string));
                MainModule.dtInstrument.Columns.Add("PriceQuoteUnit", typeof(string));
                MainModule.dtInstrument.Columns.Add("MaxSingleTransactionQuantity", typeof(int));
                MainModule.dtInstrument.Columns.Add("MaxSingleTransactionValue", typeof(decimal));
                MainModule.dtInstrument.Columns.Add("ProductStartDate", typeof(DateTime));
                MainModule.dtInstrument.Columns.Add("LastTradingDate", typeof(DateTime));
                MainModule.dtInstrument.Columns.Add("DeliveryStartDate", typeof(DateTime));
                MainModule.dtInstrument.Columns.Add("DeliveryEndDate", typeof(DateTime));
                MainModule.dtInstrument.Columns.Add("TenderStartDate", typeof(DateTime));
                MainModule.dtInstrument.Columns.Add("TenderEndDate", typeof(DateTime));
                MainModule.dtInstrument.Columns.Add("InstrumentType", typeof(short));
                MainModule.dtInstrument.Columns.Add("PermitTrading", typeof(byte));
                MainModule.dtInstrument.Columns.Add("InstrumentStatusFlag", typeof(string));
                MainModule.dtInstrument.Columns.Add("MinimumLot", typeof(uint));
                MainModule.dtInstrument.Columns.Add("InstrumentName", typeof(string));
                MainModule.dtInstrument.Columns.Add("OriginalExpiryDate", typeof(DateTime));
                MainModule.dtInstrument.Columns.Add("TermsOfInitialMargin", typeof(short));
                MainModule.dtInstrument.Columns.Add("BuyInitialMarginRate", typeof(decimal));
                MainModule.dtInstrument.Columns.Add("SellInitialMarginRate", typeof(decimal));
                MainModule.dtInstrument.Columns.Add("BuySpecialMarginRate", typeof(decimal));
                MainModule.dtInstrument.Columns.Add("SellSpecialMarginRate", typeof(decimal));
                MainModule.dtInstrument.Columns.Add("TermsOfSpecialMargin", typeof(short));
                MainModule.dtInstrument.Columns.Add("InitialMarginSpreadBenefitFlag", typeof(short));
                MainModule.dtOrderBook = new DataTable();

                MainModule.dtTradeBook = new DataTable();

                MainModule.dtTradeBook.Columns.Add("StrategyID", typeof(long));
                MainModule.dtTradeBook.Columns.Add("Token", typeof(long));
                MainModule.dtTradeBook.Columns.Add("ExchOrdNum", typeof(long));
                MainModule.dtTradeBook.Columns.Add("Account", typeof(String));
                MainModule.dtTradeBook.Columns.Add("Dispname", typeof(String));
                MainModule.dtTradeBook.Columns.Add("Exch", typeof(String));
                MainModule.dtTradeBook.Columns.Add("BuyorSell", typeof(String));
                MainModule.dtTradeBook.Columns.Add("Oid", typeof(long));
                MainModule.dtTradeBook.Columns.Add("TrdQty", typeof(int));
                MainModule.dtTradeBook.Columns.Add("TrdPrice", typeof(int));
                MainModule.dtTradeBook.Columns.Add("TotTrdQty", typeof(int));
       

                MainModule.dtNetPosition = new DataTable();
                MainModule.dtNetPosition.Columns.Add("StrategyID", typeof(long));
                MainModule.dtNetPosition.Columns.Add("Token", typeof(long));
                MainModule.dtNetPosition.Columns.Add("Symbol");
                //    MainModule.dtNetPosition.Columns.Add("ExpiryDate", typeof(DateTime));
                MainModule.dtNetPosition.Columns.Add("dmFactor", typeof(decimal));
                MainModule.dtNetPosition.Columns["dmFactor"].DefaultValue = 0;
                MainModule.dtNetPosition.Columns.Add("BuyQuantity", typeof(int));
                MainModule.dtNetPosition.Columns["BuyQuantity"].DefaultValue = 0;
                MainModule.dtNetPosition.Columns.Add("BuyPrice", typeof(decimal));
                MainModule.dtNetPosition.Columns["BuyPrice"].DefaultValue = 0;
                //  MainModule.dtNetPosition.Columns.Add("BuyAvg", typeof(decimal));
                //  MainModule.dtNetPosition.Columns["BuyAvg"].DefaultValue = 0;
                //  MainModule.dtNetPosition.Columns["BuyAvg"].Expression = "IIF(BuyQuantity<>0,BuyPrice/(BuyQuantity*dmFactor),0)";
                MainModule.dtNetPosition.Columns.Add("SellQuantity", typeof(int));
                MainModule.dtNetPosition.Columns["SellQuantity"].DefaultValue = 0;

                MainModule.dtNetPosition.Columns.Add("NetQuantity", typeof(int));
                MainModule.dtNetPosition.Columns["NetQuantity"].DefaultValue = 0;
                MainModule.dtNetPosition.Columns["NetQuantity"].Expression = "BuyQuantity-SellQuantity";
                MainModule.dtNetPosition.Columns.Add("SellPrice", typeof(decimal));
                MainModule.dtNetPosition.Columns["SellPrice"].DefaultValue = 0;

                /* MainModule.dtNetPosition.Columns.Add("SellAvg", typeof(decimal));
                 MainModule.dtNetPosition.Columns["SellAvg"].DefaultValue = 0;
                 MainModule.dtNetPosition.Columns["SellAvg"].Expression = "IIF(SellQuantity<>0,SellPrice/(SellQuantity*dmFactor),0)";
               
                 MainModule.dtNetPosition.Columns.Add("NetPrice", typeof(decimal));
                 MainModule.dtNetPosition.Columns["NetPrice"].DefaultValue = 0;
                 MainModule.dtNetPosition.Columns["NetPrice"].Expression = "SellPrice-BuyPrice";
                 MainModule.dtNetPosition.Columns.Add("NetAvg", typeof(decimal));
                 MainModule.dtNetPosition.Columns["NetAvg"].DefaultValue = 0;
                 MainModule.dtNetPosition.Columns["NetAvg"].Expression = "IIF(NetQuantity<>0,((BuyQuantity*BuyAvg)-(SellQuantity*SellAvg))/NetQuantity,0)";
                 MainModule.dtNetPosition.Columns.Add("CurrMarketPrice", typeof(decimal));
                 MainModule.dtNetPosition.Columns["CurrMarketPrice"].DefaultValue = 0;
                 MainModule.dtNetPosition.Columns.Add("M2MPosition", typeof(decimal));
                 MainModule.dtNetPosition.Columns["M2MPosition"].DefaultValue = 0;
                 MainModule.dtNetPosition.Columns["M2MPosition"].Expression = "NetQuantity*CurrMarketPrice*dmFactor";
                 MainModule.dtNetPosition.Columns.Add("M2MGain", typeof(decimal));
                 MainModule.dtNetPosition.Columns["M2MGain"].DefaultValue = 0;
                 MainModule.dtNetPosition.Columns["M2MGain"].Expression = " (M2MPosition)+(NetPrice)";*/


            }
            catch (Exception ex)
            {
              //  Trace.WriteLine("Exception occured" + ex.ToString());

                //  MessageBox.Show("Exception occured" + ex.ToString());

            }
        }


        private void BindingProcess()
        {
            try
            {
                DataGridViewCellStyle style = new DataGridViewCellStyle();
                //{
                style.FormatProvider = MainModule.numberformat;
                style.Format = "N4";
                style.NullValue = "00.0000";
                style.Alignment = DataGridViewContentAlignment.MiddleRight;
                // };
                DataGridViewCellStyle style2 = new DataGridViewCellStyle();
                //{
                style2.NullValue = "1";
                style2.Alignment = DataGridViewContentAlignment.MiddleRight;
                //                };

                this.dataGridView_MarketWatch.DataSource = MainModule.dtWatch;

                MainModule.dtWatch.Columns.Add("StrategyID", typeof(int));
                MainModule.dtWatch.Columns.Add("Exchange", typeof(int));
                MainModule.dtWatch.Columns.Add("ScripName", typeof(string));
                MainModule.dtWatch.Columns.Add("BuyQty", typeof(int));
                MainModule.dtWatch.Columns.Add("SellQty", typeof(int));
              //  MainModule.frmNetposition.dataGridView1.DataSource = MainModule.dtNetPosition;


            }
            catch (Exception exception2)
            {
                //  MainModule.objGlobalFunctions.WriteToErrorLogFile("Binding Process" + exception2.Message);
                //  this.AlertLog("Displaying data fail..." + exception2.Message);
               // Trace.WriteLine("Binding Process" + exception2.Message);

            }



        }



        public void AddScripMarketWatch(int token, StructureTestStrategies.DailyMarketWatch Dmw)
        {

            try
            {
              
                this.dataGridView_MarketWatch.DataSource = MainModule.dtWatch;
                DataGridViewColumn column = this.dataGridView_MarketWatch.Columns[0];
                DataGridViewColumn column1 = this.dataGridView_MarketWatch.Columns[1];
                DataGridViewColumn column2= this.dataGridView_MarketWatch.Columns[2];
                DataGridViewColumn column3 = this.dataGridView_MarketWatch.Columns[3];
                DataGridViewColumn column4 = this.dataGridView_MarketWatch.Columns[4];
                DataGridViewColumn column5 = this.dataGridView_MarketWatch.Columns[5];
                DataGridViewColumn column6 = this.dataGridView_MarketWatch.Columns[6];
                DataGridViewColumn column7 = this.dataGridView_MarketWatch.Columns[7];
                DataGridViewColumn column8 = this.dataGridView_MarketWatch.Columns[8];
                DataGridViewColumn column9 = this.dataGridView_MarketWatch.Columns[9];
                DataGridViewColumn column10 = this.dataGridView_MarketWatch.Columns[10];
                DataGridViewColumn column11 = this.dataGridView_MarketWatch.Columns[11];
                DataGridViewColumn column12 = this.dataGridView_MarketWatch.Columns[12];
                DataGridViewColumn column13 = this.dataGridView_MarketWatch.Columns[13];
                DataGridViewColumn column14 = this.dataGridView_MarketWatch.Columns[14];
                DataGridViewColumn column15 = this.dataGridView_MarketWatch.Columns[15];
                DataGridViewColumn column16 = this.dataGridView_MarketWatch.Columns[16];
                DataGridViewColumn column17 = this.dataGridView_MarketWatch.Columns[17];
                DataGridViewColumn column18 = this.dataGridView_MarketWatch.Columns[18];
                DataGridViewColumn column19 = this.dataGridView_MarketWatch.Columns[19];

                column.Width = 50;
                column1.Width = 50;
                column2.Width = 50;
                column3.Width = 50;
                column4.Width = 50;
                column5.Width = 50;
                column6.Width = 50;
                column7.Width = 50;
                column8.Width = 50;
                column9.Width = 50;
                column10.Width = 50;
                column11.Width = 50;
                column12.Width = 50;
                column13.Width = 50;
                column14.Width = 50;
                column15.Width = 50;
                column16.Width = 50;
                column17.Width = 50;
                column18.Width = 50;
                column19.Width = 50;

                if (MainModule._clsstmputilobj != null)
                {
               
                    MainModule._clsstmputilobj.MarketDictionary.Add(Dmw.watchid, Dmw);
                }
                               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }


        }

        private void testStrategyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void loadXmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try {

                teststg = new TestStrategy();
                teststg.Show();
            
            }
            catch (Exception ex) { }
        }

        private void dataGridView_MarketWatch_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void netPositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
           


         if (MainModule.frmNetposition == null)
            {

              MainModule.frmNetposition = MainModule.GetNetposBook();
              MainModule.frmNetposition.Show();
           
            }else
            {
                MainModule.frmNetposition.Show();
            }
         

        }

        private void stmpMainform_Load(object sender, EventArgs e)
        {
            _textBoxListener = new TextBoxTraceListener(textBox1);
            Trace.Listeners.Add(_textBoxListener);            
        }


        private void StartDistribution()
        {
            System.IO.StreamReader file = new System.IO.StreamReader(@"DisStatus.txt");
            string firstline = file.ReadLine();

            int _dfirstline = Int32.Parse(firstline);
            Trace.WriteLine("Distribution Status : " + _dfirstline);
            if (_dfirstline == 1)
            {
               // Trace.WriteLine("Before Distribution 1");
                MainModule.frmdlg.myparent.Model_AdjustDistribution();

               
              //  Trace.WriteLine("Before Distribution 2");


                MainModule.frmdlg.myparent.InitializeMarketPicturetoZeros();

                Thread.Sleep(30);
                MainModule.starttrading = 1;
                button1.Enabled = false;
                button4.Enabled = true;
            }
            else
            {

                MainModule.starttrading = 1;
                button1.Enabled = false;
                button4.Enabled = true;

            }
            file.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {

            ThreadStart myThreadDis = new ThreadStart(StartDistribution);
            Thread myThreaddis = new Thread(myThreadDis);
            myThreaddis.Priority = ThreadPriority.Normal;
            myThreaddis.Start();
            MainModule._globalsecond = 1;
            _timer_1secs.Start();
           
        }


        public void AutoStartTrading()
        {
            Trace.WriteLine("NSE ................Trading Started");
        }


        /// <summary>
        /// Check Distribution AdjustMents @ 9:15
        /// </summary>
        
        private void button2_Click(object sender, EventArgs e)
        {
            
          
        }

        

        private void button4_Click(object sender, EventArgs e)
        {
            MainModule.starttrading = 0;

            button1.Enabled = true;
            button4.Enabled = false;

            _timer_1secs.Stop();
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            MainModule.startfeed = 1;
            MainModule.breakFlag = true;
            button2.Enabled = false;
            button10.Enabled = true;
        }

        private void Cancel_AllOrders(object sender, EventArgs e)
        {
            try
            {
              //get index of strategy
             if (MainModule.frmdlg.dataGridView_MarketWatch != null)
                {

                    int selectedIndex = MainModule.frmdlg.dataGridView_MarketWatch.CurrentCell.RowIndex;

                    if (selectedIndex != -1)
                    {
                        Trace.WriteLine("selectedIndex..." + selectedIndex);
                      MainModule.frmdlg.myparent.CancelAllOrders(MainModule.objMarketWatch[selectedIndex].iWatchId);
                        MainModule.frmdlg.myparent.CancelOrderId(Convert.ToInt32(textBox3.Text));
                    }
                    else
                    {
                        Trace.WriteLine("selectedIndex...jin else" + selectedIndex);

                    }


                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Selected Index :"+ex.ToString());
            }

        }

        private void dataGridView_MarketWatch_Click(object sender, EventArgs e)
        {

            try {

              
            
            }
            catch (Exception ex) { 



            }

        }


        //buy
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                MainModule.frmdlg.myparent.SendOrder(Convert.ToInt32(textBox_token.Text), 1, Convert.ToDouble(textBox_Price.Text), textBox_account.Text, Convert.ToInt32(textBox_Qty.Text), Convert.ToInt32(textBox_exchange.Text));
              
                
                
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Error Manual Buy "+ex.ToString());
            }
            

        }
        //sell
        private void button7_Click(object sender, EventArgs e)
        {


                        
            try
            {

                MainModule.frmdlg.myparent.SendOrder(Convert.ToInt32(textBox_token.Text), 2, Convert.ToDouble(textBox_Price.Text), textBox_account.Text, Convert.ToInt32(textBox_Qty.Text), Convert.ToInt32(textBox_exchange.Text));
            
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Error Manual Sell " + ex.ToString());
            }


        }

        private void loadBasketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                MainModule._frmbaskettrd = new frmBasketTrading();
                MainModule._frmbaskettrd.Show();

            }
            catch (Exception ex) { }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MainModule._startBaskettrading = 1;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MainModule._startBaskettrading = 0;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {

                MainModule.startfeed = 0;
                button2.Enabled = true;
                button10.Enabled = false;
                MainModule.breakFlag = false;

            }
            catch (Exception ex) { }
        }

        private void stmpMainform_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Trace.WriteLine("Closing Feed Process !");
                MainModule.startfeed = 0;
            }
            catch (Exception ex) { }
        }

        private void button_SaveLog(object sender, EventArgs e)
        {
            try
            {

                // MessageBox.Show(textBox1.Text);

                string _tradelogfile = string.Format("Trade-{0:yyyy-MM-dd_hh-mm-ss-tt}.txt", DateTime.Now);
                //File.WriteAllText(n, "aaa");


                using (System.IO.StreamWriter file = new System.IO.StreamWriter(_tradelogfile, true))
                {
                    file.WriteLine(textBox1.Text);
                    this.textBox1.Text = String.Empty;
                }


            }
            catch (Exception ex)
            {

                Trace.WriteLine("SaveLog: " + ex.ToString());
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            
            
            try{
   
                MainModule.frmdlg.myparent.Model_AdjustDistribution();
               


            }
            catch (Exception ex)
            {
                Trace.WriteLine("Distribution Adjust Update Required" + ex.ToString());
            }


        }

        private void fileDistributionToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Trace.WriteLine("in file writing 1");
          try{
              if (MainModule.objMarketWatch != null && MainModule.objMarketWatch.Length > 0)
              {

                  Trace.WriteLine("in file writing 2" + MainModule.objMarketWatch.Length);
                  for (int i = 0; i < MainModule.objMarketWatch.Length; i++)
                  {
                      int _uid = MainModule.objMarketWatch[i].iWatchId;
                      Trace.WriteLine("in file writing 3" + _uid);
                      
                      if (MainModule._clsstmputilobj.strategyDictionary.ContainsKey(_uid))
                      {
                          StructureTestStrategies.MarketWatch vwapstg = MainModule._clsstmputilobj.strategyDictionary[_uid];

                          Trace.WriteLine("in uid matched 4" + vwapstg.Obook.oid);
                          //2328,63,2418,1,1,BS0009,1,
                          if (vwapstg.Obook.orderstatus == 1)
                          {
                              Trace.WriteLine("in file writing 5 " + "AdjustDisFile.txt", vwapstg.Obook.token + "," + vwapstg.Obook.qty + "," + vwapstg.Obook.ordprice + "," + vwapstg.Obook.buysell + "," + vwapstg.Obook.exch + "," + vwapstg.Obook.Account + "," + vwapstg.Obook.StrategyId + "\n");
                              //File.AppendText("AdjustDisFile.txt",vwapstg.Obook.token + "," + vwapstg.Obook.qty + "," + vwapstg.Obook.ordprice + "," + vwapstg.Obook.buysell + "," + vwapstg.Obook.exch + "," + vwapstg.Obook.Account + "," + vwapstg.Obook.StrategyId+",\n");
                          }

                      }

                  }

                     
              }
            
            }
            catch (Exception ex)
            {
                Trace.WriteLine("File Distribution :"+ex.ToString());
            }
        }

        private void button_updateexhaust_Click(object sender, EventArgs e)
        {
            
        }

        private void activateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dataGridView_MarketWatch.SelectedRows[0].Index;
                string _stgid = dataGridView_MarketWatch.Rows[index].Cells[0].Value.ToString();

                MainModule._clsstmputilobj.AppendTrace(" Menu Activate Selected Index" + index + " Stgid" + _stgid, Color.Blue);

                MainModule.frmdlg.myparent.ADScriptStatechange(Convert.ToInt32(_stgid), true);

            }
            catch (Exception ex)
            {
                MainModule._clsstmputilobj.AppendTrace("Activate:" + ex.ToString(), Color.Blue);
            }
        }

        private void deActivateToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {

                int index = dataGridView_MarketWatch.SelectedRows[0].Index;


                string _stgid = dataGridView_MarketWatch.Rows[index].Cells[0].Value.ToString();

                MainModule._clsstmputilobj.AppendTrace(" Menu DeActivate Selected Index" + index + " Stgid" + _stgid, Color.Blue);

                MainModule.frmdlg.myparent.ADScriptStatechange(Convert.ToInt32(_stgid), false);

            }
            catch (Exception ex)
            {
                MainModule._clsstmputilobj.AppendTrace("Deactivate:" + ex.ToString(), Color.Blue);
            }

        }

        private void showLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainModule._showlog = 1;
        }


        //1 second
        private void timer_1secs_Tick(object sender, EventArgs e)
        {
            try
            {
                
                MainModule.frmdlg.myparent.oneSecond();


            }

            catch (Exception ex)
            {
                Trace.WriteLine("T:timercheck:" + ex.ToString());
            }
        }


        private void cancelStrategyToolStripMenuItem_Click(object sender, EventArgs e)
        {
         

        }

        private void cancelStrategyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {

                int index = dataGridView_MarketWatch.SelectedRows[0].Index;
                string _stgid = dataGridView_MarketWatch.Rows[index].Cells[0].Value.ToString();
                MainModule.frmdlg.myparent.ADScriptStatechange(Convert.ToInt32(_stgid), false);
                MainModule._clsstmputilobj.AppendTrace("CLSID: " + _stgid, Color.Blue);
                MainModule.frmdlg.myparent.CancelAllOrdersSelectedScript(Convert.ToInt32(_stgid));


            }
            catch (Exception ex)
            {
                MainModule._clsstmputilobj.AppendTrace("E:CancelStrategy:" + ex.ToString(), Color.Blue);
            }
        }

        private void resetTradingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
               
                int index = dataGridView_MarketWatch.SelectedRows[0].Index;
                MainModule.objMarketWatch[index].send_prev_session_order = 0;

                MainModule.objMarketWatch[index].stopplacingorder = 0;
                MainModule.objMarketWatch[index]._startcanceltrade = 0;
                MainModule.objMarketWatch[index]._stopcanceltrade = 0;
            }
            catch (Exception ex)
            {
                MainModule._clsstmputilobj.AppendTrace("E:resetTrading:" + ex.ToString(), Color.Blue);
            }
            
        }

        private void button_test_Click(object sender, EventArgs e)
        {

            try
            {

                MainModule.frmdlg.myparent.placingfffff();



            }
            catch (Exception ex)
            {
                Trace.WriteLine("testttttt:" + ex.ToString());
            }

        }

        private void boostingMinuteQtyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainModule._boostvalue = 1;
            MainModule._clsstmputilobj.AppendTrace("BoostValue:" + MainModule._boostvalue, Color.Blue);
        }

        private void boostQtyDeActiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainModule._boostvalue = 0;
            MainModule._clsstmputilobj.AppendTrace("BoostValue:" + MainModule._boostvalue, Color.Blue);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Plugin pg = new Plugin();
            MainModule.startMoc = 1;

            pg.ConnectNSETCPCepSocket();
            button12.Enabled = false;
            button13.Enabled = true;
            MainModule.heartbeatTimer.Enabled = true;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            MainModule.startMoc = 0;           
            button12.Enabled = true;
            button13.Enabled = false;
            MainModule.heartbeatTimer.Stop();
        }



   }
}
