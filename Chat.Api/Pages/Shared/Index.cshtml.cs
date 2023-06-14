using Chat.Database;
using Chat.Domain;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Chat.Api.Pages.Shared
{
    public class IndexModel : PageModel
    {
        private readonly ChatDbContext _context;

        public static List<Room> Rooms { get; set; } = new List<Room>();

        public IndexModel(ChatDbContext context)
        {
            _context = context;
            Rooms = _context
                .Queryable<Room>().Include(x => x.Users)
                .AsNoTracking().ToList();
        }
        public void OnGet()
        {
            Rooms = _context.Rooms.AsNoTracking().ToList();
        }
    }
}
