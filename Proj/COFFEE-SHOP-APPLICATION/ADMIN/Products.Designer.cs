namespace COFFEE_SHOP_APPLICATION.ADMIN
{
    partial class Products
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panel1 = new Panel();
            productView = new DataGridView();
            categorytbx = new TextBox();
            categView = new DataGridView();
            addCategory = new Button();
            editProdPicbtn = new Button();
            refreshbtn = new Button();
            deletbtn = new Button();
            label1 = new Label();
            updatebtn = new Button();
            stockstbx = new TextBox();
            addbtn = new Button();
            stocklbl = new Label();
            statustbx = new ComboBox();
            pidtbx = new TextBox();
            idlbl = new Label();
            pricetbx = new TextBox();
            pricelbl = new Label();
            categorylbl = new Label();
            pnametbx = new TextBox();
            pntbx = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)productView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)categView).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.BackColor = Color.FromArgb(238, 230, 223);
            panel1.Controls.Add(productView);
            panel1.Controls.Add(categorytbx);
            panel1.Controls.Add(categView);
            panel1.Controls.Add(addCategory);
            panel1.Controls.Add(editProdPicbtn);
            panel1.Controls.Add(refreshbtn);
            panel1.Controls.Add(deletbtn);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(updatebtn);
            panel1.Controls.Add(stockstbx);
            panel1.Controls.Add(addbtn);
            panel1.Controls.Add(stocklbl);
            panel1.Controls.Add(statustbx);
            panel1.Controls.Add(pidtbx);
            panel1.Controls.Add(idlbl);
            panel1.Controls.Add(pricetbx);
            panel1.Controls.Add(pricelbl);
            panel1.Controls.Add(categorylbl);
            panel1.Controls.Add(pnametbx);
            panel1.Controls.Add(pntbx);
            panel1.Location = new Point(-7, -65);
            panel1.Name = "panel1";
            panel1.Size = new Size(1314, 810);
            panel1.TabIndex = 6;
            panel1.Paint += panel1_Paint;
            // 
            // productView
            // 
            productView.AllowUserToAddRows = false;
            productView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            productView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            productView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            productView.BackgroundColor = Color.FromArgb(73, 54, 40);
            productView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            productView.Location = new Point(482, 78);
            productView.Name = "productView";
            productView.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(255, 255, 128);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            productView.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            productView.RowHeadersWidth = 51;
            productView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            productView.Size = new Size(732, 651);
            productView.TabIndex = 71;
            productView.CellContentClick += productView_CellContentClick;
            // 
            // categorytbx
            // 
            categorytbx.Cursor = Cursors.IBeam;
            categorytbx.Location = new Point(191, 280);
            categorytbx.Name = "categorytbx";
            categorytbx.Size = new Size(197, 27);
            categorytbx.TabIndex = 72;
            // 
            // categView
            // 
            categView.AllowUserToAddRows = false;
            categView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            categView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            categView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            categView.BackgroundColor = Color.FromArgb(73, 54, 40);
            categView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            categView.Location = new Point(821, 218);
            categView.Name = "categView";
            categView.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(255, 255, 128);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            categView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            categView.RowHeadersWidth = 51;
            categView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            categView.Size = new Size(453, 317);
            categView.TabIndex = 70;
            categView.CellContentClick += categView_CellContentClick;
            // 
            // addCategory
            // 
            addCategory.Anchor = AnchorStyles.None;
            addCategory.BackColor = Color.FromArgb(76, 100, 68);
            addCategory.Cursor = Cursors.Hand;
            addCategory.FlatStyle = FlatStyle.Flat;
            addCategory.Font = new Font("Tahoma", 10.2F);
            addCategory.ForeColor = Color.White;
            addCategory.Location = new Point(188, 84);
            addCategory.Name = "addCategory";
            addCategory.Size = new Size(200, 41);
            addCategory.TabIndex = 68;
            addCategory.Text = "Add Category";
            addCategory.UseVisualStyleBackColor = false;
            addCategory.Click += addCategory_Click;
            // 
            // editProdPicbtn
            // 
            editProdPicbtn.Anchor = AnchorStyles.None;
            editProdPicbtn.BackColor = Color.FromArgb(73, 54, 40);
            editProdPicbtn.Cursor = Cursors.Hand;
            editProdPicbtn.FlatStyle = FlatStyle.Flat;
            editProdPicbtn.Font = new Font("Tahoma", 10.2F);
            editProdPicbtn.ForeColor = Color.White;
            editProdPicbtn.Location = new Point(191, 516);
            editProdPicbtn.Name = "editProdPicbtn";
            editProdPicbtn.Size = new Size(200, 32);
            editProdPicbtn.TabIndex = 67;
            editProdPicbtn.Text = "Edit Product Picture";
            editProdPicbtn.UseVisualStyleBackColor = false;
            editProdPicbtn.Click += editProdPicbtn_Click;
            // 
            // refreshbtn
            // 
            refreshbtn.Anchor = AnchorStyles.None;
            refreshbtn.BackColor = Color.FromArgb(76, 100, 68);
            refreshbtn.Cursor = Cursors.Hand;
            refreshbtn.FlatStyle = FlatStyle.Flat;
            refreshbtn.ForeColor = Color.White;
            refreshbtn.Location = new Point(288, 593);
            refreshbtn.Name = "refreshbtn";
            refreshbtn.Size = new Size(97, 64);
            refreshbtn.TabIndex = 66;
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
            deletbtn.Location = new Point(288, 663);
            deletbtn.Name = "deletbtn";
            deletbtn.Size = new Size(97, 64);
            deletbtn.TabIndex = 65;
            deletbtn.Text = "Delete";
            deletbtn.UseVisualStyleBackColor = false;
            deletbtn.Click += deletbtn_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 10.2F);
            label1.Location = new Point(191, 379);
            label1.Name = "label1";
            label1.Size = new Size(57, 21);
            label1.TabIndex = 39;
            label1.Text = "Status";
            // 
            // updatebtn
            // 
            updatebtn.Anchor = AnchorStyles.None;
            updatebtn.BackColor = Color.FromArgb(76, 100, 68);
            updatebtn.Cursor = Cursors.Hand;
            updatebtn.FlatStyle = FlatStyle.Flat;
            updatebtn.Font = new Font("Tahoma", 10.2F);
            updatebtn.ForeColor = Color.White;
            updatebtn.Location = new Point(188, 663);
            updatebtn.Name = "updatebtn";
            updatebtn.Size = new Size(94, 64);
            updatebtn.TabIndex = 64;
            updatebtn.Text = "Update";
            updatebtn.UseVisualStyleBackColor = false;
            updatebtn.Click += updatebtn_Click;
            // 
            // stockstbx
            // 
            stockstbx.Cursor = Cursors.IBeam;
            stockstbx.Location = new Point(191, 468);
            stockstbx.Name = "stockstbx";
            stockstbx.Size = new Size(197, 27);
            stockstbx.TabIndex = 37;
            // 
            // addbtn
            // 
            addbtn.Anchor = AnchorStyles.None;
            addbtn.BackColor = Color.FromArgb(76, 100, 68);
            addbtn.Cursor = Cursors.Hand;
            addbtn.FlatStyle = FlatStyle.Flat;
            addbtn.Font = new Font("Tahoma", 10.2F);
            addbtn.ForeColor = Color.White;
            addbtn.Location = new Point(188, 593);
            addbtn.Name = "addbtn";
            addbtn.Size = new Size(94, 64);
            addbtn.TabIndex = 63;
            addbtn.Text = "Add";
            addbtn.UseVisualStyleBackColor = false;
            addbtn.Click += addbtn_Click;
            // 
            // stocklbl
            // 
            stocklbl.Anchor = AnchorStyles.None;
            stocklbl.AutoSize = true;
            stocklbl.Font = new Font("Tahoma", 10.2F);
            stocklbl.Location = new Point(188, 444);
            stocklbl.Name = "stocklbl";
            stocklbl.Size = new Size(58, 21);
            stocklbl.TabIndex = 36;
            stocklbl.Text = "Stocks";
            // 
            // statustbx
            // 
            statustbx.FlatStyle = FlatStyle.System;
            statustbx.FormattingEnabled = true;
            statustbx.Items.AddRange(new object[] { "Available", "Unavailable" });
            statustbx.Location = new Point(191, 403);
            statustbx.Name = "statustbx";
            statustbx.Size = new Size(197, 28);
            statustbx.TabIndex = 35;
            // 
            // pidtbx
            // 
            pidtbx.Cursor = Cursors.IBeam;
            pidtbx.Location = new Point(188, 161);
            pidtbx.Name = "pidtbx";
            pidtbx.Size = new Size(197, 27);
            pidtbx.TabIndex = 33;
            // 
            // idlbl
            // 
            idlbl.Anchor = AnchorStyles.None;
            idlbl.AutoSize = true;
            idlbl.Font = new Font("Tahoma", 10.2F);
            idlbl.Location = new Point(188, 138);
            idlbl.Name = "idlbl";
            idlbl.Size = new Size(89, 21);
            idlbl.TabIndex = 32;
            idlbl.Text = "Product ID";
            // 
            // pricetbx
            // 
            pricetbx.Cursor = Cursors.IBeam;
            pricetbx.Location = new Point(191, 346);
            pricetbx.Name = "pricetbx";
            pricetbx.Size = new Size(194, 27);
            pricetbx.TabIndex = 22;
            // 
            // pricelbl
            // 
            pricelbl.Anchor = AnchorStyles.None;
            pricelbl.AutoSize = true;
            pricelbl.Font = new Font("Tahoma", 10.2F);
            pricelbl.Location = new Point(191, 318);
            pricelbl.Name = "pricelbl";
            pricelbl.Size = new Size(46, 21);
            pricelbl.TabIndex = 21;
            pricelbl.Text = "Price";
            // 
            // categorylbl
            // 
            categorylbl.Anchor = AnchorStyles.None;
            categorylbl.AutoSize = true;
            categorylbl.Font = new Font("Tahoma", 10.2F);
            categorylbl.Location = new Point(191, 256);
            categorylbl.Name = "categorylbl";
            categorylbl.Size = new Size(76, 21);
            categorylbl.TabIndex = 19;
            categorylbl.Text = "Category";
            // 
            // pnametbx
            // 
            pnametbx.Cursor = Cursors.IBeam;
            pnametbx.Location = new Point(191, 218);
            pnametbx.Name = "pnametbx";
            pnametbx.Size = new Size(197, 27);
            pnametbx.TabIndex = 18;
            // 
            // pntbx
            // 
            pntbx.Anchor = AnchorStyles.None;
            pntbx.AutoSize = true;
            pntbx.Font = new Font("Tahoma", 10.2F);
            pntbx.Location = new Point(191, 195);
            pntbx.Name = "pntbx";
            pntbx.Size = new Size(109, 21);
            pntbx.TabIndex = 17;
            pntbx.Text = "ProductName";
            // 
            // Products
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1300, 676);
            Controls.Add(panel1);
            Name = "Products";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Load += ShowProductLoad;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)productView).EndInit();
            ((System.ComponentModel.ISupportInitialize)categView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private TextBox stockstbx;
        private Label stocklbl;
        private ComboBox statustbx;
        private TextBox pidtbx;
        private Label idlbl;
        private TextBox pricetbx;
        private Label pricelbl;
        private Label categorylbl;
        private TextBox pnametbx;
        private Label pntbx;
        private Button refreshbtn;
        private Button deletbtn;
        private Button updatebtn;
        private Button addbtn;
        private Button editProdPicbtn;
        private Button addCategory;
        private DataGridView categView;
        private DataGridView productView;
        private TextBox categorytbx;
    }
}