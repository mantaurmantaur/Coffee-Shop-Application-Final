namespace COFFEE_SHOP_APPLICATION.ADMIN
{
    partial class MainMenu
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            panel1 = new Panel();
            comboBox1 = new ComboBox();
            staffbtn = new Button();
            label3 = new Label();
            customersbtn = new Button();
            logOut = new PictureBox();
            button2 = new Button();
            label2 = new Label();
            button1 = new Button();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            mainPanel = new Panel();
            fadeTimer = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logOut).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(staffbtn);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(customersbtn);
            panel1.Controls.Add(logOut);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1319, 82);
            panel1.TabIndex = 1;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Kitchen", "Cashier" });
            comboBox1.Location = new Point(1186, 46);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(128, 28);
            comboBox1.TabIndex = 0;
            comboBox1.Text = "Go To";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // staffbtn
            // 
            staffbtn.BackColor = Color.FromArgb(76, 100, 68);
            staffbtn.Cursor = Cursors.Hand;
            staffbtn.Font = new Font("Tahoma", 12F);
            staffbtn.ForeColor = Color.White;
            staffbtn.Location = new Point(986, 11);
            staffbtn.Name = "staffbtn";
            staffbtn.Size = new Size(178, 65);
            staffbtn.TabIndex = 3;
            staffbtn.Text = "Staffs";
            staffbtn.UseVisualStyleBackColor = false;
            staffbtn.Click += staffsbtn_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(1244, 11);
            label3.Name = "label3";
            label3.Size = new Size(65, 20);
            label3.TabIndex = 7;
            label3.Text = "Log Out";
            // 
            // customersbtn
            // 
            customersbtn.BackColor = Color.FromArgb(76, 100, 68);
            customersbtn.Cursor = Cursors.Hand;
            customersbtn.Font = new Font("Tahoma", 12F);
            customersbtn.ForeColor = Color.White;
            customersbtn.Location = new Point(779, 11);
            customersbtn.Name = "customersbtn";
            customersbtn.Size = new Size(178, 65);
            customersbtn.TabIndex = 2;
            customersbtn.Text = "Customers";
            customersbtn.UseVisualStyleBackColor = false;
            customersbtn.Click += customersbtn_Click;
            // 
            // logOut
            // 
            logOut.Cursor = Cursors.Hand;
            logOut.Image = (Image)resources.GetObject("logOut.Image");
            logOut.Location = new Point(1202, 8);
            logOut.Name = "logOut";
            logOut.Size = new Size(36, 37);
            logOut.TabIndex = 6;
            logOut.TabStop = false;
            logOut.Click += logOut_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(76, 100, 68);
            button2.Cursor = Cursors.Hand;
            button2.Font = new Font("Tahoma", 12F);
            button2.ForeColor = Color.White;
            button2.Location = new Point(572, 12);
            button2.Name = "button2";
            button2.Size = new Size(178, 65);
            button2.TabIndex = 1;
            button2.Text = "Products";
            button2.UseVisualStyleBackColor = false;
            button2.Click += productsbtn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(86, 51);
            label2.Name = "label2";
            label2.Size = new Size(143, 21);
            label2.TabIndex = 2;
            label2.Text = "ADMINISTRATOR";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(76, 100, 68);
            button1.Cursor = Cursors.Hand;
            button1.Font = new Font("Tahoma", 12F);
            button1.ForeColor = Color.White;
            button1.Location = new Point(371, 11);
            button1.Name = "button1";
            button1.Size = new Size(178, 65);
            button1.TabIndex = 0;
            button1.Text = "Dashboard";
            button1.UseVisualStyleBackColor = false;
            button1.Click += dashboardbtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Baskerville Old Face", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(73, 54, 40);
            label1.Location = new Point(75, 8);
            label1.Name = "label1";
            label1.Size = new Size(280, 43);
            label1.TabIndex = 1;
            label1.Text = "COFFEE SHOP";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 8);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(69, 58);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // mainPanel
            // 
            mainPanel.BorderStyle = BorderStyle.FixedSingle;
            mainPanel.Location = new Point(1, 88);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(1318, 721);
            mainPanel.TabIndex = 2;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1319, 811);
            Controls.Add(mainPanel);
            Controls.Add(panel1);
            MaximizeBox = false;
            Name = "MainMenu";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += MainMenu_Close;
            Load += MainMenu_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)logOut).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private PictureBox pictureBox1;
        private Label label2;
        private Panel mainPanel;
        private Label label3;
        private PictureBox logOut;
        private Button button1;
        private Button staffbtn;
        private Button customersbtn;
        private Button button2;
        private System.Windows.Forms.Timer fadeTimer;
        private ComboBox comboBox1;
    }
}