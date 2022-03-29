using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dpl
{
    public class db
    {
        private SqlConnection sqlConnection = null;

        public void GetConnection()

        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["PhotoDB"].ConnectionString);

            sqlConnection.Open();

        }

            
    }
}
