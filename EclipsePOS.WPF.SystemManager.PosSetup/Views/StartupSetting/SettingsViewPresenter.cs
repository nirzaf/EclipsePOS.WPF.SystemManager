using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Composite.Presentation.Events;
using Microsoft.Practices.Composite.Presentation.Commands;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows;
using EclipsePOS.WPF.SystemManager.PosSetup.Util;

namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.StartupSetting
{
    
    public class SettingsViewPresenter
    {
        private EclipsePOS.WPF.SystemManager.Data.organizationLookupDataSet organizationData;
        private EclipsePOS.WPF.SystemManager.Data.storeDataSet storeData;
        private EclipsePOS.WPF.SystemManager.Data.stationDataSet stationData;
        private EclipsePOS.WPF.SystemManager.Data.posConfigDataSet posConfigData;

        public DelegateCommand<object> SaveCommand;

        private ISettings _view;



        public SettingsViewPresenter()
        {
            SaveCommand = new DelegateCommand<object>(OnSaveCommandExecute, OnSaveCommandCanExecute);
           
           
        }


        public ISettings View
        {
            get
            {
                return _view;
            }
            set
            {
                this._view = value;
                this.OnShowSettings();
            }
        }

        public void  OnShowSettings()
        {
            //Organization
            organizationData = new EclipsePOS.WPF.SystemManager.Data.organizationLookupDataSet();
            EclipsePOS.WPF.SystemManager.Data.organizationLookupDataSetTableAdapters.organizationTableAdapter organizationTa = new EclipsePOS.WPF.SystemManager.Data.organizationLookupDataSetTableAdapters.organizationTableAdapter();
            organizationTa.Fill(organizationData.organization);
            View.SetOrganizationDataContext(organizationData.organization);

            //Store
            storeData = new EclipsePOS.WPF.SystemManager.Data.storeDataSet();
            EclipsePOS.WPF.SystemManager.Data.storeDataSetTableAdapters.retail_storeTableAdapter storeTa = new EclipsePOS.WPF.SystemManager.Data.storeDataSetTableAdapters.retail_storeTableAdapter();
            storeTa.Fill(storeData.retail_store);
            View.SetStoreDataContext(storeData.retail_store);

            //Station
            stationData = new EclipsePOS.WPF.SystemManager.Data.stationDataSet();
            EclipsePOS.WPF.SystemManager.Data.stationDataSetTableAdapters.posTableAdapter posTa = new EclipsePOS.WPF.SystemManager.Data.stationDataSetTableAdapters.posTableAdapter();
            posTa.Fill(stationData.pos);
            View.SetStationDataContext(stationData.pos);

            //PosConfig
            posConfigData = new EclipsePOS.WPF.SystemManager.Data.posConfigDataSet();
            EclipsePOS.WPF.SystemManager.Data.posConfigDataSetTableAdapters.pos_configTableAdapter posConfigTa = new EclipsePOS.WPF.SystemManager.Data.posConfigDataSetTableAdapters.pos_configTableAdapter();
            posConfigTa.Fill(posConfigData.pos_config);
            View.SetPosConfigDataContext(posConfigData.pos_config);

            View.SetSaveBtnDataContext(SaveCommand);

            FilterAll(PosSettings.Default.Organization, PosSettings.Default.Store);

            View.Organization = PosSettings.Default.Organization;
            View.Store = PosSettings.Default.Store;
            View.Station = PosSettings.Default.Station;

        }

        #region Save Command

        public void OnSaveCommandExecute(object obj)
        {
            //MessageBox.Show("OK");
            View.SaveSettings();
            Microsoft.Windows.Controls.MessageBox.Show("Saved", "Save command", MessageBoxButton.OK, MessageBoxImage.Information );
           // Application.Current.Shutdown();
            
        }

        public bool OnSaveCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion 



        public void FilterAll(string organizationNo, string storeNo)
        {
            this.FilterStoreByOrganization(organizationNo);
            this.FilterStationByOrganizationAndStore(organizationNo, storeNo);
        }


        public void FilterStoreByOrganization(string organizationNo)
        {
            BindingListCollectionView view1 = CollectionViewSource.GetDefaultView(this.storeData.retail_store) as BindingListCollectionView;

            if (view1 != null)
            {
                view1.CustomFilter = "organization_no = '" + organizationNo + "'";

            }
        }

        /*
        public void FilterStationByOrganization(string organizationNo)
        {
            BindingListCollectionView view1 = CollectionViewSource.GetDefaultView(this.stationData.pos) as BindingListCollectionView;

            if (view1 != null)
            {
                string filter = "organization_no = '" + organizationNo+"'";
                view1.CustomFilter = filter ;

            }
        }
        */

        public void FilterStationByOrganizationAndStore(string organizationNo, string storeNo)
        {
            BindingListCollectionView view1 = CollectionViewSource.GetDefaultView(this.stationData.pos) as BindingListCollectionView;

            if (view1 != null)
            {
                string filter = "organization_no = '" + organizationNo + "' and " + "store_no = '" + storeNo + "'";
                view1.CustomFilter = filter;

            }
        }



    }
}
