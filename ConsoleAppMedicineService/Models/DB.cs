using ConsoleAppMedicineService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppMedicineService
{
    public static class DB
    {

        public static User[] Users;
        public static Category[] Categories;
        public static Medicine[] Medicines;

        static DB()
        {
            Categories = new Category[0];
            Users = new User[0];
            Medicines = new Medicine[0];
        }
    }
}
