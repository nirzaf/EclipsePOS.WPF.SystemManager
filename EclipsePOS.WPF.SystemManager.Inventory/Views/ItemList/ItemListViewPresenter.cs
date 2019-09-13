using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using EclipsePOS.WPF.SystemManager.Data;
//using EclipsePOS.WPF.SystemManager.Data.ItemsDataSetTableAdapters;
using Microsoft.Practices.Composite.Events;
using Microsoft.Practices.Composite.Presentation.Commands;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows;

namespace EclipsePOS.WPF.SystemManager.Inventory.Views.ItemList
{
    public class ItemListViewPresenter
    {
        private IItemListView _view;
        private CollectionView _colView;
     
        private EclipsePOS.WPF.SystemManager.Data.ItemsDataSet itemData;
        private EclipsePOS.WPF.SystemManager.Data.organizationLookupDataSet organizationData;
        private EclipsePOS.WPF.SystemManager.Data.DepartmentDataSet departmentData;
        private EclipsePOS.WPF.SystemManager.Data.ItemGroupDataSet itemGroupData;
        private EclipsePOS.WPF.SystemManager.Data.taxGroupDataSet taxGroupData;

        private EclipsePOS.WPF.SystemManager.Data.ItemsDataSetTableAdapters.TableAdapterManager taManager = new EclipsePOS.WPF.SystemManager.Data.ItemsDataSetTableAdapters.TableAdapterManager(); 
     
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


        public ItemListViewPresenter()
        {
            MoveToFirstCommand = new DelegateCommand<object>(OnMoveToFirstCommandExecute, OnMoveToFirstCommandCanExecute);
            MoveToPreviousCommand = new DelegateCommand<object>(OnMoveToPreviousCommandExecute, OnMoveToPreviousCommandCanExecute);
            MoveToNextCommand = new DelegateCommand<object>(OnMoveToNextCommandExecute, OnMoveToNextCommandCanExecute);
            MoveToLastCommand = new DelegateCommand<object>(OnMoveToLastCommandExecute, OnMoveToLastCommandCanExecute);

            DeleteCommand = new DelegateCommand<object>(OnDeleteCommandExecute, OnDeleteCommandCanExecute);
            AddCommand = new DelegateCommand<object>(OnAddCommandExecute, OnAddCommandCanExecute);
            RevertCommand = new DelegateCommand<object>(OnRevertCommandExecute, OnRevertCommandCanExecute);
            SaveCommand = new DelegateCommand<object>(OnSaveCommandExecute, OnSaveCommandCanExecute);

           // FilterCommand = new DelegateCommand<object>(OnFilterCommandExecute, OnFilterCommandCanExecute);

           
         
        }

        public IItemListView View
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

        public void OnShowItems()
        {


            //Organization
            organizationData = new EclipsePOS.WPF.SystemManager.Data.organizationLookupDataSet();
            EclipsePOS.WPF.SystemManager.Data.organizationLookupDataSetTableAdapters.organizationTableAdapter organizationTa = new EclipsePOS.WPF.SystemManager.Data.organizationLookupDataSetTableAdapters.organizationTableAdapter();
            organizationTa.Fill(organizationData.organization);
            View.SetOrganizationDataContext(organizationData.organization);

            //Department
            departmentData = new EclipsePOS.WPF.SystemManager.Data.DepartmentDataSet();
            EclipsePOS.WPF.SystemManager.Data.DepartmentDataSetTableAdapters.departmentTableAdapter departmentTa = new EclipsePOS.WPF.SystemManager.Data.DepartmentDataSetTableAdapters.departmentTableAdapter();
            departmentTa.Fill(departmentData.department);
            View.SetDepartmentDataContext(departmentData.department);

            //Item Group
            itemGroupData = new EclipsePOS.WPF.SystemManager.Data.ItemGroupDataSet();
            EclipsePOS.WPF.SystemManager.Data.ItemGroupDataSetTableAdapters.ItemGroupTableAdapter itemGroupTa = new EclipsePOS.WPF.SystemManager.Data.ItemGroupDataSetTableAdapters.ItemGroupTableAdapter();
            itemGroupTa.Fill(itemGroupData.ItemGroup);
            View.SetItemGroupDataContext(itemGroupData.ItemGroup);

            //Tax Groups
            taxGroupData = new EclipsePOS.WPF.SystemManager.Data.taxGroupDataSet(); 
            EclipsePOS.WPF.SystemManager.Data.taxGroupDataSetTableAdapters.tax_groupTableAdapter taxGroupTa = new EclipsePOS.WPF.SystemManager.Data.taxGroupDataSetTableAdapters.tax_groupTableAdapter();
            taxGroupTa.Fill(taxGroupData.tax_group);
            View.SetTaxGroupDataContext(taxGroupData.tax_group);
                              


            //Item
            itemData = new EclipsePOS.WPF.SystemManager.Data.ItemsDataSet();
            EclipsePOS.WPF.SystemManager.Data.ItemsDataSetTableAdapters.itemTableAdapter taItem = new EclipsePOS.WPF.SystemManager.Data.ItemsDataSetTableAdapters.itemTableAdapter();
            taItem.Fill(itemData.item);
            View.SetItemsDataContext(itemData.item);

            _colView = CollectionViewSource.GetDefaultView(itemData.item) as CollectionView;
            taManager.itemTableAdapter = taItem;


            View.SetMoveToFirstBtnDataContext(MoveToFirstCommand);
            View.SetMoveToPreviousBtnDataContext(MoveToPreviousCommand);
            View.SetMoveToNextBtnDataContext(MoveToNextCommand);
            View.SetMoveToLastBtnDataContext(MoveToLastCommand);

            View.SetDeleteBtnDataContext(DeleteCommand);
            View.SetAddBtnDataContext(AddCommand);
            View.SetRevertBtnDataContext(RevertCommand);
            View.SetSaveBtnDataContext(SaveCommand);

           // View.SetFilterBtnDataContext(FilterCommand);

            _colView.CurrentChanged += new EventHandler(_colView_CurrentChanged);
            
        }

        void _colView_CurrentChanged(object sender, EventArgs e)
        {

            if (_colView.IsEmpty || _colView.IsCurrentBeforeFirst || _colView.IsCurrentAfterLast )
            {
                View.SetColumnsEnabled(false);
            }
            else
            {
                View.SetColumnsEnabled(true);
            }
            
        }

        
        public void OnShowItemDetails(object data)
        {
            _colView.MoveCurrentTo(data);

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
            if (!itemData.HasErrors)
            {
                this.FilterItems("sku", "");

                EclipsePOS.WPF.SystemManager.Data.ItemsDataSet.itemRow dataRow = itemData.item.NewitemRow();
                dataRow.organization_no = this.View.SelectedOrganizationNo();
                dataRow.sku = "";
                dataRow.short_desc = "";
                //dataRow.amount = 0.00M;
                dataRow.dept = Properties.Settings.Default.ItemListViewPresenter_Dept;
                dataRow.item_group = Properties.Settings.Default.ItemListViewPresenter_Item_group;
                dataRow.tax_group_id = Properties.Settings.Default.ItemListViewPresenter_Tax_group;
                dataRow.pricing_opt = Properties.Settings.Default.ItemListViewPresenter_Pricing_opt;
                dataRow.active_date = System.DateTime.Today;
                dataRow.deactive_date = System.DateTime.MaxValue;
                dataRow.tax_inclusive = Properties.Settings.Default.ItemListViewPresenter_Tax_inclusive;
                dataRow.tax_exempt = Properties.Settings.Default.ItemListViewPresenter_Tax_excempt;
                dataRow.plu = null;


                itemData.item.AdditemRow(dataRow);

                 _colView.MoveCurrentToLast();
                 _view.SetSelectedItemCursor();
                 View.SetFocusToFirstInputField();

               //CollectionView cv = (CollectionView)CollectionViewSource.GetDefaultView(itemData.item);

                // add a new color based on the current one, then select the new one
               // cv.MoveCurrentTo(dataRow);

            }
       
        }

        public bool OnAddCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion 


        #region CheckPrice
        public void CheckPrice()
        {
            System.Data.DataRow row = ((System.Data.DataRowView)_colView.CurrentItem).Row;
            if (row.IsNull("amount") || double.Parse( row["amount"].ToString() ) <= 0)
            {
                if (row.IsNull("pricing_opt") || int.Parse(row["pricing_opt"].ToString() ) != 3)
                {
                    row.SetColumnError("amount", "Enter price");
                }
                else
                {
                    row.SetColumnError("amount", "");
                }
            }
            else
            {
                row.SetColumnError("amount", "");

            }

        }
        #endregion


        #region Revert Command

        public void OnRevertCommandExecute(object obj)
        {
            if (itemData.HasChanges())
                //if (MessageBoxResult.Yes == MessageBox.Show("Are sure you want to loose all your changes", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning))
                {
                    MessageBoxResult result = Microsoft.Windows.Controls.MessageBox.Show("Are sure you want to loose all your changes", "Revert Command", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes)
                    {
                        itemData.RejectChanges();
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
            if (itemData.HasErrors)
            {
                Microsoft.Windows.Controls.MessageBox.Show("Please correct the errors first", "Save Command", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    if (itemData.HasChanges())
                    {
                        if (taManager.UpdateAll(itemData) > 0)
                        {
                            Microsoft.Windows.Controls.MessageBox.Show("Saved", "Save Command", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                }
                catch(Exception e)
                {
                    Microsoft.Windows.Controls.MessageBox.Show("Unable to save changes" + "\n" + e.ToString(), "Save Command", MessageBoxButton.OK, MessageBoxImage.Error);
                   // itemData.RejectChanges();
                }

            }
        }

        public bool OnSaveCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion 

        #region Filter Command

       /* public void OnFilterCommandExecute(object obj)
        {
            //MessageBox.Show("Filter it");
            this.FilterItems(View.GetFilterCriteria(), View.GetFilterText());
        }


        public bool OnFilterCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }*/
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
          
            
            BindingListCollectionView view2 = CollectionViewSource.GetDefaultView(this.departmentData.department) as BindingListCollectionView;

            if (view2 != null)
            {
                view2.CustomFilter = "organization_no = '" + organizationNo + "'";
                //view2.SortDescriptions.Add(new SortDescription("department_name", ListSortDirection.Ascending));
            }

            BindingListCollectionView view3 = CollectionViewSource.GetDefaultView(this.itemGroupData.ItemGroup) as BindingListCollectionView;

            if (view3 != null)
            {
                view3.CustomFilter = "organization_no = '" + organizationNo + "'";
               // view2.SortDescriptions.Add(new SortDescription("group_name", ListSortDirection.Ascending));

            }

            BindingListCollectionView view4 = CollectionViewSource.GetDefaultView(this.taxGroupData.tax_group) as BindingListCollectionView;

            if (view4 != null)
            {
                view4.CustomFilter = "organization_no = '" + organizationNo + "'";
               // view4.SortDescriptions.Add(new SortDescription("tax_group_name", ListSortDirection.Ascending));

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
                        view2.CustomFilter = "organization_no = " +"'" +org_no + "'"+ " and " + column + " = " + val;
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
