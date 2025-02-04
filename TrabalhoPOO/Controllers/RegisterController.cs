using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoPOO.Models;

namespace TrabalhoPOO.Controllers
{
   public class RegisterController
    {
        private RegisterModel registerModel;

        public RegisterController()
        {
            this.registerModel = new RegisterModel();
        }
        public bool RegisterUser(User user)
        {
            return registerModel.RegisterUser(user);
        }
    }
}
