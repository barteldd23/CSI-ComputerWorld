using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDB.ComputerWorld.BL.Models
{
    public class Application
    {
		private int id;
        #region "Properties"
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

		private double size;

		public double Size
		{
			get { return size; }
			set { size = value; }
		}
        #endregion



    }
}
