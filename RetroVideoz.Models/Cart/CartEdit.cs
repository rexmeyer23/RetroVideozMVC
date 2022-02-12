﻿using RetroVideoz.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroVideoz.Models
{
    public class CartEdit
    {
        public int CartID { get; set; }
        [Required,ForeignKey(nameof(Transaction))]
        public int TransactionID { get; set; }
        public virtual Transaction Transaction { get; set; }
        public string UserID { get; set; }

    }
    public class CartLineItemEdit
    {
        public int CartItemID { get; set; }
        [Required]
        public int TotalQuantity { get; set; }
        [Required]
        [ForeignKey(nameof(Cart))]
        public int CartID { get; set; }
        public virtual Cart Cart { get; set; }
       
        [Required]
        [ForeignKey(nameof(Video))]
        public int VideoID { get; set; }
        public virtual Video Video { get; set; }
    }
}
