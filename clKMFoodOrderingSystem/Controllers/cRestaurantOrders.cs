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
   public class cRestaurantOrders
    {

        public static DataTable GetRestaurantOrders()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT  * FROM   tblRestaurantOrders ORDER BY OrderDate ASC", con))
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

        //public static DataTable GetRestaurantOrdersbyBusine(int _SessionID)
        //{
        //    DataTable dt = new DataTable();

        //    using (SqlConnection con = new SqlConnection(Global.connString))
        //    {
        //        con.Open();
        //        using (SqlCommand cmd = new SqlCommand("SELECT  * FROM  tblRestaurantOrders WHERE SessionID=@SessionID  ORDER BY OrderDate ASC", con))
        //        {
        //            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //            {

        //                cmd.CommandType = CommandType.Text;
        //                cmd.Parameters.AddWithValue("@SessionID", _SessionID);

        //                sda.Fill(dt);




        //            }
        //        }
        //    }
        //    return dt;
        //}

        public static int AddRestaurantOrder(mRestaurantOrders pRestaurantOrders)
        {

            int isSucess = 0;

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO tblRestaurantOrders (SessionID, RestaurantID ,SubscriptionID, TableNumber, GrandTotal, OrderDate, IsProcessed, CustomerName, CustomerEmail, CustomerPhone, OrderNotes) " +
                                                            " VALUES (@SessionID, @RestaurantID, @SubscriptionID, @TableNumber, @GrandTotal, @OrderDate, @IsProcessed, @CustomerName, @CustomerEmail, @CustomerPhone, @OrderNotes);  SELECT SCOPE_IDENTITY()  ", con))
                {
                    //command.Parameters.AddWithValue("@OrderID", pRestaurantOrders.OrderID);
                    command.Parameters.AddWithValue("@SessionID", pRestaurantOrders.SessionID);
                    command.Parameters.AddWithValue("@RestaurantID", pRestaurantOrders.RestaurantID);
                    command.Parameters.AddWithValue("@SubscriptionID", pRestaurantOrders.SubscriptionID);
                    command.Parameters.AddWithValue("@TableNumber", pRestaurantOrders.TableNumber);
                    command.Parameters.AddWithValue("@GrandTotal", pRestaurantOrders.GrandTotal);
                     command.Parameters.AddWithValue("@OrderDate", pRestaurantOrders.OrderDate);
                    command.Parameters.AddWithValue("@IsProcessed", pRestaurantOrders.IsProcessed);
                    command.Parameters.AddWithValue("@CustomerName", pRestaurantOrders.CustomerName);
                    command.Parameters.AddWithValue("@CustomerEmail", pRestaurantOrders.CustomerEmail);
                    command.Parameters.AddWithValue("@CustomerPhone", pRestaurantOrders.CustomerPhone);
                    command.Parameters.AddWithValue("@OrderNotes", pRestaurantOrders.OrderNotes);


                    isSucess = Convert.ToInt32(command.ExecuteScalar());


                }
            }


            return isSucess;


        }

    
        public static DataTable GetOrdersWithWhereClause(string _where, string _orderby)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblRestaurantOrders INNER JOIN tblRestaurant ON tblRestaurantOrders.RestaurantID = tblRestaurant.RestaurantID " +
                                                        " INNER JOIN tblRestaurantBusinessUser ON tblRestaurant.BusinessUserID = tblRestaurantBusinessUser.BusinessUserID " +
                                                        " WHERE " + _where + " ORDER BY " + _orderby + " ", con))
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

        public static DataTable GetCompleteOrdersAsAdmin( )
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblRestaurantOrders INNER JOIN tblRestaurant ON tblRestaurantOrders.RestaurantID = tblRestaurant.RestaurantID " +
                                                        " INNER JOIN tblRestaurantBusinessUser ON tblRestaurant.BusinessUserID = tblRestaurantBusinessUser.BusinessUserID " +
                                                        " ORDER BY OrderDate ASC ", con))
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


        public static DataTable GetDistinctCustomerOrdersbyRestaurantID(int _restaurantID )
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT distinct CustomerEmail, CustomerName, CustomerPhone, count(CustomerEmail) as ordercount" +
                    " FROM tblRestaurantOrders Where tblRestaurantOrders.RestaurantID = @RestaurantID AND CustomerEmail != ''" +
                    " GROUP BY CustomerEmail, CustomerName, CustomerPhone", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        cmd.Parameters.AddWithValue("@RestaurantID", _restaurantID);
                        cmd.CommandType = CommandType.Text;

                        sda.Fill(dt);


                    }
                }
            }
            return dt;
        }

        public static int UpdateOrderStatus(int _iOrderID, int _IsProcessed)
        {
            int isSucess = 0;

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("UPDATE tblRestaurantOrders SET [IsProcessed] =  @IsProcessed WHERE OrderID = @OrderID ", con))

                {
                    command.Parameters.AddWithValue("@IsProcessed", _IsProcessed);
                    command.Parameters.AddWithValue("@OrderID", _iOrderID);
                    isSucess = command.ExecuteNonQuery();
                }
            }

            return isSucess;

        }






    }
}
