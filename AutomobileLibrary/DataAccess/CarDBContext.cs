using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomobileLibrary.BusinessObject;

namespace AutomobileLibrary.DataAccess
{
    public class CarDBContext
    {
        //Initialize Car list
        private static List<Car> CarList = new List<Car>()
        {
            new Car{CarID = 1, CarName = "CRV", Manufacturer = "Honda", Price = 30000, ReleaseYear = 2021 },
            new Car{CarID = 2, CarName = "Ford Focus", Manufacturer = "Ford", Price = 15000, ReleaseYear = 2020}
        };
        //-------------------
        //Using Singleton Pattern
        private static CarDBContext instance = null;
        private static readonly object instanceLock = new object();
        private CarDBContext(){}
        public static CarDBContext Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CarDBContext();
                    }
                    return instance;
                }
            }
        }
        //--------------
        //Get CarList
        public List<Car> GetCarList() => CarList;
        //------------------
        public Car GetCarById(int CarId)
        {
            //using LinQ to Object
            Car car = CarList.SingleOrDefault(pro => pro.CarID == CarId);
            return car;
        }
        //---------------
        //Add a new car
        public void AddNewCar(Car car)
        {
            Car pro = GetCarById(car.CarID);
            if(pro == null)
            {
                CarList.Add(car);
            }
            else
            {
                throw new Exception("Car already exists.");
            }
        }
        //----------------
        //Update a car
        public void UpdateCar(Car car)
        {
            Car c = GetCarById(car.CarID);
            if(c != null)
            {
                var index = CarList.IndexOf(c);
                CarList[index] = car;
            }
            else
            {
                throw new Exception("Car does not already exists.");
            }
        }
        //-------------
        //Remove car
        public void RemoveCar(int carId)
        {
            Car c = GetCarById(carId);
            if (c != null)
            {
                CarList.Remove(c);
            }
            else
            {
                throw new Exception("Car does not already exists.");
            }
        }
    }
}
