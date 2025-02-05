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

        public DataTable GetInfo()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                SELECT 
                s.Id,
                s.Name,
                s.Description,
                s.Price,
                s.Type AS StockType,         -- Coluna do StockTable
                s.Stock,
                s.Brand,
                s.Guarantee,
                -- Colunas da tabela Ram (se houver)
                r.Capacity,
                r.Type AS RamType,           -- Diferencia o ""Type"" da RAM
                r.Frequency AS RamFrequency,
                r.Latency,
                -- Colunas da tabela Cpu
                c.Cache,
                c.Socket AS CpuSocket,
                c.MemorySupport AS CpuMemorySupport,
                c.Frequency AS CpuFrequency,
                -- Colunas da tabela Gpu
                g.VRAM,
                g.BaseClock,
                g.OverClock AS BoostClock,   -- Aqui, alias para o clock de boost
                -- Colunas da tabela Motherboard
                m.Socket AS MB_Socket,
                m.MemorySupport AS MB_MemorySupport,
                m.FormFactor
            FROM StockTable s
            LEFT JOIN Ram r ON s.Id = r.ProductId
            LEFT JOIN Cpu c ON s.Id = c.ProductId
            LEFT JOIN Gpu g ON s.Id = g.ProductId
            LEFT JOIN Motherboard m ON s.Id = m.ProductId;
            ";


                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
    }
}



