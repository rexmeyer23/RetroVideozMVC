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

        public string TransactionId { get; set; }
        [Display(Name = "Date of Transaction")]
        public DateTime? TransactionDate { get; set; }
       

    }
}
