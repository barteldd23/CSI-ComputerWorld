using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDB.ComputerWorld.BL.Models
{
    public abstract class Equipment
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string manufacturer;

        public string Manufacturer
        {
            get { return manufacturer; }
            set { manufacturer = value; }
        }

        private double cost;

        public double Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        private EquipmentTypes equipmentType;

        public EquipmentTypes EquipmentType
        {
            get { return equipmentType; }
            set { equipmentType = value; }
        }

    }
}
