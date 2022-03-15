using System;
using System.Linq;
using Npgsql;

namespace acima_mbl_bknd.Helpers.DataStore
{
    public static class DBOperation
    {

        public static int CheckNonQueryStatus(NpgsqlDataReader reader, NpgsqlConnection sqlCon, bool closeConnection = true)
        {
            try
            {
                if (reader != null && reader.HasRows && reader.Read())
                {
                    var affectedRowCount = Convert.ToInt32(reader[0]);
                    if (affectedRowCount > 0)
                    {
                        if (closeConnection)
                            sqlCon.Close();
                        return affectedRowCount;
                    }
                    else
                    {
                        if (closeConnection)
                            sqlCon.Close();
                        return affectedRowCount;
                    }
                }
                else
                {
                    if (closeConnection)
                        sqlCon.Close();
                    return -1;
                }
            }
            catch (Exception ex)
            {
                //RollbarLocator.RollbarInstance.Error(ex);

                if (closeConnection)
                    sqlCon.Close();
                return -1;
            }
        }
    }
}
