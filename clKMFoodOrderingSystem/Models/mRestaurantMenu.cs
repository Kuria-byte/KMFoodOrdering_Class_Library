using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clKMFoodOrderingSystem.Models
{
  public class mRestaurantMenu
    {
        public int MenuID;
        public int RestaurantID;
        public int MenuCategoryID;
        public string MenuName;
        public string LongMenuDescription;
        public string ShortMenuDescription;
        public string MenuIngredients;
        public string Price;
        public string MenuPicture;
        public bool IsActive;
    }
}
