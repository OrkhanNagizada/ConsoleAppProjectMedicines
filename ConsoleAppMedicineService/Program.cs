using ConsoleAppMedicineService.Exceptions;
using ConsoleAppMedicineService.Services;
using ConsoleAppMedicineService;
using ConsoleAppMedicineService.Models;
MedicineService medicineService1 = new MedicineService();
var userService = new UserService();
var user1 = new User { Fullname = "Nagizade Orxan", Email = "Orxan93@gmail.com", Password = "Orxan123@" };
var user2 = new User { Fullname = "Asimian Asiman", Email = "Asiman05@gmail.com", Password = "Asiman123@" };
var user3 = new User { Fullname = "Musa Muradli", Email = "Musa07@gmail.com", Password = "Musa123@" };
var user4 = new User { Fullname = "Aqil Aqil", Email = "Aqil09@gmail.com", Password = "Aqil123@" };
userService.AddUser(user1);
userService.AddUser(user2);
userService.AddUser(user3);
userService.AddUser(user4);

var medicineService = new MedicineService(); // Instantiate MedicineService

while (true)
{
    Console.WriteLine("\nMenu:");
    Console.WriteLine("1. Add new medicine");
    Console.WriteLine("2. Get all medicines");
    Console.WriteLine("3. Find medicine by ID");
    Console.WriteLine("4. Find medicine by name");
    Console.WriteLine("5. Find medicines by category");
    Console.WriteLine("6. Remove  medicine");
    Console.WriteLine("7. Update  medicine");
    Console.WriteLine("8. Create  category");
    Console.WriteLine("10.GetAllCategory");
    Console.WriteLine("9. Exit");

    Console.Write("\nEnter your choice: ");
    int choice;
    if (!int.TryParse(Console.ReadLine(), out choice))
    {
        Console.WriteLine("Yalnısh daxiletme. Zehmet olmasa menyudan nomrə daxil edin.");
        continue;
    }

    switch (choice)
    {
        case 1:

            Console.WriteLine("Enter medicine :");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Category ID: ");
            int categoryId;
            if (!int.TryParse(Console.ReadLine(), out categoryId))
            {
                Console.WriteLine("Invalid category ID. Please enter a valid number.");
                continue;
            }
            Medicine newMedicine = new Medicine
            {
                Name = name,
                CategoryId = categoryId
            };
            try
            {
                medicineService.CreateMedicine(newMedicine);
                Console.WriteLine("Medicine added successfully.");
            }
            catch (NotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            break;
        case 2:

            var allMedicines = medicineService.GetAllMedicines();
            Console.WriteLine("\nAll Medicines:");
            foreach (var medicine in allMedicines)
            {
                Console.WriteLine($"ID: {medicine.Id}, Name: {medicine.Name}, Category ID: {medicine.CategoryId}");
            }
            break;
        case 3:

            Console.Write("Enter medicine ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID. Please enter  valid number.");
                continue;
            }
            try
            {
                var foundMedicine = medicineService.GetMedicineById(id);
                Console.WriteLine($"Medicine found: ID: {foundMedicine.Id}, Name: {foundMedicine.Name}, Category ID: {foundMedicine.CategoryId}");
            }
            catch (NotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            break;
        case 4:

            Console.Write("Enter medicine name: ");
            string searchName = Console.ReadLine();
            var medicinesByName = medicineService.GetMedicineByName(searchName);
            Console.WriteLine($"\nMedicines by name '{searchName}':");


            Console.WriteLine($"ID: {medicinesByName.Id}, Name: {medicinesByName.Name}, Category ID: {medicinesByName.CategoryId}");

            break;
        case 5:

            Console.Write("Enter category ID: ");
            if (!int.TryParse(Console.ReadLine(), out int searchCategoryId))
            {
                Console.WriteLine("Invalid category ID. Please enter  valid number.");
                continue;
            }
            var medicinesByCategory = medicineService.GetMedicineByCategory(searchCategoryId);
            Console.WriteLine($"\nMedicines found in category ID {searchCategoryId}:");
            foreach (var medicine in medicinesByCategory)
            {
                Console.WriteLine($"ID: {medicine.Id}, Name: {medicine.Name}, Category ID: {medicine.CategoryId}");
            }
            break;
        case 6:

            Console.Write("Enter medicine ID  remove: ");
            if (!int.TryParse(Console.ReadLine(), out int removeId))
            {
                Console.WriteLine("Invalid ID Please enter valid number");
                continue;
            }
            try
            {
                medicineService.RemoveMedicine(removeId);
                Console.WriteLine("Medicine removed successfully.");
            }
            catch (NotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            break;
        case 7:

            Console.Write("Enter medicine ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int updateId))
            {
                Console.WriteLine("Invalid ID. Please enter a valid number.");
                continue;
            }
            Console.WriteLine("Enter updated :");
            Console.Write("Name: ");
            string updatedName = Console.ReadLine();
            Console.Write("Category ID: ");
            int updatedCategoryId;
            if (!int.TryParse(Console.ReadLine(), out updatedCategoryId))
            {
                Console.WriteLine("Invalid category ID. Please enter  valid number.");
                continue;
            }
            Medicine updatedMedicine = new Medicine
            {
                Id = updateId,
                Name = updatedName,
                CategoryId = updatedCategoryId
            };
            try
            {
                medicineService.UpdateMedicine(updateId, updatedMedicine);
                Console.WriteLine("Medicine updated successfully.");
            }
            catch (NotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            break;
       
            
           
        case 9:

            Console.WriteLine("Exit");
            Environment.Exit(0);
            break;
        case 8:
            Console.WriteLine("Create Category :");
            Category category = new() {
                Name = Console.ReadLine()
            };
            CategoryService categoryService = new CategoryService();
            categoryService.CreateCategory(category);
           
            break;
        case 10:
            Category[] categories = medicineService1.GetAllCategory();
            foreach (var item in categories)
            {
                Console.WriteLine(item.Name + ""+ item.Id);
            }
            break;

        default:
            break;
       


    }
}


while (true)
{

    Console.WriteLine("Please enter your email:");
    string email = Console.ReadLine();
    Console.WriteLine("Please enter your password:");
    string password = Console.ReadLine();


    try
    {
        var loggedInUser = userService.Login(email, password);
        Console.WriteLine($"Logged : {loggedInUser.Fullname}");


    }
    catch (NotFoundException ex)
    {
        Console.WriteLine(ex.Message);
    }
}