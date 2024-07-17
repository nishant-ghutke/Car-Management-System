using CarRentalSystem.DAL.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;



namespace CarRentalSystem.DAL.Services.Home
{
    public class CarService
    {
        CarRentalEntities dbObj = new CarRentalEntities();


        /// <summary>
        /// Methods to Insert , Update , Delete ,GetCountriesList,GetStateList of users
        /// </summary>
        /// <returns></returns>
        
        #region Public Method
        public List<tbl_CarRegistration> GetAllCars()
        {
            return dbObj.tbl_CarRegistration.ToList();
        }
        public tbl_CarRegistration GetCarById(int id)
        {
            return dbObj.tbl_CarRegistration.FirstOrDefault(x => x.CarID == id);
        }
        public void InsertCar(tbl_CarRegistration model)
        {
            dbObj.tbl_CarRegistration.Add(model);
            SaveChanges();
        }
        public void UpdateCar(tbl_CarRegistration model)
        {
            //var car = dbObj.tbl_CarRegistration.FirstOrDefault(x => x.CarID == model.CarID);
            //if (car != null)
            //{
            //    car.CarName = model.CarName;
            //    car.CarMileage = model.CarMileage;
            //    car.Available = model.Available;

            //    SaveChanges();
            //}

            dbObj.sp_carupdate(model.CarID, model.CarName,model.CarMileage,model.Quantity);
            SaveChanges();
        }
        public void DeleteCar(int id)
        {
            var car = dbObj.tbl_CarRegistration.FirstOrDefault(x => x.CarID == id);
            if (car != null)
            {
                dbObj.tbl_CarRegistration.Remove(car);
                SaveChanges();
            }
        }
        public void Detail(int id)
        {
            dbObj.tbl_CarRegistration.FirstOrDefault(x => x.CarID == id);

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






        



