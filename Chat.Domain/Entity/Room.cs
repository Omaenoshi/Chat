namespace Chat.Models;

public class Room
{
    public int Id { get; set; }
    public string Title { get; set; }
    public ICollection<User> Users { get; set; }

    public Room(int id, string title, ICollection<User> users)
    {
        Id = id;
        Title = title;
        Users = users;
    }
}