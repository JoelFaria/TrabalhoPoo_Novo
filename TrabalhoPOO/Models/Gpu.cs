using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPOO.Models
{
    /// <summary>
    /// Classe que representa uma GPU (placa gráfica), derivada da classe Produto.
    /// Contém propriedades específicas como VRAM, BaseClock e BoostClock.
    /// </summary>
    public class Gpu : Produto
    {
        private int VRAM { get; set; } // Memória VRAM em GB
        private int BaseClock { get; set; } // Frequência base em MHz
        private int BoostClock { get; set; } // Frequência boost em MHz

        #region Construtores
        /// <summary>
        /// Construtor para inicializar uma nova GPU.
        /// </summary>
        /// <param name="vram">Memória VRAM em GB.</param>
        /// <param name="baseClock">Frequência base em MHz.</param>
        /// <param name="boostClock">Frequência boost em MHz.</param>
        /// <param name="nome">Nome do produto.</param>
        /// <param name="descricao">Descrição do produto.</param>
        /// <param name="preco">Preço do produto.</param>
        /// <param name="cat">Categoria do produto.</param>
        /// <param name="stock">Quantidade em stock.</param>
        /// <param name="marca">Marca do produto.</param>
        /// <param name="garantia">Garantia do produto em meses.</param>
        public Gpu(int vram, int baseClock, int boostClock, string nome, string descricao, double preco, string cat, int stock, string marca, int garantia)
            : base(nome, descricao, preco, cat, stock, marca, garantia)
        {
            this.VRAM = vram;
            this.BaseClock = baseClock;
            this.BoostClock = boostClock;
        }

        #endregion

        #region Propriedades Públicas
        public int GetVRAM
        {
            get { return VRAM; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("A VRAM deve ser maior que zero.");
                }
                VRAM = value;
            }
        }

        public int GetBaseClock
        {
            get { return BaseClock; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("A frequência base deve ser maior que zero.");
                }
                BaseClock = value;
            }
        }
        public int GetBoostClock
        {
            get { return BoostClock; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("A frequência boost deve ser maior que zero.");
                }
                BoostClock = value;
            }
        }
        #endregion
    }
}
