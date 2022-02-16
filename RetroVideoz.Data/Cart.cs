using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroVideoz.Data
{
    public class Cart
    {
        [Key]
        public int CartID { get; set; }
        public decimal TotalPrice { get { return GetTotalPrice(); } set { TotalPrice = value; } } //add method to calculate total price
      
        [Required]
        [ForeignKey(nameof(ApplicationUser))]
        public string UserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
       
        public decimal GetTotalPrice()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            List<CartLineItem> list = context.CartLineItems.ToList();
            decimal totalPrice = 0;
            foreach(CartLineItem line in list)
            {
                if(line.CartID == CartID)
                {
                   totalPrice += line.CartLineItemPrice;
                }
              
            }
            return totalPrice;
        }
    }
    //public class CartLineItem
    //{
    //    [Key]
    //    [Required]
    //    public int CartItemID { get; set; }
    //    [Required]
    //    [Display(Name= "Total Quantity")]
    //    public decimal TotalQuantity { get; set; }
    //    //cart foreign key - one to many
    //    [Required]
    //    [ForeignKey(nameof(Cart))]
    //    public int CartID { get; set; }
    //    public virtual Cart Cart { get; set; }
    //    //video foreign - one to one
    //    [Required]
    //    [ForeignKey(nameof(Video))]
    //    public int VideoID { get; set; }    
    //    public virtual Video Video { get; set; }
    //    public decimal CartLineItemPrice { get
    //        {
    //           return Video.Price * TotalQuantity;
    //        } }
  

    //    //create controller
    //    //add and remove from cart 
    //    //
    //}
}
