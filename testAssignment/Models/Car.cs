using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testAssignment.Models
{
    public class Car
    {
        public int Id { get; set; }

        public string CarBrand { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public DateTime YearOfProduction { get; set; }

        public List<OwnerCar> OwnerCars { get; set; }

        public Car()
        {
            OwnerCars = new List<OwnerCar>();
        }
    }
}
