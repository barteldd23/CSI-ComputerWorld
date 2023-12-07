using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDB.Utility.PL
{
    public class Database
    {

        const string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DDB.ComputerWorld.DB;Integrated Security=True";
        SqlConnection sqlConnection;

        public ConnectionState Open()
        {
            try
            {
                sqlConnection = new SqlConnection(ConnectionString);
                sqlConnection.Open();
                return sqlConnection.State;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public ConnectionState Close() 
        {
            try
            {
                sqlConnection.Close();
                return sqlConnection.State;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Insert(SqlCommand sqlCommand, bool rollback = false)
        {
            try
            {
                return ExecuteSQL(sqlCommand, rollback);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Update(SqlCommand sqlCommand, bool rollback = false)
        {
            try
            {
                return ExecuteSQL(sqlCommand, rollback);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private int ExecuteSQL(SqlCommand sqlCommand, bool rollback)
        {
            try
            {
                if (ConnectionState.Open == Open())
                {
                    SqlTransaction transaction = sqlConnection.BeginTransaction("ExecuteSQL");
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.Transaction = transaction;

                    int iRowsAffected = sqlCommand.ExecuteNonQuery();
                    if (rollback)
                    {
                        sqlCommand.Transaction.Rollback();
                    }
                    else
                    {
                        sqlCommand.Transaction.Commit();
                    }

                    sqlConnection.Close();
                    return iRowsAffected;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Delete(SqlCommand sqlCommand, bool rollback = false)
        {
            try
            {
                return ExecuteSQL(sqlCommand, rollback);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable Select(SqlCommand sqlCommand)
        {
            try
            {
                if(ConnectionState.Open == Open())
                {
                    sqlCommand.Connection = sqlConnection;
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    Close();
                    return dataTable;
                }
                else
                {
                    throw new Exception("Could not open the database.");
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
