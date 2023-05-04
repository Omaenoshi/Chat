namespace Chat.Models;

public class User
{
    public int Id { get; }
    public string Name { get; }
    public string Login { get; }

    public User(int id, string name, string login)
    {
        Id = id;
        Name = name;
        Login = login;
    }
}