using Microsoft.VisualStudio.TestTools.UnitTesting;
using DDB.ComputerWorld.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDB.ComputerWorld.BL.Models;

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

        [TestMethod]
        public void WriteTest()
        {
            List<Application> applications = new List<Application>();
            applications.Add(new Application { Id =1, Name = "Me", ParentId = -1, Size =4});

            Assert.IsTrue(ApplicationManager.Write(applications, "file.txt"));
        }

        [TestMethod]
        public void ReadTest()
        {
            int expected = 5;
            int actual = ApplicationManager.Read("applications.txt").Count;
            Assert.AreEqual(expected, actual);
        }

    }

    
}