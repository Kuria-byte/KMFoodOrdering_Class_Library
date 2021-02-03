using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clKMFoodOrderingSystem.Models
{
   public class mBusinessUser
    {
        public int BusinessUserID;
        public string BusinessUserName;
        public string BusinessUserEmail;
        public string BusinessUserPassword;
        public bool IsActive;
        public bool IsEmailVerified;
        public string BusinessUserIDEncrypted;
        public DateTime LastLogin;
        public DateTime BusinessSignupDate;

    }
}
