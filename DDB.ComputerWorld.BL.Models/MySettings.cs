using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDB.ComputerWorld.BL.Models
{
    public class MySettings
    {
        private string text;

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        private Color backColor;

        public Color BackColor
        {
            get { return backColor; }
            set { backColor = value; }
        }

        private string computerFileName;

        public string ComputerFileName
        {
            get { return computerFileName; }
            set { computerFileName = value; }
        }

        private string applicationFileName;

        public string ApplicationFileName
        {
            get { return applicationFileName; }
            set { applicationFileName = value; }
        }

        private string computerXMLFileName;

        public string ComputerXMLFileName
        {
            get { return computerXMLFileName; }
            set { computerXMLFileName = value; }
        }



    }
}
