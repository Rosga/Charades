using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web.Mvc;
using Charades.Domain.Abstract;
using Charades.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Charades.WebUI;
using Charades.WebUI.Controllers;
using Moq;

namespace Charades.WebUI.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        //[TestMethod]
        //public void Can_Paginate()
        //{
        //    var mock = new Mock<ICharadeRepository>();

        //    mock.Setup(m => m.Words).Returns(new Word[]
        //    {
        //        new Word {WordId = 1, Name = "W1"},
        //        new Word {WordId = 2, Name = "W2"},
        //        new Word {WordId = 3, Name = "W3"}
        //    }.AsQueryable());

        //    // Arrange
        //    var controller = new HomeController(mock.Object);
        //    controller.PageSize = 2;

        //    // Act
        //    var result = (IEnumerable<Word>)controller.Index(2).Model;

        //    var target = result.ToArray();

        //    //Assert
        //    Assert.AreEqual(target[0].WordId, 3);

        //    // Assert
        //    //Assert.AreEqual("Modify this template to jump-start your ASP.NET MVC application.", result.ViewBag.Message);
        //}

        //[TestMethod]
        //public void Can_get_File()
        //{
        //    var mock = new Mock<ICharadeRepository>();

        //    mock.Setup(m => m.Words).Returns(new Word[]
        //    {
        //        new Word {WordId = 1, Name = "W1"},
        //        new Word {WordId = 2, Name = "W2"},
        //        new Word {WordId = 3, Name = "W3"}
        //    }.AsQueryable());

        //    // Arrange
        //    var controller = new HomeController(mock.Object);

        //    var result = controller.GetFile(1);

        //    Assert.AreEqual(typeof(FileContentResult), result);
        //}

        //[TestMethod]
        //public void About()
        //{
        //    // Arrange
        //    HomeController controller = new HomeController();

        //    // Act
        //    ViewResult result = controller.About() as ViewResult;

        //    // Assert
        //    Assert.IsNotNull(result);
        //}

        //[TestMethod]
        //public void Contact()
        //{
        //    // Arrange
        //    HomeController controller = new HomeController();

        //    // Act
        //    ViewResult result = controller.Contact() as ViewResult;

        //    // Assert
        //    Assert.IsNotNull(result);
        //}
    }
}
