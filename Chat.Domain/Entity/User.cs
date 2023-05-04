namespace Chat.Domain.Entity;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Login { get; set; }

    public ICollection<Room> Rooms { get; set; } = new List<Room>();

    public User(int id, string name, string login)
    {
        Id = id;
        Name = name;
        Login = login;
    }
}