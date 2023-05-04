namespace Chat.Domain;

public class Room
{
    public int Id { get; set; }
    public string Title { get; set; }
    public ICollection<User> Users { get; set; }
}