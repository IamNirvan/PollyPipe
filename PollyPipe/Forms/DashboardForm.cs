using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


// gray - #D8DCDE
// white - #ffffff
// Blue - #5079de
// Black - #0d0e19
// disabled black - #7a7a81

namespace PollyPipe
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
        }

        private void installationTypeManagementBtn_Click(object sender, EventArgs e)
        {
            new DataViewForm(this, "SELECT * FROM installationType").Show();
            this.Hide();
        }

        private void jobRoleManagementBtn_Click(object sender, EventArgs e)
        {
            new DataViewForm(this, "SELECT * FROM jobRole").Show();
            this.Hide();
        }

        private void equipmentTypeManagementBtn_Click(object sender, EventArgs e)
        {
            new DataViewForm(this, "SELECT * FROM equipmentType").Show();
            this.Hide();
        }

        private void employeeManagementBtn_Click(object sender, EventArgs e)
        {
            new DataViewForm(this, "SELECT * FROM employee").Show();
            this.Hide();
        }

        private void inventoryManagementBtn_Click(object sender, EventArgs e)
        {
            new DataViewForm(this, "SELECT * FROM equipment").Show();
            this.Hide();
        }

        private void usedEquipmentManagementBtn_Click(object sender, EventArgs e)
        {
            new DataViewForm(this, "SELECT * FROM installationRequiresEquipment").Show();
            this.Hide();
        }

        private void assignedEmployeesManagementBtn_Click(object sender, EventArgs e)
        {
            new DataViewForm(this, "SELECT * FROM installationRequiresJobRole").Show();
            this.Hide();
        }

        private void customerManagementBtn_Click(object sender, EventArgs e)
        {
            new DataViewForm(this, "SELECT * FROM customer").Show();
            this.Hide();
        }

        private void InstallationManagementBtn_Click(object sender, EventArgs e)
        {
            new DataViewForm(this, "SELECT * FROM installation").Show();
            this.Hide();
        }
    }
}
