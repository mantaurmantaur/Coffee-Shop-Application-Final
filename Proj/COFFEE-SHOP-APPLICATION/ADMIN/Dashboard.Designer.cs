namespace COFFEE_SHOP_APPLICATION.ADMIN
{
    partial class Dashboard
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
            salesChart = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            salesduration = new ComboBox();
            label2 = new Label();
            startDatePicker = new DateTimePicker();
            endDatePicker = new DateTimePicker();
            label3 = new Label();
            panel1 = new Panel();
            dayDate = new DateTimePicker();
            timeDistributionChart = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            panel2 = new Panel();
            label4 = new Label();
            categorySalesChart = new LiveChartsCore.SkiaSharpView.WinForms.PieChart();
            panel3 = new Panel();
            topProductsChart = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            label5 = new Label();
            panel4 = new Panel();
            label6 = new Label();
            panel5 = new Panel();
            label1 = new Label();
            methodSalesChart = new LiveChartsCore.SkiaSharpView.WinForms.PieChart();
            label7 = new Label();
            label8 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // salesChart
            // 
            salesChart.BackColor = Color.White;
            salesChart.Location = new Point(9, 107);
            salesChart.MatchAxesScreenDataRatio = false;
            salesChart.Name = "salesChart";
            salesChart.Size = new Size(407, 539);
            salesChart.TabIndex = 75;
            // 
            // salesduration
            // 
            salesduration.FormattingEnabled = true;
            salesduration.Items.AddRange(new object[] { "Daily", "Weekly", "Monthly", "Yearly" });
            salesduration.Location = new Point(326, 40);
            salesduration.Name = "salesduration";
            salesduration.Size = new Size(90, 28);
            salesduration.TabIndex = 76;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(76, 100, 68);
            label2.Font = new Font("Tahoma", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(14, 4);
            label2.Name = "label2";
            label2.Size = new Size(168, 34);
            label2.TabIndex = 77;
            label2.Text = "Total Sales";
            // 
            // startDatePicker
            // 
            startDatePicker.CustomFormat = "yyyy-MM-dd";
            startDatePicker.Location = new Point(9, 41);
            startDatePicker.Name = "startDatePicker";
            startDatePicker.Size = new Size(248, 27);
            startDatePicker.TabIndex = 79;
            startDatePicker.Value = new DateTime(2025, 4, 18, 0, 0, 0, 0);
            // 
            // endDatePicker
            // 
            endDatePicker.CustomFormat = "yyyy-MM-dd";
            endDatePicker.Location = new Point(9, 74);
            endDatePicker.Name = "endDatePicker";
            endDatePicker.Size = new Size(248, 27);
            endDatePicker.TabIndex = 80;
            endDatePicker.Value = new DateTime(2025, 4, 18, 0, 0, 0, 0);
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Cursor = Cursors.Hand;
            label3.Font = new Font("Segoe UI", 12F);
            label3.ForeColor = Color.Yellow;
            label3.Location = new Point(356, 71);
            label3.Name = "label3";
            label3.Size = new Size(60, 28);
            label3.TabIndex = 81;
            label3.Text = "Show";
            label3.Click += label3_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(76, 100, 68);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(salesChart);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(endDatePicker);
            panel1.Controls.Add(salesduration);
            panel1.Controls.Add(startDatePicker);
            panel1.Location = new Point(-2, -4);
            panel1.Name = "panel1";
            panel1.Size = new Size(423, 707);
            panel1.TabIndex = 82;
            // 
            // dayDate
            // 
            dayDate.CustomFormat = "yyyy-MM-dd";
            dayDate.Location = new Point(188, 346);
            dayDate.Name = "dayDate";
            dayDate.Size = new Size(244, 27);
            dayDate.TabIndex = 83;
            dayDate.Value = new DateTime(2025, 4, 18, 0, 0, 0, 0);
            dayDate.ValueChanged += dayDate_ValueChanged;
            // 
            // timeDistributionChart
            // 
            timeDistributionChart.BackColor = Color.White;
            timeDistributionChart.Location = new Point(873, 349);
            timeDistributionChart.MatchAxesScreenDataRatio = false;
            timeDistributionChart.Name = "timeDistributionChart";
            timeDistributionChart.Size = new Size(415, 312);
            timeDistributionChart.TabIndex = 82;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(73, 54, 40);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(categorySalesChart);
            panel2.Location = new Point(430, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(423, 319);
            panel2.TabIndex = 83;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(73, 54, 40);
            label4.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(3, 11);
            label4.Name = "label4";
            label4.Size = new Size(160, 24);
            label4.TabIndex = 82;
            label4.Text = "Category Sales";
            // 
            // categorySalesChart
            // 
            categorySalesChart.BackColor = Color.White;
            categorySalesChart.InitialRotation = 0D;
            categorySalesChart.IsClockwise = true;
            categorySalesChart.Location = new Point(22, 40);
            categorySalesChart.MaxAngle = 360D;
            categorySalesChart.MaxValue = double.NaN;
            categorySalesChart.MinValue = 0D;
            categorySalesChart.Name = "categorySalesChart";
            categorySalesChart.Size = new Size(376, 263);
            categorySalesChart.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(73, 54, 40);
            panel3.Controls.Add(topProductsChart);
            panel3.Controls.Add(label5);
            panel3.Location = new Point(427, 321);
            panel3.Name = "panel3";
            panel3.Size = new Size(423, 382);
            panel3.TabIndex = 84;
            // 
            // topProductsChart
            // 
            topProductsChart.BackColor = Color.White;
            topProductsChart.Location = new Point(13, 28);
            topProductsChart.MatchAxesScreenDataRatio = false;
            topProductsChart.Name = "topProductsChart";
            topProductsChart.Size = new Size(397, 345);
            topProductsChart.TabIndex = 82;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.FromArgb(73, 54, 40);
            label5.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(3, 1);
            label5.Name = "label5";
            label5.Size = new Size(196, 24);
            label5.TabIndex = 82;
            label5.Text = "Trending Products";
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(76, 100, 68);
            panel4.Controls.Add(dayDate);
            panel4.Controls.Add(label6);
            panel4.Location = new Point(856, 321);
            panel4.Name = "panel4";
            panel4.Size = new Size(457, 382);
            panel4.TabIndex = 85;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.FromArgb(76, 100, 68);
            label6.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            label6.ForeColor = Color.White;
            label6.Location = new Point(3, 0);
            label6.Name = "label6";
            label6.Size = new Size(151, 24);
            label6.TabIndex = 83;
            label6.Text = "Hourly Orders";
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(76, 100, 68);
            panel5.Controls.Add(label1);
            panel5.Controls.Add(methodSalesChart);
            panel5.Location = new Point(865, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(423, 319);
            panel5.TabIndex = 84;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(76, 100, 68);
            label1.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(3, 11);
            label1.Name = "label1";
            label1.Size = new Size(240, 24);
            label1.TabIndex = 82;
            label1.Text = "Payment Method Sales";
            // 
            // methodSalesChart
            // 
            methodSalesChart.BackColor = Color.White;
            methodSalesChart.InitialRotation = 0D;
            methodSalesChart.IsClockwise = true;
            methodSalesChart.Location = new Point(22, 40);
            methodSalesChart.MaxAngle = 360D;
            methodSalesChart.MaxValue = double.NaN;
            methodSalesChart.MinValue = 0D;
            methodSalesChart.Name = "methodSalesChart";
            methodSalesChart.Size = new Size(376, 263);
            methodSalesChart.TabIndex = 0;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Black", 10.8F, FontStyle.Bold);
            label7.ForeColor = Color.White;
            label7.Location = new Point(9, 662);
            label7.Name = "label7";
            label7.Size = new Size(252, 25);
            label7.TabIndex = 82;
            label7.Text = "Total Sales (per duration): ";
            label7.Click += label7_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Black", 10.8F, FontStyle.Bold);
            label8.ForeColor = Color.White;
            label8.Location = new Point(267, 662);
            label8.Name = "label8";
            label8.Size = new Size(84, 25);
            label8.TabIndex = 83;
            label8.Text = "Loading";
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(238, 230, 223);
            ClientSize = new Size(1300, 703);
            Controls.Add(panel5);
            Controls.Add(timeDistributionChart);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(panel4);
            MaximizeBox = false;
            Name = "Dashboard";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Load += Dashboard_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart salesChart;
        private ComboBox salesduration;
        private Label label2;
        private DateTimePicker startDatePicker;
        private DateTimePicker endDatePicker;
        private Label label3;
        private Panel panel1;
        private Panel panel2;
        private LiveChartsCore.SkiaSharpView.WinForms.PieChart categorySalesChart;
        private Label label4;
        private Panel panel3;
        private Label label5;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart topProductsChart;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart timeDistributionChart;
        private DateTimePicker dayDate;
        private Panel panel4;
        private Label label6;
        private Panel panel5;
        private Label label1;
        private LiveChartsCore.SkiaSharpView.WinForms.PieChart methodSalesChart;
        private Label label7;
        private Label label8;
    }
}