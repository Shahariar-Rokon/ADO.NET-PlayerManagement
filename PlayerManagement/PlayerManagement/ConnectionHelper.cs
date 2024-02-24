using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerManagement
{
    internal class ConnectionHelper
    {
        public static string PDBCH
        {
            get
            {
                string dbPath = Path.Combine(Path.GetFullPath(@"..\..\"), "Database1.mdf");
                return $@"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename={dbPath};Initial Catalog=Database1;Trusted_Connection=True";
            }
        }
    }
}
