using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testAssignment.Models
{
    public class Owner
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public DateTime BirthYear { get; set; }

        public List<OwnerCar> OwnerCars { get; set; }

        public Owner()
        {
            OwnerCars = new List<OwnerCar>();
        }
    }
}
