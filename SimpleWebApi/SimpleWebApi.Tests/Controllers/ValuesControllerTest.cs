using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleWebApi;
using SimpleWebApi.Controllers;
using SimpleAPIService;
using Moq;

namespace SimpleWebApi.Tests.Controllers
{
    [TestClass]
    public class ValuesControllerTest
    {
        [TestInitialize]
        public void ServiceCreation()
        {
            var mockService = new Mock<IAPIService>();
        }



        [TestMethod]
        public void Get_ReturnsItemsPosted()
        {
            // Arrange
            var service = new Mock<IAPIService>();
            ValuesController controller = new ValuesController(service.Object);
            controller.Post("TestValue1");
            controller.Post("TestValue2");
            controller.Post("TestValueBob");

            // Act
            IEnumerable<string> result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count());
            Assert.AreEqual("TestValue1", result.ElementAt(0));
            Assert.AreEqual("TestValue2", result.ElementAt(1));
            Assert.AreEqual("TestValueBob", result.ElementAt(2));
        }

        [TestMethod]
        public void GetById_ReturnsItem()
        {
            // Arrange
            var service = new Mock<IAPIService>();
            ValuesController controller = new ValuesController(service.Object);
            controller.Put(5, "TestValue");

            // Act
            string result = controller.Get(5);

            // Assert
            Assert.AreEqual("TestValue", result);
        }

        [TestMethod]
        public void GetById_ReturnsNullOnNoItem()
        {
            // Arrange
            var service = new Mock<IAPIService>();
            //service.Setup(s => s.GetValue_ByID(It.IsAny<int>())).Returns(new Value() { Name = "value" + 5 });
            service.Setup(s => s.GetValue_ByID(It.IsAny<int>())).Returns<IValue>(null);
            ValuesController controller = new ValuesController(service.Object);

            // Act
            string result = controller.Get(5);

            // Assert
            Assert.IsNull(result);
        }

        //TODO Needs Service mocking!
        //[TestMethod]
        //public void Post()
        //{
        //    // Arrange
        //    ValuesController controller = new ValuesController();

        //    // Act
        //    controller.Post("value");

        //    // Assert
        //}


        //TODO Needs Service mocking!
        //[TestMethod]
        //public void Put()
        //{
        //    // Arrange
        //    ValuesController controller = new ValuesController();

        //    // Act
        //    controller.Put(5, "value");

        //    // Assert
        //}

        [TestMethod]
        public void Delete_RemovesItem()
        {
            // Arrange
            var service = new Mock<IAPIService>();
            service.Setup(s => s.DeleteValue(5)).Verifiable();
            ValuesController controller = new ValuesController(service.Object);

            // Act
            controller.Delete(5);

            // Assert
            service.Verify();
        }
    
    }
}
