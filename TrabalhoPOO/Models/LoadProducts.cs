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

        public Produto GetProductById(int productId)
        {
            Produto produto = null;
            string query = @"
        SELECT 
            s.Id, s.Name, s.Description, s.Price, s.Stock, s.Brand, s.Guarantee, s.Type,
            g.VRAM, g.BaseClock, g.OverClock,
            c.Cache, c.MemorySupport, c.Socket, c.Frequency,
            m.Socket AS MB_Socket, m.MemorySupport AS MB_MemorySupport, m.FormFactor,
            r.Capacity, r.Frequency AS RAM_Frequency, r.Latency, r.Type AS RAM_Type
        FROM StockTable s
        LEFT JOIN Gpu g ON s.Id = g.ProductId
        LEFT JOIN Cpu c ON s.Id = c.ProductId
        LEFT JOIN Motherboard m ON s.Id = m.ProductId
        LEFT JOIN Ram r ON s.Id = r.ProductId
        WHERE s.Id = @ProductId";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ProductId", productId);
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string type = reader["Type"].ToString();

                            switch (type)
                            {
                                case "Gpu":
                                    produto = new Gpu(
                                        vram: Convert.ToInt32(reader["VRAM"]),
                                        baseClock: Convert.ToInt32(reader["BaseClock"]),
                                        boostClock: Convert.ToInt32(reader["OverClock"]),
                                        nome: reader["Name"].ToString(),
                                        descricao: reader["Description"].ToString(),
                                        preco: Convert.ToDouble(reader["Price"]),
                                        cat: reader["Category"].ToString(),
                                        stock: Convert.ToInt32(reader["Stock"]),
                                        marca: reader["Brand"].ToString(),
                                        garantia: Convert.ToInt32(reader["Guarantee"])
                                        
                                    );
                                    break;

                                case "Cpu":
                                    produto = new Cpu(
                                        cache: Convert.ToInt32(reader["Cache"]),
                                        socket: reader["Socket"].ToString(),
                                        memorySupport: reader["MemorySupport"].ToString(),
                                        frequency: Convert.ToInt32(reader["Frequency"]),
                                        nome: reader["Name"].ToString(),
                                        descricao: reader["Description"].ToString(),
                                        preco: Convert.ToDouble(reader["Price"]),
                                        cat: reader["Category"].ToString(),
                                        stock: Convert.ToInt32(reader["Stock"]),
                                        marca: reader["Brand"].ToString(),
                                        garantia: Convert.ToInt32(reader["Guarantee"])
                                      
                                    );
                                    break;

                                case "Ram":
                                    produto = new RAM(
                                        capacity: Convert.ToInt32(reader["Capacity"]),
                                        type: reader["RAM_Type"].ToString(),
                                        frequency: Convert.ToInt32(reader["RAM_Frequency"]),
                                        latency: Convert.ToInt32(reader["Latency"]),                                  
                                        nome: reader["Name"].ToString(),
                                        descricao: reader["Description"].ToString(),
                                        preco: Convert.ToDouble(reader["Price"]),
                                        cat: reader["Category"].ToString(),
                                        stock: Convert.ToInt32(reader["Stock"]),
                                        marca: reader["Brand"].ToString(),
                                        garantia: Convert.ToInt32(reader["Guarantee"])
                                    );
                                    break;

                                case "Motherboard":
                                    produto = new Motherboard(
                                        socket: reader["Socket"].ToString(),
                                        memorySupport: reader["MemorySupport"].ToString(),
                                        formFactor: reader["FormFactor"].ToString(),
                                        nome: reader["Name"].ToString(),
                                        descricao: reader["Description"].ToString(),
                                        preco: Convert.ToDouble(reader["Price"]),
                                        cat: reader["Category"].ToString(),
                                        stock: Convert.ToInt32(reader["Stock"]),
                                        marca: reader["Brand"].ToString(),
                                        garantia: Convert.ToInt32(reader["Guarantee"])
                                        );
                                    break;
                            }
                        }
                    }
                }
            }
            return produto;
        }

    }

}


