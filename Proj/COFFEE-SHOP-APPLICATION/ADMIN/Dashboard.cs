using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.SKCharts;
using LiveChartsCore.SkiaSharpView.WinForms;
using LiveChartsCore.Themes;
using SkiaSharp;
using static COFFEE_SHOP_APPLICATION.generalClass;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Globalization;
using LiveChartsCore.SkiaSharpView.VisualElements;
using System.Collections;
using COFFEE_SHOP_APPLICATION.STAFFS;

namespace COFFEE_SHOP_APPLICATION.ADMIN
{
    public partial class Dashboard : Form
    {
        private Dictionary<string, decimal> sales = new Dictionary<string, decimal>();
        public Dashboard()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            ShowLastThreeDaysSales();
            loadCategSales();
            loadTopProducts();
            loadMethodSales();
            loadHourly();
        }

        public void loadMethodSales()
        {
            DashboardAdmin dash = new DashboardAdmin();
            var methodSales = dash.GetMethodSales();
            decimal totalSum = methodSales.Values.Sum();

            var series = methodSales.Select(cs =>
            new PieSeries<decimal>
            {
                Values = new[] { cs.Value },
                Name = cs.Key,
                DataLabelsPaint = new SolidColorPaint(SKColors.White),
                DataLabelsSize = 14,
                DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                DataLabelsFormatter = point =>
                {
                    double percent = (point.Coordinate.PrimaryValue / (double)totalSum) * 100;
                    return $"{percent:N1}%";
                }
            }).ToArray();

            methodSalesChart.Series = series;
        }

        private void ShowLastThreeDaysSales()
        {
            salesduration.SelectedItem = "Daily";

            endDatePicker.Value = DateTime.Today;
            startDatePicker.Value = DateTime.Today.AddDays(-4);

            label3_Click(null, EventArgs.Empty);
        }

        public void loadHourly()
        {
            DateTime selectedDate = DateTime.Now; // Get the selected date from the DateTimePicker
            var hourlyData = LoadHourlyDataForDate(selectedDate);
            var hours = hourlyData.Keys.ToArray();
            var counts = hourlyData.Values.Select(v => (double)v).ToArray();

            var columnSeries = new ColumnSeries<double>
            {
                Values = counts,
                Name = "Orders",
                DataLabelsPaint = new SolidColorPaint(SKColors.Black),
                DataLabelsSize = 10,
                DataLabelsPosition = LiveChartsCore.Measure.DataLabelsPosition.Top,
                DataLabelsFormatter = point => $"{point.Coordinate.PrimaryValue}",
                Fill = new SolidColorPaint(SKColors.SteelBlue)
            };

            timeDistributionChart.Series = new ISeries[] { columnSeries };

            timeDistributionChart.XAxes = new Axis[]
            {
        new Axis
        {
            Labels = hours,
            LabelsRotation = 45,
            Name = "Hour of Day (" + selectedDate.ToString("MMM dd, yyyy") + ")",
            TextSize = 9
        }
            };

            timeDistributionChart.YAxes = new Axis[]
            {
        new Axis
        {
            Name = "Number of Orders",
            MinLimit = 0,
            TextSize = 9
        }
            };

        }

        public void loadCategSales()
        {
            DashboardAdmin dash = new DashboardAdmin();
            var categorySales = dash.GetCategorySales();
            decimal totalSum = categorySales.Values.Sum();

            var series = categorySales.Select(cs =>
            new PieSeries<decimal>
            {
                Values = new[] { cs.Value },
                Name = cs.Key,
                DataLabelsPaint = new SolidColorPaint(SKColors.White),
                DataLabelsSize = 14,
                DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                DataLabelsFormatter = point =>
                {
                    double percent = (point.Coordinate.PrimaryValue / (double)totalSum) * 100;
                    return $"{percent:N1}%";
                }
            }).ToArray();

            categorySalesChart.Series = series;
        }

        public void loadTopProducts()
        {
            DashboardAdmin dash = new DashboardAdmin();
            var topProducts = dash.GetTopProducts();

            var orderValues = topProducts.Values.Select(val => (double)val).ToArray();
            var hoverLabel = topProducts.Keys
            .Select((name, index) => $"{name}")
            .ToArray();

            topProductsChart.Series = new ISeries[]
            {
        new LineSeries<double>
        {
            Values = orderValues,
            //Name = "Top Products",
            GeometrySize = 10,
            Stroke = new SolidColorPaint(SKColors.OrangeRed, 3),
            Fill = null,
            GeometryFill = new SolidColorPaint(SKColors.White),
            GeometryStroke = new SolidColorPaint(SKColors.OrangeRed, 3),
            DataLabelsPaint = new SolidColorPaint(SKColors.Black),
            DataLabelsSize = 14,
            DataLabelsFormatter = point => "",
        }
                };

            topProductsChart.XAxes = new Axis[]
            {
        new Axis
        {
            Labels = hoverLabel,
            LabelsRotation = 15,
            Name = "Products",
            ForceStepToMin = true,
            TextSize = 10,
            SeparatorsPaint = new SolidColorPaint(SKColors.LightGray)
        }
            };

            topProductsChart.YAxes = new Axis[]
            {
        new Axis
        {
            Name = "Orders",
            Labeler = value => value.ToString("N0"),
            TextSize = 12,
            SeparatorsPaint = new SolidColorPaint(SKColors.LightGray),
            MinLimit = 1 // Optional
        }
            };
        }
        public void LoadDailySales(DateTime startDate, DateTime endDate)
        {
            sales.Clear();

            try
            {
                using (var connection = generalClass.GetConnection())
                {
                    connection.Open();

                    string query = @"SELECT SaleDate, TotalSales
                         FROM TotalSalesToday
                         WHERE SaleDate BETWEEN ? AND ?
                         ORDER BY SaleDate";

                    using (var cmd = new OleDbCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("?", startDate.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("?", endDate.ToString("yyyy-MM-dd"));
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string dateString = reader["SaleDate"].ToString();
                                DateTime date = DateTime.ParseExact(dateString, "yyyy-MM-dd", null);
                                decimal total = Convert.ToDecimal(reader["TotalSales"]);
                                sales[date.ToString("yyyy-MM-dd")] = total;
                            }
                        }
                    }
                }

                // Fill missing dates with 0 (if necessary)
                for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
                {
                    string dateKey = date.ToString("yyyy-MM-dd");
                    if (!sales.ContainsKey(dateKey))
                    {
                        sales[dateKey] = 0;
                    }
                }

                LoadSalesChart();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading sales data: {ex.Message}");
            }
        }

        public void LoadWeeklySales(DateTime startDate, DateTime endDate)
        {
            sales.Clear();

            try
            {
                using (var connection = generalClass.GetConnection())
                {
                    connection.Open();

                    // MS Access compatible weekly grouping
                    string query = @"
                SELECT 
                    Year(SaleDate) AS SaleYear,
                    DatePart('ww', SaleDate) AS SaleWeek,
                    SUM(TotalSales) AS WeeklySales
                FROM TotalSalesToday
                WHERE SaleDate BETWEEN ? AND ?
                GROUP BY Year(SaleDate), DatePart('ww', SaleDate)
                ORDER BY Year(SaleDate), DatePart('ww', SaleDate)";

                    using (var cmd = new OleDbCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("?", startDate);
                        cmd.Parameters.AddWithValue("?", endDate);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int year = Convert.ToInt32(reader["SaleYear"]);
                                int week = Convert.ToInt32(reader["SaleWeek"]);
                                decimal total = Convert.ToDecimal(reader["WeeklySales"]);

                                string weekKey = $"{year}-W{week:00}";
                                sales[weekKey] = total;
                            }
                        }
                    }
                }

                // Fill missing weeks with 0
                DateTime currentWeek = GetStartOfWeek(startDate);
                while (currentWeek <= endDate)
                {
                    int year = currentWeek.Year;
                    int week = GetWeekOfYear(currentWeek);
                    string weekKey = $"{year}-W{week:00}";

                    if (!sales.ContainsKey(weekKey))
                    {
                        sales[weekKey] = 0;
                    }

                    currentWeek = currentWeek.AddDays(7);
                }

                LoadWeeklyLineChart();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading weekly sales: {ex.Message}");
            }
        }

        // Helper method to get start of week (Monday)
        private DateTime GetStartOfWeek(DateTime dt)
        {
            int diff = (7 + (dt.DayOfWeek - DayOfWeek.Monday)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }

        // Helper method to get week number (MS Access compatible)
        private int GetWeekOfYear(DateTime date)
        {
            // MS Access uses Sunday as first day of week
            CultureInfo ci = CultureInfo.CurrentCulture;
            return ci.Calendar.GetWeekOfYear(
                date,
                CalendarWeekRule.FirstDay,
                DayOfWeek.Sunday);
        }

        private void LoadWeeklyLineChart()
        {
            try
            {
                // 1. Process and sort weekly data
                var sortedData = sales
                    .Select(kvp => new
                    {
                        Key = kvp.Key,
                        Year = int.Parse(kvp.Key.Split('-')[0]),
                        Week = int.Parse(kvp.Key.Split('-')[1].Substring(1)),
                        Value = kvp.Value
                    })
                    .OrderBy(x => x.Year)
                    .ThenBy(x => x.Week)
                    .ToList();

                // 2. Prepare chart data
                var labels = sortedData.Select(x => x.Key).ToArray();
                var values = sortedData.Select(x => (double)x.Value).ToArray();

                // 3. Configure Line Chart
                salesChart.Series = new ISeries[]
                {
            new LineSeries<double>
            {
                Values = values,
                Name = "Weekly Sales",
                Stroke = new SolidColorPaint(SKColors.SteelBlue, 3),
                GeometryStroke = new SolidColorPaint(SKColors.SteelBlue, 3),
                GeometryFill = new SolidColorPaint(SKColors.White),
                GeometrySize = 10,
                LineSmoothness = 0, // Straight lines
                DataLabelsPaint = new SolidColorPaint(SKColors.Black),
                DataLabelsPosition = LiveChartsCore.Measure.DataLabelsPosition.Top,
                DataLabelsFormatter = point => $"{point.Coordinate.PrimaryValue:C}"
            }
                };
                salesChart.XAxes = new Axis[]
                {
            new Axis
            {
                Labels = labels,
                LabelsRotation = 45,
                Name = "Week (YYYY-WNN)",
                TextSize = 10,
                SeparatorsPaint = new SolidColorPaint(SKColors.LightGray.WithAlpha(100)),
                ForceStepToMin = true // Ensures all labels are shown
            }
                };

                salesChart.YAxes = new Axis[]
                {
            new Axis
            {
                Name = "Sales Amount",
                Labeler = value => value.ToString("C0"),
                MinLimit = 0,
                TextSize = 12,
                SeparatorsPaint = new SolidColorPaint(SKColors.LightGray.WithAlpha(50))
            }
                };

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating weekly chart: {ex.Message}\n" +
                              "Ensure your data uses 'YYYY-WNN' format (e.g. 2025-W15)");
            }

            decimal grandTotal = sales.Values.Sum();
            label8.Text = $"₱{grandTotal:F2}";
        }

        public Dictionary<string, int> LoadHourlyDataForDate(DateTime selectedDate)
        {
            Dictionary<string, int> hourlyData = new Dictionary<string, int>();

            using (var connection = generalClass.GetConnection())
            {
                connection.Open();

                string query = @"SELECT 
                            FORMAT(Hour(OrderDate), '00') & ':00' AS HourOnly,
                            COUNT(*) AS OrderCount
                         FROM Orders
                         WHERE Status IN ('paid', 'served')
                           AND FORMAT(OrderDate, 'yyyy-MM-dd') = ?
                         GROUP BY Hour(OrderDate)
                         ORDER BY Hour(OrderDate)";

                using (var cmd = new OleDbCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("?", selectedDate.ToString("yyyy-MM-dd"));

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string hour = reader["HourOnly"].ToString();
                            int count = Convert.ToInt32(reader["OrderCount"]);
                            hourlyData[hour] = count;
                        }
                    }
                }
            }

            // Fill all 24 hours (even if no orders)
            for (int h = 0; h < 24; h++)
            {
                string hourKey = $"{h:00}:00";
                if (!hourlyData.ContainsKey(hourKey))
                {
                    hourlyData[hourKey] = 0;
                }
            }

            return hourlyData.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
        }

        public void ShowHourlyDistribution(DateTime selectedDate)
        {
            var hourlyData = LoadHourlyDataForDate(selectedDate);
            var hours = hourlyData.Keys.ToArray();
            var counts = hourlyData.Values.Select(v => (double)v).ToArray();

            var columnSeries = new ColumnSeries<double>
            {
                Values = counts,
                Name = "Orders",
                DataLabelsPaint = new SolidColorPaint(SKColors.Black),
                DataLabelsSize = 10,
                DataLabelsPosition = LiveChartsCore.Measure.DataLabelsPosition.Top,
                DataLabelsFormatter = point => $"{point.Coordinate.PrimaryValue}",
                Fill = new SolidColorPaint(SKColors.SteelBlue)
            };

            timeDistributionChart.Series = new ISeries[] { columnSeries };

            timeDistributionChart.XAxes = new Axis[]
            {
        new Axis
        {
            Labels = hours,
            LabelsRotation = 45,
            Name = "Hour of Day (" + selectedDate.ToString("MMM dd, yyyy") + ")",
            TextSize = 9
        }
            };

            timeDistributionChart.YAxes = new Axis[]
            {
        new Axis
        {
            Name = "Number of Orders",
            MinLimit = 0,
            TextSize = 9
        }
            };
        }

        private void LoadSalesChart()
        {
            if (sales.Count == 0)
            {
                MessageBox.Show("No sales data available for the selected date range.");
                return;
            }

            try
            {
                var sortedDates = sales.Keys.OrderBy(d => d).ToList();

                var dates = sortedDates.ToArray();
                var values = sortedDates.Select(d => (double)sales[d]).ToArray();

                salesChart.Series = new ISeries[]
                {
            new LineSeries<double>
            {
                Values = values,
                Name = "Daily Sales",
                Fill = null,
                LineSmoothness = 0.5,
                Stroke = new SolidColorPaint(SKColors.DeepSkyBlue, 3),
                GeometryStroke = new SolidColorPaint(SKColors.DeepSkyBlue, 3),
                GeometryFill = new SolidColorPaint(SKColors.White),
                GeometrySize = 10
            }
                };

                // Configure X-axis
                salesChart.XAxes = new Axis[]
                {
            new Axis
            {
                 Labels = dates.Select(d => DateTime.Parse(d).ToString("MM/dd")).ToArray(),
                LabelsRotation = 45,
                Name = "Date",
                TextSize = 9,
                ForceStepToMin = true,
                SeparatorsPaint = new SolidColorPaint(SKColors.LightGray, 1)
            }
                };

                // Configure Y-axis
                salesChart.YAxes = new Axis[]
                {
            new Axis
            {
                Name = "Sales (₱)",
                MinLimit = 0,
                TextSize = 12,
                SeparatorsPaint = new SolidColorPaint(SKColors.LightGray, 1),
                Labeler = value => value.ToString("N0") // Format numbers with thousands separator
            }
                };

                // Force chart update
                salesChart.CoreChart.Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading chart: {ex.Message}");
            }
            decimal grandTotal = sales.Values.Sum();
            label8.Text = $"₱{grandTotal:F2}";
        }

        private void label3_Click(object sender, EventArgs e)//show
        {
            sales.Clear();

            DateTime startDate = startDatePicker.Value.Date;
            DateTime endDate = endDatePicker.Value.Date;

            if (salesduration.SelectedItem == null)
            {
                MessageBox.Show("Please select a duration.");
                return;
            }

            string duration = salesduration.SelectedItem.ToString();
            if (duration == "Daily")
            {
                LoadDailySales(startDate, endDate); // Load daily sales data
            }
            else if (duration == "Weekly")
            {
                LoadWeeklySales(startDate, endDate);
            }
            else if (duration == "Monthly")
            {
                LoadMonthlySalesChart(startDate, endDate);
            }
            else
            {
                LoadYearlySalesChart(startDate, endDate);
            }
        }
        private void LoadMonthlySalesChart(DateTime startDate, DateTime endDate)
        {
            DashboardAdmin dash = new DashboardAdmin();
            var sales = dash.LoadMonthlySalesData(startDate, endDate);

            if (sales.Count == 0)
            {
                MessageBox.Show("No sales data available for the selected date range.");
                return;
            }

            try
            {
                // Process and sort monthly data
                var sortedData = sales
                    .OrderBy(x => DateTime.ParseExact(x.Key, "yyyy-MM", CultureInfo.InvariantCulture))
                    .ToList();

                var labels = sortedData
                    .Select(x => DateTime.ParseExact(x.Key, "yyyy-MM", CultureInfo.InvariantCulture))
                    .Select(d => d.ToString("MMM yyyy"))  // "Apr 2023" format
                    .ToArray();

                var values = sortedData.Select(x => (double)x.Value).ToArray();

                salesChart.Series = new ISeries[]
                {
            new LineSeries<double>
            {
                Values = values,
                Name = "Monthly Sales",
                Fill = null,
                LineSmoothness = 0.5,
                Stroke = new SolidColorPaint(SKColors.DeepSkyBlue, 3),
                GeometryStroke = new SolidColorPaint(SKColors.DeepSkyBlue, 3),
                GeometryFill = new SolidColorPaint(SKColors.White),
                GeometrySize = 10,
                DataLabelsPaint = new SolidColorPaint(SKColors.Black),
                DataLabelsPosition = LiveChartsCore.Measure.DataLabelsPosition.Top,
                DataLabelsFormatter = point => $"{point.Coordinate.PrimaryValue:N0}₱"
            }
                };

                salesChart.XAxes = new Axis[]
                {
            new Axis
            {
                Labels = labels,
                LabelsRotation = 45,
                Name = "Month",
                TextSize = 9,
                ForceStepToMin = true,
                SeparatorsPaint = new SolidColorPaint(SKColors.LightGray, 1)
            }
                };

                salesChart.YAxes = new Axis[]
                {
            new Axis
            {
                Name = "Sales (₱)",
                MinLimit = 0,
                TextSize = 12,
                SeparatorsPaint = new SolidColorPaint(SKColors.LightGray, 1),
                Labeler = value => value.ToString("N0")
            }
                };

                salesChart.CoreChart.Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading monthly chart: {ex.Message}\n" +
                              "Ensure data uses 'YYYY-MM' format (e.g. 2023-04)");
            }
            decimal grandTotal = sales.Values.Sum();
            label8.Text = $"₱{grandTotal:F2}";
        }


        private void LoadYearlySalesChart(DateTime startDate, DateTime endDate)
        {
            DashboardAdmin dash = new DashboardAdmin();
            var sales = dash.LoadYearlySalesData(startDate, endDate);

            if (sales.Count == 0)
            {
                MessageBox.Show("No sales data available for the selected date range.");
                return;
            }

            try
            {
                var sortedData = sales
                    .OrderBy(x => int.Parse(x.Key)) // Sort by year
                    .ToList();

                var labels = sortedData.Select(x => x.Key).ToArray(); // Year as string
                var values = sortedData.Select(x => (double)x.Value).ToArray();

                salesChart.Series = new ISeries[]
                {
            new LineSeries<double>
            {
                Values = values,
                Name = "Yearly Sales",
                Fill = null,
                LineSmoothness = 0.5,
                Stroke = new SolidColorPaint(SKColors.Orange, 3),
                GeometryStroke = new SolidColorPaint(SKColors.Orange, 3),
                GeometryFill = new SolidColorPaint(SKColors.White),
                GeometrySize = 10,
                DataLabelsPaint = new SolidColorPaint(SKColors.Black),
                DataLabelsPosition = LiveChartsCore.Measure.DataLabelsPosition.Top,
                DataLabelsFormatter = point => $"{point.Coordinate.PrimaryValue:N0}₱"
            }
                };

                salesChart.XAxes = new Axis[]
                {
            new Axis
            {
                Labels = labels,
                LabelsRotation = 0,
                Name = "Year",
                TextSize = 10,
                ForceStepToMin = true,
                SeparatorsPaint = new SolidColorPaint(SKColors.LightGray, 1)
            }
                };

                salesChart.YAxes = new Axis[]
                {
            new Axis
            {
                Name = "Sales (₱)",
                MinLimit = 0,
                TextSize = 12,
                SeparatorsPaint = new SolidColorPaint(SKColors.LightGray, 1),
                Labeler = value => value.ToString("N0")
            }
                };

                salesChart.CoreChart.Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading yearly chart: {ex.Message}\n" +
                              "Ensure data uses 'YYYY' format (e.g. 2023)");
            }
            decimal grandTotal = sales.Values.Sum();
            label8.Text = $"₱{grandTotal:F2}";
        }


        private void dayDate_ValueChanged(object sender, EventArgs e)
        {
            ShowHourlyDistribution(dayDate.Value.Date);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
