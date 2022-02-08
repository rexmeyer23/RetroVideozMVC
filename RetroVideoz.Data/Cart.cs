using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroVideoz.Data
{
    public class Cart
    {
        [Key]
        public int CartID { get; set; }
        [Required]
        public IEnumerable<Video> Videos { get; set; }
        [Required]
        [ForeignKey(nameof(Transaction))]
        public int TransactionID { get; set; }
        public Transaction Transaction { get; set; }
    }
}
