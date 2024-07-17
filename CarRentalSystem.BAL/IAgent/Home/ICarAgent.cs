using CarRentalSystem.DAL.DataModel;
using CarRentalSystem.Model;
using System.Collections.Generic;


namespace CarRentalSystem.BAL.Agent.Home
{
    public interface ICarAgent
    {
            CarModel GetCarById(int id);
            void InsertCar(CarModel model);
            void UpdateCar(CarModel model);
            void DeleteCar(int id);
            List<CarModel> GetAllCars();
            void Detail(int id);
       
    }
}
        

       
