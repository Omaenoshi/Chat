namespace Chat.Domain.Entity;

public class Message
{
    public int Id { get; set; }
    public string Text { get; set; }
    public User User { get; set; }
    public Room Room { get; set; }

    public Message(int id, string text, User user, Room room)
    {
        Id = id;
        Text = text;
        User = user;
        Room = room;
    }
}