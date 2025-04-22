namespace COFFEE_SHOP_APPLICATION.ADMIN
{
    partial class Customers
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
            label5 = new Label();
            topCustomersChart = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            mostStarsChart = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            customersView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)customersView).BeginInit();
            SuspendLayout();
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.Font = new Font("Tahoma", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(76, 100, 68);
            label5.Location = new Point(12, -3);
            label5.Name = "label5";
            label5.Size = new Size(351, 72);
            label5.TabIndex = 69;
            label5.Text = "Customers";
            // 
            // topCustomersChart
            // 
            topCustomersChart.Anchor = AnchorStyles.None;
            topCustomersChart.BackColor = Color.White;
            topCustomersChart.ForeColor = Color.Black;
            topCustomersChart.Location = new Point(12, 72);
            topCustomersChart.MatchAxesScreenDataRatio = false;
            topCustomersChart.Name = "topCustomersChart";
            topCustomersChart.Size = new Size(433, 579);
            topCustomersChart.TabIndex = 74;
            // 
            // mostStarsChart
            // 
            mostStarsChart.Anchor = AnchorStyles.None;
            mostStarsChart.BackColor = Color.White;
            mostStarsChart.ForeColor = Color.Black;
            mostStarsChart.Location = new Point(496, 71);
            mostStarsChart.MatchAxesScreenDataRatio = false;
            mostStarsChart.Name = "mostStarsChart";
            mostStarsChart.Size = new Size(433, 579);
            mostStarsChart.TabIndex = 75;
            // 
            // customersView
            // 
            customersView.Anchor = AnchorStyles.None;
            customersView.BackgroundColor = Color.White;
            customersView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            customersView.Location = new Point(971, 72);
            customersView.Name = "customersView";
            customersView.RowHeadersWidth = 51;
            customersView.Size = new Size(300, 580);
            customersView.TabIndex = 76;
            // 
            // Customers
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(238, 230, 223);
            ClientSize = new Size(1300, 676);
            Controls.Add(customersView);
            Controls.Add(mostStarsChart);
            Controls.Add(topCustomersChart);
            Controls.Add(label5);
            Name = "Customers";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Load += Customers_Load;
            ((System.ComponentModel.ISupportInitialize)customersView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label5;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart topCustomersChart;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart mostStarsChart;
        private DataGridView customersView;
    }
}