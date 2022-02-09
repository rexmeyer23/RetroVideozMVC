using RetroVideoz.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroVideoz.Models
{
    public class ReviewCreate
    {
        public int ReviewID { get; set; }
        [Display(Name = "Header")]
        public string ReviewHeader { get; set; }
        [Display(Name = "Text")]
        public string ReviewText { get; set; }
        [Display(Name = "Star Rating")]
        public decimal StarRating { get; set; }
        [Display(Name = "Would Recommend?")]
        public bool WouldRecommend { get; set; }
        [Display(Name = "Date Added")]
        public DateTime? DateAdded { get; set; }
        [ForeignKey(nameof(Video))]
        [Required, Display(Name = "Movie")]
        public int VideoID { get; set; }
        public virtual Video Video { get; set; }
        [Display(Name = "User")]
        public string UserID { get; set; }
    }
}
