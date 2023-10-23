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
    }
}