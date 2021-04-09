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

        [Fact]
        public async void Details_IdNull_ReturnRedirectToIndexAction()
        {
            var result = await _controller.Details(null);
            var redirect = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirect.ActionName);
        }
        [Fact]
        public async void Details_IdInValid_ReturnNotFound()
        {
            Product product = null;
            _mockService.Setup(x => x.GetById(0)).ReturnsAsync(product);
            var result = await _controller.Details(0);
            var redirect = Assert.IsType<NotFoundResult>(result);
            Assert.Equal<int>(404, redirect.StatusCode);
        }
        [Theory]
        [InlineData(1)]
        public async void Details_IdValid_ReturnProduct(int productId)
        {
            Product product = list.First(x => x.Id == productId);
            _mockService.Setup(x => x.GetById(productId)).ReturnsAsync(product);
            var result = await _controller.Details(productId);
            var viewResult = Assert.IsType<ViewResult>(result);
            var resultProduct = Assert.IsAssignableFrom<Product>(viewResult.Model);
            Assert.Equal(product.Id, resultProduct.Id);
        }
        [Fact]
        public void Create_ActionExecutes_ReturnView()
        {
            var result = _controller.Create();
            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public async void CreatePOST_ModalStateInValid_ReturnView()
        {
            _controller.ModelState.AddModelError("Name", "The Name field is required");
            var result = await _controller.Create(list.First());
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsType<Product>(viewResult.Model);
        }
        [Fact]
        public async void CreatePOST_ModalStateValid_ReturnRedirectToIndexAction()
        {
            var result = await _controller.Create(list.First());
            var redirect = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirect.ActionName);
        }
        [Fact]
        public async void CreatePOST_ModalStateValid_CreateMethodExecute()
        {
            Product product = null;
            _mockService.Setup(x => x.Add(It.IsAny<Product>())).Callback<Product>(x => product = x);
            var result = await _controller.Create(list.First());
            _mockService.Verify(x => x.Add(It.IsAny<Product>()), Times.Once);
            Assert.Equal(list.First().Id, product.Id);
        }
        [Fact]
        public async void CreatePOST_ModalStateInValid_NeverAddExecute()
        {
            _controller.ModelState.AddModelError("Name", "");
            var result = await _controller.Create(list.First());
            _mockService.Verify(x => x.Add(It.IsAny<Product>()), Times.Never);
        }
    }
}
