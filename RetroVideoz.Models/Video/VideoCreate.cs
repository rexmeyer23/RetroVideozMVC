using RetroVideoz.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroVideoz.Models
{
    public class VideoCreate
    {
        public int VideoID { get; set; }
        [Display(Name = "Title")]
        [Required]
        public string Title { get; set; }
        [Display(Name = "Description")]
        [Required]
        public string Description { get; set; }
        [Display(Name = "Year")]
        [Required]
        public int Year { get; set; }
        [Display(Name = "Rating")]
        [Required]
        public ContentRating Rating { get; set; }
        [Display(Name = "Genre")]
        [Required]
        public GenreType Genre { get; set; }
        [Display(Name = "Format")]
        [Required]
        public HomeVideoFormat Format { get; set; }
        [Display(Name = "Price")]
        [Required]
        public decimal Price { get; set; }
        public int CartID { get; set; }

        [Display(Name = "User")]
        public string UserID { get; set; }
        [Display(Name ="Video Image")]
        public byte[] Image { get; set; }   
     




    }
}
