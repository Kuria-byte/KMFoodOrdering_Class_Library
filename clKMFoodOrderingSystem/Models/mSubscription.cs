using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clKMFoodOrderingSystem.Models
{
  public class mSubscription
    {
        public int SubscriptionID;
        public int RestaurantID;
        public int SubscriptionTypeID;
        public int NumberOfTables;
        public float Total;
        public DateTime StartedDate;
        public DateTime EndDate;
        public bool IsActive;
        public int BusinessUserID;
        public string AttachedPaymentReceipt;
        public int StatusID;
    }
}
