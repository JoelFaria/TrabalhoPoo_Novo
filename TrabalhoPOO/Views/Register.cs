using System;
using Microsoft.Data.SqlClient;
using TrabalhoPOO.Models;
using TrabalhoPOO.Controllers;
using TrabalhoPOO;

namespace TrabalhoPOO.Views
{
    public partial class Register : Form
    {
      
       

        public Register()
        {
            InitializeComponent();
        }

     
        private void button1_Click_1(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox3.Text;
            string email = textBox2.Text;

            try
            {
                User user = new User(username, password, email);

                RegisterController controller = new RegisterController();
                bool isRegistered = controller.RegisterUser(user);

                if (isRegistered) 
                {
                    Login login = new Login();
                    MessageBox.Show("Registro efetuado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    login.Show();
                }
                else
                {
                    MessageBox.Show("O registro falhou. Por favor, tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }

   
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();

    
            login.FormClosed += (s, args) => this.Close();
        }
    }
}