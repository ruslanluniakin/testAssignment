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
            mock.Setup(repo => repo.GetCars(It.IsAny<Owner>())).Returns(GetTestCars());
            var controller = new TestController(mock.Object);

            // Act
            var result = controller.Post(new Owner { FirstName = "Говард", LastName = "Зимин" });

            // Assert
            var okResult = result as OkObjectResult;
            var cars = okResult.Value as List<Car>;
            Assert.Equal(GetTestCars().Count, cars.Count);
        }

        [Fact]
        public void GetOwnersReturnsResultWithAListOfOwners()
        {
            // Arrange
            var mock = new Mock<IRepository>();
            mock.Setup(repo => repo.GetOwners(It.IsAny<int>())).Returns(GetTestOwners());
            var controller = new TestController(mock.Object);

            // Act
            var result = controller.Get(6);

            // Assert
            var okResult = result as OkObjectResult;
            var owners = okResult.Value as List<Owner>;
            Assert.Equal(GetTestCars().Count, owners.Count);
        }

        private List<Car> GetTestCars()
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

        private List<Owner> GetTestOwners()
        {
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
