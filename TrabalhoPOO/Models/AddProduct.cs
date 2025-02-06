using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using TrabalhoPOO.Data;

namespace TrabalhoPOO.Models
{
    public class AddProduct
    {
        

        public int AddProductWithId(Produto produto)
        {
            // Consulta SQL para inserir um novo produto e retornar o ID gerado
            string query = "INSERT INTO StockTable (name, description, price, stock, brand, guarantee, type) " +
                "OUTPUT INSERTED.Id VALUES (@name, @description, @price, @stock, @brand, @guarantee, @type)";

            var db = DataConnection.Instance;
            db.Open();

            try
            {

                using (SqlConnection con = new SqlConnection(db.Connection.ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Adiciona os parâmetros à consulta
                        cmd.Parameters.AddWithValue("@name", produto.NomeProduto);
                        cmd.Parameters.AddWithValue("@description", produto.DescricaoProduto);
                        cmd.Parameters.AddWithValue("@price", produto.PrecoProduto);
                        cmd.Parameters.AddWithValue("@stock", produto.StockProduto);
                        cmd.Parameters.AddWithValue("@brand", produto.MarcaProduto);
                        cmd.Parameters.AddWithValue("@guarantee", produto.GarantiaMesesProdutos);
                        cmd.Parameters.AddWithValue("@type", produto.CategoriaProduto);

                        // Executa a consulta e retorna o ID do produto gerado
                        return (int)cmd.ExecuteScalar();
                    }
                }
            }
            finally
            {
                db.Close();

            }
        }

        public bool AddCpu(Cpu cpu, int ProductId)
        {
            string query = "INSERT INTO Cpu (ProductId, [Cache], Socket, MemorySupport, Frequency) " +
                          "VALUES (@ProductId, @Cache, @Socket, @MemorySupport, @Frequency)";

            var db = DataConnection.Instance;
            db.Open();

            try
            {
                // Estabelece a conexão com o banco de dados
                using (SqlConnection conn = new SqlConnection(db.Connection.ConnectionString))
                {
                    conn.Open();
                    // Consulta SQL para inserir uma nova CPU


                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Adiciona os parâmetros à consulta
                        cmd.Parameters.AddWithValue("@ProductId", ProductId);
                        cmd.Parameters.AddWithValue("@Cache", cpu.GetCache);
                        cmd.Parameters.AddWithValue("@Socket", cpu.GetSocket);
                        cmd.Parameters.AddWithValue("@MemorySupport", cpu.GetMemorySupport);
                        cmd.Parameters.AddWithValue("@Frequency", cpu.GetFrequency);

                        // Executa a consulta para inserir a CPU
                        cmd.ExecuteNonQuery();
                    }
                }
                return true; // Retorna true se a inserção for bem-sucedida
            }
            catch
            {
                return false; // Retorna false se ocorrer um erro
            }
            finally
            {
                db.Close();
            }
        }

        public bool AddRam(RAM ram, int ProductId)
        {
            string query = "INSERT INTO Ram (ProductId, Capacity, Type, Frequency, Latency) " +
                                   "VALUES (@ProductId, @Capacity, @Type, @Frequency, @Latency)";

            var db = DataConnection.Instance;
            db.Open();

            try
            {
                // Estabelece a conexão com o banco de dados
                using (SqlConnection conn = new SqlConnection(db.Connection.ConnectionString))
                {
                    conn.Open();
                    // Consulta SQL para inserir uma nova RAM


                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Adiciona os parâmetros à consulta
                        cmd.Parameters.AddWithValue("@ProductId", ProductId);
                        cmd.Parameters.AddWithValue("@Capacity", ram.GetCapacity);
                        cmd.Parameters.AddWithValue("@Type", ram.GetType);
                        cmd.Parameters.AddWithValue("@Frequency", ram.GetFrequency);
                        cmd.Parameters.AddWithValue("@Latency", ram.GetLatency);

                        // Executa a consulta para inserir a RAM
                        cmd.ExecuteNonQuery();
                    }
                }
                return true; // Retorna true se a inserção for bem-sucedida
            }
            catch
            {
                return false; // Retorna false se ocorrer um erro
            }
            finally
            {
                db.Close();
            }
        }

        public bool AddMotherboard(Motherboard motherboard, int ProductId)
        {
            string query = "INSERT INTO Motherboard (ProductId, Socket, MemorySupport, FormFactor) " +
                                 "VALUES (@ProductId, @Socket, @MemorySupport, @FormFactor)";

            var db = DataConnection.Instance;
            db.Open();

            try
            {
                // Estabelece a conexão com o banco de dados
                using (SqlConnection conn = new SqlConnection(db.Connection.ConnectionString))
                {
                    conn.Open();
                    // Consulta SQL para inserir uma nova placa-mãe


                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Adiciona os parâmetros à consulta
                        cmd.Parameters.AddWithValue("@ProductId", ProductId);
                        cmd.Parameters.AddWithValue("@Socket", motherboard.SocketMotherboard);
                        cmd.Parameters.AddWithValue("@MemorySupport", motherboard.MemorySupportMotherboard);
                        cmd.Parameters.AddWithValue("@FormFactor", motherboard.FormFactorMotherboard);

                        // Executa a consulta para inserir a placa-mãe
                        cmd.ExecuteNonQuery();
                    }
                }
                return true; // Retorna true se a inserção for bem-sucedida
            }
            catch
            {
                return false; // Retorna false se ocorrer um erro
            }
            finally
            {
                db.Close();
            }
        }
        public bool AddGpu(Gpu gpu, int ProductId)
        {
            string query = "INSERT INTO Gpu (ProductId, VRAM, BaseClock, OverClock) " +
                                   "VALUES (@ProductId, @VRAM, @BaseClock, @OverClock)";

            var db = DataConnection.Instance;
            db.Open();

            try
            {
                // Estabelece a conexão com o banco de dados
                using (SqlConnection conn = new SqlConnection(db.Connection.ConnectionString))
                {
                    conn.Open();
                    // Consulta SQL para inserir uma nova GPU


                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Adiciona os parâmetros à consulta
                        cmd.Parameters.AddWithValue("@ProductId", ProductId);
                        cmd.Parameters.AddWithValue("@VRAM", gpu.GetVRAM);
                        cmd.Parameters.AddWithValue("@BaseClock", gpu.GetBaseClock);
                        cmd.Parameters.AddWithValue("@OverClock", gpu.GetBoostClock);

                        // Executa a consulta para inserir a GPU
                        cmd.ExecuteNonQuery();
                    }
                }
                return true; // Retorna true se a inserção for bem-sucedida
            }
            catch
            {
                return false; // Retorna false se ocorrer um erro
            }
            finally
            {
                db.Close();
            }
        }
    }
}
