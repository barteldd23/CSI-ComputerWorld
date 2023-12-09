using DDB.ComputerWorld.BL.Models;
using DDB.Utility.PL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

        public static List<Computer> REadDB()
        {
            try
            {
                Database db = new Database();
                DataTable data = new DataTable();

                string sql = "Select * from tblComputer";
                SqlCommand command = new SqlCommand(sql);

                data = db.Select(command);

                if (data.Rows.Count == 0)
                    throw new Exception("Row does not exist.");

                List<Computer> computers = new List<Computer>();
                foreach(DataRow dr in data.Rows)
                {
                    Computer computer = new Computer();
                    computer.Id = Convert.ToInt32(dr["ID"]);
                    computer.Model = dr["Model"].ToString();
                    computer.Cost = Convert.ToDouble(dr["Cost"]);
                    computer.HardDriveSize = Convert.ToInt32(dr["HardDriveSize"]);
                    computer.Memory = Convert.ToDouble(dr["Memory"]);
                    computer.EquipmentType = (EquipmentTypes)Convert.ToInt32(dr["EquipmentType"]);
                    computer.Processor = dr["Processor"].ToString();

                    computer.Applications = ApplicationManager.ReadDb(computer.Id);

                    computers.Add(computer);
                }

                

                return computers;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static Computer REadDB(int id)
        {
            try
            {
                Database db = new Database();
                DataTable data = new DataTable();

                string sql = "Select * from tblComputer where id = @Id";
                SqlCommand command = new SqlCommand(sql);
                command.Parameters.AddWithValue("@Id", id);

                data = db.Select(command);

                if (data.Rows.Count == 0)
                    throw new Exception("Row does not exist.");

                DataRow dr = data.Rows[0];

                Computer computer = new Computer();
                computer.Id = Convert.ToInt32(dr["ID"]);
                computer.Model = dr["Model"].ToString();
                computer.Cost = Convert.ToDouble(dr["Cost"]);
                computer.HardDriveSize = Convert.ToInt32(dr["HardDriveSize"]);
                computer.Memory = Convert.ToDouble(dr["Memory"]);
                computer.EquipmentType = (EquipmentTypes)Convert.ToInt32(dr["EquipmentType"]);
                computer.Processor = dr["Processor"].ToString();

                computer.Applications = ApplicationManager.ReadDb(computer.Id);

                return computer;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int Insert(Computer computer, bool rollback = false)
        {
            try
            {
                Database db = new Database();
                DataTable data = new DataTable();

                string sql = "insert into tblComputer (Id, Manufacturer, Memory, Model, EquipmentType, Cost,";
                sql += " HardDrivesize, Processor)";
                sql += " Values (@Id, @manufacturer, @memory, @model, @equipementtype, @cost, @harddrivesize, @processor)";

                SqlCommand command = new SqlCommand(sql);
                command.Parameters.AddWithValue("@Id", computer.Id);
                command.Parameters.AddWithValue("@manufacturer", computer.Manufacturer);
                command.Parameters.AddWithValue("@memory", computer.Memory);
                command.Parameters.AddWithValue("@model", computer.Model);
                command.Parameters.AddWithValue("@equipementtype", computer.EquipmentType);
                command.Parameters.AddWithValue("@cost", computer.Cost);
                command.Parameters.AddWithValue("@harddrivesize", computer.HardDriveSize);
                command.Parameters.AddWithValue("@processor", computer.Processor);

                int iRows = db.Insert(command, rollback);

                if(computer.Applications != null)
                {
                    foreach(Application application in computer.Applications)
                    {
                        iRows += ApplicationManager.Insert(application, rollback);
                    }
                }

                return iRows;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int Update(Computer computer, int maxId, bool rollback = false)
        {
            try
            {
                Database db = new Database();
                DataTable data = new DataTable();

                string sql = "update tblComputer Set Manufacturer = @manufacturer, Memory = @memory, " +
                                                    "Model = @model, EquipmentType = @equipementtype, " +
                                                    "Cost = @cost, HardDrivesize = @harddrivesize, " +
                                                    "Processor = @processor " +
                                                    "Where Id = @Id";

                SqlCommand command = new SqlCommand(sql);
                command.Parameters.AddWithValue("@Id", computer.Id);
                command.Parameters.AddWithValue("@manufacturer", computer.Manufacturer);
                command.Parameters.AddWithValue("@memory", computer.Memory);
                command.Parameters.AddWithValue("@model", computer.Model);
                command.Parameters.AddWithValue("@equipementtype", computer.EquipmentType);
                command.Parameters.AddWithValue("@cost", computer.Cost);
                command.Parameters.AddWithValue("@harddrivesize", computer.HardDriveSize);
                command.Parameters.AddWithValue("@processor", computer.Processor);

                int iRows = db.Insert(command, rollback);

                ApplicationManager.DeleteByParentId(computer.Id, rollback);

                if (computer.Applications != null)
                {
                    foreach (Application application in computer.Applications)
                    {
                        application.Id = ++maxId;

                        iRows += ApplicationManager.Insert(application, rollback);
                    }
                }

                return iRows;

            }
            catch (Exception)
            {

                throw;
            }
        }



    }
}
