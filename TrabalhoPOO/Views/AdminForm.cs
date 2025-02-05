using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using TrabalhoPOO.Models;
using TrabalhoPOO;
using TrabalhoPOO.Controllers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TrabalhoPOO.Views
{

    public partial class AdminForm : Form
    {

        private ProductController produtoController;
        private StockController stockController;
        private DeleteController deleteController;

        public AdminForm()
        {
            InitializeComponent();

            comboBox1.Items.Add("GPU");
            comboBox1.Items.Add("CPU");
            comboBox1.Items.Add("RAM");
            comboBox1.Items.Add("Motherboard");

            produtoController = new ProductController();
            stockController = new StockController();
            deleteController = new DeleteController();

            HideFields();

            CarregarDados();


        }

        private void CarregarDados()
        {
            try
            {
                dataGridView1.DataSource = stockController.ListarProdutos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados: " + ex.Message);
            }
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
                    CarregarDados(); // Atualiza a interface com os dados do estoque
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
            try
            {
                // Exemplo: Recupera o tipo do produto (assumindo que o comboBox contém as opções "GPU", "CPU", "Motherboard" e "RAM")
                string? tipo = comboBox1.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(tipo))
                {
                    MessageBox.Show("Selecione um tipo de produto.");
                    return;
                }

                // Recupera o ID do produto a ser atualizado (pode estar em um campo oculto ou selecionado de um DataGridView)
                int id = int.Parse(textId.Text);

                // Dados comuns para todos os produtos
                string nome = textName.Text;
                string descricao = textDescription.Text;
                double preco = double.Parse(textPrice.Text);
                int stock = int.Parse(textStock.Text);
                string marca = textBrand.Text;
                int garantia = int.Parse(textGuarantee.Text);

                // Instancia o objeto do tipo correto
                Produto? produto = null;

                switch (tipo.ToLower())
                {
                    case "gpu":
                        int vram = int.Parse(textVRAM.Text);
                        int baseClock = int.Parse(textBaseClock.Text);
                        int overClock = int.Parse(textBoostClock.Text);
                        produto = new Gpu(vram, baseClock, overClock, nome, descricao, preco, tipo, stock, marca, garantia);
                        break;

                    case "cpu":
                        int cache = int.Parse(textCache.Text);
                        string socket = textSocket.Text;
                        string memorySupport = textMem.Text;
                        int frequency = int.Parse(textFrequency.Text);
                        produto = new Cpu(cache, socket, memorySupport, frequency, nome, descricao, preco, tipo, stock, marca, garantia);
                        break;

                    case "motherboard":
                        string socketMB = textSocketMB.Text;
                        string memorySupportMB = textMemorySupport.Text;
                        string formFactor = textFormFactor.Text;
                        produto = new Motherboard(socketMB, memorySupportMB, formFactor, nome, descricao, preco, tipo, stock, marca, garantia);
                        break;

                    case "ram":
                        int capacity = int.Parse(textCapacity.Text);
                        string typeRam = textType.Text;
                        int frequencyRam = int.Parse(textFrequencyRAM.Text);
                        int latency = int.Parse(textLatency.Text);
                        produto = new RAM(capacity, typeRam, frequencyRam, latency, nome, descricao, preco, tipo, stock, marca, garantia);
                        break;

                    default:
                        MessageBox.Show("Tipo de produto inválido.");
                        return;
                }

                // Cria a instância do controller e chama o método de atualização
                Update up = new Update();
                bool sucesso = up.UpdateProduct(produto, id);

                if (sucesso)
                {
                    MessageBox.Show("Produto atualizado com sucesso!");
                    // Atualize os dados na interface, por exemplo, recarregando o DataGridView:
                    CarregarDados();
                }
                else
                {
                    MessageBox.Show("Erro ao atualizar o produto.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        /// <summary>
        /// Manipula o evento de clique do botão para excluir um produto.
        /// </summary>
        /// <param name="sender">O objeto que disparou o evento.</param>
        /// <param name="e">Os dados do evento.</param>
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica se há alguma linha selecionada no DataGridView
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Selecione um produto para excluir.");
                    return;
                }

                // Obtém o ID do produto selecionado
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

                // Confirma a exclusão
                DialogResult resultado = MessageBox.Show("Tem certeza que deseja excluir o produto selecionado?",
                                                          "Confirmar Exclusão",
                                                          MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Instancia a classe Delete e chama o método para remover o produto
                    Delete deleteModel = new Delete();
                    bool sucesso = deleteModel.DeleteProduct(id);

                    if (sucesso)
                    {
                        MessageBox.Show("Produto excluído com sucesso!");
                        CarregarDados(); // Atualiza a listagem
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir o produto: " + ex.Message);
            }
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
        /// Evento para carregar os detalhes do produto selecionado no DataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Garante que não está a clicar no cabeçalho
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                comboBox1.SelectedItem = row.Cells["StockType"].Value?.ToString();
                textName.Text = row.Cells["Name"].Value?.ToString();
                textDescription.Text = row.Cells["Description"].Value?.ToString();
                textPrice.Text = row.Cells["Price"].Value?.ToString();
                textStock.Text = row.Cells["Stock"].Value?.ToString();
                textBrand.Text = row.Cells["Brand"].Value?.ToString();
                textGuarantee.Text = row.Cells["Guarantee"].Value?.ToString();
                textId.Text = row.Cells["Id"].Value?.ToString();

                if(comboBox1.SelectedItem?.ToString() == "Gpu")
                {
                    textVRAM.Text = row.Cells["VRAM"].Value?.ToString();
                    textBaseClock.Text = row.Cells["BaseClock"].Value?.ToString();
                    textBoostClock.Text = row.Cells["BoostClock"].Value?.ToString();
                }
                else if (comboBox1.SelectedItem?.ToString() == "Cpu")
                {
                    textCache.Text = row.Cells["Cache"].Value?.ToString();
                    textSocket.Text = row.Cells["CpuSocket"].Value?.ToString();
                    textMem.Text = row.Cells["CpuMemorySupport"].Value?.ToString();
                    textFrequency.Text = row.Cells["CpuFrequency"].Value?.ToString();
                }
                else if (comboBox1.SelectedItem?.ToString() == "Motherboard")
                {
                    textSocketMB.Text = row.Cells["MB_Socket"].Value?.ToString();
                    textMemorySupport.Text = row.Cells["MB_MemorySupport"].Value?.ToString();
                    textFormFactor.Text = row.Cells["FormFactor"].Value?.ToString();
                }
                else if (comboBox1.SelectedItem?.ToString() == "RAM")
                {
                    textFrequencyRAM.Text = row.Cells["RamFrequency"].Value?.ToString();
                    textCapacity.Text = row.Cells["Capacity"].Value?.ToString();
                    textType.Text = row.Cells["RamType"].Value?.ToString();
                    textLatency.Text = row.Cells["Latency"].Value?.ToString();
                }
            }
        }

        #endregion

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
