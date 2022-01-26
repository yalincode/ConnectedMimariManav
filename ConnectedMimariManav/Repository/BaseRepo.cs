using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectedMimariManav.Repository
{
    public abstract class BaseRepo
    {
        public BaseRepo()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DbManav"].ConnectionString);
        }

        private SqlConnection connection=null;

        public SqlConnection con
        {
            get { return connection; }
            
        }

    }
}
