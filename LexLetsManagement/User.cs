using System;
using System.Data.SqlClient;

namespace LexLetsManagement
{
    static class User
    {
        static public string Username { get; set; }
        static public int UserId { get; set; }
        static public int AccessLevel { get; set; }
        static public bool AcountLocked { get; set; }

        static public void AddToUserLog(string category, string activity)
        {
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            String sql = "";

            sql = "INSERT into tblUsersLog VALUES (@date, @id, @cat, @activity)";
            if (DatabaseAssist.ConnectToLexlets.State.ToString() == "Closed") { DatabaseAssist.ConnectToLexlets.Open(); }
            command = new SqlCommand(sql, DatabaseAssist.ConnectToLexlets);
            command.Parameters.AddWithValue("@date", DateTime.Now);
            command.Parameters.AddWithValue("@id", UserId);
            command.Parameters.AddWithValue("@cat", category);
            command.Parameters.AddWithValue("@activity", activity);


            int i = command.ExecuteNonQuery();
            command.Dispose();
            DatabaseAssist.ConnectToLexlets.Close();
        }
    }
}
