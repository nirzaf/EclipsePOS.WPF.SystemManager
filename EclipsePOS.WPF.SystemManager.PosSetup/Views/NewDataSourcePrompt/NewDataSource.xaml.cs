using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using EclipsePOS.WPF.SystemManager.Data;
using System.Data.Linq;
using System.ComponentModel;
using System.Threading;
using EclipsePOS.WPF.SystemManager.Infrastructure.Constants;
using EclipsePOS.WPF.SystemManager.PosSetup.SQLSetup;
using System.Windows.Media.Animation;

using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.NewDataSourcePrompt
{
    /// <summary>
    /// Interaction logic for NewDataSource.xaml
    /// </summary>
    public partial class NewDataSource : UserControl, INewDataSource
    {
        private NewDataSourcePresenter _presenter;
        private int response = -1;
        private string serverInstance;
        private string databaseName;
        private string userName;
        private string password;
        private int storeOperation = 0;
        private int auth;
        private bool includeSampleData = true;


        public NewDataSource()
        {
            InitializeComponent();
            //this.Closing += new System.ComponentModel.CancelEventHandler(NewDataSource_Closing);
            this.rootControl.SizeChanged += new SizeChangedEventHandler(rootControl_SizeChanged);
          
             this.DataContext = this;
             this.checkBoxSampleData.LostFocus += new RoutedEventHandler(checkBoxSampleData_LostFocus);

             //Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Send, (SendOrPostCallback)delegate { this.LoadServerInstances(); }, null);


         }

        void checkBoxSampleData_LostFocus(object sender, RoutedEventArgs e)
        {
            if (this.checkBoxSampleData.IsChecked == true)
            {
                this.IncludeSampleData = true;
            }
            else
            {
                this.IncludeSampleData = false;

            }
        }

        
        void rootControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.rootControl.Height = Math.Ceiling(Application.Current.MainWindow.ActualHeight * 0.82); 
        }

       
        public NewDataSource(NewDataSourcePresenter presenter)
            : this()
        {
            this._presenter = presenter;
            this._presenter.View = this;

            this.Loaded += new RoutedEventHandler(NewDataSource_Loaded);

        }

        void NewDataSource_Loaded(object sender, RoutedEventArgs e)
        {
            this.LoadResources();
            
            this.txtBoxServerName.Focus();
           // this.cmbBoxServerName.Focus();
           
           // this.RefreshDataSourcePath();

            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Send, (SendOrPostCallback)delegate { this.SetDataSourcePath(); }, null);

            
        }


     
     
        public void SetDataSourcePath()
        {
            this.txtBlockCurrDBPath.Text = _presenter.GetCurrentDatabasePathAndSize();

        }

        public void LoadResources()
        {
            // Merge resoure directory
            base.Resources.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri(@"EclipsePOS.WPF.SystemManager.Infrastructure;;;component/Skins/BaseSkin.xaml", UriKind.Relative)));
            this.txtBoxServerName.Text = ".\\sqlexpress";
            this.ServerInstance = ".\\sqlexpress";
            this.radioButtonWindowsAuth.IsChecked = true;
            this.Authentication = 0;
            this.DatabaseName = "possite";
            this.txtBoxDatabase.Text = "possite";
            txtBlockWarMessage.Text = Properties.Resource.DataSourceView_txtBlockWarMessage;
        
        }

        

             
       

        void btnOK_Click(object sender, RoutedEventArgs e)
        {
            if (! FieldEmpty())
            {
                int aut = 0;
                if (this.radioButtonWindowsAuth.IsChecked == true)
                {
                    aut = 0;
                }
                else
                {
                    aut = 1;
                }
               
                _presenter.SetupDatabase(this.txtBoxServerName.Text, aut, this.txtBoxUserName.Text, this.txtBoxPassword.Password, this.txtBoxDatabase.Text);
                //_presenter.SetupDatabase(this.cmbBoxServerName.SelectedValue.ToString(), aut, this.txtBoxUserName.Text, this.txtBoxPassword.Password, this.txtBoxDatabase.Text);
              
            }
           
        }

        public bool FieldEmpty()
        {

            //Server instance
           /* try
            {
                if (!string.IsNullOrEmpty(this.cmbBoxServerName.SelectedValue.ToString()))
                {

                    this.ServerInstance = this.cmbBoxServerName.SelectedValue.ToString();
                }
                else
                {
                    Microsoft.Windows.Controls.MessageBox.Show("Please select or enter SQL server instance name", "Run Command", MessageBoxButton.OK, MessageBoxImage.Error);
                    return true;
                }
            }
            catch
            {
                Microsoft.Windows.Controls.MessageBox.Show("Please select or enter SQL server instance name", "Run Command", MessageBoxButton.OK, MessageBoxImage.Error);
                return true;
            }
            */

            
            if (this.radioButtonWindowsAuth.IsChecked == true)
            {
                this.Authentication  = 0;
            }
            else
            {
                this.Authentication = 1;
            }
           
            BindingExpression be1 = this.txtBoxServerName.GetBindingExpression(TextBox.TextProperty);
            BindingExpression be2 = this.txtBoxDatabase.GetBindingExpression(TextBox.TextProperty);
            BindingExpression be3 = this.txtBoxUserName.GetBindingExpression(TextBox.TextProperty);
            be3.UpdateSource();

           if (be1.HasError ||be2.HasError || be3.HasError )
           // if (be2.HasError || be3.HasError)
            {
                Microsoft.Windows.Controls.MessageBox.Show("Please correct the errors first", "Run Command", MessageBoxButton.OK, MessageBoxImage.Error);
            
                return true; 
            }
         
          
           if (this.radioButtonSqlAuth.IsChecked == true)
            {
                    if (String.IsNullOrEmpty(this.txtBoxPassword.Password))
                    {
                        Microsoft.Windows.Controls.MessageBox.Show(Properties.Resource.NewDataSource_txtBlockMessagesPasswordEmpty, "Run Command", MessageBoxButton.OK, MessageBoxImage.Error);
            
                        return true; 
                    }

            }

           
           
                         

            return false;


        }
          

       
       
        

        private void radioButtonWindowsAuth_Checked(object sender, RoutedEventArgs e)
        {
            this.txtBoxUserName.IsEnabled = false;
            this.txtBoxPassword.IsEnabled = false;

            BindingExpression be = this.txtBoxUserName.GetBindingExpression(TextBox.TextProperty);
            be.UpdateSource();
        }

        private void radioButtonSqlAuth_Checked(object sender, RoutedEventArgs e)
        {
            this.txtBoxUserName.IsEnabled = true;
            this.txtBoxPassword.IsEnabled = true;
            BindingExpression be = this.txtBoxUserName.GetBindingExpression(TextBox.TextProperty);
            be.UpdateSource();
            
        }

        public string ServerInstance
        {
            get
            {
                return serverInstance;
            }
            set
            {
                serverInstance = value;
                if (String.IsNullOrEmpty(serverInstance.Trim()))
                {
                    this.txtBoxServerName.ToolTip = Properties.Resource.NewDataSource_txtBlockMessagesServerEmpty;
                   // this.cmbBoxServerName.ToolTip = Properties.Resource.NewDataSource_txtBlockMessagesServerEmpty;
                   
                    throw new ApplicationException(Properties.Resource.NewDataSource_txtBlockMessagesServerEmpty);
                 
                }
                else
                {
                    this.txtBoxServerName.ToolTip = null;
                   // this.cmbBoxServerName.ToolTip = null;
                }
            }
        }

        public string DatabaseName
        {
            get
            {
                return databaseName;
            }
            set
            {
                databaseName = value;
                if (String.IsNullOrEmpty(databaseName.Trim()))
                {
                    this.txtBoxDatabase.ToolTip = Properties.Resource.NewDataSource_txtBlockMessagesSelectDatabaseName;
                    throw new ApplicationException(Properties.Resource.NewDataSource_txtBlockMessagesSelectDatabaseName);

                }
                else
                {
                    this.txtBoxDatabase.ToolTip = null;
                }
            }
        }


        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                if (this.radioButtonSqlAuth.IsChecked == true)
                {
                    userName = value;
                    if (String.IsNullOrEmpty(userName))
                    {
                        this.txtBoxUserName.ToolTip = Properties.Resource.NewDataSource_txtBlockMessagesUserNameEmpty;
                        throw new ApplicationException(Properties.Resource.NewDataSource_txtBlockMessagesUserNameEmpty);

                    }
                    else
                    {
                        this.txtBoxUserName.ToolTip = null;
                    }
                }
            }
        }




        public void UpdateStatus(string status)
        {
        }

        private CreateMode mode;
        public CreateMode Mode
        {
            set
            {
                mode = value;
                
                if (mode == CreateMode.NewEmptyDatabase)
                {
                    this.txtBlockHeading.Text = "Create a new database";
                    this.DatabaseName = "possite";
                    return;
                }
                if (mode == CreateMode.ExistingDatabase)
                {
                    this.txtBlockHeading.Text = "Use an existing database";
                    this.DatabaseName = "possite";
                    return;
                }
            }
            get
            {
                return mode;
            }

            

        }

        public void SetOKBtnDataContext(object command)
        {
            this.btnOK.DataContext = command;
        }

        private void txtBoxPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            this.Password = this.txtBoxPassword.Password;
        }

        public string Password
        {
            set
            {
                password = value;
            }
            get
            {
                return password;
            }
        }

        public int Authentication
        {
            set
            {
                auth = value;
            }
            get
            {
                return auth;
            }
        }


        public bool IncludeSampleData
        {
            set
            {
                includeSampleData = value;
            }
            get
            {
                return includeSampleData;
            }
        }


        public void CloseView()
        {
            //this.Close();
        }

        /// This method is used to start Synchronization Animation
        /// </summary>
         public void StartSyncAnimation()
         {
             this.busyIndicator.IsBusy = true;
         }
         

        /// <summary>
        /// This method is used to end Synchronization Animation
        /// </summary>
         public void EndSyncAnimation()
         {
             this.busyIndicator.IsBusy = false;
         }

        /*
         private void LoadServerInstances()
         {
             SqlDataSourceEnumerator side = SqlDataSourceEnumerator.Instance;
             DataTable table = side.GetDataSources();
             foreach (DataRow row in table.Rows)
             {
                 this.cmbBoxServerName.Items.Add(row["ServerName"].ToString() + "\\" + row["InstanceName"].ToString());
             }
         }
         * */

    }
}
