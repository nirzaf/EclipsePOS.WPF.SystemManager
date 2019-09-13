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
using System.Collections;




namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.PosConfigInput
{
    /// <summary>
    /// Interaction logic for InputConfigNoView.xaml
    /// </summary>
    public partial class InputConfigNoView : Window, IInputConfigNoView
    {
        private InputConfigNoPresenter _presenter;

        private int response = -1 ;

        public InputConfigNoView()
        {
            InitializeComponent();

            this.btnOK.Click += new RoutedEventHandler(btnOK_Click);
            this.btnCancel.Click += new RoutedEventHandler(btnCancel_Click);
            this.Closing += new System.ComponentModel.CancelEventHandler(InputConfigNoView_Closing);
            this.txtBoxConfigNo.TextChanged += new TextChangedEventHandler(txtBoxConfigNo_TextChanged);

            this.txtBoxConfigNo.PreviewTextInput += new TextCompositionEventHandler(txtBoxConfigNo_PreviewTextInput); 
        }

        void txtBoxConfigNo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !AreAllValidNumericChars(e.Text);
        }

        void txtBoxConfigNo_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.txtMessageBox.Text = "";
            this.response = -1;
        }

        void InputConfigNoView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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

        void btnCancel_Click(object sender, RoutedEventArgs e)
        {
           // e..Cancel = true;
            //work around for not being able to hide a window during closing. This behavior was needed in WPF to ensure consistent window
            //visiblity state
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, (DispatcherOperationCallback)delegate(object o)
            {
                Hide();
                return null;
            }, null);


        }

        void btnOK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                response = int.Parse(this.txtBoxConfigNo.Text);

                if (response > 0 || response < 9999999)
                {
                    Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, (DispatcherOperationCallback)delegate(object o)
                    {
                        Hide();
                        return null;
                    }, null);
                }
                else
                {
                    txtMessageBox.Text = "Please enter valid number that between 0 - 9999999";
                }

            }
            catch
            {
                txtMessageBox.Text = "Please enter valid number that between 0 - 9999999"; 
            }
        }

        public InputConfigNoView(InputConfigNoPresenter presenter)
            : this()
        {
            this._presenter = presenter;
            this._presenter.View = this;

            this.Loaded += new RoutedEventHandler(InputConfigNoView_Loaded);
        }

        void InputConfigNoView_Loaded(object sender, RoutedEventArgs e)
        {
            this.LoadResources();
            _presenter.OnShowInputConfigNo();
        }

        public void LoadResources()
        {
            // Merge resoure directory
            base.Resources.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri(@"EclipsePOS.WPF.SystemManager.Infrastructure;;;component/Skins/BaseSkin.xaml", UriKind.Relative)));
        }

        public int ShowInputDialog()
        {
            
            if (this.Owner == null)
            {
                this.Owner = Application.Current.MainWindow;
            }

            this.ShowDialog();
            
            return response;



        }

        public int CopyFromConfigNo
        {
            set
            {
                this.cmbBoxCopyFromConfigNo.SelectedItem = value;
            }
            get
            {
                if (this.cmbBoxCopyFromConfigNo.SelectedIndex >= 0)
                {
                    return int.Parse(this.cmbBoxCopyFromConfigNo.SelectedValue.ToString());
                }
                else
                {
                    return 0;
                }
            }
        }

        public void SetPosConfigDataContext(IEnumerable data)
        {
            this.cmbBoxCopyFromConfigNo.ItemsSource = data;
        }

        private bool AreAllValidNumericChars(string str)
        {
            bool ret = true;
            
            int l = str.Length;
            for (int i = 0; i < l; i++)
            {
                char ch = str[i];
                ret &= Char.IsDigit(ch);
            }

            if (!ret) Commands.Beep(500, 50);
            return ret;
        }




    }
}
