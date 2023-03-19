using Business.Models;
using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Assert = NUnit.Framework.Assert;

namespace SRRTests
{
    [TestClass]
    public class HollowClassificationTest
    {
        [TestMethod]
        public void AddingShouldWork()
        {
            var data = new List<HollowClassification>
            {
                new HollowClassification {Name = "aaaa", Description = "a"},
                new HollowClassification {Name = "bbbb", Description= "b"},
                new HollowClassification {Name = "cccc", Description= "c"},
            }.AsQueryable();

            var mockSet = new Mock<DbSet<HollowClassification>>();
            mockSet.As<IQueryable<HollowClassification>>().Setup(hc => hc.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<HollowClassification>>().Setup(hc => hc.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<HollowClassification>>().Setup(hc => hc.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<HollowClassification>>().Setup(hc => hc.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<SRRContext>();
            mockContext.Setup(c => c.HollowClassification).Returns(mockSet.Object);

            var controller = new HCBusiness(mockContext.Object);
            data.ToList().ForEach(h => controller.Add(h));

            var hc = controller.Get(1);
            Assert.AreEqual("aaaa", hc.Name);





        }
    }
}
