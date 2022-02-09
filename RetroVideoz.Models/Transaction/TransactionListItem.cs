using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroVideoz.Models
{
    public class TransactionListItem
    {
        public int TransactionID { get; set; }
        [Display(Name = "User")]
        public string UserID { get; set; }
        public string Username { get; set; }
        [Display(Name = "Date of Transaction")]
        public DateTime? TransactionDate { get; set; }
    }
}
