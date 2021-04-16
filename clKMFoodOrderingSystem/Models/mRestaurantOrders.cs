using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clKMFoodOrderingSystem.Models
{
   public class mRestaurantOrders
    {
        public int OrderID;
        public string SessionID;
        public int RestaurantID;
        public int SubscriptionID;
        public int DiningExpereince;
        public int TableNumber;
        public decimal GrandTotal;
        public DateTime OrderDate;
        public int IsProcessed;
        public string CustomerName;
        public string CustomerEmail;
        public string CustomerPhone;
        public string OrderNotes;

    }
}
