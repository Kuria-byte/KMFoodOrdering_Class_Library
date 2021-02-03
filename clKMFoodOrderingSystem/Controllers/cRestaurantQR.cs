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
    public class cRestaurantQR
    {
        public static DataTable GetRestaurantQRcodes()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT  * FROM   tblRestaurantQRcodes INNER JOIN " +
                                                       " tblRestaurant on tblRestaurantQRcodes.RestaurantID = tblRestaurant.RestaurantID INNER JOIN " +
                                                       " tblSubscriptions on tblRestaurantQRCodes.SubscriptionID = tblSubscriptions.SubscriptionID INNER JOIN " +
                                                       " tblSubscriptionType on tblSubscriptions.SubscriptionTypeID = tblSubscriptionType.SubscriptionTypeID ", con))
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

        public static DataTable GetRestaurantQRcodesByUserID(int _BusinessUserID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT  * FROM   tblRestaurantQRcodes INNER JOIN " +
                                                       " tblRestaurant on tblRestaurantQRcodes.RestaurantID = tblRestaurant.RestaurantID INNER JOIN " +
                                                       " tblSubscriptions on tblRestaurantQRCodes.SubscriptionID = tblSubscriptions.SubscriptionID INNER JOIN " +
                                                       " tblSubscriptionType on tblSubscriptions.SubscriptionTypeID = tblSubscriptionType.SubscriptionTypeID WHERE tblRestaurant.BusinessUserID = @BusinessUserID  ", con))
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

        public static int AddRestaurantQRcode(mRestaurantQR pRestaurantQR)
        {

            int isSucess = 0;

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO tblRestaurantQRcodes (RestaurantID, SubscriptionID, TableNumber , WebURL, QRPicture, QRName, ISActive) " +
                                                            " VALUES (@RestaurantID, @SubscriptionID, @TableNumber,  @WebURL, @QRPicture,  @QRName,  @IsActive) ", con))
                {

                    command.Parameters.AddWithValue("@RestaurantID", pRestaurantQR.RestaurantID);
                    command.Parameters.AddWithValue("@SubscriptionID", pRestaurantQR.SubscriptionID);
                    command.Parameters.AddWithValue("@WebURL", pRestaurantQR.WebURL);
                    command.Parameters.AddWithValue("@TableNumber", pRestaurantQR.TableNumber);
                    command.Parameters.AddWithValue("@QRPicture", pRestaurantQR.QRPicture);
                    command.Parameters.AddWithValue("@QRName", pRestaurantQR.QRName);
                    command.Parameters.AddWithValue("@IsActive", pRestaurantQR.IsActive);


                    isSucess = command.ExecuteNonQuery();


                }
            }




            return isSucess;


        }

        public static int UpdateRestaurantQRcode(mRestaurantQR pRestaurantQR)
        {

            int isSucess = 0;

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("UPDATE tblRestaurantQRcodes SET  [RestaurantID] = @RestaurantID, [SubscriptionID] = @SubscriptionID, [WebURL] = @WebURL, [TableNumber] = @TableNumber, [QRPicture] = @QRPicture, [QRName] = @QRName " +
                                                             " [IsActive] = @IsActive WHERE RestaurantQR_ID = @RestaurantQR_ID ", con))

                {
                    command.Parameters.AddWithValue("@RestaurantQR_ID", pRestaurantQR.RestaurantID);
                    command.Parameters.AddWithValue("@SubscriptionID", pRestaurantQR.SubscriptionID);
                    command.Parameters.AddWithValue("@RestaurantID", pRestaurantQR.RestaurantID);
                    command.Parameters.AddWithValue("WebURL", pRestaurantQR.WebURL);
                    command.Parameters.AddWithValue("@TableNumber", pRestaurantQR.TableNumber);
                    command.Parameters.AddWithValue("@QRPicture", pRestaurantQR.QRPicture);
                    command.Parameters.AddWithValue("@QRName", pRestaurantQR.QRName);

                    command.Parameters.AddWithValue("@IsActive", pRestaurantQR.IsActive);


                    isSucess = command.ExecuteNonQuery();


                }
            }

            return isSucess;


        }
    }
}
