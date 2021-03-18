using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clKMFoodOrderingSystem.Models
{
  public class mRestaurant
    {
        public int RestaurantID;
        public int RestaurantTypeID;
        public string RestaurantName;
        public string RestaurantDescription;
        public string RestaurantContactNumber;
        public string RestaurantEmailAddress;
        public string RestaurantAddress;
        public int CityID;
        public int CountryID;
        public int StateID;
        public string RestaurantLogo;
        public DateTime RestaurantAddedOn;
        public bool isActive;
        public int BusinessUserID;
        public string MessageOnOrderIsReady;
    }
}
