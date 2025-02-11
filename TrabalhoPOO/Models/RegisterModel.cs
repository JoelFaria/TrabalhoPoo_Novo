﻿using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using TrabalhoPOO.Data;

namespace TrabalhoPOO.Models
{
    public class RegisterModel
    {
        
        private string query = "INSERT INTO LoginTable (username, password, email) VALUES (@Username, @Password, @Email)";

        public bool RegisterUser(User user)
        {
            var db = DataConnection.Instance;
            db.Open();

            try
            {
                using (SqlConnection con = new SqlConnection(db.Connection.ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Adiciona os parâmetros ao comando SQL
                        cmd.Parameters.AddWithValue("@Username", user.nomeUser);
                        cmd.Parameters.AddWithValue("@Password", user.PasswordUser);
                        cmd.Parameters.AddWithValue("@Email", user.emailUser);

                        // Executa o comando e verifica o número de linhas afetadas
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Retorna true se pelo menos uma linha foi inserida
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Lança uma exceção para ser tratada no Controller ou View
                throw new Exception("Erro ao registrar o usuário no banco de dados.", ex);
            }
            finally
            {
                db.Close();
            }
        }
    }
}
