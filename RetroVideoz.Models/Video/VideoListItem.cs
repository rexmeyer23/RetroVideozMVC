using RetroVideoz.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroVideoz.Models.Video
{
    public class VideoListItem
    {
        public int VideoID { get; set; }
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Year")]
        public int Year { get; set; }
        [Display(Name = "Rating")]
        public ContentRating Rating { get; set; }
        [Display(Name = "Genre")]
        public GenreType Genre { get; set; }
        [Display(Name = "Format")]
        public HomeVideoFormat Format { get; set; }
        [Display(Name = "Price")]
        public decimal Price { get; set; }
    }
}
