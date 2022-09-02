using PollyPipe.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            new DataManipulationForm(this, "Installation type management", FormName.INSTALLATION_TYPE, 
                Program.INSTALATION_TYPE_POSITIONS, "SELECT * FROM installationType").Show();
            this.Hide();
        }

        private void jobRoleManagementBtn_Click(object sender, EventArgs e)
        {
            new DataManipulationForm(this, "Job role management",
                FormName.JOB_ROLE, Program.JOB_ROLE_POSITIONS, "SELECT * FROM jobRole").Show();
            this.Hide();
        }

        private void equipmentTypeManagementBtn_Click(object sender, EventArgs e)
        {
            new DataManipulationForm(this, "Equipment type management", 
                FormName.EQUIPMENT_TYPE, Program.EQUIPMENT_TYPE_POSITIONS, "SELECT * FROM equipmentType").Show();
            this.Hide();
        }

        private void employeeManagementBtn_Click(object sender, EventArgs e)
        {
            new DataManipulationForm(this, "Employee management", 
                FormName.EMPLOYEE, Program.EMPLOYEE_POSITIONS, "SELECT * FROM employee").Show();
            this.Hide();
        }

        private void inventoryManagementBtn_Click(object sender, EventArgs e)
        {
            new DataManipulationForm(this, "Inventory management",
                FormName.EQUIPMENT, Program.EQUIPMENT_POSITIONS, "SELECT * FROM equipment").Show();
            this.Hide();
        }

        private void usedEquipmentManagementBtn_Click(object sender, EventArgs e)
        {
            new DataManipulationForm(this, "Used equipment management", 
                FormName.INSTALLATION_REQUIRES_EQUIPMENT, Program.INSTALLATION_REQUIRES_EQUIPMENT_POSITIONS, "SELECT * FROM installationRequiresEquipment").Show();
            this.Hide();
        }

        private void assignedEmployeesManagementBtn_Click(object sender, EventArgs e)
        {
            new DataManipulationForm(this, "Assigned job roles management", 
                FormName.INSTALLATION_REQUIRES_JOB_ROLE, Program.INSTALLATION_REQUIRES_JOB_ROLE_POSITIONS, "SELECT * FROM installationRequiresJobRole").Show();
            this.Hide();
        }

        private void customerManagementBtn_Click(object sender, EventArgs e)
        {
            new DataManipulationForm(this, "Customer management", FormName.CUSTOMER, Program.CUSTOMER_POSITIONS, "SELECT * FROM customer").Show();
            this.Hide();
        }

        private void InstallationManagementBtn_Click(object sender, EventArgs e)
        {
            new DataManipulationForm(this, "Installation management", FormName.INSTALLATION, Program.INSTALLATION_POSITIONS, 
                "SELECT * FROM installation").Show();
            this.Hide();
        }

        private void paymentBtn_Click(object sender, EventArgs e)
        {
            new DataManipulationForm(this, "Payment management", FormName.PAYMENT, Program.PAYMENT_POSITIONS,
                "SELECT * FROM payment").Show();
            this.Hide();
        }

        private void installationLocationBtn_Click(object sender, EventArgs e)
        {
            new DataManipulationForm(this, "Installation location management", FormName.INSTALLATION_LOCATION, Program.INSTALLATION_LOCATION_POSITIONS,
                "SELECT * FROM installationLocation").Show();
            this.Hide();
        }
    }
}
