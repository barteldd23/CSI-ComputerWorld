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

        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(7, ApplicationManager.ReadDb().Count);
        }

        [TestMethod]
        public void LoadByParentIdTest()
        {
            Assert.AreEqual(3, ApplicationManager.ReadDb(1).Count);
            Assert.AreEqual(4, ApplicationManager.ReadDb(2).Count);
        }

        [TestMethod]
        public void InsertTest()
        {
            Application application = new Application
            {
                Id = -1,
                Name = "Outlook",
                ParentId = 2,
                Size = 4
            };

            Assert.AreEqual(1, ApplicationManager.Insert(application, true));
        }

        [TestMethod]
        public void UpdateTest()
        {
            
        }

        [TestMethod]
        public void DeleteTest()
        {
            Assert.AreEqual(1, ApplicationManager.Delete(1, true));
        }

        [TestMethod]
        public void DeleteByParentIdTest()
        {
            Assert.AreEqual(4, ApplicationManager.DeleteByParentId(2, true));
        }

    }

    
}