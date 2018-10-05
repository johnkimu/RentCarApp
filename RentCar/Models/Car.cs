using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentCar.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public string Make { get; set; }
    }
}