using DDB.ComputerWorld.BL.Models;
using DDB.Utility.PL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDB.ComputerWorld.BL
{
    public static class ApplicationManager
    {
        public static List<Application> Populate(int computerId)
        {
            List<Application> list = new List<Application>();

            switch (computerId)
            {
                case 1:
                    list.Add(new Application { Id = 1, ParentId = computerId, Name = "Google Chrome", Size = 100 });
                    list.Add(new Application { Id = 2, ParentId = computerId, Name = "Visual Studio", Size = 150.25 });
                    list.Add(new Application { Id = 3, ParentId = computerId, Name = "Steam", Size = 275 });
                    break;
                case 2:
                    list.Add(new Application { Id = 4, ParentId = computerId, Name = "Microsoft Word", Size = 100.6 });
                    list.Add(new Application { Id = 5, ParentId = computerId, Name = "Visual Studio Code", Size = 50 });
                    break;

            }

            return list;
        }

        public static void DeleteDataFile(string filePath)
        {
            FileIO.Delete(filePath);
        }

        public static bool Write(List<Application> applications, string filename)
        {
            try
            {
                foreach(Application app in applications)
                {
                    FileIO.Write(filename, app.DataFormat);
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<Application> Read(string filePath)
        {
            try
            {
                // Read all the data from the flat file.
                string contents = FileIO.Read(filePath);

                List<Application> applications = new List<Application>();

                // Create an array of line rows of type string
                // split by carriage return and line feed
                string[] separators = new string[] { "\r\n" };
                string[] rows = contents.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                foreach (string row in rows)
                {
                    string[] dataRow = row.Split('|');

                    Application application = new Application
                    {
                        Id = int.Parse(dataRow[0]),
                        ParentId = int.Parse(dataRow[1]),
                        Name = dataRow[2],
                        Size = double.Parse(dataRow[3])
                    };

                    applications.Add(application);

                }
                return applications;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
