using DDB.ComputerWorld.BL.Models;
using System;
using System.Collections.Generic;
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
    }
}
