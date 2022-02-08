using RetroVideoz.Data;
using RetroVideoz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroVideoz.Services
{
    //public class TransactionService
    //{
    //    public int TransactionID { get; set; }
    //    public List<Video> Videos { get; set; }
    //    public bool CreateTransaction(TransactionCreate model)
    //    {
    //        var entity =
    //            new Transaction()
    //            {
    //                TransactionID = model.TransactionID,
    //                UserID = model.UserID,
                    
    //                TransactionDate = DateTime.Now
    //            };
    //        using (var ctx = new ApplicationDbContext())
    //        {
    //            ctx.Transactions.Add(entity);
    //            return ctx.SaveChanges() == 1;
    //        }
    //    }
    //    public IEnumerable<TransactionListItem> GetTransactions()
    //    {
    //        using (var ctx = new ApplicationDbContext())
    //        {
    //            var query = ctx.Transactions.ToList();
    //            List<TransactionListItem> transactions = new List<TransactionListItem>();
    //            foreach(Transaction transaction in query)
    //            {
    //                TransactionListItem item = new TransactionListItem
    //                {
    //                    TransactionID = transaction.TransactionID,
                        
    //                    TransactionDate = transaction.TransactionDate,
    //                };
    //                transactions.Add(item);
    //            }
    //            return transactions;
    //        }
    //    }
    //    public IEnumerable<TransactionListItem> GetTransactionsByUser(string userID)
    //    {
    //        using (var ctx = new ApplicationDbContext())
    //        {
    //            var query =
    //                ctx
    //                .Transactions
    //                .Where(e => e.UserID == userID)
    //                .OrderBy(e => e.TransactionDate)
    //                .Select(e => new TransactionListItem
    //                {
    //                    TransactionID = e.TransactionID,
                        
    //                    TransactionDate = e.TransactionDate,
    //                });
    //            return query.ToArray();
    //        }
    //    }
    //    //public bool AddMovieToTransaction(Video video)
    //    //{
    //    //    using(var ctx = new ApplicationDbContext())
    //    //    {
    //    //        var entity =
    //    //            ctx
    //    //            .Transactions
    //    //            .Where(e => e.Video.VideoID == video.VideoID && e.TransactionID == TransactionID);
    //    //    }
    //    //}
    //}
}
