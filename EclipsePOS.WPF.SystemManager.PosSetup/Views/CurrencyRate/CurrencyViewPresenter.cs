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

namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.CurrencyRate
{
    public class CurrencyViewPresenter
    {

        private ICurrencyView _view;
        private CollectionView _colView;

        private EclipsePOS.WPF.SystemManager.Data.currencyDataSet currencyData;
        private EclipsePOS.WPF.SystemManager.Data.currencyCodeDataSet homeCurrencyCodeData;
        private EclipsePOS.WPF.SystemManager.Data.currencyCodeDataSet sourceCurrencyCodeData;
        private EclipsePOS.WPF.SystemManager.Data.organizationDataSet organizationData;
        private EclipsePOS.WPF.SystemManager.Data.organizationDataSet.organizationRow organizationRow;


        private EclipsePOS.WPF.SystemManager.Data.currencyDataSetTableAdapters.TableAdapterManager taManager = new EclipsePOS.WPF.SystemManager.Data.currencyDataSetTableAdapters.TableAdapterManager(); 
        public DelegateCommand<object> MoveToFirstCommand;
        public DelegateCommand<object> MoveToPreviousCommand;
        public DelegateCommand<object> MoveToNextCommand;
        public DelegateCommand<object> MoveToLastCommand;

        public DelegateCommand<object> DeleteCommand;
        public DelegateCommand<object> AddCommand;
        public DelegateCommand<object> RevertCommand;
        public DelegateCommand<object> SaveCommand;

        public CurrencyViewPresenter()
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

        public ICurrencyView View
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

        public void OnShowCurrency()
        {

            //Currency code(Home)
            homeCurrencyCodeData = new EclipsePOS.WPF.SystemManager.Data.currencyCodeDataSet();
            EclipsePOS.WPF.SystemManager.Data.currencyCodeDataSetTableAdapters.currency_codeTableAdapter homeCurrencyCodeTa = new EclipsePOS.WPF.SystemManager.Data.currencyCodeDataSetTableAdapters.currency_codeTableAdapter();
            homeCurrencyCodeTa.Fill(homeCurrencyCodeData.currency_code);
            View.SetHomeCurrencyCodeDataContext(homeCurrencyCodeData.currency_code);

            //Currency code(Source)
            sourceCurrencyCodeData = new EclipsePOS.WPF.SystemManager.Data.currencyCodeDataSet();
            EclipsePOS.WPF.SystemManager.Data.currencyCodeDataSetTableAdapters.currency_codeTableAdapter sourceCurrencyCodeTa = new EclipsePOS.WPF.SystemManager.Data.currencyCodeDataSetTableAdapters.currency_codeTableAdapter();
            sourceCurrencyCodeTa.Fill(sourceCurrencyCodeData.currency_code);
            View.SetSourceCurrencyCodeDataContext(sourceCurrencyCodeData.currency_code);

            //Organization
            organizationData = new EclipsePOS.WPF.SystemManager.Data.organizationDataSet();
            EclipsePOS.WPF.SystemManager.Data.organizationDataSetTableAdapters.organizationTableAdapter organizationTa = new EclipsePOS.WPF.SystemManager.Data.organizationDataSetTableAdapters.organizationTableAdapter();
            organizationTa.Fill(organizationData.organization);
            organizationRow = organizationData.organization.FindByorganization_no(PosSettings.Default.Organization);


            //Currency
            currencyData = new  EclipsePOS.WPF.SystemManager.Data.currencyDataSet();
            EclipsePOS.WPF.SystemManager.Data.currencyDataSetTableAdapters.currencyTableAdapter currencyTa = new  EclipsePOS.WPF.SystemManager.Data.currencyDataSetTableAdapters.currencyTableAdapter();
            currencyTa.Fill(currencyData.currency);
            View.SetCurrencyDataContext(currencyData.currency);

            _colView = CollectionViewSource.GetDefaultView(currencyData.currency) as CollectionView;
            taManager.currencyTableAdapter = currencyTa;

           
           

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
            if (!currencyData.HasErrors)
            {

                EclipsePOS.WPF.SystemManager.Data.currencyDataSet.currencyRow dataRow = currencyData.currency.NewcurrencyRow();

                //dataRow.currency_id = -1;

                dataRow.date_match = DateTime.Now;
                dataRow.home_currency = organizationRow.home_currency;
                dataRow.rate_operator = 1;
                dataRow.rate_date = DateTime.Now;
                dataRow.source_currency = "";
                dataRow.spread = 0;
                dataRow.conversion_rate = 0;
                                 
                
                currencyData.currency.AddcurrencyRow(dataRow);

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
            if (currencyData.HasChanges())
            {
                MessageBoxResult result = Microsoft.Windows.Controls.MessageBox.Show("Are sure you want to loose all your changes", "Revert command", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    currencyData.RejectChanges();
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
            if (currencyData.HasErrors)
            {
                Microsoft.Windows.Controls.MessageBox.Show("Please correct the errors first", "Save command", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (currencyData.HasChanges())
                {
                    try
                    {
                        if (taManager.UpdateAll(currencyData) > 0)
                        {
                            Microsoft.Windows.Controls.MessageBox.Show("Saved", "Save command", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    catch(Exception ex)
                    {
                        Microsoft.Windows.Controls.MessageBox.Show("Unable to save changes", "Save command", MessageBoxButton.OK, MessageBoxImage.Error);
                        this.currencyData.RejectChanges();
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

        public void FilterCurrencyByOrganizationNo(int organizationNo)
        {

            BindingListCollectionView view2 = CollectionViewSource.GetDefaultView(this.currencyData.currency) as BindingListCollectionView;

            if (view2 != null)
            {
                view2.CustomFilter = "organization_no = " + organizationNo.ToString();

            }

        }

      

    }
}
