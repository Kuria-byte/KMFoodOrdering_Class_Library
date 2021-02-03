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
    public class cRestaurantSteps
    {
        public static DataTable GetRestaurantSteps()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT  * FROM   tblRestaurantOnboardingSteps ORDER BY RestaurantID ASC", con))
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

        public static DataTable GetRestaurantStepsbyBusinessID(int _BusinessUserID) 
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT  * FROM   tblRestaurantOnboardingSteps WHERE BusinessUserID = @BusinessUserID  ORDER BY BusinessUserID ASC", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@BusinessUserID", _BusinessUserID);

                        sda.Fill(dt);


                    }
                }
            }
            return dt;
        }


        public static int AddRestaurantSteps(mRestaurantSteps pRestaurantSteps)
        {

            int isSucess = 0;

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO tblRestaurantOnboardingSteps (BusinessUserID, RestaurantID, SubscriptionID, Step1, Step2, Step3, Step4) " +
                                                            " VALUES (@BusinessUserID, @RestaurantID, @SubscriptionID, @Step1, @Step2, @Step3, @Step4) ", con))
                {
                    command.Parameters.AddWithValue("@BusinessUserID", pRestaurantSteps.BusinessUserID);
                    command.Parameters.AddWithValue("@RestaurantID", pRestaurantSteps.RestaurantID);
                    command.Parameters.AddWithValue("@SubscriptionID", pRestaurantSteps.SubscriptionID);
                    command.Parameters.AddWithValue("@Step1", pRestaurantSteps.Step1);
                    command.Parameters.AddWithValue("@Step2", pRestaurantSteps.Step2);
                    command.Parameters.AddWithValue("@Step3", pRestaurantSteps.Step3);
                    command.Parameters.AddWithValue("@Step4", pRestaurantSteps.Step4);

                    isSucess = command.ExecuteNonQuery();


                }
            }




            return isSucess;


        }



        public static int UpdateRestaurantSteps(mRestaurantSteps pRestaurantSteps)
        {

            int isSucess = 0;

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("UPDATE tblRestaurantOnboardingSteps SET  [RestaurantID] = @RestaurantID, [SubscriptionID] = @SubscriptionID, [Step1] = @Step1, [Step2] = @Step2, [Step3] = @Step3, " +
                                                             " [Step4] = @Step4  WHERE BusinessUserID = @BusinessUserID ", con))

                {
                    command.Parameters.AddWithValue("@BusinessUserID", pRestaurantSteps.BusinessUserID);
                    command.Parameters.AddWithValue("@RestaurantID", pRestaurantSteps.RestaurantID);
                    command.Parameters.AddWithValue("@SubscriptionID", pRestaurantSteps.SubscriptionID);
                    command.Parameters.AddWithValue("@Step1", pRestaurantSteps.Step1);
                    command.Parameters.AddWithValue("@Step2", pRestaurantSteps.Step2);
                    command.Parameters.AddWithValue("@Step3", pRestaurantSteps.Step3);
                    command.Parameters.AddWithValue("@Step4", pRestaurantSteps.Step4);
                 

                isSucess = command.ExecuteNonQuery();


                }
            }

            return isSucess;


        }


    }
}
