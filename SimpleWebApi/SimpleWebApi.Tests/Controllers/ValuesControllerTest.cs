using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleWebApi;
using SimpleWebApi.Controllers;

namespace SimpleWebApi.Tests.Controllers
{
    [TestClass]
    public class ValuesControllerTest
    {
        [TestMethod]
        public void Get_ReturnsItemsPosted()
        {
            // Arrange
            ValuesController controller = new ValuesController();
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
            ValuesController controller = new ValuesController();
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
            ValuesController controller = new ValuesController();

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
            ValuesController controller = new ValuesController();
            controller.Put(5,"value");

            // Act
            controller.Delete(5);

            // Assert
            Assert.IsNull(controller.Get(5));
        }
    
    }
}
