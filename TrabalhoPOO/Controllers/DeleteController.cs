using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoPOO.Models;

namespace TrabalhoPOO.Controllers
{
    public class DeleteController
    {
        private Delete repo;

        public DeleteController()
        {
            this.repo = new Delete();
        }

        public bool DeleteProduct(int id)
        {
            return repo.DeleteProduct(id);
        }
    }
}
