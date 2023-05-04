namespace Chat.Domain;

public class Message
{
    public int Id { get; set; }
    public string Text { get; set; }
    public User User { get; set; }
    public Room Room { get; set; }
}