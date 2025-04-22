namespace COFFEE_SHOP_APPLICATION.ADMIN
{
    partial class Staffs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Staffs));
            idtbx = new TextBox();
            label2 = new Label();
            lntbx = new TextBox();
            refreshbtn = new Button();
            deletbtn = new Button();
            updatebtn = new Button();
            addbtn = new Button();
            staffdataview = new DataGridView();
            label1 = new Label();
            statustbx = new ComboBox();
            credenbtn = new Button();
            postbx = new TextBox();
            pricelbl = new Label();
            categorylbl = new Label();
            fntbx = new TextBox();
            pntbx = new Label();
            backbtn = new PictureBox();
            emailtbx = new TextBox();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)staffdataview).BeginInit();
            ((System.ComponentModel.ISupportInitialize)backbtn).BeginInit();
            SuspendLayout();
            // 
            // idtbx
            // 
            idtbx.Anchor = AnchorStyles.None;
            idtbx.Cursor = Cursors.IBeam;
            idtbx.Location = new Point(89, 56);
            idtbx.Name = "idtbx";
            idtbx.Size = new Size(197, 27);
            idtbx.TabIndex = 65;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 10.2F);
            label2.Location = new Point(89, 33);
            label2.Name = "label2";
            label2.Size = new Size(64, 21);
            label2.TabIndex = 64;
            label2.Text = "Staff Id";
            // 
            // lntbx
            // 
            lntbx.Anchor = AnchorStyles.None;
            lntbx.Cursor = Cursors.IBeam;
            lntbx.Location = new Point(86, 186);
            lntbx.Name = "lntbx";
            lntbx.Size = new Size(197, 27);
            lntbx.TabIndex = 63;
            // 
            // refreshbtn
            // 
            refreshbtn.Anchor = AnchorStyles.None;
            refreshbtn.BackColor = Color.FromArgb(76, 100, 68);
            refreshbtn.Cursor = Cursors.Hand;
            refreshbtn.FlatStyle = FlatStyle.Flat;
            refreshbtn.ForeColor = Color.White;
            refreshbtn.Location = new Point(189, 433);
            refreshbtn.Name = "refreshbtn";
            refreshbtn.Size = new Size(100, 64);
            refreshbtn.TabIndex = 62;
            refreshbtn.Text = "Refresh";
            refreshbtn.UseVisualStyleBackColor = false;
            refreshbtn.Click += refreshbtn_Click;
            // 
            // deletbtn
            // 
            deletbtn.Anchor = AnchorStyles.None;
            deletbtn.BackColor = Color.FromArgb(76, 100, 68);
            deletbtn.Cursor = Cursors.Hand;
            deletbtn.FlatStyle = FlatStyle.Flat;
            deletbtn.Font = new Font("Tahoma", 10.2F);
            deletbtn.ForeColor = Color.White;
            deletbtn.Location = new Point(189, 503);
            deletbtn.Name = "deletbtn";
            deletbtn.Size = new Size(100, 64);
            deletbtn.TabIndex = 61;
            deletbtn.Text = "Delete";
            deletbtn.UseVisualStyleBackColor = false;
            deletbtn.Click += deletbtn_Click;
            // 
            // updatebtn
            // 
            updatebtn.Anchor = AnchorStyles.None;
            updatebtn.BackColor = Color.FromArgb(76, 100, 68);
            updatebtn.Cursor = Cursors.Hand;
            updatebtn.FlatStyle = FlatStyle.Flat;
            updatebtn.Font = new Font("Tahoma", 10.2F);
            updatebtn.ForeColor = Color.White;
            updatebtn.Location = new Point(89, 503);
            updatebtn.Name = "updatebtn";
            updatebtn.Size = new Size(94, 64);
            updatebtn.TabIndex = 60;
            updatebtn.Text = "Update";
            updatebtn.UseVisualStyleBackColor = false;
            updatebtn.Click += updatebtn_Click;
            // 
            // addbtn
            // 
            addbtn.Anchor = AnchorStyles.None;
            addbtn.BackColor = Color.FromArgb(76, 100, 68);
            addbtn.Cursor = Cursors.Hand;
            addbtn.FlatStyle = FlatStyle.Flat;
            addbtn.Font = new Font("Tahoma", 10.2F);
            addbtn.ForeColor = Color.White;
            addbtn.Location = new Point(89, 433);
            addbtn.Name = "addbtn";
            addbtn.Size = new Size(94, 64);
            addbtn.TabIndex = 59;
            addbtn.Text = "Add";
            addbtn.UseVisualStyleBackColor = false;
            addbtn.Click += addbtn_Click;
            // 
            // staffdataview
            // 
            staffdataview.Anchor = AnchorStyles.None;
            staffdataview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            staffdataview.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            staffdataview.BackgroundColor = Color.FromArgb(73, 54, 40);
            staffdataview.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            staffdataview.Location = new Point(358, 34);
            staffdataview.Name = "staffdataview";
            staffdataview.RowHeadersWidth = 51;
            staffdataview.Size = new Size(851, 618);
            staffdataview.TabIndex = 58;
            staffdataview.CellContentClick += staffdataview_CellContentClick;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 10.2F);
            label1.Location = new Point(86, 337);
            label1.Name = "label1";
            label1.Size = new Size(57, 21);
            label1.TabIndex = 57;
            label1.Text = "Status";
            // 
            // statustbx
            // 
            statustbx.Anchor = AnchorStyles.None;
            statustbx.FlatStyle = FlatStyle.System;
            statustbx.FormattingEnabled = true;
            statustbx.Items.AddRange(new object[] { "Active", "Inactive" });
            statustbx.Location = new Point(86, 361);
            statustbx.Name = "statustbx";
            statustbx.Size = new Size(197, 28);
            statustbx.TabIndex = 56;
            // 
            // credenbtn
            // 
            credenbtn.Anchor = AnchorStyles.None;
            credenbtn.Cursor = Cursors.Hand;
            credenbtn.Font = new Font("Tahoma", 10.2F);
            credenbtn.Location = new Point(86, 594);
            credenbtn.Name = "credenbtn";
            credenbtn.Size = new Size(203, 51);
            credenbtn.TabIndex = 53;
            credenbtn.Text = "Show Credentials";
            credenbtn.UseVisualStyleBackColor = true;
            credenbtn.Click += credenbtn_Click;
            // 
            // postbx
            // 
            postbx.Anchor = AnchorStyles.None;
            postbx.Cursor = Cursors.IBeam;
            postbx.Location = new Point(86, 244);
            postbx.Name = "postbx";
            postbx.Size = new Size(197, 27);
            postbx.TabIndex = 52;
            // 
            // pricelbl
            // 
            pricelbl.Anchor = AnchorStyles.None;
            pricelbl.AutoSize = true;
            pricelbl.Font = new Font("Tahoma", 10.2F);
            pricelbl.Location = new Point(86, 216);
            pricelbl.Name = "pricelbl";
            pricelbl.Size = new Size(68, 21);
            pricelbl.TabIndex = 51;
            pricelbl.Text = "Position";
            // 
            // categorylbl
            // 
            categorylbl.Anchor = AnchorStyles.None;
            categorylbl.AutoSize = true;
            categorylbl.Font = new Font("Tahoma", 10.2F);
            categorylbl.Location = new Point(86, 154);
            categorylbl.Name = "categorylbl";
            categorylbl.Size = new Size(89, 21);
            categorylbl.TabIndex = 50;
            categorylbl.Text = "Last Name";
            // 
            // fntbx
            // 
            fntbx.Anchor = AnchorStyles.None;
            fntbx.Cursor = Cursors.IBeam;
            fntbx.Location = new Point(86, 116);
            fntbx.Name = "fntbx";
            fntbx.Size = new Size(194, 27);
            fntbx.TabIndex = 49;
            // 
            // pntbx
            // 
            pntbx.Anchor = AnchorStyles.None;
            pntbx.AutoSize = true;
            pntbx.Font = new Font("Tahoma", 10.2F);
            pntbx.Location = new Point(86, 93);
            pntbx.Name = "pntbx";
            pntbx.Size = new Size(91, 21);
            pntbx.TabIndex = 48;
            pntbx.Text = "First Name";
            // 
            // backbtn
            // 
            backbtn.Cursor = Cursors.Hand;
            backbtn.Image = (Image)resources.GetObject("backbtn.Image");
            backbtn.Location = new Point(12, 12);
            backbtn.Name = "backbtn";
            backbtn.Size = new Size(33, 36);
            backbtn.TabIndex = 66;
            backbtn.TabStop = false;
            backbtn.Click += backbtn_Click;
            // 
            // emailtbx
            // 
            emailtbx.Anchor = AnchorStyles.None;
            emailtbx.Cursor = Cursors.IBeam;
            emailtbx.Location = new Point(86, 307);
            emailtbx.Name = "emailtbx";
            emailtbx.Size = new Size(197, 27);
            emailtbx.TabIndex = 68;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 10.2F);
            label3.Location = new Point(86, 279);
            label3.Name = "label3";
            label3.Size = new Size(51, 21);
            label3.TabIndex = 67;
            label3.Text = "Email";
            // 
            // Staffs
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(238, 230, 223);
            ClientSize = new Size(1300, 676);
            Controls.Add(emailtbx);
            Controls.Add(label3);
            Controls.Add(backbtn);
            Controls.Add(idtbx);
            Controls.Add(label2);
            Controls.Add(lntbx);
            Controls.Add(refreshbtn);
            Controls.Add(deletbtn);
            Controls.Add(updatebtn);
            Controls.Add(addbtn);
            Controls.Add(staffdataview);
            Controls.Add(label1);
            Controls.Add(statustbx);
            Controls.Add(credenbtn);
            Controls.Add(postbx);
            Controls.Add(pricelbl);
            Controls.Add(categorylbl);
            Controls.Add(fntbx);
            Controls.Add(pntbx);
            Name = "Staffs";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Load += Staffs_Load;
            ((System.ComponentModel.ISupportInitialize)staffdataview).EndInit();
            ((System.ComponentModel.ISupportInitialize)backbtn).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox idtbx;
        private Label label2;
        private TextBox lntbx;
        private Button refreshbtn;
        private Button deletbtn;
        private Button updatebtn;
        private Button addbtn;
        private DataGridView staffdataview;
        private Label label1;
        private ComboBox statustbx;
        private Button credenbtn;
        private TextBox postbx;
        private Label pricelbl;
        private Label categorylbl;
        private TextBox fntbx;
        private Label pntbx;
        private PictureBox backbtn;
        private TextBox emailtbx;
        private Label label3;
    }
}