using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDB.ComputerWorld.BL.Models
{
    public enum EquipmentTypes
    {
        Server = 0,
        Desktop,
        Laptop,
        Printer,
        Tablet,
        OfficeChair,
        LawnChair,
        LightBulb,
        Widget
    }

    public class EquipmentType
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


    }
}
