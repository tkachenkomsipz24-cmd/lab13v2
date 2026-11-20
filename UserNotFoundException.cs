using System.Runtime.Serialization;

namespace Lab13v2;

[Serializable]
public class UserNotFoundException : Exception
{
    public string Username { get; } = string.Empty;

    public UserNotFoundException()
        : base("Користувача не знайдено.")
    {
    }

    public UserNotFoundException(string username)
        : base($"Користувача '{username}' не знайдено.")
    {
        Username = username;
    }

    public UserNotFoundException(string username, Exception innerException)
        : base($"Користувача '{username}' не знайдено.", innerException)
    {
        Username = username;
    }

#pragma warning disable SYSLIB0051
    protected UserNotFoundException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
        Username = info.GetString(nameof(Username)) ?? string.Empty;
    }

    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        base.GetObjectData(info, context);
        info.AddValue(nameof(Username), Username);
    }
#pragma warning restore SYSLIB0051
}
