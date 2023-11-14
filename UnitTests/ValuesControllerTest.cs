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
        private readonly ValuesController _controller;
        private readonly IDataContext _dataContext;

        public ValuesControllerTest()
        {
            _dataContext = new FakeContext();
            _controller = new ValuesController(_dataContext);
        }

        [Fact]
        public void Get_ReturnsOKResult()
        {
            //Act
            var result = _controller.Get();

            //Assert
            Assert.IsType<List<string>>(result);
        }

        [Fact]
        public void Get_ReturnsAllItems()
        {
            //Act
            var result = _controller.Get() as List<string>;

            //Assert
            var items = Assert.IsType<List<string>>(result);
            Assert.Equal(2, items.Count);
        }

        [Fact]
        public void GetById_ReturnNotFoundResult()
        {
            var result = _controller.Get("bbb") as ActionResult<string>;
            Assert.IsType<NotFoundResult>(result.Result);
        }

        //[Fact]
        //public void GetById_ReturnNotFoundResult()
        //{
        //    var result = _controller.Get("bbb");
        //    Assert.IsType<NotFoundResult>(result as NotFoundResult);
        //}

        [Fact]
        public void GetById_ReturnsOkResult()
        {
            var testValue = "text a";
            var result = _controller.Get(testValue) as ActionResult<string>;
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetById_ReturnsRightItem()
        {
            var testValue = "text a";
            var result = _controller.Get(testValue) as ActionResult<string>;
            Assert.IsType<string>(result.Value);
            Assert.Equal(testValue, result.Value);
        }
    }
}
