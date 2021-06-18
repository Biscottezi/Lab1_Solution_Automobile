using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomobileLibrary.BusinessObject;
using AutomobileLibrary.DataAccess;

namespace AutomobileLibrary.Repository
{
    public class CarRepository : ICarRepository
    {
        public IEnumerable<Car> GetCars() => CarDBContext.Instance.GetCarList();
        public Car GetCarById(int carId) => CarDBContext.Instance.GetCarById(carId);
        public void InsertCar(Car car) => CarDBContext.Instance.AddNewCar(car);
        public void DeleteCar(int carId) => CarDBContext.Instance.RemoveCar(carId);
        public void UpdateCar(Car car) => CarDBContext.Instance.UpdateCar(car);
    }
}
