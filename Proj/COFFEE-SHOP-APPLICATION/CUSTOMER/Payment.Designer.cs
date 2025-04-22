namespace COFFEE_SHOP_APPLICATION.CUSTOMER
{
    partial class PaymentGuest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentGuest));
            gcashPanel = new Panel();
            label2 = new Label();
            button2 = new Button();
            donebtn = new Button();
            refbox = new TextBox();
            pictureBox1 = new PictureBox();
            panel3 = new Panel();
            TakeOut = new RadioButton();
            dineIn = new RadioButton();
            totalpanel = new Panel();
            subtotaltbx = new TextBox();
            label4 = new Label();
            redeemedpanel = new Panel();
            discountcbx = new ComboBox();
            label5 = new Label();
            orderDetailstbx = new RichTextBox();
            panel1 = new Panel();
            ordrnumtbx = new TextBox();
            label3 = new Label();
            panel2 = new Panel();
            label6 = new Label();
            totalbox = new TextBox();
            counterbtn = new RadioButton();
            gcashbtn = new RadioButton();
            label1 = new Label();
            paybtn = new Button();
            orderPanel = new Panel();
            gcashPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            totalpanel.SuspendLayout();
            redeemedpanel.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            orderPanel.SuspendLayout();
            SuspendLayout();
            // 
            // gcashPanel
            // 
            gcashPanel.BackColor = Color.FromArgb(76, 100, 68);
            gcashPanel.Controls.Add(label2);
            gcashPanel.Controls.Add(button2);
            gcashPanel.Controls.Add(donebtn);
            gcashPanel.Controls.Add(refbox);
            gcashPanel.Controls.Add(pictureBox1);
            gcashPanel.Location = new Point(2, 82);
            gcashPanel.Name = "gcashPanel";
            gcashPanel.Size = new Size(381, 624);
            gcashPanel.TabIndex = 15;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 22.2F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(116, 21);
            label2.Name = "label2";
            label2.Size = new Size(133, 45);
            label2.TabIndex = 19;
            label2.Text = "Gcash";
            // 
            // button2
            // 
            button2.BackColor = Color.White;
            button2.Cursor = Cursors.Hand;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(45, 550);
            button2.Name = "button2";
            button2.Size = new Size(125, 38);
            button2.TabIndex = 7;
            button2.Text = "BACK";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // donebtn
            // 
            donebtn.BackColor = SystemColors.ActiveCaption;
            donebtn.Cursor = Cursors.Hand;
            donebtn.FlatStyle = FlatStyle.Flat;
            donebtn.Location = new Point(226, 550);
            donebtn.Name = "donebtn";
            donebtn.Size = new Size(125, 38);
            donebtn.TabIndex = 6;
            donebtn.Text = "DONE";
            donebtn.UseVisualStyleBackColor = false;
            donebtn.Click += donebtn_Click;
            // 
            // refbox
            // 
            refbox.Cursor = Cursors.IBeam;
            refbox.Location = new Point(76, 507);
            refbox.Name = "refbox";
            refbox.PlaceholderText = "Enter reference number";
            refbox.Size = new Size(236, 27);
            refbox.TabIndex = 5;
            refbox.TextAlign = HorizontalAlignment.Center;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(36, 114);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(315, 366);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            panel3.Controls.Add(TakeOut);
            panel3.Controls.Add(dineIn);
            panel3.Location = new Point(24, 353);
            panel3.Name = "panel3";
            panel3.Size = new Size(512, 31);
            panel3.TabIndex = 17;
            // 
            // TakeOut
            // 
            TakeOut.AutoSize = true;
            TakeOut.Font = new Font("Tahoma", 10.8F, FontStyle.Bold);
            TakeOut.ForeColor = Color.White;
            TakeOut.Location = new Point(284, 3);
            TakeOut.Name = "TakeOut";
            TakeOut.Size = new Size(113, 26);
            TakeOut.TabIndex = 20;
            TakeOut.TabStop = true;
            TakeOut.Text = "Take Out";
            TakeOut.UseVisualStyleBackColor = true;
            // 
            // dineIn
            // 
            dineIn.AutoSize = true;
            dineIn.Font = new Font("Tahoma", 10.8F, FontStyle.Bold);
            dineIn.ForeColor = Color.White;
            dineIn.Location = new Point(112, 3);
            dineIn.Name = "dineIn";
            dineIn.Size = new Size(99, 26);
            dineIn.TabIndex = 19;
            dineIn.TabStop = true;
            dineIn.Text = "Dine In";
            dineIn.UseVisualStyleBackColor = true;
            // 
            // totalpanel
            // 
            totalpanel.BackColor = Color.White;
            totalpanel.Controls.Add(subtotaltbx);
            totalpanel.Controls.Add(label4);
            totalpanel.Location = new Point(24, 405);
            totalpanel.Name = "totalpanel";
            totalpanel.Size = new Size(522, 38);
            totalpanel.TabIndex = 9;
            // 
            // subtotaltbx
            // 
            subtotaltbx.BackColor = Color.White;
            subtotaltbx.BorderStyle = BorderStyle.None;
            subtotaltbx.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            subtotaltbx.Location = new Point(384, 9);
            subtotaltbx.Name = "subtotaltbx";
            subtotaltbx.ReadOnly = true;
            subtotaltbx.Size = new Size(138, 25);
            subtotaltbx.TabIndex = 13;
            subtotaltbx.TextAlign = HorizontalAlignment.Right;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(0, 64, 0);
            label4.Location = new Point(3, 9);
            label4.Name = "label4";
            label4.Size = new Size(95, 24);
            label4.TabIndex = 17;
            label4.Text = "Subtotal";
            // 
            // redeemedpanel
            // 
            redeemedpanel.BackColor = Color.White;
            redeemedpanel.Controls.Add(discountcbx);
            redeemedpanel.Controls.Add(label5);
            redeemedpanel.Location = new Point(24, 449);
            redeemedpanel.Name = "redeemedpanel";
            redeemedpanel.Size = new Size(522, 38);
            redeemedpanel.TabIndex = 10;
            // 
            // discountcbx
            // 
            discountcbx.FormattingEnabled = true;
            discountcbx.Location = new Point(331, 7);
            discountcbx.Name = "discountcbx";
            discountcbx.Size = new Size(188, 28);
            discountcbx.TabIndex = 13;
            discountcbx.SelectedIndexChanged += discountcbx_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(0, 64, 0);
            label5.Location = new Point(7, 6);
            label5.Name = "label5";
            label5.Size = new Size(213, 24);
            label5.TabIndex = 18;
            label5.Text = "Redeemed Rewards";
            // 
            // orderDetailstbx
            // 
            orderDetailstbx.BackColor = Color.White;
            orderDetailstbx.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            orderDetailstbx.Location = new Point(24, 100);
            orderDetailstbx.Name = "orderDetailstbx";
            orderDetailstbx.ReadOnly = true;
            orderDetailstbx.Size = new Size(522, 231);
            orderDetailstbx.TabIndex = 13;
            orderDetailstbx.Text = "";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(ordrnumtbx);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(24, 56);
            panel1.Name = "panel1";
            panel1.Size = new Size(522, 38);
            panel1.TabIndex = 12;
            // 
            // ordrnumtbx
            // 
            ordrnumtbx.BackColor = Color.White;
            ordrnumtbx.BorderStyle = BorderStyle.None;
            ordrnumtbx.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            ordrnumtbx.Location = new Point(165, 5);
            ordrnumtbx.Name = "ordrnumtbx";
            ordrnumtbx.ReadOnly = true;
            ordrnumtbx.Size = new Size(128, 25);
            ordrnumtbx.TabIndex = 12;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(0, 64, 0);
            label3.Location = new Point(7, 6);
            label3.Name = "label3";
            label3.Size = new Size(155, 24);
            label3.TabIndex = 16;
            label3.Text = "Order Number";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(label6);
            panel2.Controls.Add(totalbox);
            panel2.Location = new Point(24, 493);
            panel2.Name = "panel2";
            panel2.Size = new Size(522, 38);
            panel2.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(0, 64, 0);
            label6.Location = new Point(7, 9);
            label6.Name = "label6";
            label6.Size = new Size(60, 24);
            label6.TabIndex = 19;
            label6.Text = "Total";
            // 
            // totalbox
            // 
            totalbox.BackColor = Color.White;
            totalbox.BorderStyle = BorderStyle.None;
            totalbox.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            totalbox.Location = new Point(314, 9);
            totalbox.Name = "totalbox";
            totalbox.ReadOnly = true;
            totalbox.Size = new Size(208, 25);
            totalbox.TabIndex = 13;
            totalbox.TextAlign = HorizontalAlignment.Right;
            // 
            // counterbtn
            // 
            counterbtn.AutoSize = true;
            counterbtn.Font = new Font("Tahoma", 10.8F, FontStyle.Bold);
            counterbtn.ForeColor = Color.White;
            counterbtn.Location = new Point(136, 561);
            counterbtn.Name = "counterbtn";
            counterbtn.Size = new Size(104, 26);
            counterbtn.TabIndex = 16;
            counterbtn.TabStop = true;
            counterbtn.Text = "Counter";
            counterbtn.UseVisualStyleBackColor = true;
            // 
            // gcashbtn
            // 
            gcashbtn.AutoSize = true;
            gcashbtn.Font = new Font("Tahoma", 10.8F, FontStyle.Bold);
            gcashbtn.ForeColor = Color.White;
            gcashbtn.Location = new Point(308, 561);
            gcashbtn.Name = "gcashbtn";
            gcashbtn.Size = new Size(86, 26);
            gcashbtn.TabIndex = 18;
            gcashbtn.TabStop = true;
            gcashbtn.Text = "Gcash";
            gcashbtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 22.2F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(189, 0);
            label1.Name = "label1";
            label1.Size = new Size(190, 45);
            label1.TabIndex = 16;
            label1.Text = "My Order";
            // 
            // paybtn
            // 
            paybtn.BackColor = Color.FromArgb(238, 230, 223);
            paybtn.Cursor = Cursors.Hand;
            paybtn.Font = new Font("Microsoft Sans Serif", 8.25F);
            paybtn.ForeColor = Color.FromArgb(76, 100, 68);
            paybtn.Location = new Point(56, 630);
            paybtn.Name = "paybtn";
            paybtn.Size = new Size(440, 38);
            paybtn.TabIndex = 20;
            paybtn.Text = "Pay";
            paybtn.UseVisualStyleBackColor = false;
            paybtn.Click += paybtn_Click;
            // 
            // orderPanel
            // 
            orderPanel.BackColor = Color.FromArgb(76, 100, 68);
            orderPanel.Controls.Add(paybtn);
            orderPanel.Controls.Add(label1);
            orderPanel.Controls.Add(gcashbtn);
            orderPanel.Controls.Add(counterbtn);
            orderPanel.Controls.Add(panel2);
            orderPanel.Controls.Add(panel1);
            orderPanel.Controls.Add(orderDetailstbx);
            orderPanel.Controls.Add(redeemedpanel);
            orderPanel.Controls.Add(totalpanel);
            orderPanel.Controls.Add(panel3);
            orderPanel.Location = new Point(220, 12);
            orderPanel.Name = "orderPanel";
            orderPanel.Size = new Size(569, 694);
            orderPanel.TabIndex = 1;
            // 
            // PaymentGuest
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(238, 230, 223);
            ClientSize = new Size(1034, 717);
            Controls.Add(gcashPanel);
            Controls.Add(orderPanel);
            MaximizeBox = false;
            Name = "PaymentGuest";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Load += payment_Load;
            gcashPanel.ResumeLayout(false);
            gcashPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            totalpanel.ResumeLayout(false);
            totalpanel.PerformLayout();
            redeemedpanel.ResumeLayout(false);
            redeemedpanel.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            orderPanel.ResumeLayout(false);
            orderPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel gcashPanel;
        private Label label2;
        private Button button2;
        private Button donebtn;
        private TextBox refbox;
        private PictureBox pictureBox1;
        private Panel panel3;
        private RadioButton TakeOut;
        private RadioButton dineIn;
        private Panel totalpanel;
        private TextBox subtotaltbx;
        private Label label4;
        private Panel redeemedpanel;
        private ComboBox discountcbx;
        private Label label5;
        private RichTextBox orderDetailstbx;
        private Panel panel1;
        private TextBox ordrnumtbx;
        private Label label3;
        private Panel panel2;
        private Label label6;
        private TextBox totalbox;
        private RadioButton counterbtn;
        private RadioButton gcashbtn;
        private Label label1;
        private Button paybtn;
        private Panel orderPanel;
    }
}