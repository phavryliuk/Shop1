using Shop1.Data.interfaces;
using Shop1.Data.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace Shop1.Data.Repository
{
    public class CarRepository : IAllCars
    {


        private readonly AppDbContent appDbContent;

        public CarRepository(AppDbContent appDbContent)
        {
            this.appDbContent = appDbContent;
           
        }

        public IEnumerable<Car> Cars => appDbContent.Car.Include(c => c.Category);

        public IEnumerable<Car> GetFavCars => appDbContent.Car.Where(p => p.isFavourite).Include(c => c.Category);

        public Car GetObjectCar(int carId) => appDbContent.Car.FirstOrDefault(p => p.id == carId);
    }
}
