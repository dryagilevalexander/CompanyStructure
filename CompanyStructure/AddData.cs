using CompanyStructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyStructure
{
    public static class AddData
    {
        public static void AddDataToDb()
        {
            using (CompanyStructure.AppContext db = new CompanyStructure.AppContext())
            {
                // пересоздадим базу данных
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                List<Division> divisions = new List<Division>();
                List<Staff> staffs = new List<Staff>();
                List<User> users = new List<User>();

                // создание отделов первого уровня
                Division company = new Division();
                company.Id = Guid.NewGuid();
                company.Name = "Фирма";
                company.Description = "Фирма по разработке ПО";
                divisions.Add(company);

                Division department1 = new Division();
                department1.Id = Guid.NewGuid();
                department1.Name = "Отдел разработки";
                department1.Description = "Отдел разработки уровень 1";
                department1.ParentId = company.Id;
                divisions.Add(department1);


                Division department2 = new Division();
                department2.Id = Guid.NewGuid();
                department2.Name = "Отдел тестирования";
                department2.Description = "Отдел тестирования уровень 1";
                department2.ParentId = company.Id;
                divisions.Add(department2);

                Division department3 = new Division();
                department3.Id = Guid.NewGuid();
                department3.Name = "Отдел аналитики";
                department3.Description = "Отдел аналитики уровень 1";
                department3.ParentId = company.Id;
                divisions.Add(department3);

                //Создание отделов второго уровня
                Division department4 = new Division();
                department4.Id = Guid.NewGuid();
                department4.Name = "Группа 1 отдела аналитики";
                department4.Description = "Группа 1 отдела аналитики (уровень 2;";
                department4.ParentId = department3.Id;
                divisions.Add(department4);

                Division department5 = new Division();
                department5.Id = Guid.NewGuid();
                department5.Name = "Группа 2 отдела аналитики";
                department5.Description = "Группа 2 отдела аналитики (уровень 2;";
                department5.ParentId = department3.Id;
                divisions.Add(department5);

                Division department6 = new Division();
                department6.Id = Guid.NewGuid();
                department6.Name = "Группа 1 отдела разработки";
                department6.Description = "Группа 1 отдела разработки (уровень 2;";
                department6.ParentId = department1.Id;
                divisions.Add(department6);

                //Создание отделов третьего уровня
                Division department7 = new Division();
                department7.Id = Guid.NewGuid();
                department7.Name = "Подгруппа 1 группы 1 2 отдела аналитики";
                department7.Description = "Подгруппа 1 группы 1 1 отдела аналитики (уровень 3;";
                department7.ParentId = department4.Id;
                divisions.Add(department7);

                //Создание пользователей
                User user1 = new User();
                user1.Id = Guid.NewGuid();
                user1.Name = "Иванов Иван Иванович";
                users.Add(user1);

                User user2 = new User();
                user2.Id = Guid.NewGuid();
                user2.Name = "Дмитриев Дмитрий Дмитриевич";
                users.Add(user2);

                User user3 = new User();
                user3.Id = Guid.NewGuid();
                user3.Name = "Павел Павлович Павлов";
                users.Add(user3);

                User user4 = new User();
                user4.Id = Guid.NewGuid();
                user4.Name = "Кирилл Андреевич Михайлов";
                users.Add(user4);

                User user5 = new User();
                user5.Id = Guid.NewGuid();
                user5.Name = "Андрей Андреевич Андреев";
                users.Add(user5);

                User user6 = new User();
                user6.Id = Guid.NewGuid();
                user6.Name = "Михаил Васильевич Васильев";
                users.Add(user6);

                User user7 = new User();
                user7.Id = Guid.NewGuid();
                user7.Name = "Васильев Василий Васильевич";
                users.Add(user7);

                User user8 = new User();
                user8.Id = Guid.NewGuid();
                user8.Name = "Королев Антон Васильевич";
                users.Add(user8);

                User user9 = new User();
                user9.Id = Guid.NewGuid();
                user9.Name = "Артамонов Виталий Дмитриевич";
                users.Add(user9);

                //Создание должностей
                Staff staff1 = new Staff();
                staff1.Id = Guid.NewGuid();
                staff1.Name = "Программист";
                staff1.Description = "Программист";
                staff1.Quantity = 5;
                staff1.DivisionId = department6.Id;
                staff1.Users.Add(user1);
                staff1.Users.Add(user2);
                staffs.Add(staff1);

                Staff staff2 = new Staff();
                staff2.Id = Guid.NewGuid();
                staff2.Name = "Руководитель отдела разработки";
                staff2.Description = "Руководитель";
                staff2.Quantity = 1;
                staff2.DivisionId = department1.Id;
                staff2.Users.Add(user3);
                staffs.Add(staff2);

                Staff staff3 = new Staff();
                staff3.Id = Guid.NewGuid();
                staff3.Name = "Руководитель отдела аналитики";
                staff3.Description = "Руководитель";
                staff3.Quantity = 1;
                staff3.DivisionId = department3.Id;
                staff3.Users.Add(user4);
                staffs.Add(staff3);

                Staff staff4 = new Staff();
                staff4.Id = Guid.NewGuid();
                staff4.Name = "Руководитель отдела тестирования";
                staff4.Description = "Руководитель";
                staff4.Quantity = 1;
                staff4.DivisionId = department2.Id;
                staff4.Users.Add(user4);
                staffs.Add(staff4);

                Staff staff5 = new Staff();
                staff5.Id = Guid.NewGuid();
                staff5.Name = "Тестировщик";
                staff5.Description = "Тестировщик";
                staff5.Quantity = 3;
                staff5.DivisionId = department2.Id;
                staff5.Users.Add(user5);
                staff5.Users.Add(user5);
                staffs.Add(staff5);

                Staff staff6 = new Staff();
                staff6.Id = Guid.NewGuid();
                staff6.Name = "Системный аналитик";
                staff6.Description = "Аналитик";
                staff6.Quantity = 4;
                staff6.DivisionId = department4.Id;
                staff6.Users.Add(user6);
                staff6.Users.Add(user7);
                staffs.Add(staff6);

                Staff staff7 = new Staff();
                staff7.Id = Guid.NewGuid();
                staff7.Name = "Аналитик";
                staff7.Description = "Аналитик";
                staff7.Quantity = 2;
                staff7.DivisionId = department7.Id;
                staff7.Users.Add(user8);
                staff7.Users.Add(user9);
                staffs.Add(staff7);

                Staff staff8 = new Staff();
                staff8.Id = Guid.NewGuid();
                staff8.Name = "Продуктовый аналитик";
                staff8.Description = "Аналитик";
                staff8.Quantity = 1;
                staff8.DivisionId = department5.Id;
                staff8.Users.Add(user9);
                staffs.Add(staff8);

                db.Users.AddRange(users);
                db.Divisions.AddRange(divisions);
                db.Staffs.AddRange(staffs);
                db.SaveChanges();
            }
        }
    }
}
