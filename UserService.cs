namespace Lab13v2;

public class UserService
{
    private const int MinPasswordLength = 6;

    private readonly Dictionary<string, User> _users =
        new Dictionary<string, User>(StringComparer.OrdinalIgnoreCase);

    public UserService()
    {
        _users["admin"] = new User("admin", "admin123");
    }

    public User GetUser(string username)
    {
        if (string.IsNullOrWhiteSpace(username) || !_users.TryGetValue(username, out var user))
        {
            throw new UserNotFoundException(username ?? string.Empty);
        }

        return user;
    }

    public Result<bool> RegisterUser(string username, string password)
    {
        if (string.IsNullOrWhiteSpace(username))
        {
            return Result<bool>.Failure("Ім'я користувача не може бути порожнім.");
        }

        if (_users.ContainsKey(username))
        {
            return Result<bool>.Failure($"Користувач '{username}' уже існує.");
        }

        if (string.IsNullOrEmpty(password) || password.Length < MinPasswordLength)
        {
            return Result<bool>.Failure($"Пароль занадто короткий (мінімум {MinPasswordLength} символів).");
        }

        _users[username] = new User(username, password);
        return Result<bool>.Success(true);
    }
}
