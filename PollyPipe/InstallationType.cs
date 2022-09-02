using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PollyPipe
{
    class InstallationType
    {
        private string TypeName { get; set; }
        private static readonly QueryHandler queryHandler = new QueryHandler();


        public InstallationType(string name)
        {
            TypeName = name;
        }

        public bool AddInstallationTypeDetails()
        {
            string query = "INSERT INTO installationType VALUES(@typeName)";
            string[] parameters = { "@typeName" };
            object[] values = { TypeName };

            if (queryHandler.HandleInsertDeleteUpdateQuery(query, parameters, values))
            {
                MessageBox.Show("Installation type record successfully added", "Record inserted",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show("Failed to add the installation type record", "An error occurred",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        public static bool DeleteInstallationTypeDetails(string installationTypeID)
        {
            string query = "DELETE FROM installationType WHERE installationTypeID = @installationTypeID";
            string[] parameters = { "@installationTypeID" };
            object[] values = { installationTypeID };

            if (queryHandler.HandleInsertDeleteUpdateQuery(query, parameters, values))
            {
                MessageBox.Show("Installation type record successfully deleted", "Record deleted",
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

        public bool UpdateInstallationTypeDetails(string installationTypeID)
        {
            string query = "UPDATE installationType SET typeName = @typeName WHERE installationTypeID = @installationTypeID";
            string[] parameters = { "@typeName", "@installationTypeID" };
            object[] values = { TypeName, installationTypeID };

            if (queryHandler.HandleInsertDeleteUpdateQuery(query, parameters, values))
            {
                MessageBox.Show("Installation type record successfully updated", "Record updated",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show("Failed to update the installation type record", "An error occurred",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

    }
}
