using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using TrabalhoPOO.Models;
using TrabalhoPOO;
using TrabalhoPOO.Controllers;

namespace TrabalhoPOO.Views
{

    public partial class AdminForm : Form
    {

        private ProductController produtoController;
        private LoadProducts LoadProducts;

        public AdminForm()
        {
            InitializeComponent();

            comboBox1.Items.Add("GPU");
            comboBox1.Items.Add("CPU");
            comboBox1.Items.Add("RAM");
            comboBox1.Items.Add("Motherboard");

            produtoController = new ProductController();

            HideFields();

            LoadProducts.LoadStockData();

        }


        #region Login

        // Botão para voltar ao formulário de login
        private void button4_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        #endregion

        #region Metodo de salvar produtos

       

        /// <summary>
        /// Manipula o evento de clique do botão 2. 
        /// Salva o produto no banco de dados e atualiza os dados do estoque na interface.
        /// </summary>
        /// <param name="sender">O objeto que disparou o evento.</param>
        /// <param name="e">Os dados do evento.</param>
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string tipo = comboBox1.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(tipo)) 
                {
                    MessageBox.Show("Selecione um tipo de produto.");
                }

                string nome = textName.Text;
                string descricao = textDescription.Text;
                double preco = double.Parse(textPrice.Text);
                int stock = int.Parse(textStock.Text);
                string marca = textBrand.Text;
                int garantia = int.Parse(textGuarantee.Text);


                bool sucesso = false;

                switch (tipo.ToLower())
                {
                    case "gpu":
                        int vram = int.Parse(textVRAM.Text);
                        int baseclock = int.Parse(textBaseClock.Text);
                        int boostclock = int.Parse(textBoostClock.Text);
                        Gpu gpu = new Gpu(vram, baseclock, boostclock, nome, descricao, preco, tipo, stock, marca, garantia);
                        sucesso = produtoController.AddNewProduct(gpu);

                        break;

                    case "cpu":
                        int cache = int.Parse(textCache.Text);
                        string socket = textSocket.Text;
                        string memorySupport = textMem.Text;
                        int frequency = int.Parse(textFrequency.Text);
                        Cpu cpu = new Cpu(cache, socket, memorySupport, frequency, nome, descricao, preco, tipo, stock, marca, garantia);
                        sucesso = produtoController.AddNewProduct(cpu);
                        break;

                    case "motherboard":
                        string socketMB = textSocketMB.Text;
                        string memorySupportMB = textMemorySupport.Text;
                        string formFactor = textFormFactor.Text;
                        Motherboard motherboard = new Motherboard(socketMB, memorySupportMB, formFactor, nome, descricao, preco, tipo, stock, marca, garantia);
                        sucesso = produtoController.AddNewProduct(motherboard);
                        break;

                    case "ram":
                        int capacity = int.Parse(textCapacity.Text);
                        string typeRam = textType.Text;
                        int frequencyRam = int.Parse(textFrequencyRAM.Text);
                        int latency = int.Parse(textLatency.Text);
                        RAM ram = new RAM(capacity, typeRam, frequencyRam, latency, nome, descricao, preco, tipo, stock, marca, garantia);
                        sucesso = produtoController.AddNewProduct(ram);
                        break;
                }

                if (sucesso)
                {
                    MessageBox.Show("Produto adicionado com sucesso!");
                    LoadProducts.LoadStockData(); // Atualiza a interface com os dados do estoque
                }
                else
                {
                    MessageBox.Show("Erro ao adicionar produto.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        /// <summary>
        /// Manipula o evento de clique do botão para atualizar um produto existente no banco de dados.
        /// Verifica o tipo de produto selecionado no ComboBox e instancia o objeto correspondente.
        /// Atualiza o produto no banco de dados e exibe uma mensagem de sucesso ou erro.
        /// </summary>
        /// <param name="sender">O objeto que disparou o evento.</param>
        /// <param name="e">Os dados do evento.</param>
        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        /// <summary>
        /// Manipula o evento de clique do botão para excluir um produto.
        /// </summary>
        /// <param name="sender">O objeto que disparou o evento.</param>
        /// <param name="e">Os dados do evento.</param>
        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        #endregion

        #region Metodo de Esconder campos

        /// <summary>
        /// Oculta todos os campos relacionados a todos os tipos de produtos
        /// </summary>
        private void HideFields()
        {
            // Oculta todos os campos relacionados a todos os tipos de produtos
            textVRAM.Visible = false;
            textBaseClock.Visible = false;
            textBoostClock.Visible = false;
            VRAMlabel.Visible = false;
            Baselabel.Visible = false;
            Boostlabel.Visible = false;

            textCache.Visible = false;
            textSocket.Visible = false;
            textMem.Visible = false;
            textFrequency.Visible = false;
            CacheLabel.Visible = false;
            SocketLabel.Visible = false;
            MemoryLabel.Visible = false;  
            FrequencyLabel.Visible = false;

            textSocketMB.Visible = false;
            textMemorySupport.Visible = false;  
            textFormFactor.Visible = false;
            SocketLabelMB.Visible = false;
            MemorySupportLabelMB.Visible = false; 
            FormFactorLabel.Visible = false;

            textFrequencyRAM.Visible = false;
            textCapacity.Visible = false;
            textType.Visible = false;
            textLatency.Visible = false;
            FrequencylabelRAM.Visible = false;
            Capacitylabel.Visible = false;
            Typelabel.Visible = false;
            Latencylabel.Visible = false;
        }

        /// <summary>
        /// Manipula o evento de alteração de seleção do comboBox1.
        /// Oculta todos os campos e exibe apenas os campos específicos do tipo de produto selecionado.
        /// </summary>
        /// <param name="sender">O objeto que disparou o evento.</param>
        /// <param name="e">Os dados do evento.</param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Primeiro, oculta todos os campos
            HideFields();

            // Exibe apenas os campos específicos do tipo de produto selecionado
            switch (comboBox1.SelectedItem)
            {
                case "GPU":
                    textVRAM.Visible = true;
                    textBaseClock.Visible = true;
                    textBoostClock.Visible = true;
                    VRAMlabel.Visible = true;
                    Baselabel.Visible = true;
                    Boostlabel.Visible = true;
                    break;

                case "CPU":
                    textCache.Visible = true;
                    textSocket.Visible = true;
                    textMem.Visible = true;
                    textFrequency.Visible = true;
                    CacheLabel.Visible = true;
                    SocketLabel.Visible = true;
                    MemoryLabel.Visible = true;
                    FrequencyLabel.Visible = true;
                    break;

                case "Motherboard":
                    textSocketMB.Visible = true;
                    textMemorySupport.Visible = true;
                    textFormFactor.Visible = true;
                    SocketLabelMB.Visible = true;
                    MemorySupportLabelMB.Visible = true;  // Memória suportada para Motherboard
                    FormFactorLabel.Visible = true;
                    break;

                case "RAM":
                    textFrequencyRAM.Visible = true;
                    textCapacity.Visible = true;
                    textType.Visible = true;
                    textLatency.Visible = true;
                    FrequencylabelRAM.Visible = true;
                    Capacitylabel.Visible = true;
                    Typelabel.Visible = true;
                    Latencylabel.Visible = true;
                    break;
            }
        }

        #endregion

        #region Metodo de carregar detalhes de produtos

        /// <summary>
        /// Método para carregar os dados do estoque
        /// </summary>

        
        
        /// <summary>
        /// Método para carregar os detalhes de uma GPU
        /// </summary>
        /// <param name="productId"></param>
      
        private void LoadGpuDetails(int productId)
        {
          
        }

        /// <summary>
        /// Método para carregar os detalhes de uma CPU
        /// </summary>
        /// <param name="productId"></param>

        private void LoadCpuDetails(int productId)
        {
            
        }
        /// <summary>
        /// Método para carregar os detalhes de uma placa-mãe
        /// </summary>
        /// <param name="productId"></param>

        private void LoadMotherboardDetails(int productId)
        {
           
        }
        /// <summary>
        /// Método para carregar os detalhes de uma RAM
        /// </summary>
        /// <param name="productId"></param>
        private void LoadRamDetails(int productId)
        {
           
        }

        /// <summary>
        /// Evento para carregar os detalhes do produto selecionado no DataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        #endregion
    }
}
