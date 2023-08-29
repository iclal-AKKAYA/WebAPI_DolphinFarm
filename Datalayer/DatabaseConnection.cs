using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DatabaseConnection
    {
        // Bağlantı adresimizi yazıp, bağlantıyı açıyoruz
        public SqlConnection OpenConnection()
        {
            SqlConnection sqlConnection = new SqlConnection("Server=ICLALA\\SQLEXPRESS;database=DolphinFarm;trusted_connection=true");
            sqlConnection.Open();
            return sqlConnection;
        }
        // Her sorgu oluşturduğumuzda buradan yararlanacağız.
        public SqlCommand CreateCommand(string query)
        {
            SqlCommand sqlCommand = new SqlCommand(query, OpenConnection());
            return sqlCommand;
        }

    }
}
