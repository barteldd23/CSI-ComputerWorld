using DDB.ComputerWorld.BL.Models;
using DDB.Utility.PL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

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
                    Processor = "CGX1001",
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


        public static List<Computer> Read(string filePath, string applicationsfilepath)
        {
            try
            {
                // Read all the data from the flat file.
                string contents = FileIO.Read(filePath);

                List<Application> applications = ApplicationManager.Read(applicationsfilepath);

                List<Computer> computers = new List<Computer>();

                // Create an array of line rows of type string
                // split by carriage return and line feed
                string[] separators = new string[] { "\r\n" };
                string[] rows = contents.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                foreach (string row in rows)
                {
                    string[] dataRow = row.Split('|');

                    Computer computer = new Computer
                    {
                        Id = int.Parse(dataRow[0]),
                        Manufacturer = dataRow[1],
                        Model = dataRow[2],
                        Cost = double.Parse(dataRow[3]),
                        HardDriveSize = int.Parse(dataRow[4]),
                        Memory = double.Parse(dataRow[5]),
                        Processor = dataRow[6],
                        EquipmentType = (EquipmentTypes)(int.Parse(dataRow[7]))
                    };

                    // Get all of this computer's applications.
                    computer.Applications = applications.Where(a => a.ParentId == computer.Id).ToList();

                    computers.Add(computer);

                }
                return computers;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<Computer> ReadXML(string xmlfilepath)
        {
            try
            {
                List<Computer> computers = new List<Computer>();
                XmlSerializer serializer = new XmlSerializer(typeof(List<Computer>));

                TextReader reader = new StreamReader(xmlfilepath);

                computers.AddRange((List<Computer>)serializer.Deserialize(reader));

                reader.Close();
                reader = null;
                serializer = null;
                return computers;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static bool Write(List<Computer> computers, string filePath)
        {
            try
            {
                FileIO.Delete(filePath);
                foreach(Computer computer in computers)
                {
                    FileIO.Write(filePath, computer.DataFormat);
                    
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool WriteXML(List<Computer> computers, string filePath)
        {
            try
            {
                FileIO.Delete(filePath);

                XmlSerializer serializer = new XmlSerializer(typeof(List<Computer>));
                TextWriter writer = new StreamWriter(filePath);
                serializer.Serialize(writer, computers);
                writer.Close();
                writer = null;
                serializer = null;
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
