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
    public class CartLineItemCreate
    {
        public int CartItemID { get; set; }
        [Required]
        public int TotalQuantity { get; set; }
        [Required]
        [ForeignKey(nameof(Cart))]
        public int CartID { get; set; }
        public virtual Cart Cart { get; set; }

    }
}
