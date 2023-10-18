using Microsoft.VisualStudio.TestTools.UnitTesting;
using DDB.ComputerWorld.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDB.ComputerWorld.BL.Test
{
    [TestClass()]
    public class ApplicationManagerTests
    {
        [TestMethod()]
        public void PopulateTest()
        {
            int expected = 2;
            int actual = ApplicationManager.Populate(2).Count;
            Assert.AreEqual(expected, actual);
        }
    }
}