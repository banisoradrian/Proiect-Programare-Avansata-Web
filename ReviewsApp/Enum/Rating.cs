using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace ReviewsApp.Rating
{
    public enum Rating
    {
        [Display(Name ="✨")]
        One = 1,
        [Display(Name = "✨✨")]
        Two = 2,
        [Display(Name = "✨✨✨")]
        Three = 3,
        [Display(Name = "✨✨✨✨")]
        Four = 4,
        [Display(Name = "✨✨✨✨✨")]
        Five = 5
    }
}
