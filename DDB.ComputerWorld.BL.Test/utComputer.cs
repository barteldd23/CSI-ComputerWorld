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
    }
}