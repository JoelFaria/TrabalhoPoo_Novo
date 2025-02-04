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

        public AdminForm()
        {
            InitializeComponent();

            comboBox1.Items.Add("GPU");
            comboBox1.Items.Add("CPU");
            comboBox1.Items.Add("RAM");
            comboBox1.Items.Add("Motherboard");

            produtoController = new ProductController();

            HideFields();

            LoadStockData();
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
                    LoadStockData(); // Atualiza a interface com os dados do estoque
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
            int id = int.Parse(textId.Text);

            // Verificar o tipo de produto selecionado e instanciar o objeto correto
            Produto produto;

            // Verificar o tipo do produto a partir do ComboBox
            if (comboBox1.SelectedItem.ToString() == "GPU")
            {
                produto = new Gpu(
                    vram: int.Parse(textVRAM.Text),
                    baseClock: int.Parse(textBaseClock.Text),
                    boostClock: int.Parse(textBoostClock.Text),
                    nome: textName.Text,
                    descricao: textDescription.Text,
                    preco: double.Parse(textPrice.Text),
                    cat: comboBox1.SelectedItem?.ToString() ?? string.Empty,
                    stock: int.Parse(textStock.Text),
                    marca: textBrand.Text,
                    garantia: int.Parse(textGuarantee.Text)
                );
            }
            else if (comboBox1.SelectedItem.ToString() == "CPU")
            {
                produto = new Cpu(
                    cache: int.Parse(textCache.Text),
                    socket: textSocket.Text,
                    memorySupport: textMem.Text,
                    frequency: int.Parse(textFrequency.Text),
                    nome: textName.Text,
                    descricao: textDescription.Text,
                    preco: double.Parse(textPrice.Text),
                    cat: comboBox1.SelectedItem?.ToString() ?? string.Empty,
                    stock: int.Parse(textStock.Text),
                    marca: textBrand.Text,
                    garantia: int.Parse(textGuarantee.Text)
                );
            }
            else if (comboBox1.SelectedItem.ToString() == "Motherboard")
            {
                produto = new Motherboard(
                    socket: textSocketMB.Text,
                    memorySupport: textMemorySupport.Text,
                    formFactor: textFormFactor.Text,
                    nome: textName.Text,
                    descricao: textDescription.Text,
                    preco: double.Parse(textPrice.Text),
                    cat: comboBox1.SelectedItem?.ToString() ?? string.Empty,
                    stock: int.Parse(textStock.Text),
                    marca: textBrand.Text,
                    garantia: int.Parse(textGuarantee.Text)
                );
            }
            else if (comboBox1.SelectedItem.ToString() == "RAM")
            {
                produto = new RAM(
                    frequency: int.Parse(textFrequencyRAM.Text),
                    capacity: int.Parse(textCapacity.Text),
                    type: textType.Text,
                    latency: int.Parse(textLatency.Text),
                    nome: textName.Text,
                    descricao: textDescription.Text,
                    preco: double.Parse(textPrice.Text),
                    cat: comboBox1.SelectedItem?.ToString() ?? string.Empty,
                    stock: int.Parse(textStock.Text),
                    marca: textBrand.Text,
                    garantia: int.Parse(textGuarantee.Text)
                );
            }
            else
            {
                // Exibe uma mensagem se o tipo de produto não for selecionado ou for inválido
                MessageBox.Show("Tipo de produto não selecionado ou inválido.");
                return;
            }

            // Atualiza o produto no banco de dados
            bool sucesso = a.UpdateProduct(produto, id);

            if (sucesso)
            {
                // Exibe uma mensagem de sucesso e recarrega os dados do estoque
                MessageBox.Show("Produto atualizado com sucesso!");
                LoadStockData();
            }
            else
            {
                // Exibe uma mensagem de erro se a atualização falhar
                MessageBox.Show("Erro ao atualizar produto.");
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
                int id = int.Parse(textId.Text); // Pega o Id do produto da caixa de texto
                bool sucesso = a.DeleteProduct(id);

                if (sucesso)
                {
                    // Exibe uma mensagem de sucesso e recarrega os dados do estoque
                    MessageBox.Show("Produto eliminado com sucesso!");
                    LoadStockData(); // Recarrega os dados para refletir a exclusão
                }
            }
            catch (Exception ex)
            {
                // Exibe uma mensagem de erro se ocorrer um problema ao eliminar o produto
                MessageBox.Show($"Erro: {ex.Message}");
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
        /// Método para carregar os dados do estoque
        /// </summary>

        private void LoadStockData()
        {
            string query = "SELECT * FROM StockTable";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable; // Exibe os dados no DataGridView
                }
                catch (Exception ex)
                {
                    // Exibe uma mensagem de erro se ocorrer um problema ao carregar os dados
                    MessageBox.Show("Erro ao carregar dados: " + ex.Message);
                }
            }
        }
        /// <summary>
        /// Método para carregar os detalhes de uma GPU
        /// </summary>
        /// <param name="productId"></param>
      
        private void LoadGpuDetails(int productId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT VRAM, BaseClock, OverClock FROM Gpu WHERE ProductId = @ProductId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ProductId", productId);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    // Preenche os campos de texto com os detalhes da GPU
                    textVRAM.Text = reader["VRAM"].ToString();
                    textBaseClock.Text = reader["BaseClock"].ToString();
                    textBoostClock.Text = reader["OverClock"].ToString();
                }
            }
        }

        /// <summary>
        /// Método para carregar os detalhes de uma CPU
        /// </summary>
        /// <param name="productId"></param>

        private void LoadCpuDetails(int productId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT Cache, Socket, MemorySupport, Frequency FROM Cpu WHERE ProductId = @ProductId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ProductId", productId);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    // Preenche os campos de texto com os detalhes da CPU
                    textCache.Text = reader["Cache"].ToString();
                    textSocket.Text = reader["Socket"].ToString();
                    textMem.Text = reader["MemorySupport"].ToString();
                    textFrequency.Text = reader["Frequency"].ToString();
                }
            }
        }
        /// <summary>
        /// Método para carregar os detalhes de uma placa-mãe
        /// </summary>
        /// <param name="productId"></param>

        private void LoadMotherboardDetails(int productId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT Socket, MemorySupport, FormFactor FROM Motherboard WHERE ProductId = @ProductId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ProductId", productId);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    // Preenche os campos de texto com os detalhes da placa-mãe
                    textSocketMB.Text = reader["Socket"].ToString();
                    textMemorySupport.Text = reader["MemorySupport"].ToString();
                    textFormFactor.Text = reader["FormFactor"].ToString();
                }
            }
        }
        /// <summary>
        /// Método para carregar os detalhes de uma RAM
        /// </summary>
        /// <param name="productId"></param>
        private void LoadRamDetails(int productId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT Frequency, Capacity, Type, Latency FROM Ram WHERE ProductId = @ProductId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ProductId", productId);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    // Preenche os campos de texto com os detalhes da RAM
                    textFrequencyRAM.Text = reader["Frequency"].ToString();
                    textCapacity.Text = reader["Capacity"].ToString();
                    textType.Text = reader["Type"].ToString();
                    textLatency.Text = reader["Latency"].ToString();
                }
            }
        }

        /// <summary>
        /// Evento para carregar os detalhes do produto selecionado no DataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ignora cabeçalhos
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // Preenche os campos de texto com os dados comuns do produto
                textId.Text = selectedRow.Cells["id"].Value.ToString();
                textName.Text = selectedRow.Cells["name"].Value.ToString();
                textDescription.Text = selectedRow.Cells["description"].Value.ToString();
                textPrice.Text = selectedRow.Cells["price"].Value.ToString();
                textStock.Text = selectedRow.Cells["stock"].Value.ToString();
                textBrand.Text = selectedRow.Cells["brand"].Value.ToString();
                textGuarantee.Text = selectedRow.Cells["guarantee"].Value.ToString();
                comboBox1.SelectedItem = selectedRow.Cells["type"].Value.ToString();

                // Identifica o tipo de produto
                string productType = selectedRow.Cells["type"].Value.ToString();
                int productId = int.Parse(textId.Text);

                // Carrega os detalhes adicionais com base no tipo de produto
                if (productType.ToLower() == "gpu")
                {
                    LoadGpuDetails(productId);
                }
                else if (productType.ToLower() == "cpu")
                {
                    LoadCpuDetails(productId);
                }
                else if (productType.ToLower() == "motherboard")
                {
                    LoadMotherboardDetails(productId);
                }
                else if (productType.ToLower() == "ram")
                {
                    LoadRamDetails(productId);
                }
            }
        }

        #endregion
    }
}
