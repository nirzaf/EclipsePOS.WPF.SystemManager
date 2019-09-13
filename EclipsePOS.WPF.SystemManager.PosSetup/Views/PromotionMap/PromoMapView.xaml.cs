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

using EclipsePOS.WPF.SystemManager.Infrastructure.Constants;

namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.PromotionMap
{
    /// <summary>
    /// Interaction logic for PromoMapView.xaml
    /// </summary>
    public partial class PromoMapView : UserControl, IPromoMapView
    {
        #region Variables
        private PromoMapViewPresenter _presenter;
        #endregion

        #region Properties
       
        private string organization;
        public string Organization
        {
            get { return organization; }
            set { organization = value; }
        }
        
        private int promoNumber;
        public int PromoNumber
        {
            get { return promoNumber; }
            set { promoNumber = value; }
        }
        
        private string promoName;
        public string PromoName
        {
            get { return promoName; }
            set { promoName = value; }
        }
        
        private string validDateFrom;
        public string ValidDateFrom
        {
            get { return validDateFrom; }
            set { validDateFrom = value; }
        }
        
        private string validDateTo;
        public string ValidDateTo
        {
            get { return validDateTo; }
            set { validDateTo = value; }
        }
        
        #endregion


        #region Constructure
        
        public PromoMapView()
        {
            InitializeComponent();
        }
        
        public PromoMapView(PromoMapViewPresenter presenter)
            : this()
        {
            this._presenter = presenter;
            this._presenter.View = this;

            this.Loaded += new RoutedEventHandler(PromoMapView_Loaded);
            this.SizeChanged += new SizeChangedEventHandler(PromoMapView_SizeChanged);

            this.txtBoxFilter.PreviewTextInput += new TextCompositionEventHandler(txtBoxFilter_PreviewTextInput);

            this.radioButtonDescription.Checked += new RoutedEventHandler(radioButtonDescription_Checked);
            this.radioButtonPLU.Checked += new RoutedEventHandler(radioButtonPLU_Checked);
            this.radioButtonSKU.Checked += new RoutedEventHandler(radioButtonSKU_Checked);
        }

        void txtBoxFilter_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (this.radioButtonPLU.IsChecked == true)
            {
                e.Handled = !AreAllValidPLU(e.Text);
            }
        }

        void radioButtonSKU_Checked(object sender, RoutedEventArgs e)
        {
           // this._presenter.FilterItems("sku", this.txtBoxFilter.Text.Trim());
           // this.radioButtonSKU.IsChecked = false;
            this.txtBoxFilter.Text = "";
            Properties.Settings.Default.PromotionMapView_FilterOption = 1;
            Properties.Settings.Default.Save();
        }

        void radioButtonPLU_Checked(object sender, RoutedEventArgs e)
        {
           // this._presenter.FilterItems("plu", this.txtBoxFilter.Text.Trim());
            this.txtBoxFilter.Text = "";
           // this.radioButtonPLU.IsChecked = false;
            Properties.Settings.Default.PromotionMapView_FilterOption = 3;
            Properties.Settings.Default.Save();

        }

        void radioButtonDescription_Checked(object sender, RoutedEventArgs e)
        {
           // this._presenter.FilterItems("short_desc", this.txtBoxFilter.Text.Trim());
            this.txtBoxFilter.Text = "";
           // this.radioButtonDescription.IsChecked = false;
            Properties.Settings.Default.PromotionMapView_FilterOption = 2;
            Properties.Settings.Default.Save();
        }

        #endregion


        void PromoMapView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.rootControl.Height = Math.Ceiling(Application.Current.MainWindow.ActualHeight * 0.82); 
        }

        
        void PromoMapView_Loaded(object sender, RoutedEventArgs e)
        {
            this.LoadResources();

            this.txtBlockPromotionName.Text = this.PromoName;
            this.txtBlockPromotionNumber.Text = this.promoNumber.ToString();
            this.txtBlockValidFrom.Text = this.ValidDateFrom;
            this.txtBlockValidTo.Text = this.ValidDateTo;

            _presenter.OnShowPromoMapView();

           
            switch (Properties.Settings.Default.PromotionMapView_FilterOption)
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

        
        
        #region IPromotionView implementations

        public void SetPromoMapDataContext(object data)
        {
            this.promoMappListView.DataContext = data;
            this.DataContext = data;
        }

        public void SetItemsDataContext(Object data)
        {
            this.itemsListView.DataContext = data;
        }

        


        public void SetSelectedItemCursor()
        {
            this.itemsListView.ScrollIntoView(this.itemsListView.Items.CurrentItem);
            this.itemsListView.SelectedItem = this.itemsListView.Items.CurrentItem;
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

        
        public void SetRevertBtnDataContext(object command)
        {
            this.btnRevert.DataContext = command;
        }

        public void SetSaveBtnDataContext(object command)
        {
            this.btnSave.DataContext = command;
        }

      //  public void SetFilterBtnDataContext(object command)
      //  {
      //      this.btnFilter.DataContext = command;
      //  }

        public void SetSelectBtnDataContext(object command)
        {
            this.btnSelect.DataContext = command;
        }

        public void SetSelectAllBtnDataContext(object command)
        {
            this.btnSelectAll.DataContext = command;
        }


        public void SetCancelBtnDataContext(object command)
        {
            this.btnPromotions.DataContext = command;
        }
        #endregion

      
        
        /* public string GetFilterCriteria()
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
        * 
        */ 



        private void txtBoxFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string filterKey = "plu";

                if (this.radioButtonSKU.IsChecked == true)
                    filterKey = "sku";

                if (this.radioButtonDescription.IsChecked == true)
                    filterKey = "short_desc";


                this._presenter.FilterItems(filterKey, this.txtBoxFilter.Text.Trim());
                this.txtBoxFilter.Text = "";
            }
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




    }
}
