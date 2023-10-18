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

                // Add Applications - Wrong Way - do not do.
                //computer1.Applications = new List<Application>();
                //computer1.Applications.Add(new Application { Id = 1, Name = "Google Chrome", Size = 100});
                //computer1.Applications.Add(new Application { Id = 2, Name = "Visual Studio", Size = 150.25 });
                //computer1.Applications.Add(new Application { Id = 3, Name = "Steam", Size = 275 });


                // Correct Way - have a Populate / load in ApplicationManager
                computer1.Applications = ApplicationManager.Populate(computer1.Id);

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

                computer2.Applications = ApplicationManager.Populate(computer2.Id);

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
