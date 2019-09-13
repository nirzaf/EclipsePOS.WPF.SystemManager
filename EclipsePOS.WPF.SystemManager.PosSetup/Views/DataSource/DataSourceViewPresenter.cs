
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EclipsePOS.WPF.SystemManager.Data;
using Microsoft.Practices.Composite.Presentation.Events;
using Microsoft.Practices.Composite.Presentation.Commands;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows;
using System.Data.SqlClient;
using System.Data;
using EclipsePOS.WPF.SystemManager.PosSetup.Views.NewDataSourcePrompt;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Unity;
using EclipsePOS.WPF.SystemManager.Infrastructure.Constants;
using EclipsePOS.WPF.SystemManager.PosSetup.Views.PosConfigInput;
using EclipsePOS.WPF.SystemManager.PosSetup.Views.BackupDataSourcePrompt;
using EclipsePOS.WPF.SystemManager.PosSetup.Views.ExportData;
using EclipsePOS.WPF.SystemManager.PosSetup.Views.ImportData;
using EclipsePOS.WPF.SystemManager.PosSetup.Util;
using EclipsePOS.WPF.SystemManager.Infrastructure.Services;





namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.DataSource
{
    public class DataSourceViewPresenter
    {
        private IUnityContainer _container;
        private IRegionManager _regionManager;

        private IDataSourceView _view;

      /*  public DelegateCommand<object> SetDemoDBCommand;
        public DelegateCommand<object> SetNewDBCommand;
        public DelegateCommand<object> SetExistingDBCommand;
        public DelegateCommand<object> SetBackupDBCommand;
        public DelegateCommand<object> SetExportDataCommand;
        public DelegateCommand<object> SetImportDataCommand;
        */

        public DataSourceViewPresenter(IUnityContainer container, IRegionManager regionManager)
        {
            this._container = container;
            this._regionManager = regionManager;


          /*  SetDemoDBCommand = new DelegateCommand<object>(OnSetDemoDBCommandExecute, OnSetDemoDBCommandCanExecute);
            SetNewDBCommand = new DelegateCommand<object>(OnSetNewDBCommandExecute, OnSetNewDBCommandCanExecute);
            SetExistingDBCommand = new DelegateCommand<object>(OnSetExistingDBCommandExecute, OnSetExistingDBCommandCanExecute);

            SetBackupDBCommand = new DelegateCommand<object>(OnSetBackupDBCommandExecute, OnSetBackupDBCommandCanExecute);
            SetExportDataCommand = new DelegateCommand<object>(OnSetExportDataCommandExecute, OnSetExportDataCommandCanExecute);
            SetImportDataCommand = new DelegateCommand<object>(OnSetImportDataCommandExecute, OnSetImportDataCommandCanExecute);
            */
           
        }

        public IDataSourceView View
        {
            get
            {
                return _view;
            }
            set
            {
                _view = value;
              //  _view.SetCurrDataSourcePath(Properties.Resource.DataSourceView_txtBlockCurrDataSourceTxt + DataModule.CurrDataSourcePath);
                _view.SetCurrDataSourcePath(this.GetCurrentDatabasePathAndSize());  //PosSettings.Default.DataSource);
                //this.GetCurrentDatabasePathAndSize();
              //  _view.SetDemoDataBaseBtnDataContext(SetDemoDBCommand);
              //  _view.SetNewDataBaseBtnDataContext(SetNewDBCommand);
              //  _view.SetExistingDataBaseBtnDataContext(SetExistingDBCommand);
              //  _view.SetBackupDataBaseBtnDataContext(SetBackupDBCommand);
              //  _view.SetExportDataBtnDataContext(SetExportDataCommand);
              //  _view.SetImportDataBtnDataContext(SetImportDataCommand);
            }

        }

        #region SetDemoDB Command
        
        public void OnSetDemoDBCommandExecute(object obj)
        {
           // INewDataSource view1 = _container.Resolve<NewDataSource>();
           // view1.Mode = CreateMode.DemoDatabse;
            

         }

        public bool OnSetDemoDBCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion

        #region SetNewDB Command

        public void OnSetNewDBCommandExecute(object obj)
        {
          
            INewDataSource view1 = _container.Resolve<NewDataSource>();
            view1.Mode = CreateMode.NewEmptyDatabase;
            

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
           // _colView.MoveCurrentToLast();
           // View.SetSelectedItemCursor();
            //MessageBox.Show("Existing Data base");
            INewDataSource view1 = _container.Resolve<NewDataSource>();
            view1.Mode = CreateMode.ExistingDatabase;
           

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


        public string GetCurrentDatabasePathAndSize()
        {
            StringBuilder output = new StringBuilder();

            string connString = PosSettings.Default.DataSource;
            SqlConnection conn = new SqlConnection(connString);
           
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand("select filename, size from dbo.sysfiles", conn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                   // MessageBox.Show(reader[0].ToString());
                   // MessageBox.Show(reader[1].ToString());
                    output.Append(reader[0].ToString());
                    output.Append(", Size=");
                    output.Append(reader[1].ToString());
                    output.AppendLine(" KB");
                 }
                

           
            }
            catch (Exception e)
            {

               // MessageBox.Show(e.ToString());
            }
            finally
            {
                conn.Close();
            }

            return output.ToString();
        }



    }
}
