using Patterns.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Composite
{
    public abstract class Component
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsComposite { get; set; }

        public abstract void ProcessOrder(Order order);
    }
    
}
