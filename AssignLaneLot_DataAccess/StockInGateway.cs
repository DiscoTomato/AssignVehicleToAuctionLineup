using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignLaneLot_DataAccess
{
    public class StockInGateway
    {
        private readonly string ConnectionString;
        private readonly IDbConnection DbConnection;


        public StockInGateway(string dbConnection)
        {
            ConnectionString = dbConnection;
            var sqlcsb = new SqlConnectionStringBuilder(ConnectionString);
            DbConnection = new SqlConnection(sqlcsb.ConnectionString);
        }

        public DataRowCollection StockInRecordsForVehicle(string vin)
        {
            SqlCommand dbQuery = new SqlCommand
            {
                Connection = (SqlConnection)DbConnection
            };
            dbQuery.Parameters.Add("@VIN", SqlDbType.VarChar).Value = vin;
            dbQuery.CommandText = "EXEC dbo.GetStockInDataByVIN @VIN";

            DataTable resultSet = new DataTable("VINStockInRecords");

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(dbQuery))
            {
                dataAdapter.Fill(resultSet);
                dbQuery.Connection.Close();
                dbQuery.Dispose();
            }

            bool vehicleFound = (resultSet.Rows.Count > 0);
            Debug.Assert(vehicleFound, $"VIN {vin} not found in StockIn.dbo.StockIn table.");

            return resultSet.Rows;
        }

        public string SampleVIN()
        {
            SqlCommand dbQuery = new SqlCommand
            {
                Connection = (SqlConnection)DbConnection
            };

            dbQuery.CommandText = "EXEC LaneLot.GetSampleStockInVIN;";

            DataTable resultSet = new DataTable("VIN");

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(dbQuery))
            {
                dataAdapter.Fill(resultSet);
                dbQuery.Connection.Close();
                dbQuery.Dispose();
            }

            return resultSet.Rows[0].ItemArray[0].ToString();
        }
    }
}
