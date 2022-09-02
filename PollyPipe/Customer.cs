using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PollyPipe
{
    class Customer
    {
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string ContactNumber { get; set; }
        private static readonly QueryHandler queryHandler = new QueryHandler();

        public Customer(string firstName, string lastName, string contactNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            ContactNumber = contactNumber;
        }

        public bool AddCustomerDetails()
        {
            string query = "INSERT INTO customer VALUES(@firstName, @lastName, @contactNumber)";
            string[] parameters = { "@firstName", "@lastName", "@contactNumber" };
            object[] values = { FirstName, LastName, ContactNumber };

            if (queryHandler.HandleInsertDeleteUpdateQuery(query, parameters, values))
            {
                MessageBox.Show("Customer record successfully added", "Record inserted",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show("Failed to add the customer record", "An error occurred",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        public static bool DeleteCustomerDetails(string customerID)
        {
            string query = "DELETE FROM customer WHERE customerID = @customerID";
            string[] parameters = { "@customerID" };
            object[] values = { customerID };

            if (queryHandler.HandleInsertDeleteUpdateQuery(query, parameters, values))
            {
                MessageBox.Show("Customer record successfully deleted", "Record deleted",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show("Failed to delete the customer record", "An error occurred",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        public bool UpdateCustomerDetails(string customerID)
        {
            string query = "UPDATE customer SET firstName = @firstName, lastName = @lastName, " +
                "contactNumber = @contactNumber WHERE customerID = @customerID";
            string[] parameters = { "@customerID", "@firstName", "@lastName", "@contactNumber" };
            object[] values = { customerID, FirstName, LastName, ContactNumber };

            if (queryHandler.HandleInsertDeleteUpdateQuery(query, parameters, values))
            {
                MessageBox.Show("Customer record successfully updated", "Record updated",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show("Failed to update the customer record", "An error occurred",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }
    }
}
