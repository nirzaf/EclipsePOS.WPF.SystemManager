using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Composite.Events;
using Microsoft.Practices.Composite.Wpf.Commands;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows;

namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.StoreGroup
{
    public class StoreGroupViewPresenter
    {
        private IStoreGroupView _view;
        private CollectionView _colView;

        private EclipsePOS.WPF.SystemManager.Data.StoreGroupDataSet storeGroupData;


       private EclipsePOS.WPF.SystemManager.Data.StoreGroupDataSetTableAdapters.TableAdapterManager taManager = new  EclipsePOS.WPF.SystemManager.Data.StoreGroupDataSetTableAdapters.TableAdapterManager();

        public DelegateCommand<object> MoveToFirstCommand;
        public DelegateCommand<object> MoveToPreviousCommand;
        public DelegateCommand<object> MoveToNextCommand;
        public DelegateCommand<object> MoveToLastCommand;

        public DelegateCommand<object> DeleteCommand;
        public DelegateCommand<object> AddCommand;
        public DelegateCommand<object> RevertCommand;
        public DelegateCommand<object> SaveCommand;


        public StoreGroupViewPresenter()
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

        public IStoreGroupView View
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

        public void OnShowStoreGroup()
        {

            //StoreGroup
            storeGroupData = new EclipsePOS.WPF.SystemManager.Data.StoreGroupDataSet();
            EclipsePOS.WPF.SystemManager.Data.StoreGroupDataSetTableAdapters.RetailStoreGroupTableAdapter storeGroupTa = new EclipsePOS.WPF.SystemManager.Data.StoreGroupDataSetTableAdapters.RetailStoreGroupTableAdapter();
            storeGroupTa.Fill(storeGroupData.RetailStoreGroup);
            View.SetStoreGroupDataContext(storeGroupData.RetailStoreGroup);

            _colView = CollectionViewSource.GetDefaultView(storeGroupData.RetailStoreGroup) as CollectionView;
            taManager.RetailStoreGroupTableAdapter = storeGroupTa;



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
            System.Data.DataRow dataRow = ((System.Data.DataRowView)_colView.CurrentItem).Row;
            dataRow.Delete();

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
            if (!storeGroupData.HasErrors)
            {

                EclipsePOS.WPF.SystemManager.Data.StoreGroupDataSet.RetailStoreGroupRow  dataRow = storeGroupData.RetailStoreGroup.NewRetailStoreGroupRow();

                dataRow.OrganizationID = 1;
                dataRow.RetailStoreGroupID = "";
                dataRow.LanguageID = "";
                dataRow.RetailStoreGroupName = "";
                
                storeGroupData.RetailStoreGroup.AddRetailStoreGroupRow(dataRow);

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
            if (storeGroupData.HasChanges())
                if (MessageBoxResult.Yes == MessageBox.Show("Are sure you want to loose all your changes", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning))
                {
                    storeGroupData.RejectChanges();
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
            if (storeGroupData.HasErrors)
            {
                MessageBox.Show("Please correct the errors first");
            }
            else
            {
                if (storeGroupData.HasChanges())
                {
                    if (taManager.UpdateAll(storeGroupData) > 0)
                    {
                        MessageBox.Show("Saved");
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


    }
}
