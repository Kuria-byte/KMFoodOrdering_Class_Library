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
   public class cRestaurant
    {
        public static DataTable GetRestaurantList()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(" SELECT  tblRestaurant.RestaurantID, tblRestaurantType.RestaurantTypeID, tblRestaurantType.RestaurantType , tblRestaurant.RestaurantName, tblRestaurant.RestaurantDescription, tblRestaurant.RestaurantEmailAddress, tblRestaurant.RestaurantAddress, tblRestaurant.CountryID, tblRestaurant.StateID, tblRestaurant.CityID, tblRestaurant.RestaurantContactNumber, tblRestaurant.RestaurantAddedOn, tblRestaurant.IsActive, tblRestaurant.RestaurantLogo," +
                                                       " tblRestaurant.RestaurantAddress + ', ' + countries.name + ', ' + states.name + ', ' +countries.name + ', ' + cities.name as CompleteAddress FROM   tblRestaurant  INNER JOIN" +
                                                       " tblRestaurantType ON tblRestaurant.RestaurantTypeID = tblRestaurantType.RestaurantTypeID INNER JOIN" +
                                                       " countries ON tblRestaurant.CountryID = countries.id INNER JOIN" +
                                                       " cities ON tblRestaurant.CityID = cities.id INNER JOIN " +
                                                       " states ON tblRestaurant.StateID = states.id ", con))
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


        public static DataTable GetRestaurantInfoByUser(int pBusinessUserID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(" SELECT  tblRestaurant.RestaurantID, tblRestaurantType.RestaurantTypeID, tblRestaurantType.RestaurantType , tblRestaurant.RestaurantName, tblRestaurant.RestaurantDescription, tblRestaurant.RestaurantEmailAddress, tblRestaurant.RestaurantAddress, tblRestaurant.CountryID, tblRestaurant.StateID, tblRestaurant.CityID, tblRestaurant.RestaurantContactNumber, tblRestaurant.RestaurantAddedOn, tblRestaurant.IsActive, tblRestaurant.RestaurantLogo," +
                                                       " tblRestaurant.RestaurantAddress + ', ' + countries.name + ', ' + states.name + ', ' +countries.name + ', ' + cities.name as CompleteAddress FROM   tblRestaurant  INNER JOIN" +
                                                       " tblRestaurantType ON tblRestaurant.RestaurantTypeID = tblRestaurantType.RestaurantTypeID INNER JOIN" +
                                                       " countries ON tblRestaurant.CountryID = countries.id INNER JOIN" +
                                                       " cities ON tblRestaurant.CityID = cities.id INNER JOIN " +
                                                       " states ON tblRestaurant.StateID = states.id WHERE tblRestaurant.BusinessUserID = @BusinessUserID  ", con))
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

        public static DataTable GetRestaurantInfoByRestaurantID(int pRestaurantID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(" SELECT *, tblRestaurant.RestaurantID, tblSubscriptions.SubscriptionID, tblRestaurantType.RestaurantTypeID, tblRestaurantType.RestaurantType , tblRestaurant.RestaurantName, tblRestaurant.RestaurantDescription, tblRestaurant.RestaurantEmailAddress, tblRestaurant.RestaurantAddress, tblRestaurant.CountryID, tblRestaurant.StateID, tblRestaurant.CityID, tblRestaurant.RestaurantContactNumber, tblRestaurant.RestaurantAddedOn, tblRestaurant.IsActive, tblRestaurant.RestaurantLogo," +
                                                       " tblRestaurant.RestaurantAddress + ', ' + countries.name + ', ' + states.name + ', ' +countries.name + ', ' + cities.name as CompleteAddress FROM   tblRestaurant  INNER JOIN" +
                                                       " tblRestaurantType ON tblRestaurant.RestaurantTypeID = tblRestaurantType.RestaurantTypeID INNER JOIN" +
                                                       " countries ON tblRestaurant.CountryID = countries.id INNER JOIN" +
                                                       " cities ON tblRestaurant.CityID = cities.id INNER JOIN " +
                                                       " states ON tblRestaurant.StateID = states.id " +
                                                       " INNER JOIN tblSubscriptions ON tblSubscriptions.RestaurantID = tblRestaurant.RestaurantID" +
                                                       " WHERE tblRestaurant.RestaurantID = @RestaurantID AND tblSubscriptions.IsActive=1", con))
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






        public static int AddNewRestaurant(mRestaurant pRestaurant)
        {

            int isSucess = 0;

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO tblRestaurant (RestaurantName,RestaurantTypeID, RestaurantDescription,RestaurantContactNumber,RestaurantEmailAddress,RestaurantAddress,CityID, CountryID, StateID, RestaurantAddedOn, RestaurantLogo, isActive, BusinessUserID) " +
                                                            " VALUES (@RestaurantName, @RestaurantTypeID, @RestaurantDescription, @RestaurantContactNumber,@RestaurantEmailAddress,@RestaurantAddress, @CityID,  @CountryID, @StateID, @RestaurantAddedOn, @RestaurantLogo, @isActive, @BusinessUserID); SELECT SCOPE_IDENTITY() ", con))
                {
                    
                    command.Parameters.AddWithValue("@RestaurantName", pRestaurant.RestaurantName);
                    command.Parameters.AddWithValue("@RestaurantTypeID", pRestaurant.RestaurantTypeID);
                    command.Parameters.AddWithValue("@RestaurantDescription", pRestaurant.RestaurantDescription);
                    command.Parameters.AddWithValue("@RestaurantContactNumber", pRestaurant.RestaurantContactNumber);
                    command.Parameters.AddWithValue("@RestaurantEmailAddress", pRestaurant.RestaurantEmailAddress);
                    command.Parameters.AddWithValue("@RestaurantAddress", pRestaurant.RestaurantAddress);
                    command.Parameters.AddWithValue("@CityID", pRestaurant.CityID);
                    command.Parameters.AddWithValue("@CountryID", pRestaurant.CountryID);
                    command.Parameters.AddWithValue("@StateID", pRestaurant.StateID);
                    command.Parameters.AddWithValue("@RestaurantLogo ", pRestaurant.RestaurantLogo);
                    command.Parameters.AddWithValue("@RestaurantAddedOn", DateTime.Now);
                    command.Parameters.AddWithValue("@isActive", pRestaurant.isActive);
                    command.Parameters.AddWithValue("@BusinessUserID", pRestaurant.BusinessUserID);


                    isSucess = Convert.ToInt32(command.ExecuteScalar());


                }
            }




            return isSucess;


        }
        public static int UpdateRestaurant(mRestaurant pRestaurant)
        {

            int isSucess = 0;

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("UPDATE tblRestaurant SET  [RestaurantName] = @RestaurantName,[RestaurantTypeID] = @RestaurantTypeID, [RestaurantDescription] = @RestaurantDescription, [RestaurantContactNumber] = @RestaurantContactNumber, [RestaurantEmailAddress] = @RestaurantEmailAddress, " +
                                                             " [RestaurantAddress] = @RestaurantAddress, [CityID] = @CityID,  [StateID] = @StateID, [CountryID] = @CountryID, [RestaurantLogo] = @RestaurantLogo, [RestaurantAddedOn] = @RestaurantAddedOn,  " +
                                                             " [isActive] = @isActive , [BusinessUserID]= @BusinessUserID WHERE RestaurantID = @RestaurantID ", con))

                {
                    command.Parameters.AddWithValue("@RestaurantID", pRestaurant.RestaurantID);
                    command.Parameters.AddWithValue("@RestaurantName", pRestaurant.RestaurantName);
                    command.Parameters.AddWithValue("@RestaurantTypeID", pRestaurant.RestaurantTypeID);
                    command.Parameters.AddWithValue("@RestaurantDescription", pRestaurant.RestaurantDescription);
                    command.Parameters.AddWithValue("@RestaurantContactNumber", pRestaurant.RestaurantContactNumber);
                    command.Parameters.AddWithValue("@RestaurantEmailAddress", pRestaurant.RestaurantEmailAddress);
                    command.Parameters.AddWithValue("@RestaurantAddress", pRestaurant.RestaurantAddress);
                    command.Parameters.AddWithValue("@CityID", pRestaurant.CityID);
                    command.Parameters.AddWithValue("@CountryID", pRestaurant.CountryID);
                    command.Parameters.AddWithValue("@StateID", pRestaurant.StateID);
                    command.Parameters.AddWithValue("@RestaurantAddedOn", DateTime.Now);
                    command.Parameters.AddWithValue("@RestaurantLogo", pRestaurant.RestaurantLogo);
                    command.Parameters.AddWithValue("@isActive", pRestaurant.isActive);
                    command.Parameters.AddWithValue("@BusinessUserID", pRestaurant.BusinessUserID);


                    isSucess = command.ExecuteNonQuery();


                }
            }

            return isSucess;


        }


        public static int DeleteRestaurant(int _pRestaurantID)
        {

            int isSucess = 0;

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("DELETE From tblRestaurant WHERE RestaurantID = @ RestaurantID ", con))
                {
                    command.Parameters.AddWithValue("@ RestaurantID", _pRestaurantID);

                    isSucess = command.ExecuteNonQuery();


                }
            }




            return isSucess;

        }
    }
}
