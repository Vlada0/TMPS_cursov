using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Patterns.Model
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public Client() { }

        public Client(string name)
        {
            Name = name;
        }
        public Client(string name, string email, string phone)
        {
            Name = name;
            Email = email;
            Phone = phone;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
