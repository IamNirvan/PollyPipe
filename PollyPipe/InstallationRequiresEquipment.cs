using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PollyPipe
{
    class InstallationRequiresEquipment
    {
        private string EquipmentNo { get; set; }
        private string InstallationID { get; set; }
        private int Quantity { get; set; }
        private static readonly QueryHandler queryHandler = new QueryHandler();

        public InstallationRequiresEquipment(string equipmentNo, string installationID, int quantity)
        {
            EquipmentNo = equipmentNo;
            InstallationID = installationID;
            Quantity = quantity;
        }

        public bool AddInstallationRequiresEquipmentDetails()
        {
            string query = "INSERT INTO installationRequiresEquipment VALUES(@equipmentNo, @installationID" +
                ", @quantity)";
            string[] parameters = { "@equipmentNo", "@installationID", "@quantity" };
            object[] values = { EquipmentNo, InstallationID, Quantity };

            if (queryHandler.HandleInsertDeleteUpdateQuery(query, parameters, values))
            {
                MessageBox.Show("Record successfully added", "Record inserted",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show("Failed to add the record", "An error occurred",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        public static bool DeleteInstallationRequiresEquipmentDetails(string equipmentNo, string installationID)
        {
            string query = "DELETE FROM installationRequiresEquipment " +
                "WHERE equipmentNo = @equipmentNo AND installationID = @installationID";
            string[] parameters = { "@equipmentNo", "@installationID" };
            object[] values = { equipmentNo, installationID };

            if (queryHandler.HandleInsertDeleteUpdateQuery(query, parameters, values))
            {
                MessageBox.Show("Record successfully deleted", "Record deleted",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show("Failed to delete the record", "An error occurred",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        public bool UpdateInstallationRequiresEquipmentDetails(string equipmentNo, string installationID)
        {
            string query = "UPDATE installationRequiresEquipment SET quantity = @quantity " +
                "WHERE equipmentNo = @equipmentNo AND installationID = @installationID";
            string[] parameters = { "@quantity", "@equipmentNo", "@installationID" };
            object[] values = { Quantity, equipmentNo, installationID };

            if (queryHandler.HandleInsertDeleteUpdateQuery(query, parameters, values))
            {
                MessageBox.Show("Record successfully updated", "Record updated",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show("Failed to update the record", "An error occurred",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }
    }
}
