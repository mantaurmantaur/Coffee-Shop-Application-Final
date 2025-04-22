namespace COFFEE_SHOP_APPLICATION.STAFFS
{
    partial class Kitchen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Kitchen));
            panel1 = new Panel();
            backbtn = new PictureBox();
            changePass = new LinkLabel();
            button2 = new Button();
            button1 = new Button();
            showallorders = new Button();
            label3 = new Label();
            logOut = new PictureBox();
            label2 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            kitchenPanel = new Panel();
            servebtn = new Button();
            panel8 = new Panel();
            label8 = new Label();
            totaltbx = new TextBox();
            panel7 = new Panel();
            label7 = new Label();
            orderDetailstbx = new RichTextBox();
            pictureBox5 = new PictureBox();
            panel4 = new Panel();
            label4 = new Label();
            statustbx = new TextBox();
            pictureBox2 = new PictureBox();
            panel3 = new Panel();
            label9 = new Label();
            ordNuminput = new Label();
            modetbx = new TextBox();
            orderNumbersflp = new FlowLayoutPanel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)backbtn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)logOut).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            kitchenPanel.SuspendLayout();
            panel8.SuspendLayout();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(backbtn);
            panel1.Controls.Add(changePass);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(showallorders);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(logOut);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1319, 82);
            panel1.TabIndex = 2;
            // 
            // backbtn
            // 
            backbtn.Cursor = Cursors.Hand;
            backbtn.Image = (Image)resources.GetObject("backbtn.Image");
            backbtn.Location = new Point(165, 51);
            backbtn.Name = "backbtn";
            backbtn.Size = new Size(33, 36);
            backbtn.TabIndex = 12;
            backbtn.TabStop = false;
            backbtn.Click += backbtn_Click;
            // 
            // changePass
            // 
            changePass.AutoSize = true;
            changePass.Cursor = Cursors.Hand;
            changePass.Location = new Point(1086, 39);
            changePass.Name = "changePass";
            changePass.Size = new Size(124, 20);
            changePass.TabIndex = 11;
            changePass.TabStop = true;
            changePass.Text = "Change Password";
            changePass.LinkClicked += changePass_LinkClicked;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(76, 100, 68);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            button2.ForeColor = Color.White;
            button2.Location = new Point(909, 28);
            button2.Name = "button2";
            button2.Size = new Size(157, 38);
            button2.TabIndex = 9;
            button2.Tag = "order";
            button2.Text = "Take Out";
            button2.UseVisualStyleBackColor = false;
            button2.Click += takeoutbtn_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(76, 100, 68);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(725, 28);
            button1.Name = "button1";
            button1.Size = new Size(157, 38);
            button1.TabIndex = 8;
            button1.Tag = "order";
            button1.Text = "Dine In";
            button1.UseVisualStyleBackColor = false;
            button1.Click += dineInbtn_Click;
            // 
            // showallorders
            // 
            showallorders.BackColor = Color.FromArgb(76, 100, 68);
            showallorders.FlatStyle = FlatStyle.Flat;
            showallorders.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            showallorders.ForeColor = Color.White;
            showallorders.Location = new Point(533, 28);
            showallorders.Name = "showallorders";
            showallorders.Size = new Size(157, 38);
            showallorders.TabIndex = 7;
            showallorders.Tag = "order";
            showallorders.Text = "Show All";
            showallorders.UseVisualStyleBackColor = false;
            showallorders.Click += showallorders_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1231, 52);
            label3.Name = "label3";
            label3.Size = new Size(62, 20);
            label3.TabIndex = 5;
            label3.Text = "Log Out";
            // 
            // logOut
            // 
            logOut.Cursor = Cursors.Hand;
            logOut.Image = (Image)resources.GetObject("logOut.Image");
            logOut.Location = new Point(1242, 12);
            logOut.Name = "logOut";
            logOut.Size = new Size(36, 37);
            logOut.TabIndex = 4;
            logOut.TabStop = false;
            logOut.Click += logOut_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(84, 51);
            label2.Name = "label2";
            label2.Size = new Size(65, 21);
            label2.TabIndex = 3;
            label2.Text = "Kitchen";
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
            // kitchenPanel
            // 
            kitchenPanel.BackColor = Color.FromArgb(73, 54, 40);
            kitchenPanel.BorderStyle = BorderStyle.FixedSingle;
            kitchenPanel.Controls.Add(servebtn);
            kitchenPanel.Controls.Add(panel8);
            kitchenPanel.Controls.Add(panel7);
            kitchenPanel.Controls.Add(panel4);
            kitchenPanel.Controls.Add(panel3);
            kitchenPanel.Location = new Point(1, 88);
            kitchenPanel.Name = "kitchenPanel";
            kitchenPanel.Size = new Size(440, 723);
            kitchenPanel.TabIndex = 3;
            // 
            // servebtn
            // 
            servebtn.BackColor = Color.FromArgb(76, 100, 68);
            servebtn.Cursor = Cursors.Hand;
            servebtn.FlatStyle = FlatStyle.Flat;
            servebtn.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            servebtn.ForeColor = Color.White;
            servebtn.Location = new Point(125, 672);
            servebtn.Name = "servebtn";
            servebtn.Size = new Size(157, 38);
            servebtn.TabIndex = 6;
            servebtn.Tag = "order";
            servebtn.Text = "Served";
            servebtn.UseVisualStyleBackColor = false;
            servebtn.Click += servebutton_Click;
            // 
            // panel8
            // 
            panel8.BackColor = Color.FromArgb(238, 230, 223);
            panel8.Controls.Add(label8);
            panel8.Controls.Add(totaltbx);
            panel8.ForeColor = Color.Black;
            panel8.Location = new Point(3, 600);
            panel8.Name = "panel8";
            panel8.Size = new Size(432, 43);
            panel8.TabIndex = 3;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            label8.Location = new Point(13, 10);
            label8.Name = "label8";
            label8.Size = new Size(67, 24);
            label8.TabIndex = 2;
            label8.Text = "Total:";
            // 
            // totaltbx
            // 
            totaltbx.BackColor = Color.FromArgb(238, 230, 223);
            totaltbx.BorderStyle = BorderStyle.None;
            totaltbx.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            totaltbx.Location = new Point(304, 10);
            totaltbx.Name = "totaltbx";
            totaltbx.Size = new Size(125, 25);
            totaltbx.TabIndex = 1;
            // 
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(238, 230, 223);
            panel7.Controls.Add(label7);
            panel7.Controls.Add(orderDetailstbx);
            panel7.Controls.Add(pictureBox5);
            panel7.ForeColor = Color.Black;
            panel7.Location = new Point(3, 124);
            panel7.Name = "panel7";
            panel7.Size = new Size(432, 470);
            panel7.TabIndex = 5;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            label7.Location = new Point(42, 10);
            label7.Name = "label7";
            label7.Size = new Size(143, 24);
            label7.TabIndex = 4;
            label7.Text = "Order Details";
            // 
            // orderDetailstbx
            // 
            orderDetailstbx.BorderStyle = BorderStyle.None;
            orderDetailstbx.Cursor = Cursors.Hand;
            orderDetailstbx.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            orderDetailstbx.Location = new Point(13, 46);
            orderDetailstbx.Name = "orderDetailstbx";
            orderDetailstbx.ReadOnly = true;
            orderDetailstbx.Size = new Size(401, 396);
            orderDetailstbx.TabIndex = 3;
            orderDetailstbx.Text = "";
            // 
            // pictureBox5
            // 
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(11, 16);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(25, 18);
            pictureBox5.TabIndex = 2;
            pictureBox5.TabStop = false;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(238, 230, 223);
            panel4.Controls.Add(label4);
            panel4.Controls.Add(statustbx);
            panel4.Controls.Add(pictureBox2);
            panel4.ForeColor = Color.Black;
            panel4.Location = new Point(3, 75);
            panel4.Name = "panel4";
            panel4.Size = new Size(432, 43);
            panel4.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            label4.Location = new Point(42, 10);
            label4.Name = "label4";
            label4.Size = new Size(74, 24);
            label4.TabIndex = 0;
            label4.Text = "Status";
            // 
            // statustbx
            // 
            statustbx.BackColor = Color.FromArgb(238, 230, 223);
            statustbx.BorderStyle = BorderStyle.None;
            statustbx.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            statustbx.Location = new Point(238, 9);
            statustbx.Name = "statustbx";
            statustbx.Size = new Size(191, 25);
            statustbx.TabIndex = 3;
            statustbx.TextAlign = HorizontalAlignment.Right;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(11, 16);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(25, 18);
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(73, 54, 40);
            panel3.Controls.Add(label9);
            panel3.Controls.Add(ordNuminput);
            panel3.Controls.Add(modetbx);
            panel3.ForeColor = Color.White;
            panel3.Location = new Point(3, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(432, 66);
            panel3.TabIndex = 1;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Tahoma", 13.8F, FontStyle.Bold);
            label9.Location = new Point(11, 15);
            label9.Name = "label9";
            label9.Size = new Size(97, 28);
            label9.TabIndex = 4;
            label9.Text = "Order#";
            // 
            // ordNuminput
            // 
            ordNuminput.AutoSize = true;
            ordNuminput.Font = new Font("Tahoma", 13.8F, FontStyle.Bold);
            ordNuminput.Location = new Point(108, 15);
            ordNuminput.Name = "ordNuminput";
            ordNuminput.Size = new Size(102, 28);
            ordNuminput.TabIndex = 4;
            ordNuminput.Text = "123456";
            // 
            // modetbx
            // 
            modetbx.BackColor = Color.FromArgb(73, 54, 40);
            modetbx.BorderStyle = BorderStyle.None;
            modetbx.Font = new Font("Tahoma", 13.8F, FontStyle.Bold);
            modetbx.ForeColor = Color.Yellow;
            modetbx.Location = new Point(250, 20);
            modetbx.Name = "modetbx";
            modetbx.Size = new Size(164, 28);
            modetbx.TabIndex = 2;
            modetbx.TextAlign = HorizontalAlignment.Right;
            // 
            // orderNumbersflp
            // 
            orderNumbersflp.AutoScroll = true;
            orderNumbersflp.BackColor = Color.FromArgb(73, 54, 40);
            orderNumbersflp.BorderStyle = BorderStyle.FixedSingle;
            orderNumbersflp.Location = new Point(457, 90);
            orderNumbersflp.Name = "orderNumbersflp";
            orderNumbersflp.Size = new Size(850, 709);
            orderNumbersflp.TabIndex = 4;
            // 
            // Kitchen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1319, 811);
            Controls.Add(orderNumbersflp);
            Controls.Add(kitchenPanel);
            Controls.Add(panel1);
            MaximizeBox = false;
            Name = "Kitchen";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += form_Close;
            Load += kitchen_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)backbtn).EndInit();
            ((System.ComponentModel.ISupportInitialize)logOut).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            kitchenPanel.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private PictureBox pictureBox1;
        private Label label2;
        private Panel kitchenPanel;
        private PictureBox logOut;
        private Label label3;
        private Panel panel3;
        private Panel panel4;
        private Panel panel7;
        private PictureBox pictureBox5;
        private PictureBox pictureBox2;
        private Panel panel8;
        private FlowLayoutPanel orderNumbersflp;
        private TextBox statustbx;
        private RichTextBox orderDetailstbx;
        private TextBox totaltbx;
        private Button servebtn;
        private TextBox modetbx;
        private Label label8;
        private Label label7;
        private Label label4;
        private Label ordNuminput;
        private Button showallorders;
        private Button button2;
        private Button button1;
        private Label label9;
        private LinkLabel changePass;
        private PictureBox backbtn;
    }
}