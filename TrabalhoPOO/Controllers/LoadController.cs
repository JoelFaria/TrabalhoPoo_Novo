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
        private LoadProducts load;
        private StockView stockView;

        public StockController(StockView view)
        {
            this.stockView = view;
            this.productRepository = new ProductRepository();
        }

        public void LoadProductDetails(int productId)
        {
            Produto produto = productRepository.GetProductById(productId);

            if (produto != null)
            {
                stockView.SetProductDetails(produto);
            }
            else
            {
                MessageBox.Show("Produto não encontrado.");
            }
        }
    }
}