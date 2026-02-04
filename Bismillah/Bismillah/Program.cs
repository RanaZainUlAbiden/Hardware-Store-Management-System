using Bismillah.UI;

namespace Bismillah
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

 

            Application.Run(new AdminDashboard());



        }
    }
}




//private void RefreshProductOrderList()
//{
//    try
//    {
//        dgvProductOrders.DataSource = null; // Clear previous binding

//        var dt = _productOrderBL.GetAllProductOrders();

//        // Debug output to check if data is retrieved
//        Console.WriteLine($"Retrieved {dt.Rows.Count} rows");
//        if (dt.Rows.Count > 0)
//        {
//            Console.WriteLine($"First row: {dt.Rows[0]["order_id"]}");
//        }

//        dgvProductOrders.DataSource = dt;

//        // Ensure AutoGenerateColumns is true if you haven't manually defined columns
//        dgvProductOrders.AutoGenerateColumns = true;

//        // OR if you want manual column configuration:
//        if (dgvProductOrders.Columns.Count == 0 && dt.Columns.Count > 0)
//        {
//            // Add columns manually if they don't exist
//            foreach (DataColumn column in dt.Columns)
//            {
//                dgvProductOrders.Columns.Add(
//                    column.ColumnName,
//                    column.ColumnName);
//            }
//        }
//    }
//    catch (Exception ex)
//    {
//        MessageBox.Show($"Error loading product orders: {ex.Message}\n\n{ex.StackTrace}",
//                       "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//    }
//}
