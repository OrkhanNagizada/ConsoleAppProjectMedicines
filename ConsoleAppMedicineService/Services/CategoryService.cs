using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleAppMedicineService.Models;

namespace ConsoleAppMedicineService.Services
{
    public class CategoryService
    {
        public void CreateCategory(Category category)
        {
            Array.Resize(ref DB.Categories, DB.Categories.Length + 1);
            category.Id = GenerateCategoryId();
            DB.Categories[DB.Categories.Length - 1] = category;
        }

        private int GenerateCategoryId()
        {
            return DB.Categories.Length;
        }
    }
}
