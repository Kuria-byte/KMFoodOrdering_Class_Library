using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clKMFoodOrderingSystem.Models
{
    public class mPayment
    {
        public int PaymentID;
        public int SubscriptionID;
        public int BusinessUserID;
        public float Total;
        public bool IsPaymentRecieved;
        public DateTime PaymentDate;
     
    }
}
