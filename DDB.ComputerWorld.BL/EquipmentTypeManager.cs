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
    public static class EquipmentTypeManager
    {
        public static List<EquipmentType> Populate()
        {
            List<EquipmentType> equipmentTypes = new List<EquipmentType>();

            string[] types = Enum.GetNames(typeof(EquipmentTypes));

            //int intcount = 0;
            foreach (string type in types)
            {
                int id = (int)Enum.Parse(typeof(EquipmentTypes), type);
                string name = Enum.Parse(typeof(EquipmentTypes), type).ToString();

                // add a newly populated object to the list
                equipmentTypes.Add(new EquipmentType { Id = id, Name = name });
            }

            return equipmentTypes;
        }

        public static List<EquipmentType> ReadDb()
        {
            try
            {
                List<EquipmentType> equipmentTypes = new List<EquipmentType>();
                Database database = new Database();
                DataTable dataTable = new DataTable();

                string sql = "Select * from tblEquipmentType";
                SqlCommand sqlCommand = new SqlCommand(sql);

                dataTable = database.Select(sqlCommand);

                foreach (DataRow row in dataTable.Rows)
                {
                    EquipmentType equipmentType = new EquipmentType();
                    equipmentType.Id = Convert.ToInt32(row["Id"]);
                    equipmentType.Name = row["Name"].ToString();
                    equipmentTypes.Add(equipmentType);
                }

                return equipmentTypes;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }

   
}
