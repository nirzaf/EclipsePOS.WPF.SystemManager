using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Diagnostics;


namespace EclipsePOS.WPF.SystemManager.PosSetup.SQLSetup
{
    class EmbeddedInstall
    {

        #region Internal variables

        //Variables for setup.exe command line
        private string instanceName = "SQLEXPRESS";
        private string installSqlDir = "";
        private string installSqlSharedDir = "";
        private string installSqlDataDir = "";
        private string addLocal = "All";
        private bool sqlAutoStart = true;
        private bool sqlBrowserAutoStart = false;
        private string sqlBrowserAccount = "";
        private string sqlBrowserPassword = "";
        private string sqlAccount = "";
        private string sqlPassword = "";
        private bool sqlSecurityMode = false;
        private string saPassword = "";
        private string sqlCollation = "";
        private bool disableNetworkProtocols = true;
        private bool errorReporting = true;
        private string sqlExpressSetupFileLocation = System.Environment.GetEnvironmentVariable("TEMP") + "\\sqlexpr.exe";

        #endregion
        #region Properties
        public string InstanceName
        {
            get
            {
                return instanceName;
            }
            set
            {
                instanceName = value;
            }
        }

        public string SetupFileLocation
        {
            get
            {
                return sqlExpressSetupFileLocation;
            }
            set
            {
                sqlExpressSetupFileLocation = value;
            }
        }

        public string SqlInstallSharedDirectory
        {
            get
            {
                return installSqlSharedDir;
            }
            set
            {
                installSqlSharedDir = value;
            }
        }
        public string SqlDataDirectory
        {
            get
            {
                return installSqlDataDir;
            }
            set
            {
                installSqlDataDir = value;
            }
        }
        public bool AutostartSQLService
        {
            get
            {
                return sqlAutoStart;
            }
            set
            {
                sqlAutoStart = value;
            }
        }
        public bool AutostartSQLBrowserService
        {
            get
            {
                return sqlBrowserAutoStart;
            }
            set
            {
                sqlBrowserAutoStart = value;
            }
        }
        public string SqlBrowserAccountName
        {
            get
            {
                return sqlBrowserAccount;
            }
            set
            {
                sqlBrowserAccount = value;
            }
        }
        public string SqlBrowserPassword
        {
            get
            {
                return sqlBrowserPassword;
            }
            set
            {
                sqlBrowserPassword = value;
            }
        }
        //Defaults to LocalSystem
        public string SqlServiceAccountName
        {
            get
            {
                return sqlAccount;
            }
            set
            {
                sqlAccount = value;
            }
        }
        public string SqlServicePassword
        {
            get
            {
                return sqlPassword;
            }
            set
            {
                sqlPassword = value;
            }
        }
        public bool UseSQLSecurityMode
        {
            get
            {
                return sqlSecurityMode;
            }
            set
            {
                sqlSecurityMode = value;
            }
        }
        public string SysadminPassword
        {
            set
            {
                saPassword = value;
            }
        }
        public string Collation
        {
            get
            {
                return sqlCollation;
            }
            set
            {
                sqlCollation = value;
            }
        }
        public bool DisableNetworkProtocols
        {
            get
            {
                return disableNetworkProtocols;
            }
            set
            {
                disableNetworkProtocols = value;
            }
        }
        public bool ReportErrors
        {
            get
            {
                return errorReporting;
            }
            set
            {
                errorReporting = value;
            }
        }
        public string SqlInstallDirectory
        {
            get
            {
                return installSqlDir;
            }
            set
            {
                installSqlDir = value;
            }
        }

        #endregion

        public bool IsExpressInstalled()
        {
                using (RegistryKey Key = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Microsoft SQL Server\\", false))
                {
                    if (Key == null) return false;
                    string[] strNames;
                    strNames = Key.GetSubKeyNames();

                    //If we cannot find a SQL Server registry key, we don't have SQL Server Express installed
                    if (strNames.Length == 0) return false;

                    foreach (string s in strNames)
                    {
                        if (s.StartsWith("MSSQL."))
                        {
                            //Check to see if the edition is "Express Edition"
                            using (RegistryKey KeyEdition = Key.OpenSubKey(s.ToString() + "\\Setup\\", false))
                            {
                                if ((string)KeyEdition.GetValue("Edition") == "Express Edition")
                                {
                                    //If there is at least one instance of SQL Server Express installed, return true
                                    return true;
                                }
                            }
                        }
                    }
                }

                return false;
        }

        public int EnumSQLInstances(ref string[] strInstanceArray, ref string[] strEditionArray, ref string[] strVersionArray)
        {
            using (RegistryKey Key = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Microsoft SQL Server\\", false))
            {
                if (Key == null) return 0;
                string[] strNames;
                strNames = Key.GetSubKeyNames();

                //If we can not find a SQL Server registry key, we return 0 for none
                if (strNames.Length == 0) return 0;

                //How many instances do we have?
                int iNumberOfInstances = 0;

                foreach (string s in strNames)
                {
                    if (s.StartsWith("MSSQL."))
                        iNumberOfInstances++;
                }

                //Reallocate the string arrays to the new number of instances
                strInstanceArray = new string[iNumberOfInstances];
                strVersionArray = new string[iNumberOfInstances];
                strEditionArray = new string[iNumberOfInstances];
                int iCounter = 0;

                foreach (string s in strNames)
                {
                    if (s.StartsWith("MSSQL."))
                    {
                        //Get Instance name
                        using (RegistryKey KeyInstanceName = Key.OpenSubKey(s.ToString(), false))
                        {
                            strInstanceArray[iCounter] =(string)KeyInstanceName.GetValue("");
                        }

                        //Get Edition
                        using (RegistryKey KeySetup = Key.OpenSubKey(s.ToString() + "\\Setup\\", false))
                        {
                            strEditionArray[iCounter] = (string)KeySetup.GetValue("Edition");
                            strVersionArray[iCounter] = (string)KeySetup.GetValue("Version");
                        }

                        iCounter++;
                    }
                }
                return iCounter;
            }
        }


        private string BuildCommandLine()
            {
                StringBuilder strCommandLine = new StringBuilder();

                if (!string.IsNullOrEmpty(installSqlDir))
                {
                    strCommandLine.Append(" INSTALLSQLDIR=\"").Append(installSqlDir).Append("\"");
                }

                if (!string.IsNullOrEmpty(installSqlSharedDir))
                {
                    strCommandLine.Append(" INSTALLSQLSHAREDDIR=\"").Append(installSqlSharedDir).Append("\"");
                }

                if (!string.IsNullOrEmpty(installSqlDataDir))
                {
                    strCommandLine.Append(" INSTALLSQLDATADIR=\"").Append(installSqlDataDir).Append("\"");
                }

                if (!string.IsNullOrEmpty(addLocal))
                {
                    strCommandLine.Append(" ADDLOCAL=\"").Append(addLocal).Append("\"");
                }

                if (sqlAutoStart)
                {
                    strCommandLine.Append(" SQLAUTOSTART=1");
                }
                else
                {
                    strCommandLine.Append(" SQLAUTOSTART=0");
                }

                if (sqlBrowserAutoStart)
                {
                    strCommandLine.Append(" SQLBROWSERAUTOSTART=1");
                }
                else
                {
                    strCommandLine.Append(" SQLBROWSERAUTOSTART=0");
                }

                if (!string.IsNullOrEmpty(sqlBrowserAccount))
                {
                    strCommandLine.Append(" SQLBROWSERACCOUNT=\"").Append(sqlBrowserAccount).Append("\"");
                }

                if (!string.IsNullOrEmpty(sqlBrowserPassword))
                {
                    strCommandLine.Append("SQLBROWSERPASSWORD=\"").Append(sqlBrowserPassword).Append("\"");
                }

                if (!string.IsNullOrEmpty(sqlAccount))
                {
                    strCommandLine.Append(" SQLACCOUNT=\"").Append(sqlAccount).Append("\"");
                }

                if (!string.IsNullOrEmpty(sqlPassword))
                {
                    strCommandLine.Append(" SQLPASSWORD=\"").Append(sqlPassword).Append("\"");
                }

                if (sqlSecurityMode == true)
                {
                    strCommandLine.Append(" SECURITYMODE=SQL");
                }

                if (!string.IsNullOrEmpty(saPassword))
                {
                    strCommandLine.Append(" SAPWD=\"").Append(saPassword).Append("\"");
                }

                if (!string.IsNullOrEmpty(sqlCollation))
                {
                    strCommandLine.Append(" SQLCOLLATION=\"").Append(sqlCollation).Append("\"");
                }

                if (disableNetworkProtocols == true)
                {
                    strCommandLine.Append(" DISABLENETWORKPROTOCOLS=1");
                }
                else
                {
                    strCommandLine.Append(" DISABLENETWORKPROTOCOLS=0");
                }

                if (errorReporting == true)
                {
                    strCommandLine.Append(" ERRORREPORTING=1");
                }
                else
                {
                    strCommandLine.Append(" ERRORREPORTING=0");
                }

                return strCommandLine.ToString();
            }

        public bool InstallExpress()
        {

            //In both cases, we run Setup because we have the file.
            Process myProcess = new Process();
            myProcess.StartInfo.FileName = sqlExpressSetupFileLocation;
            myProcess.StartInfo.Arguments = "/qb " + BuildCommandLine();
            /*      /qn -- Specifies that setup run with no user interface.
                    /qb -- Specifies that setup show only the basic 
                    user interface. Only dialog boxes displaying progress information are 
                    displayed. Other dialog boxes, such as the dialog box that asks users if 
                    they want to restart at the end of the setup process, are not displayed.
            */
            myProcess.StartInfo.UseShellExecute = false;

            return myProcess.Start();

        }



         
    }
}
