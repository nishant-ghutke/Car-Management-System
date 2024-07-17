using CarRentalSystem.DAL.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;


namespace CarRentalSystem.BAL.Services
{
    public class UserService
    {
         CarRentalEntities dbObj = new CarRentalEntities();

        /// <summary>
        /// Methods to Insert , Update , Delete ,GetCountriesList,GetStateList of users
        /// </summary>
        /// <returns></returns>
        #region Public Method
        public List<tbl_UserRegistration> GetAllUsers()
        {
            return dbObj.tbl_UserRegistration.AsNoTracking().ToList();
        }
        public tbl_UserRegistration GetUserById(int id)
        {
            return dbObj.tbl_UserRegistration.FirstOrDefault(x => x.UserID == id);
        }
        public bool InsertUser(tbl_UserRegistration model)
        {
            try
            {
                dbObj.tbl_UserRegistration.Add(model);
                dbObj.QuantityCheck(model.CarRented,0);
                SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error inserting data: {ex.Message}");
                return false;
            }

        }


        public bool UpdateUser(tbl_UserRegistration model)
        {
            try
            {
                dbObj.sp_update(model.UserID, model.FirstName, model.LastName, model.Email, model.Country, model.State, model.CarRented);
                dbObj.SaveChanges();
                GetAllUsers();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting data: {ex.Message}");
                return false;
            }
        }
        public List<string> GetCountriesList()
        {
            List<tbl_Countries> countries = dbObj.tbl_Countries.ToList();
            List<string> countryNames = new List<string>();

            foreach (var item in countries)
            {
                countryNames.Add(item.Countries);
            }

            return countryNames;
        }

        public List<string> GetCarList()
        {
            List<tbl_CarRegistration> cars = dbObj.tbl_CarRegistration.Where(a => a.Quantity > 0).ToList();
            List<string> carsName = new List<string>();
            foreach (var item in cars)
            {
                carsName.Add(item.CarName);
            }
            return carsName;
        }



        public List<string> GetStatesList()
        {
            List<tbl_States> states = dbObj.tbl_States.ToList();
            List<string> stateName = new List<string>();

            foreach (var item in states)
            {
                stateName.Add(item.State);
            }

            return stateName;
        }
       
        public void DeleteUser(int id)
        {
            var user = dbObj.tbl_UserRegistration.FirstOrDefault(x => x.UserID == id);
            if (user != null)
            {
                dbObj.tbl_UserRegistration.Remove(user);
                dbObj.QuantityCheck(user.CarRented, 1);
                SaveChanges();
            }
        }
        public void Detail(int id)
        {
             dbObj.tbl_UserRegistration.FirstOrDefault(x => x.UserID == id);
            
        }
        private void SaveChanges()
        {
            try
            {
                dbObj.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}











