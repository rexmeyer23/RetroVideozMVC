using RetroVideoz.Data;
using RetroVideoz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroVideoz.Services
{
    public class TransactionService
    {
    public bool CreateTransaction(TransactionCreate model)
        {
            var entity =

                new Transaction()
                {
                    TransactionID = model.TransactionID,
                    CartID = model.CartID,
                    TransactionDate = DateTime.Now,
                   
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Transactions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<TransactionListItem> GetTransactions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Transactions.ToArray();
                List<TransactionListItem> list = new List<TransactionListItem>();
                foreach (Transaction transaction in query)
                {
                    TransactionListItem transactions = new TransactionListItem
                    {
                        TransactionID=transaction.TransactionID,
                        TransactionDate = transaction.TransactionDate
                    };
                    list.Add(transactions);
                }
                return list;
            }
        }
        public IEnumerable<TransactionListItem> GetTransactionByID(int transactionID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Transactions
                    .Where(e => e.TransactionID == transactionID)
                    .Select(e => new TransactionListItem
                    {
                        TransactionID = e.TransactionID,
                        TransactionDate = e.TransactionDate
                    });
                return query.ToList();
            }
        }
        public bool DeleteTransaction(int transactionID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                 var entity = 
                    ctx
                    .Transactions
                    .Single(e => e.TransactionID==transactionID);
                ctx.Transactions.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        //public bool UpdateTransaction(TransactionEdit model)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var entity =
        //            ctx
        //            .Transactions
        //            .Single(e => e.TransactionID == model.TransactionID);

        //        return ctx.SaveChanges() == 1;
        //    }
        //}

    }
}
