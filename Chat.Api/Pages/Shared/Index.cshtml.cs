using Chat.Domain;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Chat.Api.Pages.Shared;

public class IndexModel : PageModel
{
    public IndexModel(IEnumerable<Room> rooms)
    {
        Rooms = rooms.ToList();
    }

    public static List<Room> Rooms { get; set; } = new();

    public void OnGet()
    {
    }
}