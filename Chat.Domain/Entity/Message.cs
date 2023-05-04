namespace Chat.Domain.Entity;

public class Message
{
    public int Id { get; set; }
    public string Text { get; set; }

    public Message(int id, string text)
    {
        Id = id;
        Text = text;
    }
}