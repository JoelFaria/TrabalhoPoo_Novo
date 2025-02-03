using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using TrabalhoPOO.Controllers;
using TrabalhoPOO.Models;


namespace TrabalhoPOO.Views
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtPass.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }
        private void button1_Click(object sender, EventArgs e)
        {

            string username = txtUser.Text;
            string password = txtPass.Text;

            LoginController loginController = new LoginController();
            bool isValid = loginController.ValidateUser(username, password);


            if (isValid)
            {
                MessageBox.Show("Login bem-sucedido!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (username == "admin" && password == "admin")
                {
                    AdminForm adminForm = new AdminForm();
                    adminForm.Show();
                    this.Hide();
                }
                else
                {
                    Items items = new Items();
                    items.Show();
                    this.Hide();

                }
            }
            else
            {
                MessageBox.Show("Nome de usuário ou senha incorretos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register forms2 = new Register();
            forms2.Show();
            this.Hide();

            forms2.FormClosed += (s, args) => this.Close();
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
