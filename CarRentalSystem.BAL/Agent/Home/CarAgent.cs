using AutoMapper;
using CarRentalSystem.DAL.DataModel;
using CarRentalSystem.DAL.Services.Home;
using CarRentalSystem.Model;
using System;
using System.Collections.Generic;



namespace CarRentalSystem.BAL.Agent.Home
{
    public class CarAgent : ICarAgent
    {


        private readonly IMapper _mapper;
        public CarAgent(IMapper mapper)
        {
            _mapper = mapper;
        }
        
        CarService carService = new CarService();
        #region public method
        public List<CarModel> GetAllCars()
        {
            List<tbl_CarRegistration> carList = carService.GetAllCars();
            List<CarModel> carListView = _mapper.Map<List<CarModel>>(carList);
            return carListView;
        }

        public CarModel GetCarById(int id)
        {
            tbl_CarRegistration carData = carService.GetCarById(id);
            CarModel carDataView = _mapper.Map<CarModel>(carData);
            return carDataView;
        }

        public void InsertCar(CarModel model)
        {
           tbl_CarRegistration carData= _mapper.Map<tbl_CarRegistration>(model);
            carService.InsertCar(carData);
        }

        public void UpdateCar(CarModel model)
        {
            tbl_CarRegistration carData = _mapper.Map<tbl_CarRegistration>(model);
            carService.UpdateCar(carData);
        }

        public void DeleteCar(int id)
        {
            carService.DeleteCar(id);
        }
        public void Detail(int id)
        {
            carService.Detail(id);
        }
        #endregion
    }
}
