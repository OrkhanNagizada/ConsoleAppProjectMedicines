using ConsoleAppMedicineService.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppMedicineService.Services
{
    public class MedicineService:BaseEntity
    {
        public void CreateMedicine(Medicine medicine)
        {
            if (DB.categories.All(c => c.Id != medicine.CategoryId))
            {
                throw new NotFoundException("Category not found.");
            }
            DB.medicines.Add(medicine);
        }

        public List<Medicine> GetAllMedicines()
        {
            return DB.medicines;
        }

        public Medicine GetMedicineById(int id)
        {
            var medicine = DB.medicines.FirstOrDefault(m => m.Id == id);
            if (medicine == null)
            {
                throw new NotFoundException("Medicine not found.");
            }
            return medicine;
        }

        public List<Medicine> GetMedicineByName(string name)
        {
            return DB.medicines.Where(m => m.Name.ToLower().Contains(name.ToLower())).ToList();
        }

        public List<Medicine> GetMedicineByCategory(int categoryId)
        {
            return DB.medicines.Where(m => m.CategoryId == categoryId).ToList();
        }

        public void RemoveMedicine(int id)
        {
            var medicine = GetMedicineById(id);
            DB.medicines.Remove(medicine);
        }

        public void UpdateMedicine(int id, Medicine updatedMedicine)
        {
            var index = DB.medicines.FindIndex(m => m.Id == id);
            if (index != -1)
            {
                DB.medicines[index] = updatedMedicine;
            }
        }
    }

}
