using Labolatorium3___App.Controllers;
using Labolatorium3___App.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class CarControllerTest
    {
        private CarController _controller;
        private ICarService _carService;
        public CarControllerTest()
        {
            _carService = new MemoryCarService();
            _carService.Add(new Car() { Name = "Test1", MakerId = 1 });
            _carService.Add(new Car() { Name = "Test2", MakerId = 2 });
            _carService.Add(new Car() { Name = "Test3", MakerId = 1 });
            _carService.Add(new Car() { Name = "Test4", MakerId = 3 });
            _controller = new CarController(_carService);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void IndexPaginationTest(int p)
        {
            var result = _controller.Index(p);
            Assert.IsType<ViewResult>(result);
            var view = result as ViewResult;
            Assert.IsType<PagingList<Car>>(view.Model);
            PagingList<Car>? list = view.Model as PagingList<Car>;
            Assert.NotNull(list.Data);
            if(p == 1)
                Assert.Equal(3, list.Data.Count());
            else 
                Assert.Equal(1, list.Data.Count());
        }


        [Theory]
        [InlineData(-1)]
        [InlineData(1)]
        [InlineData(2)]
        public void IndexMakersTest(int m)
        {
            var result = _controller.Index(1, 3, m);
            Assert.IsType<ViewResult>(result);
            var view = result as ViewResult;
            Assert.IsType<PagingList<Car>>(view.Model);
            PagingList<Car>? list = view.Model as PagingList<Car>;
            Assert.NotNull(list.Data);

            switch (m)
            {
                case -1:
                    Assert.Equal(3, list.Data.Count());
                    break;
                case 1:
                    Assert.Equal(2, list.Data.Count());
                    break;
                case 2:
                    Assert.Equal(1, list.Data.Count());
                    break;
            }
            if(m != -1)
                foreach(Car item in list.Data)
                    Assert.Equal(m, item.MakerId);
        }


        [Fact]
        public void CreateValidTest()
        {
            Car car = new Car()
            {
                Name = "TestCreate",
                MakerId = 1,
                Volume = 1000,
                Power = 100,
                EngineType = EngineType.Diesel,
                Registration = "ABC123",
                OwnerId = 2
            };

            _controller.Create(car);
            Car? created = _carService.FindById(5);
            Assert.NotNull(created);
            Assert.Equal("TestCreate", created.Name);
        }
        
        [Fact]
        public void CreateInvalidTest()
        {
            Car car = new Car()
            {
                Name = "TestCreate",
                MakerId = 1,
                Volume = -1000,
                Power = 100,
                EngineType = EngineType.Diesel,
                Registration = "ABC123",
                OwnerId = 2
            };

            _controller.ModelState.AddModelError("Volume", "Volume must be greather than zero");
            _controller.Create(car);
            Car? created = _carService.FindById(5);
            Assert.Null(created);
        }

        [Fact]
        public void DeleteCarTest()
        {
            Car? car = _carService.FindById(4);
            Assert.NotNull(car);
            _controller.Delete(car);
            Car? deleted = _carService.FindById(4);
            Assert.Null(deleted);
        }

        [Fact]
        public void UpdateValidTest()
        {
            Car? car = _carService.FindById(4);
            Assert.NotNull(car);
            car.Name = "UpdatedName";
            var result = _controller.Update(car);
            Assert.IsType<RedirectToActionResult>(result);
            Car? updated = _carService.FindById(4);
            Assert.NotNull(updated);
            Assert.Equal("UpdatedName", updated.Name);
        }

        [Fact]
        public void UpdateInvalidTest()
        {
            Car car = new Car()
            {
                Id = 10,
                Name = "TestCreate",
                MakerId = 1,
                Volume = -1000,
                Power = 100,
                EngineType = EngineType.Diesel,
                Registration = "ABC123",
                OwnerId = 2
            };

            _controller.ModelState.AddModelError("Volume", "Volume must be greather than zero");

            var result = _controller.Update(car);
            Assert.IsType<ViewResult>(result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void DetailsForExistingCarTest(int id)
        {
            var result = _controller.Details(id);
            Assert.IsType<ViewResult>(result);
            var view = result as ViewResult;
            Assert.IsType<Car>(view.Model);
            Car? model = view.Model as Car;
            Assert.NotNull(model);
            Assert.Equal(id, model.Id);
            Assert.Equal($"Test{id}", model.Name);
            Assert.Equal(id, model.Maker.Id);
        }

        [Fact]
        public void DetailsForNonExistingCarTest()
        {
            var result = _controller.Details(10);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void UpdateForNonExistingCarTest()
        {
            var result = _controller.Update(10);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void DeleteForNonExistingCarTest()
        {
            var result = _controller.Delete(10);
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
