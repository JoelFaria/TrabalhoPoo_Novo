using System;
using Microsoft.Data.SqlClient;
using TrabalhoPOO.Views;
using TrabalhoPOO;

namespace TrabalhoPOO.Views
{
    public partial class Register : Form
    {
        // Instância da classe RegisterClass para registrar usuários
        RegisterClass registerClass = new RegisterClass();

        public Register()
        {
            InitializeComponent();
        }

        // Classe para registrar usuários no banco de dados
        public class RegisterClass
        {
            // String de conexão com o banco de dados
            string connectingString = "Data Source=JOELFARIA\\SQLEXPRESS;Initial Catalog=LoginApp;Integrated Security=True;TrustServerCertificate=True";
            // Consulta SQL para inserir um novo usuário
            string query = "INSERT INTO LoginTable (username, password, email) VALUES (@Username, @Password, @Email)";

            // Método para registrar um usuário no banco de dados
            public void RegisterUser(User user)
            {
                using (SqlConnection con = new SqlConnection(connectingString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    // Adiciona os parâmetros à consulta
                    cmd.Parameters.AddWithValue("@Username", user.nomeUser);
                    cmd.Parameters.AddWithValue("@Password", user.PasswordUser);
                    cmd.Parameters.AddWithValue("@Email", user.emailUser);
                    int a = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        // Evento do botão para registrar um novo usuário
        private void button1_Click_1(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox3.Text;
            string email = textBox2.Text;

            // Cria um novo objeto User com os dados fornecidos
            User user = new User(username, email, password);

            try
            {
                // Tenta registrar o usuário
                registerClass.RegisterUser(user);
                MessageBox.Show("Registo efetuado com sucesso!");
            }
            catch (Exception ex)
            {
                // Exibe uma mensagem de erro se o registro falhar
                MessageBox.Show("Erro ao registar: " + ex.Message);
            }
        }

        // Evento do botão para fechar o formulário
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Evento para mostrar ou esconder a senha
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }

        // Evento para abrir o formulário de login
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();

            // Fecha o formulário atual quando o formulário de login é fechado
            login.FormClosed += (s, args) => this.Close();
        }
    }
}