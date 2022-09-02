using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PollyPipe
{
    class Employee
    {

        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string ContactNumber { get; set; }
        private string JobRoleID { get; }
        private static readonly QueryHandler queryHandler = new QueryHandler();

        public Employee(string firstName, string lastName, string contactNumber, string jobRoleID)
        {
            FirstName = firstName;
            LastName = lastName;
            ContactNumber = contactNumber;
            JobRoleID = jobRoleID;
        }

        public bool AddEmployeeDetails()
        {
            string query = "INSERT INTO employee VALUES(@jobRoleID, @firstName, @lastName, @contactNumber)";
            string[] parameters = {"@jobRoleID", "@firstName", "@lastName", "@contactNumber" };
            object[] values = { JobRoleID, FirstName, LastName, ContactNumber };

            if (queryHandler.HandleInsertDeleteUpdateQuery(query, parameters, values))
            {
                MessageBox.Show("Employee record successfully added", "Record inserted",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show("Failed to add the employee record", "An error occurred",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        public static bool DeleteEmployeeDetails(string employeeID)
        {
            string query = "DELETE FROM employee WHERE employeeID = @employeeID";
            string[] parameters = { "@employeeID" };
            object[] values = { employeeID };

            if (queryHandler.HandleInsertDeleteUpdateQuery(query, parameters, values))
            {
                MessageBox.Show("Employee record successfully deleted", "Record deleted",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show("Failed to delete the employee record", "An error occurred",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        public bool UpdateEmployeeDetails(string employeeID)
        {
            string query = "UPDATE employee SET jobRoleID = @jobRoleID, firstName = @firstName, " +
                "lastName = @lastName, contactNumber = @contactNumber WHERE employeeID = @employeeID";
            string[] parameters = { "@jobRoleID", "@firstName", "@lastName", "@contactNumber", "@employeeID" };
            object[] values = { JobRoleID, FirstName, LastName, ContactNumber, employeeID };

            if (queryHandler.HandleInsertDeleteUpdateQuery(query, parameters, values))
            {
                MessageBox.Show("Employee record successfully updated", "Record updated",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show("Failed to update the employee record", "An error occurred",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }


    }
}
