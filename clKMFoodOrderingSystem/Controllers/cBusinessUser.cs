using clKMFoodOrderingSystem.Models;
using clKMFoodOrderingSystem.UtilityClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clKMFoodOrderingSystem.Controllers
{
    public class cBusinessUser
    {

        public static DataTable GetBusinessUserList()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT  * FROM   tblRestaurantBusinessUser ", con))
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


        public static mBusinessUser VerifyBusinessInformation(string pBusinessUserEmail, string pBusinessUserPassword)
        {
            mBusinessUser collectmBusinessUser = new mBusinessUser();
            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("select * from tblRestaurantBusinessUser where BusinessUserEmail =@BusinessUserEmail and BusinessUserPassword=@BusinessUserPassword", con))
                {
                    command.Parameters.AddWithValue("@BusinessUserEmail", pBusinessUserEmail);
                    command.Parameters.AddWithValue("@BusinessUserPassword", pBusinessUserPassword);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {


                                collectmBusinessUser.BusinessUserID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("BusinessUserID")));
                                collectmBusinessUser.BusinessUserIDEncrypted = ucEDOperation.EncryptString(Global.gEDKey, Convert.ToString(reader.GetValue(reader.GetOrdinal("BusinessUserID"))));
                                collectmBusinessUser.BusinessUserName = reader.GetValue(reader.GetOrdinal("BusinessUserName")).ToString();

                                if (reader.GetValue(reader.GetOrdinal("BusinessUserEmail")) == null)
                                {
                                    collectmBusinessUser.BusinessUserEmail = null;
                                }
                                else
                                {
                                    collectmBusinessUser.BusinessUserEmail = reader.GetValue(reader.GetOrdinal("BusinessUserEmail")).ToString();
                                }

                                collectmBusinessUser.BusinessSignupDate = reader.GetDateTime(reader.GetOrdinal("BusinessSignupDate"));
                                collectmBusinessUser.IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"));   //reader.GetBoolean(17);
                                collectmBusinessUser.IsEmailVerified = reader.GetBoolean(reader.GetOrdinal("IsEmailVerified"));   //reader.GetBoolean(17);
                            }
                        }
                        else

                        {
                            collectmBusinessUser = null;
                        }

                    }
                }
            }

            return collectmBusinessUser;
        }
        public static mBusinessUser VerifyBusinessEmail(string spBusinessEmail)
        {
            mBusinessUser collectmBusinessUser = new mBusinessUser();
            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("select * from tblRestaurantBusinessUser where BusinessUserEmail = @BusinessUserEmail ", con))
                {
                    command.Parameters.AddWithValue("@BusinessUserEmail", spBusinessEmail);


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {

                                collectmBusinessUser.BusinessUserID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("BusinessUserID")));
                                collectmBusinessUser.BusinessUserIDEncrypted = ucEDOperation.EncryptString(Global.gEDKey, Convert.ToString(reader.GetValue(reader.GetOrdinal("BusinessUserID"))));
                                collectmBusinessUser.BusinessUserName = reader.GetValue(reader.GetOrdinal("BusinessUserName")).ToString();

                                if (reader.GetValue(reader.GetOrdinal("BusinessUserEmail")) == null)
                                {
                                    collectmBusinessUser.BusinessUserEmail = null;
                                }
                                else
                                {
                                    collectmBusinessUser.BusinessUserEmail = reader.GetValue(reader.GetOrdinal("BusinessUserEmail")).ToString();
                                }

                                collectmBusinessUser.LastLogin = reader.GetDateTime(reader.GetOrdinal("lastLogin")); //reader.GetDateTime(16);
                                collectmBusinessUser.IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"));   //reader.GetBoolean(17);
                                collectmBusinessUser.IsEmailVerified = reader.GetBoolean(reader.GetOrdinal("IsEmailVerified"));
                            }

                        }
                        else

                        {
                            collectmBusinessUser = null;
                        }

                    }
                }
            }

            return collectmBusinessUser;
        }
        public static DataTable GetBusinessListWithNoDuplicates(mBusinessUser pbusinessUser)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblRestaurantBusinessUser WHERE BusinessUserEmail = @BusinessUserEmail", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("@BusinessUserEmail", pbusinessUser.BusinessUserEmail);

                        sda.Fill(dt);


                    }
                }
            }
            return dt;

        }

        public static int AddNewBusinessUser(mBusinessUser pBusinessUser)
        {

            int isSucess = 0;

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO tblRestaurantBusinessUser ( BusinessUserName, BusinessUserEmail, BusinessUserPassword, IsActive, IsEmailVerified, LastLogin, BusinessSignupDate) " +
                                                            " VALUES (@BusinessUserName, @BusinessUserEmail, @BusinessUserPassword, @IsActive, @IsEmailVerified, @LastLogin, @BusinessSignupDate)  SELECT SCOPE_IDENTITY() ", con))
                {
                    command.Parameters.AddWithValue("@BusinessUserName", pBusinessUser.BusinessUserName);
                    command.Parameters.AddWithValue("@BusinessUserEmail", pBusinessUser.BusinessUserEmail);
                    command.Parameters.AddWithValue("@BusinessUserPassword", pBusinessUser.BusinessUserPassword);
                    command.Parameters.AddWithValue("@IsActive", pBusinessUser.IsActive);
                    command.Parameters.AddWithValue("@IsEmailVerified", pBusinessUser.IsEmailVerified);
                    command.Parameters.AddWithValue("@LastLogin", DateTime.Now);
                    command.Parameters.AddWithValue("@BusinessSignupDate", DateTime.Now);


                    


                }
            }




            return isSucess;

        }

        public static int UpdateBusinessUser(mBusinessUser pBusinessUser)
        {

            int isSucess = 0;

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("UPDATE tblRestaurantBusinessUser SET  [BusinessUserName] = @BusinessUserName, [BusinessUserEmail] = @BusinessUserEmail " +
                                                            " WHERE BusinessUserID = @BusinessUserID ", con))

                {

                    command.Parameters.AddWithValue("@BusinessUserID", pBusinessUser.BusinessUserID);
                    command.Parameters.AddWithValue("@BusinessUserName", pBusinessUser.BusinessUserName);
                    command.Parameters.AddWithValue("@BusinessUserEmail", pBusinessUser.BusinessUserEmail);
                   
                   

                    isSucess = command.ExecuteNonQuery();


                }
            }

            return isSucess;

        }

        public static int UpdateBusinessUserFromEmail(int _BusinessUserID)
        {

            int isSucess = 0;

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("UPDATE tblRestaurantBusinessUser SET  [IsActive] = 1, [IsEmailVerified] = 1  WHERE BusinessUserID = @BusinessUserID ", con))

                {
                    command.Parameters.AddWithValue("@BusinessUserID", _BusinessUserID);

                    isSucess = command.ExecuteNonQuery();


                }
            }

            return isSucess;

        }


        public static int UpdateBusinessChangePasswordFromEmail(string pNewPassword, int pBusinessUserID)
        {

            int isSucess = 0;

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("UPDATE tblRestaurantBusinessUser SET BusinessUserPassword = @BusinessUserPassword WHERE BusinessUserID = @BusinessUserID  ", con))

                {
                    command.Parameters.AddWithValue("@BusinessUserID", pBusinessUserID);
                    command.Parameters.AddWithValue("@BusinessUserPassword", pNewPassword);
                    isSucess = command.ExecuteNonQuery();
                }
            }

            return isSucess;

        }


        public static int DeleteUser(int _pBusinessUserID)
        {

            int isSucess = 0;

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("DELETE From tblRestaurantBusinessUser WHERE BusinessUserID = @BusinessUserID ", con))
                {
                    command.Parameters.AddWithValue("@BusinessUserID", _pBusinessUserID);

                    isSucess = command.ExecuteNonQuery();


                }
            }




            return isSucess;

        }


    }
}
