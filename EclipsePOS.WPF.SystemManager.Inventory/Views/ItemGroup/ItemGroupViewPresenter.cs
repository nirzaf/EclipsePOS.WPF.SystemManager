﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Composite.Events;
using Microsoft.Practices.Composite.Presentation.Commands;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows;


namespace EclipsePOS.WPF.SystemManager.Inventory.Views.ItemGroup
{
    public class ItemGroupViewPresenter
    {
        private IItemGroupView _view;
        private CollectionView _colView;
        private EclipsePOS.WPF.SystemManager.Data.ItemGroupDataSet groupData;
        private EclipsePOS.WPF.SystemManager.Data.ItemGroupDataSetTableAdapters.TableAdapterManager taManager = new EclipsePOS.WPF.SystemManager.Data.ItemGroupDataSetTableAdapters.TableAdapterManager();

        private EclipsePOS.WPF.SystemManager.Data.organizationLookupDataSet organizationData;

        public DelegateCommand<object> MoveToFirstCommand;
        public DelegateCommand<object> MoveToPreviousCommand;
        public DelegateCommand<object> MoveToNextCommand;
        public DelegateCommand<object> MoveToLastCommand;

        public DelegateCommand<object> DeleteCommand;
        public DelegateCommand<object> AddCommand;
        public DelegateCommand<object> RevertCommand;
        public DelegateCommand<object> SaveCommand;

        public ItemGroupViewPresenter()
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


        public IItemGroupView View
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

        public void OnShowItemGroup()
        {
            //Organization
            organizationData = new EclipsePOS.WPF.SystemManager.Data.organizationLookupDataSet();
            EclipsePOS.WPF.SystemManager.Data.organizationLookupDataSetTableAdapters.organizationTableAdapter organizationTa = new EclipsePOS.WPF.SystemManager.Data.organizationLookupDataSetTableAdapters.organizationTableAdapter();
            organizationTa.Fill(organizationData.organization);
            View.SetOrganizationDataContext(organizationData.organization);

            //Item Group
            groupData = new EclipsePOS.WPF.SystemManager.Data.ItemGroupDataSet();
            EclipsePOS.WPF.SystemManager.Data.ItemGroupDataSetTableAdapters.ItemGroupTableAdapter groupTa = new EclipsePOS.WPF.SystemManager.Data.ItemGroupDataSetTableAdapters.ItemGroupTableAdapter();
            groupTa.Fill(groupData.ItemGroup);
            View.SetItemGroupDataContext(groupData.ItemGroup);

            _colView = CollectionViewSource.GetDefaultView(groupData.ItemGroup) as CollectionView;
            taManager.ItemGroupTableAdapter = groupTa;


            View.SetMoveToFirstBtnDataContext(MoveToFirstCommand);
            View.SetMoveToPreviousBtnDataContext(MoveToPreviousCommand);
            View.SetMoveToNextBtnDataContext(MoveToNextCommand);
            View.SetMoveToLastBtnDataContext(MoveToLastCommand);

            View.SetDeleteBtnDataContext(DeleteCommand);
            View.SetAddBtnDataContext(AddCommand);
            View.SetRevertBtnDataContext(RevertCommand);
            View.SetSaveBtnDataContext(SaveCommand);

            _colView.CurrentChanged += new EventHandler(_colView_CurrentChanged);
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
            if (!groupData.HasErrors)
            {

                EclipsePOS.WPF.SystemManager.Data.ItemGroupDataSet.ItemGroupRow dataRow = groupData.ItemGroup.NewItemGroupRow();
                dataRow.organization_no = this.View.SelectedOrganizationNo();
                dataRow.group_id = "";
                dataRow.group_name = "";

                groupData.ItemGroup.AddItemGroupRow(dataRow);

                _colView.MoveCurrentToLast();
                View.SetSelectedItemCursor();
                View.SetFocusToFirstInputField();
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
            if (groupData.HasChanges())

                    //MessageBox.Show("Are sure you want to loose all your changes", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning))
                {
                    MessageBoxResult result = Microsoft.Windows.Controls.MessageBox.Show("Are sure you want to loose all your changes", "Revert Command", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes )
                    {
                        groupData.RejectChanges();
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
            if (groupData.HasErrors)
            {
                //MessageBox.Show("Please correct the errors first");
                Microsoft.Windows.Controls.MessageBox.Show("Please correct the errors first", "Save Command", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    if (groupData.HasChanges())
                    {
                        if (taManager.UpdateAll(groupData) > 0)
                        {
                            //MessageBox.Show("Saved");
                            Microsoft.Windows.Controls.MessageBox.Show("Saved", "Save Command", MessageBoxButton.OK, MessageBoxImage.Information);
                           // Microsoft..w
                        }
                    }
                }
                catch
                {
                    //MessageBox.Show("Unable to save changes");
                    Microsoft.Windows.Controls.MessageBox.Show("Unable to save changes", "Save Command", MessageBoxButton.OK, MessageBoxImage.Error);
                    groupData.RejectChanges();
                }
            }
        }

        public bool OnSaveCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion

        public void FilterItemGroupDByOrganizationNo(string organizationNo)
        {

            BindingListCollectionView view1 = CollectionViewSource.GetDefaultView(this.groupData.ItemGroup) as BindingListCollectionView;

            if (view1 != null)
            {
                view1.CustomFilter = "organization_no = '" + organizationNo.ToString() + "'";

            }

        }


    }
}
