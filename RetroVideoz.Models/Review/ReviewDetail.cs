using RetroVideoz.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroVideoz.Models
{
    public class ReviewDetail
    {
       public int ReviewID { get; set; }
        [Required]
        [Display(Name = "Video")]
        public int VideoID { get; set; }
        public string VideoTitle { get; set; }
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
        [Display(Name = "Date Review was Added")]
        public DateTime? DateAdded { get; set; }
        
       
      
       
    }
}
