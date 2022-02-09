using RetroVideoz.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroVideoz.Models
{
    public class ReviewListItem
    {
        public int ReviewID { get; set; }
        [Required]
        [Display(Name = "Header")]
        public string ReviewHeader { get; set; }
        [Required]
        [Display(Name = "Star Rating")]
        public decimal StarRating { get; set; }
        [Display(Name = "Date Added")]
        public DateTime? DateAdded { get; set; }
        //[Required]
        //[Display(Name = "User")]
        //public string UserID { get; set; }
        //public string Username { get; set; }
        public string Video { get; set; }
        [Display(Name = "Video")]
        public string VideoTitle { get; set;}
        
    }
}
