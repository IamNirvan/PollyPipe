using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PollyPipe
{
    class Payment
    {
        private string DateOfPayment { get; set; }
        private decimal Amount { get; set; }
        private string InstallationID { get; set; }
        private string CustomerID { get; set; }
        private static readonly QueryHandler queryHandler = new QueryHandler();

        public Payment (string dateOfPayment, decimal amount, string installationID, string customerID)
        {
            DateOfPayment = dateOfPayment;
            Amount = amount;
            InstallationID = installationID;
            CustomerID = customerID;
        }

        public bool AddPaymentDetails()
        {
            string query = "INSERT INTO payment VALUES(@dateOfPayment, @amount" +
                ", @installationID, @customerID)";
            string[] parameters = { "@dateOfPayment", "@amount", "@installationID", "@customerID" };
            object[] values = { DateOfPayment, Amount, InstallationID, CustomerID };

            if (queryHandler.HandleInsertDeleteUpdateQuery(query, parameters, values))
            {
                MessageBox.Show("Payment record successfully added", "Record inserted",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show("Failed to add the payment record", "An error occurred",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        public static bool DeletePaymentDetails(string paymentID)
        {
            string query = "DELETE FROM payment WHERE paymentID = @paymentID";
            string[] parameters = { "@paymentID" };
            object[] values = { paymentID };

            if (queryHandler.HandleInsertDeleteUpdateQuery(query, parameters, values))
            {
                MessageBox.Show("Payment record successfully deleted", "Record deleted",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show("Failed to delete the payment record", "An error occurred",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        public bool UpdatePaymentDetails(string paymentID)
        {
            string query = "UPDATE payment SET dateOfPayment = @dateOfPayment, " +
                "amount = @amount, installationID = @installationID, customerID = @customerID " +
                "WHERE paymentID = @paymentID";
            string[] parameters = { "@dateOfPayment", "@amount", "@installationID", "@customerID", "@paymentID" };
            object[] values = { DateOfPayment, Amount, InstallationID, CustomerID, paymentID };

            if (queryHandler.HandleInsertDeleteUpdateQuery(query, parameters, values))
            {
                MessageBox.Show("Payment record successfully updated", "Record updated",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show("Failed to update the payment record", "An error occurred",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }
    }
}
