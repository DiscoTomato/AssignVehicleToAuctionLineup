using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignLaneLot_DataAccess
{
    public class LaneLotGateway
    {
        private readonly string ConnectionString;
        private readonly IDbConnection DbConnection;


        public LaneLotGateway(string connectionString)
        {
            ConnectionString = connectionString;
            var sqlcsb = new SqlConnectionStringBuilder(ConnectionString);
            DbConnection = new SqlConnection(sqlcsb.ConnectionString);
        }

        public string NextSaleDate()
        {
            // TODO: We're getting back a decimal type here--what should we be returning?
            // TODO: What if we get back multiple dates?
            // TODO: What to return? DateTime? DataRow?

            SqlCommand dbQuery = new SqlCommand
            {
                Connection = (SqlConnection)DbConnection,
                CommandText = "EXEC LaneLot.NextSaleDate"
            };

            DataTable resultSet = new DataTable("SaleDate");

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(dbQuery))
            {
                dataAdapter.Fill(resultSet);
                dbQuery.Connection.Close();
                dbQuery.Dispose();
            }

            return resultSet.Rows[0].ItemArray[0].ToString();
        }

        public DataTable OpenLotsInSaleForSeller(string saleDate, string seller)
        {
            // TODO: Sort by LaneLotNumber column ascending?
            // TODO: Return a DataSet?

            SqlCommand dbQuery = new SqlCommand
            {
                Connection = (SqlConnection)DbConnection
            };
            dbQuery.Parameters.Add("@NextSaleDate", SqlDbType.VarChar).Value = saleDate;
            dbQuery.Parameters.Add("@Seller", SqlDbType.VarChar).Value = seller;
            dbQuery.CommandText = "EXEC LaneLot.GetOpenReservations @NextSaleDate, @Seller;";

            DataTable resultSet = new DataTable("Open Reservations");

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(dbQuery))
            {
                dataAdapter.Fill(resultSet);
                dbQuery.Connection.Close();
                dbQuery.Dispose();
            }

            return resultSet;
        }

        public DataRow Lot(string saleDate, string seller, string laneLotNumber)
        {
            SqlCommand dbQuery = new SqlCommand
            {
                Connection = (SqlConnection)DbConnection
            };
            dbQuery.Parameters.Add("@SaleDate", SqlDbType.VarChar).Value = saleDate;
            dbQuery.Parameters.Add("@Seller", SqlDbType.VarChar).Value = seller;
            dbQuery.Parameters.Add("@LaneLotNumber", SqlDbType.VarChar).Value = laneLotNumber;
            dbQuery.CommandText = "EXEC LaneLot.GetReservation @SaleDate, @Seller, @LaneLotNumber;";

            DataTable resultSet = new DataTable("Lane/Lot Reservation");

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(dbQuery))
            {
                dataAdapter.Fill(resultSet);
                dbQuery.Connection.Close();
                dbQuery.Dispose();
            }

            // TODO: What if the reservation cannot be found? Or doesn't exist anymore?

            return resultSet.Rows[0]; 
        }

        public DataRowCollection AssignedLotsInSaleForSeller(string saleDate, string seller)
        {
            SqlCommand dbQuery = new SqlCommand
            {
                Connection = (SqlConnection)DbConnection
            };
            dbQuery.Parameters.Add("@SaleDate", SqlDbType.VarChar).Value = saleDate;
            dbQuery.Parameters.Add("@Seller", SqlDbType.VarChar).Value = seller;
            dbQuery.CommandText = "EXEC LaneLot.GetLineup @SaleDate, @Seller;";

            var resultSet = new DataTable("Lineup");

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(dbQuery))
            {
                dataAdapter.Fill(resultSet);
                dbQuery.Connection.Close();
                dbQuery.Dispose();
            }

            return resultSet.Rows;
        }

        public DataTable SellerIDsWithAssignedAndUnassignedLotsNextSale()
        {
            SqlCommand dbQuery = new SqlCommand
            {
                Connection = (SqlConnection)DbConnection
            };
            dbQuery.CommandText = "EXEC LaneLot.SellerIDsWithAssignedAndUnassignedLotsNextSale;";

            DataTable resultSet = new DataTable("Seller ID");

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(dbQuery))
            {
                dataAdapter.Fill(resultSet);
                dbQuery.Connection.Close();
                dbQuery.Dispose();
            }

            return resultSet;
        }

        public DataRowCollection LotsAssignedToVIN(string vin)
        {
            SqlCommand dbQuery = new SqlCommand
            {
                Connection = (SqlConnection)DbConnection,
                CommandText = "EXEC LaneLot.ReservationsAssignedToVIN @VIN;"
            };
            dbQuery.Parameters.Add("@VIN", SqlDbType.VarChar).Value = vin;

            DataTable resultSet = new DataTable("Reservations Assigned To VIN");

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(dbQuery))
            {
                dataAdapter.Fill(resultSet);
                dbQuery.Connection.Close();
                dbQuery.Dispose();
            }

            return resultSet.Rows;
        }
    }
}
