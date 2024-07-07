using ConsoleAppMedicineService.Exceptions;
using ConsoleAppMedicineService;

public class UserService
{
    public void AddUser(User user)
    {
        Array.Resize(ref DB.Users, DB.Users.Length + 1);
        user.Id = GenerateUserId();
        DB.Users[DB.Users.Length - 1] = user;
    }

    public User Login(string email, string password)
    {
        var user = DB.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        if (user == null)
        {
            throw new NotFoundException("User not found");
        }
        return user;
    }

    private int GenerateUserId()
    {
        return DB.Users.Length + 1;
    }
}
