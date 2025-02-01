using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPOO.Models
{
    public class Motherboard : Produto
    {
        // Propriedades específicas da motherboard 
        private string Socket { get; set; } // Tipo de socket suportado
        private string MemorySupport { get; set; } // Capacidade máxima de memória suportada (em GB)
        private string FormFactor { get; set; } // Tipo de formato da placa (e.g., ATX, Micro-ATX)

        #region Construtores

        /// <summary>
        /// Construtor que inicializa uma motherboard com as suas características específicas.
        /// </summary>
        /// <param name="socket">Tipo de socket suportado.</param>
        /// <param name="memorySupport">Capacidade máxima de memória suportada.</param>
        /// <param name="formFactor">Formato físico da motherboard.</param>
        /// <param name="nome">Nome do produto.</param>
        /// <param name="descricao">Descrição do produto.</param>
        /// <param name="preco">Preço do produto.</param>
        /// <param name="cat">Categoria do produto.</param>
        /// <param name="stock">Quantidade em stock.</param>
        /// <param name="marca">Marca do produto.</param>
        /// <param name="garantia">Garantia do produto em meses.</param>
        public Motherboard(string socket, string memorySupport, string formFactor, string nome, string descricao, double preco, string cat, int stock, string marca, int garantia)
            : base(nome, descricao, preco, cat, stock, marca, garantia)
        {
            this.Socket = socket;
            this.MemorySupport = memorySupport;
            this.FormFactor = formFactor;
        }

        #endregion

        #region Propriedades Públicas>
        public string SocketMotherboard
        {
            get { return Socket; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("O socket não pode ser vazio.");
                }
                Socket = value;
            }
        }

        public string MemorySupportMotherboard
        {
            get { return MemorySupport; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("A capacidade de memória deve ser maior que zero.");
                }
                MemorySupport = value;
            }
        }
        public string FormFactorMotherboard
        {
            get { return FormFactor; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("O formato físico não pode ser vazio.");
                }
                FormFactor = value;
            }
        }
        #endregion
    }
}
