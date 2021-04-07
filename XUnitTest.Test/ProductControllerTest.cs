using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebUI.Controllers;
using Xunit;

namespace xUnitTest.Test
{
    public class ProductControllerTest
    {
        private readonly Mock<IProductService> _mockService;
        private readonly ProductController _controller;
        private List<Product> list;

        public ProductControllerTest()
        {
            _mockService = new Mock<IProductService>();
            _controller = new ProductController(_mockService.Object);
            list = new List<Product>()
            {
                new Product(){ Id=1, Name="kalem",   Price=8,   Stock=10},
                new Product(){ Id=2, Name="silgi",   Price=5,   Stock=11},
            };
        }

        [Fact]
        public async void Index_ActionExecutes_ReturnValue()
        {
            var result = await _controller.Index();
            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public async void Index_ActionExecutes_ReturnProductList()
        {
            _mockService.Setup(x => x.GetList()).ReturnsAsync(list);
            var result = await _controller.Index();
            var viewResult = Assert.IsType<ViewResult>(result);
            var productList = Assert.IsAssignableFrom<IEnumerable<Product>>(viewResult.Model);
            Assert.Equal<int>(2, productList.Count());
        }
    }
}
