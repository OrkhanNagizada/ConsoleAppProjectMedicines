using ConsoleAppMedicineService.Exceptions;
using ConsoleAppMedicineService.Models;
using ConsoleAppMedicineService;
using System;
using System.Linq;

public class MedicineService
{


    public void CreateMedicine(Medicine medicine)
    {
        
        if (DB.Categories.All(c => c.Id != medicine.CategoryId))
        {
            throw new NotFoundException("Category not found");
        }

        Array.Resize(ref DB.Medicines, DB.Medicines.Length + 1);
        medicine.Id = GenerateMedicineId();
        medicine.CreatedDate = DateTime.Now;
        DB.Medicines[DB.Medicines.Length - 1] = medicine;
    }

    public Medicine[] GetAllMedicines()
    {
        return DB.Medicines;
    }

    public Medicine GetMedicineById(int id)
    {
        var medicine = DB.Medicines.FirstOrDefault(m => m.Id == id);
        if (medicine == null)
        {
            throw new NotFoundException("Medicine not found");
        }
        return medicine;
    }

    public Medicine GetMedicineByName(string name)
    {
        var medicine = DB.Medicines.FirstOrDefault(m => m.Name == name);
        if (medicine == null)
        {
            throw new NotFoundException("Medicine not found");
        }
        return medicine;
    }

    public Medicine[] GetMedicineByCategory(int categoryId)
    {
        var medicines = DB.Medicines.Where(m => m.CategoryId == categoryId).ToArray();
        return medicines;
    }

    public void RemoveMedicine(int id)
    {
        int index = Array.FindIndex(DB.Medicines, m => m.Id == id);
        if (index == -1)
        {
            throw new NotFoundException("Medicine not found");
        }

        DB.Medicines = DB.Medicines.Where((source, idx) => idx != index).ToArray();
    }

    public void UpdateMedicine(int id, Medicine updatedMedicine)
    {
        var existingMedicine = GetMedicineById(id);
        existingMedicine.Name = updatedMedicine.Name;
        existingMedicine.Price = updatedMedicine.Price;
        existingMedicine.CategoryId = updatedMedicine.CategoryId;
    }

    private int GenerateMedicineId()
    {
        return DB.Medicines.Length + 1;
    }
}
