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
        public int VideoID { get; set; }
        public virtual Video Video { get; set; }

    }
}
