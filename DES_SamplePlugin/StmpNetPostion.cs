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
    public class StmpNetPostion : Form
    {
        public DataGridView dataGridView1;
        private IContainer components;
    
        public StmpNetPostion()
        {
            InitializeComponent();
            //MainModule.dtNetPosition.Clear();
            this.dataGridView1.DataSource = MainModule.dtNetPosition;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Enabled = false;
            this.dataGridView1.Location = new System.Drawing.Point(2, 1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(979, 544);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            // 
            // StmpNetPostion
            // 
            this.ClientSize = new System.Drawing.Size(981, 548);
            this.Controls.Add(this.dataGridView1);
            this.Name = "StmpNetPostion";
            this.Text = "Net Positions";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StmpNetPostion_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StmpNetPostion_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void StmpNetPostion_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.Hide();

            //e.Cancel = true;
        }

        private void StmpNetPostion_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainModule.frmNetposition = null;
        }



    }
}
