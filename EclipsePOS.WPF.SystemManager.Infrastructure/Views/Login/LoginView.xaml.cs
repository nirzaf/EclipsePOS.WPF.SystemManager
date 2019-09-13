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
using EclipsePOS.WPF.SystemManager.Infrastructure.Constants;
using EclipsePOS.WPF.SystemManager.Data.Util;
using Microsoft.Practices.Unity;
using EclipsePOS.WPF.SystemManager.Infrastructure.Services;
using System.Security.Cryptography;



namespace EclipsePOS.WPF.SystemManager.Infrastructure.Views.Login
{
    /// <summary>
    /// Interaction logic for LoginView.xaml-
    /// </summary>
    public partial class LoginView : Window, ILoginView
    {
        private IUnityContainer _container;

        public LoginView(IUnityContainer container)
        {
            this._container = container;
            InitializeComponent();
            this.btnSubmit.Click += new RoutedEventHandler(btnSubmit_Click);
            this.Closing += new System.ComponentModel.CancelEventHandler(LoginView_Closing);
            
            //Merge Dictonary
        }

        void LoginView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            //work around for not being able to hide a window during closing. This behavior was needed in WPF to ensure consistent window
            //visiblity state
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, (DispatcherOperationCallback)delegate(object o)
            {
                Hide();
                return null;
            }, null);
            


        }

        void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (!IsFieldsEmpty())
            {
                if (ValidateUser())
                {
                    //Properties.Settings.Default.SecurityToken = txtUserTextBox.Text;
                    //Properties.Settings.Default.Save();
                    //User user = new User();
                    User user = _container.Resolve<User>();
                    user.UserName = this.txtUserTextBox.Text;
                    user.Password= this.txtPasswordTextBox.Password; 
                    _container.RegisterInstance<User>(user);
                    this.Close();
                   
                }
            }
            
        }

        public bool IsFieldsEmpty()
        {
           
            if (String.IsNullOrEmpty(txtUserTextBox.Text))
            {
                ShowMessage(Properties.Resources.UserNameRequired);
                return true;
            }

            if (String.IsNullOrEmpty(txtPasswordTextBox.Password))
            {
                ShowMessage(Properties.Resources.PasswordRequired);
                return true;
            }

            return false;
        }

        public bool ValidateUser()
        {
            string conn = PosSettings.Default.possiteConnectionString;
            DataClasses1DataContext dataContext = new DataClasses1DataContext(conn);
            try
            {
                var userInfo = from sub in dataContext.subs where sub.subscriber_name.Equals(this.txtUserTextBox.Text.Trim()) select sub;//from sub in dataContext.subs select sub;
                foreach (sub s in userInfo)
                {
                   /* if (s.subscriber_pass == this.txtPasswordTextBox.Password)
                    {
                        return true;
                    }
                    else
                    {
                        ShowMessage(Properties.Resources.InvalidUserName);
                        return false;
                    }
                    * */
                    if (this.verifyMd5Hash(this.txtPasswordTextBox.Password.ToString(), s.subscriber_pass))
                    {
                        return true;
                    }
                    else
                    {
                        ShowMessage(Properties.Resources.InvalidUserName);
                        return false;
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException exp)
            {
                MessageBox.Show("Data source not found. Please setup the data soruce" );
 
            }

            ShowMessage(Properties.Resources.InvalidUserName);
            return false;
            
        }

       

        #region IloginView members

        public void ShowMessage(string message)
        {
            txtMessageBox.Text = message;
        }


        public void LoadResources()
        {
            txtUserText.Text = Properties.Resources.LoginView_UserId;
            txtPasswordText.Text = Properties.Resources.LoginView_Password;

            // Merge resoure directory
            base.Resources.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri(@"EclipsePOS.WPF.SystemManager.Infrastructure;;;component/Skins/BaseSkin.xaml", UriKind.Relative)));
            this.txtUserTextBox.Focus();
        }

        public void  ShowLoginDialog()
        {
            if (this.Owner == null)
            {
                this.Owner = Application.Current.MainWindow;
            }
            
           this.ShowDialog();
           
           
        }

        // Hash an input string and return the hash as
        // a 32 character hexadecimal string.
        private string getMd5Hash(string input)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            MD5 md5Hasher = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        private bool verifyMd5Hash(string input, string hash)
        {
            // Hash the input.
            string hashOfInput = getMd5Hash(input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }




      
        #endregion
    }
}
