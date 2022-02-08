using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroVideoz.Data
{
    public class Review
    {
        [Key]
        [Required]
        public int ReviewID { get; set; }
        [Required]
        [Display(Name = "Header")]
        public string ReviewHeader { get; set; }
        [Required]
        [Display(Name = "Text")]
        public string ReviewText { get; set; }
        [Required]
        [Display(Name = "Star Rating")]
        public decimal StarRating { get; set; }
        [Required]
        [Display(Name = "Would Recommend?")]
        public bool WouldRecommend { get; set; }
        [Required]
        [Display(Name = "Date Added")]
        public DateTime? DateAdded { get; set; }
        [ForeignKey(nameof(Video))]
        [Required]
        public int VideoID { get; set; }
        public virtual Video Video { get; set; }
        [ForeignKey(nameof(ApplicationUser))]
        [Required]
        public string UserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public Guid OwnerID { get; set; }
    }
}
