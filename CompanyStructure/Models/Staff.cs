using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyStructure.Models
{
    public class Staff
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? DivisionId { get; set; }
        public int Quantity { get; set; }
        public List<User> Users { get; set; } = new List<User>();
    }
}
