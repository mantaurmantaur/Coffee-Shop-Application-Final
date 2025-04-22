namespace COFFEE_SHOP_APPLICATION.CUSTOMER
{
    partial class Profile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Profile));
            profPanel = new Panel();
            redeemPanel = new Panel();
            pointstbx = new RichTextBox();
            desc = new RichTextBox();
            button2 = new Button();
            redeembtn = new Button();
            panel1 = new Panel();
            redeemedflp = new FlowLayoutPanel();
            label2 = new Label();
            rewardsList = new FlowLayoutPanel();
            values = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            profilePicbox = new PictureBox();
            profilePanel = new Panel();
            button1 = new Button();
            unlbl = new Label();
            profemail = new Label();
            profPanel.SuspendLayout();
            redeemPanel.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)profilePicbox).BeginInit();
            profilePanel.SuspendLayout();
            SuspendLayout();
            // 
            // profPanel
            // 
            profPanel.BackColor = Color.White;
            profPanel.Controls.Add(redeemPanel);
            profPanel.Controls.Add(panel1);
            profPanel.Controls.Add(profilePicbox);
            profPanel.Controls.Add(profilePanel);
            profPanel.Location = new Point(0, 0);
            profPanel.Name = "profPanel";
            profPanel.Size = new Size(1015, 696);
            profPanel.TabIndex = 0;
            // 
            // redeemPanel
            // 
            redeemPanel.Controls.Add(pointstbx);
            redeemPanel.Controls.Add(desc);
            redeemPanel.Controls.Add(button2);
            redeemPanel.Controls.Add(redeembtn);
            redeemPanel.Location = new Point(12, 12);
            redeemPanel.Name = "redeemPanel";
            redeemPanel.Size = new Size(394, 244);
            redeemPanel.TabIndex = 7;
            // 
            // pointstbx
            // 
            pointstbx.BackColor = Color.FromArgb(76, 100, 68);
            pointstbx.BorderStyle = BorderStyle.None;
            pointstbx.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pointstbx.ForeColor = Color.White;
            pointstbx.Location = new Point(14, 116);
            pointstbx.Name = "pointstbx";
            pointstbx.Size = new Size(367, 45);
            pointstbx.TabIndex = 6;
            pointstbx.Text = "";
            // 
            // desc
            // 
            desc.BackColor = Color.FromArgb(76, 100, 68);
            desc.BorderStyle = BorderStyle.None;
            desc.Font = new Font("Tahoma", 14F);
            desc.ForeColor = Color.White;
            desc.Location = new Point(14, 33);
            desc.Name = "desc";
            desc.Size = new Size(367, 77);
            desc.TabIndex = 5;
            desc.Text = "";
            // 
            // button2
            // 
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(14, 181);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 4;
            button2.Text = "Back";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // redeembtn
            // 
            redeembtn.BackColor = Color.FromArgb(73, 54, 40);
            redeembtn.FlatStyle = FlatStyle.Flat;
            redeembtn.ForeColor = Color.White;
            redeembtn.Location = new Point(287, 181);
            redeembtn.Name = "redeembtn";
            redeembtn.Size = new Size(94, 29);
            redeembtn.TabIndex = 3;
            redeembtn.Text = "Redeem";
            redeembtn.UseVisualStyleBackColor = false;
            redeembtn.Click += redeembtn_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.BackColor = Color.FromArgb(73, 54, 40);
            panel1.Controls.Add(redeemedflp);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(rewardsList);
            panel1.Controls.Add(values);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(141, 321);
            panel1.Name = "panel1";
            panel1.Size = new Size(741, 359);
            panel1.TabIndex = 6;
            // 
            // redeemedflp
            // 
            redeemedflp.BackColor = Color.White;
            redeemedflp.BorderStyle = BorderStyle.FixedSingle;
            redeemedflp.Location = new Point(251, 259);
            redeemedflp.Name = "redeemedflp";
            redeemedflp.Size = new Size(465, 87);
            redeemedflp.TabIndex = 19;
            // 
            // label2
            // 
            label2.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(216, 232);
            label2.Name = "label2";
            label2.Size = new Size(167, 24);
            label2.TabIndex = 7;
            label2.Text = "Redeemed";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // rewardsList
            // 
            rewardsList.AutoScroll = true;
            rewardsList.BackColor = Color.White;
            rewardsList.BorderStyle = BorderStyle.FixedSingle;
            rewardsList.FlowDirection = FlowDirection.TopDown;
            rewardsList.Location = new Point(251, 18);
            rewardsList.Name = "rewardsList";
            rewardsList.Size = new Size(465, 211);
            rewardsList.TabIndex = 18;
            // 
            // values
            // 
            values.Font = new Font("Tahoma", 22.2F, FontStyle.Bold);
            values.ForeColor = Color.White;
            values.Location = new Point(24, 250);
            values.Name = "values";
            values.Size = new Size(207, 45);
            values.TabIndex = 17;
            values.Text = "Points";
            values.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.Font = new Font("Tahoma", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(24, 42);
            label1.Name = "label1";
            label1.Size = new Size(207, 45);
            label1.TabIndex = 16;
            label1.Text = "Points";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(38, 90);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(168, 139);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            // 
            // profilePicbox
            // 
            profilePicbox.Location = new Point(439, 30);
            profilePicbox.Name = "profilePicbox";
            profilePicbox.Size = new Size(145, 119);
            profilePicbox.SizeMode = PictureBoxSizeMode.StretchImage;
            profilePicbox.TabIndex = 5;
            profilePicbox.TabStop = false;
            // 
            // profilePanel
            // 
            profilePanel.Anchor = AnchorStyles.None;
            profilePanel.BackColor = Color.FromArgb(76, 100, 68);
            profilePanel.Controls.Add(button1);
            profilePanel.Controls.Add(unlbl);
            profilePanel.Controls.Add(profemail);
            profilePanel.Location = new Point(141, 110);
            profilePanel.Name = "profilePanel";
            profilePanel.Size = new Size(741, 205);
            profilePanel.TabIndex = 4;
            // 
            // button1
            // 
            button1.Location = new Point(324, 63);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 6;
            button1.Text = "Change Profile";
            button1.UseVisualStyleBackColor = true;
            button1.Click += changeProfbtn_Click;
            // 
            // unlbl
            // 
            unlbl.Font = new Font("Tahoma", 22.2F, FontStyle.Bold);
            unlbl.ForeColor = Color.White;
            unlbl.Location = new Point(197, 95);
            unlbl.Name = "unlbl";
            unlbl.Size = new Size(360, 45);
            unlbl.TabIndex = 5;
            unlbl.Text = "Username";
            unlbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // profemail
            // 
            profemail.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            profemail.ForeColor = Color.White;
            profemail.Location = new Point(197, 149);
            profemail.Name = "profemail";
            profemail.Size = new Size(356, 24);
            profemail.TabIndex = 6;
            profemail.Text = "Email";
            profemail.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Profile
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1015, 696);
            Controls.Add(profPanel);
            MaximizeBox = false;
            Name = "Profile";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Load += profile_Load;
            profPanel.ResumeLayout(false);
            redeemPanel.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)profilePicbox).EndInit();
            profilePanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel profPanel;
        private PictureBox profilePicbox;
        private Panel profilePanel;
        private Label unlbl;
        private Label profemail;
        private Button button1;
        private Panel panel1;
        private FlowLayoutPanel rewardsList;
        private Label values;
        private Label label1;
        private PictureBox pictureBox1;
        private FlowLayoutPanel redeemedflp;
        private Label label2;
        private Panel redeemPanel;
        private RichTextBox desc;
        private Button button2;
        private Button redeembtn;
        private RichTextBox pointstbx;
    }
}