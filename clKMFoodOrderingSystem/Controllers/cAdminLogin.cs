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
    public class cAdminLogin
    {


        public static DataTable GetAdminLoginList()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT  * FROM   tblAdminLogin ORDER BY AdminLoginName ASC", con))
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
        public static int AddNewAdminLogin(mAdminLogin pAdminLogin)
        {

            int isSucess = 0;

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO tblAdminLogin ( AdminLoginName, AdminLoginPassword, AdminLastLoginDateTime, IsActive) " +
                                                            " VALUES (@AdminLoginName, @AdminLoginPassword, @AdminLastLoginDateTime,  @IsActive) ", con))
                {
                    command.Parameters.AddWithValue("@AdminLoginName", pAdminLogin.AdminLoginName);
                    command.Parameters.AddWithValue("@AdminLoginPassword", pAdminLogin.AdminLoginPassword);
                    command.Parameters.AddWithValue("@AdminLastLoginDateTime", DateTime.Now);
                    command.Parameters.AddWithValue("@IsActive", pAdminLogin.IsActive);


                    isSucess = command.ExecuteNonQuery();


                }
            }




            return isSucess;

        }

        public static int UpdateAdminLogin(mAdminLogin pAdminLogin)
        {

            int isSucess = 0;

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("UPDATE tblAdminLogin SET  [AdminLoginName] = @AdminLoginName, [AdminLoginPassword] = @AdminLoginPassword, [AdminLastLoginDateTime] = @AdminLastLoginDateTime, " +
                                                            "[IsActive] = @IsActive WHERE AdminLoginID = @AdminLoginID ", con))

                {
                    command.Parameters.AddWithValue("@AdminLoginID", pAdminLogin.AdminLoginID);
                    command.Parameters.AddWithValue("@AdminLoginName", pAdminLogin.AdminLoginName);
                    command.Parameters.AddWithValue("@AdminLoginPassword", pAdminLogin.AdminLoginPassword);
                    command.Parameters.AddWithValue("@AdminLastLoginDateTime", DateTime.Now);
                    command.Parameters.AddWithValue("@IsActive", pAdminLogin.IsActive);

                    isSucess = command.ExecuteNonQuery();


                }
            }

            return isSucess;

        }

        public static int UpdateAdminLoginDateTime(int _AdminID)
        {

            int isSucess = 0;

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("UPDATE tblAdminLogin SET  LastLoginDateTime = GetDate() " +
                                                            " WHERE AdminLoginID = @AdminLoginID ", con))
                {
                    command.Parameters.AddWithValue("@AdminLoginID", _AdminID);
                    isSucess = command.ExecuteNonQuery();
                }
            }

            return isSucess;

        }






    }

}
