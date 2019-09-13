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

namespace EclipsePOS.WPF.SystemManager.Inventory.Views.Stock
{
    /// <summary>
    /// Interaction logic for StockDiaryView.xaml
    /// </summary>
    public partial class StockDiaryView : UserControl, IStockDiaryView
    {
        private StockDiaryPresenter _presenter;

        public StockDiaryView()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(StockDiaryView_Loaded);
            this.rootControl.SizeChanged += new SizeChangedEventHandler(rootControl_SizeChanged);

            this.cmbBoxOrganizationID.SelectionChanged += new SelectionChangedEventHandler(cmbBoxOrganizationID_SelectionChanged);
            this.txtBoxQuantity.PreviewTextInput += new TextCompositionEventHandler(txtBoxQuantity_PreviewTextInput);
            this.itemsListView.SelectionChanged += new SelectionChangedEventHandler(itemsListView_SelectionChanged);
            this.datePickerReferenceDate.SelectedDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        }

        void itemsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            System.Data.DataRowView dataRow = itemsListView.Items.CurrentItem as System.Data.DataRowView;
            this.txtBoxSku.Text = dataRow["sku"].ToString();
        }

        void txtBoxQuantity_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !AreAllValidNumericChars(e.Text);
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

        void StockDiaryView_Loaded(object sender, RoutedEventArgs e)
        {
            base.Resources.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri(@"EclipsePOS.WPF.SystemManager.Infrastructure;;;component/Skins/BaseSkin.xaml", UriKind.Relative)));

            _presenter.OnShowItems();

            this.cmbBoxOrganizationID.SelectedValue = PosSettings.Default.Organization;

        }

        public StockDiaryView(StockDiaryPresenter presenter)
            : this()
        {
            this._presenter = presenter;
            this._presenter.View = this;
        }




        #region IItemListView implementations

        public void SetItemsDataContext(object data)
        {
            this.itemsListView.DataContext = data;
           
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

        public void SetFocusToFirstInputField()
        {
            this.txtBoxSku.Focus();
        }


        #endregion
       
        
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


        public DateTime GetSelectedDate()
        {
            return this.datePickerReferenceDate.SelectedDate.Value;
        }

        public string GetSKU()
        {
            return this.txtBoxSku.Text;
        }


        public string GetReference()
        {
            return this.txtBoxReference.Text;
        }


        public double GetQuantity()
        {
            return double.Parse(txtBoxQuantity.Text);
        }


        public int GetTransactionType()
        {
            return int.Parse(this.cmbBoxTransactionType.SelectedValue.ToString() );
        }

        public void InitInput()
        {
            this.txtBoxQuantity.Text = "1";
            this.txtBoxSku.Text = "";
            this.txtBoxReference.Text = "";
           
        }




    }
}
