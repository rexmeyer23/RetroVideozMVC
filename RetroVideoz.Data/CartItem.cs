using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroVideoz.Data
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }
        public Video Video { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartID { get; set; }
    }
}
