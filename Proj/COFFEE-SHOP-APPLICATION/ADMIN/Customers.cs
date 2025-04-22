using LiveChartsCore.SkiaSharpView.WinForms;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using LCAxis = LiveChartsCore.SkiaSharpView.Axis;
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
using System.Windows.Forms.DataVisualization.Charting;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;

namespace COFFEE_SHOP_APPLICATION.ADMIN
{
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void Customers_Load(object sender, EventArgs e)
        {
            LoadUsernamesFromDatabase();
            var list = GetTopCustomersSimple();
            var list1 = GetTopCustomersStars();
            if (list.Count > 0 || list1.Count > 0)
            {
                SetupSimpleChart();
                SetupSimpleChartPoints();
            }
            else
            {
                MessageBox.Show("No data available for top customers.");
            }

        }

        // Method to get simple top customers data
        private List<TopCustomer> GetTopCustomersSimple()
        {
            var customers = new List<TopCustomer>();

            using (var conn = generalClass.GetConnection())
            {
                conn.Open();
                string query = "SELECT *FROM [TopCustomerbasedonorders]";

                using (var cmd = new OleDbCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customers.Add(new TopCustomer
                        {
                            Username = reader["Username"].ToString(),
                            OrderCount = Convert.ToInt32(reader["OrderCount"])
                        });
                    }
                }
            }

            return customers;
        }

        private void LoadUsernamesFromDatabase()
        {
            DataTable dt = new DataTable();

            using (var myConn = generalClass.GetConnection())
            {
                myConn.Open();
                string query = "SELECT Username FROM Users WHERE Username <> 'Guest'";

                using (OleDbCommand cmd = new OleDbCommand(query, myConn))
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }

            customersView.DataSource = dt;
        }


        private List<TopCustomer> GetTopCustomersStars()
        {
            var customers = new List<TopCustomer>();

            using (var conn = generalClass.GetConnection())
            {
                conn.Open();
                string query = "SELECT *FROM [TopCustomerBasedonStars]";

                using (var cmd = new OleDbCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customers.Add(new TopCustomer
                        {
                            Username = reader["Username"].ToString(),
                            OrderCount = Convert.ToInt32(reader["Points"])
                        });
                    }
                }
            }

            return customers;
        }

        // Simple class for the data
        public class TopCustomer
        {
            public string Username { get; set; }
            public int OrderCount { get; set; }
        }

        private void SetupSimpleChart()
        {
            var topCustomers = GetTopCustomersSimple();

            topCustomersChart.Series = new ISeries[]
            {
            new ColumnSeries<int>
            {
                Values = topCustomers.Select(c => c.OrderCount).ToArray(),
                Name = "Total Orders",
                DataLabelsPaint = new SolidColorPaint(SKColors.White),
                DataLabelsPosition = LiveChartsCore.Measure.DataLabelsPosition.Top,
            }
            };

            topCustomersChart.XAxes = new[]
            {
            new LCAxis
            {
                Labels = topCustomers.Select(c => c.Username).ToArray(),
                LabelsRotation = 45,
                ForceStepToMin = true,
                Name = "Top Customers",
                TextSize = 10
            }
                };

            topCustomersChart.YAxes = new[]
            {
            new LCAxis
            {
                MinLimit = 0,
                Name = "Number of Orders"
            }
                };
        }

        private void SetupSimpleChartPoints()
        {
            var topCustomers = GetTopCustomersStars();

            mostStarsChart.Series = new ISeries[]
            {
        new LineSeries<int>
        {
            Values = topCustomers.Select(c => c.OrderCount).ToArray(),
            Name = "Points",
            DataLabelsPaint = new SolidColorPaint(SKColors.White),
            DataLabelsPosition = LiveChartsCore.Measure.DataLabelsPosition.Top,
            GeometrySize = 10, // Size of the point markers
            Fill = null        // Makes the line not filled below
        }
            };

            mostStarsChart.XAxes = new[]
            {
        new LCAxis
        {
            Labels = topCustomers.Select(c => c.Username).ToArray(),
            LabelsRotation = 45,
            ForceStepToMin = true,
            Name = "Top Customers",
            TextSize = 10
        }
    };

            mostStarsChart.YAxes = new[]
            {
        new LCAxis
        {
            MinLimit = 0,
            Name = "Points"
        }
    };
        }

    }
}
