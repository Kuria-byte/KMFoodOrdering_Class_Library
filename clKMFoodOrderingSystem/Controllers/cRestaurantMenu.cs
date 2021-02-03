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
    public class cRestaurantMenu
    {
        public static DataTable GetMenuList()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT  * FROM   tblMenu ORDER BY MenuName ASC", con))
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

        public static DataTable GetJoinedMenuList()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT  * FROM   tblMenu INNER JOIN " +
                        " tblMenuCategory on tblmenu.MenuCategoryID = tblMenuCategory.MenuCategoryID INNER JOIN " +
                        " tblRestaurant on tblmenu.RestaurantID = tblRestaurant.RestaurantID ORDER BY MenuName ASC", con))
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


        public static DataTable GetMenuListbyBusinessID(int pBusinessUserID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT  * FROM   tblMenu INNER JOIN " +
                    " tblMenuCategory on tblmenu.MenuCategoryID = tblMenuCategory.MenuCategoryID INNER JOIN " +
                    " tblRestaurant on tblmenu.RestaurantID = tblRestaurant.RestaurantID WHERE tblRestaurant.BusinessUserID=@BusinessUserID ORDER BY MenuName ASC", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@BusinessUserID", pBusinessUserID);

                        sda.Fill(dt);


                    }
                }
            }
            return dt;
        }


        public static DataTable GetMenuListbyRestaurantID(int pBusinessID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT  * FROM   tblMenu INNER JOIN " +
                    " tblMenuCategory on tblmenu.MenuCategoryID = tblMenuCategory.MenuCategoryID INNER JOIN " +
                    " tblRestaurant on tblmenu.RestaurantID = tblRestaurant.RestaurantID WHERE tblRestaurant.RestaurantID=@RestaurantID ORDER BY MenuName ASC", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@RestaurantID", pBusinessID);

                        sda.Fill(dt);


                    }
                }
            }
            return dt;
        }




        public static int AddRestaurantMenu(mRestaurantMenu pMenuCategory)
        {

            int isSucess = 0;

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO tblMenu (RestaurantID, MenuCategoryID, MenuName, LongMenuDescription, ShortMenuDescription , MenuIngredients, Price, MenuPicture, IsActive) " +
                                                            " VALUES (@RestaurantID, @MenuCategoryID, @MenuName, @LongMenuDescription, @ShortMenuDescription, @MenuIngredients, @Price, @MenuPicture, @IsActive) ", con))
                {
                    command.Parameters.AddWithValue("@RestaurantID", pMenuCategory.RestaurantID);
                    command.Parameters.AddWithValue("@MenuCategoryID", pMenuCategory.MenuCategoryID);
                    command.Parameters.AddWithValue("@MenuName", pMenuCategory.MenuName);
                    command.Parameters.AddWithValue("@LongMenuDescription", pMenuCategory.LongMenuDescription);
                    command.Parameters.AddWithValue("@ShortMenuDescription", pMenuCategory.ShortMenuDescription);
                    command.Parameters.AddWithValue("@MenuIngredients", pMenuCategory.MenuIngredients);
                    command.Parameters.AddWithValue("@Price", pMenuCategory.Price);
                    command.Parameters.AddWithValue("@MenuPicture", pMenuCategory.MenuPicture);
                    command.Parameters.AddWithValue("@IsActive", pMenuCategory.IsActive);


                    isSucess = command.ExecuteNonQuery();


                }
            }




            return isSucess;


        }
        public static int UpdateMenu(mRestaurantMenu pMenuCategory)
        {

            int isSucess = 0;

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("UPDATE tblMenu SET  [MenuName] = @MenuName, [RestaurantID] = @RestaurantID, [MenuCategoryID] = @MenuCategoryID, [MenuDescription] = @MenuDescription, [MenuIngredients] = @MenuIngredients, [Price] = @Price,[MenuPicture] = @MenuPicture, " +
                                                             " [IsActive] = @IsActive WHERE MenuID = @MenuID ", con))

                {
                    command.Parameters.AddWithValue("@MenuID", pMenuCategory.MenuID);
                    command.Parameters.AddWithValue("@RestaurantID", pMenuCategory.RestaurantID);
                    command.Parameters.AddWithValue("@MenuCategoryID", pMenuCategory.MenuCategoryID);
                    command.Parameters.AddWithValue("@MenuName", pMenuCategory.MenuName);
                    command.Parameters.AddWithValue("@LongMenuDescription", pMenuCategory.LongMenuDescription);
                    command.Parameters.AddWithValue("@ShortMenuDescription", pMenuCategory.ShortMenuDescription);
                    command.Parameters.AddWithValue("@MenuIngredients", pMenuCategory.MenuIngredients);
                    command.Parameters.AddWithValue("@Price", pMenuCategory.Price);
                    command.Parameters.AddWithValue("@MenuPicture", pMenuCategory.MenuPicture);
                    command.Parameters.AddWithValue("@IsActive", pMenuCategory.IsActive);


                    isSucess = command.ExecuteNonQuery();


                }
            }

            return isSucess;


        }


        public static int DeleteMenu(int _pMenuCategoryID)
        {

            int isSucess = 0;

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("DELETE From tblMenu WHERE MenuID = @ MenuID ", con))
                {
                    command.Parameters.AddWithValue("@ MenuID", _pMenuCategoryID);

                    isSucess = command.ExecuteNonQuery();


                }
            }




            return isSucess;

        }
    }
}
