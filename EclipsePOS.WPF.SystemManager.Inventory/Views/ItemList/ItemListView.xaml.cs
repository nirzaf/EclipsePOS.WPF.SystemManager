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



namespace EclipsePOS.WPF.SystemManager.Inventory.Views.ItemList
{
    /// <summary>
    /// Interaction logic for ItemList.xaml
    /// </summary>
    public partial class ItemListView : UserControl, IItemListView
    {
        private ItemListViewPresenter _presenter;
         
        public ItemListView()
        {
            InitializeComponent();
            
        }

        public ItemListView(ItemListViewPresenter presenter):this()
        {
            this._presenter = presenter;
            _presenter.View = this;

           
            this.Loaded += new RoutedEventHandler(ItemListView_Loaded);
            this.rootControl.SizeChanged += new SizeChangedEventHandler(rootControl_SizeChanged);
            this.cmbBoxOrganizationID.SelectionChanged += new SelectionChangedEventHandler(cmbBoxOrganizationID_SelectionChanged);
            
            
            this.radioButtonDescription.Checked += new RoutedEventHandler(radioButtonDescription_Checked);
            this.radioButtonPLU.Checked += new RoutedEventHandler(radioButtonPLU_Checked);
            this.radioButtonSKU.Checked += new RoutedEventHandler(radioButtonSKU_Checked);

            this.txtBoxUnitPrice.PreviewTextInput += new TextCompositionEventHandler(txtBoxUnitPrice_PreviewTextInput);
           // this.txtBoxPlu.PreviewTextInput += new TextCompositionEventHandler(txtBoxPlu_PreviewTextInput);
            this.txtBoxFilter.PreviewTextInput += new TextCompositionEventHandler(txtBoxFilter_PreviewTextInput);

            this.cmbBoxPricingOpt.SelectionChanged += new SelectionChangedEventHandler(cmbBoxPricingOpt_SelectionChanged);
            this.cmbBoxDepartment.SelectionChanged += new SelectionChangedEventHandler(cmbBoxDepartment_SelectionChanged);
            this.cmbBoxItemGroup.SelectionChanged += new SelectionChangedEventHandler(cmbBoxItemGroup_SelectionChanged);
            this.cmbBoxTaxExempt.SelectionChanged += new SelectionChangedEventHandler(cmbBoxTaxExempt_SelectionChanged);
            this.cmbBoxTaxId.SelectionChanged += new SelectionChangedEventHandler(cmbBoxTaxId_SelectionChanged);
            this.cmbBoxTaxInclusive.SelectionChanged += new SelectionChangedEventHandler(cmbBoxTaxInclusive_SelectionChanged);
        }

        void txtBoxFilter_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (this.radioButtonPLU.IsChecked == true)
            {
                e.Handled = !AreAllValidPLU(e.Text);
            }
        }

        void cmbBoxTaxInclusive_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Properties.Settings.Default.ItemListViewPresenter_Tax_inclusive = short.Parse(this.cmbBoxTaxInclusive.SelectedValue.ToString() );
                Properties.Settings.Default.Save();
            }
            catch
            {
            }
        }

        void cmbBoxTaxId_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Properties.Settings.Default.ItemListViewPresenter_Tax_group =  this.cmbBoxTaxId.SelectedValue.ToString() ;
                Properties.Settings.Default.Save();
            }
            catch
            {
            }
        }

        void cmbBoxTaxExempt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Properties.Settings.Default.ItemListViewPresenter_Tax_excempt = short.Parse(this.cmbBoxTaxExempt.SelectedValue.ToString());
                Properties.Settings.Default.Save();
            }
            catch
            {
            }
        }

        void cmbBoxItemGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Properties.Settings.Default.ItemListViewPresenter_Item_group = this.cmbBoxItemGroup.SelectedValue.ToString();
                Properties.Settings.Default.Save();
            }
            catch { }
        }

        void cmbBoxDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Properties.Settings.Default.ItemListViewPresenter_Dept = this.cmbBoxDepartment.SelectedValue.ToString();
                Properties.Settings.Default.Save();
            }
            catch
            {
            }
        }

        void txtBoxPlu_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !AreAllValidPLU(e.Text);
        }

        void txtBoxUnitPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !this.AreAllValidAmount(e.Text);
        }

        void radioButtonSKU_Checked(object sender, RoutedEventArgs e)
        {
            //this._presenter.FilterItems("sku", this.txtBoxFilter.Text);
            //this.radioButtonSKU.IsChecked = false;
            this.txtBoxFilter.Text = "";
            Properties.Settings.Default.ItemListViewPresenter_FilterOption = 1;
            Properties.Settings.Default.Save();
        }

        void radioButtonPLU_Checked(object sender, RoutedEventArgs e)
        {
            //this._presenter.FilterItems("plu", this.txtBoxFilter.Text);
            //this.radioButtonPLU.IsChecked = false;
            this.txtBoxFilter.Text = "";
            Properties.Settings.Default.ItemListViewPresenter_FilterOption = 3;
            Properties.Settings.Default.Save();
        }

        void radioButtonDescription_Checked(object sender, RoutedEventArgs e)
        {
            //this._presenter.FilterItems("short_desc", this.txtBoxFilter.Text);
            //this.radioButtonDescription.IsChecked = false;
            this.txtBoxFilter.Text = "";
            Properties.Settings.Default.ItemListViewPresenter_FilterOption = 2;
            Properties.Settings.Default.Save();
        }


        void cmbBoxPricingOpt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                 Properties.Settings.Default.ItemListViewPresenter_Pricing_opt = short.Parse(cmbBoxPricingOpt.SelectedValue.ToString());
                 Properties.Settings.Default.Save();
            }
            catch
            {
            }
        }

        void cmbBoxOrganizationID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                this._presenter.FilterItemByOrganizationNo(this.cmbBoxOrganizationID.SelectedValue.ToString());
            }
            catch
            {
                this._presenter.FilterItemByOrganizationNo(PosSettings.Default.Organization);
            }
        }

        void rootControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.rootControl.Height = Math.Ceiling(Application.Current.MainWindow.ActualHeight * 0.82); 
        }

        void ItemListView_Loaded(object sender, RoutedEventArgs e)
        {
            this.LoadResources();

            _presenter.OnShowItems();

            this.cmbBoxOrganizationID.SelectedValue = PosSettings.Default.Organization;

            switch (Properties.Settings.Default.ItemListViewPresenter_FilterOption)
            {
                case 1:
                    this.radioButtonSKU.IsChecked = true;
                    break;
                case 2:
                    this.radioButtonDescription.IsChecked = true;
                    break;
                case 3:
                    this.radioButtonPLU.IsChecked = true;
                    break;
            }


        }

        private void LoadResources()
        {
            base.Resources.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri(@"EclipsePOS.WPF.SystemManager.Infrastructure;;;component/Skins/BaseSkin.xaml", UriKind.Relative)));
        }

        #region IItemListView implementations

        public void SetItemsDataContext(object data)
        {
            this.itemsListView.DataContext = data;
            this.DataContext = data;
        }

        public void SetOrganizationDataContext(IEnumerable data)
        {
            this.cmbBoxOrganizationID.ItemsSource = data;
        }

        public void SetSelectedItemCursor()
        {
            itemsListView.ScrollIntoView(itemsListView.Items.CurrentItem);
            itemsListView.SelectedItem = itemsListView.Items.CurrentItem;
        }

        public void SetMoveToFirstBtnDataContext(object data)
        {
            this.btnMoveFirst.DataContext = data;
        }

        public void SetMoveToPreviousBtnDataContext(object data)
        {
            this.btnMovePrevious.DataContext = data;
        }

        public void SetMoveToNextBtnDataContext(object data)
        {
            this.btnMoveNext.DataContext = data;
        }

        public void SetMoveToLastBtnDataContext(object data)
        {
            this.btnMoveLast.DataContext = data;
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



        public void SetDepartmentDataContext(IEnumerable data)
        {
            this.cmbBoxDepartment.ItemsSource = data;
        }

        public void SetItemGroupDataContext(IEnumerable data)
        {
            this.cmbBoxItemGroup.ItemsSource = data;
        }


        public void SetTaxGroupDataContext(IEnumerable data)
        {
            this.cmbBoxTaxId.ItemsSource  = data;
        }


       /* public void SetFilterBtnDataContext(object command)
        {
           // this.btnFilter.DataContext = command;
        }
        */
        #endregion
        


        #region Events

        public void OnItemListView_SelectionChanged(object sender, RoutedEventArgs e)
        {

            object selectedItem = ((ListView)e.Source).SelectedItem;

            _presenter.OnShowItemDetails(selectedItem);
        }

       
        #endregion

        public string SelectedOrganizationNo()
        {
            string orgId = "";
            try
            {

                orgId = this.cmbBoxOrganizationID.SelectedValue.ToString();
            }
            catch
            {
            }

            return orgId;
        }

       /*     
        public string GetFilterCriteria()
        {
            if (this.radioButtonSKU.IsChecked == true)
                return "sku ";

            if (this.radioButtonDescription.IsChecked == true)
                return "short_desc ";

            if (this.radioButtonPLU.IsChecked == true)
                return "plu ";

            return "sku ";

        }



        public string GetFilterText()
        {
            return this.txtBoxFilter.Text.Trim();
        }
        */

        public void SetFocusToFirstInputField()
        {
            this.txtBoxSku.Focus();
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


        private bool AreAllValidPLU(string str)
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

        private void txtBoxFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string filterKey = "plu ";

                if (this.radioButtonSKU.IsChecked == true)
                filterKey = "sku ";

                if (this.radioButtonDescription.IsChecked == true)
                filterKey = "short_desc ";

                this._presenter.FilterItems( filterKey, this.txtBoxFilter.Text);
                this.txtBoxFilter.Text = "";
                
            }
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
