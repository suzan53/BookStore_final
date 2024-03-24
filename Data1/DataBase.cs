using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class Database
    {
        public static SqlConnection GetConnection()
        {
            String connectionString = "Data Source=LAPTOP-9PKO3DPE\\SQLEXPRESS;Database=books;Integrated Security=True";
            SqlConnection objCon = new SqlConnection();
            try
            {
                objCon = new SqlConnection(connectionString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new SqlConnection(connectionString);
        }
    }
}
