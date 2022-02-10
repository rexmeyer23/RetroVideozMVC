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
        public ICollection<Video> VideosInCart { get; set; }
        //[Required]
        //[ForeignKey(nameof(Transaction))]
        //public int TransactionID { get; set; }
        //public Transaction Transaction { get; set; }
        public Cart()
        {
            VideosInCart = new HashSet<Video>();
        }
        [Required]
        [ForeignKey(nameof(ApplicationUser))]
        public string UserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
       
    }
    public class CartLineItem
    {
        public int CartItemID { get; set; }
        public int TotalQuantity { get; set; }
        //cart foreign key - one to many
        //video foreign - one to one

        //create controller
        //add and remove from cart 
        //
    }
}
