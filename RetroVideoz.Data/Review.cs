using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroVideoz.Data
{
    public class Review
    {
        [Key]
        [Required]
        public int ReviewID { get; set; }
        [Required]
        public string ReviewHeader { get; set; }
        [Required]
        public string ReviewText { get; set; }
        [Required]
        public decimal StarRating { get; set; }
        [Required]
        public bool WouldRecommend { get; set; }
        [ForeignKey(nameof(Video))]
        [Required]
        public int VideoID { get; set; }
        public virtual Video Video { get; set; }
        [ForeignKey(nameof(ApplicationUser))]
        [Required]
        public int UserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
