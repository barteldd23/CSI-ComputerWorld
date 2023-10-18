using DDB.ComputerWorld.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDB.ComputerWorld.BL
{
    public static class ComputerManager
    {
        public static List<Computer> Populate()
        {
            try
            {
                List<Computer> computers = new List<Computer>();

                // Make computer 1
                Computer computer1 = new Computer();
                computer1.Id = 1;
                computer1.Manufacturer = "Dell";
                computer1.Model = "6100";
                computer1.Cost = 399.99;
                computer1.HardDriveSize = 2048;
                computer1.Memory = 32.5;
                computer1.Processor = "CGX1000";
                computer1.EquipmentType = EquipmentTypes.Laptop;
                computers.Add(computer1);

                // Make computer 2
                Computer computer2 = new Computer
                {
                    Id = 2,
                    Manufacturer = "HP",
                    Model = "6200",
                    Cost = 599.99,
                    HardDriveSize = 4196,
                    Memory = 64,
                    EquipmentType = EquipmentTypes.Desktop
                };

                computers.Add(computer2);

                // Return List back
                return computers;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
