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
    public class cContactUs
    {
        public static DataTable GetContactUsList()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT  * FROM   tblContactUs ORDER BY ContactDate ASC", con))
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

        public static int AddContactList(mContactUs pContactUs)
        {

            int isSucess = 0;

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO tblContactUs (FirstName, LastName, Email, Phone, BusinessType, SubscriptionPlan, Details, ContactDate, ActionTaken) " +
                                                            " VALUES (@FirstName, @LastName, @Email, @Phone, @BusinessType, @SubscriptionPlan, @Details, @ContactDate, @ActionTaken);  SELECT SCOPE_IDENTITY()  ", con))
                {
                    
                    command.Parameters.AddWithValue("@FirstName", pContactUs.FirstName);
                    command.Parameters.AddWithValue("@LastName", pContactUs.LastName);
                    command.Parameters.AddWithValue("@Email", pContactUs.Email);
                    command.Parameters.AddWithValue("@Phone", pContactUs.Phone);
                    command.Parameters.AddWithValue("@BusinessType", pContactUs.BusinessType);
                    command.Parameters.AddWithValue("@SubscriptionPlan", pContactUs.SubscriptionPlan);
                    command.Parameters.AddWithValue("@Details", pContactUs.Details);
                    command.Parameters.AddWithValue("@ContactDate", pContactUs.ContactDate);
                    command.Parameters.AddWithValue("@ActionTaken", pContactUs.ActionTaken);

                    isSucess = command.ExecuteNonQuery();
                }
            }


            return isSucess;


        }

        public static int UpdateActionTaken(int _iContactID, bool _IsActionTaken)
        {
            int isSucess = 0;

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("UPDATE tblContactUs SET [ActionTaken] =  @ActionTaken WHERE ContactID = @ContactID ", con))

                {
                    command.Parameters.AddWithValue("@ContactID", _iContactID);
                    command.Parameters.AddWithValue("@ActionTaken", _IsActionTaken);
                   
                    isSucess = command.ExecuteNonQuery();
                }
            }

            return isSucess;

        }
    }
}
