using System.ComponentModel.DataAnnotations;

namespace UserTracker.Models
{
    public class CreateLogViewModel
    {
        [Required(AllowEmptyStrings = false)]
        public string CurrentPage { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string NextPage { get; set; }
    }
}