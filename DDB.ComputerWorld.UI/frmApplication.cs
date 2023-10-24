using DDB.ComputerWorld.BL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDB.ComputerWorld.UI
{
    public partial class frmApplication : Form
    {
        private Computer computer;

        public Computer Computer
        {
            get { return computer; }
            set { computer = value; }
        }


        public frmApplication()
        {
            InitializeComponent();
        }

        private void frmApplication_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DDB.ComputerWorld.BL.Models.Application application = new DDB.ComputerWorld.BL.Models.Application();

            // Ternary operation
            application.Id = computer.Applications.Any() ? computer.Applications.Max(a => a.Id) + 1 : 1;

            application.Name = txtName.Text;
            application.Size = double.Parse(txtSize.Text);

            computer.Applications.Add(application);
            this.Close();
        }
    }
}
