using DDB.ComputerWorld.BL;
using DDB.ComputerWorld.BL.Models;

namespace DDB.ComputerWorld.UI
{
    public partial class frmComputerWorld : Form
    {
        List<Computer> computers;
        List<EquipmentType> equipmentTypes;
        public frmComputerWorld()
        {
            InitializeComponent();
        }

        private void frmComputerWorld_Load(object sender, EventArgs e)
        {

            try
            {
                lblStatus.ForeColor = Color.Black;
                computers = ComputerManager.Populate();
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

                    // Show the applications for this computer.
                    dgvChildren.DataSource = null;
                    dgvChildren.DataSource = computer.Applications;
                    dgvChildren.Columns[0].Visible = false;

                    dgvChildren.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvChildren.Columns[2].DefaultCellStyle.Format = "C";

                }

            }
            catch (Exception ex)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = ex.Message;
            }
        }
    }
}