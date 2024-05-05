using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyStructure.Services.Models
{
    public partial class StructureModels
    {
        public class DivisionsOnlyLevel
        {
            public SmallDivisionModel? DivisionRoot { get; set; }
            public List<DivisionsOnlyLevel>? Divisions { get; set; }
        }

        public class SmallDivisionModel()
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public Guid? ParentId { get; set; }
        }

        public class DivisionsLevel
        {
            public DivisionModel? DivisionRoot { get; set; }
            public List<DivisionsLevel>? Divisions { get; set; }
        }

        public class DivisionModel()
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public Guid? ParentId { get; set; }
            public List<StaffModel> Staffs { get; set; }
        }

        public class StaffModel()
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public int Quantity { get; set; }
            public List<UserModel> Users { get; set; }
        }

        public class UserModel
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
        }
    }
}
