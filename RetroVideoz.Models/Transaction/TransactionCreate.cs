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
    public class TransactionCreate
    {
        public int TransactionID { get; set; }
        [Required]
        public int CartID { get; set; }
        public virtual Cart Cart { get; set; }
        [ForeignKey(nameof(ApplicationUser))]
        public string UserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        [Required]
        [Display(Name = "Transaction Date")]
        public DateTime? TransactionDate { get; set; }
        [Required, Display(Name = "Quantity Bought")]
        public int QuantityBought { get; set; }
    }
}
