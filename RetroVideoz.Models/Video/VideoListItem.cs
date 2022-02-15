using RetroVideoz.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroVideoz.Models
{
    public class VideoListItem
    {
        private List<VideoListItem> _list;
        public int VideoID { get; set; }
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Display(Name = "Year")]
        public int Year { get; set; }
        [Display(Name = "Format")]
        public HomeVideoFormat Format { get; set; }
        [Display(Name = "Price")]
        public decimal Price { get; set; }
        [Required, Display(Name = "Quantity")]
        public int Quantity { get; set; }
    }
}
