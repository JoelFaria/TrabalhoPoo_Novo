using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPOO.Models
{
    public class User
    {
        // Identificador único gerado automaticamente pelo SQL Server
        public int Id { get; set; }

        // Nome do utilizador
        public string Nome { get; set; }

        // Email do utilizador
        public string Email { get; set; }

        // Palavra-passe do utilizador
        public string Password { get; set; }

        #region Construtores

        /// <summary>
        /// Construtor para inicializar um novo utilizador.
        /// </summary>
        /// <param name="nome">Nome do utilizador.</param>
        /// <param name="email">Email do utilizador.</param>
        /// <param name="password">Palavra-passe do utilizador.</param>
        public User(string nome, string email, string password)
        {
            Nome = nome;
            Email = email;
            Password = password;
        }

        #endregion

        #region Propriedades Públicas

        /// <summary>
        /// Propriedade com validação para obter e definir o Nome.
        /// </summary>
        public string nomeUser
        {
            get { return Nome; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Nome não pode ser vazio");
                }
                Nome = value;
            }
        }

        /// <summary>
        /// Propriedade com validação para obter e definir o Email.
        /// </summary>
        public string emailUser
        {
            get { return Email; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Email não pode ser vazio");
                }
                Email = value;
            }
        }

        /// <summary>
        /// Propriedade com validação para obter e definir a Password.
        /// </summary>
        public string PasswordUser
        {
            get { return Password; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Password não pode ser vazio");
                }
                Password = value;
            }
        }
        #endregion
    }
}
