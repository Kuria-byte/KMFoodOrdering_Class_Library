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
  public class cMenuCategory
    {
        public static DataTable GetMenuCategory()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT  * FROM   tblMenuCategory ORDER BY MenuCategoryID ASC", con))
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

        public static DataTable GetMenuCategorybyRestaurantID(int pRestaurantID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT  * FROM   tblMenuCategory WHERE RestaurantID = @RestaurantID ORDER BY MenuCategoryID ASC", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@RestaurantID", pRestaurantID);

                        sda.Fill(dt);


                    }
                }
            }
            return dt;
        }

        public static int UpdateMenuCategory(mMenuCategory pMenuCategory)
        {

            int isSucess = 0;

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("UPDATE tblMenuCategory SET  [MenuCategoryName] = @MenuCategoryName, [RestaurantID] = @RestaurantID, [CategoryImage] = @CategoryImage, " +
                                                             " [IsActive] = @IsActive WHERE MenuCategoryID = @MenuCategoryID ", con))

                {
                    command.Parameters.AddWithValue("@MenuCategoryID", pMenuCategory.MenuCategoryID);
                    command.Parameters.AddWithValue("@MenuCategoryName", pMenuCategory.MenuCategoryName);
                    command.Parameters.AddWithValue("@RestaurantID", pMenuCategory.RestaurantID);
                    command.Parameters.AddWithValue("@CategoryImage", pMenuCategory.CategoryImage);
                    command.Parameters.AddWithValue("@IsActive", pMenuCategory.IsActive);


                    isSucess = command.ExecuteNonQuery();


                }
            }

            return isSucess;


        }


        public static int AddRestaurantMenuCategory(mMenuCategory pMenuCategory)
        {

            int isSucess = 0;

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO tblMenuCategory (MenuCategoryName, RestaurantID, CategoryImage, IsActive) " +
                                                            " VALUES (@MenuCategoryName, @RestaurantID, @CategoryImage,  @IsActive) ", con))
                {
                    
                    command.Parameters.AddWithValue("@MenuCategoryName", pMenuCategory.MenuCategoryName);
                    command.Parameters.AddWithValue("@RestaurantID", pMenuCategory.RestaurantID);
                    command.Parameters.AddWithValue("@CategoryImage", pMenuCategory.CategoryImage);
                    command.Parameters.AddWithValue("IsActive", pMenuCategory.IsActive);


                    isSucess = command.ExecuteNonQuery();


                }
            }




            return isSucess;


        }
    }
}

