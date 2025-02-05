using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoPOO.Models;
using TrabalhoPOO.Views;

namespace TrabalhoPOO.Controllers
{
    public class ProductController
    {
        private AddProduct repo;

        public ProductController()
        {
            this.repo = new AddProduct();
        }

        public bool AddNewProduct(Produto produto)
        {
            // Adiciona o produto principal à tabela StockTable e obtém o ID gerado
            int productId = repo.AddProductWithId(produto);

            bool sucesso = false;

            // Adiciona as informações específicas de cada tipo de produto
            if (produto is Gpu gpu)
            {
                sucesso = repo.AddGpu(gpu, productId);
                if (!sucesso)
                {
                    return false;
                }
            }
            else if (produto is Cpu cpu)
            {
                sucesso = repo.AddCpu(cpu, productId);
                if (!sucesso)
                {
                    return false;
                }
            }
            else if (produto is RAM ram)
            {
                sucesso = repo.AddRam(ram, productId);
                if (!sucesso)
                {
                    return false;
                }
            }
            else if (produto is Motherboard motherboard)
            {
                sucesso = repo.AddMotherboard(motherboard, productId);
                if (!sucesso)
                {
                    return false;
                }
            }
            else
            {
                // Tipo de produto desconhecido
                return false;
            }

            return true;
        }


     
    }
}

