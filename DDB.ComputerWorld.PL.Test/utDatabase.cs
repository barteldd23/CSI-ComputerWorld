using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDB.ComputerWorld.PL.Test
{
    [TestClass]
    public class utDatabase
    {
        [TestMethod]
        public void OpenTest()
        {
            Database database = new Database();
            ConnectionState actual = database.Open();
            database.Close();
            Assert.AreEqual(ConnectionState.Open, actual);
        }

        [TestMethod]
        public void CloseTest()
        {
            Database database = new Database();
            database.Open();
            ConnectionState actual = database.Close();
            database.Close();
            Assert.AreEqual(ConnectionState.Closed, actual);
        }

        [TestMethod]
        public void SelectEquipmentTypes()
        {
            Database database = new Database();
            string sql = "SELECT * FROM tblEquipmentType";

            SqlCommand sqlCommand = new SqlCommand(sql);
            DataTable dataTable = database.Select(sqlCommand);

            int expected = 9;
            int actual = dataTable.Rows.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertTest()
        {
            Database database = new Database();
            SqlCommand sqlCommand = new SqlCommand();

            int id = -1;
            string name = "Screwdrivers";

            sqlCommand.CommandText = "Insert into tblEquipmentType values (@Id, @Name)";
            sqlCommand.Parameters.AddWithValue("@Id", id);
            sqlCommand.Parameters.AddWithValue("@Name", name);

            int expected = 1;
            int actual = database.Insert(sqlCommand, true);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Database database = new Database();
            SqlCommand sqlCommand = new SqlCommand();

            int id = 5;
            string name = "New Name";

            sqlCommand.CommandText = "Update tblEquipmentType set Name = @Name where Id = @Id";
            sqlCommand.Parameters.AddWithValue("@Id", id);
            sqlCommand.Parameters.AddWithValue("@Name", name);

            int expected = 1;
            int actual = database.Update(sqlCommand, true);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Database database = new Database();
            SqlCommand sqlCommand = new SqlCommand();

            int id = 5;

            sqlCommand.CommandText = "Delete tblEquipmentType where Id = @Id";
            sqlCommand.Parameters.AddWithValue("@Id", id);

            int expected = 1;
            int actual = database.Update(sqlCommand, true);

            Assert.AreEqual(expected, actual);
        }
    }
}
