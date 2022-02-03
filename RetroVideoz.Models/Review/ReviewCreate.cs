using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroVideoz.Models.Review
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
    }
}
