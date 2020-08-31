using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testAssignment.Models
{
    public interface IRepository
    {
        IEnumerable<Car> GetCars(Owner owner);

        IEnumerable<Owner> GetOwners(int id);
    }
}
