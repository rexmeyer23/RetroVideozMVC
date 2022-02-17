using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroVideoz.Data
{
    public class CartLineItem
    {
        [Key]
        [Required]
        public int CartItemID { get; set; }
        [Required]
        [Display(Name = "Total Quantity")]
        public decimal TotalQuantity { get; set; }
        //cart foreign key - one to many
     
        [ForeignKey(nameof(Cart))]
        public int? CartID { get; set; }
        public virtual Cart Cart { get; set; }
        //video foreign - one to one
 
        [ForeignKey(nameof(Video))]
        public int VideoID { get; set; }
        public virtual Video Video { get; set; }
        public decimal CartLineItemPrice
        {
            get
            {
                return Video.Price * TotalQuantity;
            }
        }


        //create controller
        //add and remove from cart 
        //
    }
}
