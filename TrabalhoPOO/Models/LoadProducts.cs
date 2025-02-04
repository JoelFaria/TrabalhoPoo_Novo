using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace TrabalhoPOO.Models
{
    public class LoadProducts
    {

        private string connectionString = "Data Source=JOELFARIA\\SQLEXPRESS;Initial Catalog=LoginApp;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
       

        // Carrega dados do stock e retorna um DataTable
        public DataTable GetStockData()
        {
            string query = "SELECT * FROM StockTable";
            DataTable dataTable = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, con))
            {
                try
                {
                    con.Open();
                    adapter.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    // Lidar com o erro ou relançar a exceção
                    throw new Exception("Erro ao carregar dados: " + ex.Message);
                }
            }

            return dataTable;
        }

        // Retorna detalhes de uma GPU
        public Gpu GetGpuDetails(int productId)
        {
            Gpu gpu = null;
            string query = "SELECT ProductId, Nome, Preco, VRAM, BaseClock, OverClock FROM Gpu WHERE ProductId = @ProductId";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@ProductId", productId);
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        gpu = new Gpu
                        {
                            GetVRAM = int.Parse(reader["VRAM"].ToString()),
                            GetBaseClock = int.Parse(reader["BaseClock"].ToString()),
                            GetBoostClock = int.Parse(reader["OverClock"].ToString())


                            NomeProduto = reader["Nome"].ToString(),
                            PrecoProduto = double.Parse(reader["Preco"]),
                            CategoriaProduto = reader["Ca"]
                           
                        };
                    }
                }
            }

            return gpu;
        }

        // Retorna detalhes de uma CPU
        public CpuDetails GetCpuDetails(int productId)
        {
            CpuDetails details = null;
            string query = "SELECT Cache, Socket, MemorySupport, Frequency FROM Cpu WHERE ProductId = @ProductId";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@ProductId", productId);
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        details = new CpuDetails
                        {
                            Cache = reader["Cache"].ToString(),
                            Socket = reader["Socket"].ToString(),
                            MemorySupport = reader["MemorySupport"].ToString(),
                            Frequency = reader["Frequency"].ToString()
                        };
                    }
                }
            }

            return details;
        }

        // Retorna detalhes de uma placa-mãe
        public MotherboardDetails GetMotherboardDetails(int productId)
        {
            MotherboardDetails details = null;
            string query = "SELECT Socket, MemorySupport, FormFactor FROM Motherboard WHERE ProductId = @ProductId";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@ProductId", productId);
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        details = new MotherboardDetails
                        {
                            Socket = reader["Socket"].ToString(),
                            MemorySupport = reader["MemorySupport"].ToString(),
                            FormFactor = reader["FormFactor"].ToString()
                        };
                    }
                }
            }

            return details;
        }

        // Retorna detalhes de uma RAM
        public RamDetails GetRamDetails(int productId)
        {
            RamDetails details = null;
            string query = "SELECT Frequency, Capacity, Type, Latency FROM Ram WHERE ProductId = @ProductId";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@ProductId", productId);
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        details = new RamDetails
                        {
                            Frequency = reader["Frequency"].ToString(),
                            Capacity = reader["Capacity"].ToString(),
                            Type = reader["Type"].ToString(),
                            Latency = reader["Latency"].ToString()
                        };
                    }
                }
            }

            return details;
        }
    }
}

