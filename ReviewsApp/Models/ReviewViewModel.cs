using Microsoft.AspNetCore.Identity;
using ReviewsApp.Data;
using System.ComponentModel.DataAnnotations;

namespace ReviewsApp.Models
{
    public class ReviewViewModel
    {
        public Guid ID { get; set; }
        [Required]
        public string TITLE { get; set; }
        public string CONTENT { get; set; }
        public DateTime CREATED { get; set; }
        public DateTime MODIFIED { get; set; }
        public int RATING { get; set; }
        [Required]
        public string SUBJECT { get; set; }
        public string CREATEDBY { get; set; }

        [Display(Name ="Created By")]
        public string CREATEDBYUSER{ get; set; }

        public bool HasEditAndDeletePermissions { get; set; }

        public static ReviewViewModel FromEntity(Review entity)
        {
            return new ReviewViewModel
            {
                ID = entity.ID,
                TITLE = entity.TITLE,
                CONTENT = entity.CONTENT,
                CREATED = entity.CREATED,
                MODIFIED = entity.MODIFIED,
                RATING = entity.RATING,
                SUBJECT = entity.SUBJECT,
                CREATEDBY = entity.CREATEDBY?.Id,
                CREATEDBYUSER = entity.CREATEDBY?.UserName
            };
        }

        public Review ToEntity()
        {
            return new Review
            {
                ID = ID,
                TITLE = TITLE,
                CONTENT = CONTENT,
                CREATED = CREATED,
                MODIFIED = MODIFIED,
                RATING = RATING,
                SUBJECT = SUBJECT,
            };
        }
    }
}

