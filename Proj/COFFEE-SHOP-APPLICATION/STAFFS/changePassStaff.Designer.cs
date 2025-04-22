namespace COFFEE_SHOP_APPLICATION.STAFFS
{
    partial class changePassStaff
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(changePassStaff));
            verificationPanel = new Panel();
            verificationbutton = new Button();
            vercodetbx = new TextBox();
            label4 = new Label();
            label3 = new Label();
            cemailtbx = new TextBox();
            cusernametbx = new TextBox();
            sendCodebtn = new Button();
            cpasstbx = new TextBox();
            changepassbtn = new Button();
            confirmPassTBX = new TextBox();
            backbtn = new PictureBox();
            changePasspanel = new Panel();
            verificationPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)backbtn).BeginInit();
            changePasspanel.SuspendLayout();
            SuspendLayout();
            // 
            // verificationPanel
            // 
            verificationPanel.BackColor = Color.White;
            verificationPanel.BorderStyle = BorderStyle.FixedSingle;
            verificationPanel.Controls.Add(verificationbutton);
            verificationPanel.Controls.Add(vercodetbx);
            verificationPanel.Controls.Add(label4);
            verificationPanel.Location = new Point(745, 132);
            verificationPanel.Name = "verificationPanel";
            verificationPanel.Size = new Size(360, 220);
            verificationPanel.TabIndex = 18;
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
            verificationbutton.Click += verificationbutton_Click;
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
            // cemailtbx
            // 
            cemailtbx.Cursor = Cursors.IBeam;
            cemailtbx.Location = new Point(37, 144);
            cemailtbx.Name = "cemailtbx";
            cemailtbx.PlaceholderText = "Email";
            cemailtbx.Size = new Size(323, 27);
            cemailtbx.TabIndex = 11;
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
            // cpasstbx
            // 
            cpasstbx.Cursor = Cursors.IBeam;
            cpasstbx.Location = new Point(41, 332);
            cpasstbx.Name = "cpasstbx";
            cpasstbx.PlaceholderText = "Password";
            cpasstbx.Size = new Size(323, 27);
            cpasstbx.TabIndex = 15;
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
            // confirmPassTBX
            // 
            confirmPassTBX.Cursor = Cursors.IBeam;
            confirmPassTBX.Location = new Point(41, 378);
            confirmPassTBX.Name = "confirmPassTBX";
            confirmPassTBX.PlaceholderText = "Confirm Password";
            confirmPassTBX.Size = new Size(323, 27);
            confirmPassTBX.TabIndex = 17;
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
            changePasspanel.Location = new Point(282, 99);
            changePasspanel.Name = "changePasspanel";
            changePasspanel.Size = new Size(404, 510);
            changePasspanel.TabIndex = 11;
            // 
            // changePassStaff
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(238, 230, 223);
            ClientSize = new Size(1001, 690);
            Controls.Add(verificationPanel);
            Controls.Add(changePasspanel);
            Name = "changePassStaff";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += changePassStaff_Close;
            Load += changePassStaff_Load;
            verificationPanel.ResumeLayout(false);
            verificationPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)backbtn).EndInit();
            changePasspanel.ResumeLayout(false);
            changePasspanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel verificationPanel;
        private Button verificationbutton;
        private TextBox vercodetbx;
        private Label label4;
        private Label label3;
        private TextBox cemailtbx;
        private TextBox cusernametbx;
        private Button sendCodebtn;
        private TextBox cpasstbx;
        private Button changepassbtn;
        private TextBox confirmPassTBX;
        private PictureBox backbtn;
        private Panel changePasspanel;
    }
}