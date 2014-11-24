using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuantX
{
    public class TestStrategy : Form
    {
        private GroupBox groupBox2;
        private TextBox textBox_Qty;
        private TextBox textBox_price;
        private Label label1;
        private Label label2;
        private TextBox textBox_token;
        private Label label3;
        private TextBox textBox_Symbol;
        private Label label4;
        private Button button2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label5;
        private Label label6;
        private TextBox textBox3;
        private Label label7;
        private TextBox textBox4;
        private GroupBox groupBox4;
        private Label label8;
        private GroupBox groupBox1;
        private Button button5;
        private Button button1;
        private Button button4;
        private GroupBox groupBox_algo;
        private Label label_exchange;
        private ComboBox comboBox1;
        private ComboBox comboBox6;
        private Label label13;
        private ComboBox comboBox5;
        private Label label12;
        private ComboBox comboBox4;
        private Label label11;
        private ComboBox comboBox3;
        private Label label10;
        private ComboBox comboBox2;
        private Label label9;
        private Label label14;
        private TextBox textBox5;
        private TextBox textBox11;
        private Label label20;
        private TextBox textBox12;
        private Label label21;
        private TextBox textBox13;
        private Label label22;
        private TextBox textBox8;
        private Label label17;
        private TextBox textBox9;
        private Label label18;
        private TextBox textBox10;
        private Label label19;
        private TextBox textBox7;
        private Label label16;
        private TextBox textBox6;
        private Label label15;
        private TextBox textBox14;
        private Label label23;
        private TextBox textBox15;
        private Label label24;
        private TextBox textBox16;
        private Label label25;
        private CheckBox checkBox_BufferCheck;
        private Button button3;
    
        public TestStrategy()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_Qty = new System.Windows.Forms.TextBox();
            this.textBox_price = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_token = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Symbol = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox_algo = new System.Windows.Forms.GroupBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label_exchange = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.checkBox_BufferCheck = new System.Windows.Forms.CheckBox();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox_algo.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_Qty);
            this.groupBox2.Controls.Add(this.textBox_price);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBox_token);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBox_Symbol);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(14, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(55, 32);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Leg1 Rules";
            // 
            // textBox_Qty
            // 
            this.textBox_Qty.Location = new System.Drawing.Point(256, 66);
            this.textBox_Qty.Name = "textBox_Qty";
            this.textBox_Qty.Size = new System.Drawing.Size(84, 20);
            this.textBox_Qty.TabIndex = 5;
            this.textBox_Qty.Text = "1000";
            // 
            // textBox_price
            // 
            this.textBox_price.Location = new System.Drawing.Point(368, 66);
            this.textBox_price.Name = "textBox_price";
            this.textBox_price.Size = new System.Drawing.Size(95, 20);
            this.textBox_price.TabIndex = 6;
            this.textBox_price.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(365, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Price";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(253, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Qty";
            // 
            // textBox_token
            // 
            this.textBox_token.Location = new System.Drawing.Point(155, 66);
            this.textBox_token.Name = "textBox_token";
            this.textBox_token.Size = new System.Drawing.Size(82, 20);
            this.textBox_token.TabIndex = 4;
            this.textBox_token.Text = "11957";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(152, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Token";
            // 
            // textBox_Symbol
            // 
            this.textBox_Symbol.Location = new System.Drawing.Point(28, 66);
            this.textBox_Symbol.Name = "textBox_Symbol";
            this.textBox_Symbol.Size = new System.Drawing.Size(98, 20);
            this.textBox_Symbol.TabIndex = 3;
            this.textBox_Symbol.Text = "IDFCEQ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Symbol";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(131, 282);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 34);
            this.button2.TabIndex = 1;
            this.button2.Text = "Run";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(256, 66);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(84, 20);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "1000";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(368, 66);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(95, 20);
            this.textBox2.TabIndex = 6;
            this.textBox2.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(365, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Price";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(253, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Qty";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(155, 66);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(82, 20);
            this.textBox3.TabIndex = 4;
            this.textBox3.Text = "11957";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(152, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Token";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(28, 66);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(98, 20);
            this.textBox4.TabIndex = 3;
            this.textBox4.Text = "IDFCEQ";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBox1);
            this.groupBox4.Controls.Add(this.textBox2);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.textBox3);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.textBox4);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Location = new System.Drawing.Point(76, 18);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(55, 31);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Leg2 Rules";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(39, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Symbol";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox_BufferCheck);
            this.groupBox1.Controls.Add(this.groupBox_algo);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Location = new System.Drawing.Point(3, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(947, 399);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Test Model ";
            // 
            // groupBox_algo
            // 
            this.groupBox_algo.Controls.Add(this.textBox14);
            this.groupBox_algo.Controls.Add(this.label23);
            this.groupBox_algo.Controls.Add(this.textBox15);
            this.groupBox_algo.Controls.Add(this.label24);
            this.groupBox_algo.Controls.Add(this.textBox16);
            this.groupBox_algo.Controls.Add(this.label25);
            this.groupBox_algo.Controls.Add(this.textBox11);
            this.groupBox_algo.Controls.Add(this.label20);
            this.groupBox_algo.Controls.Add(this.textBox12);
            this.groupBox_algo.Controls.Add(this.label21);
            this.groupBox_algo.Controls.Add(this.textBox13);
            this.groupBox_algo.Controls.Add(this.label22);
            this.groupBox_algo.Controls.Add(this.textBox8);
            this.groupBox_algo.Controls.Add(this.label17);
            this.groupBox_algo.Controls.Add(this.textBox9);
            this.groupBox_algo.Controls.Add(this.label18);
            this.groupBox_algo.Controls.Add(this.textBox10);
            this.groupBox_algo.Controls.Add(this.label19);
            this.groupBox_algo.Controls.Add(this.textBox7);
            this.groupBox_algo.Controls.Add(this.label16);
            this.groupBox_algo.Controls.Add(this.textBox6);
            this.groupBox_algo.Controls.Add(this.label15);
            this.groupBox_algo.Controls.Add(this.textBox5);
            this.groupBox_algo.Controls.Add(this.label14);
            this.groupBox_algo.Controls.Add(this.comboBox6);
            this.groupBox_algo.Controls.Add(this.label13);
            this.groupBox_algo.Controls.Add(this.comboBox5);
            this.groupBox_algo.Controls.Add(this.label12);
            this.groupBox_algo.Controls.Add(this.comboBox4);
            this.groupBox_algo.Controls.Add(this.label11);
            this.groupBox_algo.Controls.Add(this.comboBox3);
            this.groupBox_algo.Controls.Add(this.label10);
            this.groupBox_algo.Controls.Add(this.comboBox2);
            this.groupBox_algo.Controls.Add(this.label9);
            this.groupBox_algo.Controls.Add(this.comboBox1);
            this.groupBox_algo.Controls.Add(this.label_exchange);
            this.groupBox_algo.Location = new System.Drawing.Point(6, 59);
            this.groupBox_algo.Name = "groupBox_algo";
            this.groupBox_algo.Size = new System.Drawing.Size(918, 197);
            this.groupBox_algo.TabIndex = 15;
            this.groupBox_algo.TabStop = false;
            this.groupBox_algo.Text = "Algo Parameters";
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(197, 138);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(80, 20);
            this.textBox14.TabIndex = 35;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(195, 122);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(46, 13);
            this.label23.TabIndex = 34;
            this.label23.Text = "Max Qty";
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(112, 138);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(80, 20);
            this.textBox15.TabIndex = 33;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(110, 122);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(46, 13);
            this.label24.TabIndex = 32;
            this.label24.Text = "Max Qty";
            // 
            // textBox16
            // 
            this.textBox16.Location = new System.Drawing.Point(22, 138);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(80, 20);
            this.textBox16.TabIndex = 31;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(20, 122);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(46, 13);
            this.label25.TabIndex = 30;
            this.label25.Text = "Max Qty";
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(723, 89);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(80, 20);
            this.textBox11.TabIndex = 29;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(721, 73);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(46, 13);
            this.label20.TabIndex = 28;
            this.label20.Text = "Max Qty";
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(638, 89);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(80, 20);
            this.textBox12.TabIndex = 27;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(636, 73);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(46, 13);
            this.label21.TabIndex = 26;
            this.label21.Text = "Max Qty";
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(548, 89);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(80, 20);
            this.textBox13.TabIndex = 25;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(546, 73);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(46, 13);
            this.label22.TabIndex = 24;
            this.label22.Text = "Max Qty";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(461, 89);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(80, 20);
            this.textBox8.TabIndex = 23;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(459, 73);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(46, 13);
            this.label17.TabIndex = 22;
            this.label17.Text = "Max Qty";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(376, 89);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(80, 20);
            this.textBox9.TabIndex = 21;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(374, 73);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(46, 13);
            this.label18.TabIndex = 20;
            this.label18.Text = "Max Qty";
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(286, 89);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(80, 20);
            this.textBox10.TabIndex = 19;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(284, 73);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(46, 13);
            this.label19.TabIndex = 18;
            this.label19.Text = "Max Qty";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(197, 89);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(80, 20);
            this.textBox7.TabIndex = 17;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(195, 73);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(46, 13);
            this.label16.TabIndex = 16;
            this.label16.Text = "Max Qty";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(112, 89);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(80, 20);
            this.textBox6.TabIndex = 15;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(110, 73);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(50, 13);
            this.label15.TabIndex = 14;
            this.label15.Text = "Initial Qty";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(22, 89);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(80, 20);
            this.textBox5.TabIndex = 13;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(20, 73);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(46, 13);
            this.label14.TabIndex = 12;
            this.label14.Text = "Max Qty";
            // 
            // comboBox6
            // 
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Location = new System.Drawing.Point(463, 39);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(79, 21);
            this.comboBox6.TabIndex = 11;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(466, 23);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(76, 13);
            this.label13.TabIndex = 10;
            this.label13.Text = "Strategy Type ";
            // 
            // comboBox5
            // 
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(368, 39);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(79, 21);
            this.comboBox5.TabIndex = 9;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(365, 23);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 13);
            this.label12.TabIndex = 8;
            this.label12.Text = "Account";
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(282, 39);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(79, 21);
            this.comboBox4.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(279, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "Buy / Sell";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(197, 39);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(79, 21);
            this.comboBox3.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(194, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Type";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(111, 39);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(79, 21);
            this.comboBox2.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(108, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Symbol";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(23, 39);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(79, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // label_exchange
            // 
            this.label_exchange.AutoSize = true;
            this.label_exchange.Location = new System.Drawing.Point(20, 23);
            this.label_exchange.Name = "label_exchange";
            this.label_exchange.Size = new System.Drawing.Size(55, 13);
            this.label_exchange.TabIndex = 0;
            this.label_exchange.Text = "Exchange";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(387, 282);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(88, 34);
            this.button5.TabIndex = 12;
            this.button5.Text = "Save as XML";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 282);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 34);
            this.button1.TabIndex = 0;
            this.button1.Text = "Add Strategy";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button_LoadScripts);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(510, 282);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(92, 34);
            this.button4.TabIndex = 11;
            this.button4.Text = "Load Scripts";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(266, 282);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(97, 34);
            this.button3.TabIndex = 2;
            this.button3.Text = "Test Order";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // checkBox_BufferCheck
            // 
            this.checkBox_BufferCheck.AutoSize = true;
            this.checkBox_BufferCheck.Location = new System.Drawing.Point(14, 332);
            this.checkBox_BufferCheck.Name = "checkBox_BufferCheck";
            this.checkBox_BufferCheck.Size = new System.Drawing.Size(85, 17);
            this.checkBox_BufferCheck.TabIndex = 16;
            this.checkBox_BufferCheck.Text = "BufferCheck";
            this.checkBox_BufferCheck.UseVisualStyleBackColor = true;
            // 
            // TestStrategy
            // 
            this.ClientSize = new System.Drawing.Size(968, 418);
            this.Controls.Add(this.groupBox1);
            this.Name = "TestStrategy";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox_algo.ResumeLayout(false);
            this.groupBox_algo.PerformLayout();
            this.ResumeLayout(false);

        }

        private void button_LoadScripts(object sender, EventArgs e)
        {

            try
            {


                //Load Buffer Xml 
                MainModule.dtWatch = LoadDsXML();

                int Rowcount = MainModule.dtWatch.Rows.Count;

                MainModule.iMaximumScripts = MainModule.dtWatch.Rows.Count;
                                                            
                //MainModule.GetBasketform();
                
               
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
                        MainModule.objMarketWatch[j].aType = Int32.Parse(row["atype"].ToString());
                        MainModule.objMarketWatch[j].dDPRHigh = Convert.ToDouble(row["dDPRHigh"].ToString());
                        MainModule.objMarketWatch[j].dDPRLow = Convert.ToDouble(row["dDPRLow"].ToString());
                        MainModule.objMarketWatch[j].dAsk = 0;
                        MainModule.objMarketWatch[j].dBid = 0;
                        MainModule.objMarketWatch[j].dLTP = 0;
                        MainModule.objMarketWatch[j].iMLot = 1000;
                        MainModule.objMarketWatch[j].d_stgtype = Convert.ToInt32(row["Stgtype"].ToString());
                        MainModule.objMarketWatch[j].d_marketvwap = 1;
                        MainModule.objMarketWatch[j].vwapvalue = 0;
                        MainModule.objMarketWatch[j]._Buy = Convert.ToInt32(row["_Buy"].ToString());
                        MainModule.objMarketWatch[j]._Sell = Convert.ToInt32(row["_Sell"].ToString()); 
                        MainModule.objMarketWatch[j].iMaxQty = Convert.ToInt32(row["iMaxQty"].ToString());
                        MainModule.objMarketWatch[j].i_initqty = Convert.ToInt32(row["i_initqty"].ToString());
                        MainModule.objMarketWatch[j].i_multiplier = Convert.ToDouble(row["i_multiplier"].ToString());
                        MainModule.objMarketWatch[j].increment = Convert.ToDouble(row["increment"].ToString());
                        MainModule.objMarketWatch[j].dTickSize = Convert.ToDouble(row["dTickSize"].ToString());
                        MainModule.objMarketWatch[j].dTTickSize = Convert.ToDouble(row["dTTickSize"].ToString());
                        
                        
                        MainModule.objMarketWatch[j].lowprice = Convert.ToDouble(row["lowprice"].ToString());
                        MainModule.objMarketWatch[j].highprice = Convert.ToDouble(row["highprice"].ToString());
                        MainModule.objMarketWatch[j].startprices = Convert.ToDouble(row["startprices"].ToString());                       

                        MainModule.objMarketWatch[j].pricefrom = 0;
                        MainModule.objMarketWatch[j].restart = 0;                        
                        MainModule.objMarketWatch[j].iSLTick = 10;
                        MainModule.objMarketWatch[j].iPTick = 20;
                        MainModule.objMarketWatch[j].iTradedQty = 1;
                        MainModule.objMarketWatch[j].iDisclosedQty = 0;
                        MainModule.objMarketWatch[j].blSL = false;
                        MainModule.objMarketWatch[j].blTSL = false;                        
                        MainModule.objMarketWatch[j].BuyQuantityTraded = Convert.ToInt32(row["BQtyTrd"].ToString()); 
                        MainModule.objMarketWatch[j].SellQuantityTraded = Convert.ToInt32(row["SQtyTrd"].ToString());
                        MainModule.objMarketWatch[j]._pstaticbuyqty = Convert.ToInt32(row["BQtyTrd"].ToString());
                        MainModule.objMarketWatch[j]._pstaticsellqty = Convert.ToInt32(row["SQtyTrd"].ToString()); 


                        MainModule.objMarketWatch[j].BuyPrice = Convert.ToDouble(row["BPriceTrd"].ToString());
                        MainModule.objMarketWatch[j]._pstaticbuyprice = Convert.ToDecimal(row["BPriceTrd"].ToString()); 
                        MainModule.objMarketWatch[j].SellPrice = Convert.ToDouble(row["SPriceTrd"].ToString());
                        MainModule.objMarketWatch[j]._pstaticsellprice = Convert.ToDecimal(row["SPriceTrd"].ToString()); 
                        MainModule.objMarketWatch[j].account = row["account"].ToString();
                        
                        MainModule.iMarketOpen = 1;
                        MainModule.objMarketWatch[j]._listorderbook = new List<StructureTestStrategies.Strategy_TestOrderbook>();
                        MainModule.objMarketWatch[j]._listpendingorderbook = new List<StructureTestStrategies.Strategy_TestOrderbook>();
                        MainModule.objMarketWatch[j]._listtradebook = new List<StructureTestStrategies.Strategy_Tradebook>();
                        MainModule.objMarketWatch[j]._listbufferbook = new List<StructureTestStrategies.StgBufferContainer>();
                        MainModule.objMarketWatch[j]._listQtycheck = new List<StructureTestStrategies.StgOrderQtyCheck>();
                       
                        MainModule.objMarketWatch[j].stop_session=0;
                        MainModule.objMarketWatch[j].send_prev_session_order=0;
                        MainModule.objMarketWatch[j].checkprevordertrade = 0;
                        MainModule.objMarketWatch[j].refvalue = Convert.ToDouble(row["refvalue"].ToString());
                        MainModule.objMarketWatch[j].placeavgpercent = Convert.ToDouble(row["placeavgpercent"].ToString());
                        MainModule.objMarketWatch[j].placeavgpercent_order = 0;
                        MainModule.objMarketWatch[j].livepercentmove = 0;
                        MainModule.objMarketWatch[j].refup = MainModule.objMarketWatch[j].refvalue;
                        
                        
                        //add pre existing or previous days net postion
                        DataRow rownet = MainModule.dtNetPosition.NewRow();

                        rownet["Token"] = Int32.Parse(row["Token"].ToString());
                        rownet["StrategyID"] = Int32.Parse(row["Strategyid"].ToString());
                        rownet["Symbol"] = row["ScripName"].ToString().Trim();
                        rownet["BuyPrice"] = Convert.ToDecimal(row["BPriceTrd"].ToString()); 
                        rownet["BuyQuantity"] = Convert.ToInt32(row["BQtyTrd"].ToString());
                        rownet["SellPrice"] = Convert.ToDecimal(row["SPriceTrd"].ToString());
                        rownet["SellQuantity"] = Convert.ToInt32(row["SQtyTrd"].ToString());


                        MainModule.dtNetPosition.Rows.Add(rownet);
                        MainModule.dtNetPosition.AcceptChanges();

                        MainModule._clsstmputilobj.strategyDictionary.Add(MainModule.objMarketWatch[j].iWatchId, MainModule.objMarketWatch[j]);

                    }
                }

                


                for (int i = 0; i < Rowcount; i++)
                {
                    Vwapstrategy.Strategy_Vwap vwapobj = new Vwapstrategy.Strategy_Vwap();

                    vwapobj._listorderbook = new List<Vwapstrategy.Strategy_TestOrderbook>();
                    vwapobj._listtradebook = new List<Vwapstrategy.Strategy_Tradebook>();
                    vwapobj._dynamicobook = new Vwapstrategy.CreatedynamicObook[MainModule.MaxoBook];

                    DataRow row = MainModule.dtWatch.Rows[i];
                    vwapobj.StrategyId = Int32.Parse(row["Strategyid"].ToString());
                    vwapobj.Scripname = row["ScripName"].ToString();
                    vwapobj.Account = "AB101";
                    vwapobj.BuySell = 1;
                    vwapobj.Exchange = 2;
                    vwapobj.OrderType = 1;
                    vwapobj.Price = 0;
                    vwapobj.Qty = 0;
                    vwapobj.Token = Int32.Parse(row["Token"].ToString());
                    vwapobj.SellQuantityTraded = 0;
                    vwapobj.BuyQuantityTraded = 0;
                    vwapobj.PreviousTradedqty = 0;
                    vwapobj.itradedBuyQty = 0;
                    vwapobj.itradedSellQty = 0;

                    StructureTestStrategies.DailyMarketWatch dmw = new StructureTestStrategies.DailyMarketWatch();
                    dmw.ScripName = row["ScripName"].ToString();
                    dmw.tokenid = Int32.Parse(row["Token"].ToString());
                    dmw.ask = 0;
                    dmw.bid = 0;
                    dmw.volume = 0;
                    dmw.watchid = Int32.Parse(row["Strategyid"].ToString());

                    //
                    DataRow row1 = MainModule.dtInstrument.NewRow();

                    row1["Token"] = Int32.Parse(row["Token"].ToString());
                    row1["StrategyID"] = Int32.Parse(row["StrategyID"].ToString());

                    MainModule.dtInstrument.Rows.Add(row1);
                    MainModule.frmdlg.AddScripMarketWatch(vwapobj.StrategyId, dmw);
                  //  MainModule._clsstmputilobj.strategyDictionary.Add(vwapobj.Token, vwapobj);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }


        private DataTable LoadStgExhaustXML()
        {
            DataSet ds = new DataSet();

            try
            {
                ds.ReadXml(@"StgExhaust.xml");
                //   MainModule.dtWatch.ReadXml(@"Strategies.xml");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            return ds.Tables[0];
        }

        private DataTable LoadDsXML()
        {
            DataSet ds = new DataSet();

            try
            {
                ds.ReadXml(@"Strategies_MOC_TBT.xml");
                //   MainModule.dtWatch.ReadXml(@"Strategies.xml");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            return ds.Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                int k = 1;

                for (; k < 200; k++)
                {
                    // MainModule.frmdlg.MyParent.Host.sendOrder(1, IHost.Exchanges.NSE, 11957, IHost.ActionType.Buy, 100, 0, 13875, IHost.OrderTypes.Normal, "AB101");
                    //  MainModule.frmdlg.label4.Text = "Order Send No:" + k.ToString();
                    try
                    {
                //        int kk = MainModule.frmdlg.MyParent.MyHost.sendOrder(k, IHost.Exchanges.NSE, 11957, IHost.ActionType.Buy, 10, 0, 13875, IHost.OrderTypes.Normal, "AB101");
                        //  MessageBox.Show(kk.ToString());

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.ToString());
                    }




                    //kk.ToString();

                }




                //  MessageBox.Show("1K Orders Sent");
            }
            catch (Exception ex)
            {

                // MainModule.frmdlg.label4.Text="Error while sending Order"+ex.ToString();
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
