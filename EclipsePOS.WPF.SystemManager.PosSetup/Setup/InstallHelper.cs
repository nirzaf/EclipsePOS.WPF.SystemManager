using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Configuration;
using System.Configuration.Install;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Reflection;
using System.IO;
using System.Text.RegularExpressions;
using System.Data;
using EclipsePOS.WPF.SystemManager.PosSetup.Util;

namespace EclipsePOS.WPF.SystemManager.PosSetup.Setup
{
    [RunInstaller(true)]
    public class InstallHelper:Installer
    {
        private SqlConnection conn;
        //private string database1;
        private string server1;
        private SqlConnection sqlCon = new SqlConnection();
        private SqlCommand sqlCmd = new SqlCommand();
        FileStream fs;
        StreamWriter sw;

        public InstallHelper()
		{
            fs  = new FileStream("c:\\temp\\mylog.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite );
            sw = new StreamWriter(fs);
            sw.WriteLine("Open", "logging", Environment.NewLine);
		}


        public override void Install(System.Collections.IDictionary stateSaver)
        {
            base.Install(stateSaver);

            try
            {

                string server = Context.Parameters["server"];
                string userName = Context.Parameters["userName"];
                string password = Context.Parameters["password"];
                string database = Context.Parameters["database"];
                int authMode = 1;
                sw.WriteLine("ok1", "logging", Environment.NewLine);
                if (string.IsNullOrEmpty(userName.Trim()))
                {
                    authMode = 0;
                }
                this.SetupDatabase(server, authMode, userName, password, database);
                sw.WriteLine("ok2", "logging", Environment.NewLine);
            }
            catch (Exception e)
            {
                string s = e.Message;
                sw.WriteLine(s, "logging", Environment.NewLine);

            }

            sw.Close();
            fs.Close();


        }

        public bool SetupDatabase(string server, int autMode, string user, string password, string databaseName)
        {


            this.server1 = server;

            StringBuilder str1 = new StringBuilder();
            str1.Append("server=");
            str1.Append(server);
            str1.Append("; ");
            //  str1.Append("Database=");
            //  str1.Append(databaseName);
            //  str1.Append("; ");
            if (autMode == 0)
            {
                str1.Append("Integrated Security=True;");
            }
            else
            {
                str1.Append("user=");
                str1.Append(user);
                str1.Append(";");
                str1.Append("password=");
                str1.Append(password);
                str1.Append(";");
            }

            string dataSource = str1.ToString();//"server=" + server + ";" + "Database=master;Integrated Security=True;";

            bool bContinue = false;



            //Create a connection to SQL Server
            try
            {
                sqlCon.ConnectionString = dataSource; //"Server=.\\sqlexpress;Integrated Security=true";
                sqlCon.Open();
            }
            catch (SqlException sql_ex)
            {
               // MessageBox.Show("Fail to connect to SQL Server Express\n" + sql_ex.Number.ToString() + " " + sql_ex.Message.ToString());
                //throw sql_ex;
                //return bContinue;
                sw.WriteLine(sql_ex.ToString(), "logging", Environment.NewLine);
            }

            //Now that you are connected to Express, check the database versions

            string script = Regex.Replace(Properties.Resource.CreatePosSite_v103.ToString(), "possite", databaseName);
            string[] scripts = Regex.Split(script, "demo_data", RegexOptions.IgnoreCase);

          //  if (View.Mode == CreateMode.DemoDatabse)
          //  {

                if (RunScript(scripts[0]) && RunScript(scripts[1]))
                {
                    string connString = dataSource + "Initial Catalog=" + databaseName; //"Data Source=" + ".\\sqlexpress" + ";" + "Initial Catalog=" + "possite" + ";" + "Integrated Security=True";
                    PosSettings.Default.DataSource = connString;
                    PosSettings.Default.possiteConnectionString = connString;
                    PosSettings.Default.Save();
                   
                }

           // }
          
            /*
            if (View.Mode == CreateMode.NewEmptyDatabase)
            {
                if (RunScript(scripts[0]))
                {
                    string connString = dataSource + "Initial Catalog=" + databaseName;
                    PosSettings.Default.DataSource = connString;
                    PosSettings.Default.possiteConnectionString = connString;
                    PosSettings.Default.Save();
                }

            }

            if (View.Mode == CreateMode.ExistingDatabase)
            {

                string connString = dataSource + "Initial Catalog=" + databaseName;
                PosSettings.Default.DataSource = connString;
                PosSettings.Default.possiteConnectionString = connString;
                PosSettings.Default.Save();

            }

            */

            return bContinue;


        }


        public bool RunScript(string strFile)
        {

            int count = 0;
            string[] strCommands;
            strCommands = ParseScriptToCommands(strFile);
            try
            {
                if (sqlCon.State != ConnectionState.Open) sqlCon.Open();

                sqlCmd.Connection = sqlCon;

                foreach (string strCmd in strCommands)
                {
                    if (strCmd.Length > 0)
                    {
                        try
                        {
                            count++;
                         //   View.UpdateProgress(count);
                            sqlCmd.CommandText = strCmd;
                            sqlCmd.ExecuteNonQuery();
                        }
                        catch (SqlException sql_ex0)
                        {
                          //  MessageBox.Show(sql_ex0.Number.ToString() + " " + sql_ex0.Message.ToString() + "\n" + strCmd);
                            throw sql_ex0;
                            return false;
                        }
                    }

                }
            }
            catch (SqlException sql_ex)
            {
                //MessageBox.Show(sql_ex.Number.ToString() + " " + sql_ex.Message.ToString());
               // throw sql_ex;
               // return false;
                sw.WriteLine(sql_ex.ToString(), "logging", Environment.NewLine);
            }
            //MessageBox.Show(count.ToString());

            return true;
        }

        public string[] ParseScriptToCommands(string strScript)
        {
            string[] commands;
            commands = Regex.Split(strScript, "GO\r\n", RegexOptions.IgnoreCase);
            return commands;
        }

    }
}
