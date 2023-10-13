using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDB.ComputerWorld.BL.Models
{
    public class Computer
    {
        #region "Properties"
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

        private string model;

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        private double memory;

        public double Memory
        {
            get { return memory; }
            set { memory = value; }
        }

        private int hardDriveSize;

        public int HardDriveSize
        {
            get { return hardDriveSize; }
            set { hardDriveSize = value; }
        }

        private string processor;

        public string Processor
        {
            get { return processor; }
            set { processor = value; }
        }

        private double cost;

        public double Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        private List<Application> applications;

        public List<Application> Applications
        {
            get { return applications; }
            set { applications = value; }
        }









        #endregion

    }
}
