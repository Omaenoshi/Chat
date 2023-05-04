namespace Chat.Domain;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Login { get; set; }

    public ICollection<Room> Rooms { get; set; }
}