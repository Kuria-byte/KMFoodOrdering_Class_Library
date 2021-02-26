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
    public class cSubscription
    {
        public static DataTable GetSubscription()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT  * FROM   tblSubscriptions INNER JOIN tblRestaurant on tblSubscriptions.RestaurantID = tblRestaurant.RestaurantID INNER JOIN " +
                    " tblSubscriptionStatus on tblSubscriptions.StatusID = tblSubscriptionStatus.StatusID Order By  tblSubscriptions.SubscriptionID  ASC", con))
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

        public static DataTable GetSubscriptionByRestaurantID(int _RestaurantID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * from tblSubscriptions INNER JOIN tblSubscriptionStatus on tblSubscriptions.StatusID = tblSubscriptionStatus.StatusID " +
                    " INNER JOIN tblSubscriptionType ON tblSubscriptions.SubscriptionTypeID = tblSubscriptionType.SubscriptionTypeID" +
                    " WHERE RestaurantID = @RestaurantID  ORDER BY tblSubscriptions.SubscriptionID DESC", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@RestaurantID", _RestaurantID);

                        sda.Fill(dt);


                    }
                }
            }
            return dt;
        }

        public static DataTable GetSubscriptionByBusinessUserID(int _BusinessUserID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT  * FROM   tblSubscriptions INNER JOIN tblSubscriptionStatus ON tblSubscriptions.StatusID = tblSubscriptionStatus.StatusID" +
                    " INNER JOIN tblSubscriptionType ON tblSubscriptions.SubscriptionTypeID = tblSubscriptionType.SubscriptionTypeID  WHERE tblSubscriptions.BusinessUserID = @BusinessUserID  ORDER BY SubscriptionID ASC", con))
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



        public static int AddSubscription(mSubscription pSubscription)
        {

            int isSucess = 0;

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO tblSubscriptions (RestaurantID, SubscriptionTypeID, NumberOfTables, Total, SubscriptionStartDate, SubscriptionEndDate, IsActive, BusinessUserID,AttachedPaymentReceipt, StatusID) " +
                                                            " VALUES (@RestaurantID, @SubscriptionTypeID, @NumberOfTables, @Total, @SubscriptionStartDate, @SubscriptionEndDate, @IsActive ,@BusinessUserID ,@AttachedPaymentReceipt, @StatusID); SELECT SCOPE_IDENTITY() ", con))
                {

                    command.Parameters.AddWithValue("@RestaurantID", pSubscription.RestaurantID);
                    command.Parameters.AddWithValue("@SubscriptionTypeID", pSubscription.SubscriptionTypeID);
                    command.Parameters.AddWithValue("@NumberOfTables", pSubscription.NumberOfTables);
                    command.Parameters.AddWithValue("@Total", pSubscription.Total);
                    command.Parameters.AddWithValue("@SubscriptionStartDate", pSubscription.StartedDate);
                    command.Parameters.AddWithValue("@SubscriptionEndDate",pSubscription.EndDate );
                    command.Parameters.AddWithValue("@IsActive", pSubscription.IsActive);
                    command.Parameters.AddWithValue("@BusinessUserID", pSubscription.BusinessUserID);
                    command.Parameters.AddWithValue("@AttachedPaymentReceipt", pSubscription.AttachedPaymentReceipt);
                    command.Parameters.AddWithValue("@StatusID", pSubscription.StatusID);

                  
                    isSucess = Convert.ToInt32(command.ExecuteScalar());


                }
            }




            return isSucess;


        }

        public static int UpdateSubscription(mSubscription pSubscription)
        {

            int isSucess = 0;

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("UPDATE tblSubscriptions SET  [RestaurantID] = @RestaurantID, [SubscriptionTypeID] = @SubscriptionTypeID, [NumberOfTables] = @NumberOfTables, [Total] = @Total, [SubscriptionStartDate] = @SubscriptionStartDate, " +
                                                             " [SubscriptionEndDate] = @SubscriptionEndDate ,  " +
                                                             " [IsActive] = @IsActive, [StatusID] = @StatusID WHERE SubscriptionID = @SubscriptionID ", con))

                {
                    command.Parameters.AddWithValue("@RestaurantID", pSubscription.RestaurantID);
                    command.Parameters.AddWithValue("@SubscriptionID", pSubscription.SubscriptionID);
                    command.Parameters.AddWithValue("@SubscriptionTypeID", pSubscription.SubscriptionTypeID);
                    command.Parameters.AddWithValue("@NumberOfTables", pSubscription.NumberOfTables);
                    command.Parameters.AddWithValue("@Total", pSubscription.Total);
                    command.Parameters.AddWithValue("@SubscriptionStartDate", pSubscription.StartedDate);
                    command.Parameters.AddWithValue("@SubscriptionEndDate", pSubscription.EndDate);
                    command.Parameters.AddWithValue("@IsActive", pSubscription.IsActive);
                    command.Parameters.AddWithValue("@StatusID", pSubscription.StatusID);


                    isSucess = command.ExecuteNonQuery();


                }
            }

            return isSucess;


        }



        public static int DeleteSubscription(int _pSubscriptionID)
        {

            int isSucess = 0;

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("DELETE From tblSubscriptions WHERE SubscriptionID= @SubscriptionID ", con))
                {
                    command.Parameters.AddWithValue("@SubscriptionID", _pSubscriptionID);


                    isSucess = command.ExecuteNonQuery();

                }
            }

            return isSucess;

        }

        public static int UpdateSubscriptionStatus(int _StatusID, int _BusinessUserID, string _attachment)
        {

            int isSucess = 0;

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("Update tblSubscriptions set StatusID = @StatusID , AttachedPaymentReceipt = @AttachedPaymentReceipt WHERE BusinessUserID = @BusinessUserID", con))

                {
                    command.Parameters.AddWithValue("@BusinessUserID", _BusinessUserID);                   
                    command.Parameters.AddWithValue("@StatusID", _StatusID);
                    command.Parameters.AddWithValue("@AttachedPaymentReceipt", _attachment);


                    isSucess = command.ExecuteNonQuery();


                }
            }

            return isSucess;


        }
    }


}

