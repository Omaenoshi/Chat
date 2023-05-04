namespace Chat.Domain.Entity;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Login { get; set; }

    public ICollection<Room> Rooms { get; set; }

    public User(int id, string name, string login)
    {
        Id = id;
        Name = name;
        Login = login;
        Rooms = new List<Room>();
    }
    
    public User(int id, string name, string login, ICollection<Room> rooms)
    {
        Id = id;
        Name = name;
        Login = login;
        Rooms = rooms;
    }
}