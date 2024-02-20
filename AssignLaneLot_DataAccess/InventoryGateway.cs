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
    public class InventoryGateway
    {
        private readonly string ConnectionString;
        private readonly IDbConnection DbConnection;


        public InventoryGateway(string connectionString)
        {
            ConnectionString = connectionString;
            var sqlcsb = new SqlConnectionStringBuilder(ConnectionString);
            DbConnection = new SqlConnection(sqlcsb.ConnectionString);
        }

        public DataRowCollection InventoryRecordsForVehicle(string vin)
        {
            SqlCommand dbQuery = new SqlCommand
            {
                Connection = (SqlConnection)DbConnection
            };
            dbQuery.Parameters.Add("@VIN", SqlDbType.VarChar).Value = vin;
            dbQuery.CommandText = "EXEC LaneLot.InventoryRecordsForVehicle @VIN";

            DataTable resultSet = new DataTable("Vehicle Info");

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(dbQuery))
            {
                dataAdapter.Fill(resultSet);
                dbQuery.Connection.Close();
                dbQuery.Dispose();
            }

            // TODO: What to do here if we have a VIN that's not found in the Inventory table? I hit one that was, briefly, not there.
            bool vehicleFound = (resultSet.Rows.Count > 0);
            Debug.Assert(vehicleFound, $"VIN {vin} not found in Inventory.");

            return resultSet.Rows;
        }

        public string SampleVIN()
        {
            SqlCommand dbQuery = new SqlCommand
            {
                Connection = (SqlConnection)DbConnection
            };

            dbQuery.CommandText = "EXEC LaneLot.GetSampleInventoryVIN;";

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
