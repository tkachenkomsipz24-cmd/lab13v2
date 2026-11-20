using System.Text;

namespace Lab13v2;

public static class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        var service = new UserService();

        Console.WriteLine("=== 1. Власний виняток: GetUser ===");
        TryGetUser(service, "admin");
        TryGetUser(service, "ghost");

        Console.WriteLine();
        Console.WriteLine("=== 2. Патерн Result<T>: RegisterUser ===");
        PrintRegistration(service, "maksym", "secret123");
        PrintRegistration(service, "maksym", "another123");
        PrintRegistration(service, "newuser", "123");
    }

    private static void TryGetUser(UserService service, string username)
    {
        try
        {
            var user = service.GetUser(username);
            Console.WriteLine($"Знайдено користувача: {user.Username}");
        }
        catch (UserNotFoundException ex)
        {
            Console.WriteLine($"Помилка (виняток): {ex.Message} [Username = {ex.Username}]");
        }
    }

    private static void PrintRegistration(UserService service, string username, string password)
    {
        var result = service.RegisterUser(username, password);

        if (result.IsSuccess)
        {
            Console.WriteLine($"Користувача '{username}' зареєстровано.");
        }
        else
        {
            Console.WriteLine($"Помилка (Result): {result.Error}");
        }
    }
}
