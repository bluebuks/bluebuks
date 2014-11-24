using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuantX
{
     public class CustomDataGridview : DataGridView
       {
           private IContainer components;

           public CustomDataGridview()
           {
               this.InitializeComponent();
           }

           public CustomDataGridview(IContainer container)
           {
               container.Add(this);
               this.InitializeComponent();
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
               this.components = new Container();
           }

           protected override void OnPaint(PaintEventArgs e)
           {
               try
               {
                   base.OnPaint(e);
               }
               catch (Exception)
               {
                   Invalidate();
               }
           }
       }

}
