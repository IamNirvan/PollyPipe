using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PollyPipe
{
    class Equipment
    {
        private string EquipmentName { get; set; }
        private string EquipmentTypeID { get; }
        private static readonly QueryHandler queryHandler = new QueryHandler();

        public Equipment(string name, string typeID)
        {
            EquipmentName = name;
            EquipmentTypeID = typeID;
        }

        public bool AddEquipmentDetails()
        {
            string query = "INSERT INTO equipment VALUES(@equipmentName, @equipmentTypeID)";
            string[] parameters = { "@equipmentName" , "@equipmentTypeID" };
            object[] values = { EquipmentName, EquipmentTypeID };

            if (queryHandler.HandleInsertDeleteUpdateQuery(query, parameters, values))
            {
                MessageBox.Show("Equipment record successfully added", "Record inserted",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show("Failed to add the equipment record", "An error occurred",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;

        }

        public static bool DeleteEquipmentDetails(string equipmentNo)
        {
            string query = "DELETE FROM equipment WHERE equipmentNo = @equipmentNo";
            string[] parameters = { "@equipmentNo" };
            object[] values = { equipmentNo };

            if (queryHandler.HandleInsertDeleteUpdateQuery(query, parameters, values))
            {
                MessageBox.Show("Equipment record successfully deleted", "Record deleted",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show("Failed to delete the equipment record", "An error occurred",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        public bool UpdateEquipmentDetails(string equipmentNo)
        {
            string query = "UPDATE equipment SET equipmentName = @equipmentName, " +
                "equipmentTypeID = @equipmentTypeID WHERE equipmentNo = @equipmentNo";
            string[] parameters = { "@equipmentName", "@equipmentTypeID" , "@equipmentNo" };
            object[] values = { EquipmentName, EquipmentTypeID, equipmentNo };

            if (queryHandler.HandleInsertDeleteUpdateQuery(query, parameters, values))
            {
                MessageBox.Show("Equipment record successfully updated", "Record updated",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show("Failed to update the equipment record", "An error occurred",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }


    }
}
