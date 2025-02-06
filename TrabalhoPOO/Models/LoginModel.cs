using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using TrabalhoPOO.Data;

namespace TrabalhoPOO.Models
{
    public class LoginModel
    {
        public bool ValidateUser(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return false;
            }

            var db = DataConnection.Instance;
            db.Open();

            try
            {
                using (SqlConnection con = new SqlConnection(db.Connection.ConnectionString))
                {
                    string query = "SELECT COUNT(*) FROM LoginTable WHERE Username = @Username AND Password = @Password";
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
                throw new Exception("Erro ao verificar usuário", ex);
            }
            finally
            {
                db.Close();
            }
        }
    }
}
