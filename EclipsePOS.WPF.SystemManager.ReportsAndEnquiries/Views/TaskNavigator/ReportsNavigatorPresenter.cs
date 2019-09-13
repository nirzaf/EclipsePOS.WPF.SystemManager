using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Composite.Presentation.Commands;
using EclipsePOS.WPF.SystemManager.Infrastructure.Constants;
using EclipsePOS.WPF.SystemManager.Infrastructure.Services;
using EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.Views.SalesSummary;
using EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.Views.SalesDetailByDate;
using EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.Views.PaymentDetailsByDate;
using EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.Views.PaymentSummary;
using EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.Views.TaxDetail;
using EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.Views.ItemLabels;
using EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.Views.Inventory;
using EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.Views.SalesSummaryBySalesperson;

using System.Windows;

namespace EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.Views.TaskNavigator
{
    public class ReportsNavigatorPresenter
    {
        private IReportsNavigatorView _view;

        public DelegateCommand<object> ShowSalesSummaryReportCommand;
        public DelegateCommand<object> ShowSalesDetailsByDateReportCommand;
        public DelegateCommand<object> ShowSalesBySalesPersonReportCommand;
       
        public DelegateCommand<object> ShowPaymentDetailsByDateReportCommand;
        public DelegateCommand<object> ShowPaymentSummaryCommand;
        public DelegateCommand<object> ShowTaxDetailsCommand;
        public DelegateCommand<object> ShowItemLabelsCommand;

        public DelegateCommand<object> ShowInventoryCommand;
        public DelegateCommand<object> ShowInventoryDetailsCommand;
        public DelegateCommand<object> ShowStockDiaryCommand;
        public DelegateCommand<object> ShowStockDiaryDetailsCommand;

        private IUnityContainer _container;
        private IRegionManager _regionManager;
       

         public ReportsNavigatorPresenter(IUnityContainer container, IRegionManager regionManager)
        {

            _container = container;
            _regionManager = regionManager;

            ShowSalesSummaryReportCommand = new DelegateCommand<object>(OnShowSalesSummaryReportCommandExecute, OnShowSalesSummaryReportsCommandCanExecute);
            ShowSalesDetailsByDateReportCommand = new DelegateCommand<object>(OnShowSalesDetailsByDateReportCommandExecute, OnShowSalesDetailsByDateReportsCommandCanExecute);
            ShowSalesBySalesPersonReportCommand = new DelegateCommand<object>(OnShowSalesBySalesPersonReportCommandExecute, OnShowSalesBySalesPersonReportsCommandCanExecute);
            ShowPaymentDetailsByDateReportCommand = new DelegateCommand<object>(OnShowPaymentDetailsByDateReportCommandExecute, OnShowPaymentDetailsByDateReportsCommandCanExecute);
            ShowPaymentSummaryCommand = new DelegateCommand<object>(OnShowPaymentSummaryCommandExecute, OnShowPaymentSummaryCommandCanExecute);
            ShowTaxDetailsCommand = new DelegateCommand<object>(OnShowTaxDetailsCommandExecute, OnShowTaxDetailsCommandCanExecute);
            ShowItemLabelsCommand = new DelegateCommand<object>(OnShowItemLabelsCommandExecute, OnShowItemLabelsCommandCanExecute);
         }

        public IReportsNavigatorView View
        {
            get
            {
                return _view;
            }
            set
            {
                _view = value;
                View.SetDataContextSalesSummaryReportView(ShowSalesSummaryReportCommand);
                View.SetDataContextSalesDetailsByDate(ShowSalesDetailsByDateReportCommand);
                View.SetDataContextSalesBySalesPerson(ShowSalesBySalesPersonReportCommand);
                View.SetDataContextPaymentDetailsByDate(ShowPaymentDetailsByDateReportCommand);
                View.SetDataContextPaymentSummary(ShowPaymentSummaryCommand);
                View.SetDataContextTaxDetails(ShowTaxDetailsCommand);
                View.SetDataContextItemLabels(ShowItemLabelsCommand);
            }
        }

        #region Show SalesSummaryReports Command

        public void OnShowSalesSummaryReportCommandExecute(object obj)
        {
            IAuthenticationService authenticationService = _container.Resolve<IAuthenticationService>();
            if (authenticationService.Authenticate())
            {
                // Implement business logic for myCommand.
                IRegion mainRegion = _regionManager.Regions[Regions.ReportsMain];

                //Remove the view on main region 
                object mainView = mainRegion.GetView("MainView");
                if (mainView != null)
                {
                    mainRegion.Remove(mainView);
                }

                var view = _container.Resolve<SalesSummaryView>();
                mainRegion.Add(view, "MainView");
                mainRegion.Activate(view);
            }
        }

        public bool OnShowSalesSummaryReportsCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion 


        #region Show SalesDetailsByDateReports Command

        public void OnShowSalesDetailsByDateReportCommandExecute(object obj)
        {
            IAuthenticationService authenticationService = _container.Resolve<IAuthenticationService>();
            if (authenticationService.Authenticate())
            {
                // Implement business logic for myCommand.
                IRegion mainRegion = _regionManager.Regions[Regions.ReportsMain];

                //Remove the view on main region 
                object mainView = mainRegion.GetView("MainView");
                if (mainView != null)
                {
                    mainRegion.Remove(mainView);
                }

                var view = _container.Resolve<SalesDetailByDateView>();
                mainRegion.Add(view, "MainView");
                mainRegion.Activate(view);
            }
        }

        public bool OnShowSalesDetailsByDateReportsCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion 


        #region Show SalesBySalesPersonReports Command

        public void OnShowSalesBySalesPersonReportCommandExecute(object obj)
        {
            IAuthenticationService authenticationService = _container.Resolve<IAuthenticationService>();
            if (authenticationService.Authenticate())
            {
                // Implement business logic for myCommand.
                IRegion mainRegion = _regionManager.Regions[Regions.ReportsMain];

                //Remove the view on main region 
                object mainView = mainRegion.GetView("MainView");
                if (mainView != null)
                {
                    mainRegion.Remove(mainView);
                }

                var view = _container.Resolve<SalesPersonsView>();
                mainRegion.Add(view, "MainView");
                mainRegion.Activate(view);
            }
        }

        public bool OnShowSalesBySalesPersonReportsCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion 




        #region Show PaymentDetailsByDateReports Command

        public void OnShowPaymentDetailsByDateReportCommandExecute(object obj)
        {
            IAuthenticationService authenticationService = _container.Resolve<IAuthenticationService>();
            if (authenticationService.Authenticate())
            {
                // Implement business logic for myCommand.
                IRegion mainRegion = _regionManager.Regions[Regions.ReportsMain];

                //Remove the view on main region 
                object mainView = mainRegion.GetView("MainView");
                if (mainView != null)
                {
                    mainRegion.Remove(mainView);
                }

                var view = _container.Resolve<PaymentDetailsByDateView>();
                mainRegion.Add(view, "MainView");
                mainRegion.Activate(view);
            }
        }

        public bool OnShowPaymentDetailsByDateReportsCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion 

        #region ShowPaymentSummayCommand

        public void OnShowPaymentSummaryCommandExecute(object obj)
        {
            IAuthenticationService authenticationService = _container.Resolve<IAuthenticationService>();
            if (authenticationService.Authenticate())
            {
                // Implement business logic for myCommand.
                IRegion mainRegion = _regionManager.Regions[Regions.ReportsMain];

                //Remove the view on main region 
                object mainView = mainRegion.GetView("MainView");
                if (mainView != null)
                {
                    mainRegion.Remove(mainView);
                }

                var view = _container.Resolve<PaymentSummaryView>();
                mainRegion.Add(view, "MainView");
                mainRegion.Activate(view);
            }
        }

        public bool OnShowPaymentSummaryCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion 

        #region ShowTaxDetailCommand

        public void OnShowTaxDetailsCommandExecute(object obj)
        {
            IAuthenticationService authenticationService = _container.Resolve<IAuthenticationService>();
            if (authenticationService.Authenticate())
            {
                // Implement business logic for myCommand.
                IRegion mainRegion = _regionManager.Regions[Regions.ReportsMain];

                //Remove the view on main region 
                object mainView = mainRegion.GetView("MainView");
                if (mainView != null)
                {
                    mainRegion.Remove(mainView);
                }

                var view = _container.Resolve<TaxDetailsView>();
                mainRegion.Add(view, "MainView");
                mainRegion.Activate(view);
            }
        }

        public bool OnShowTaxDetailsCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion 


        #region ShowItemLabelsCommand

        public void OnShowItemLabelsCommandExecute(object obj)
        {
            IAuthenticationService authenticationService = _container.Resolve<IAuthenticationService>();
            if (authenticationService.Authenticate())
            {
                // Implement business logic for myCommand.
                IRegion mainRegion = _regionManager.Regions[Regions.ReportsMain];

                //Remove the view on main region 
                object mainView = mainRegion.GetView("MainView");
                if (mainView != null)
                {
                    mainRegion.Remove(mainView);
                }

                var view = _container.Resolve<ItemLabelsView>();
                mainRegion.Add(view, "MainView");
                mainRegion.Activate(view);
            }
        }

        public bool OnShowItemLabelsCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion 


        #region ShowInventoryCommand

        public void OnShowInventoryCommandExecute(object obj)
        {
            IAuthenticationService authenticationService = _container.Resolve<IAuthenticationService>();
            if (authenticationService.Authenticate())
            {
                // Implement business logic for myCommand.
                IRegion mainRegion = _regionManager.Regions[Regions.ReportsMain];

                //Remove the view on main region 
                object mainView = mainRegion.GetView("MainView");
                if (mainView != null)
                {
                    mainRegion.Remove(mainView);
                }

                //var view = _container.Resolve<PaymentSummaryView>();
                //mainRegion.Add(view, "MainView");
                //mainRegion.Activate(view);
            }
        }

        public bool OnShowInventoryCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion 


        /*
        #region ShowPaymentSummayCommand
        
        public void OnShowPaymentSummaryCommandExecute(object obj)
        {
            IAuthenticationService authenticationService = _container.Resolve<IAuthenticationService>();
            if (authenticationService.Authenticate())
            {
                // Implement business logic for myCommand.
                IRegion mainRegion = _regionManager.Regions[Regions.ReportsMain];

                //Remove the view on main region 
                object mainView = mainRegion.GetView("MainView");
                if (mainView != null)
                {
                    mainRegion.Remove(mainView);
                }

                var view = _container.Resolve<PaymentSummaryView>();
                mainRegion.Add(view, "MainView");
                mainRegion.Activate(view);
            }
        }

        public bool OnShowPaymentSummaryCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion 
        */

        /*
        #region ShowPaymentSummayCommand

        public void OnShowPaymentSummaryCommandExecute(object obj)
        {
            IAuthenticationService authenticationService = _container.Resolve<IAuthenticationService>();
            if (authenticationService.Authenticate())
            {
                // Implement business logic for myCommand.
                IRegion mainRegion = _regionManager.Regions[Regions.ReportsMain];

                //Remove the view on main region 
                object mainView = mainRegion.GetView("MainView");
                if (mainView != null)
                {
                    mainRegion.Remove(mainView);
                }

                var view = _container.Resolve<PaymentSummaryView>();
                mainRegion.Add(view, "MainView");
                mainRegion.Activate(view);
            }
        }

        public bool OnShowPaymentSummaryCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion 
        */

       /*     
        #region ShowPaymentSummayCommand

        public void OnShowPaymentSummaryCommandExecute(object obj)
        {
            IAuthenticationService authenticationService = _container.Resolve<IAuthenticationService>();
            if (authenticationService.Authenticate())
            {
                // Implement business logic for myCommand.
                IRegion mainRegion = _regionManager.Regions[Regions.ReportsMain];

                //Remove the view on main region 
                object mainView = mainRegion.GetView("MainView");
                if (mainView != null)
                {
                    mainRegion.Remove(mainView);
                }

                var view = _container.Resolve<PaymentSummaryView>();
                mainRegion.Add(view, "MainView");
                mainRegion.Activate(view);
            }
        }

        public bool OnShowPaymentSummaryCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion 


        */

    }
}
