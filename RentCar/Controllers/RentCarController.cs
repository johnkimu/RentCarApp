using RentCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RentCar.Controllers
{
    public class RentCarController : ApiController
    {
        List<Car> cars = new List<Car>();

        public RentCarController() { }

        public RentCarController(List<Car> cars)
        {
            this.cars = cars;
        }

        public IEnumerable<Car> GetAllCars()
        {
            return cars;
        }

        public async Task<IEnumerable<Car>> GetAllCarsAsync()
        {
            return await Task.FromResult(GetAllCars());
        }

        public IHttpActionResult GetCar(int id)
        {
            var car = cars.FirstOrDefault((c) => c.Id == id);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }

        public async Task<IHttpActionResult> GetCarAsync(int id)
        {
            return await Task.FromResult(GetCar(id));
        }
    }
}

