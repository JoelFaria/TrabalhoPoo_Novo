using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace TrabalhoPOO.Models
{
    public class LoadProducts
    {

        private string connectionString = "Data Source=JOELFARIA\\SQLEXPRESS;Initial Catalog=LoginApp;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public DataTable LoadStockData()
        {
            DataTable dataTable = new DataTable();
            string query = "SELECT * FROM StockTable";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    adapter.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    // Em vez de MessageBox (que é parte da View), lançamos a exceção ou tratamos de outra forma.
                    throw new Exception("Erro ao carregar dados: " + ex.Message);
                }
            }
            return dataTable;
        }

       
    }

}


