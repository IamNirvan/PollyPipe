using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PollyPipe
{
    class InstallationRequiresJobRole
    {
        private string JobRoleID { get; set; }
        private string InstallationID { get; set; }
        private int Quantity { get; set; }
        private static readonly QueryHandler queryHandler = new QueryHandler();

        public InstallationRequiresJobRole(string installationID, string jobRoleID, int quantity)
        {
            InstallationID = installationID;
            JobRoleID = jobRoleID;
            Quantity = quantity;
        }

        public bool AddInstallationRequiresJobRoleDetails()
        {
            string query = "INSERT INTO installationRequiresJobRole VALUES(@installationID, @jobRoleID" +
                ", @quantity)";
            string[] parameters = { "@installationID", "@jobRoleID", "@quantity" };
            object[] values = { InstallationID, JobRoleID, Quantity };

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

        public static bool DeleteInstallationRequiresJobRoleDetails(string installationID, string jobRoleID)
        {
            string query = "DELETE FROM installationRequiresJobRole " +
                "WHERE installationID = @installationID AND jobRoleID = @jobRoleID";
            string[] parameters = { "@installationID" , "@jobRoleID"};
            object[] values = { installationID, jobRoleID };

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

        public bool UpdateInstallationRequiresJobRoleDetails(string installationID, string jobRoleID)
        {
            string query = "UPDATE installationRequiresJobRole SET quantity = @quantity " +
                "WHERE installationID = @installationID AND jobRoleId = @jobRoleID";
            string[] parameters = { "@quantity", "@installationID", "@jobRoleId" };
            object[] values = {Quantity, installationID, jobRoleID };

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
