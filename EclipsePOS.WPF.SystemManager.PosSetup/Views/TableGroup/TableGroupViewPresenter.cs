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


namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.TableGroup
{
    public class TableGroupViewPresenter
    {
        private ITableGroupView _view;
        private CollectionView _colView;

        private EclipsePOS.WPF.SystemManager.Data.tableGroupDataSet tableGroupData;
        //private EclipsePOS.WPF.SystemManager.Data.posConfigDataSet posConfigData;



        private EclipsePOS.WPF.SystemManager.Data.tableGroupDataSetTableAdapters.TableAdapterManager taManager = new EclipsePOS.WPF.SystemManager.Data.tableGroupDataSetTableAdapters.TableAdapterManager();

        public DelegateCommand<object> MoveToFirstCommand;
        public DelegateCommand<object> MoveToPreviousCommand;
        public DelegateCommand<object> MoveToNextCommand;
        public DelegateCommand<object> MoveToLastCommand;

        public DelegateCommand<object> DeleteCommand;
        public DelegateCommand<object> AddCommand;
        public DelegateCommand<object> RevertCommand;
        public DelegateCommand<object> SaveCommand;

        public TableGroupViewPresenter()
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


        public ITableGroupView View
        {
            set
            {
                this._view = value;
            }
            get
            {
                return this._view;
            }
        }

        public void OnShowTableGroup()
        {

            //
            tableGroupData = new  EclipsePOS.WPF.SystemManager.Data.tableGroupDataSet();
            EclipsePOS.WPF.SystemManager.Data.tableGroupDataSetTableAdapters.table_groupTableAdapter tableGroupTa = new  EclipsePOS.WPF.SystemManager.Data.tableGroupDataSetTableAdapters.table_groupTableAdapter();
            tableGroupTa.Fill(tableGroupData.table_group);
            View.SetTableGroupDataContext(tableGroupData.table_group);

            _colView = CollectionViewSource.GetDefaultView(tableGroupData.table_group) as CollectionView;
            taManager.table_groupTableAdapter = tableGroupTa;

            this.FilterTableGroup();
            //PosConfig
          //  posConfigData = new EclipsePOS.WPF.SystemManager.Data.posConfigDataSet();
          //  EclipsePOS.WPF.SystemManager.Data.posConfigDataSetTableAdapters.pos_configTableAdapter posConfigTa = new EclipsePOS.WPF.SystemManager.Data.posConfigDataSetTableAdapters.pos_configTableAdapter();
          //  posConfigTa.Fill(posConfigData.pos_config);
          //  View.SetPosConfigDataContext(posConfigData.pos_config);


            View.SetMoveToFirstBtnDataContext(MoveToFirstCommand);
            View.SetMoveToPreviousBtnDataContext(MoveToPreviousCommand);
            View.SetMoveToNextBtnDataContext(MoveToNextCommand);
            View.SetMoveToLastBtnDataContext(MoveToLastCommand);

            View.SetDeleteBtnDataContext(DeleteCommand);
            View.SetAddBtnDataContext(AddCommand);
            View.SetRevertBtnDataContext(RevertCommand);
            View.SetSaveBtnDataContext(SaveCommand);

            _colView.CurrentChanged += new EventHandler(_colView_CurrentChanged);

            if (_colView.IsEmpty || _colView.IsCurrentBeforeFirst || _colView.IsCurrentAfterLast)
            {
                View.SetColumnsEnabled(false);
            }
            else
            {
                View.SetColumnsEnabled(true);
            }
        }

        void _colView_CurrentChanged(object sender, EventArgs e)
        {
            if (_colView.IsEmpty || _colView.IsCurrentBeforeFirst || _colView.IsCurrentAfterLast)
            {
                View.SetColumnsEnabled(false);
            }
            else
            {
                View.SetColumnsEnabled(true);
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
            try
            {
                System.Data.DataRow dataRow = ((System.Data.DataRowView)_colView.CurrentItem).Row;
                dataRow.Delete();
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
           
            if (!tableGroupData.HasErrors)
            {

                EclipsePOS.WPF.SystemManager.Data.tableGroupDataSet.table_groupRow dataRow = tableGroupData.table_group.Newtable_groupRow();
                dataRow.organization_no = PosSettings.Default.Organization;
                dataRow.store_no = PosSettings.Default.Store;
                dataRow.table_group_no = 0;
                dataRow.table_group_name = "";

                tableGroupData.table_group.Addtable_groupRow(dataRow);

                _colView.MoveCurrentToLast();
                View.SetSelectedItemCursor();
                this.View.SetFocusToFirstElement();
             
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
            if (tableGroupData.HasChanges())
            {
                MessageBoxResult result = Microsoft.Windows.Controls.MessageBox.Show("Are sure you want to loose all your changes", "Revert command", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result  == MessageBoxResult.Yes)
                {
                    tableGroupData.RejectChanges();
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
            if (tableGroupData.HasErrors)
            {
                Microsoft.Windows.Controls.MessageBox.Show("Please correct the errors first", "Save command", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try
                {

                    if (tableGroupData.HasChanges())
                    {
                        if (taManager.UpdateAll(tableGroupData) > 0)
                        {
                            Microsoft.Windows.Controls.MessageBox.Show("Saved", "Save command", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                }
                catch
                {
                    Microsoft.Windows.Controls.MessageBox.Show("Unable to save changes", "Save command", MessageBoxButton.OK, MessageBoxImage.Error);
                    tableGroupData.RejectChanges();
                }
            }
             
        }

        public bool OnSaveCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion


        public void FilterTableGroup()
        {

            BindingListCollectionView view1 = CollectionViewSource.GetDefaultView(this.tableGroupData.table_group) as BindingListCollectionView;

            if (view1 != null)
            {
                view1.CustomFilter = "organization_no = '" + PosSettings.Default.Organization + "' and " +
                    " store_no = '" + PosSettings.Default.Store.ToString() + "'";
 
               // view1.SortDescriptions.Add(new SortDescription("table_group_no", ListSortDirection.Ascending));

            }

        }

        


    }
}
