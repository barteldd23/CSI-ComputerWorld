using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDB.ComputerWorld.BL.Models
{
    public class Computer : Equipment //Means inherit Equipment Class. Can only inherit from 1 class
    {
        #region "Properties"
        

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

        private List<Application> applications;

        public List<Application> Applications
        {
            get { return applications; }
            set { applications = value; }
        }

        // Make a calculated Field
        // to combine info
        public string Information
        {
            get
            {
                return this.Manufacturer + " " + Model + " " + Cost.ToString("C");
            }
        }









        #endregion

    }
}
