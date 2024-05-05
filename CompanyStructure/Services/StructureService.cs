using CompanyStructure.Models;
using Microsoft.EntityFrameworkCore;
using CompanyStructure.Services.Models;

namespace CompanyStructure.Services
{
    public class StructureService: StructureModels
    {
        public List<DivisionsLevel> GetCompanyStructure()
        {
            var tree = GetFullDivisions(null);
            return tree;
        }

        public List<DivisionsLevel> GetDivisionTreeById(Guid id)
        {
            var tree = GetFullDivisions(id);
            return tree;
        }


        public List<UserModel> GetDivisionPersonalById(Guid? id = null)
        {
            var tree = GetFullDivisions(id);
            var users = GetPersonalRecursive(tree, new List<UserModel>());
            return users;           
        }

        public void AddUserInStaff(string staffGuid, Guid userId)
        {
            using (CompanyStructure.AppContext db = new CompanyStructure.AppContext())
            {
                Staff staff = db.Staffs.Include(x => x.Users).FirstOrDefault(x => x.Id == Guid.Parse(staffGuid));
                if (staff == null)
                {
                    Console.WriteLine("Штатная единица не найдена");
                    return;
                }

                if(staff.Users.Count() < staff.Quantity) 
                {
                    var currentUser = db.Users.FirstOrDefault(x => x.Id == userId);
                    currentUser.Staffs.Add(staff);
                    db.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Превышено допустимое количество штатных единиц");
                    return;
                }
            }
        }

        public void RemoveUserInStaff(string staffGuid, Guid userId)
        {
            using (CompanyStructure.AppContext db = new CompanyStructure.AppContext())
            {
                Staff staff = db.Staffs.Include(x => x.Users).FirstOrDefault(x => x.Id == Guid.Parse(staffGuid));
                if (staff == null)
                {
                    Console.WriteLine("Штатная единица не найдена");
                    return;
                }

                if (staff.Users.Count() < staff.Quantity)
                {
                    var currentUser = db.Users.FirstOrDefault(x => x.Id == userId);
                    currentUser.Staffs.Remove(staff);
                    db.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Превышено допустимое количество штатных единиц");
                    return;
                }
            }
        }

        public List<DivisionsLevel> GetFullDivisions(Guid? rootDivisionId)
        {
            var level = new List<DivisionsLevel>();
            using (CompanyStructure.AppContext db = new CompanyStructure.AppContext())
            {

                foreach (var subDivision in db.Divisions.Where(x => x.ParentId == rootDivisionId).Include(x => x.Staffs).ThenInclude(x => x.Users))
                {
                    level.Add(
                        new DivisionsLevel
                        {
                            DivisionRoot = new DivisionModel
                            {
                                Id = subDivision.Id,
                                Name = subDivision.Name,
                                Description = subDivision.Description,
                                ParentId = subDivision.ParentId,
                                Staffs = subDivision.Staffs.Select(x => new StaffModel
                                {
                                    Id = x.Id,
                                    Name = x.Name,
                                    Description = x.Description,
                                    Quantity = x.Quantity,
                                    Users = x.Users.Select(x => new UserModel
                                    {
                                        Id = x.Id,
                                        Name = x.Name
                                    }).ToList()

                                }).ToList()
                            },
                            Divisions = GetFullDivisions(subDivision.Id)
                        }
                        ); ;
                }
            }

            return level;
        }

        public List<UserModel> GetPersonalRecursive(List<DivisionsLevel> tree, List<UserModel> users)
        {

                foreach (var level in tree)
                {
                    users.AddRange(level.DivisionRoot.Staffs.SelectMany(x => x.Users).ToList());
                    GetPersonalRecursive(level.Divisions, users);
                }

            return users;
        }

        public List<DivisionsOnlyLevel> GetDivisionsOnly(Guid? rootDivisionId = null)
        {

            var level = new List<DivisionsOnlyLevel>();
            using (CompanyStructure.AppContext db = new CompanyStructure.AppContext())
            {

                foreach (var subDivision in db.Divisions.Where(x => x.ParentId == rootDivisionId))
                {
                    level.Add(
                        new DivisionsOnlyLevel
                        {
                            DivisionRoot = new SmallDivisionModel
                            {
                                Id = subDivision.Id,
                                Name = subDivision.Name,
                                Description = subDivision.Description,
                                ParentId = subDivision.ParentId,
                            },
                            Divisions = GetDivisionsOnly(subDivision.Id)
                        }
                        );
                }
            }

            return level;
        }
    }
}
