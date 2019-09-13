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
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections;
using EclipsePOS.WPF.SystemManager.PosSetup.Util;

namespace EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.Views.TaxDetail
{
    /// <summary>
    /// Interaction logic for TaxDetailsViewPresenter.xaml
    /// </summary>
    public partial class TaxDetailsView : UserControl, ITaxDetailsView
    {
        private TaxDetailsViewPresenter _presenter;

        private DateTime salesDateFrom;
        private DateTime salesDateTo;
        private string storeNoFrom;
        private string storeNoTo;
        private string organizationNoFrom;
        private string organizationNoTo;


        public TaxDetailsView()
        {
            InitializeComponent();
            this.rootControl.SizeChanged += new SizeChangedEventHandler(rootControl_SizeChanged);

            this.datePickerTo.SelectedDateChanged +=new EventHandler<SelectionChangedEventArgs>(datePickerTo_SelectedDateChanged);
            this.datePickerFrom.SelectedDateChanged +=new EventHandler<SelectionChangedEventArgs>(datePickerFrom_SelectedDateChanged);
            this.cmbBoxStoreIDFrom.SelectionChanged += new SelectionChangedEventHandler(cmbBoxStoreIDFrom_SelectionChanged);
            this.cmbBoxStoreIDTo.SelectionChanged += new SelectionChangedEventHandler(cmbBoxStoreIDTo_SelectionChanged);
            this.cmbBoxOrganizationIDFrom.SelectionChanged += new SelectionChangedEventHandler(cmbBoxOrganizationIDFrom_SelectionChanged);
            this.cmbBoxOrganizationIDTo.SelectionChanged += new SelectionChangedEventHandler(cmbBoxOrganizationIDTo_SelectionChanged);

        }

        void  datePickerTo_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
     	    this.salesDateTo = (DateTime)datePickerTo.SelectedDate;
        }

        void  datePickerFrom_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            this.salesDateFrom = (DateTime)datePickerFrom.SelectedDate;	
        }

        void rootControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.rootControl.Height = Math.Ceiling(Application.Current.MainWindow.ActualHeight * 0.82); 
        }

        void cmbBoxOrganizationIDTo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                organizationNoTo = this.cmbBoxOrganizationIDTo.SelectedValue.ToString();
            }
            catch
            {
                organizationNoTo = PosSettings.Default.Organization;
            }
        }

        void cmbBoxOrganizationIDFrom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                organizationNoFrom = this.cmbBoxOrganizationIDFrom.SelectedValue.ToString();
            }
            catch
            {
                organizationNoFrom = PosSettings.Default.Organization;
            }
        }

        void cmbBoxStoreIDTo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                storeNoTo = this.cmbBoxStoreIDTo.SelectedValue.ToString();
            }
            catch
            {
                storeNoTo = PosSettings.Default.Store;
            }
        }

        void cmbBoxStoreIDFrom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                storeNoFrom = this.cmbBoxStoreIDFrom.SelectedValue.ToString();
            }
            catch
            {
                storeNoFrom = PosSettings.Default.Store;
            }
        }

        



        public TaxDetailsView(TaxDetailsViewPresenter presenter):this()
        {
            this._presenter = presenter;
            this._presenter.View = this;
            this.Loaded += new RoutedEventHandler(TaxDetailsView_Loaded);
           

        }

        void TaxDetailsView_Loaded(object sender, RoutedEventArgs e)
        {
            this.LoadResources();
            this._presenter.OnShowTaxDetails();
            this.SetSelectionDefaults();
        }

        private void LoadResources()
        {
            base.Resources.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri(@"EclipsePOS.WPF.SystemManager.Infrastructure;;;component/Skins/BaseSkin.xaml", UriKind.Relative)));
       
        }

        public void SetOrganizationFromDataContext(IEnumerable data)
        {
            this.cmbBoxOrganizationIDFrom.ItemsSource = data;
        }

        public void SetOrganizationToDataContext(IEnumerable data)
        {
            this.cmbBoxOrganizationIDTo.ItemsSource = data;
        }

        public void SetRunBtnDataContext(object command)
        {
            this.btnRun.DataContext = command;
        }


        private void SetSelectionDefaults()
        {
            try
            {
                this.cmbBoxStoreIDFrom.SelectedValue = PosSettings.Default.Store;
                this.cmbBoxStoreIDTo.SelectedValue = PosSettings.Default.Store;
                this.cmbBoxOrganizationIDFrom.SelectedValue = PosSettings.Default.Organization;
                this.cmbBoxOrganizationIDTo.SelectedValue = PosSettings.Default.Organization;
                this.datePickerFrom.SelectedDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                this.datePickerTo.SelectedDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }


        public void SetRetailStoreFromDataContext(IEnumerable data)
        {
            this.cmbBoxStoreIDFrom.ItemsSource = data;
        }


        public void SetRetailStoreToDataContext(IEnumerable data)
        {
            this.cmbBoxStoreIDTo.ItemsSource = data;
        }

        public string StoreNoFrom
        {
            get
            {
                return storeNoFrom;
            }
        }

        public string StoreNoTo
        {
            get
            {
                return storeNoTo;
            }
        }

        public string OrganizationNoFrom
        {
            get
            {
                return organizationNoFrom;
            }
        }

        public string OrganizationNoTo
        {
            get
            {
                return organizationNoTo;
            }
        }


        public DateTime SalesDateFrom
        {
            get
            {
                return salesDateFrom;
            }
        }

        public DateTime SalesDateTo
        {
            get
            {
                return salesDateTo;
            }
        }

        /// <summary>
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



    }
}
