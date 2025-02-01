using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPOO.Models
{
    public class Cpu : Produto
    {
        private int Cache { get; set; } // Cache em MB
        private string Socket { get; set; } // Tipo de socket da CPU
        private string MemorySupport { get; set; } // Suporte de memória máximo em GB
        private int Frequency { get; set; } // Frequência base em MHz

        #region Construtores

        /// <summary>
        /// Construtor para inicializar um novo processador.
        /// </summary>
        /// <param name="cache">Cache do processador em MB.</param>
        /// <param name="socket">Socket do processador.</param>
        /// <param name="memorySupport">Suporte máximo de memória em GB.</param>
        /// <param name="frequency">Frequência base em MHz.</param>
        /// <param name="nome">Nome do produto.</param>
        /// <param name="descricao">Descrição do produto.</param>
        /// <param name="preco">Preço do produto.</param>
        /// <param name="cat">Categoria do produto.</param>
        /// <param name="stock">Quantidade em stock.</param>
        /// <param name="marca">Marca do produto.</param>
        /// <param name="garantia">Garantia do produto em meses.</param>
        public Cpu(int cache, string socket, string memorySupport, int frequency, string nome, string descricao, double preco, string cat, int stock, string marca, int garantia)
            : base(nome, descricao, preco, cat, stock, marca, garantia)
        {
            this.Cache = cache;
            this.Socket = socket;
            this.MemorySupport = memorySupport;
            this.Frequency = frequency;
        }

        #endregion

        #region Propriedades Públicas

        public int GetCache
        {
            get { return Cache; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("A cache deve ser maior que zero.");
                }
                Cache = value;
            }
        }

        public string GetSocket
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

        public string GetMemorySupport
        {
            get { return MemorySupport; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("O suporte de memória deve ser maior que zero.");
                }
                MemorySupport = value;
            }
        }
        public int GetFrequency
        {
            get { return Frequency; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("A frequência deve ser maior que zero.");
                }
                Frequency = value;
            }
        }
        #endregion
    }
}
