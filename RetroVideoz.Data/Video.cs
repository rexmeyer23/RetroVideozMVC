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
        [Required]
        public int VideoID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public ContentRating Rating { get; set; }
        [Required]
        public GenreType Genre { get; set; }
        [Required]
        public HomeVideoFormat Format { get; set; }
        [Required]
        public decimal Price { get; set; }
        [ForeignKey(nameof(ApplicationUser))]
        [Required]
        public string UserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public byte[] Image { get; set; }

        //adding image
        public Guid OwnerID { get; set; }

    }
}
