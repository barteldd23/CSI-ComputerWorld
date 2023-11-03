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
    public enum ScreenMode
    {
        Add = 0,
        Edit
    }

    public partial class frmApplication : Form
    {
        private ScreenMode screenMode;
        private Computer computer;

        public Computer Computer
        {
            get { return computer; }
            set { computer = value; }
        }


        private int applicationId;

        public int ApplicationId
        {
            get { return applicationId; }
            set { applicationId = value; }
        }

        public frmApplication(ScreenMode screenMode)
        {
            InitializeComponent();
            this.screenMode = screenMode;
            this.Text = screenMode.ToString() + " application" ;
        }

        private void frmApplication_Load(object sender, EventArgs e)
        {
            if(screenMode == ScreenMode.Edit) 
            {
                txtName.Text = computer.Applications[applicationId].Name;
                txtSize.Text = computer.Applications[applicationId].Size.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(screenMode == ScreenMode.Add)
                {
                    DDB.ComputerWorld.BL.Models.Application application = new DDB.ComputerWorld.BL.Models.Application();

                    // Ternary operation
                    application.Id = computer.Applications.Any() ? computer.Applications.Max(a => a.Id) + 1 : 1;

                    application.Name = txtName.Text;
                    application.Size = double.Parse(txtSize.Text);
                    application.ParentId = computer.Id;

                    computer.Applications.Add(application);
                }
                else if(screenMode == ScreenMode.Edit)
                {
                    computer.Applications[applicationId].Name = txtName.Text;
                    computer.Applications[applicationId].Size = double.Parse(txtSize.Text);
                }


                this.Close();

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
