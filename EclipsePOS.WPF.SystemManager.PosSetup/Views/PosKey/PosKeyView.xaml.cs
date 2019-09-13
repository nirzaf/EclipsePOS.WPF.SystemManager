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
using EclipsePOS.WPF.SystemManager.Infrastructure.Constants;

namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.PosKey
{
    /// <summary>
    /// Interaction logic for PosKeyView.xaml
    /// </summary>
    public partial class PosKeyView : Window, IPosKey
    {
        private PosKeyPresenter _presenter;
        private int response = -1;


        public PosKeyView()
        {
            InitializeComponent();
            this.btnOK.Click += new RoutedEventHandler(btnOK_Click);
            this.btnCancel.Click += new RoutedEventHandler(btnCancel_Click);
            this.Loaded += new RoutedEventHandler(PosKeyView_Loaded);
            this.Closing += new System.ComponentModel.CancelEventHandler(PosKeyView_Closing);

            //this.txtBoxKeyText.PreviewTextInput += new TextCompositionEventHandler(txtBoxKeyText_PreviewTextInput);
            this.txtBoxKeyText.TextChanged += new TextChangedEventHandler(txtBoxKeyText_TextChanged);
            this.txtBoxImage.TextChanged += new TextChangedEventHandler(txtBoxImage_TextChanged);
            this.txtBoxParam.TextChanged += new TextChangedEventHandler(txtBoxParam_TextChanged);

            this.cmbBoxAttr.SelectionChanged += new SelectionChangedEventHandler(cmbBoxAttr_SelectionChanged);
            this.cmbBoxKeyClass.SelectionChanged += new SelectionChangedEventHandler(cmbBoxKeyClass_SelectionChanged);

            this.txtBoxKeyVal.PreviewTextInput += new TextCompositionEventHandler(txtBoxKeyVal_PreviewTextInput);
            this.txtBoxKeyCode.PreviewTextInput += new TextCompositionEventHandler(txtBoxKeyCode_PreviewTextInput);
        }

        void cmbBoxKeyClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BindingExpression be2 = this.cmbBoxKeyClass.GetBindingExpression(ComboBox.SelectedValueProperty);
            be2.UpdateSource();
        }

        void cmbBoxAttr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BindingExpression be4 = this.cmbBoxAttr.GetBindingExpression(ComboBox.SelectedValueProperty);
            be4.UpdateSource();
   
        }

        void txtBoxKeyCode_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !AreAllValidNumericChars(e.Text);
        }

        void txtBoxKeyVal_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !AreAllValidNumericChars(e.Text);
        }

        void txtBoxParam_TextChanged(object sender, TextChangedEventArgs e)
        {
            BindingExpression be5 = this.txtBoxParam.GetBindingExpression(TextBox.TextProperty);
            be5.UpdateSource();
        }

        void txtBoxImage_TextChanged(object sender, TextChangedEventArgs e)
        {
            BindingExpression be6 = this.txtBoxImage.GetBindingExpression(TextBox.TextProperty);
            be6.UpdateSource();

        }

        void txtBoxKeyText_TextChanged(object sender, TextChangedEventArgs e)
        {
            BindingExpression be = this.txtBoxKeyText.GetBindingExpression(TextBox.TextProperty);
            be.UpdateSource();
        }

        
        void PosKeyView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
           
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, (DispatcherOperationCallback)delegate(object o)
            {
                Hide();
                return null;
            }, null);

        }

        void PosKeyView_Loaded(object sender, RoutedEventArgs e)
        {
            // Merge resoure directory
            base.Resources.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri(@"EclipsePOS.WPF.SystemManager.Infrastructure;;;component/Skins/BaseSkin.xaml", UriKind.Relative)));

            BindingExpression be1 = this.txtBoxKeyText.GetBindingExpression(TextBox.TextProperty);
            be1.UpdateSource();

            BindingExpression be2 = this.cmbBoxKeyClass.GetBindingExpression(ComboBox.SelectedValueProperty);
            be2.UpdateSource();

            
            BindingExpression be3 = this.txtBoxKeyCode.GetBindingExpression(TextBox.TextProperty);
            be3.UpdateSource();

            BindingExpression be4 = this.cmbBoxAttr.GetBindingExpression(ComboBox.SelectedValueProperty);
            be4.UpdateSource();

                      
            BindingExpression be5 = this.txtBoxParam.GetBindingExpression(TextBox.TextProperty);
            be5.UpdateSource();

            BindingExpression be6 = this.txtBoxImage.GetBindingExpression(TextBox.TextProperty);
            be6.UpdateSource();

            this.SetFocusToFirstElement();


        }




        void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            response = -1;
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, (DispatcherOperationCallback)delegate(object o)
           {
               Hide();
               return null;
           }, null);
        }

        void btnOK_Click(object sender, RoutedEventArgs e)
        {
            BindingExpression be1 = this.txtBoxKeyText.GetBindingExpression(TextBox.TextProperty);
            BindingExpression be2 = this.txtBoxImage.GetBindingExpression(TextBox.TextProperty);
            BindingExpression be3 = this.txtBoxParam.GetBindingExpression(TextBox.TextProperty);
            BindingExpression be4 = this.cmbBoxKeyClass.GetBindingExpression(ComboBox.SelectedValueProperty);
            BindingExpression be5 = this.cmbBoxAttr.GetBindingExpression(ComboBox.SelectedValueProperty);
            
            if (be1.HasError || be2.HasError || be3.HasError || be4.HasError || be5.HasError)
            {
                Microsoft.Windows.Controls.MessageBox.Show("Please fill in the compulsory fields", "OK command", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                response = 1;
                //this.Close();
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, (DispatcherOperationCallback)delegate(object o)
                {
                    Hide();
                    return null;
                }, null);

            }
           
        }

        public PosKeyView(PosKeyPresenter presenter):this()
        {
            this._presenter = presenter;
            this._presenter.View = this;

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

        public void SetDataContext(object data)
        {
           this.DataContext = data;
        }


        public void SetFocusToFirstElement()
        {
          this.txtBoxKeyText.Focus();
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
