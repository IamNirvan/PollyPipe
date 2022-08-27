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
        private readonly DataViewForm dataViewForm;
        private readonly string query;
        private readonly QueryHandler queryHandler = new QueryHandler();
        private readonly int[] inputTypePositions;
        private readonly TextBox[] textboxes;
        private readonly ComboBox[] comboBoxes;
        private readonly object recordObject;
        private readonly DataGridViewRow record;

        // Pass an object into of a particular record into the constructor so that its values can be displayed in the data manipulation form.
        public DataManipulationForm(DataViewForm form, int[] positions, DataGridViewRow row, object obj = null, string selectQuery = null)
        {
            InitializeComponent();
            form = dataViewForm;
            inputTypePositions = positions;
            query = selectQuery;
            PlaceObjects();
            // Initialize an empty Textbox array that can hold enough textboxes
            textboxes = new TextBox[positions.Length];
            // Initialize an empty ComboBox array that can hold enough textboxes
            comboBoxes = new ComboBox[positions.Length];
            record = row;
            recordObject = obj;
        }

        private void PlaceObjects()
        {
            DataTable dataTable = queryHandler.SelectQueryHandler(query);
            int y = 30;
            int textBoxesIndex = 0, comboBoxesIndex = 0;

            for (int i = 0; i < dataTable.Columns.Count; i ++)
            {
                // Add the label and set the text property to the column name
                Label label = new Label
                {
                    Location = new Point(20, y),
                    Font = new Font("Carlito", 10),
                    Text = dataTable.Columns[i].ToString(),
                    Size = new Size(120, 30)
                };
                dataPanel.Controls.Add(label);
                
                // 0 -> textbox
                // 1 -> dropdown list
                if(inputTypePositions[i] == 0)
                {
                    TextBox textBox = new TextBox()
                    {
                        Location = new Point(150, y),
                        Font = new Font("Carlito", 10),
                        Size = new Size(250, 30)
                    };
                    dataPanel.Controls.Add(textBox);
                    textboxes[textBoxesIndex] = textBox;
                    textBoxesIndex ++;

                } else
                {
                    ComboBox comboBox = new ComboBox()
                    {
                        Location = new Point(150, y),
                        Font = new Font("Carlito", 10),
                        Size = new Size(250, 30)
                    };
                    dataPanel.Controls.Add(comboBox);
                    comboBoxes[comboBoxesIndex] = comboBox;
                    comboBoxesIndex ++;
                }
                y += 30;
            }
        }

        private void AddData()
        {
            // Finish this
        }

        private void DataManipulationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            dataViewForm.Show();
        }

        private void enableInsertRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (enableInsertRadioBtn.Checked)
            {
                insertBtn.Enabled = true;
                return;
            }
            insertBtn.Enabled = false;
        }

        private void enableUpdateRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (enableUpdateRadioBtn.Checked)
            {
                updateBtn.Enabled = true;
                return;
            }
            updateBtn.Enabled = false;
        }
    }
}
