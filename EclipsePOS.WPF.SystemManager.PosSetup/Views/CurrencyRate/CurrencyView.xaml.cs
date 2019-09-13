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

namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.CurrencyRate
{
    /// <summary>
    /// Interaction logic for CurrencyView.xaml
    /// </summary>
    public partial class CurrencyView : UserControl, ICurrencyView
    {
        private CurrencyViewPresenter _presenter;

        public CurrencyView()
        {
            InitializeComponent();
        }

        public CurrencyView(CurrencyViewPresenter presenter):this()
        {
            this._presenter = presenter;
            this._presenter.View = this;

            this.Loaded += new RoutedEventHandler(CurrencyView_Loaded);
            this.rootControl.SizeChanged += new SizeChangedEventHandler(rootControl_SizeChanged);
           // this.cmbBoxOrganizationID.SelectionChanged += new SelectionChangedEventHandler(cmbBoxOrganizationID_SelectionChanged);
           // this.cmbBoxOrganizationID.SelectedValue = PosSettings.Default.Organization;
            this.txtBoxConversionRate.PreviewTextInput += new TextCompositionEventHandler(txtBoxConversionRate_PreviewTextInput);
         
        }

        void txtBoxConversionRate_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !AreAllValidAmount(e.Text);
        }

       

      //  void cmbBoxOrganizationID_SelectionChanged(object sender, SelectionChangedEventArgs e)
      //  {
      //      this._presenter.FilterCurrencyByOrganizationNo(int.Parse(this.cmbBoxOrganizationID.SelectedValue.ToString()));
      // 
      //  }

        void rootControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.rootControl.Height = Math.Ceiling(Application.Current.MainWindow.ActualHeight * 0.82); 
        }



        void CurrencyView_Loaded(object sender, RoutedEventArgs e)
        {
            this.LoadResources();

            _presenter.OnShowCurrency();
        }



        private void LoadResources()
        {
            base.Resources.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri(@"EclipsePOS.WPF.SystemManager.Infrastructure;;;component/Skins/BaseSkin.xaml", UriKind.Relative)));
        }


        #region Events

        public void OnCurrencyListView_SelectionChanged(object sender, RoutedEventArgs e)
        {

            object selectedItem = ((ListView)e.Source).SelectedItem;

        }


        #endregion

        #region ICurrencyCode implementations

        public void SetCurrencyDataContext(object data)
        {
            this.currencyListView.DataContext = data;
            this.DataContext = data;
        }

        public void SetHomeCurrencyCodeDataContext(IEnumerable data)
        {
            this.cmbBoxHomeCurrencyCode.ItemsSource = data;
        }

        public void SetSourceCurrencyCodeDataContext(IEnumerable data)
        {
            this.cmbBoxSourceCurrencyCode.ItemsSource = data;
            
        }



        public void SetSelectedItemCursor()
        {
            currencyListView.ScrollIntoView(currencyListView.Items.CurrentItem);
            currencyListView.SelectedItem = currencyListView.Items.CurrentItem;
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
        
        
       

        #endregion

        public void SetFocusToFirstElement()
        {
            //this.cmbBoxCurrencyCode.Focus();
        }

        private bool AreAllValidAmount(string str)
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
