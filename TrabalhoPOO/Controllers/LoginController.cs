using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Microsoft.Data.SqlClient;
namespace TrabalhoPOO.Controllers
{
    public class LoginController
    {
        public string connectionString = "Data Source=JOELFARIA\SQLEXPRESS;Initial Catalog = LoginApp; Integrated Security = True; Encrypt=True;TrustServerCertificate=True";
        public string query = "SELECT COUNT(*) FROM LoginTable WHERE Username = @Username AND Password = @Password";

        public bool ValidateUser(string username, string password)
        {

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return false;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    con.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();

                    return count > 0;

                }
            } 
            catch (Exception ex) 
            {
                throw new Exception("Erro na verificaçao de usuario", ex);
            }
        }
    }
}
