using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Composite.Presentation.Events;
using Microsoft.Practices.Composite.Presentation.Commands;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows;



namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.Customer
{
    public class CustomerViewPresenter
    {
        private ICustomerView _view;
        private CollectionView _colView;
        
        private EclipsePOS.WPF.SystemManager.Data.customerDataSet customerData;
        private EclipsePOS.WPF.SystemManager.Data.organizationLookupDataSet organizationData;

        private EclipsePOS.WPF.SystemManager.Data.customerDataSetTableAdapters.TableAdapterManager taManager = new EclipsePOS.WPF.SystemManager.Data.customerDataSetTableAdapters.TableAdapterManager();
        public DelegateCommand<object> MoveToFirstCommand;
        public DelegateCommand<object> MoveToPreviousCommand;
        public DelegateCommand<object> MoveToNextCommand;
        public DelegateCommand<object> MoveToLastCommand;

        public DelegateCommand<object> DeleteCommand;
        public DelegateCommand<object> AddCommand;
        public DelegateCommand<object> RevertCommand;
        public DelegateCommand<object> SaveCommand;


        public CustomerViewPresenter()
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



        public ICustomerView View
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

        public void OnShowCustomer()
        {

            //Organization
            organizationData = new EclipsePOS.WPF.SystemManager.Data.organizationLookupDataSet();
            EclipsePOS.WPF.SystemManager.Data.organizationLookupDataSetTableAdapters.organizationTableAdapter organizationTa = new EclipsePOS.WPF.SystemManager.Data.organizationLookupDataSetTableAdapters.organizationTableAdapter();
            organizationTa.Fill(organizationData.organization);
            View.SetOrganizationDataContext(organizationData.organization);

            //Customer
            customerData = new EclipsePOS.WPF.SystemManager.Data.customerDataSet();
            EclipsePOS.WPF.SystemManager.Data.customerDataSetTableAdapters.customerTableAdapter customerTa = new EclipsePOS.WPF.SystemManager.Data.customerDataSetTableAdapters.customerTableAdapter();
            customerTa.Fill(customerData.customer);
            View.SetCustomerDataContext(customerData.customer);

            _colView = CollectionViewSource.GetDefaultView(customerData.customer) as CollectionView;
            taManager.customerTableAdapter = customerTa;

          
            View.SetMoveToFirstBtnDataContext(MoveToFirstCommand);
            View.SetMoveToPreviousBtnDataContext(MoveToPreviousCommand);
            View.SetMoveToNextBtnDataContext(MoveToNextCommand);
            View.SetMoveToLastBtnDataContext(MoveToLastCommand);

            View.SetDeleteBtnDataContext(DeleteCommand);
            View.SetAddBtnDataContext(AddCommand);
            View.SetRevertBtnDataContext(RevertCommand);
            View.SetSaveBtnDataContext(SaveCommand);

            _colView.CurrentChanged +=new EventHandler(_colView_CurrentChanged);

        }

        void _colView_CurrentChanged(object sender, EventArgs e)
        {
            if (_colView.IsEmpty || _colView.IsCurrentAfterLast || _colView.IsCurrentBeforeFirst)
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

            if (!customerData.HasErrors)
            {

                EclipsePOS.WPF.SystemManager.Data.customerDataSet.customerRow dataRow = customerData.customer.NewcustomerRow();

                dataRow.addr1 = "";
                dataRow.organization_no = this.View.SelectedOrganizationNo();
                dataRow.addr2 = "";
                dataRow.alt_phone = "";
                dataRow.card = "";
                dataRow.city = "";
                dataRow.country = "";
                dataRow.current_debt = 0;
                dataRow.customer_first_name = "";
                dataRow.customer_last_name = "";
                dataRow.customer_search_key = "";
                dataRow.creation_date = System.DateTime.Now; 
                dataRow.email = "";
                dataRow.fax = "";
                dataRow.max_debt = 0;
                dataRow.notes = "";
                dataRow.phone = "";
                dataRow.postel_code = "";
                dataRow.region = "";
                dataRow.status = 1;
                dataRow.tax_id = "";
                



                customerData.customer.AddcustomerRow(dataRow);

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
            if (customerData.HasChanges())
            {   
                MessageBoxResult result =  Microsoft.Windows.Controls.MessageBox.Show("Are sure you want to loose all your changes", "Revert command", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if ( result == MessageBoxResult.Yes)
                {
                    customerData.RejectChanges();
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
            if (customerData.HasErrors)
            {
                Microsoft.Windows.Controls.MessageBox.Show("Please correct the errors first", "Save command", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (customerData.HasChanges())
                {
                    try
                    {
                        if (taManager.UpdateAll(customerData) > 0)
                        {
                            Microsoft.Windows.Controls.MessageBox.Show("Saved", "Save command", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        Microsoft.Windows.Controls.MessageBox.Show("Unable to save changes" , "Save command", MessageBoxButton.OK, MessageBoxImage.Error);
                        this.customerData.RejectChanges();
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

       public void FilterCustomerByOrganizationNo(string organizationNo)
        {

            BindingListCollectionView view2 = CollectionViewSource.GetDefaultView(this.customerData.customer) as BindingListCollectionView;

            if (view2 != null)
            {
                view2.CustomFilter = "organization_no = '" + organizationNo + "'";

            }

        }
       

    }
}
