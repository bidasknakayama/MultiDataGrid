using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleButton.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public UserModel(int Id, String Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
    }
}
