using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bismillah.DL
{
    public class DatabaseHelper
    {
        private string serverName = "127.0.0.1";
        private string port = "3306";
        private string databaseName = "bismillah";
        private string databaseUser = "root";

        private string databasePassword = "Ahadsaab@263";

     


        private DatabaseHelper() { }

        private static DatabaseHelper _instance;

        public static DatabaseHelper Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DatabaseHelper();
                return _instance;
            }
        }

        public int Update(string query, params MySqlParameter[] parameters)
        {
            using (var connection = getConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddRange(parameters);
                    return command.ExecuteNonQuery();
                }
            }
        }

        public object ExecuteScalar(string query)
        {
            using (var connection = getConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand(query, connection))
                {
                    return command.ExecuteScalar();
                }
            }
        }

        public DataTable GetDataTable(string query)
        {
            using (var connection = getConnection())
            {
                connection.Open();
                using (var adapter = new MySqlDataAdapter(query, connection))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetDataTable(string query, params MySqlParameter[] parameters)
        {
            using (var connection = getConnection())
            {
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddRange(parameters);
                    using (var adapter = new MySqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public object ExecuteScalar(string query, params MySqlParameter[] parameters)
        {
            using (var connection = getConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddRange(parameters);
                    return command.ExecuteScalar();
                }
            }
        }

        public static string FormatAsPKR(decimal amount)
        {
            return string.Format("Rs. {0:#,##0.00}", amount);
        }

        public MySqlConnection getConnection()
        {
            string connectionString = $"server={serverName};port={port};user={databaseUser};database={databaseName};password={databasePassword};SslMode=Required;";
            return new MySqlConnection(connectionString);
        }

        public MySqlDataReader GetDataReader(string query)
        {
            var connection = getConnection();
            connection.Open();
            var command = new MySqlCommand(query, connection);
            return command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        }

        public int Update(string query)
        {
            using (var connection = getConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand(query, connection))
                {
                    return command.ExecuteNonQuery();
                }
            }
        }

        public DataTable ExecuteQuery(string query)
        {
            using (var connection = getConnection())
            {
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var adapter = new MySqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public int Scaler(string query)
        {
            using (var connection = getConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand(query, connection))
                {
                    object result = command.ExecuteScalar();
                    return result == null ? 0 : Convert.ToInt32(result);
                }
            }
        }

        // New helper method for product operations
        public decimal GetProductPrice(int productId)
        {
            string query = "SELECT unit_price FROM products WHERE product_id = @productId";
            using (var connection = getConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@productId", productId);
                    object result = command.ExecuteScalar();
                    return result == null ? 0 : Convert.ToDecimal(result);
                }
            }
        }

        // New helper method for product operations
        public bool UpdateProductPrice(int productId, decimal newPrice)
        {
            string query = "UPDATE products SET unit_price = @price, last_updated = NOW() WHERE product_id = @productId";
            using (var connection = getConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@price", newPrice);
                    command.Parameters.AddWithValue("@productId", productId);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        // New helper method for product operations
        public DataTable GetAllProductsWithStock()
        {
            string query = @"
                SELECT 
                    p.product_id,
                    p.name AS product_name,
                    l.value AS category,
                    p.size,
                    p.unit_price,
                    COALESCE(SUM(s.quantity_in_stock), 0) AS stock_quantity
                FROM products p
                JOIN lookup l ON p.category_id = l.lookup_id
                LEFT JOIN stock s ON p.product_id = s.product_id
                GROUP BY p.product_id
                ORDER BY p.name";

            return GetDataTable(query);
        }



        




    }
}