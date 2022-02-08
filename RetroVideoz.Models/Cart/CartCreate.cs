using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetroVideoz.Data;

namespace RetroVideoz.Models
{
    public class CartCreate
    {
        public int CartID { get; set; }
        
        [Required,ForeignKey(nameof(Transaction))]
        public int TransactionID { get; set; }
       public virtual Transaction Transaction { get; set; }
        //public string VideosInCartIDs {get; set;}
    }
}
