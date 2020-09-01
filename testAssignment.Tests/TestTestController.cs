using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text.Json;
using testAssignment.Controllers;
using testAssignment.Models;
using Xunit;

namespace testAssignment.Tests
{
    public class TestControllerTests
    {
        [Fact]
        public void GetCarsReturnsResultWithAListOfCars()
        {
            // Arrange
            var mock = new Mock<IRepository>();
            mock.Setup(repo => repo.GetCars(It.IsAny<Owner>())).Returns(GetTestCars(new Owner{ FirstName = "Говард", LastName = "Зимин" }));
            var controller = new TestController(mock.Object);

            // Act
            var result = controller.Post(new Owner ());

            // Assert
            var okResult = result as OkObjectResult;
            var cars = okResult.Value as List<Car>;
            Assert.Equal(GetTestCars(new Owner { FirstName = "Говард", LastName = "Зимин" }).Count, cars.Count);
        }

        [Fact]
        public void GetCarsReturnsNotFoundResult()
        {
            // Arrange
            var mock = new Mock<IRepository>();
            mock.Setup(repo => repo.GetCars(It.IsAny<Owner>())).Returns(GetTestCars(new Owner { FirstName = "Василида", LastName = "Симонова" }));
            var controller = new TestController(mock.Object);

            // Act
            var result = controller.Post(new Owner());

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void GetOwnersReturnsResultWithAListOfOwners()
        {
            // Arrange
            var mock = new Mock<IRepository>();
            mock.Setup(repo => repo.GetOwners(It.IsAny<int>())).Returns(GetTestOwners(2));
            var controller = new TestController(mock.Object);

            // Act
            var result = controller.Get(6);

            // Assert
            var okResult = result as OkObjectResult;
            var owners = okResult.Value as List<Owner>;
            Assert.Equal(GetTestOwners(2).Count, owners.Count);
        }

        [Fact]
        public void GetOwnersReturnsNotFoundResult()
        {
            // Arrange
            var mock = new Mock<IRepository>();
            mock.Setup(repo => repo.GetOwners(It.IsAny<int>())).Returns(GetTestOwners(100));
            var controller = new TestController(mock.Object);

            // Act
            var result = controller.Get(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        private List<Car> GetTestCars(Owner owner)
        {
            if (owner.LastName == "Зимин" && owner.FirstName == "Говард")
            {
                var cars = new List<Car>
                { 
                    new Car() { CarBrand = "Toyota", Model = "RAV4", Color = "Красный", YearOfProduction = new DateTime(2012, 1, 1) },
                    new Car() { CarBrand = "Honda", Model = "Accord", Color = "Белый", YearOfProduction = new DateTime(2011, 1, 1) },
                    new Car() { CarBrand = "Volkswagen", Model = "Tiguan", Color = "Желтый", YearOfProduction = new DateTime(2017, 1, 1) },
                    new Car() { CarBrand = "Ford", Model = "Focus", Color = "Черный", YearOfProduction = new DateTime(2010, 1, 1) },
                };
                return cars;
            }

            return null;
        }

        private List<Owner> GetTestOwners(int? id)
        {
            if (id < 1 || id > 10)
            {
                return null;
            }

            var owners = new List<Owner>
            {
                new Owner() { LastName = "Лучная", FirstName = "Анора", MiddleName = "Владиславовна", BirthYear = new DateTime(1996, 5, 18) },
                new Owner() { LastName = "Кузнецов", FirstName = "Вербан", MiddleName = "Кириллович", BirthYear = new DateTime(1985, 9, 18) },
                new Owner() { LastName = "Осипова", FirstName = "Альона", MiddleName = "Андреевна", BirthYear = new DateTime(1982, 7, 25) },
                new Owner() { LastName = "Зимин", FirstName = "Говард", MiddleName = "Ярославович", BirthYear = new DateTime(1988, 12, 2) }
            };
            return owners;
        }
    }
}
