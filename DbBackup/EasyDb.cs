using System;
using System.Data.SqlClient;
using System.Text;

namespace DbBackup
{
    class EasyDb
    {
        #region property

        public string ConnectionString { get; set; }

        #endregion

        #region init

        public EasyDb()
        {
            
        }

        public EasyDb(string connStr)
        {
            ConnectionString = connStr;
        }

        #endregion

        #region MainFunction

        public int ExecSQL(string sqlStr)
        {
            int result = -1;
            var conn = new SqlConnection(ConnectionString);
            conn.Open();
            var command = new SqlCommand(sqlStr, conn);
            result = command.ExecuteNonQuery();
            command.Dispose();
            conn.Close();
            conn.Dispose();
            return result;
        }

        #endregion
    }
}
