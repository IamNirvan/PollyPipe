using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PollyPipe
{
    class JobRole
    {
        private string JobRoleName { get; set; }
        private static readonly QueryHandler queryHandler = new QueryHandler();

        public JobRole(string jobRoleName)
        {
            JobRoleName = jobRoleName;
        }

        public bool AddJobRoleDetails()
        {
            string query = "INSERT INTO jobRole VALUES(@jobRoleName)";
            string[] parameters = { "@jobRoleName" };
            object[] values = { JobRoleName };

            if (queryHandler.HandleInsertDeleteUpdateQuery(query, parameters, values))
            {
                MessageBox.Show("Job role record successfully added", "Record inserted",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show("Failed to add the job role record", "An error occurred",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        public static bool DeleteJobRoleDetails(string jobRoleID)
        {
            string query = "DELETE FROM jobRole WHERE jobRoleID = @jobRoleID";
            string[] parameters = { "@jobRoleID" };
            object[] values = { jobRoleID };

            if (queryHandler.HandleInsertDeleteUpdateQuery(query, parameters, values))
            {
                MessageBox.Show("Job role record successfully deleted", "Record deleted",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show("Failed to delete the job role record", "An error occurred",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        public bool UpdateJobRoleDetails(string jobRoleID)
        {
            string query = "UPDATE jobRole SET jobRoleName = @jobRoleName" +
                " WHERE jobRoleID = @jobRoleID";
            string[] parameters = { "@jobRoleName", "@jobRoleID" };
            object[] values = { JobRoleName, jobRoleID };

            if (queryHandler.HandleInsertDeleteUpdateQuery(query, parameters, values))
            {
                MessageBox.Show("Job role record successfully updated", "Record updated",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show("Failed to update the jb role record", "An error occurred",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

    }
}
