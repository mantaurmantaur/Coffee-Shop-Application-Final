namespace COFFEE_SHOP_APPLICATION.STAFFS
{
    partial class Cashier
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cashier));
            panel1 = new Panel();
            remoteOrderbtn = new Button();
            refundbutton = new Button();
            pictureBox7 = new PictureBox();
            changePass = new LinkLabel();
            awaitingpaymentsbtn = new Button();
            pendingCancellation = new Button();
            label3 = new Label();
            pictureBox2 = new PictureBox();
            label2 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            cashierPanel = new Panel();
            pictureBox4 = new PictureBox();
            kitchenPanel = new Panel();
            button1 = new Button();
            paybtn = new Button();
            panel8 = new Panel();
            label9 = new Label();
            totaltbx = new TextBox();
            panel7 = new Panel();
            label10 = new Label();
            orderDetailstbx = new RichTextBox();
            pictureBox5 = new PictureBox();
            panel5 = new Panel();
            label8 = new Label();
            paymethodtbx = new TextBox();
            pictureBox3 = new PictureBox();
            panel4 = new Panel();
            label12 = new Label();
            statustbx = new TextBox();
            pictureBox6 = new PictureBox();
            panel3 = new Panel();
            label13 = new Label();
            ordNuminput = new Label();
            modetbx = new TextBox();
            label7 = new Label();
            changePanel = new Panel();
            receiptbtn = new Button();
            donebtn = new Button();
            changebox = new TextBox();
            cashbox = new TextBox();
            refundPanel = new Panel();
            amountbox = new Label();
            label6 = new Label();
            label5 = new Label();
            confirmrc = new Button();
            confirmationPanel = new Panel();
            code = new TextBox();
            label16 = new Label();
            donebutton = new Button();
            adminName = new TextBox();
            SearchTextBox = new TextBox();
            backbtn = new PictureBox();
            paymentflp = new FlowLayoutPanel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            cashierPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            kitchenPanel.SuspendLayout();
            panel8.SuspendLayout();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            panel3.SuspendLayout();
            changePanel.SuspendLayout();
            refundPanel.SuspendLayout();
            confirmationPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)backbtn).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(remoteOrderbtn);
            panel1.Controls.Add(refundbutton);
            panel1.Controls.Add(pictureBox7);
            panel1.Controls.Add(changePass);
            panel1.Controls.Add(awaitingpaymentsbtn);
            panel1.Controls.Add(pendingCancellation);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1319, 82);
            panel1.TabIndex = 4;
            // 
            // remoteOrderbtn
            // 
            remoteOrderbtn.BackColor = Color.FromArgb(76, 100, 68);
            remoteOrderbtn.Cursor = Cursors.Hand;
            remoteOrderbtn.Font = new Font("Tahoma", 12F);
            remoteOrderbtn.ForeColor = Color.White;
            remoteOrderbtn.Location = new Point(648, 7);
            remoteOrderbtn.Name = "remoteOrderbtn";
            remoteOrderbtn.Size = new Size(139, 65);
            remoteOrderbtn.TabIndex = 15;
            remoteOrderbtn.Text = "Gcash Payment";
            remoteOrderbtn.UseVisualStyleBackColor = false;
            remoteOrderbtn.Click += remoteOrderbtn_Click;
            // 
            // refundbutton
            // 
            refundbutton.BackColor = Color.FromArgb(76, 100, 68);
            refundbutton.Cursor = Cursors.Hand;
            refundbutton.Font = new Font("Tahoma", 12F);
            refundbutton.ForeColor = Color.White;
            refundbutton.Location = new Point(945, 8);
            refundbutton.Name = "refundbutton";
            refundbutton.Size = new Size(139, 65);
            refundbutton.TabIndex = 14;
            refundbutton.Text = "Refund";
            refundbutton.UseVisualStyleBackColor = false;
            refundbutton.Click += refundbutton_Click;
            // 
            // pictureBox7
            // 
            pictureBox7.Cursor = Cursors.Hand;
            pictureBox7.Image = (Image)resources.GetObject("pictureBox7.Image");
            pictureBox7.Location = new Point(175, 51);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(33, 36);
            pictureBox7.TabIndex = 13;
            pictureBox7.TabStop = false;
            pictureBox7.Click += pictureBox7_Click;
            // 
            // changePass
            // 
            changePass.AutoSize = true;
            changePass.Cursor = Cursors.Hand;
            changePass.Location = new Point(1087, 46);
            changePass.Name = "changePass";
            changePass.Size = new Size(124, 20);
            changePass.TabIndex = 12;
            changePass.TabStop = true;
            changePass.Text = "Change Password";
            changePass.LinkClicked += changePass_LinkClicked;
            // 
            // awaitingpaymentsbtn
            // 
            awaitingpaymentsbtn.BackColor = Color.FromArgb(76, 100, 68);
            awaitingpaymentsbtn.Cursor = Cursors.Hand;
            awaitingpaymentsbtn.Font = new Font("Tahoma", 12F);
            awaitingpaymentsbtn.ForeColor = Color.White;
            awaitingpaymentsbtn.Location = new Point(503, 7);
            awaitingpaymentsbtn.Name = "awaitingpaymentsbtn";
            awaitingpaymentsbtn.Size = new Size(139, 65);
            awaitingpaymentsbtn.TabIndex = 6;
            awaitingpaymentsbtn.Text = "Awaiting Payments";
            awaitingpaymentsbtn.UseVisualStyleBackColor = false;
            awaitingpaymentsbtn.Click += awaitingpaymentsbtn_Click;
            // 
            // pendingCancellation
            // 
            pendingCancellation.BackColor = Color.FromArgb(76, 100, 68);
            pendingCancellation.Cursor = Cursors.Hand;
            pendingCancellation.Font = new Font("Tahoma", 12F);
            pendingCancellation.ForeColor = Color.White;
            pendingCancellation.Location = new Point(800, 8);
            pendingCancellation.Name = "pendingCancellation";
            pendingCancellation.Size = new Size(139, 65);
            pendingCancellation.TabIndex = 2;
            pendingCancellation.Text = "Cancel";
            pendingCancellation.UseVisualStyleBackColor = false;
            pendingCancellation.Click += pendingCancellation_Click;
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
            // pictureBox2
            // 
            pictureBox2.Cursor = Cursors.Hand;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(1242, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(36, 37);
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(84, 51);
            label2.Name = "label2";
            label2.Size = new Size(65, 21);
            label2.TabIndex = 3;
            label2.Text = "Cashier";
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
            // cashierPanel
            // 
            cashierPanel.BackColor = Color.FromArgb(238, 230, 223);
            cashierPanel.BorderStyle = BorderStyle.FixedSingle;
            cashierPanel.Controls.Add(pictureBox4);
            cashierPanel.Controls.Add(kitchenPanel);
            cashierPanel.Controls.Add(label7);
            cashierPanel.Controls.Add(changePanel);
            cashierPanel.Controls.Add(refundPanel);
            cashierPanel.Controls.Add(confirmationPanel);
            cashierPanel.Controls.Add(SearchTextBox);
            cashierPanel.Controls.Add(backbtn);
            cashierPanel.Controls.Add(paymentflp);
            cashierPanel.Location = new Point(1, 88);
            cashierPanel.Name = "cashierPanel";
            cashierPanel.Size = new Size(1318, 723);
            cashierPanel.TabIndex = 5;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.White;
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(737, 50);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(33, 27);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 8;
            pictureBox4.TabStop = false;
            // 
            // kitchenPanel
            // 
            kitchenPanel.BackColor = Color.FromArgb(73, 54, 40);
            kitchenPanel.BorderStyle = BorderStyle.FixedSingle;
            kitchenPanel.Controls.Add(button1);
            kitchenPanel.Controls.Add(paybtn);
            kitchenPanel.Controls.Add(panel8);
            kitchenPanel.Controls.Add(panel7);
            kitchenPanel.Controls.Add(panel5);
            kitchenPanel.Controls.Add(panel4);
            kitchenPanel.Controls.Add(panel3);
            kitchenPanel.Location = new Point(3, 7);
            kitchenPanel.Name = "kitchenPanel";
            kitchenPanel.Size = new Size(440, 723);
            kitchenPanel.TabIndex = 10;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(76, 100, 68);
            button1.Cursor = Cursors.Hand;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(31, 664);
            button1.Name = "button1";
            button1.Size = new Size(157, 38);
            button1.TabIndex = 7;
            button1.Tag = "order";
            button1.Text = "Cancel";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // paybtn
            // 
            paybtn.BackColor = Color.FromArgb(76, 100, 68);
            paybtn.Cursor = Cursors.Hand;
            paybtn.FlatStyle = FlatStyle.Flat;
            paybtn.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            paybtn.ForeColor = Color.White;
            paybtn.Location = new Point(241, 664);
            paybtn.Name = "paybtn";
            paybtn.Size = new Size(157, 38);
            paybtn.TabIndex = 6;
            paybtn.Tag = "order";
            paybtn.Text = "Pay";
            paybtn.UseVisualStyleBackColor = false;
            paybtn.Click += paybtn_Click;
            // 
            // panel8
            // 
            panel8.BackColor = Color.FromArgb(238, 230, 223);
            panel8.Controls.Add(label9);
            panel8.Controls.Add(totaltbx);
            panel8.ForeColor = Color.Black;
            panel8.Location = new Point(3, 600);
            panel8.Name = "panel8";
            panel8.Size = new Size(432, 43);
            panel8.TabIndex = 3;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            label9.Location = new Point(13, 10);
            label9.Name = "label9";
            label9.Size = new Size(67, 24);
            label9.TabIndex = 2;
            label9.Text = "Total:";
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
            panel7.Controls.Add(label10);
            panel7.Controls.Add(orderDetailstbx);
            panel7.Controls.Add(pictureBox5);
            panel7.ForeColor = Color.Black;
            panel7.Location = new Point(3, 173);
            panel7.Name = "panel7";
            panel7.Size = new Size(432, 421);
            panel7.TabIndex = 5;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            label10.Location = new Point(42, 10);
            label10.Name = "label10";
            label10.Size = new Size(143, 24);
            label10.TabIndex = 4;
            label10.Text = "Order Details";
            // 
            // orderDetailstbx
            // 
            orderDetailstbx.BorderStyle = BorderStyle.None;
            orderDetailstbx.Cursor = Cursors.Hand;
            orderDetailstbx.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            orderDetailstbx.Location = new Point(13, 46);
            orderDetailstbx.Name = "orderDetailstbx";
            orderDetailstbx.ReadOnly = true;
            orderDetailstbx.Size = new Size(401, 360);
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
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(238, 230, 223);
            panel5.Controls.Add(label8);
            panel5.Controls.Add(paymethodtbx);
            panel5.Controls.Add(pictureBox3);
            panel5.ForeColor = Color.Black;
            panel5.Location = new Point(3, 124);
            panel5.Name = "panel5";
            panel5.Size = new Size(432, 43);
            panel5.TabIndex = 3;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            label8.Location = new Point(42, 10);
            label8.Name = "label8";
            label8.Size = new Size(99, 24);
            label8.TabIndex = 4;
            label8.Text = "Payment";
            // 
            // paymethodtbx
            // 
            paymethodtbx.BackColor = Color.FromArgb(238, 230, 223);
            paymethodtbx.BorderStyle = BorderStyle.None;
            paymethodtbx.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            paymethodtbx.Location = new Point(238, 12);
            paymethodtbx.Name = "paymethodtbx";
            paymethodtbx.Size = new Size(191, 25);
            paymethodtbx.TabIndex = 4;
            paymethodtbx.TextAlign = HorizontalAlignment.Right;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(11, 16);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(25, 18);
            pictureBox3.TabIndex = 2;
            pictureBox3.TabStop = false;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(238, 230, 223);
            panel4.Controls.Add(label12);
            panel4.Controls.Add(statustbx);
            panel4.Controls.Add(pictureBox6);
            panel4.ForeColor = Color.Black;
            panel4.Location = new Point(3, 75);
            panel4.Name = "panel4";
            panel4.Size = new Size(432, 43);
            panel4.TabIndex = 2;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            label12.Location = new Point(42, 10);
            label12.Name = "label12";
            label12.Size = new Size(74, 24);
            label12.TabIndex = 0;
            label12.Text = "Status";
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
            // pictureBox6
            // 
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(11, 16);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(25, 18);
            pictureBox6.TabIndex = 2;
            pictureBox6.TabStop = false;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(73, 54, 40);
            panel3.Controls.Add(label13);
            panel3.Controls.Add(ordNuminput);
            panel3.Controls.Add(modetbx);
            panel3.ForeColor = Color.White;
            panel3.Location = new Point(3, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(432, 66);
            panel3.TabIndex = 1;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Tahoma", 13.8F, FontStyle.Bold);
            label13.Location = new Point(11, 15);
            label13.Name = "label13";
            label13.Size = new Size(97, 28);
            label13.TabIndex = 4;
            label13.Text = "Order#";
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
            modetbx.ReadOnly = true;
            modetbx.Size = new Size(164, 28);
            modetbx.TabIndex = 2;
            modetbx.TextAlign = HorizontalAlignment.Right;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Tahoma", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(73, 54, 40);
            label7.Location = new Point(461, 7);
            label7.Name = "label7";
            label7.Size = new Size(148, 36);
            label7.TabIndex = 6;
            label7.Text = "Payment";
            // 
            // changePanel
            // 
            changePanel.BackColor = Color.FromArgb(73, 54, 40);
            changePanel.Controls.Add(receiptbtn);
            changePanel.Controls.Add(donebtn);
            changePanel.Controls.Add(changebox);
            changePanel.Controls.Add(cashbox);
            changePanel.Location = new Point(784, 38);
            changePanel.Name = "changePanel";
            changePanel.Size = new Size(529, 308);
            changePanel.TabIndex = 12;
            // 
            // receiptbtn
            // 
            receiptbtn.BackColor = Color.FromArgb(76, 100, 68);
            receiptbtn.ForeColor = Color.White;
            receiptbtn.Location = new Point(60, 239);
            receiptbtn.Name = "receiptbtn";
            receiptbtn.Size = new Size(94, 47);
            receiptbtn.TabIndex = 7;
            receiptbtn.Text = "Receipt";
            receiptbtn.UseVisualStyleBackColor = false;
            receiptbtn.Click += receiptbtn_Click;
            // 
            // donebtn
            // 
            donebtn.BackColor = Color.FromArgb(73, 54, 40);
            donebtn.ForeColor = Color.White;
            donebtn.Location = new Point(378, 239);
            donebtn.Name = "donebtn";
            donebtn.Size = new Size(94, 47);
            donebtn.TabIndex = 6;
            donebtn.Text = "CONFIRM";
            donebtn.UseVisualStyleBackColor = false;
            donebtn.Click += donebtn_Click;
            // 
            // changebox
            // 
            changebox.Font = new Font("Segoe UI", 16.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            changebox.Location = new Point(60, 129);
            changebox.Multiline = true;
            changebox.Name = "changebox";
            changebox.PlaceholderText = "Change";
            changebox.Size = new Size(412, 57);
            changebox.TabIndex = 5;
            // 
            // cashbox
            // 
            cashbox.Font = new Font("Segoe UI", 16.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cashbox.Location = new Point(60, 42);
            cashbox.Multiline = true;
            cashbox.Name = "cashbox";
            cashbox.PlaceholderText = "Enter Cash";
            cashbox.Size = new Size(412, 57);
            cashbox.TabIndex = 4;
            // 
            // refundPanel
            // 
            refundPanel.BackColor = Color.FromArgb(76, 100, 68);
            refundPanel.Controls.Add(amountbox);
            refundPanel.Controls.Add(label6);
            refundPanel.Controls.Add(label5);
            refundPanel.Controls.Add(confirmrc);
            refundPanel.Location = new Point(551, 227);
            refundPanel.Name = "refundPanel";
            refundPanel.Size = new Size(389, 275);
            refundPanel.TabIndex = 13;
            // 
            // amountbox
            // 
            amountbox.AutoSize = true;
            amountbox.BackColor = Color.Transparent;
            amountbox.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            amountbox.ForeColor = Color.White;
            amountbox.Location = new Point(151, 122);
            amountbox.Name = "amountbox";
            amountbox.Size = new Size(55, 24);
            amountbox.TabIndex = 17;
            amountbox.Text = "0.00";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(49, 122);
            label6.Name = "label6";
            label6.Size = new Size(96, 24);
            label6.TabIndex = 16;
            label6.Text = "Amount:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Tahoma", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(31, 56);
            label5.Name = "label5";
            label5.Size = new Size(291, 34);
            label5.TabIndex = 15;
            label5.Text = "Refund (Cash Only)";
            // 
            // confirmrc
            // 
            confirmrc.BackColor = Color.FromArgb(73, 54, 40);
            confirmrc.ForeColor = Color.White;
            confirmrc.Location = new Point(274, 229);
            confirmrc.Name = "confirmrc";
            confirmrc.Size = new Size(94, 29);
            confirmrc.TabIndex = 6;
            confirmrc.Text = "CONFIRM";
            confirmrc.UseVisualStyleBackColor = false;
            confirmrc.Click += confirmrc_Click;
            // 
            // confirmationPanel
            // 
            confirmationPanel.BackColor = Color.FromArgb(76, 100, 68);
            confirmationPanel.Controls.Add(code);
            confirmationPanel.Controls.Add(label16);
            confirmationPanel.Controls.Add(donebutton);
            confirmationPanel.Controls.Add(adminName);
            confirmationPanel.Location = new Point(927, 458);
            confirmationPanel.Name = "confirmationPanel";
            confirmationPanel.Size = new Size(365, 223);
            confirmationPanel.TabIndex = 18;
            // 
            // code
            // 
            code.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            code.Location = new Point(19, 109);
            code.Multiline = true;
            code.Name = "code";
            code.PlaceholderText = "Code";
            code.Size = new Size(321, 47);
            code.TabIndex = 18;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.BackColor = Color.Transparent;
            label16.Font = new Font("Tahoma", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label16.ForeColor = Color.White;
            label16.Location = new Point(19, 12);
            label16.Name = "label16";
            label16.Size = new Size(199, 34);
            label16.TabIndex = 14;
            label16.Text = "Confirmation";
            // 
            // donebutton
            // 
            donebutton.BackColor = Color.FromArgb(73, 54, 40);
            donebutton.ForeColor = Color.White;
            donebutton.Location = new Point(256, 180);
            donebutton.Name = "donebutton";
            donebutton.Size = new Size(94, 29);
            donebutton.TabIndex = 6;
            donebutton.Text = "APPROVE";
            donebutton.UseVisualStyleBackColor = false;
            donebutton.Click += donebutton_Click;
            // 
            // adminName
            // 
            adminName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            adminName.Location = new Point(19, 49);
            adminName.Multiline = true;
            adminName.Name = "adminName";
            adminName.PlaceholderText = "Name";
            adminName.Size = new Size(321, 47);
            adminName.TabIndex = 4;
            // 
            // SearchTextBox
            // 
            SearchTextBox.Location = new Point(461, 50);
            SearchTextBox.Name = "SearchTextBox";
            SearchTextBox.PlaceholderText = "Search Order";
            SearchTextBox.Size = new Size(309, 27);
            SearchTextBox.TabIndex = 19;
            SearchTextBox.TextChanged += textBox1_TextChanged;
            // 
            // backbtn
            // 
            backbtn.Image = (Image)resources.GetObject("backbtn.Image");
            backbtn.Location = new Point(615, 11);
            backbtn.Name = "backbtn";
            backbtn.Size = new Size(33, 36);
            backbtn.TabIndex = 11;
            backbtn.TabStop = false;
            backbtn.Click += backbtn_Click;
            // 
            // paymentflp
            // 
            paymentflp.AutoScroll = true;
            paymentflp.BackColor = Color.FromArgb(73, 54, 40);
            paymentflp.Location = new Point(456, 83);
            paymentflp.Name = "paymentflp";
            paymentflp.Size = new Size(844, 627);
            paymentflp.TabIndex = 20;
            // 
            // Cashier
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1319, 811);
            Controls.Add(panel1);
            Controls.Add(cashierPanel);
            Name = "Cashier";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += form_Close;
            Load += pay_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            cashierPanel.ResumeLayout(false);
            cashierPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            kitchenPanel.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            changePanel.ResumeLayout(false);
            changePanel.PerformLayout();
            refundPanel.ResumeLayout(false);
            refundPanel.PerformLayout();
            confirmationPanel.ResumeLayout(false);
            confirmationPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)backbtn).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label3;
        private PictureBox pictureBox2;
        private Label label2;
        private Label label1;
        private PictureBox pictureBox1;
        private Panel cashierPanel;
        private Label label7;
        private Panel kitchenPanel;
        private Button paybtn;
        private Panel panel8;
        private Label label9;
        private TextBox totaltbx;
        private Panel panel7;
        private Label label10;
        private RichTextBox orderDetailstbx;
        private PictureBox pictureBox5;
        private Panel panel5;
        private Label label8;
        private TextBox paymethodtbx;
        private PictureBox pictureBox3;
        private Panel panel4;
        private Label label12;
        private TextBox statustbx;
        private PictureBox pictureBox6;
        private Panel panel3;
        private Label label13;
        private Label ordNuminput;
        private TextBox modetbx;
        private Panel changePanel;
        private Button receiptbtn;
        private Button donebtn;
        private TextBox changebox;
        private TextBox cashbox;
        private Button button1;
        private Panel refundPanel;
        private Button confirmrc;
        private Label label5;
        private Label amountbox;
        private Label label6;
        private PictureBox backbtn;
        private Panel confirmationPanel;
        private TextBox code;
        private Label label16;
        private Button donebutton;
        private TextBox adminName;
        private Button pendingCancellation;
        private Button awaitingpaymentsbtn;
        private LinkLabel changePass;
        private TextBox SearchTextBox;
        private PictureBox pictureBox4;
        private PictureBox pictureBox7;
        private Button refundbutton;
        private FlowLayoutPanel paymentflp;
        private Button remoteOrderbtn;
    }
}