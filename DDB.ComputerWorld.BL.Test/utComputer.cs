using DDB.ComputerWorld.BL.Models;

namespace DDB.ComputerWorld.BL.Test
{
    [TestClass]
    public class utComputer
    {
        [TestMethod]
        public void PopulateTest()
        {
            int expected = 2;
            List<Computer> items = ComputerManager.Populate();
            int actual = items.Count;
            Assert.AreEqual(expected,actual);
            Assert.IsTrue(items[0].Applications.Count == 3);
            Assert.IsTrue(items[1].Applications.Count == 2);
        }

        [TestMethod]
        public void HardDrivePositiveTest()
        {
            Computer computer = new Computer { HardDriveSize = 10 };

            Assert.AreEqual(10, computer.HardDriveSize);
        }

        [TestMethod]
        public void HardDriveNegativeTest()
        {
            try
            {
                Computer computer = new Computer { HardDriveSize = -10 };

                Assert.AreEqual(-10, computer.HardDriveSize);
            }

            catch (HardDriveNegativeException)
            {
                // If i got here, it handled the negative correctly.
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                // Error thrown but not correct.
                Assert.Fail();
            }
        }

        [TestMethod]
        public void WriteTest()
        {
            List<Computer> computers = ComputerManager.Populate();

            bool results = ComputerManager.Write(computers, "computers.txt");
            Assert.IsTrue(results);
        }

        [TestMethod]
        public void WriteXMLTest()
        {
            List<Computer> items = ComputerManager.Populate();

            bool results = ComputerManager.WriteXML(items, "computers.xml");
            Assert.IsTrue(results);
        }

        [TestMethod]
        public void ReadTest()
        {
            List<Computer> computers = ComputerManager.Read("computers.txt", "applications.txt");
            Assert.AreEqual(computers.Count, 2);
            Assert.AreEqual(computers[0].Applications.Count, 3);
            Assert.AreEqual(computers[1].Applications.Count, 2);
        }

        [TestMethod]
        public void ReadXMLTest()
        {
            List<Computer> computers = ComputerManager.ReadXML("computers.xml");
            Assert.AreEqual(computers.Count, 2);
            Assert.AreEqual(computers[0].Applications.Count, 3);
            Assert.AreEqual(computers[1].Applications.Count, 2);
        }

        [TestMethod]
        public void ReadDbByIdTest()
        {
            Computer computer = ComputerManager.REadDB(1);
            Assert.AreEqual(computer.Model, "6100");
            Assert.AreEqual(computer.Applications.Count, 3);
        }

        [TestMethod]
        public void ReadDbTest()
        {
            List<Computer> computers = ComputerManager.REadDB();
            Assert.AreEqual(computers.Count, 2);
            Assert.AreEqual(computers[0].Applications.Count, 3);
            Assert.AreEqual(computers[1].Applications.Count, 4);
        }

        [TestMethod]
        public void InsertTest()
        {
            Computer computer = new Computer();
            computer.Id = 99;
            computer.Manufacturer = "Test";
            computer.Model = "Test";
            computer.Cost = 999;
            computer.Processor = "Test";
            computer.HardDriveSize = 123;
            computer.EquipmentType= EquipmentTypes.OfficeChair;

            List<Application> applications = ApplicationManager.ReadDb();
            int newid = applications.Max(app => app.Id) + 1;

            computer.Applications.Add(new Application
            {
                Id = newid,
                Name = "Outlook",
                Size = 25,
                ParentId = computer.Id
            });

            Assert.AreEqual(ComputerManager.Insert(computer, true), 2);
        }
    }
}