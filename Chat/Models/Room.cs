namespace Chat.Models;

public class Room
{
    public int Id { get; }
    public string Title { get; }
    public ICollection<User> Users { get; }

    public Room(int id, string title, ICollection<User> users)
    {
        Id = id;
        Title = title;
        Users = users;
    }
}