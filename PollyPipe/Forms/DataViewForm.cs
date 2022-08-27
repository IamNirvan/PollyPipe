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
    public partial class DataViewForm : Form
    {
        private readonly string query;
        private readonly DashboardForm dashboardForm;
        

        public DataViewForm(DashboardForm dashboard, string selectQuery = null)
        {
            InitializeComponent();
            dashboardForm = dashboard;
            query = selectQuery;
            dataGridView.ScrollBars = ScrollBars.Both;
        }

        private void LoadData(string query = "SELECT * FROM InstallationType")
        {
            DataTable dataTable = new QueryHandler().SelectQueryHandler(query);

            // Alow the columns to resize themselves automatically          
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Bound a data table to the data grid view
            dataGridView.DataSource = dataTable;
        }

        private void DataViewForm_Load(object sender, EventArgs e)
        {
            LoadData(query);
        }

        private void DataViewForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            dashboardForm.Show();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            new DataManipulationForm(this, new int[]{ 0, 0, 0, 1, 1, 1 }, dataGridView.Rows[e.RowIndex], null, "SELECT * FROM InstallationType").Show();
            this.Hide();
        }
    }
}
