using DDB.Utility.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDB.ComputerWorld.BL.Models
{
    public class HardDriveNegativeException : Exception
    {
        // constructor number 1
        public HardDriveNegativeException() :base("Hard Drive cannot be negative")
        { 

        }

        // constructor number 2
        public HardDriveNegativeException(string message) : base(message)
        {

        }
    }

    // :Equipment Means INHERIT Equipment Class. Can only inherit from 1 class
    // ,IComputer means IMPLEMENT the interface
    public class Computer : Equipment, IComputer 
    {
        const string DELIM = "|";
        public Computer()
        {
            Applications = new List<Application>();
        }

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
            set 
            { 
                if(value < 0)
                {
                    // Throw a non-custom error
                    //throw new Exception("Hard Drive Negative");

                    //throw new HardDriveNegativeException();
                    throw new HardDriveNegativeException("Invalid Hard Drive Size. Must be Positive.");
                }
                else
                {
                    hardDriveSize = value;
                }
                
            }
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

        public string DataFormat
        {
            get
            {
                return Id + DELIM 
                    + Manufacturer + DELIM 
                    + Model + DELIM 
                    + Cost + DELIM 
                    + HardDriveSize + DELIM 
                    + Memory + DELIM 
                    + Processor + DELIM 
                    + (int)EquipmentType;
            }
        }

        public bool Write()
        {
            throw new NotImplementedException();
        }

        public int DoIt(string userId)
        {
            throw new NotImplementedException();
        }









        #endregion

    }
}
