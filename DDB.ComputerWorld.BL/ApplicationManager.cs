using DDB.ComputerWorld.BL.Models;
using DDB.Utility.PL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

        public static List<Application> ReadDb()
        {
            try
            {
                List<Application> applications = new List<Application>();
                Database db = new Database();
                DataTable dt = new DataTable();

                string sql = "Select * from tblApplication";
                SqlCommand sqlCommand = new SqlCommand(sql);
                dt = db.Select(sqlCommand);

                foreach(DataRow dr in dt.Rows)
                {
                    Application application = new Application();
                    application.Id = Convert.ToInt32(dr["Id"]);
                    application.Name = dr["Name"].ToString();
                    application.Size = Convert.ToDouble(dr["Size"]);

                    applications.Add((application));
                }
                return applications;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<Application> ReadDb(int parentId)
        {
            try
            {
                List<Application> applications = new List<Application>();
                Database db = new Database();
                DataTable dt = new DataTable();

                string sql = "Select * from tblApplication where ParentId = @parentId";
                SqlCommand sqlCommand = new SqlCommand(sql);
                sqlCommand.Parameters.AddWithValue("@parentId", parentId);
                dt = db.Select(sqlCommand);

                foreach (DataRow dr in dt.Rows)
                {
                    Application application = new Application();
                    application.Id = Convert.ToInt32(dr["Id"]);
                    application.Name = dr["Name"].ToString();
                    application.Size = Convert.ToDouble(dr["Size"]);
                    application.ParentId = Convert.ToInt32(dr["ParentId"]);

                    applications.Add((application));
                }
                return applications;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static Application ReadDb(short id)
        {
            try
            {
                Database db = new Database();
                DataTable dt = new DataTable();

                string sql = "Select * from tblApplication where Id = @Id";
                SqlCommand sqlCommand = new SqlCommand(sql);
                sqlCommand.Parameters.AddWithValue("@Id", id);
                dt = db.Select(sqlCommand);

                Application application = new Application();

                foreach (DataRow dr in dt.Rows)
                {
                    application.Id = Convert.ToInt32(dr["Id"]);
                    application.Name = dr["Name"].ToString();
                    application.Size = Convert.ToDouble(dr["Size"]);
                    application.ParentId = Convert.ToInt32(dr["ParentId"]);

                }
                return application;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int Insert(Application application, bool rollback = false)
        {
            try
            {
                Database db = new Database();
                SqlCommand sqlCommand = new SqlCommand();

                string sql = "Insert into tblApplication (Id, Name, ParentId, Size)";
                sql += " Values (@Id, @Name, @ParentId, @Size)";

                sqlCommand.CommandText = sql;
                sqlCommand.Parameters.AddWithValue("@Id", application.Id);
                sqlCommand.Parameters.AddWithValue("@Name", application.Name);
                sqlCommand.Parameters.AddWithValue("@ParentId", application.ParentId);
                sqlCommand.Parameters.AddWithValue("@Size", application.Size);

                int results = db.Insert(sqlCommand, rollback);
                return results;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int Update(Application application, bool rollback = false)
        {
            try
            {
                Database db = new Database();
                SqlCommand sqlCommand = new SqlCommand();

                string sql = "Update into tblApplication set Name = @Name, " +
                              "ParentId = @ParentId, " +
                              "Size = @Size " +
                              "Where Id = @Id";

                sqlCommand.CommandText = sql;
                sqlCommand.Parameters.AddWithValue("@Id", application.Id);
                sqlCommand.Parameters.AddWithValue("@Name", application.Name);
                sqlCommand.Parameters.AddWithValue("@ParentId", application.ParentId);
                sqlCommand.Parameters.AddWithValue("@Size", application.Size);

                int results = db.Update(sqlCommand, rollback);
                return results;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int Delete(int id, bool rollback = false)
        {
            try
            {
                Database db = new Database();
                SqlCommand sqlCommand = new SqlCommand();

                string sql = "Delete from tblApplication where Id = @Id";

                sqlCommand.CommandText = sql;
                sqlCommand.Parameters.AddWithValue("@Id", id);

                int results = db.Delete(sqlCommand, rollback);
                return results;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int DeleteByParentId(int parentId, bool rollback = false)
        {
            try
            {
                Database db = new Database();
                SqlCommand sqlCommand = new SqlCommand();

                string sql = "Delete from tblApplication where ParentId = @ParentId";

                sqlCommand.CommandText = sql;
                sqlCommand.Parameters.AddWithValue("@ParentId", parentId);

                int results = db.Delete(sqlCommand, rollback);
                return results;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
