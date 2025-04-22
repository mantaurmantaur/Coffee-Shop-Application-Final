using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COFFEE_SHOP_APPLICATION
{
    internal class DashboardAdmin : generalClass
    {
        public Dictionary<string, decimal> GetCategorySales()
        {
            Dictionary<string, decimal> categorySales = new Dictionary<string, decimal>();

            using (var connection = generalClass.GetConnection())
            {
                connection.Open();

                string query = @"SELECT Category, TotalSales FROM CategorySales ORDER BY Category";

                using (var cmd = new OleDbCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string category = reader["Category"].ToString();
                        decimal totalSales = Convert.ToDecimal(reader["TotalSales"]);
                        categorySales[category] = totalSales;
                    }
                }
            }

            return categorySales;
        }

        public Dictionary<string, decimal> GetMethodSales()
        {
            Dictionary<string, decimal> methodSales = new Dictionary<string, decimal>();

            using (var connection = generalClass.GetConnection())
            {
                connection.Open();

                string query = @"SELECT Method, TotalSales FROM PaymethodSales ORDER BY Method";

                using (var cmd = new OleDbCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string method = reader["Method"].ToString();
                        decimal totalSales = Convert.ToDecimal(reader["TotalSales"]);
                        methodSales[method] = totalSales;
                    }
                }
            }

            return methodSales;
        }


        public Dictionary<string, int> GetTopProducts()
        {
            Dictionary<string, int> topProducts = new Dictionary<string, int>();

            using (var connection = generalClass.GetConnection())
            {
                connection.Open();

                string query = @"SELECT ProductName, OrderCount FROM TopProducts ORDER BY OrderCount DESC";

                using (var cmd = new OleDbCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string prodName = reader["ProductName"].ToString();
                        int orderCount = Convert.ToInt32(reader["OrderCount"]);
                        topProducts[prodName] = orderCount;
                    }
                }
            }

            return topProducts;
        }

        public Dictionary<string, decimal> LoadMonthlySalesData(DateTime startDate, DateTime endDate)
        {
            Dictionary<string, decimal> sales = new Dictionary<string, decimal>();

            try
            {
                using (var connection = generalClass.GetConnection())
                {
                    connection.Open();

                    string query = @"
                SELECT 
                    Format([SaleDate], 'yyyy-MM') AS MonthKey,
                    SUM([TotalSales]) AS MonthlySales
                FROM [TotalSalesToday]
                WHERE [SaleDate] BETWEEN ? AND ?
                GROUP BY Format([SaleDate], 'yyyy-MM')
                ORDER BY Format([SaleDate], 'yyyy-MM')";

                    using (var cmd = new OleDbCommand(query, connection))
                    {
                        cmd.Parameters.Add(new OleDbParameter("StartDate", OleDbType.DBDate)).Value = startDate.Date;
                        cmd.Parameters.Add(new OleDbParameter("EndDate", OleDbType.DBDate)).Value = endDate.Date;

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string monthKey = reader["MonthKey"].ToString();
                                decimal total = Convert.ToDecimal(reader["MonthlySales"]);
                                sales[monthKey] = total;
                            }
                        }
                    }
                }

                DateTime currentMonth = new DateTime(startDate.Year, startDate.Month, 1);
                while (currentMonth <= endDate)
                {
                    string monthKey = currentMonth.ToString("yyyy-MM");
                    if (!sales.ContainsKey(monthKey))
                        sales[monthKey] = 0;

                    currentMonth = currentMonth.AddMonths(1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading monthly sales data: {ex.Message}");
            }

            return sales;
        }

        public Dictionary<string, decimal> LoadYearlySalesData(DateTime startDate, DateTime endDate)
        {
            var sales = new Dictionary<string, decimal>();

            try
            {
                using (var connection = generalClass.GetConnection())
                {
                    connection.Open();

                    string query = @"
                SELECT 
                    Format([SaleDate], 'yyyy') AS YearKey,
                    SUM([TotalSales]) AS YearlySales
                FROM [TotalSalesToday]
                WHERE [SaleDate] BETWEEN ? AND ?
                GROUP BY Format([SaleDate], 'yyyy')
                ORDER BY Format([SaleDate], 'yyyy')";

                    using (var cmd = new OleDbCommand(query, connection))
                    {
                        cmd.Parameters.Add(new OleDbParameter("StartDate", OleDbType.DBDate)).Value = startDate.Date;
                        cmd.Parameters.Add(new OleDbParameter("EndDate", OleDbType.DBDate)).Value = endDate.Date;

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string yearKey = reader["YearKey"].ToString();
                                decimal total = Convert.ToDecimal(reader["YearlySales"]);
                                sales[yearKey] = total;
                            }
                        }
                    }
                }

                // Fill missing years with 0
                for (int year = startDate.Year; year <= endDate.Year; year++)
                {
                    string yearKey = year.ToString();
                    if (!sales.ContainsKey(yearKey))
                    {
                        sales[yearKey] = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading yearly sales data: {ex.Message}\n" +
                                $"Date Range: {startDate:yyyy-MM-dd} to {endDate:yyyy-MM-dd}");
            }

            return sales;
        }
    }
}
