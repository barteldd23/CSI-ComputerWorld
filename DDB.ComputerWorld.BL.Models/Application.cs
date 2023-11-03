using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DDB.ComputerWorld.BL.Models
{
    public class Application
    {
        const string DELIM = "|";

		private int id;
        #region "Properties"
        public int Id
		{
			get { return id; }
			set { id = value; }
		}

		private int parentId;

		public int ParentId
		{
			get { return parentId; }
			set { parentId = value; }
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

        public string DataFormat
        {
            get
            {
				return Id + DELIM
					+ parentId + DELIM 
					+ name + DELIM
					+ size.ToString();
            }
        }
        #endregion



    }
}
