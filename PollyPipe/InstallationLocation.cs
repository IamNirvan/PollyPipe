using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PollyPipe
{
    class InstallationLocation
    {

        private string PostalCode { get; set; }
        private string City { get; set; }
        private string Suburb { get; set; }
        private string StreetName { get; set; }
        private static readonly QueryHandler queryHandler = new QueryHandler();

        public InstallationLocation(string postalCode, string city, string suburb, string streetName)
        {
            PostalCode = postalCode;
            City = city;
            Suburb = suburb;
            StreetName = streetName;
        }

        public bool AddLocationDetails()
        {
            string query = "INSERT INTO installationLocation VALUES(@postalCode, @city" +
                ", @suburb, @streetName)";
            string[] parameters = { "@postalCode", "@city", "@suburb", "@streetName" };
            object[] values = { PostalCode, City, Suburb, StreetName };

            if (queryHandler.HandleInsertDeleteUpdateQuery(query, parameters, values))
            {
                MessageBox.Show("Installation location successfully added", "Record addded",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show("Failed to insert the installation location", "An error occurred",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        public static bool DeleteLocationDetails(string locationID)
        {
            string query = "DELETE FROM installationLocation WHERE locationID = @locationID";
            string[] parameters = { "@locationID" };
            object[] values = { locationID };

            if(queryHandler.HandleInsertDeleteUpdateQuery(query, parameters, values))
            {
                MessageBox.Show("Installation location successfully deleted", "Record deleted", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show("Failed to delete the installation location", "An error occurred",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        public bool UpdateLocationDetails(string locationID)
        {
            string query = "UPDATE installationLocation SET postalCode = @postalCode, " +
                "city = @city, suburb = @suburb, streetName = @streetName WHERE locationID = @locationID";
            string[] parameters = { "@postalCode", "city", "@suburb", "@streetName", "@locationID" };
            object[] values = { PostalCode, City, Suburb, StreetName, locationID };

            if (queryHandler.HandleInsertDeleteUpdateQuery(query, parameters, values))
            {
                MessageBox.Show("Installation location successfully updated", "Record deleted",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show("Failed to update the installation location", "An error occurred",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }
    }
}
