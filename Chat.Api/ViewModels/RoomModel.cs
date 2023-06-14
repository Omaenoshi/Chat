using System.ComponentModel.DataAnnotations;

namespace Chat.Api.ViewModels
{
    public class RoomModel
    {
        [Required] public string Title { get; set; }
    }
}
