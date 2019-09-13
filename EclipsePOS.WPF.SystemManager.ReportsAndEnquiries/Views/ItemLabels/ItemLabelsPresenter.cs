using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Composite.Events;
using Microsoft.Practices.Composite.Presentation.Commands;
using Microsoft.Practices.Composite.Regions;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using EclipsePOS.WPF.SystemManager.Data;
using EclipsePOS.WPF.SystemManager.Infrastructure.Constants;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using Microsoft.Practices.Unity;
using EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.ReportingServices;
using EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.Views.XPSDoc;
using System.Windows.Markup;
using System.IO;
using System.Windows.Documents;
using System.Windows.Xps.Packaging;
using EclipsePOS.WPF.SystemManager.Data.Util;
using System.Threading;
using System.Windows.Threading;

using EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.BarcodeLib;
using EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.BarcodeLib.Symbologies;



namespace EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.Views.ItemLabels
{
    public class ItemLabelsPresenter
    {
        private IItemLabelsView view;
        private IUnityContainer _container;
        private IRegionManager _regionManager;
        private CollectionView _colView;

        private EclipsePOS.WPF.SystemManager.Data.ItemsDataSet itemData;
        private EclipsePOS.WPF.SystemManager.Data.organizationLookupDataSet organizationData;

        public DelegateCommand<object> RunCommand;
        public DelegateCommand<object> SelectCommand;
        public DelegateCommand<object> FilterCommand;
        public DelegateCommand<object> SelectAllCommand;
       
        private XpsDocument xpsRep;
       // private FlowDocument doc;

        private string org_no;

        public delegate void RunRportDelegate();

        

        public ItemLabelsPresenter(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;


            RunCommand = new DelegateCommand<object>(OnRunCommandExecute, OnRunCommandCanExecute);
            SelectCommand = new DelegateCommand<object>(OnSelectCommandExecute, OnSelectCommandCanExecute);
            SelectAllCommand = new DelegateCommand<object>(OnSelectAllCommandExecute, OnSelectAllCommandCanExecute);
            FilterCommand = new DelegateCommand<object>(OnFilterCommandExecute, OnFilterCommandCanExecute);


        }

        public void OnShowItemLabels()
        {

            //Organization
            organizationData = new EclipsePOS.WPF.SystemManager.Data.organizationLookupDataSet();
            EclipsePOS.WPF.SystemManager.Data.organizationLookupDataSetTableAdapters.organizationTableAdapter organizationTa = new EclipsePOS.WPF.SystemManager.Data.organizationLookupDataSetTableAdapters.organizationTableAdapter();
            organizationTa.Fill(organizationData.organization);
            View.SetOrganizationDataContext(organizationData.organization);


            //Item
            itemData = new EclipsePOS.WPF.SystemManager.Data.ItemsDataSet();
            EclipsePOS.WPF.SystemManager.Data.ItemsDataSetTableAdapters.itemTableAdapter taItem = new EclipsePOS.WPF.SystemManager.Data.ItemsDataSetTableAdapters.itemTableAdapter();
            taItem.Fill(itemData.item);
            View.SetItemsDataContext(itemData.item);
            _colView = CollectionViewSource.GetDefaultView(itemData.item) as CollectionView;

            //Commands
            View.SetRunBtnDataContext(RunCommand);
            View.SetFilterBtnDataContext(FilterCommand);
            View.SetSelectBtnDataContext(SelectCommand);
            View.SetSelectAllBtnDataContext(SelectAllCommand);

        }

        public IItemLabelsView View
        {
            set
            {
                view = value;
            }
            get
            {
                return view;
            }
        }

        #region Filter Command

        public void OnFilterCommandExecute(object obj)
        {
            //MessageBox.Show("Filter it");
            this.FilterItems(View.GetFilterCriteria(), View.GetFilterText());
        }


        public bool OnFilterCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }
        #endregion


        #region Select Command

        public void OnSelectCommandExecute(object obj)
        {
            //MessageBox.Show("Select it");
            View.AddSelectedItemLabel();
            _colView.MoveCurrentToNext();
            View.SetSelectedItemCursor();
        }


        public bool OnSelectCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }
        #endregion


        #region Select Command

        public void OnSelectAllCommandExecute(object obj)
        {
            //MessageBox.Show("Select it");
            View.AddAllItemLabels();
            
        }


        public bool OnSelectAllCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }
        #endregion





        #region Run Command

        public void OnRunCommandExecute(object obj)
        {
            View.SaveSelections();
          //  RunRportDelegate runRpt = new RunRportDelegate(this.CreateLabelHelper);
          //  runRpt.BeginInvoke(null, null);
            this.CreateLabelHelper();
            
        }


        private void CreateLabelHelper()
        {
          //  Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Send, (SendOrPostCallback)delegate { View.StartSyncAnimation(); }, null);

          //  ReportEngine repEngine = _container.Resolve<ReportEngine>() as ReportEngine;
            List<WPFBarcode> wpfBarcode = View.LabelData();
            LabelPrintHelper printHelper = _container.Resolve<LabelPrintHelper>() as LabelPrintHelper;
             this.xpsRep = printHelper.CreateLabels(wpfBarcode, View.NumberAcross, View.NumberDown, View.TopMargin, View.SideMargin);
//            this.xpsRep = repEngine.CreateLabels(wpfBarcode, View.NumberAcross, View.NumberDown, View.TopMargin, View.SideMargin);

            this.DisplayLabels();
            //Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Send, (SendOrPostCallback)delegate { this.DisplayLabels(); }, null);
            //Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Send, (SendOrPostCallback)delegate { View.EndSyncAnimation(); }, null);
         
        }


        

        private void DisplayLabels()
        {
            IRegion mainRegion = _regionManager.Regions[Regions.ReportsMain];
            XPSDocView view = _container.Resolve<XPSDocView>() as XPSDocView;

            view.DisplayDoc(this.xpsRep);

            //Remove the view on main region 
            object mainView = mainRegion.GetView("MainView");
            if (mainView != null)
            {
                mainRegion.Remove(mainView);
            }

            mainRegion.Add(view, "MainView");
            mainRegion.Activate(view);
        }




        public bool OnRunCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }
        #endregion



        public void FilterItemsByOrganizationNo(string organizationNo)
        {
            this.org_no = organizationNo;

            BindingListCollectionView view2 = CollectionViewSource.GetDefaultView(this.itemData.item) as BindingListCollectionView;

            if (view2 != null)
            {
                view2.CustomFilter = "organization_no = '" + organizationNo.ToString() + "'";

            }
            

        }


        public void FilterItems(string column, string val)
        {

            BindingListCollectionView view2 = CollectionViewSource.GetDefaultView(this.itemData.item) as BindingListCollectionView;

            if (view2 != null)
            {
                if (column.Trim() == "plu" )
                {
                    if (val.Trim().Length > 0)
                    {
                        view2.CustomFilter = "organization_no = '" + org_no.ToString() + "' and " + column + " = '" + val +"'";
                        view2.SortDescriptions.Add(new SortDescription("plu", ListSortDirection.Ascending));
                    }
                }
                else
                {
                    view2.CustomFilter = "organization_no = '" + org_no.ToString()+ "' and " +column + " LIKE " + "'*" + val + "*'";
                    view2.SortDescriptions.Add(new SortDescription(column.Trim(), ListSortDirection.Ascending));
                }
                

           }
           
        }

        

        

    }
}
