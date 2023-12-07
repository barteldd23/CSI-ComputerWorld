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
    public class EquipmentTypeManagerTests
    {
        [TestMethod()]
        public void PopulateTest()
        {
            var items = EquipmentTypeManager.Populate();
            Assert.AreEqual(9, items.Count);
            Assert.AreEqual(EquipmentTypes.Printer.ToString(), items[3].Name);
            Assert.AreEqual((int)EquipmentTypes.Printer, items[3].Id);
        }

        [TestMethod]
        public void ReadDbTest()
        {
            int actual = EquipmentTypeManager.ReadDb().Count;
            Assert.AreEqual(9, actual);
        }
    }

    
}