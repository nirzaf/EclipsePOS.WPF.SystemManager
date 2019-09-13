using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Composite.Presentation.Commands;
using EclipsePOS.WPF.SystemManager.Infrastructure.Constants;
using EclipsePOS.WPF.SystemManager.PosSetup.Views.DataSource;
using EclipsePOS.WPF.SystemManager.PosSetup.Views.NewDataSourcePrompt;
using EclipsePOS.WPF.SystemManager.PosSetup.Views.PosConfigInput;
using EclipsePOS.WPF.SystemManager.PosSetup.Views.BackupDataSourcePrompt;
using EclipsePOS.WPF.SystemManager.PosSetup.Views.ExportData;
using EclipsePOS.WPF.SystemManager.PosSetup.Views.ImportData;
using EclipsePOS.WPF.SystemManager.PosSetup.Util;
using EclipsePOS.WPF.SystemManager.Infrastructure.Services;


namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.NavigatorDataSource
{
    public class DataSourceNavPresenter
    {
        public DelegateCommand<object> SetNewDBCommand;
        public DelegateCommand<object> SetExistingDBCommand;
        public DelegateCommand<object> SetBackupDBCommand;
        public DelegateCommand<object> SetExportDataCommand;
        public DelegateCommand<object> SetImportDataCommand;

        private IUnityContainer _container;
        private IRegionManager _regionManager;

        public DataSourceNavPresenter(IUnityContainer container, IRegionManager regionManager)
        {
            this._container = container;
            this._regionManager = regionManager;

            SetNewDBCommand = new DelegateCommand<object>(OnSetNewDBCommandExecute, OnSetNewDBCommandCanExecute);
            SetExistingDBCommand = new DelegateCommand<object>(OnSetExistingDBCommandExecute, OnSetExistingDBCommandCanExecute);

            SetBackupDBCommand = new DelegateCommand<object>(OnSetBackupDBCommandExecute, OnSetBackupDBCommandCanExecute);
            SetExportDataCommand = new DelegateCommand<object>(OnSetExportDataCommandExecute, OnSetExportDataCommandCanExecute);
            SetImportDataCommand = new DelegateCommand<object>(OnSetImportDataCommandExecute, OnSetImportDataCommandCanExecute);
             
        }


        public void OnShowDataSorce()
        {
            /*
            IRegion dataSourceInfoRegion = _regionManager.Regions[Regions.DataSourceInfo];

            //Remove the view on main region 
            object mainView = dataSourceInfoRegion.GetView("MainView");
            if (mainView != null)
            {
                dataSourceInfoRegion.Remove(mainView);
            }

            var view = _container.Resolve<DataSourceView>();
            dataSourceInfoRegion.Add(view, "MainView");
            dataSourceInfoRegion.Activate(view);
            */


        }


        private IDataSourceNavView _view;
        public IDataSourceNavView View
        {
            get
            {
                return this._view;
            }
            set
            {
                this._view = value;
                _view.SetNewDataBaseBtnDataContext(SetNewDBCommand);
                _view.SetExistingDataBaseBtnDataContext(SetExistingDBCommand);
                _view.SetBackupDataBaseBtnDataContext(SetBackupDBCommand);
                _view.SetExportDataBtnDataContext(SetExportDataCommand);
                _view.SetImportDataBtnDataContext(SetImportDataCommand);

            }
            
        }

       

        #region SetNewDB Command

        public void OnSetNewDBCommandExecute(object obj)
        {

           
            IRegion dataSourceMain= _regionManager.Regions[Regions.DataSourceMain];

            //Remove the view on main region 
            object mainView = dataSourceMain.GetView("MainView");
            if (mainView != null)
            {
                dataSourceMain.Remove(mainView);
            }

            INewDataSource view1 = _container.Resolve<NewDataSource>();
            view1.Mode = CreateMode.NewEmptyDatabase;
            dataSourceMain.Add(view1, "MainView");
            dataSourceMain.Activate(view1);


        }

        public bool OnSetNewDBCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion

        #region SetExistingDB Command

        public void OnSetExistingDBCommandExecute(object obj)
        {
            IRegion dataSourceMain = _regionManager.Regions[Regions.DataSourceMain];

            //Remove the view on main region 
            object mainView = dataSourceMain.GetView("MainView");
            if (mainView != null)
            {
                dataSourceMain.Remove(mainView);
            }

            INewDataSource view1 = _container.Resolve<NewDataSource>();
            view1.Mode = CreateMode.ExistingDatabase;
            dataSourceMain.Add(view1, "MainView");
            dataSourceMain.Activate(view1);

        }

        public bool OnSetExistingDBCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion


        #region SetBackupDB Command

        public void OnSetBackupDBCommandExecute(object obj)
        {
            // _colView.MoveCurrentToLast();
            // View.SetSelectedItemCursor();
            //MessageBox.Show("Existing Data base");
            IBackupDataSource view1 = _container.Resolve<BackupDataSource>();
            int response = view1.ShowInputDialog();
            if (response > 0)
            {

            }

        }

        public bool OnSetBackupDBCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion

        #region SetExportData Command

        public void OnSetExportDataCommandExecute(object obj)
        {

            IAuthenticationService authenticationService = _container.Resolve<IAuthenticationService>();
            if (authenticationService.Authenticate())
            {
                IExportDataView view1 = _container.Resolve<ExportDataView>();
                int response = view1.ShowInputDialog();
                if (response > 0)
                {

                }
            }


        }

        public bool OnSetExportDataCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion

        #region SetImportData Command

        public void OnSetImportDataCommandExecute(object obj)
        {

            IAuthenticationService authenticationService = _container.Resolve<IAuthenticationService>();
            if (authenticationService.Authenticate())
            {

                IImportDataView view1 = _container.Resolve<ImportDataView>();
                int response = view1.ShowInputDialog();
                if (response > 0)
                {

                }
            }

        }

        public bool OnSetImportDataCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion


    }
}
