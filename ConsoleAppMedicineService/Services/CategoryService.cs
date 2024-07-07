using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppMedicineService.Services
{
    public class CategoryService
    {
        public void CreateCategory(Category category)
        {
            DB.categories.Add(category);
        }
    }
}
