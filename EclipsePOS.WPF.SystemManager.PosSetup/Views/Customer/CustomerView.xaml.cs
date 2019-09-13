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
using System.Collections;
using EclipsePOS.WPF.SystemManager.PosSetup.Util;

using EclipsePOS.WPF.SystemManager.Infrastructure.Constants;



namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.Customer
{
    /// <summary>
    /// Interaction logic for CustomerView.xaml
    /// </summary>
    public partial class CustomerView : UserControl,ICustomerView
    {
        private CustomerViewPresenter _presenter;

        public CustomerView()
        {
            InitializeComponent();
        }

        public CustomerView(CustomerViewPresenter presernter):this()
        {
            this._presenter = presernter;
            this._presenter.View = this;

                     
            this.Loaded += new RoutedEventHandler(CustomerView_Loaded);

            this.rootControl.SizeChanged += new SizeChangedEventHandler(rootControl_SizeChanged);

            this.cmbBoxOrganizationID.SelectionChanged += new SelectionChangedEventHandler(cmbBoxOrganizationID_SelectionChanged);
            // this.cmbBoxOrganizationID.SelectedValue = PosSettings.Default.Organization;

            this.txtBoxMaxDebt.PreviewTextInput += new TextCompositionEventHandler(txtBoxMaxDebt_PreviewTextInput);

            
        }

        void CustomerView_Loaded(object sender, RoutedEventArgs e)
        {
            base.Resources.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri(@"EclipsePOS.WPF.SystemManager.Infrastructure;;;component/Skins/BaseSkin.xaml", UriKind.Relative)));

            _presenter.OnShowCustomer();

            this.cmbBoxOrganizationID.SelectedValue = PosSettings.Default.Organization;   
        }

        void txtBoxMaxDebt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !AreAllValidNumericChars(e.Text);
        }

        void cmbBoxOrganizationID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                this._presenter.FilterCustomerByOrganizationNo(this.cmbBoxOrganizationID.SelectedValue.ToString());
            }
            catch
            {
                this._presenter.FilterCustomerByOrganizationNo(PosSettings.Default.Organization);
            }
          

        }


        void rootControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.rootControl.Height = Math.Ceiling(Application.Current.MainWindow.ActualHeight * 0.82); 
        }

       

        public void OnCustomerListView_SelectionChanged(object sender, RoutedEventArgs e)
        {

            //object selectedItem = ((ListView)e.Source).SelectedItem;

        }


        


        

        #region ICustomerView implementations

        public void SetCustomerDataContext(object data)
        {
            this.customerListView.DataContext = data;
            this.DataContext = data;
        }
        

        public void SetOrganizationDataContext(IEnumerable data)
        {
            this.cmbBoxOrganizationID.ItemsSource = data;
        }

        



        public void SetSelectedItemCursor()
        {
            this.customerListView.ScrollIntoView(customerListView.Items.CurrentItem);
            customerListView.SelectedItem = customerListView.Items.CurrentItem;
        }

        public void SetMoveToFirstBtnDataContext(object command)
        {
            this.btnMoveFirst.DataContext = command;
        }

        public void SetMoveToPreviousBtnDataContext(object command)
        {
            this.btnMovePrevious.DataContext = command;
        }

        public void SetMoveToNextBtnDataContext(object command)
        {
            this.btnMoveNext.DataContext = command;
        }

        public void SetMoveToLastBtnDataContext(object command)
        {
            this.btnMoveLast.DataContext = command;
        }


        public void SetDeleteBtnDataContext(object command)
        {
            this.btnDelete.DataContext = command;
        }

        public void SetAddBtnDataContext(object command)
        {
            this.btnAdd.DataContext = command;
        }

        public void SetRevertBtnDataContext(object command)
        {
            this.btnRevert.DataContext = command;
        }

        public void SetSaveBtnDataContext(object command)
        {
            this.btnSave.DataContext = command;
        }
        
        
        public string SelectedOrganizationNo()
        {
            string orgID = "";

            try
            {
                orgID = this.cmbBoxOrganizationID.SelectedValue.ToString();
            }
            catch
            {
            }

            return orgID;
        }

        #endregion

        public void SetFocusToFirstElement()
        {
            this.txtBoxTaxId.Focus();
        }

        private bool AreAllValidNumericChars(string str)
        {
            bool ret = true;
            if (str == System.Globalization.NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator |
                 str == System.Globalization.NumberFormatInfo.CurrentInfo.CurrencyGroupSeparator |
                 str == System.Globalization.NumberFormatInfo.CurrentInfo.CurrencySymbol |
                 str == System.Globalization.NumberFormatInfo.CurrentInfo.NegativeSign |
                 str == System.Globalization.NumberFormatInfo.CurrentInfo.NegativeInfinitySymbol |
                 str == System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator |
                 str == System.Globalization.NumberFormatInfo.CurrentInfo.NumberGroupSeparator |
                 str == System.Globalization.NumberFormatInfo.CurrentInfo.PercentDecimalSeparator |
                 str == System.Globalization.NumberFormatInfo.CurrentInfo.PercentGroupSeparator |
                 str == System.Globalization.NumberFormatInfo.CurrentInfo.PercentSymbol |
                 str == System.Globalization.NumberFormatInfo.CurrentInfo.PerMilleSymbol |
                 str == System.Globalization.NumberFormatInfo.CurrentInfo.PositiveInfinitySymbol |
                 str == System.Globalization.NumberFormatInfo.CurrentInfo.PositiveSign)
                return ret;


            int l = str.Length;
            for (int i = 0; i < l; i++)
            {
                char ch = str[i];
                ret &= Char.IsDigit(ch);
            }

            if (!ret) Commands.Beep(500, 50);
            return ret;

        }


        public void SetColumnsEnabled(bool flag)
        {

            int count = VisualTreeHelper.GetChildrenCount(this.dataGrid);
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    UIElement child = (UIElement)VisualTreeHelper.GetChild(this.dataGrid, i);
                    if (child is TextBox)
                    {
                        ((TextBox)child).IsEnabled = flag;
                    }
                    if (child is ComboBox)
                    {
                        ((ComboBox)child).IsEnabled = flag;
                    }
                }
            }




        }



    }
}
