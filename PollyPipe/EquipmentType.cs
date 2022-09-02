using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PollyPipe
{
    class EquipmentType
    {

        private string TypeName { get; set; }
        private static readonly QueryHandler queryHandler = new QueryHandler();

        public EquipmentType(string name)
        {
            TypeName = name;
        }


        public bool AddEquipmentTypeDetails()
        {
            string query = "INSERT INTO equipmentType VALUES(@typeName)";
            string[] parameters = { "@typeName" };
            object[] values = { TypeName };

            if (queryHandler.HandleInsertDeleteUpdateQuery(query, parameters, values))
            {
                MessageBox.Show("Equipment type record successfully added", "Record inserted",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show("Failed to add the equipment type record", "An error occurred",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        public static bool DeleteEquipmentTypeDetails(string equipmentTypeID)
        {
            string query = "DELETE FROM equipmentType WHERE equipmentTypeID = @equipmentTypeID";
            string[] parameters = { "@equipmentTypeID" };
            object[] values = { equipmentTypeID };

            if (queryHandler.HandleInsertDeleteUpdateQuery(query, parameters, values))
            {
                MessageBox.Show("Equipment type record successfully deleted", "Record deleted",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show("Failed to delete the equipment type record", "An error occurred",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        public bool UpdateEquipmentTypeDetails(string equipmentTypeID)
        {
            string query = "UPDATE equipmentType SET typeName = @typeName WHERE equipmentTypeID = @equipmentTypeID";
            string[] parameters = { "@typeName", "@equipmentTypeID" };
            object[] values = { TypeName, equipmentTypeID };

            if (queryHandler.HandleInsertDeleteUpdateQuery(query, parameters, values))
            {
                MessageBox.Show("Equipment type record successfully updated", "Record updated",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show("Failed to updated the equipment type record", "An error occurred",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

    }
}
