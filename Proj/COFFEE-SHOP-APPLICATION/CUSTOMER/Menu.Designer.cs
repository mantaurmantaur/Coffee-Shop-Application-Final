namespace COFFEE_SHOP_APPLICATION.CUSTOMER
{
    partial class Menu
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
            orderdetails = new Panel();
            label2 = new Label();
            orderDetailstbx = new RichTextBox();
            timer1 = new System.Windows.Forms.Timer(components);
            panel1 = new Panel();
            categoriesLayOutPanel = new FlowLayoutPanel();
            label1 = new Label();
            menuflp = new FlowLayoutPanel();
            orderdetails.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // orderdetails
            // 
            orderdetails.BackColor = Color.FromArgb(76, 100, 68);
            orderdetails.BorderStyle = BorderStyle.FixedSingle;
            orderdetails.Controls.Add(label2);
            orderdetails.Controls.Add(orderDetailstbx);
            orderdetails.Dock = DockStyle.Right;
            orderdetails.Location = new Point(747, 0);
            orderdetails.Name = "orderdetails";
            orderdetails.Size = new Size(268, 735);
            orderdetails.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(58, 8);
            label2.Name = "label2";
            label2.Size = new Size(155, 31);
            label2.TabIndex = 1;
            label2.Text = "Order Details";
            // 
            // orderDetailstbx
            // 
            orderDetailstbx.BackColor = Color.White;
            orderDetailstbx.BorderStyle = BorderStyle.FixedSingle;
            orderDetailstbx.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            orderDetailstbx.Location = new Point(3, 43);
            orderDetailstbx.Name = "orderDetailstbx";
            orderDetailstbx.Size = new Size(260, 679);
            orderDetailstbx.TabIndex = 0;
            orderDetailstbx.Text = "";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(238, 230, 223);
            panel1.Controls.Add(categoriesLayOutPanel);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(menuflp);
            panel1.Location = new Point(-3, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(748, 735);
            panel1.TabIndex = 5;
            // 
            // categoriesLayOutPanel
            // 
            categoriesLayOutPanel.Location = new Point(34, 101);
            categoriesLayOutPanel.Name = "categoriesLayOutPanel";
            categoriesLayOutPanel.Size = new Size(705, 121);
            categoriesLayOutPanel.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(73, 54, 40);
            label1.Location = new Point(15, 22);
            label1.Name = "label1";
            label1.Size = new Size(340, 57);
            label1.TabIndex = 11;
            label1.Text = "Choose Menu";
            // 
            // menuflp
            // 
            menuflp.Anchor = AnchorStyles.None;
            menuflp.AutoScroll = true;
            menuflp.Location = new Point(10, 228);
            menuflp.Name = "menuflp";
            menuflp.Padding = new Padding(20);
            menuflp.Size = new Size(729, 478);
            menuflp.TabIndex = 10;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1015, 735);
            Controls.Add(panel1);
            Controls.Add(orderdetails);
            Name = "Menu";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Load += Menu_Load;
            orderdetails.ResumeLayout(false);
            orderdetails.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel orderdetails;
        private RichTextBox orderDetailstbx;
        private System.Windows.Forms.Timer timer1;
        private Panel panel1;
        private FlowLayoutPanel menuflp;
        private Label label1;
        private Label label2;
        private FlowLayoutPanel categoriesLayOutPanel;
    }
}