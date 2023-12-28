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
            _carService.Add(new Car() { Name = "Test1" });
            _carService.Add(new Car() { Name = "Test2" });
            _carService.Add(new Car() { Name = "Test3" });
            _carService.Add(new Car() { Name = "Test4" });
            _controller = new CarController(_carService);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void IndexTest(int p)
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
        [InlineData(1)]
        [InlineData(2)]
        public void DetailsTestForExistingContacts(int id)
        {
            var result = _controller.Details(id);
            Assert.IsType<ViewResult>(result);
            var view = result as ViewResult;
            Assert.IsType<Car>(view.Model);
            Car? model = view.Model as Car;
            Assert.NotNull(model);
            Assert.Equal(id, model.Id);
        }

        [Fact]
        public void DetailsTestForNonExistingContacts()
        {
            var result = _controller.Details(10);
            Assert.IsType<NotFoundResult>(result);
        }


    }
}
