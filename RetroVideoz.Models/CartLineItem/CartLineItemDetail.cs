using RetroVideoz.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroVideoz.Models
{
    public class CartLineItemDetail
    {
        public int CartItemID { get; set;}
        [Required]
        public decimal TotalQuantity { get; set; }
        public decimal TotalPrice { get; set; }
        //[Required]
        //[ForeignKey(nameof(Cart))]
        //public int CartID { get; set; }
        //public virtual Cart Cart { get; set; }
        [Required]
        [ForeignKey(nameof(Video))]
        public string Title { get; set; }
        public virtual Video Video { get; set; }
    }
}
