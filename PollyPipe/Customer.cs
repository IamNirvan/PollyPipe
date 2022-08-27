using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollyPipe
{
    class Customer
    {
        private string CustomerID { get; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string ContactNumber { get; set; }
        private readonly QueryHandler queryHandler = new QueryHandler();

        public Customer(string customerID, string firstName, string lastName, string contactNumber)
        {
            CustomerID = customerID;
            FirstName = firstName;
            LastName = lastName;
            ContactNumber = contactNumber;
        }

        public Customer RegisterCustomer(string firstName, string lastName, string contactNumber)
        {
            string customerID = "";
            string query = "INSERT INTO Customer VALUES(@customerID, @firstName, @lastName, @contactNumber)";
            string[] parameters = { "@customerID", "@firstName", "@lastName", "@contactNumber" };
            object[] values = { customerID, firstName, lastName, contactNumber };

            if(queryHandler.HandleInsertDeleteUpdateQuery(query, parameters, values))
            {
                return new Customer(customerID, firstName, lastName, contactNumber);
            }
            return null;
        }

    }
}
