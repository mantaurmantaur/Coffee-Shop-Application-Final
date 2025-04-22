namespace COFFEE_SHOP_APPLICATION.CUSTOMER
{
    partial class History
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pastordersflp = new FlowLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            ongoingflp = new FlowLayoutPanel();
            tobeCancelled = new FlowLayoutPanel();
            label3 = new Label();
            SuspendLayout();
            // 
            // pastordersflp
            // 
            pastordersflp.AutoScroll = true;
            pastordersflp.BackColor = Color.FromArgb(76, 100, 68);
            pastordersflp.Location = new Point(2, 48);
            pastordersflp.Name = "pastordersflp";
            pastordersflp.Padding = new Padding(0, 10, 0, 10);
            pastordersflp.Size = new Size(603, 636);
            pastordersflp.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(2, 9);
            label1.Name = "label1";
            label1.Size = new Size(190, 36);
            label1.TabIndex = 0;
            label1.Text = "Past Orders";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(632, 9);
            label2.Name = "label2";
            label2.Size = new Size(252, 36);
            label2.TabIndex = 2;
            label2.Text = "Ongoing Orders";
            // 
            // ongoingflp
            // 
            ongoingflp.AutoScroll = true;
            ongoingflp.BackColor = Color.FromArgb(73, 54, 40);
            ongoingflp.Location = new Point(611, 48);
            ongoingflp.Name = "ongoingflp";
            ongoingflp.Size = new Size(392, 636);
            ongoingflp.TabIndex = 3;
            // 
            // tobeCancelled
            // 
            tobeCancelled.AutoScroll = true;
            tobeCancelled.BackColor = Color.FromArgb(73, 54, 40);
            tobeCancelled.Location = new Point(611, 510);
            tobeCancelled.Name = "tobeCancelled";
            tobeCancelled.Size = new Size(392, 174);
            tobeCancelled.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(611, 471);
            label3.Name = "label3";
            label3.Size = new Size(249, 36);
            label3.TabIndex = 5;
            label3.Text = "To be cancelled";
            // 
            // History
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1015, 696);
            Controls.Add(tobeCancelled);
            Controls.Add(ongoingflp);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pastordersflp);
            Controls.Add(label3);
            Name = "History";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += History_Close;
            Load += History_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private RichTextBox richTextBox1;
        private FlowLayoutPanel pastordersflp;
        private Label label1;
        private Label label2;
        private FlowLayoutPanel ongoingflp;
        private FlowLayoutPanel tobeCancelled;
        private Label label3;
    }
}