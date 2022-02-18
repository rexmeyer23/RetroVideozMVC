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
    public class CartLineItemListed
    {
        public int CartItemID { get; set; }
        public decimal TotalQuantity { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
        //[Required]
        //[ForeignKey(nameof(Cart))]
        //public int CartID { get; set; }
        //public virtual Cart Cart { get; set; }
        //[Required]
        public string Title { get; set; }
    }
}
