using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testAssignment.Models
{
    public class OwnerCar
    {
        public int OwnerId { get; set; }

        public Owner Owner { get; set; }

        public int CarId { get; set; }

        public Car Car { get; set; }
    }
}
