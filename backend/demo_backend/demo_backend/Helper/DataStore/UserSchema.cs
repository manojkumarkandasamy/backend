using demo_backend.BOs;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Npgsql;
using acima_mbl_bknd.Helpers.DataStore;

namespace demo_backend.Helper.DataStore
{
    public class UserSchema
    {
        public enum UserTable
        {
            [Description("feedback.user")]
            user_tabel
        }
        public enum UserFunction
        {
            [Description("SELECT user.insert_user(@_id, @_name")]
            insert_user_function,

            [Description("SELECT (user.get_user()).*")]
            get_user_function,

            [Description("SELECT user.delete_user(@_id)")]
            delete_user_function,

            [Description("SELECT user.update_user(@_name, @_id")]
            update_user_function
        }

        public static int insert_user(int id, string name)
        {
            using (NpgsqlConnection sqlConnection = new NpgsqlConnection("User ID=postgres;Password=Manoj@123;Host=localhost;Port=5432;Database=postgres;"))
            {
                sqlConnection.Open();

                using (NpgsqlCommand sqlCommand = new NpgsqlCommand("SELECT feedback.insert_user(@_id, @_name)", sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.Parameters.AddWithValue("@_id", id);
                    sqlCommand.Parameters.AddWithValue("@_name", name);

                    var reader = sqlCommand.ExecuteReader();
                    return DBOperation.CheckNonQueryStatus(reader, sqlConnection);
                }
            }
        }

        public static ObservableCollection<UserBO> get_user()
        {
            ObservableCollection<UserBO> userList = new ObservableCollection<UserBO>();

            using (NpgsqlConnection sqlConnection = new NpgsqlConnection("User ID=postgres;Password=Manoj@123;Host=localhost;Port=5432;Database=postgres;"))
            {
                sqlConnection.Open();
                using (NpgsqlCommand sqlCommand = new NpgsqlCommand("SELECT (feedback.get_user()).*", sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;

                    var reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        userList.Add(new UserBO()
                        {
                            id = reader.IsDBNull(reader.GetOrdinal("id")) ? -1 : reader.GetInt32(reader.GetOrdinal("id")),
                            name = reader.IsDBNull(reader.GetOrdinal("name")) ? null : reader.GetString(reader.GetOrdinal("name"))
                        });
                    }
                    sqlConnection.Close();
                }
            }

            return userList;
        }

        public static int delete_user(int id)
        {
            using (NpgsqlConnection sqlConnection = new NpgsqlConnection("User ID=postgres;Password=Manoj@123;Host=localhost;Port=5432;Database=postgres;"))
            {
                sqlConnection.Open();

                using (NpgsqlCommand sqlCommand = new NpgsqlCommand("SELECT feedback.delete_user(@_id)", sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.Parameters.AddWithValue("@_id", id);

                    var reader = sqlCommand.ExecuteReader();
                    return DBOperation.CheckNonQueryStatus(reader, sqlConnection);
                }
            }
        }

        public static int update_user(string name, int id)
        {
            using (NpgsqlConnection sqlConnection = new NpgsqlConnection("User ID=postgres;Password=Manoj@123;Host=localhost;Port=5432;Database=postgres;"))
            {
                sqlConnection.Open();

                using (NpgsqlCommand sqlCommand = new NpgsqlCommand("SELECT feedback.update_user(@_name, @_id)", sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.Parameters.AddWithValue("@_name", name);
                    sqlCommand.Parameters.AddWithValue("@_id", id);

                    var reader = sqlCommand.ExecuteReader();
                    return DBOperation.CheckNonQueryStatus(reader, sqlConnection);
                }
            }
        }
    }
}
