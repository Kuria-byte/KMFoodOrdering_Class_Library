using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clKMFoodOrderingSystem.Controllers
{
   public class cRestaurantType
    {
        
            public static DataTable GetRestaurantCategory()
            {
                DataTable dt = new DataTable();

                using (SqlConnection con = new SqlConnection(Global.connString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT  * FROM   tblRestaurantType ORDER BY RestaurantTypeID ASC", con))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            cmd.CommandType = CommandType.Text;

                            sda.Fill(dt);


                        }
                    }
                }
                return dt;
            }
        }
    
}
