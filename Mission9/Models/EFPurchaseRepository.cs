using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9.Models
{
    //inherits from IPurchaseRepository
    public class EFPurchaseRepository : IPurchaseRepository
    {
        //Brings in context
        private Mission9Context context;
        public EFPurchaseRepository (Mission9Context temp)
        {
            context = temp;
        }
        //Includes the books from basket
        public IQueryable<Purchase> Purchases => context.Purchases.Include(x => x.Lines).ThenInclude(x => x.Book);
        //saves the purchases to the database
        public void SavePurchase(Purchase purchase)
        {
            context.AttachRange(purchase.Lines.Select(x => x.Book));
            
            if (purchase.PurchaseId == 0)
            {
                context.Purchases.Add(purchase);
            }

            context.SaveChanges();
        }
    }
}
