using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroVideoz.Data
{
    public enum ContentRating
    {
        G = 1,
        PG,
        PG_13,
        R,
        NC_17,
        NR
    }
    public enum GenreType
    {
        Horror = 1,
        Thriller,
        Documentary,
        RomCom,
        Romance,
        Drama,
        Action,
        Comedy,
        Animated
    }
    public enum HomeVideoFormat
    {
        VHS = 1,
        DVD,
        Bluray,
        UHD
    }
    public class Video
    {
        [Key]
        public int VideoID { get; set; }
        [Required]
        [Display(Name = "Movie")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Year")]
        public int Year { get; set; }
        [Required]
        [Display(Name = "Rating")]
        public ContentRating Rating { get; set; }
        [Required]
        [Display(Name = "Genre")]
        public GenreType Genre { get; set; }
        [Required]
        [Display(Name = "Format")]
        public HomeVideoFormat Format { get; set; }
        [Required]
        [Display(Name = "Price")]
        public decimal Price { get; set; }
        [Required, Display(Name = "Quantity")]
        public int Quantity { get; set; }

        //stretch goal
        //adding image
        public byte[] Image { get; set; }

     
        public Guid OwnerID { get; set; }

       
    }
}
