namespace Chat.Models;

public class Message
{
    public int Id { get; }
    public string Text { get; }

    public Message(int id, string text)
    {
        Id = id;
        Text = text;
    }
}