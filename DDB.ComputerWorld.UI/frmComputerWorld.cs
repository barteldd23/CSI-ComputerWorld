using DDB.ComputerWorld.BL;
using DDB.ComputerWorld.BL.Models;

namespace DDB.ComputerWorld.UI
{
    public partial class frmComputerWorld : Form
    {
        List<Computer> computers;
        public frmComputerWorld()
        {
            InitializeComponent();
        }

        private void frmComputerWorld_Load(object sender, EventArgs e)
        {
            try
            {
                computers = ComputerManager.Populate();
                Refresh();
            }
            catch (Exception)
            {

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
    }
}