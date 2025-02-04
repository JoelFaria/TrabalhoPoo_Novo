using Microsoft.Identity.Client;
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

    public class StockController
    {
        private LoadProducts loadProducts;

        public StockController()
        {
            loadProducts = new LoadProducts();
        }

        
        
    }
}