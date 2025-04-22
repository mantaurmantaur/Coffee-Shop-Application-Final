namespace COFFEE_SHOP_APPLICATION.UserControls
{
    partial class ongoingorders
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
            cancelbtn = new Button();
            totallbl = new Label();
            label3 = new Label();
            date = new Label();
            SuspendLayout();
            // 
            // OrderCodelbl
            // 
            OrderCodelbl.AutoSize = true;
            OrderCodelbl.ForeColor = Color.Gray;
            OrderCodelbl.Location = new Point(3, 9);
            OrderCodelbl.Name = "OrderCodelbl";
            OrderCodelbl.Size = new Size(86, 20);
            OrderCodelbl.TabIndex = 1;
            OrderCodelbl.Text = "Order Code";
            // 
            // itemstbx
            // 
            itemstbx.BackColor = Color.Silver;
            itemstbx.BorderStyle = BorderStyle.None;
            itemstbx.Font = new Font("Tahoma", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            itemstbx.Location = new Point(13, 32);
            itemstbx.Name = "itemstbx";
            itemstbx.ReadOnly = true;
            itemstbx.Size = new Size(219, 88);
            itemstbx.TabIndex = 2;
            itemstbx.Text = "";
            // 
            // cancelbtn
            // 
            cancelbtn.BackColor = Color.Brown;
            cancelbtn.Cursor = Cursors.Hand;
            cancelbtn.FlatStyle = FlatStyle.Flat;
            cancelbtn.ForeColor = Color.White;
            cancelbtn.Location = new Point(250, 59);
            cancelbtn.Name = "cancelbtn";
            cancelbtn.Size = new Size(94, 29);
            cancelbtn.TabIndex = 9;
            cancelbtn.Text = "Cancel";
            cancelbtn.UseVisualStyleBackColor = false;
            cancelbtn.Click += cancelbtn_Click;
            // 
            // totallbl
            // 
            totallbl.AutoSize = true;
            totallbl.Location = new Point(280, 103);
            totallbl.Name = "totallbl";
            totallbl.Size = new Size(80, 20);
            totallbl.TabIndex = 8;
            totallbl.Text = "butangana";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(238, 103);
            label3.Name = "label3";
            label3.Size = new Size(45, 20);
            label3.TabIndex = 7;
            label3.Text = "Total:";
            // 
            // date
            // 
            date.AutoSize = true;
            date.Location = new Point(278, 9);
            date.Name = "date";
            date.Size = new Size(41, 20);
            date.TabIndex = 6;
            date.Text = "Date";
            date.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ongoingorders
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(cancelbtn);
            Controls.Add(totallbl);
            Controls.Add(label3);
            Controls.Add(date);
            Controls.Add(itemstbx);
            Controls.Add(OrderCodelbl);
            Name = "ongoingorders";
            Size = new Size(360, 150);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label OrderCodelbl;
        private RichTextBox itemstbx;
        private Button cancelbtn;
        private Label totallbl;
        private Label label3;
        private Label date;
    }
}
