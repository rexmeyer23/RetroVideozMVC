using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroVideoz.Models
{
    public class VideoCartItems
    {
       
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Display(Name = "Price")]
        public decimal Price { get; set; }
        [Required, Display(Name = "Quantity")]
        public int Quantity { get; set; }
    }
}
