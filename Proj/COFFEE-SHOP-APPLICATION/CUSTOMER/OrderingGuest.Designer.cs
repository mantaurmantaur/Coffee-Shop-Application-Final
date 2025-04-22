namespace COFFEE_SHOP_APPLICATION.CUSTOMER
{
    partial class OrderingGuest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderingGuest));
            panel1 = new Panel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            menubtnpanel = new Panel();
            label3 = new Label();
            profiletab = new Button();
            LogOut = new PictureBox();
            paymenttab = new Button();
            historytab = new Button();
            menutab = new Button();
            mainpanel = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            menubtnpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LogOut).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1314, 58);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Baskerville Old Face", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(73, 54, 40);
            label1.Location = new Point(75, 7);
            label1.Name = "label1";
            label1.Size = new Size(280, 43);
            label1.TabIndex = 1;
            label1.Text = "COFFEE SHOP";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(69, 58);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // menubtnpanel
            // 
            menubtnpanel.BackColor = Color.White;
            menubtnpanel.BorderStyle = BorderStyle.FixedSingle;
            menubtnpanel.Controls.Add(label3);
            menubtnpanel.Controls.Add(profiletab);
            menubtnpanel.Controls.Add(LogOut);
            menubtnpanel.Controls.Add(paymenttab);
            menubtnpanel.Controls.Add(historytab);
            menubtnpanel.Controls.Add(menutab);
            menubtnpanel.Location = new Point(3, 66);
            menubtnpanel.Name = "menubtnpanel";
            menubtnpanel.Size = new Size(275, 743);
            menubtnpanel.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(73, 54, 40);
            label3.Location = new Point(84, 707);
            label3.Name = "label3";
            label3.Size = new Size(103, 28);
            label3.TabIndex = 7;
            label3.Text = "Log Out";
            // 
            // profiletab
            // 
            profiletab.BackColor = Color.FromArgb(76, 100, 68);
            profiletab.Cursor = Cursors.Hand;
            profiletab.FlatStyle = FlatStyle.Flat;
            profiletab.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            profiletab.ForeColor = Color.White;
            profiletab.Image = (Image)resources.GetObject("profiletab.Image");
            profiletab.ImageAlign = ContentAlignment.MiddleLeft;
            profiletab.Location = new Point(-1, 318);
            profiletab.Name = "profiletab";
            profiletab.Padding = new Padding(25, 0, 0, 0);
            profiletab.Size = new Size(266, 75);
            profiletab.TabIndex = 4;
            profiletab.Text = "      Profile";
            profiletab.TextAlign = ContentAlignment.MiddleLeft;
            profiletab.UseVisualStyleBackColor = false;
            profiletab.Click += profiletab_Click;
            // 
            // LogOut
            // 
            LogOut.Cursor = Cursors.Hand;
            LogOut.Image = (Image)resources.GetObject("LogOut.Image");
            LogOut.Location = new Point(118, 667);
            LogOut.Name = "LogOut";
            LogOut.Size = new Size(36, 37);
            LogOut.TabIndex = 6;
            LogOut.TabStop = false;
            LogOut.Click += LogOut_Click;
            // 
            // paymenttab
            // 
            paymenttab.BackColor = Color.FromArgb(76, 100, 68);
            paymenttab.Cursor = Cursors.Hand;
            paymenttab.FlatStyle = FlatStyle.Flat;
            paymenttab.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            paymenttab.ForeColor = Color.White;
            paymenttab.Image = (Image)resources.GetObject("paymenttab.Image");
            paymenttab.ImageAlign = ContentAlignment.MiddleLeft;
            paymenttab.Location = new Point(-1, 156);
            paymenttab.Name = "paymenttab";
            paymenttab.Padding = new Padding(25, 0, 0, 0);
            paymenttab.Size = new Size(266, 75);
            paymenttab.TabIndex = 3;
            paymenttab.Text = "      Payment";
            paymenttab.TextAlign = ContentAlignment.MiddleLeft;
            paymenttab.UseVisualStyleBackColor = false;
            paymenttab.Click += paymenttab_Click;
            // 
            // historytab
            // 
            historytab.BackColor = Color.FromArgb(76, 100, 68);
            historytab.Cursor = Cursors.Hand;
            historytab.FlatStyle = FlatStyle.Flat;
            historytab.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            historytab.ForeColor = Color.White;
            historytab.Image = (Image)resources.GetObject("historytab.Image");
            historytab.ImageAlign = ContentAlignment.MiddleLeft;
            historytab.Location = new Point(-1, 237);
            historytab.Name = "historytab";
            historytab.Padding = new Padding(25, 0, 0, 0);
            historytab.Size = new Size(266, 75);
            historytab.TabIndex = 2;
            historytab.Text = "      History";
            historytab.TextAlign = ContentAlignment.MiddleLeft;
            historytab.UseVisualStyleBackColor = false;
            historytab.Click += historytab_Click;
            // 
            // menutab
            // 
            menutab.BackColor = Color.FromArgb(76, 100, 68);
            menutab.Cursor = Cursors.Hand;
            menutab.FlatStyle = FlatStyle.Flat;
            menutab.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menutab.ForeColor = Color.White;
            menutab.Image = (Image)resources.GetObject("menutab.Image");
            menutab.ImageAlign = ContentAlignment.MiddleLeft;
            menutab.Location = new Point(-1, 75);
            menutab.Name = "menutab";
            menutab.Padding = new Padding(25, 0, 0, 0);
            menutab.Size = new Size(266, 75);
            menutab.TabIndex = 1;
            menutab.Text = "      Menu";
            menutab.TextAlign = ContentAlignment.MiddleLeft;
            menutab.UseVisualStyleBackColor = false;
            menutab.Click += menutab_Click;
            // 
            // mainpanel
            // 
            mainpanel.Location = new Point(284, 66);
            mainpanel.Name = "mainpanel";
            mainpanel.Size = new Size(1033, 743);
            mainpanel.TabIndex = 2;
            // 
            // OrderingGuest
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1319, 811);
            Controls.Add(mainpanel);
            Controls.Add(menubtnpanel);
            Controls.Add(panel1);
            Name = "OrderingGuest";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += Ordering_Close;
            Load += Ordering_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            menubtnpanel.ResumeLayout(false);
            menubtnpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)LogOut).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel menubtnpanel;
        private Label label1;
        private PictureBox pictureBox1;
        private Button menutab;
        private Button profiletab;
        private Button paymenttab;
        private Button historytab;
        private Panel mainpanel;
        private Label label3;
        private PictureBox LogOut;
    }
}