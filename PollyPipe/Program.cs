using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PollyPipe
{
    static class Program
    {
        public static readonly int[] JOB_ROLE_POSITIONS = { 0, 0 };
        public static readonly int[] INSTALATION_TYPE_POSITIONS = { 0, 0 };
        public static readonly int[] EMPLOYEE_POSITIONS = { 0, 1, 0, 0, 0 };
        public static readonly int[] EQUIPMENT_POSITIONS = { 0, 0, 1 };
        public static readonly int[] EQUIPMENT_TYPE_POSITIONS = { 0, 0 };
        public static readonly int[] INSTALLATION_POSITIONS = { 0, 2, 2, 1, 1, 1 };
        public static readonly int[] INSTALLATION_LOCATION_POSITIONS = { 0, 0, 0, 0, 0 };
        public static readonly int[] INSTALLATION_REQUIRES_EQUIPMENT_POSITIONS = { 1, 1, 0 };
        public static readonly int[] INSTALLATION_REQUIRES_JOB_ROLE_POSITIONS = { 1, 1, 0 };
        public static readonly int[] CUSTOMER_POSITIONS = { 0, 0, 0, 0 };
        public static readonly int[] PAYMENT_POSITIONS = { 0, 2, 0, 1, 1 };

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DashboardForm());
        }
    }
}
