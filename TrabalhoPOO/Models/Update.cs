using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoPOO.Models;
using Microsoft.Data.SqlClient;

namespace TrabalhoPOO.Models
{
    public class Update
    {
        private string connectionString = "Data Source=JOELFARIA\\SQLEXPRESS;Initial Catalog=LoginApp;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public bool UpdateProduct(Produto produto, int Id)
        {
            try
            {
                // Estabelece a conexão com o banco de dados
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Atualiza a tabela StockTable com os dados do produto
                    string queryStock = "UPDATE StockTable SET Name = @Name, Description = @Description, Price = @Price, " +
                                        "Type = @Type, Stock = @Stock, Brand = @Brand, Guarantee = @Guarantee WHERE Id = @Id";

                    using (SqlCommand cmdStock = new SqlCommand(queryStock, conn))
                    {
                        // Adiciona os parâmetros à consulta
                        cmdStock.Parameters.AddWithValue("@Name", produto.NomeProduto);
                        cmdStock.Parameters.AddWithValue("@Description", produto.DescricaoProduto);
                        cmdStock.Parameters.AddWithValue("@Price", produto.PrecoProduto);
                        cmdStock.Parameters.AddWithValue("@Type", produto.CategoriaProduto);
                        cmdStock.Parameters.AddWithValue("@Stock", produto.StockProduto);
                        cmdStock.Parameters.AddWithValue("@Brand", produto.MarcaProduto);
                        cmdStock.Parameters.AddWithValue("@Guarantee", produto.GarantiaMesesProdutos);
                        cmdStock.Parameters.AddWithValue("@Id", Id);

                        // Executa a consulta para atualizar a tabela StockTable
                        cmdStock.ExecuteNonQuery();
                    }

                    // Atualiza a tabela específica com base no tipo do produto
                    switch (produto)
                    {
                        case Gpu gpu:
                            // Atualiza a tabela Gpu com os dados específicos da GPU
                            string queryGpu = "UPDATE Gpu SET VRAM = @VRAM, BaseClock = @BaseClock, OverClock = @OverClock WHERE ProductId = @ProductId";
                            using (SqlCommand cmdGpu = new SqlCommand(queryGpu, conn))
                            {
                                cmdGpu.Parameters.AddWithValue("@ProductId", Id);
                                cmdGpu.Parameters.AddWithValue("@VRAM", gpu.GetVRAM);
                                cmdGpu.Parameters.AddWithValue("@BaseClock", gpu.GetBaseClock);
                                cmdGpu.Parameters.AddWithValue("@OverClock", gpu.GetBoostClock);
                                cmdGpu.ExecuteNonQuery();
                            }
                            break;

                        case Cpu cpu:
                            // Atualiza a tabela Cpu com os dados específicos da CPU
                            string queryCpu = "UPDATE Cpu SET Cache = @Cache, Socket = @Socket, MemorySupport = @MemorySupport, Frequency = @Frequency WHERE ProductId = @ProductId";
                            using (SqlCommand cmdCpu = new SqlCommand(queryCpu, conn))
                            {
                                cmdCpu.Parameters.AddWithValue("@ProductId", Id);
                                cmdCpu.Parameters.AddWithValue("@Cache", cpu.GetCache);
                                cmdCpu.Parameters.AddWithValue("@Socket", cpu.GetSocket);
                                cmdCpu.Parameters.AddWithValue("@MemorySupport", cpu.GetMemorySupport);
                                cmdCpu.Parameters.AddWithValue("@Frequency", cpu.GetFrequency);
                                cmdCpu.ExecuteNonQuery();
                            }
                            break;

                        case Motherboard motherboard:
                            // Atualiza a tabela Motherboard com os dados específicos da placa-mãe
                            string queryMotherboard = "UPDATE Motherboard SET Socket = @Socket, MemorySupport = @MemorySupport, FormFactor = @FormFactor WHERE ProductId = @ProductId";
                            using (SqlCommand cmdMotherboard = new SqlCommand(queryMotherboard, conn))
                            {
                                cmdMotherboard.Parameters.AddWithValue("@ProductId", Id);
                                cmdMotherboard.Parameters.AddWithValue("@Socket", motherboard.SocketMotherboard);
                                cmdMotherboard.Parameters.AddWithValue("@MemorySupport", motherboard.MemorySupportMotherboard);
                                cmdMotherboard.Parameters.AddWithValue("@FormFactor", motherboard.FormFactorMotherboard);
                                cmdMotherboard.ExecuteNonQuery();
                            }
                            break;

                        case RAM ram:
                            // Atualiza a tabela Ram com os dados específicos da RAM
                            string queryRam = "UPDATE Ram SET Capacity = @Capacity, Type = @Type, Frequency = @Frequency, Latency = @Latency WHERE ProductId = @ProductId";
                            using (SqlCommand cmdRam = new SqlCommand(queryRam, conn))
                            {
                                cmdRam.Parameters.AddWithValue("@ProductId", Id);
                                cmdRam.Parameters.AddWithValue("@Capacity", ram.GetCapacity);
                                cmdRam.Parameters.AddWithValue("@Type", ram.GetType);
                                cmdRam.Parameters.AddWithValue("@Frequency", ram.GetFrequency);
                                cmdRam.Parameters.AddWithValue("@Latency", ram.GetLatency);
                                cmdRam.ExecuteNonQuery();
                            }
                            break;

                        default:
                            // Lança uma exceção se o tipo de produto for desconhecido
                            throw new ArgumentException("Tipo de produto desconhecido.");
                    }

                    return true; // Retorna true se a atualização for bem-sucedida
                }
            }
            catch (Exception ex)
            {
                // Lança uma exceção se ocorrer um erro durante a atualização
                throw new Exception("Erro ao atualizar o produto.", ex);
            }
        }
    }
}
