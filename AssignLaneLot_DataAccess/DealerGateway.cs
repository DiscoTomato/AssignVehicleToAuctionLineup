using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignLaneLot_DataAccess
{
    public class DealerGateway
    {
        private readonly string ConnectionString;
        private readonly IDbConnection DbConnection;


        public DealerGateway(string connectionString)
        {
            ConnectionString = connectionString;
            var sqlcsb = new SqlConnectionStringBuilder(ConnectionString);
            DbConnection = new SqlConnection(sqlcsb.ConnectionString);
        }

        public string SellerName(string sellerId)
        {
            SqlCommand dbQuery = new SqlCommand
            {
                Connection = (SqlConnection)DbConnection
            };
            dbQuery.CommandText = "EXEC LaneLot.SellerName @SellerID;";
            dbQuery.Parameters.Add("@SellerID", SqlDbType.Char).Value = sellerId;

            DataTable resultSet = new DataTable("Seller ID");

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(dbQuery))
            {
                dataAdapter.Fill(resultSet);
                dbQuery.Connection.Close();
                dbQuery.Dispose();
            }

            return resultSet.Rows[0][DealerColumn.SellerName].ToString();
        }
    }
}
