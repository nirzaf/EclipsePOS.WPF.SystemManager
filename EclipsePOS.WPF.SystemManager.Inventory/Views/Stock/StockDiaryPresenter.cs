using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Practices.Composite.Events;
using Microsoft.Practices.Composite.Presentation.Commands;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows;

using EclipsePOS.WPF.SystemManager.PosSetup.Util;



namespace EclipsePOS.WPF.SystemManager.Inventory.Views.Stock
{
    public class StockDiaryPresenter
    {
      
        private CollectionView _colView;

        private EclipsePOS.WPF.SystemManager.Data.ItemsDataSet itemData;
        private EclipsePOS.WPF.SystemManager.Data.transStockDataSet stockData;
        private EclipsePOS.WPF.SystemManager.Data.updateStockBalanceDataSet stockBalanceData;

        private EclipsePOS.WPF.SystemManager.Data.organizationLookupDataSet organizationData;
        

        private EclipsePOS.WPF.SystemManager.Data.ItemsDataSetTableAdapters.TableAdapterManager taManager = new EclipsePOS.WPF.SystemManager.Data.ItemsDataSetTableAdapters.TableAdapterManager();
        private EclipsePOS.WPF.SystemManager.Data.transStockDataSetTableAdapters.TableAdapterManager taManagerTransStock = new EclipsePOS.WPF.SystemManager.Data.transStockDataSetTableAdapters.TableAdapterManager();
        private EclipsePOS.WPF.SystemManager.Data.updateStockBalanceDataSetTableAdapters.QueriesTableAdapter taManagerStockBalance = new EclipsePOS.WPF.SystemManager.Data.updateStockBalanceDataSetTableAdapters.QueriesTableAdapter();

        public DelegateCommand<object> MoveToFirstCommand;
        public DelegateCommand<object> MoveToPreviousCommand;
        public DelegateCommand<object> MoveToNextCommand;
        public DelegateCommand<object> MoveToLastCommand;

        public DelegateCommand<object> DeleteCommand;
        public DelegateCommand<object> AddCommand;
        public DelegateCommand<object> RevertCommand;
        public DelegateCommand<object> SaveCommand;

        //public DelegateCommand<object> FilterCommand;

        private string org_no;


        private IStockDiaryView _view;


        public StockDiaryPresenter()
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



        public IStockDiaryView View
        {
            get
            {
                return this._view;
            }
            set
            {
                this._view = value;
            }
        }

        public void OnShowItems()
        {


            //Organization
            organizationData = new EclipsePOS.WPF.SystemManager.Data.organizationLookupDataSet();
            EclipsePOS.WPF.SystemManager.Data.organizationLookupDataSetTableAdapters.organizationTableAdapter organizationTa = new EclipsePOS.WPF.SystemManager.Data.organizationLookupDataSetTableAdapters.organizationTableAdapter();
            organizationTa.Fill(organizationData.organization);
            View.SetOrganizationDataContext(organizationData.organization);

           
           

            //Item
            itemData = new EclipsePOS.WPF.SystemManager.Data.ItemsDataSet();
            EclipsePOS.WPF.SystemManager.Data.ItemsDataSetTableAdapters.itemTableAdapter taItem = new EclipsePOS.WPF.SystemManager.Data.ItemsDataSetTableAdapters.itemTableAdapter();
            taItem.Fill(itemData.item);
            View.SetItemsDataContext(itemData.item);

            _colView = CollectionViewSource.GetDefaultView(itemData.item) as CollectionView;
            taManager.itemTableAdapter = taItem;


            //Trans Stock
            stockData = new EclipsePOS.WPF.SystemManager.Data.transStockDataSet();
            EclipsePOS.WPF.SystemManager.Data.transStockDataSetTableAdapters.trans_stockTableAdapter taTransStock = new EclipsePOS.WPF.SystemManager.Data.transStockDataSetTableAdapters.trans_stockTableAdapter();
            
            taManagerTransStock.trans_stockTableAdapter = taTransStock;

            //Stock Balance
            stockBalanceData = new EclipsePOS.WPF.SystemManager.Data.updateStockBalanceDataSet();
            

            View.SetMoveToFirstBtnDataContext(MoveToFirstCommand);
            View.SetMoveToPreviousBtnDataContext(MoveToPreviousCommand);
            View.SetMoveToNextBtnDataContext(MoveToNextCommand);
            View.SetMoveToLastBtnDataContext(MoveToLastCommand);

            View.SetDeleteBtnDataContext(DeleteCommand);
            View.SetAddBtnDataContext(AddCommand);
            View.SetRevertBtnDataContext(RevertCommand);
            View.SetSaveBtnDataContext(SaveCommand);

            // View.SetFilterBtnDataContext(FilterCommand);

            //_colView.CurrentChanged += new EventHandler(_colView_CurrentChanged);

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
            try
            {
                double qty = 0;
                switch (View.GetTransactionType())
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                        qty = View.GetQuantity();
                        break;
                    case 11:
                    case 12:
                    case 13:
                    case 14:
                    case 15:
                        qty = View.GetQuantity() * (-1);
                        break;
                }
                EclipsePOS.WPF.SystemManager.Data.transStockDataSet.trans_stockRow dataRow = stockData.trans_stock.Newtrans_stockRow();
                dataRow.organization_no = this.View.SelectedOrganizationNo();
                dataRow.sku = View.GetSKU();
                dataRow.store_no = PosSettings.Default.Store;
                dataRow.transaction_time = View.GetSelectedDate();
                dataRow.transaction_type = (short)View.GetTransactionType();
                dataRow.reference_number = View.GetReference();
                dataRow.quantity = (decimal)qty;
                stockData.trans_stock.Addtrans_stockRow(dataRow);

                if (stockData.HasChanges() && !stockData.HasErrors)
                {
                    taManagerTransStock.UpdateAll(stockData);

                    taManagerStockBalance.Update_stock_balance(this.View.SelectedOrganizationNo(), PosSettings.Default.Store, this.View.GetSKU(), (decimal)qty);

                    View.InitInput();
                }


            }
            catch (Exception e)
            {
                Microsoft.Windows.Controls.MessageBox.Show("Please correct the errors first" + "\\n" + e.ToString() , "Save Command", MessageBoxButton.OK, MessageBoxImage.Error);
            }


           // groupData.ItemGroup.AddItemGroupRow(dataRow);
            
        }

        public bool OnSaveCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion



        public void FilterItemByOrganizationNo(string organizationNo)
        {
            this.org_no = organizationNo;

            BindingListCollectionView view1 = CollectionViewSource.GetDefaultView(this.itemData.item) as BindingListCollectionView;

            if (view1 != null)
            {
                view1.CustomFilter = "organization_no = '" + organizationNo + "'";
                // view1.SortDescriptions.Add(new SortDescription("short_desc", ListSortDirection.Ascending));

            }


          


        }

        public void FilterItems(string column, string val)
        {

            BindingListCollectionView view2 = CollectionViewSource.GetDefaultView(this.itemData.item) as BindingListCollectionView;


            if (view2 != null)
            {
                if (column.Trim() == "plu")
                {
                    if (val.Trim().Length > 0)
                    {
                        view2.CustomFilter = "organization_no = " + "'" + org_no + "'" + " and " + column + " = " + val;
                        // view2.SortDescriptions.Add(new SortDescription("plu", ListSortDirection.Ascending));
                    }
                }
                else
                {
                    view2.CustomFilter = "organization_no = '" + org_no + "'" + " and " + column + " LIKE " + "'*" + val + "*'";
                    // view2.SortDescriptions.Add(new SortDescription(column.Trim(), ListSortDirection.Ascending));
                }


            }

        }




    }
}
