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

namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.Tax
{
    public class TaxViewPresenter
    {

        private ITaxView _view;
        private CollectionView _colView;

        private EclipsePOS.WPF.SystemManager.Data.taxDataSet taxData;
        private EclipsePOS.WPF.SystemManager.Data.organizationLookupDataSet organizationData;
        private EclipsePOS.WPF.SystemManager.Data.taxGroupDataSet taxGroupData;
        


        private EclipsePOS.WPF.SystemManager.Data.taxDataSetTableAdapters.TableAdapterManager taManager = new  EclipsePOS.WPF.SystemManager.Data.taxDataSetTableAdapters.TableAdapterManager();

        public DelegateCommand<object> MoveToFirstCommand;
        public DelegateCommand<object> MoveToPreviousCommand;
        public DelegateCommand<object> MoveToNextCommand;
        public DelegateCommand<object> MoveToLastCommand;

        public DelegateCommand<object> DeleteCommand;
        public DelegateCommand<object> AddCommand;
        public DelegateCommand<object> RevertCommand;
        public DelegateCommand<object> SaveCommand;


        public TaxViewPresenter()
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

        public ITaxView View
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

        public void OnShowTax()
        {
           
            //Organization
            organizationData = new EclipsePOS.WPF.SystemManager.Data.organizationLookupDataSet();
            EclipsePOS.WPF.SystemManager.Data.organizationLookupDataSetTableAdapters.organizationTableAdapter organizationTa = new EclipsePOS.WPF.SystemManager.Data.organizationLookupDataSetTableAdapters.organizationTableAdapter();
            organizationTa.Fill(organizationData.organization);
            View.SetOrganizationDataContext(organizationData.organization);

            //tax group data
            taxGroupData = new EclipsePOS.WPF.SystemManager.Data.taxGroupDataSet();
            EclipsePOS.WPF.SystemManager.Data.taxGroupDataSetTableAdapters.tax_groupTableAdapter taxGroupTa = new EclipsePOS.WPF.SystemManager.Data.taxGroupDataSetTableAdapters.tax_groupTableAdapter();
            taxGroupTa.Fill(taxGroupData.tax_group);
            View.SetTaxGroupDataContext(taxGroupData.tax_group);
            this.FilterTaxGroupByOrganizationNo(PosSettings.Default.Organization);

            //Tax
            taxData = new EclipsePOS.WPF.SystemManager.Data.taxDataSet();
            EclipsePOS.WPF.SystemManager.Data.taxDataSetTableAdapters.taxTableAdapter taxTa = new EclipsePOS.WPF.SystemManager.Data.taxDataSetTableAdapters.taxTableAdapter();
            taxTa.Fill(taxData.tax);
            View.SetTaxDataContext(taxData.tax);

            taManager.taxTableAdapter = taxTa;

            _colView = CollectionViewSource.GetDefaultView(taxData.tax) as CollectionView;
           

            View.SetMoveToFirstBtnDataContext(MoveToFirstCommand);
            View.SetMoveToPreviousBtnDataContext(MoveToPreviousCommand);
            View.SetMoveToNextBtnDataContext(MoveToNextCommand);
            View.SetMoveToLastBtnDataContext(MoveToLastCommand);

            View.SetDeleteBtnDataContext(DeleteCommand);
            View.SetAddBtnDataContext(AddCommand);
            View.SetRevertBtnDataContext(RevertCommand);
            View.SetSaveBtnDataContext(SaveCommand);

            this.FilterTaxByOrganizationNo(PosSettings.Default.Organization);

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
            if (string.IsNullOrEmpty(View.SelectedOrganizationNo()))
            {
                Microsoft.Windows.Controls.MessageBox.Show("Please set the default organization and try this option again", "Add command", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!taxData.HasErrors)
            {

                EclipsePOS.WPF.SystemManager.Data.taxDataSet.taxRow dataRow = taxData.tax.NewtaxRow();

                dataRow.tax_id  = -1;
                dataRow.tax_group_id = "";
                dataRow.tax_type = 0;
                dataRow.organization_no = View.SelectedOrganizationNo() ;
                dataRow.short_desc = "";
                dataRow.rate = 0;
                dataRow.alt_rate = 0;
                
                taxData.tax.AddtaxRow(dataRow);

                _colView.MoveCurrentToLast();
                View.SetSelectedItemCursor();
                View.SetFocusToFirstElement();
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
            if (taxData.HasChanges())
            {
                MessageBoxResult result = Microsoft.Windows.Controls.MessageBox.Show("Are sure you want to loose all your changes", "Revert command", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes )
                {
                    taxData.RejectChanges();
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
            if (taxData.HasErrors)
            {
                Microsoft.Windows.Controls.MessageBox.Show("Please correct the errors first", "Save command", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (taxData.HasChanges())
                {
                    if (taManager.UpdateAll(taxData) > 0)
                    {
                        Microsoft.Windows.Controls.MessageBox.Show("Saved", "Save command", MessageBoxButton.OK, MessageBoxImage.Information);
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

        public void FilterTaxByOrganizationNo(string organizationNo)
        {

            BindingListCollectionView view1 = CollectionViewSource.GetDefaultView(this.taxData.tax) as BindingListCollectionView;

            if (view1 != null)
            {
                view1.CustomFilter = "organization_no = '" + organizationNo + "'";

                view1.GroupDescriptions.Clear();
                PropertyGroupDescription groupDescription = new PropertyGroupDescription();
                groupDescription.PropertyName = "tax_group_id";
                view1.GroupDescriptions.Add(groupDescription);


            }

        }

        public void FilterTaxGroupByOrganizationNo(string organizationNo)
        {

            BindingListCollectionView view1 = CollectionViewSource.GetDefaultView(this.taxGroupData.tax_group) as BindingListCollectionView;

            if (view1 != null)
            {
                view1.CustomFilter = "organization_no = '" + organizationNo+ "'";

                view1.GroupDescriptions.Clear();
                PropertyGroupDescription groupDescription = new PropertyGroupDescription();
                groupDescription.PropertyName = "tax_group_id";
                view1.GroupDescriptions.Add(groupDescription);

            }

        }

    }
}
