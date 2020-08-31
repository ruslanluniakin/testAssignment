using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace testAssignment.Models
{
    public class BaseRepository : IRepository
    {
        ApplicationContext db;
        public BaseRepository(ApplicationContext context)
        {
            db = context;

            //db first initialization
            if (!db.Owners.Any())
            {
                List<Owner> owners = new List<Owner>();

                owners.Add(new Owner() { LastName = "Химченко", FirstName = "Гамар", MiddleName = "Валерьевич", BirthYear = new DateTime(1984, 10, 6) });
                owners.Add(new Owner() { LastName = "Обломова", FirstName = "Маритона", MiddleName = "Ивановна", BirthYear = new DateTime(1998, 12, 1) });
                owners.Add(new Owner() { LastName = "Ильина", FirstName = "Илена", MiddleName = "Михайловна", BirthYear = new DateTime(1997, 8, 5) });
                owners.Add(new Owner() { LastName = "Симонова", FirstName = "Василида", MiddleName = "Александровна", BirthYear = new DateTime(1996, 7, 25) });
                owners.Add(new Owner() { LastName = "Добровольская", FirstName = "Энния", MiddleName = "Закировна", BirthYear = new DateTime(1982, 11, 10) });
                owners.Add(new Owner() { LastName = "Ермилова", FirstName = "Бразилия", MiddleName = "Романовна", BirthYear = new DateTime(2001, 9, 15) });
                owners.Add(new Owner() { LastName = "Лучная", FirstName = "Анора", MiddleName = "Владиславовна", BirthYear = new DateTime(1996, 5, 18) });
                owners.Add(new Owner() { LastName = "Кузнецов", FirstName = "Вербан", MiddleName = "Кириллович", BirthYear = new DateTime(1985, 9, 18) });
                owners.Add(new Owner() { LastName = "Осипова", FirstName = "Альона", MiddleName = "Андреевна", BirthYear = new DateTime(1982, 7, 25) });
                owners.Add(new Owner() { LastName = "Зимин", FirstName = "Говард", MiddleName = "Ярославович", BirthYear = new DateTime(1988, 12, 2) });
                owners.Add(new Owner() { LastName = "Добронравова", FirstName = "Ольга", MiddleName = "Андреевна", BirthYear = new DateTime(1976, 4, 10) });
                owners.Add(new Owner() { LastName = "Быстрова", FirstName = "Евгнния", MiddleName = "Ярославовна", BirthYear = new DateTime(1993, 3, 3) });

                db.Owners.AddRange(owners);

                List<Car> cars = new List<Car>();

                cars.Add(new Car() { CarBrand = "Toyota", Model = "Corolla", Color = "Синий", YearOfProduction = new DateTime(2010, 1, 1) });
                cars.Add(new Car() { CarBrand = "Ford", Model = "Raptor", Color = "Черный", YearOfProduction = new DateTime(2015, 1, 1) });
                cars.Add(new Car() { CarBrand = "Volkswagen", Model = "Golf", Color = "Зеленый", YearOfProduction = new DateTime(2011, 1, 1) });
                cars.Add(new Car() { CarBrand = "Toyota", Model = "RAV4", Color = "Красный", YearOfProduction = new DateTime(2012, 1, 1) });
                cars.Add(new Car() { CarBrand = "Honda", Model = "Accord", Color = "Белый", YearOfProduction = new DateTime(2011, 1, 1) });
                cars.Add(new Car() { CarBrand = "Volkswagen", Model = "Tiguan", Color = "Желтый", YearOfProduction = new DateTime(2017, 1, 1) });
                cars.Add(new Car() { CarBrand = "Ford", Model = "Focus", Color = "Черный", YearOfProduction = new DateTime(2010, 1, 1) });
                cars.Add(new Car() { CarBrand = "Toyota", Model = "Camry", Color = "Серый", YearOfProduction = new DateTime(2010, 1, 1) });
                cars.Add(new Car() { CarBrand = "Chevrolet", Model = "Silverado", Color = "Синий", YearOfProduction = new DateTime(2010, 1, 1) });
                cars.Add(new Car() { CarBrand = "Honda", Model = "Accord", Color = "Черный", YearOfProduction = new DateTime(2010, 1, 1) });

                db.Cars.AddRange(cars);
                db.SaveChanges();

                owners[0].OwnerCars.Add(new OwnerCar { CarId = cars[1].Id, OwnerId = owners[0].Id });
                owners[1].OwnerCars.Add(new OwnerCar { CarId = cars[4].Id, OwnerId = owners[1].Id });
                owners[1].OwnerCars.Add(new OwnerCar { CarId = cars[2].Id, OwnerId = owners[1].Id });
                owners[2].OwnerCars.Add(new OwnerCar { CarId = cars[0].Id, OwnerId = owners[2].Id });
                owners[3].OwnerCars.Add(new OwnerCar { CarId = cars[4].Id, OwnerId = owners[3].Id });
                owners[4].OwnerCars.Add(new OwnerCar { CarId = cars[5].Id, OwnerId = owners[4].Id });
                owners[4].OwnerCars.Add(new OwnerCar { CarId = cars[7].Id, OwnerId = owners[4].Id });
                owners[4].OwnerCars.Add(new OwnerCar { CarId = cars[9].Id, OwnerId = owners[4].Id });
                owners[5].OwnerCars.Add(new OwnerCar { CarId = cars[2].Id, OwnerId = owners[5].Id });
                owners[5].OwnerCars.Add(new OwnerCar { CarId = cars[8].Id, OwnerId = owners[5].Id });
                owners[6].OwnerCars.Add(new OwnerCar { CarId = cars[8].Id, OwnerId = owners[6].Id });
                owners[6].OwnerCars.Add(new OwnerCar { CarId = cars[9].Id, OwnerId = owners[6].Id });
                owners[7].OwnerCars.Add(new OwnerCar { CarId = cars[3].Id, OwnerId = owners[7].Id });
                owners[7].OwnerCars.Add(new OwnerCar { CarId = cars[7].Id, OwnerId = owners[7].Id });
                owners[8].OwnerCars.Add(new OwnerCar { CarId = cars[6].Id, OwnerId = owners[8].Id });
                owners[8].OwnerCars.Add(new OwnerCar { CarId = cars[3].Id, OwnerId = owners[8].Id });
                owners[9].OwnerCars.Add(new OwnerCar { CarId = cars[0].Id, OwnerId = owners[9].Id });
                owners[9].OwnerCars.Add(new OwnerCar { CarId = cars[6].Id, OwnerId = owners[9].Id });
                owners[10].OwnerCars.Add(new OwnerCar { CarId = cars[6].Id, OwnerId = owners[10].Id });
                owners[11].OwnerCars.Add(new OwnerCar { CarId = cars[1].Id, OwnerId = owners[11].Id });
                owners[11].OwnerCars.Add(new OwnerCar { CarId = cars[0].Id, OwnerId = owners[11].Id });
                db.SaveChanges();


            }
        }
        public IEnumerable<Car> GetCars(Owner owner)
        {
            Owner foundOwner =
                db.Owners
                .Include(x => x.OwnerCars)
                .ThenInclude(x => x.Car)
                .FirstOrDefault(x => x.FirstName == owner.FirstName && x.LastName == owner.LastName);

            if (foundOwner == null)
            {
                return null;
            }

            List<Car> cars = new List<Car>();
            foundOwner.OwnerCars.ForEach(x => cars.Add(
                new Car
                {
                    Id = x.Car.Id,
                    CarBrand = x.Car.CarBrand,
                    Model = x.Car.Model,
                    Color = x.Car.Color,
                    YearOfProduction = x.Car.YearOfProduction
                }));

            return cars;
        }

        public IEnumerable<Owner> GetOwners(int id)
        {
            Car car = db.Cars.Include(x => x.OwnerCars).ThenInclude(x => x.Owner).FirstOrDefault(x => x.Id == id);

            if (car == null)
            {
                return null;
            }

            List<Owner> owners = new List<Owner>();
            car.OwnerCars.ForEach(x => owners.Add(
                new Owner
                {
                    Id = x.Owner.Id,
                    LastName = x.Owner.LastName,
                    FirstName = x.Owner.FirstName,
                    MiddleName = x.Owner.MiddleName,
                    BirthYear = x.Owner.BirthYear
                }));

            return owners;
        }
    }
}
