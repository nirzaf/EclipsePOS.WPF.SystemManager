using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Composite.Presentation.Events;
using Microsoft.Practices.Composite.Presentation.Commands;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows;
using System.Data;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Unity;
using EclipsePOS.WPF.SystemManager.Infrastructure.Constants;
using EclipsePOS.WPF.SystemManager.PosSetup.Views.PosConfigInput;
using EclipsePOS.WPF.SystemManager.PosSetup.Util;
using EclipsePOS.WPF.SystemManager.Data;



namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.PosConfig
{
    public class PosConfigurationsViewPresenter
    {
        private IUnityContainer _container;
        private IRegionManager _regionManager;

        private IPosConfigurationsView _view;
        private CollectionView _colView;

        private EclipsePOS.WPF.SystemManager.Data.posConfigDataSet posConfigData;
        private EclipsePOS.WPF.SystemManager.Data.posParamDefaultDataSet posParamDefaultData;
        private EclipsePOS.WPF.SystemManager.Data.posParamDataSet posParamData;


        private EclipsePOS.WPF.SystemManager.Data.posConfigDataSetTableAdapters.TableAdapterManager taManager = new EclipsePOS.WPF.SystemManager.Data.posConfigDataSetTableAdapters.TableAdapterManager();
        private EclipsePOS.WPF.SystemManager.Data.posParamDataSetTableAdapters.TableAdapterManager taManagerPosParam = new EclipsePOS.WPF.SystemManager.Data.posParamDataSetTableAdapters.TableAdapterManager();


        public DelegateCommand<object> MoveToFirstCommand;
        public DelegateCommand<object> MoveToPreviousCommand;
        public DelegateCommand<object> MoveToNextCommand;
        public DelegateCommand<object> MoveToLastCommand;

        public DelegateCommand<object> DeleteCommand;
        public DelegateCommand<object> AddCommand;
        public DelegateCommand<object> RevertCommand;
        public DelegateCommand<object> SaveCommand;

        public PosConfigurationsViewPresenter(IUnityContainer container, IRegionManager regionManager)
        {
            this._container = container;
            this._regionManager = regionManager;

            MoveToFirstCommand = new DelegateCommand<object>(OnMoveToFirstCommandExecute, OnMoveToFirstCommandCanExecute);
            MoveToPreviousCommand = new DelegateCommand<object>(OnMoveToPreviousCommandExecute, OnMoveToPreviousCommandCanExecute);
            MoveToNextCommand = new DelegateCommand<object>(OnMoveToNextCommandExecute, OnMoveToNextCommandCanExecute);
            MoveToLastCommand = new DelegateCommand<object>(OnMoveToLastCommandExecute, OnMoveToLastCommandCanExecute);

            DeleteCommand = new DelegateCommand<object>(OnDeleteCommandExecute, OnDeleteCommandCanExecute);
            AddCommand = new DelegateCommand<object>(OnAddCommandExecute, OnAddCommandCanExecute);
            RevertCommand = new DelegateCommand<object>(OnRevertCommandExecute, OnRevertCommandCanExecute);
            SaveCommand = new DelegateCommand<object>(OnSaveCommandExecute, OnSaveCommandCanExecute);
         

        }

        public IPosConfigurationsView View
        {
            set
            {
                _view = value;
            }

            get
            {
                return _view;
            }
        }

        public void OnShowPosConfig()
        {

            //PosConfig
            posConfigData = new EclipsePOS.WPF.SystemManager.Data.posConfigDataSet();
            EclipsePOS.WPF.SystemManager.Data.posConfigDataSetTableAdapters.pos_configTableAdapter posConfigTa = new  EclipsePOS.WPF.SystemManager.Data.posConfigDataSetTableAdapters.pos_configTableAdapter();
            posConfigTa.Fill(posConfigData.pos_config);
            View.SetPosConfigDataContext(posConfigData.pos_config);

            _colView = CollectionViewSource.GetDefaultView(posConfigData.pos_config) as CollectionView;
            taManager.pos_configTableAdapter = posConfigTa;

            //PosParam
            posParamData = new EclipsePOS.WPF.SystemManager.Data.posParamDataSet();
            EclipsePOS.WPF.SystemManager.Data.posParamDataSetTableAdapters.pos_paramTableAdapter posParamTa = new  EclipsePOS.WPF.SystemManager.Data.posParamDataSetTableAdapters.pos_paramTableAdapter();
            posParamTa.Fill(posParamData.pos_param);
            taManagerPosParam.pos_paramTableAdapter = posParamTa;

            //PosParam - Default
            posParamDefaultData = new EclipsePOS.WPF.SystemManager.Data.posParamDefaultDataSet();
            EclipsePOS.WPF.SystemManager.Data.posParamDefaultDataSetTableAdapters.pos_paramTableAdapter posParamDefaultTa = new  EclipsePOS.WPF.SystemManager.Data.posParamDefaultDataSetTableAdapters.pos_paramTableAdapter();
            posParamDefaultTa.Fill(posParamDefaultData.pos_param);

         
            View.SetMoveToFirstBtnDataContext(MoveToFirstCommand);
            View.SetMoveToPreviousBtnDataContext(MoveToPreviousCommand);
            View.SetMoveToNextBtnDataContext(MoveToNextCommand);
            View.SetMoveToLastBtnDataContext(MoveToLastCommand);

            View.SetDeleteBtnDataContext(DeleteCommand);
            View.SetAddBtnDataContext(AddCommand);
            View.SetRevertBtnDataContext(RevertCommand);
            View.SetSaveBtnDataContext(SaveCommand);


        }

        #region MoveToFirst Command

        public void OnMoveToFirstCommandExecute(object obj)
        {
            _colView.MoveCurrentToFirst();
            View.SetSelectedItemCursor();
        }

        public bool OnMoveToFirstCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion
        #region MoveToPrevioust Command

        public void OnMoveToPreviousCommandExecute(object obj)
        {
            _colView.MoveCurrentToPrevious();
            if (_colView.IsCurrentBeforeFirst) _colView.MoveCurrentToFirst();
            View.SetSelectedItemCursor();
        }

        public bool OnMoveToPreviousCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion

        #region MoveToNext Command

        public void OnMoveToNextCommandExecute(object obj)
        {
            _colView.MoveCurrentToNext();
            if (_colView.IsCurrentAfterLast) _colView.MoveCurrentToLast();
            View.SetSelectedItemCursor();
        }

        public bool OnMoveToNextCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion


        #region MoveToLast Command

        public void OnMoveToLastCommandExecute(object obj)
        {
            _colView.MoveCurrentToLast();
            View.SetSelectedItemCursor();
        }

        public bool OnMoveToLastCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion


        #region Delete Command

        public void OnDeleteCommandExecute(object obj)
        {
            int deleteConfigNo = 0;
            try
            {


                System.Data.DataRow dataRow = ((System.Data.DataRowView)_colView.CurrentItem).Row;

                deleteConfigNo = int.Parse(dataRow["config_no"].ToString());
                
                dataRow.Delete();
            }
            catch
            {
            }

            
            try
            {
                DataTable dt = posParamData.pos_param;
                foreach (DataRow dr in dt.Rows)
                {
                    if (int.Parse(dr["config_no"].ToString()) == deleteConfigNo)
                    {
                        dr.Delete();
                    }

                }
            }
            catch
            {
            }
		



        }

        public bool OnDeleteCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion


        #region Add Command

        public void OnAddCommandExecute(object obj)
        {
            if (!posConfigData.HasErrors)
            {
                
                InputConfigNoView view1 = _container.Resolve<InputConfigNoView>();
                int response =  view1.ShowInputDialog();
                int copyFromPosConfig = view1.CopyFromConfigNo;
                if (response > 0)
                {

                    EclipsePOS.WPF.SystemManager.Data.posConfigDataSet.pos_configRow dataRow = posConfigData.pos_config.Newpos_configRow();
                    dataRow.config_no = response;
                    dataRow.name = "";

                    posConfigData.pos_config.Addpos_configRow(dataRow);

                    this.CopyConfiguration(copyFromPosConfig, response );

                    _colView.MoveCurrentToLast();
                    View.SetSelectedItemCursor();
                }


            }

        }

        public bool OnAddCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion


        #region Revert Command

        public void OnRevertCommandExecute(object obj)
        {
            if (posConfigData.HasChanges())
            {
                MessageBoxResult result = Microsoft.Windows.Controls.MessageBox.Show("Are sure you want to loose all your changes", "Revert command", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if ( result == MessageBoxResult.Yes )
                {
                    posConfigData.RejectChanges();
                }
            }

        }

        public bool OnRevertCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion

        #region Save Command

        public void OnSaveCommandExecute(object obj)
        {
            if (posConfigData.HasErrors)
            {
                Microsoft.Windows.Controls.MessageBox.Show("Please correct the errors first", "Save command", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (posConfigData.HasChanges())
                {
                    try
                    {
                        if (taManager.UpdateAll(posConfigData) > 0)
                        {
                            Microsoft.Windows.Controls.MessageBox.Show("Saved pos config", "Save command", MessageBoxButton.OK, MessageBoxImage.Information);
                        }

                        if (taManagerPosParam.UpdateAll(posParamData) > 0)
                        {
                            Microsoft.Windows.Controls.MessageBox.Show("Saved pos param", "Save command", MessageBoxButton.OK, MessageBoxImage.Information);
                        }


                    }
                    catch(Exception e)
                    {
                        // Try to save other way around for delteted record

                        try
                        {
                            if (taManagerPosParam.UpdateAll(posParamData) > 0)
                            {
                                Microsoft.Windows.Controls.MessageBox.Show("Saved pos param", "Save command", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                            
                            
                            if (taManager.UpdateAll(posConfigData) > 0)
                            {
                                Microsoft.Windows.Controls.MessageBox.Show("Saved pos config", "Save command", MessageBoxButton.OK, MessageBoxImage.Information);
                            }

                        }
                        catch (Exception e1)
                        {
                            Microsoft.Windows.Controls.MessageBox.Show("Unable to save changes", "Save command", MessageBoxButton.OK, MessageBoxImage.Error);
                        }

                      
                    }
                }
            }
        }

        public bool OnSaveCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion 

       
        #region Copy configurations
        public void CopyConfiguration(int fromConfigNo, int newConfigNo )
        {
            string conn = PosSettings.Default.possiteConnectionString;
            DataClasses1DataContext dataContext = new DataClasses1DataContext(conn);
            //Copy pos param
            var copyPosParam = from pos_parms in dataContext.pos_params where pos_parms.config_no == fromConfigNo select pos_parms;  //from pos_param in dataContext.subs where sub.subscriber_name.Equals(this.txtUserTextBox.Text.Trim()) select sub;//from sub in dataContext.subs select sub;
            foreach (pos_param param in copyPosParam)
            {
                EclipsePOS.WPF.SystemManager.Data.posParamDataSet.pos_paramRow dataRow = posParamData.pos_param.Newpos_paramRow();
                dataRow.config_no = newConfigNo;
                dataRow.help_id = (int)param.help_id;
                //  dataRow.param_id = int.Parse(dr["param_id"].ToString());
                dataRow.param_name = param.param_name; ;
                dataRow.param_type = (int)param.param_type;
                dataRow.param_value = param.param_value;
                dataRow.param_catogory = (int)param.param_catogory;

                posParamData.pos_param.Addpos_paramRow(dataRow);

                this.View.SetFocusToFirstElement();
                
            }
            //Copy dialog
            //Copy dialog events
		    
            

        }
        #endregion

      

    }
}
