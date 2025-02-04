using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TrabalhoPOO.Models;
using TrabalhoPOO.Views;

namespace TrabalhoPOO.Controllers
{
    public class LoadController
    {
        private LoadProducts load;

        public ProductController()
        {
            this.load = new LoadProducts();
        }

        public DataTable GetStockTable() 
        {
            return load.GetAllStock();
        }
        public DataRow GetGpuDetails(int productId)
        {
            return load.GetGpuDetails(productId);
        }
    }
}
