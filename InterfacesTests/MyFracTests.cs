using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Tests
{
    [TestClass]
    public class MyFracTests
    {
        [TestMethod]
        public void AddTest1()
        {
            var f1 = new MyFrac("1/30");
            var f2 = new MyFrac("3/25");

            var res = f1+f2;
            Assert.AreEqual(new MyFrac("23/150"), res);
        }
    }
}