using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xenon.Utility.Filters;
using System.Collections.Generic;

namespace Xenon.Utility.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestFilters()
        {
            Car[] cars = new Car[] 
            {
                new Test.Car() { Make = "Honda", Model = "Civic", Id = Guid.NewGuid() },
                new Test.Car() { Make = "Chevy", Model = "Cobalt", Id = Guid.NewGuid() }
            };
            Filter filter = Filter.Create("cars", "cars", cars, "Make", "Id");
        }
    }
}
