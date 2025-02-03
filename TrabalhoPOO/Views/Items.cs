using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace TrabalhoPOO.Views
{
    public partial class Items : Form
    {
        public Items()
        {
            InitializeComponent();

            LoadData();
        }

        private string selectedProduct; // Produto selecionado
        private int selectedProductId; // ID do produto selecionado
        private List<string> carrinho = new List<string>(); // Lista de itens no carrinho
        Login


        private void LoadData()
        {
            string query = "SELECT * FROM StockTable";
            string connectionString = "Data Source=JOELFARIA\\SQLEXPRESS;Initial Catalog=LoginApp;Integrated Security=True;TrustServerCertificate=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable; // Exibe os dados na DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar dados: " + ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
        /// <summary>
        /// Atualiza o estoque do produto decrementando a quantidade em 1.
        /// </summary>
        /// <param name="productId">ID do produto a ser atualizado.</param>
        private void UpdateStock(int productId)
        {
            string connectionString = "Data Source=JOELFARIA\\SQLEXPRESS;Initial Catalog=LoginApp;Integrated Security=True;TrustServerCertificate=True";
            string query = "UPDATE StockTable SET Stock = Stock - 1 WHERE Id = @Id AND Stock > 0";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Id", productId);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Produto comprado com sucesso!");
                        }
                        else
                        {
                            MessageBox.Show("Produto sem stock disponível!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao atualizar o stock: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Manipula o evento de clique em uma célula do DataGridView.
        /// Captura o ID e os detalhes do produto selecionado.
        /// </summary>
        /// <param name="sender">O objeto que disparou o evento.</param>
        /// <param name="e">Os dados do evento de clique na célula.</param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ignorar cabeçalhos
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                string nomeProduto = selectedRow.Cells["name"].Value.ToString();
                string precoProduto = selectedRow.Cells["price"].Value.ToString();

                // Capturar o ID e os detalhes do produto
                selectedProductId = Convert.ToInt32(selectedRow.Cells["id"].Value); // Atualiza o ID selecionado
                selectedProduct = $"Produto: {nomeProduto}, Preço: {precoProduto}€";
            }
        }

        /// <summary>
        /// Botão para adicionar um item ao carrinho.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedProduct))
            {
                // Adicionar o item ao carrinho
                carrinho.Add(selectedProduct);

                // Exibir mensagem de confirmação
                MessageBox.Show($"Item adicionado ao carrinho:\n\n{selectedProduct}", "Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Selecione um produto antes de adicionar ao carrinho!");
            }

        }

        /// <summary>
        /// Botão para confirmar a compra dos itens no carrinho.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (carrinho.Count > 0)
            {
                // Exibir todos os itens no carrinho
                string carrinhoDetalhes = string.Join("\n", carrinho);

                DialogResult result = MessageBox.Show(
                    $"Itens no carrinho:\n\n{carrinhoDetalhes}\n\nDeseja confirmar a compra?",
                    "Confirmação de Compra",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    // Atualizar o estoque para cada item no carrinho
                    foreach (var item in carrinho)
                    {
                        UpdateStock(selectedProductId);
                    }

                    MessageBox.Show("Compra realizada com sucesso!");
                    carrinho.Clear(); // Limpar o carrinho após a compra
                    LoadData(); // Recarregar a tabela
                }
                else
                {
                    MessageBox.Show("Compra cancelada.");
                }
            }
            else
            {
                MessageBox.Show("O carrinho está vazio!");
            }
        }
    }
}
