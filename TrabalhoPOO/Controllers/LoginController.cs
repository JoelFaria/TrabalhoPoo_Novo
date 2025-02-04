using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using TrabalhoPOO.Models;
using Microsoft.Data.SqlClient;

namespace TrabalhoPOO.Controllers
{
    public class LoginController
    {
        private LoginModel loginModel;

        public LoginController()
        {
            this.loginModel = new LoginModel();
        }

        public bool ValidateUser(string username, string password)
        {
            return loginModel.ValidateUser(username, password);
        }
    }
}
