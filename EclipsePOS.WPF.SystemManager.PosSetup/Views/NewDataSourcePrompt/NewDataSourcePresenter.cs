using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Diagnostics;
using System.Reflection;
using System.IO;
using System.Windows.Threading;
using System.Threading;

using System.Text.RegularExpressions;
using Microsoft.Practices.Composite.Presentation.Events;
using Microsoft.Practices.Composite.Presentation.Commands;



using EclipsePOS.WPF.SystemManager.PosSetup.Util;


namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.NewDataSourcePrompt
{
    public class NewDataSourcePresenter
    {
        private SqlConnection conn;
        private string database1;
        private string server1;
        private INewDataSource _view;

        private SqlConnection sqlCon = new SqlConnection();
        private SqlCommand sqlCmd = new SqlCommand();

        public DelegateCommand<object> OKCommand;
        public delegate void RunCreateDatabaseDelegate();

        
        public NewDataSourcePresenter()
        {
            OKCommand = new DelegateCommand<object>(OnOKCommandExecute, OnOKCommandCanExecute);
            
        }

        public INewDataSource View
        {
            set
            {
                _view = value;
                View.SetOKBtnDataContext(OKCommand);
               // View.SetCurrDataSourcePath(this.GetCurrentDatabasePathAndSize());  
              
            }
            get
            {
                return _view;
            }
        }

        #region OK Command

        public void OnOKCommandExecute(object obj)
        {
           // MessageBox.Show("OK command"); 
            if (!View.FieldEmpty())
            {
               
               //this.SetupDatabase( View.ServerInstance , View.Authentication, this.View.UserName, this.View.Password, this.View.DatabaseName);
                RunCreateDatabaseDelegate runCreateDatabase = new RunCreateDatabaseDelegate(this.SetupDatabaseHelper);
                runCreateDatabase.BeginInvoke(null, null);
            }
        }

        public bool OnOKCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion

        public void SetupDatabaseHelper()
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Send, (SendOrPostCallback)delegate { View.StartSyncAnimation(); }, null);
            this.SetupDatabase(View.ServerInstance, View.Authentication, this.View.UserName, this.View.Password, this.View.DatabaseName);
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Send, (SendOrPostCallback)delegate { View.EndSyncAnimation(); }, null);
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Send, (SendOrPostCallback)delegate { View.SetDataSourcePath(); }, null);
    
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
                MessageBox.Show("Fail to connect to SQL Server Express\n" + sql_ex.Number.ToString() + " " + sql_ex.Message.ToString());
                return bContinue;
            }

            //Now that you are connected to Express, check the database versions

          //  string script = Regex.Replace(Properties.Resource.CreatePosSite.ToString(), "possite", databaseName);

            string script = Regex.Replace(Properties.Resource.CreatePosSite_v106.ToString(), "possite", databaseName);
            
            string[] scripts = Regex.Split(script, "demo_data", RegexOptions.IgnoreCase);
            /*
            if (View.Mode == CreateMode.NewEmptyDatabase && View.IncludeSampleData )
            {

                if ( RunScript(scripts[0]) &&  RunScript(scripts[1]) )
                {
                    string connString = dataSource + "Initial Catalog=" + databaseName; //"Data Source=" + ".\\sqlexpress" + ";" + "Initial Catalog=" + "possite" + ";" + "Integrated Security=True";
                    PosSettings.Default.DataSource = connString;
                    PosSettings.Default.possiteConnectionString = connString;
                    PosSettings.Default.Save();
                }

            }
            */

            if (View.Mode == CreateMode.NewEmptyDatabase)
            {
                if (RunScript(scripts[0]))
                {
                    string connString = dataSource + "Initial Catalog=" + databaseName; 
                    PosSettings.Default.DataSource = connString;
                    PosSettings.Default.possiteConnectionString = connString;
                    PosSettings.Default.Save();
                }

                if (View.IncludeSampleData)
                {
                    this.RunScript(scripts[1]);
                }

            }

            if (View.Mode == CreateMode.ExistingDatabase)
            {
                
                string connString = dataSource + "Initial Catalog=" + databaseName; 
                PosSettings.Default.DataSource = connString;
                PosSettings.Default.possiteConnectionString = connString;
                PosSettings.Default.Save();
                
            }

      
                                 
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
                           // View.UpdateProgress(count);
                            sqlCmd.CommandText = strCmd;
                            sqlCmd.ExecuteNonQuery();
                        }
                        catch (SqlException sql_ex0)
                        {
                            MessageBox.Show(sql_ex0.Number.ToString() + " " + sql_ex0.Message.ToString() + "\n" +strCmd);
                            return false;
                        }
                    }

                }
            }
            catch (SqlException sql_ex)
            {
                MessageBox.Show(sql_ex.Number.ToString() + " " + sql_ex.Message.ToString()  );
                return false;
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


        public string GetCurrentDatabasePathAndSize()
        {
            StringBuilder output = new StringBuilder();

            string connString = PosSettings.Default.DataSource;
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand("select filename, size from dbo.sysfiles", conn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    // MessageBox.Show(reader[0].ToString());
                    // MessageBox.Show(reader[1].ToString());
                    output.Append(reader[0].ToString());
                    output.Append(", Size=");
                    output.Append(reader[1].ToString());
                    output.AppendLine(" KB");
                }



            }
            catch (Exception e)
            {

                // MessageBox.Show(e.ToString());
            }
            finally
            {
                conn.Close();
            }

            return output.ToString();
        }


        
    }
}
