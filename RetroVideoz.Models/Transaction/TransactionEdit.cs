using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroVideoz.Models.Transaction
{
    public class TransactionEdit
    {

        public int TransactionID { get; set; }
        [Display(Name = "Video")]
        public int VideoID { get; set; }
        [Display(Name = "User")]
        public string UserID { get; set; }
        [Display(Name = "Date of Transaction")]
        public DateTime? TransactionDate { get; set; }
       

    }
}
