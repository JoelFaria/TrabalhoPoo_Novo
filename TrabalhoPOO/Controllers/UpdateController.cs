using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoPOO.Models;

namespace TrabalhoPOO.Controllers
{
    public class UpdateController
    {
        private Update up;

        public bool UpdateProduct(Produto produto, int id)
        {
            return up.UpdateProduct(produto, id);
        }
    }
}
