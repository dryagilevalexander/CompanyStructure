using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyStructure.Models
{
    public class User
    {
        public Guid Id { get; set; }   
        public string Name { get; set; }
        public List<Staff> Staffs { get; set; } = new List<Staff>();
    }
}
