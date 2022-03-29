using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dpl
{
    internal class dbb
    {

        private SqlConnection sqlConnection = null;

        public void GetConnection()

        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersDB"].ConnectionString);

            sqlConnection.Open();

        }

    }
}
