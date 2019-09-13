using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Composite.Presentation.Events;
using Microsoft.Practices.Composite.Presentation.Commands;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows;
using EclipsePOS.WPF.SystemManager.Data;
using EclipsePOS.WPF.SystemManager.PosSetup.Util;

namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.PosParam
{
    public class PosParamViewPresenter
    {
        private IPosParamView _view;
        private CollectionView _colView;

        private EclipsePOS.WPF.SystemManager.Data.posParamDataSet posParamData;
        private EclipsePOS.WPF.SystemManager.Data.posConfigDataSet posConfigData;


        private EclipsePOS.WPF.SystemManager.Data.posParamDataSetTableAdapters.TableAdapterManager taManager = new EclipsePOS.WPF.SystemManager.Data.posParamDataSetTableAdapters.TableAdapterManager(); 

        public DelegateCommand<object> MoveToFirstCommand;
        public DelegateCommand<object> MoveToPreviousCommand;
        public DelegateCommand<object> MoveToNextCommand;
        public DelegateCommand<object> MoveToLastCommand;

        public DelegateCommand<object> DeleteCommand;
        public DelegateCommand<object> AddCommand;
        public DelegateCommand<object> RevertCommand;
        public DelegateCommand<object> SaveCommand;

        public PosParamViewPresenter()
        {
            MoveToFirstCommand = new DelegateCommand<object>(OnMoveToFirstCommandExecute, OnMoveToFirstCommandCanExecute);
            MoveToPreviousCommand = new DelegateCommand<object>(OnMoveToPreviousCommandExecute, OnMoveToPreviousCommandCanExecute);
            MoveToNextCommand = new DelegateCommand<object>(OnMoveToNextCommandExecute, OnMoveToNextCommandCanExecute);
            MoveToLastCommand = new DelegateCommand<object>(OnMoveToLastCommandExecute, OnMoveToLastCommandCanExecute);

            DeleteCommand = new DelegateCommand<object>(OnDeleteCommandExecute, OnDeleteCommandCanExecute);
            AddCommand = new DelegateCommand<object>(OnAddCommandExecute, OnAddCommandCanExecute);
            RevertCommand = new DelegateCommand<object>(OnRevertCommandExecute, OnRevertCommandCanExecute);
            SaveCommand = new DelegateCommand<object>(OnSaveCommandExecute, OnSaveCommandCanExecute);
         

        }

        public IPosParamView View
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

        public void OnShowPosParam()
        {

            //PosParam
            posParamData = new  EclipsePOS.WPF.SystemManager.Data.posParamDataSet();
            EclipsePOS.WPF.SystemManager.Data.posParamDataSetTableAdapters.pos_paramTableAdapter posParamTa = new EclipsePOS.WPF.SystemManager.Data.posParamDataSetTableAdapters.pos_paramTableAdapter(); 
            posParamTa.Fill(posParamData.pos_param);
            View.SetPosParamDataContext(posParamData.pos_param);

            _colView = CollectionViewSource.GetDefaultView(posParamData.pos_param) as CollectionView;
            taManager.pos_paramTableAdapter = posParamTa;

            //PosConfig
            posConfigData = new EclipsePOS.WPF.SystemManager.Data.posConfigDataSet();
            EclipsePOS.WPF.SystemManager.Data.posConfigDataSetTableAdapters.pos_configTableAdapter posConfigTa = new EclipsePOS.WPF.SystemManager.Data.posConfigDataSetTableAdapters.pos_configTableAdapter();
            posConfigTa.Fill(posConfigData.pos_config);
            View.SetPosConfigDataContext(posConfigData.pos_config);



            View.SetMoveToFirstBtnDataContext(MoveToFirstCommand);
            View.SetMoveToPreviousBtnDataContext(MoveToPreviousCommand);
            View.SetMoveToNextBtnDataContext(MoveToNextCommand);
            View.SetMoveToLastBtnDataContext(MoveToLastCommand);

            View.SetDeleteBtnDataContext(DeleteCommand);
            View.SetAddBtnDataContext(AddCommand);
            View.SetRevertBtnDataContext(RevertCommand);
            View.SetSaveBtnDataContext(SaveCommand);


        }

        public void OnShowHelpText(object rowData)
        {
            View.SetHelpText("");

            try
            {
                System.Data.DataRow dataRow = ((System.Data.DataRowView)_colView.CurrentItem).Row;
                int helpid = int.Parse(dataRow["help_id"].ToString());
                string param_catogory = dataRow["param_catogory"].ToString();
                DataClasses1DataContext dataContext = new DataClasses1DataContext(PosSettings.Default.DataSource);
                var helpInfo = from help in dataContext.helps where (help.help_id == helpid && help.display_name == param_catogory) select help;//from sub in dataContext.subs select sub;
                foreach (help s in helpInfo)
                {
                    
                    View.SetHelpText(s.display_text.Replace("<br>", "\n"));
                }
            }
            catch
            {
            }
            
            
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
           // System.Data.DataRow dataRow = ((System.Data.DataRowView)_colView.CurrentItem).Row;
           // dataRow.Delete();

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
            if (posParamData.HasChanges())
            {
                MessageBoxResult result = Microsoft.Windows.Controls.MessageBox.Show("Are sure you want to loose all your changes", "Revert command", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if ( result  == MessageBoxResult.Yes )
                {
                    posParamData.RejectChanges();
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
            if (posParamData.HasErrors)
            {
                Microsoft.Windows.Controls.MessageBox.Show("Please correct the errors first", "Save command", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try
                {

                    if (posParamData.HasChanges())
                    {
                        if (taManager.UpdateAll(posParamData) > 0)
                        {
                            Microsoft.Windows.Controls.MessageBox.Show("Saved", "Save command", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                }
                catch
                {
                    Microsoft.Windows.Controls.MessageBox.Show("Unable to save changes", "Save command", MessageBoxButton.OK, MessageBoxImage.Error);
                    posParamData.RejectChanges();
                }
            }
        }

        public bool OnSaveCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion 


        public void FilterPosParamByConfigNo(int configNo)
        {
        
            BindingListCollectionView view1 = CollectionViewSource.GetDefaultView( posParamData.pos_param ) as BindingListCollectionView;
         
            if (view1 != null)
            {
                view1.CustomFilter = "config_no = " + configNo.ToString();
         
                view1.GroupDescriptions.Clear();
                PropertyGroupDescription groupDescription = new PropertyGroupDescription();
                groupDescription.PropertyName = "param_catogory";
                view1.GroupDescriptions.Add(groupDescription);
            }
 
        }

      



    }
}
