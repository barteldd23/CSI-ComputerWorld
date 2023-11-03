using DDB.ComputerWorld.BL;
using DDB.ComputerWorld.BL.Models;
using Microsoft.Extensions.Configuration;

namespace DDB.ComputerWorld.UI
{
    public partial class frmComputerWorld : Form
    {
        List<Computer> computers;
        List<EquipmentType> equipmentTypes;
        MySettings settings;
        public frmComputerWorld()
        {
            InitializeComponent();
        }

        private void frmComputerWorld_Load(object sender, EventArgs e)
        {

            try
            {
                settings = Program.Configuration.GetSection("MySettings").Get<MySettings>();

                this.Text = settings.Text;
                this.BackColor = settings.BackColor;


                lblStatus.ForeColor = Color.Black;
                //computers = ComputerManager.Populate();
                computers = ComputerManager.Read(settings.ComputerFileName, settings.ApplicationFileName);
                equipmentTypes = EquipmentTypeManager.Populate();

                cbxEquipmentType.DataSource = equipmentTypes;
                cbxEquipmentType.DisplayMember = "Name";
                cbxEquipmentType.ValueMember = "Id";

                Refresh();
            }
            catch (Exception ex)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = ex.Message;
                throw;
            }
        }

        private void Refresh()
        {
            lbxEquipment.DataSource = null;
            lbxEquipment.DataSource = computers;
            lbxEquipment.DisplayMember = "Information";
            lbxEquipment.ValueMember = "Id";

        }

        private void lbxEquipment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblStatus.ForeColor = Color.Black;
                lblStatus.Text = string.Empty;

                // Check to see if something is selected
                if (lbxEquipment.SelectedIndex >= 0)
                {
                    // Get the computer that is selected
                    Computer computer = computers[lbxEquipment.SelectedIndex];


                    // Display Property values
                    txtManufacturer.Text = computer.Manufacturer;
                    txtModel.Text = computer.Model;
                    txtCost.Text = computer.Cost.ToString("N2");
                    txtMemory.Text = computer.Memory.ToString();
                    txtHardDriveSize.Text = computer.HardDriveSize.ToString();
                    txtProcessor.Text = computer.Processor;

                    cbxEquipmentType.SelectedIndex = (int)computer.EquipmentType;

                    //Show the applications for this computer
                    RefreshApplications(computer.Applications);

                }

            }
            catch (Exception ex)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = ex.Message;
            }
        }

        private void RefreshApplications(List<BL.Models.Application> applications)
        {
            // Show the applications for this computer.
            dgvChildren.DataSource = null;
            dgvChildren.DataSource = applications;
            dgvChildren.Columns[0].Visible = false;
            dgvChildren.Columns[1].Visible = false;

            dgvChildren.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvChildren.Columns[3].DefaultCellStyle.Format = "C";

            dgvChildren.Columns[4].Visible = false;
        }

        private void btnMakeComputer_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.ForeColor = Color.Black;
                lblStatus.Text = string.Empty;

                Computer computer = new Computer();
                computer.Id = computers.Count + 1;
                SetProperties(computer);

                computers.Add(computer);
                Refresh();

            }
            catch (Exception ex)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = ex.Message;
            }
        }

        private void SetProperties(Computer computer)
        {
            try
            {
                computer.Manufacturer = txtManufacturer.Text;
                computer.Model = txtModel.Text;
                computer.Processor = txtProcessor.Text;
                computer.HardDriveSize = Convert.ToInt32(txtHardDriveSize.Text);
                computer.Cost = Convert.ToDouble(txtCost.Text);
                computer.Memory = Convert.ToDouble(txtMemory.Text);
                computer.EquipmentType = (EquipmentTypes)cbxEquipmentType.SelectedIndex;
            }
            catch (Exception ex)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = ex.Message;
            }
        }

        private void btnFakeData_Click(object sender, EventArgs e)
        {
            txtCost.Text = "1243.50";
            txtHardDriveSize.Text = "2345";
            txtModel.Text = "NewModel";
            txtManufacturer.Text = "MyManufacturer";
            txtMemory.Text = "123";
            txtProcessor.Text = "567";
            cbxEquipmentType.SelectedIndex = 3;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.ForeColor = Color.Black;
                lblStatus.Text = string.Empty;

                Computer computer = computers[lbxEquipment.SelectedIndex];
                SetProperties(computer);

                Refresh();

            }
            catch (Exception ex)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = ex.Message;
            }
        }

        private void btnDeleteComputer_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.ForeColor = Color.Black;
                lblStatus.Text = string.Empty;

                if (lbxEquipment.SelectedIndex >= 0)
                {
                    // The user picked a computer.
                    //Method 1 - Remove an object.
                    computers.Remove(computers[lbxEquipment.SelectedIndex]);

                    // Method 2 - Remove by index
                    //computers.RemoveAt(lbxEquipment.SelectedIndex);

                    Refresh();
                    ClearScreen();
                    lbxEquipment.SelectedIndex = -1;
                }
                else
                {
                    //nothing selected
                    throw new Exception("Nothing is selected you goof.");
                }
            }
            catch (Exception ex)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = ex.Message;
            }
        }

        private void ClearScreen()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    control.Text = string.Empty;
                }
            }

            cbxEquipmentType.SelectedIndex = -1;
        }

        private void btnAddApplication_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.ForeColor = Color.Black;
                lblStatus.Text = string.Empty;

                frmApplication frmApplication = new frmApplication(ScreenMode.Add);

                if (lbxEquipment.SelectedIndex >= 0)
                {
                    frmApplication.Computer = computers[lbxEquipment.SelectedIndex];
                    frmApplication.ShowDialog();

                    RefreshApplications(computers[lbxEquipment.SelectedIndex].Applications);
                }
                else
                {
                    throw new Exception("Please pick a computer.");
                }
            }
            catch (Exception ex)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = ex.Message;
            }


        }

        private void btnEditApplication_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.ForeColor = Color.Black;
                lblStatus.Text = string.Empty;

                frmApplication frmApplication = new frmApplication(ScreenMode.Edit);

                if (dgvChildren.CurrentRow.Index >= 0)
                {
                    frmApplication.Computer = computers[lbxEquipment.SelectedIndex];
                    //frmApplication.ApplicationId = computers[lbxEquipment.SelectedIndex].Applications[dgvChildren.CurrentRow.Index].Id;
                    frmApplication.ApplicationId = dgvChildren.CurrentRow.Index;
                    frmApplication.ShowDialog();

                    RefreshApplications(computers[lbxEquipment.SelectedIndex].Applications);
                }
                else
                {
                    throw new Exception("Please pick a computer.");
                }
            }
            catch (Exception ex)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = ex.Message;
            }

        }

        private void btnWriteDelimited_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.ForeColor = Color.Black;
                lblStatus.Text = string.Empty;

                ApplicationManager.DeleteDataFile(settings.ApplicationFileName);

                foreach (Computer computer in computers)
                {
                    ApplicationManager.Write(computer.Applications, settings.ApplicationFileName);
                }


                ComputerManager.Write(computers, settings.ComputerFileName);
            }
            catch (Exception ex)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = ex.Message;
            }
        }

        private void btnReadDelimited_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.ForeColor = Color.Black;
                lblStatus.Text = string.Empty;

                computers = ComputerManager.Read(settings.ComputerFileName, settings.ApplicationFileName );


            }
            catch (Exception ex)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = ex.Message;
            }
        }
    }
}