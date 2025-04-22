namespace COFFEE_SHOP_APPLICATION.UserControls
{
    partial class canceOrder
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            date = new Label();
            itemstbx = new RichTextBox();
            OrderCodelbl = new Label();
            SuspendLayout();
            // 
            // date
            // 
            date.AutoSize = true;
            date.Location = new Point(259, 0);
            date.Name = "date";
            date.Size = new Size(41, 20);
            date.TabIndex = 12;
            date.Text = "Date";
            date.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // itemstbx
            // 
            itemstbx.BackColor = Color.Silver;
            itemstbx.BorderStyle = BorderStyle.None;
            itemstbx.Font = new Font("Tahoma", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            itemstbx.Location = new Point(3, 23);
            itemstbx.Name = "itemstbx";
            itemstbx.ReadOnly = true;
            itemstbx.Size = new Size(354, 52);
            itemstbx.TabIndex = 11;
            itemstbx.Text = "";
            // 
            // OrderCodelbl
            // 
            OrderCodelbl.AutoSize = true;
            OrderCodelbl.ForeColor = Color.Gray;
            OrderCodelbl.Location = new Point(0, 0);
            OrderCodelbl.Name = "OrderCodelbl";
            OrderCodelbl.Size = new Size(86, 20);
            OrderCodelbl.TabIndex = 10;
            OrderCodelbl.Text = "Order Code";
            // 
            // canceOrder
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(date);
            Controls.Add(itemstbx);
            Controls.Add(OrderCodelbl);
            Name = "canceOrder";
            Size = new Size(360, 95);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label date;
        private RichTextBox itemstbx;
        private Label OrderCodelbl;
    }
}
