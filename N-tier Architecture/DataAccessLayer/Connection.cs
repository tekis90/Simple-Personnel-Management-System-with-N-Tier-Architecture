using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class Connection
    {
        public static SqlConnection cnt = new SqlConnection(@"Data Source=YAZILIM\MESTAN;Initial Catalog=DbPerson;Integrated Security=True");



    }
}
