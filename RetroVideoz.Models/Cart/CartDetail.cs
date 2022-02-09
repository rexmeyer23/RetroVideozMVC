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
    public class CartDetail
    {
        public int CartID { get; set; }
        [Required, ForeignKey(nameof(Transaction))]
        public int TransactionID { get; set; }
        public virtual Transaction Transaction { get; set; }
        public ICollection<Video> VideosInCart { get; set; }
        public string UserID { get; set; }
    }
}