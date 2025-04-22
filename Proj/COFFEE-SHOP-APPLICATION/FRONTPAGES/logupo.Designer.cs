namespace COFFEE_SHOP_APPLICATION.FRONTPAGES
{
    partial class logupo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(logupo));
            label1 = new Label();
            loginPanel = new Panel();
            createAccountlbl = new Label();
            showPassbtn = new CheckBox();
            forgotPasslbl = new Label();
            loginGuest = new Button();
            logInbtn = new Button();
            passwordtbx = new TextBox();
            usernametbx = new TextBox();
            pictureBox1 = new PictureBox();
            verificationPanel = new Panel();
            verificationbutton = new Button();
            vercodetbx = new TextBox();
            label4 = new Label();
            signUppanel = new Panel();
            logInlabel = new Label();
            confirmtbx = new TextBox();
            registerbutton = new Button();
            passtbx = new TextBox();
            suntbx = new TextBox();
            emailtbx = new TextBox();
            label2 = new Label();
            changePasspanel = new Panel();
            backbtn = new PictureBox();
            confirmPassTBX = new TextBox();
            changepassbtn = new Button();
            cpasstbx = new TextBox();
            sendCodebtn = new Button();
            cusernametbx = new TextBox();
            cemailtbx = new TextBox();
            label3 = new Label();
            loginPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            verificationPanel.SuspendLayout();
            signUppanel.SuspendLayout();
            changePasspanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)backbtn).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(24, 171);
            label1.Name = "label1";
            label1.Size = new Size(111, 41);
            label1.TabIndex = 1;
            label1.Text = "Login";
            // 
            // loginPanel
            // 
            loginPanel.BackColor = Color.White;
            loginPanel.Controls.Add(createAccountlbl);
            loginPanel.Controls.Add(showPassbtn);
            loginPanel.Controls.Add(forgotPasslbl);
            loginPanel.Controls.Add(loginGuest);
            loginPanel.Controls.Add(logInbtn);
            loginPanel.Controls.Add(passwordtbx);
            loginPanel.Controls.Add(usernametbx);
            loginPanel.Controls.Add(pictureBox1);
            loginPanel.Controls.Add(label1);
            loginPanel.Location = new Point(288, 65);
            loginPanel.Name = "loginPanel";
            loginPanel.Size = new Size(404, 554);
            loginPanel.TabIndex = 2;
            // 
            // createAccountlbl
            // 
            createAccountlbl.AutoSize = true;
            createAccountlbl.Cursor = Cursors.Hand;
            createAccountlbl.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            createAccountlbl.Location = new Point(142, 510);
            createAccountlbl.Name = "createAccountlbl";
            createAccountlbl.Size = new Size(110, 20);
            createAccountlbl.TabIndex = 22;
            createAccountlbl.Text = "Create Account";
            createAccountlbl.Click += createAccountlbl_Click;
            // 
            // showPassbtn
            // 
            showPassbtn.AutoSize = true;
            showPassbtn.Location = new Point(35, 354);
            showPassbtn.Name = "showPassbtn";
            showPassbtn.Size = new Size(132, 24);
            showPassbtn.TabIndex = 21;
            showPassbtn.Text = "Show Password";
            showPassbtn.UseVisualStyleBackColor = true;
            showPassbtn.CheckedChanged += showPassbtn_CheckedChanged;
            // 
            // forgotPasslbl
            // 
            forgotPasslbl.AutoSize = true;
            forgotPasslbl.Cursor = Cursors.Hand;
            forgotPasslbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            forgotPasslbl.Location = new Point(242, 354);
            forgotPasslbl.Name = "forgotPasslbl";
            forgotPasslbl.Size = new Size(127, 20);
            forgotPasslbl.TabIndex = 20;
            forgotPasslbl.Text = "Forgot Password";
            forgotPasslbl.Click += forgotPasslbl_Click;
            // 
            // loginGuest
            // 
            loginGuest.BackColor = Color.FromArgb(76, 100, 68);
            loginGuest.Cursor = Cursors.Hand;
            loginGuest.FlatStyle = FlatStyle.Flat;
            loginGuest.ForeColor = Color.White;
            loginGuest.Location = new Point(35, 456);
            loginGuest.Name = "loginGuest";
            loginGuest.Size = new Size(325, 42);
            loginGuest.TabIndex = 18;
            loginGuest.Text = "Login as Guest";
            loginGuest.UseVisualStyleBackColor = false;
            loginGuest.Click += login;
            // 
            // logInbtn
            // 
            logInbtn.BackColor = Color.FromArgb(76, 100, 68);
            logInbtn.Cursor = Cursors.Hand;
            logInbtn.FlatStyle = FlatStyle.Flat;
            logInbtn.ForeColor = Color.White;
            logInbtn.Location = new Point(35, 408);
            logInbtn.Name = "logInbtn";
            logInbtn.Size = new Size(325, 42);
            logInbtn.TabIndex = 17;
            logInbtn.Text = "Login";
            logInbtn.UseVisualStyleBackColor = false;
            logInbtn.Click += logInbtn_Click;
            // 
            // passwordtbx
            // 
            passwordtbx.Cursor = Cursors.IBeam;
            passwordtbx.Location = new Point(35, 303);
            passwordtbx.Name = "passwordtbx";
            passwordtbx.PlaceholderText = "Password";
            passwordtbx.Size = new Size(325, 27);
            passwordtbx.TabIndex = 16;
            passwordtbx.UseSystemPasswordChar = true;
            // 
            // usernametbx
            // 
            usernametbx.Cursor = Cursors.IBeam;
            usernametbx.Location = new Point(35, 242);
            usernametbx.Name = "usernametbx";
            usernametbx.PlaceholderText = "Username";
            usernametbx.Size = new Size(325, 27);
            usernametbx.TabIndex = 15;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, -27);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(404, 183);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // verificationPanel
            // 
            verificationPanel.BorderStyle = BorderStyle.FixedSingle;
            verificationPanel.Controls.Add(verificationbutton);
            verificationPanel.Controls.Add(vercodetbx);
            verificationPanel.Controls.Add(label4);
            verificationPanel.Location = new Point(708, 270);
            verificationPanel.Name = "verificationPanel";
            verificationPanel.Size = new Size(360, 220);
            verificationPanel.TabIndex = 11;
            // 
            // verificationbutton
            // 
            verificationbutton.BackColor = Color.FromArgb(76, 100, 68);
            verificationbutton.Cursor = Cursors.Hand;
            verificationbutton.FlatStyle = FlatStyle.Flat;
            verificationbutton.ForeColor = Color.White;
            verificationbutton.Location = new Point(35, 161);
            verificationbutton.Name = "verificationbutton";
            verificationbutton.Size = new Size(94, 42);
            verificationbutton.TabIndex = 18;
            verificationbutton.Text = "Verify";
            verificationbutton.UseVisualStyleBackColor = false;
            verificationbutton.Click += verifiybtn_Click;
            // 
            // vercodetbx
            // 
            vercodetbx.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            vercodetbx.Location = new Point(35, 76);
            vercodetbx.Multiline = true;
            vercodetbx.Name = "vercodetbx";
            vercodetbx.Size = new Size(283, 54);
            vercodetbx.TabIndex = 13;
            vercodetbx.TextAlign = HorizontalAlignment.Center;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(15, 11);
            label4.Name = "label4";
            label4.Size = new Size(211, 28);
            label4.TabIndex = 12;
            label4.Text = "Verification Code";
            // 
            // signUppanel
            // 
            signUppanel.BackColor = Color.White;
            signUppanel.Controls.Add(logInlabel);
            signUppanel.Controls.Add(confirmtbx);
            signUppanel.Controls.Add(registerbutton);
            signUppanel.Controls.Add(passtbx);
            signUppanel.Controls.Add(suntbx);
            signUppanel.Controls.Add(emailtbx);
            signUppanel.Controls.Add(label2);
            signUppanel.Location = new Point(288, 65);
            signUppanel.Name = "signUppanel";
            signUppanel.Size = new Size(404, 554);
            signUppanel.TabIndex = 7;
            // 
            // logInlabel
            // 
            logInlabel.AutoSize = true;
            logInlabel.Cursor = Cursors.Hand;
            logInlabel.Location = new Point(171, 501);
            logInlabel.Name = "logInlabel";
            logInlabel.Size = new Size(50, 20);
            logInlabel.TabIndex = 22;
            logInlabel.Text = "Log In";
            logInlabel.Click += loginlbl_Click;
            // 
            // confirmtbx
            // 
            confirmtbx.Cursor = Cursors.IBeam;
            confirmtbx.Location = new Point(37, 336);
            confirmtbx.Name = "confirmtbx";
            confirmtbx.PlaceholderText = "Confirm Password";
            confirmtbx.Size = new Size(323, 27);
            confirmtbx.TabIndex = 21;
            // 
            // registerbutton
            // 
            registerbutton.BackColor = Color.FromArgb(76, 100, 68);
            registerbutton.Cursor = Cursors.Hand;
            registerbutton.FlatStyle = FlatStyle.Flat;
            registerbutton.ForeColor = Color.White;
            registerbutton.Location = new Point(37, 447);
            registerbutton.Name = "registerbutton";
            registerbutton.Size = new Size(323, 42);
            registerbutton.TabIndex = 18;
            registerbutton.Text = "Register";
            registerbutton.UseVisualStyleBackColor = false;
            registerbutton.Click += Signuptbtn_Click;
            // 
            // passtbx
            // 
            passtbx.Cursor = Cursors.IBeam;
            passtbx.Location = new Point(35, 283);
            passtbx.Name = "passtbx";
            passtbx.PlaceholderText = "Password";
            passtbx.Size = new Size(323, 27);
            passtbx.TabIndex = 20;
            // 
            // suntbx
            // 
            suntbx.Cursor = Cursors.IBeam;
            suntbx.Location = new Point(35, 232);
            suntbx.Name = "suntbx";
            suntbx.PlaceholderText = "Username";
            suntbx.Size = new Size(323, 27);
            suntbx.TabIndex = 19;
            // 
            // emailtbx
            // 
            emailtbx.Cursor = Cursors.IBeam;
            emailtbx.Location = new Point(35, 185);
            emailtbx.Name = "emailtbx";
            emailtbx.PlaceholderText = "Email";
            emailtbx.Size = new Size(323, 27);
            emailtbx.TabIndex = 18;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(35, 60);
            label2.Name = "label2";
            label2.Size = new Size(149, 41);
            label2.TabIndex = 1;
            label2.Text = "Sign Up";
            // 
            // changePasspanel
            // 
            changePasspanel.BackColor = Color.White;
            changePasspanel.Controls.Add(backbtn);
            changePasspanel.Controls.Add(confirmPassTBX);
            changePasspanel.Controls.Add(changepassbtn);
            changePasspanel.Controls.Add(cpasstbx);
            changePasspanel.Controls.Add(sendCodebtn);
            changePasspanel.Controls.Add(cusernametbx);
            changePasspanel.Controls.Add(cemailtbx);
            changePasspanel.Controls.Add(label3);
            changePasspanel.Location = new Point(108, 85);
            changePasspanel.Name = "changePasspanel";
            changePasspanel.Size = new Size(404, 510);
            changePasspanel.TabIndex = 10;
            // 
            // backbtn
            // 
            backbtn.Image = (Image)resources.GetObject("backbtn.Image");
            backbtn.Location = new Point(23, 18);
            backbtn.Name = "backbtn";
            backbtn.Size = new Size(33, 36);
            backbtn.TabIndex = 10;
            backbtn.TabStop = false;
            backbtn.Click += backbtn_Click;
            // 
            // confirmPassTBX
            // 
            confirmPassTBX.Cursor = Cursors.IBeam;
            confirmPassTBX.Location = new Point(41, 378);
            confirmPassTBX.Name = "confirmPassTBX";
            confirmPassTBX.PlaceholderText = "Confirm Password";
            confirmPassTBX.Size = new Size(323, 27);
            confirmPassTBX.TabIndex = 17;
            // 
            // changepassbtn
            // 
            changepassbtn.BackColor = Color.FromArgb(76, 100, 68);
            changepassbtn.Cursor = Cursors.Hand;
            changepassbtn.FlatStyle = FlatStyle.Flat;
            changepassbtn.ForeColor = Color.White;
            changepassbtn.Location = new Point(41, 427);
            changepassbtn.Name = "changepassbtn";
            changepassbtn.Size = new Size(323, 42);
            changepassbtn.TabIndex = 16;
            changepassbtn.Text = "Change Password";
            changepassbtn.UseVisualStyleBackColor = false;
            changepassbtn.Click += changepassbtn_Click;
            // 
            // cpasstbx
            // 
            cpasstbx.Cursor = Cursors.IBeam;
            cpasstbx.Location = new Point(41, 332);
            cpasstbx.Name = "cpasstbx";
            cpasstbx.PlaceholderText = "Password";
            cpasstbx.Size = new Size(323, 27);
            cpasstbx.TabIndex = 15;
            // 
            // sendCodebtn
            // 
            sendCodebtn.BackColor = Color.FromArgb(76, 100, 68);
            sendCodebtn.Cursor = Cursors.Hand;
            sendCodebtn.FlatStyle = FlatStyle.Flat;
            sendCodebtn.ForeColor = Color.White;
            sendCodebtn.Location = new Point(266, 245);
            sendCodebtn.Name = "sendCodebtn";
            sendCodebtn.Size = new Size(94, 42);
            sendCodebtn.TabIndex = 13;
            sendCodebtn.Text = "Send Code";
            sendCodebtn.UseVisualStyleBackColor = false;
            sendCodebtn.Click += sendCodebtn_Click;
            // 
            // cusernametbx
            // 
            cusernametbx.Cursor = Cursors.IBeam;
            cusernametbx.Location = new Point(37, 195);
            cusernametbx.Name = "cusernametbx";
            cusernametbx.PlaceholderText = "Username";
            cusernametbx.Size = new Size(323, 27);
            cusernametbx.TabIndex = 12;
            // 
            // cemailtbx
            // 
            cemailtbx.Cursor = Cursors.IBeam;
            cemailtbx.Location = new Point(37, 144);
            cemailtbx.Name = "cemailtbx";
            cemailtbx.PlaceholderText = "Email";
            cemailtbx.Size = new Size(323, 27);
            cemailtbx.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(37, 73);
            label3.Name = "label3";
            label3.Size = new Size(216, 28);
            label3.TabIndex = 1;
            label3.Text = "Change password";
            // 
            // logupo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(238, 230, 223);
            ClientSize = new Size(1001, 690);
            Controls.Add(changePasspanel);
            Controls.Add(verificationPanel);
            Controls.Add(signUppanel);
            Controls.Add(loginPanel);
            MaximizeBox = false;
            Name = "logupo";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += logupo_Close;
            Load += front_Load;
            loginPanel.ResumeLayout(false);
            loginPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            verificationPanel.ResumeLayout(false);
            verificationPanel.PerformLayout();
            signUppanel.ResumeLayout(false);
            signUppanel.PerformLayout();
            changePasspanel.ResumeLayout(false);
            changePasspanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)backbtn).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private Panel loginPanel;
        private Panel signUppanel;
        private Label label2;
        private PictureBox pictureBox1;
        private Panel changePasspanel;
        private Label label3;
        private Panel verificationPanel;
        private Label label4;
        private TextBox vercodetbx;
        private TextBox passwordtbx;
        private TextBox usernametbx;
        private Button logInbtn;
        private Button loginGuest;
        private CheckBox showPassbtn;
        private Label forgotPasslbl;
        private Label createAccountlbl;
        private TextBox cusernametbx;
        private TextBox cemailtbx;
        private Button sendCodebtn;
        private TextBox cpasstbx;
        private Button changepassbtn;
        private TextBox confirmPassTBX;
        private PictureBox backbtn;
        private TextBox passtbx;
        private TextBox suntbx;
        private TextBox emailtbx;
        private Label logInlabel;
        private TextBox confirmtbx;
        private Button registerbutton;
        private Button verificationbutton;
    }
}