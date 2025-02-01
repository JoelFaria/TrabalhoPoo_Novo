using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPOO.Models
{
     public abstract class Produto
     {
         // Propriedades privadas
         private string Nome { get; set; } // Nome do produto
         private int Id { get; set; } // Identificador único do produto
         private string Descricao { get; set; } // Descrição detalhada do produto
         private double Preco { get; set; } // Preço do produto
         private string Cat { get; set; } // Categoria do produto
         private int Stock { get; set; } // Quantidade em stock
         private string Marca { get; set; } // Marca do produto
         private int GarantiaMeses { get; set; } // Garantia em meses

         #region Construtores
         /// <summary>
         /// Construtor para inicializar as propriedades de um produto.
         /// </summary>
         /// <param name="nome">Nome do produto.</param>
         /// <param name="descricao">Descrição detalhada.</param>
         /// <param name="preco">Preço do produto.</param>
         /// <param name="cat">Categoria do produto.</param>
         /// <param name="stock">Quantidade em stock.</param>
         /// <param name="marca">Marca do produto.</param>
         /// <param name="garantia">Garantia do produto em meses.</param>
         public Produto(string nome, string descricao, double preco, string cat, int stock, string marca, int garantia)
         {
             this.Nome = nome;
             this.Descricao = descricao;
             this.Preco = preco;
             this.Cat = cat;
             this.Stock = stock;
             this.Marca = marca;
             this.GarantiaMeses = garantia;
         }
         #endregion

         #region Propriedades Públicas

         public string NomeProduto
         {
             get { return Nome; }
             set
             {
                 if (string.IsNullOrWhiteSpace(value))
                 {
                     throw new ArgumentException("O nome do produto não pode ser vazio.");
                 }
                 Nome = value;
             }
         }
         public string DescricaoProduto
         {
             get { return Descricao; }
             set
             {
                 if (string.IsNullOrWhiteSpace(value))
                 {
                     throw new ArgumentException("A descrição não pode ser vazia.");
                 }
                 Descricao = value;
             }
         }

         public double PrecoProduto
         {
             get { return Preco; }
             set
             {
                 if (value <= 0)
                 {
                     throw new ArgumentException("O preço deve ser maior que zero.");
                 }
                 Preco = value;
             }
         }

         public string CategoriaProduto
         {
             get { return Cat; }
             set
             {
                 if (string.IsNullOrWhiteSpace(value))
                 {
                     throw new ArgumentException("A categoria não pode ser vazia.");
                 }
                 Cat = value;
             }
         }

         public int StockProduto
         {
             get { return Stock; }
             set
             {
                 if (value < 0)
                 {
                     throw new ArgumentException("O stock não pode ser negativo.");
                 }
                 Stock = value;
             }
         }

         public string MarcaProduto
         {
             get { return Marca; }
             set
             {
                 if (string.IsNullOrWhiteSpace(value))
                 {
                     throw new ArgumentException("A marca não pode ser vazia.");
                 }
                 Marca = value;
             }
         }

         public int GarantiaMesesProdutos
         {
             get { return GarantiaMeses; }
             set
             {
                 if (value < 0)
                 {
                     throw new ArgumentException("A garantia não pode ser negativa.");
                 }
                 GarantiaMeses = value;
             }
         }
         #endregion
     }
}