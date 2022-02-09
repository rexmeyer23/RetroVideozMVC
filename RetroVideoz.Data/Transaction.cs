﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroVideoz.Data
{
    public class Transaction
    {
        [Key]
        public int TransactionID { get; set; }
        [ForeignKey(nameof(Cart))]
        public int CartID { get; set; }
        public virtual Cart Cart { get; set; }
 
        [Required]
        [Display(Name = "Transaction Date")]
        public DateTime? TransactionDate { get; set; }
    }
}
