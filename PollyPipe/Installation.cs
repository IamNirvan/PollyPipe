using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PollyPipe
{
    class Installation
    {
        private string InstallationTypeID { get; set; }
        private string CustomerID { get; set; }
        private string LocationID { get; set; }
        private string StartDate { get; set; }
        private string EndDate { get; set; }
        private static readonly QueryHandler queryHandler = new QueryHandler();

        public Installation(string installationTypeID, string customerID, string locationID, string start, string end)
        {
            InstallationTypeID = installationTypeID;
            CustomerID = customerID;
            LocationID = locationID;
            StartDate = start;
            EndDate = end;
        }

        public bool AddInstallationDetails()
        {
            string query = "INSERT INTO installation VALUES(@startDate, @endDate, @installationTypeID, " +
                "@customerID, @locationID)";
            string[] parameters = { "@startDate", "@endDate", "@installationTypeID", "@customerID", "@locationID" };
            object[] values = { StartDate, EndDate, InstallationTypeID, CustomerID, LocationID };

            if (queryHandler.HandleInsertDeleteUpdateQuery(query, parameters, values))
            {
                MessageBox.Show("Installation record successfully added", "Record inserted",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show("Failed to add the installation record", "An error occurred",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        public static bool DeleteInstallationDetails(string installationID)
        {
            string query = "DELETE FROM installation WHERE installationID = @installationID";
            string[] parameters = { "@installationID" };
            object[] values = { installationID };

            if (queryHandler.HandleInsertDeleteUpdateQuery(query, parameters, values))
            {
                MessageBox.Show("Installation record successfully deleted", "Record deleted",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show("Failed to delete the installation record", "An error occurred",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        public bool UpdateLocationDetails(string installationID)
        {
            string query = "UPDATE installation SET startDate = @startDate, endDate = @endDate, " +
                "installationTypeID = @installationTypeID, customerID = @customerID, " +
                "locationID = @locationID WHERE installationID = @installationID";
            string[] parameters = { "@startDate", "@endDate", "@installationTypeID", "@customerID", "@locationID", "@installationID" };
            object[] values = { StartDate, EndDate, InstallationTypeID, CustomerID, LocationID, installationID };

            if (queryHandler.HandleInsertDeleteUpdateQuery(query, parameters, values))
            {
                MessageBox.Show("Installation successfully updated", "Record updated",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show("Failed to update the installation record", "An error occurred",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }
    }
}
