using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroVideoz.Models.Transaction
{
    public class TransactionEdit
    {
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
        public int UserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public byte[] Image { get; set; }

        //adding image

    }
}
