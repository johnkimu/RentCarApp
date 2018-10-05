using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentCar.Controllers;
using RentCar.Models;

namespace RentCar.Tests
{
    [TestClass]
    public class TestRentCarController
    {
         [TestMethod]
        public void GetAllCars_ShouldReturnAllCars()
        {
            var testCars = GetTestCars();
            var controller = new RentCarController(testCars);

            var result = controller.GetAllCars() as List<Car>;
            Assert.AreEqual(testCars.Count, result.Count);
        }

        [TestMethod]
        public async Task GetAllCarsAsync_ShouldReturnAllCars()
        {
            var testCars = GetTestCars();
            var controller = new RentCarController(testCars);

            var result = await controller.GetAllCarsAsync() as List<Car>;
            Assert.AreEqual(testCars.Count, result.Count);
        }

        [TestMethod]
        public void GetCar_ShouldReturnCorrectCar()
        {
            var testCars = GetTestCars();
            var controller = new RentCarController(testCars);

            var result = controller.GetCar(4) as OkNegotiatedContentResult<Car>;
            Assert.IsNotNull(result);
            Assert.AreEqual(testCars[3].Make, result.Content.Make);
        }

        [TestMethod]
        public async Task GetCarAsync_ShouldReturnCorrectCar()
        {
            var testCars = GetTestCars();
            var controller = new RentCarController(testCars);

            var result = await controller.GetCarAsync(1) as OkNegotiatedContentResult<Car>;
            Assert.IsNotNull(result);
            Assert.AreEqual(testCars[0].Make, result.Content.Make);
        }

        [TestMethod]
        public void GetCar_ShouldNotFindCar()
        {
            var controller = new RentCarController(GetTestCars());

            var result = controller.GetCar(999);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        private List<Car> GetTestCars()
        {
            var testCars = new List<Car>();
            testCars.Add(new Car { Id = 1, Model = "Ford", Price = 270.000, Make ="Mustang" });
            testCars.Add(new Car { Id = 2, Model = "Audi", Price = 370.000, Make ="A7" });
            testCars.Add(new Car { Id = 3, Model = "BMW", Price = 570.000, Make ="i8" });
            testCars.Add(new Car { Id = 4, Model = "Mercedes", Price = 770.000, Make ="EQC 400" });
            testCars.Add(new Car { Id = 5, Model = "Ferrari", Price = 870.000, Make ="488" });
            testCars.Add(new Car { Id = 6, Model = "Bugatti", Price = 9170.000, Make ="Chiron" });
            
            return testCars;
        }
    }
}
