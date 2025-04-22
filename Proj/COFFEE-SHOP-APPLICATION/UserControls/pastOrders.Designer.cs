namespace COFFEE_SHOP_APPLICATION.UserControls
{
    partial class pastOrders
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
            OrderCodelbl = new Label();
            itemstbx = new RichTextBox();
            date = new Label();
            label3 = new Label();
            totallbl = new Label();
            reorderbtn = new Button();
            SuspendLayout();
            // 
            // OrderCodelbl
            // 
            OrderCodelbl.AutoSize = true;
            OrderCodelbl.ForeColor = Color.Gray;
            OrderCodelbl.Location = new Point(3, 11);
            OrderCodelbl.Name = "OrderCodelbl";
            OrderCodelbl.Size = new Size(86, 20);
            OrderCodelbl.TabIndex = 0;
            OrderCodelbl.Text = "Order Code";
            // 
            // itemstbx
            // 
            itemstbx.BackColor = Color.Silver;
            itemstbx.BorderStyle = BorderStyle.None;
            itemstbx.Font = new Font("Tahoma", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            itemstbx.Location = new Point(15, 34);
            itemstbx.Name = "itemstbx";
            itemstbx.ReadOnly = true;
            itemstbx.Size = new Size(402, 88);
            itemstbx.TabIndex = 1;
            itemstbx.Text = "";
            // 
            // date
            // 
            date.AutoSize = true;
            date.Location = new Point(474, 16);
            date.Name = "date";
            date.Size = new Size(41, 20);
            date.TabIndex = 2;
            date.Text = "Date";
            date.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(423, 107);
            label3.Name = "label3";
            label3.Size = new Size(45, 20);
            label3.TabIndex = 3;
            label3.Text = "Total:";
            // 
            // totallbl
            // 
            totallbl.AutoSize = true;
            totallbl.Location = new Point(474, 107);
            totallbl.Name = "totallbl";
            totallbl.Size = new Size(80, 20);
            totallbl.TabIndex = 4;
            totallbl.Text = "butangana";
            // 
            // reorderbtn
            // 
            reorderbtn.BackColor = Color.FromArgb(76, 100, 68);
            reorderbtn.Cursor = Cursors.Hand;
            reorderbtn.FlatStyle = FlatStyle.Flat;
            reorderbtn.ForeColor = Color.White;
            reorderbtn.Location = new Point(448, 61);
            reorderbtn.Name = "reorderbtn";
            reorderbtn.Size = new Size(94, 29);
            reorderbtn.TabIndex = 5;
            reorderbtn.Text = "Reorder";
            reorderbtn.UseVisualStyleBackColor = false;
            reorderbtn.Click += btnReorder_Click;
            // 
            // pastOrders
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(reorderbtn);
            Controls.Add(totallbl);
            Controls.Add(label3);
            Controls.Add(date);
            Controls.Add(itemstbx);
            Controls.Add(OrderCodelbl);
            Name = "pastOrders";
            Size = new Size(580, 148);
            Load += pastOrders_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label OrderCodelbl;
        private RichTextBox itemstbx;
        private Label date;
        private Label label3;
        private Label totallbl;
        private Button reorderbtn;
    }
}
