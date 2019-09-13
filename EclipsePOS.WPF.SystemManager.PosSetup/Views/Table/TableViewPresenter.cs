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


namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.Table
{
    public class TableViewPresenter
    {
        private ITableView _view;
        private CollectionView _colView;

        private EclipsePOS.WPF.SystemManager.Data.tableDetailsDataSet tableData;
        private EclipsePOS.WPF.SystemManager.Data.tableGroupDataSet tableGroupData;



        private EclipsePOS.WPF.SystemManager.Data.tableDetailsDataSetTableAdapters.TableAdapterManager  taManager = new  EclipsePOS.WPF.SystemManager.Data.tableDetailsDataSetTableAdapters.TableAdapterManager();

        public DelegateCommand<object> MoveToFirstCommand;
        public DelegateCommand<object> MoveToPreviousCommand;
        public DelegateCommand<object> MoveToNextCommand;
        public DelegateCommand<object> MoveToLastCommand;

        public DelegateCommand<object> DeleteCommand;
        public DelegateCommand<object> AddCommand;
        public DelegateCommand<object> RevertCommand;
        public DelegateCommand<object> SaveCommand;

       

        public TableViewPresenter()
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

        public ITableView View
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

        public void OnShowTableViewPresenter()
        {

            //Table Group
            tableGroupData = new EclipsePOS.WPF.SystemManager.Data.tableGroupDataSet();
            EclipsePOS.WPF.SystemManager.Data.tableGroupDataSetTableAdapters.table_groupTableAdapter tableGroupTa = new EclipsePOS.WPF.SystemManager.Data.tableGroupDataSetTableAdapters.table_groupTableAdapter();
            tableGroupTa.Fill(tableGroupData.table_group);
            View.SetTableGroupDataContext(tableGroupData.table_group);
            this.FilterTableGroup();

            
            tableData = new EclipsePOS.WPF.SystemManager.Data.tableDetailsDataSet();
            EclipsePOS.WPF.SystemManager.Data.tableDetailsDataSetTableAdapters.table_detailsTableAdapter tableTa = new EclipsePOS.WPF.SystemManager.Data.tableDetailsDataSetTableAdapters.table_detailsTableAdapter();
            tableTa.Fill(tableData.table_details);
            View.SetTableDataContext(tableData.table_details);
            //View.SetTableModel(tableData.table_details); 

            _colView = CollectionViewSource.GetDefaultView(tableData.table_details) as CollectionView;
            taManager.table_detailsTableAdapter = tableTa;

           
           

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
            System.Data.DataRow dataRow = ((System.Data.DataRowView)_colView.CurrentItem).Row;
            dataRow.Delete();
            View.DrawTableModel();

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

            if (View.SelectedTableGroupNo() <= 0 )
            {
                Microsoft.Windows.Controls.MessageBox.Show("Please set up table group and try this option again", "Add command", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
          
            if (!tableData.HasErrors)
            {

                EclipsePOS.WPF.SystemManager.Data.tableDetailsDataSet.table_detailsRow dataRow = tableData.table_details.Newtable_detailsRow();
                dataRow.organization_no = PosSettings.Default.Organization;
                dataRow.store_no = PosSettings.Default.Store;
                dataRow.table_group_no = this.View.SelectedTableGroupNo();
                dataRow.table_name = " ";
                //dataRow.table_no = 99;
                dataRow.display_row_no = 7;
                dataRow.display_column_no = 9;
                dataRow.number_of_guests = 0;

                tableData.table_details.Addtable_detailsRow(dataRow);

                _colView.MoveCurrentToLast();
                View.SetSelectedItemCursor();

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
            if (tableData.HasChanges())
            {
                MessageBoxResult result = Microsoft.Windows.Controls.MessageBox.Show("Are sure you want to loose all your changes", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result  == MessageBoxResult.Yes )
                {
                    tableData.RejectChanges();
                    View.DrawTableModel();

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
            if (tableData.HasErrors)
            {
                Microsoft.Windows.Controls.MessageBox.Show("Please correct the errors first", "Save command", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    if (tableData.HasChanges())
                    {
                        if (taManager.UpdateAll(tableData) > 0)
                        {
                            Microsoft.Windows.Controls.MessageBox.Show("Saved", "Save command", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                }
                catch
                {
                    Microsoft.Windows.Controls.MessageBox.Show("Unable to save changes", "Save command", MessageBoxButton.OK, MessageBoxImage.Error);
                    tableData.RejectChanges();
                }
            }

        }

        public bool OnSaveCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion


        public void FilterTableDetailsByTableGroupNo(int tableGroupNo)
        {
            

            BindingListCollectionView view1 = CollectionViewSource.GetDefaultView(tableData.table_details) as BindingListCollectionView;

            if (view1 != null)
            {
                view1.CustomFilter = "table_group_no = " + tableGroupNo.ToString() + " and " +
                                     " organization_no = '" + PosSettings.Default.Organization.ToString() + "' and " +
                                     " store_no = '" + PosSettings.Default.Store.ToString()+ "'";

            }
             

        }


        public void FilterTableGroup()
        {


            BindingListCollectionView view1 = CollectionViewSource.GetDefaultView( this.tableGroupData.table_group ) as BindingListCollectionView;

            if (view1 != null)
            {
                view1.CustomFilter = " organization_no = '" + PosSettings.Default.Organization + "' and " +
                                     " store_no = '" + PosSettings.Default.Store + "'";

            }


        }


        public void SetTablePosition(object obj)
        {
            _colView.MoveCurrentTo(obj);
            View.SetSelectedItemCursor();
        }








    }
}
