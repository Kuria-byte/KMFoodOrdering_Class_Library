using clKMFoodOrderingSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clKMFoodOrderingSystem.Controllers
{
   public class cCountry
    {
        public static DataTable GetCountryList()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT  * FROM   countries ORDER BY name ASC", con))
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


        public static int UpdateCountry(mCountry pCountry)
        {

            int isSucess = 0;

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("UPDATE countries SET  [LanguageCountryCode] = @LanguageCountryCode, [USDConversion] = @USDConversion, [TimeZone] = @TimeZone  " +
                                                            " WHERE id = @id ", con))

                {
                    command.Parameters.AddWithValue("@id", pCountry.id);
                    command.Parameters.AddWithValue("@LanguageCountryCode", pCountry.LanguageCountryCode);
                    command.Parameters.AddWithValue("@USDConversion", pCountry.USDConversion);
                    command.Parameters.AddWithValue("@TimeZone", pCountry.TimeZone);



                    isSucess = command.ExecuteNonQuery();


                }
            }

            return isSucess;

        }

    }

    


}
