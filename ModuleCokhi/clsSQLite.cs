using System;
using System.Data;
using System.Data.SQLite;
using System.Text.RegularExpressions;

using System.Collections;
using System.IO;
using System.Windows.Forms;

namespace WM03Soft
{
    public class clsSQLite
    {
        public static string _strConnect = "Data Source=" + MyLib.GetAppPath() + "LocalDB.db;Version=3;New=False;Compress=True;Pooling=True;Max Pool Size=1000;";
        public static SQLiteConnection _con = new SQLiteConnection();

        public static string strPCID = "";

        public static void createConection()
        {
            _con.Close();
            _con.ConnectionString = _strConnect;
            _con.Open();
        }

        public static void closeConnection()
        {
            _con.Close();
        }

        public static DataTable ExecuteQuery(string strSQL)
        {
            DataSet ds = new DataSet();
            createConection();
            try
            {
                SQLiteDataAdapter da = new SQLiteDataAdapter(strSQL, _con);
                da.Fill(ds);
            }
            catch (Exception ex)
            { //MyLib.NoticeError(ex.ToString(), "Lỗi");
            }
            closeConnection();
            return ds.Tables[0];

        }
        
        public static int ExecuteSql(string strSQL)
        {
            int num;
            createConection();
            SQLiteCommand cmd = new SQLiteCommand(strSQL, _con);
            try
            {
                num = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                num = 0;
            }
            finally
            {
                closeConnection();
            }      
            return num;
        }

        // Xóa bản ghi rất cũ
        public static void ClearOld()
        {
            try
            {
                ExecuteSql("delete from tblFirstCheckingInfo where Created < '" + DateTime.Now.AddYears(-2).ToString("yyyy-MM-dd") + "'  and Pushed=1");
                ExecuteSql("delete from tblFirstCheckingInfoGua where Created < '" + DateTime.Now.AddYears(-2).ToString("yyyy-MM-dd") + "'  and Pushed=1");
                ExecuteSql("delete from tblSecondCheckingInfo where Created < '" + DateTime.Now.AddYears(-2).ToString("yyyy-MM-dd") + "'  and Pushed=1");
                ExecuteSql("delete from tblSecondCheckingInfoGua where Created < '" + DateTime.Now.AddYears(-2).ToString("yyyy-MM-dd") + "'  and Pushed=1");
            }
            catch { }
        }

        public static bool ExecuteSqlTran(ArrayList SQLStringList)
        {
            bool flag;
            string str = "";
            using (IDbConnection connection = new SQLiteConnection())
            {
                connection.ConnectionString = _strConnect;
                connection.Open();

                using (IDbCommand command = new SQLiteCommand())
                {
                    command.Connection = connection;
                    using (IDbTransaction transaction = connection.BeginTransaction())
                    {
                        command.Transaction = transaction;
                        try
                        {
                            for (int i = 0; i < SQLStringList.Count; i++)
                            {
                                str = SQLStringList[i].ToString();

                                if (str.Trim().Length > 1)
                                {
                                    command.CommandText = str;
                                    command.ExecuteNonQuery();
                                }
                            }
                            transaction.Commit();
                            flag = true;
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            flag = false;
                            MessageBox.Show(str + ex.ToString());
                        }
                        finally
                        {
                            if (connection.State != ConnectionState.Closed)
                            {
                                connection.Close();
                            }
                        }
                    }
                }
            }

            return flag;
        }
    }
}
