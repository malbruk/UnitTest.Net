using BasicAPI;
using BasicAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    //https://code-maze.com/unit-testing-aspnetcore-web-api/
    public class ValuesControllerTest
    {
        private readonly EventsController _controller;
        private readonly IDataContext _dataContext;

        public ValuesControllerTest()
        {
            _dataContext = new FakeContext();
            _controller = new EventsController(_dataContext);
        }

        [Fact]
        public void Get_ReturnsOKResult()
        {
            //Act
            var result = _controller.Get();

            //Assert
            Assert.IsType<List<Event>>(result);
        }

        [Fact]
        public void Get_ReturnsAllItems()
        {
            //Act
            var result = _controller.Get() as List<Event>;

            //Assert
            var items = Assert.IsType<List<Event>>(result);
            Assert.Equal(2, items.Count);
        }

        [Fact]
        public void GetById_ReturnNotFoundResult()
        {
            var testId = 1;
            var result = _controller.Get(testId) as ActionResult<Event>;
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void GetById_ReturnsOkResult()
        {
            var testId = 1;
            var result = _controller.Get(testId) as ActionResult<Event>;
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetById_ReturnsRightItem()
        {
            var testId = 1;
            var result = _controller.Get(testId) as ActionResult<Event>;
            Assert.IsType<Event>(result.Value);
            Assert.Equal(testId, result.Value.Id);
        }
    }
}
