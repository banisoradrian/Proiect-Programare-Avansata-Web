using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ReviewsApp.Data
{
    public class Review
    {
        
        public Guid ID { get; set; }
        public string TITLE { get; set; }
        public string CONTENT { get; set; }
        public DateTime CREATED { get; set; }
        public DateTime MODIFIED{ get; set; }
        public int RATING { get; set; }
        public string SUBJECT { get; set; }
        public IdentityUser CREATEDBY { get; set; }
    }
}
