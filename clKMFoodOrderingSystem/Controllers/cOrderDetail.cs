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
   public class cOrderDetail
    {

        public static DataTable GetOrderDetail()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT  * FROM   tblOrderDetail ORDER BY OrderID ASC", con))
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

        public static int AddOrderDetail(mOrderDetail pOrderDetail)
        {

            int isSucess = 0;

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO tblOrderDetail (OrderID, MenuID, Quantity, SubTotal) " +
                                                            " VALUES ( @OrderID, @MenuID, @Quantity, @SubTotal );  SELECT SCOPE_IDENTITY()  ", con))
                {
                    command.Parameters.AddWithValue("@OrderID", pOrderDetail.OrderID);
                    command.Parameters.AddWithValue("@MenuID", pOrderDetail.MenuID);
                    command.Parameters.AddWithValue("@Quantity", pOrderDetail.Quantity);
                    command.Parameters.AddWithValue("@SubTotal", pOrderDetail.SubTotal);
     

                    isSucess = command.ExecuteNonQuery();


                }
            }


            return isSucess;


        }

        public static DataTable GetOrderDetailListByOrderID(int pOrderID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblOrderDetail INNER JOIN tblMenu ON tblOrderDetail.MenuID = tblMenu.MenuID " +
                  " INNER JOIN  tblMenuCategory ON tblMenu.MenuCategoryID = tblMenuCategory.MenuCategoryID" +
                  " WHERE tblOrderDetail.OrderID = @OrderID ORDER BY OrderID ASC", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {

                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@OrderID", pOrderID);

                        sda.Fill(dt);


                    }
                }
            }
            return dt;

        }




    }
}
