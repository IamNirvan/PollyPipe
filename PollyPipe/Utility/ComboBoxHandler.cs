using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PollyPipe.Forms
{
    class ComboBoxHandler
    {
        private readonly ComboBox FormComboBox;
        private readonly string Query;
        private readonly string ColumnName;
        private static readonly QueryHandler queryHandler = new QueryHandler();

        public ComboBoxHandler(ComboBox comboBox, string query, string columnName)
        {
            FormComboBox = comboBox;
            Query = query;
            ColumnName = columnName;
        }

        public bool FillComboBox()
        {
            FormComboBox.Items.Clear();
            DataTable dataTable = queryHandler.SelectQueryHandler(Query);

            if(dataTable != null)
            {
                foreach(DataRow record in dataTable.Rows)
                {
                    FormComboBox.Items.Add(record[ColumnName]);
                }
                return true;
            }
            return false;
        }
    }
}
