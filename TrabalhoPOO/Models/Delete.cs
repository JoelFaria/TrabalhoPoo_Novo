using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoPOO.Models;
using Microsoft.Data.SqlClient;

namespace TrabalhoPOO.Models
{
    public class Delete
    {
        private string connectionString = "Data Source=JOELFARIA\\SQLEXPRESS;Initial Catalog=LoginApp;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public bool DeleteProduct(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Eliminar registros de tabelas específicas
                    string deleteGpu = "DELETE FROM Gpu WHERE ProductId = @ProductId";
                    string deleteCpu = "DELETE FROM Cpu WHERE ProductId = @ProductId";
                    string deleteMotherboard = "DELETE FROM Motherboard WHERE ProductId = @ProductId";
                    string deleteRam = "DELETE FROM Ram WHERE ProductId = @ProductId";

                    using (SqlCommand cmdGpu = new SqlCommand(deleteGpu, conn))
                    {
                        cmdGpu.Parameters.AddWithValue("@ProductId", id);
                        cmdGpu.ExecuteNonQuery();
                    }

                    using (SqlCommand cmdCpu = new SqlCommand(deleteCpu, conn))
                    {
                        cmdCpu.Parameters.AddWithValue("@ProductId", id);
                        cmdCpu.ExecuteNonQuery();
                    }

                    using (SqlCommand cmdMotherboard = new SqlCommand(deleteMotherboard, conn))
                    {
                        cmdMotherboard.Parameters.AddWithValue("@ProductId", id);
                        cmdMotherboard.ExecuteNonQuery();
                    }

                    using (SqlCommand cmdRam = new SqlCommand(deleteRam, conn))
                    {
                        cmdRam.Parameters.AddWithValue("@ProductId", id);
                        cmdRam.ExecuteNonQuery();
                    }

                    // Eliminar o registro principal na tabela StockTable
                    string deleteStock = "DELETE FROM StockTable WHERE Id = @Id";
                    using (SqlCommand cmdStock = new SqlCommand(deleteStock, conn))
                    {
                        cmdStock.Parameters.AddWithValue("@Id", id);
                        int rowsAffected = cmdStock.ExecuteNonQuery();

                        // Verificar se algum registro foi removido
                        if (rowsAffected == 0)
                        {
                            throw new ArgumentException("Nenhum produto encontrado com o Id especificado.");
                        }
                    }
                }

                return true; // Produto eliminado com sucesso
            }
            catch (Exception ex)
            {
                // Registar ou lançar a exceção
                throw new ArgumentException("Erro ao eliminar o produto.", ex);
            }
        }
    }
}
