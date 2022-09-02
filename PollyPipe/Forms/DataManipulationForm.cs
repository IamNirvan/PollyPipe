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
    public partial class DataManipulationForm : Form
    {
        private readonly string query;
        private readonly DashboardForm dashboardForm;
        private FormName formName;
        private readonly QueryHandler queryHandler = new QueryHandler();
        private readonly int[] inputTypePositions;
        private TextBox[] textboxes;
        private ComboBox[] comboBoxes;
        private DateTimePicker[] dateTimePickers;
        private DataTable dataTable;
        private int rowIndex = 0;
        
        public DataManipulationForm(DashboardForm dashboard, string title, FormName name, int[] positions, string selectQuery)
        {
            InitializeComponent();
            dashboardForm = dashboard;
            titleLbl.Text = title;
            formName = name;
            query = selectQuery;
            inputTypePositions = positions;
        }

        private void LoadData(string query)
        {
            dataTable = new QueryHandler().SelectQueryHandler(query);
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ScrollBars = ScrollBars.Both;
            dataGridView.DataSource = dataTable;
        }

        private void DataViewForm_Load(object sender, EventArgs e)
        {
            LoadData(query);
            PlaceObjects(dataTable);
        }

        private void DataViewForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            dashboardForm.Show();
        }

        private void EnableInputObjects()
        {
            if(formName == FormName.INSTALLATION_REQUIRES_EQUIPMENT || 
                formName == FormName.INSTALLATION_REQUIRES_JOB_ROLE)
            {
                foreach (TextBox textBox in textboxes)
                {
                    if (textBox != null)
                    {
                        textBox.Enabled = true;
                    }
                }
            }
            else
            {
                for (int i = 1; i < textboxes.Length; i++)
                {
                    if (textboxes[i] != null)
                    {
                        textboxes[i].Enabled = true;
                    }
                }
            }

            foreach (ComboBox comboBox in comboBoxes)
            {
                if(comboBox != null)
                {
                    comboBox.Enabled = true;
                }
            }

            foreach (DateTimePicker dateTimePicker in dateTimePickers)
            {
                if(dateTimePicker != null)
                {
                    dateTimePicker.Enabled = true;
                }
            }
        }

        private void DisableInputObjects()
        {
            foreach (TextBox textbox in textboxes)
            {
                if (textbox != null)
                {
                    textbox.Enabled = false;
                }
            }

            foreach (ComboBox comboBox in comboBoxes)
            {
                if (comboBox != null)
                {
                    comboBox.Enabled = false;
                }
            }

            foreach (DateTimePicker dateTimePicker in dateTimePickers)
            {
                if (dateTimePicker != null)
                {
                    dateTimePicker.Enabled = false;
                }
            }
        }

        private void PlaceObjects(DataTable dataTable)
        {
            int textBoxesIndex = 0;
            int comboBoxesIndex = 0;
            int dateTimePickerIndex = 0;
            int yAxisPoint = 10;

            textboxes = new TextBox[inputTypePositions.Length];
            comboBoxes = new ComboBox[inputTypePositions.Length];
            dateTimePickers = new DateTimePicker[inputTypePositions.Length];

            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                Label label = new Label
                {
                    Location = new Point(10, yAxisPoint),
                    Font = new Font("Carlito", 10),
                    Text = dataTable.Columns[i].ToString(),
                    Size = new Size(120, 30),
                };

                dataPanel.Controls.Add(label);

                // Add a text box
                if (inputTypePositions[i] == 0)
                {
                    TextBox textBox = new TextBox()
                    {
                        Location = new Point(130, yAxisPoint),
                        Font = new Font("Carlito", 10),
                        Size = new Size(dataPanel.Width - 150, 30),
                        Enabled = false
                    };

                    dataPanel.Controls.Add(textBox);
                    textboxes[textBoxesIndex] = textBox;
                    textBoxesIndex++;
                }
                // Add a combo box
                else if (inputTypePositions[i] == 1)
                {
                    ComboBox comboBox = new ComboBox()
                    {
                        Location = new Point(130, yAxisPoint),
                        Font = new Font("Carlito", 10),
                        Size = new Size(dataPanel.Width - 150, 30),
                        Enabled = false
                    };

                    dataPanel.Controls.Add(comboBox);
                    comboBoxes[comboBoxesIndex] = comboBox;
                    comboBoxesIndex++;
                } 
                // Add a data time picker
                else if (inputTypePositions[i] == 2)
                {
                    DateTimePicker dateTimePicker = new DateTimePicker()
                    {
                        Location = new Point(130, yAxisPoint),
                        Font = new Font("Carlito", 10),
                        Size = new Size(dataPanel.Width - 150, 30),
                        Enabled = false,
                    };

                    dataPanel.Controls.Add(dateTimePicker);
                    dateTimePickers[dateTimePickerIndex] = dateTimePicker;
                    dateTimePickerIndex++;
                }
                yAxisPoint += 30;
            }
        }

        private string[] GetColumnNames()
        {
            if (formName == FormName.EMPLOYEE)
            {
                return new string[] { "jobRoleID" };
            }
            else if (formName == FormName.EQUIPMENT)
            {
                return new string[] { "equipmentTypeID" };
            }
            else if (formName == FormName.INSTALLATION)
            {
                return new string[] { "installationTypeID", "customerID", "locationID" };
            }
            else if (formName == FormName.INSTALLATION_REQUIRES_EQUIPMENT)
            {
                return new string[] { "equipmentNo", "installationID" };
            }
            else if (formName == FormName.INSTALLATION_REQUIRES_JOB_ROLE)
            {
                return new string[] { "installationID", "jobRoleID" };
            }
            else if (formName == FormName.PAYMENT)
            {
                return new string[] { "installationID", "customerID" };
            }
            return null;
        }

        private string[] GetQueries()
        {
            if (formName == FormName.EMPLOYEE)
            {
                return new string[] { "SELECT jobRoleID FROM jobRole" };
            }
            else if (formName == FormName.EQUIPMENT)
            {
                return new string[] { "SELECT equipmentTypeID FROM equipmentType" };
            }
            else if (formName == FormName.INSTALLATION)
            {
                return new string[] {
                    "SELECT * FROM installationType",
                    "SELECT customerID FROM customer",
                    "SELECT locationID FROM installationLocation"
                };
            }
            else if (formName == FormName.INSTALLATION_REQUIRES_EQUIPMENT)
            {
                return new string[] {
                    "SELECT equipmentNo FROM equipment",
                    "SELECT installationID FROM installation"
                };
            }
            else if (formName == FormName.INSTALLATION_REQUIRES_JOB_ROLE)
            {
                return new string[] {
                    "SELECT installationID FROM installation",
                    "SELECT jobRoleID FROM jobRole"
                };
            }
            else if (formName == FormName.PAYMENT)
            {
                return new string[] {
                    "SELECT installationID FROM installation",
                    "SELECT customerID FROM customer"
                };
            }
            return null;
        }

        private void FillInputObjects()
        {
            if (rowIndex >= 0 && dataTable.Rows.Count >= 1)
            {
                DataRow record = dataTable.Rows[rowIndex];
                string[] columnNames = GetColumnNames();
                string[] queries = GetQueries();
                int textboxIndex = 0;
                int comboBoxIndex = 0;
                int dateTimePickerIndex = 0;
                int columnIndex = 0;

                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    if (inputTypePositions[i] == 0)
                    {
                        // Make sure that the primary key does not appear into the textbox when inserting
                        // This is because the primary key is generated automatically
                        if (!(insertRadioButton.Checked && columnIndex == 0))
                        {
                            textboxes[textboxIndex].Text = record[columnIndex].ToString();
                        }
                        textboxIndex++;
                    }
                    else if (inputTypePositions[i] == 1)
                    {
                        comboBoxes[comboBoxIndex].Text = record[columnIndex].ToString();
                        new ComboBoxHandler(comboBoxes[comboBoxIndex], queries[comboBoxIndex],
                            columnNames[comboBoxIndex]).FillComboBox();
                        comboBoxIndex++;
                    }
                    else if (inputTypePositions[i] == 2)
                    {
                        dateTimePickers[dateTimePickerIndex].Text = record[columnIndex].ToString();
                        dateTimePickerIndex++;
                    }
                    columnIndex++;
                }
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Enable the delete button incase the user wants to delete the selected record
                deleteBtn.Enabled = true;

                rowIndex = e.RowIndex;
                DataRow record = dataTable.Rows[e.RowIndex];
                string[] columnNames = GetColumnNames();
                string[] queries = GetQueries();

                int textboxIndex = 0;
                int comboBoxIndex = 0;
                int dateTimePickerIndex = 0;
                int columnIndex = 0;

                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    if (inputTypePositions[i] == 0)
                    {
                        // Make sure that the primary key does not appear into the textbox when inserting.
                        // This is because the primary key is generated automatically
                        if (!(insertRadioButton.Checked && columnIndex == 0))
                        {
                            textboxes[textboxIndex].Text = record[columnIndex].ToString();
                        }

                        textboxIndex++;
                    }
                    else if (inputTypePositions[i] == 1)
                    {
                        comboBoxes[comboBoxIndex].Text = record[columnIndex].ToString();
                        new ComboBoxHandler(comboBoxes[comboBoxIndex], queries[comboBoxIndex],
                            columnNames[comboBoxIndex]).FillComboBox();
                        comboBoxIndex++;
                    }
                    else if (inputTypePositions[i] == 2)
                    {
                        dateTimePickers[dateTimePickerIndex].Text = record[columnIndex].ToString();
                        dateTimePickerIndex++;
                    }

                    columnIndex++;
                }
            }
        }

        private void FillComboBoxes()
        {
            string[] columnNames = GetColumnNames();
            string[] queries = GetQueries();

            if (rowIndex >= 0 && columnNames != null)
            {
                for (int i = 0; i < columnNames.Length; i++)
                {
                    new ComboBoxHandler(comboBoxes[i], queries[i],
                                columnNames[i]).FillComboBox();
                }
            }
        }

        private bool ValidateInput()
        {
            for (int i = 1; i < textboxes.Length; i++)
            {
                if(textboxes[i] != null && textboxes[i].Text == "")
                {
                    return false;
                }
            }

            foreach (ComboBox comboBox in comboBoxes)
            {
                if (comboBox != null && comboBox.Text == "")
                {
                    return false;
                }
            }

            foreach (DateTimePicker dateTimePicker in dateTimePickers)
            {
                if (dateTimePicker != null && dateTimePicker.Text == "")
                {
                    return false;
                }
            }
            return true;
        }

        private void insertBtn_Click(object sender, EventArgs e)
        {
            
            if(ValidateInput())
            {
                if (formName == FormName.EMPLOYEE)
                {
                    string firstName = textboxes[1].Text;
                    string lastName = textboxes[2].Text;
                    string contact = textboxes[3].Text;
                    string jobRoleID = comboBoxes[0].Text;

                    new Employee(firstName, lastName, contact, jobRoleID).AddEmployeeDetails();
                }
                else if (formName == FormName.EQUIPMENT)
                {
                    string name = textboxes[1].Text;
                    string typeID = comboBoxes[0].Text;

                    new Equipment(name, typeID).AddEquipmentDetails();
                }
                else if (formName == FormName.INSTALLATION)
                {
                    string startDate = dateTimePickers[0].Text;
                    string endDate = dateTimePickers[1].Text;
                    string instalationTypeID = comboBoxes[0].Text;
                    string customerID = comboBoxes[1].Text;
                    string locationID = comboBoxes[2].Text;

                    new Installation(instalationTypeID, customerID, locationID,
                        startDate, endDate).AddInstallationDetails();
                }
                else if (formName == FormName.INSTALLATION_REQUIRES_EQUIPMENT)
                {
                    string equipmentNo = comboBoxes[0].Text;
                    string installationID = comboBoxes[1].Text;
                    int quantity = int.Parse(textboxes[0].Text);

                    new InstallationRequiresEquipment(equipmentNo, installationID,
                        quantity).AddInstallationRequiresEquipmentDetails();

                }
                else if (formName == FormName.INSTALLATION_REQUIRES_JOB_ROLE)
                {
                    string installationID = comboBoxes[0].Text;
                    string jobRoleID = comboBoxes[1].Text;
                    int quantity = int.Parse(textboxes[0].Text);

                    new InstallationRequiresJobRole(installationID, jobRoleID,
                        quantity).AddInstallationRequiresJobRoleDetails();
                }
                else if (formName == FormName.PAYMENT)
                {
                    string date = dateTimePickers[0].Text;
                    decimal amount = decimal.Parse(textboxes[1].Text);
                    string installationID = comboBoxes[0].Text;
                    string customerID = comboBoxes[1].Text;

                    new Payment(date, amount, installationID, customerID).AddPaymentDetails();
                }
                else if (formName == FormName.INSTALLATION_TYPE)
                {
                    string name = textboxes[1].Text;
                    new InstallationType(name).AddInstallationTypeDetails();
                }
                else if (formName == FormName.EQUIPMENT_TYPE)
                {
                    string name = textboxes[1].Text;
                    new EquipmentType(name).AddEquipmentTypeDetails();
                }
                else if (formName == FormName.JOB_ROLE)
                {
                    string name = textboxes[1].Text;
                    new JobRole(name).AddJobRoleDetails();
                }
                else if (formName == FormName.INSTALLATION_LOCATION)
                {
                    string postalCode = textboxes[1].Text;
                    string city = textboxes[2].Text;
                    string town = textboxes[3].Text;
                    string streetName = textboxes[4].Text;

                    new InstallationLocation(postalCode, city, town, streetName).AddLocationDetails();
                }
                else if (formName == FormName.CUSTOMER)
                {
                    string firstName = textboxes[1].Text;
                    string lastName = textboxes[2].Text;
                    string contact = textboxes[3].Text;

                    new Customer(firstName, lastName, contact).AddCustomerDetails();
                }
                Reload();
            }
            else
            {
                MessageBox.Show("Please provide valid input", "Invalid input(s)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (formName == FormName.EMPLOYEE)
            {
                string employeeID = textboxes[0].Text;
                string firstName = textboxes[1].Text;
                string lastName = textboxes[2].Text;
                string contact = textboxes[3].Text;
                string jobRoleID = comboBoxes[0].Text;

                new Employee(firstName, lastName, contact, jobRoleID).UpdateEmployeeDetails(employeeID);
            }
            else if (formName == FormName.EQUIPMENT)
            {
                string equipmentNo = textboxes[0].Text;
                string name = textboxes[1].Text;
                string typeID = comboBoxes[0].Text;

                new Equipment(name, typeID).UpdateEquipmentDetails(equipmentNo);
            }
            else if (formName == FormName.INSTALLATION)
            {
                string installationID = textboxes[0].Text;
                string startDate = dateTimePickers[0].Text;
                string endDate = dateTimePickers[1].Text;
                string instalationTypeID = comboBoxes[0].Text;
                string customerID = comboBoxes[1].Text;
                string locationID = comboBoxes[2].Text;

                new Installation(instalationTypeID, customerID, locationID,
                    startDate, endDate).UpdateLocationDetails(installationID);
            }
            else if (formName == FormName.INSTALLATION_REQUIRES_EQUIPMENT)
            {
                string equipmentNo = comboBoxes[0].Text;
                string installationID = comboBoxes[1].Text;
                int quantity = int.Parse(textboxes[0].Text);

                new InstallationRequiresEquipment(equipmentNo, installationID,
                    quantity).UpdateInstallationRequiresEquipmentDetails(equipmentNo, installationID);

            }
            else if (formName == FormName.INSTALLATION_REQUIRES_JOB_ROLE)
            {
                string installationID = comboBoxes[0].Text;
                string jobRoleID = comboBoxes[1].Text;
                int quantity = int.Parse(textboxes[0].Text);

                new InstallationRequiresJobRole(installationID, jobRoleID,
                    quantity).UpdateInstallationRequiresJobRoleDetails(installationID, jobRoleID);
            }
            else if (formName == FormName.PAYMENT)
            {
                string paymentID = textboxes[0].Text;
                string date = dateTimePickers[0].Text;
                decimal amount = decimal.Parse(textboxes[1].Text);
                string installationID = comboBoxes[0].Text;
                string customerID = comboBoxes[1].Text;

                new Payment(date, amount, installationID, customerID).UpdatePaymentDetails(paymentID);
            }
            else if (formName == FormName.INSTALLATION_TYPE)
            {
                string installationID = textboxes[0].Text;
                string name = textboxes[1].Text;
                new InstallationType(name).UpdateInstallationTypeDetails(installationID);
            }
            else if (formName == FormName.EQUIPMENT_TYPE)
            {
                string equipmentTypeID = textboxes[0].Text;
                string name = textboxes[1].Text;
                new EquipmentType(name).UpdateEquipmentTypeDetails(equipmentTypeID);
            }
            else if (formName == FormName.JOB_ROLE)
            {
                string jobRoleID = textboxes[0].Text;
                string name = textboxes[1].Text;
                new JobRole(name).UpdateJobRoleDetails(jobRoleID);
            }
            else if (formName == FormName.INSTALLATION_LOCATION)
            {
                string locationID = textboxes[0].Text;
                string postalCode = textboxes[1].Text;
                string city = textboxes[2].Text;
                string town = textboxes[3].Text;
                string streetName = textboxes[4].Text;

                new InstallationLocation(postalCode, city, town, streetName).UpdateLocationDetails(locationID);
            }
            else if (formName == FormName.CUSTOMER)
            {
                string customerID = textboxes[0].Text;
                string firstName = textboxes[1].Text;
                string lastName = textboxes[2].Text;
                string contact = textboxes[3].Text;

                new Customer(firstName, lastName, contact).UpdateCustomerDetails(customerID);
            }

            Reload();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete the selected record?", "Delete confirmation", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (formName == FormName.EMPLOYEE)
                {
                    string employeeID = textboxes[0].Text;
                    Employee.DeleteEmployeeDetails(employeeID);
                }
                else if (formName == FormName.EQUIPMENT)
                {
                    string equipmentNo = textboxes[0].Text;
                    Equipment.DeleteEquipmentDetails(equipmentNo);
                }
                else if (formName == FormName.INSTALLATION)
                {
                    string installationID = textboxes[0].Text;
                    Installation.DeleteInstallationDetails(installationID);
                }
                else if (formName == FormName.INSTALLATION_REQUIRES_EQUIPMENT)
                {
                    string equipmentNo = comboBoxes[0].Text;
                    string installationID = comboBoxes[1].Text;
                    InstallationRequiresEquipment.DeleteInstallationRequiresEquipmentDetails(equipmentNo, installationID);
                }
                else if (formName == FormName.INSTALLATION_REQUIRES_JOB_ROLE)
                {
                    string installationID = comboBoxes[0].Text;
                    string jobRoleID = comboBoxes[1].Text;
                    InstallationRequiresJobRole.DeleteInstallationRequiresJobRoleDetails(installationID, jobRoleID);
                }
                else if (formName == FormName.PAYMENT)
                {
                    string paymentID = textboxes[0].Text;
                    Payment.DeletePaymentDetails(paymentID);
                }
                else if (formName == FormName.INSTALLATION_TYPE)
                {
                    string installationID = textboxes[0].Text;
                    InstallationType.DeleteInstallationTypeDetails(installationID);
                }
                else if (formName == FormName.EQUIPMENT_TYPE)
                {
                    string equipmentTypeID = textboxes[0].Text;
                    EquipmentType.DeleteEquipmentTypeDetails(equipmentTypeID);
                }
                else if (formName == FormName.JOB_ROLE)
                {
                    string jobRoleID = textboxes[0].Text;
                    JobRole.DeleteJobRoleDetails(jobRoleID);
                }
                else if (formName == FormName.INSTALLATION_LOCATION)
                {
                    string locationID = textboxes[0].Text;
                    InstallationLocation.DeleteLocationDetails(locationID);
                }
                else if (formName == FormName.CUSTOMER)
                {
                    string customerID = textboxes[0].Text;
                    Customer.DeleteCustomerDetails(customerID);
                }

                Reload();
                // Reset the rowIndex after deleting the selected row.
                rowIndex = 0;
            }
        }

        private void Reload()
        {
            insertRadioButton.Checked = false;
            updateRadioButton.Checked = false;
            DisableInputObjects();
            LoadData(query);
            ClearInputObjects();
        }

        private void ClearInputObjects()
        {
            foreach (TextBox textBox in textboxes)
            {
                if (textBox != null)
                {
                    textBox.Text = "";
                }
            }

            foreach (ComboBox comboBox in comboBoxes)
            {
                if (comboBox != null)
                {
                    comboBox.Text = "";
                }
            }

            foreach (DateTimePicker dateTimePicker in dateTimePickers)
            {
                if(dateTimePicker != null)
                {
                    dateTimePicker.Value = DateTime.Today;
                }
            }
        }

        private void insertRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if(insertRadioButton.Checked)
            {
                FillComboBoxes();
                insertBtn.Enabled = true;
                updateBtn.Enabled = false;
                EnableInputObjects();

                if (!(formName == FormName.INSTALLATION_REQUIRES_EQUIPMENT || formName == FormName.INSTALLATION_REQUIRES_JOB_ROLE))
                {
                    textboxes[0].Text = "";
                }
            } else
            {
                insertBtn.Enabled = false;
            }
        }

        private void updateRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (updateRadioButton.Checked)
            {
                FillComboBoxes();
                insertBtn.Enabled = false;
                updateBtn.Enabled = true;
                EnableInputObjects();
            } else
            {
                updateBtn.Enabled = false;
            }
        }
    }
}
