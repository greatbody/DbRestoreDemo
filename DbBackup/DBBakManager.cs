using System;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DbBackup
{
    class DbBackUpManager : IDisposable
    {
        #region 内部变量

        private const string DefaultName = "default";
        private string _mConnStr;

        #endregion

        #region public methods

        public DbBackUpManager(string connStr)
        {
            _mConnStr = connStr;
        }

        public int restoreDb(string dbName)
        {
            return restoreDb(dbName, Application.StartupPath, DefaultName);
        }

        public int restoreDb(string dbName, string fromPath, string fileName)
        {
            var easyDb = new EasyDb(_mConnStr);
            var sqlCommandStr = "ALTER DATABASE " + dbName + " SET OFFLINE WITH ROLLBACK IMMEDIATE;";
            sqlCommandStr += "RESTORE DATABASE " + dbName + " FROM DISK='" + fromPath + "\\" + fileName + ".bak" + "' WITH REPLACE;";
            sqlCommandStr += "ALTER DATABASE " + dbName + " SET ONLINE;";
            return easyDb.ExecSQL(sqlCommandStr);
        }

        public int backupDb(string dbName)
        {
            return backupDb(dbName, Application.StartupPath, "default");
        }

        public int backupDb(string dbName, string toPath, string fileName)
        {
            var easyDb = new EasyDb(_mConnStr);
            var sqlCommandStr = "BACKUP DATABASE " + dbName + " TO DISK='" + toPath + "\\" + fileName + ".bak" + "';";
            sqlCommandStr += "BACKUP LOG " + dbName + " TO DISK='" + toPath + "\\" + fileName + ".log" + "';";
            return easyDb.ExecSQL(sqlCommandStr);
        }

        #endregion

        #region IDisposable 成员

        public void Dispose()
        {
            _mConnStr = null;
        }

        #endregion
    }
}