using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using EclipsePOS.WPF.SystemManager.Data;
using EclipsePOS.WPF.SystemManager.Data.organizationDataSetTableAdapters;
using Microsoft.Practices.Composite.Presentation.Events;
using Microsoft.Practices.Composite.Presentation.Commands;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows;



namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.Organization
{
    public class OrganizationViewPresenter
    {
        //private IEventAggregator _eventAggregator;
        private IOrganizationView _view;
        private ICollectionView _colView;
        private organizationDataSet orgData;
        private TableAdapterManager taManager = new TableAdapterManager();

        private EclipsePOS.WPF.SystemManager.Data.currencyCodeDataSet homeCurrencyCodeData;
       


        public DelegateCommand<object> MoveToFirstCommand;
        public DelegateCommand<object> MoveToPreviousCommand;
        public DelegateCommand<object> MoveToNextCommand;
        public DelegateCommand<object> MoveToLastCommand;

        public DelegateCommand<object> DeleteCommand;
        public DelegateCommand<object> AddCommand;
        public DelegateCommand<object> RevertCommand;
        public DelegateCommand<object> SaveCommand;


        

        public OrganizationViewPresenter()
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

        public IOrganizationView View
        {
            get
            {
                return _view;
            }
            set
            {
                _view = value;
            }
        }

     //   public void OnShowOrganizationDetails(object obj)
     //   {
           // FundAddedEvent fundAddedEvent = this.eventAggregator.GetEvent<FundAddedEvent>(); 

           // View.
           // OrgListViewSelectionChangedEvent itemChangeEvent = this.eventAggregator.GetEvent<OrgListViewSelectionChangedEvent>();
           // itemChangeEvent.Publish(null);
           // MessageBox.Show(_colView.CurrentPosition.ToString());
           // View.ShowOrganizationDetails(obj);
      //      _colView.MoveCurrentTo(obj);
      //     
       //}


        public void OnShowOrganizations()
        {
            //Currency
            homeCurrencyCodeData = new EclipsePOS.WPF.SystemManager.Data.currencyCodeDataSet();
            EclipsePOS.WPF.SystemManager.Data.currencyCodeDataSetTableAdapters.currency_codeTableAdapter homeCurrencyCodeTa = new EclipsePOS.WPF.SystemManager.Data.currencyCodeDataSetTableAdapters.currency_codeTableAdapter();
            homeCurrencyCodeTa.Fill(homeCurrencyCodeData.currency_code);
            View.SetCurrencyDataContext(homeCurrencyCodeData.currency_code);
           
            //Organization
            orgData = new organizationDataSet();
            organizationTableAdapter taOrg = new organizationTableAdapter();
            taOrg.Fill(orgData.organization);
            View.SetOrganizationDataContext(orgData.organization);
 
            _colView = CollectionViewSource.GetDefaultView(orgData.organization);
            taManager.organizationTableAdapter = taOrg;
           


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
            if (!orgData.HasErrors)
            {

                organizationDataSet.organizationRow dataRow = orgData.organization.NeworganizationRow();
                
                dataRow.organization_no = " ";
                dataRow.organization_name = " ";
                dataRow.address1 = " ";
                dataRow.address2 = " ";
                dataRow.home_currency = " ";
                dataRow.pos_shipment_code_length  =22;
                dataRow.pos_shipment_next_number = 1;
                dataRow.pos_shipment_prefix = "POS";

                orgData.organization.AddorganizationRow(dataRow);
                
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
            if (orgData.HasChanges())
            {
                MessageBoxResult result = Microsoft.Windows.Controls.MessageBox.Show("Are sure you want to loose all your changes", "Revert command", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    orgData.RejectChanges();
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
            

            if (orgData.HasErrors)
            {
                Microsoft.Windows.Controls.MessageBox.Show("Please correct the errors first", "Save command", MessageBoxButton.OK, MessageBoxImage.Error);

                //System.Data.DataRow[] rows  = orgData.organization.GetErrors();
                //foreach (object obj in rows)
                //{
                //    MessageBox.Show(obj.ToString());
                //}

            }
            else
            {

                if (orgData.HasChanges())
                {
                    try
                    {
                        if (taManager.UpdateAll(orgData) > 0)
                        {
                            Microsoft.Windows.Controls.MessageBox.Show("Saved" , "Save command", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    catch (Exception e)
                    {
                        Microsoft.Windows.Controls.MessageBox.Show("Unable to save changes.", "Save command", MessageBoxButton.OK, MessageBoxImage.Error);
                        orgData.RejectChanges();
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




        
        
        
       // public void OnRevert()
       // {
       //     if (orgData.HasChanges() )
       //         if (MessageBoxResult.Yes == MessageBox.Show("Are sure you want to loose all your changes", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning))
       //         {
       //             orgData.RejectChanges();
       //         }
       // 
       // }

    }
}
