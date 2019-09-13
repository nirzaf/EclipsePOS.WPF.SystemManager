using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows;
using System.ComponentModel;


using Microsoft.Practices.Composite.Presentation.Events;
using Microsoft.Practices.Composite.Presentation.Commands;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Unity;

using EclipsePOS.WPF.SystemManager.PosSetup.Views.Promotion;

using EclipsePOS.WPF.SystemManager.Infrastructure.Constants;



namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.PromotionMap
{
    
    public class PromoMapViewPresenter
    {
        private PromoMapView _view;

        private IUnityContainer _container;
        private IRegionManager _regionManager;
        private CollectionView _itemColView;
        private CollectionView _promotionMapColView;

        private EclipsePOS.WPF.SystemManager.Data.ItemsDataSet itemData;
       // private EclipsePOS.WPF.SystemManager.Data.organizationLookupDataSet organizationData;
        private EclipsePOS.WPF.SystemManager.Data.promotionMapDataSet promotionMapData;

        private EclipsePOS.WPF.SystemManager.Data.promotionMapDataSetTableAdapters.TableAdapterManager taManager = new EclipsePOS.WPF.SystemManager.Data.promotionMapDataSetTableAdapters.TableAdapterManager();


        public DelegateCommand<object> MoveToFirstCommand;
        public DelegateCommand<object> MoveToPreviousCommand;
        public DelegateCommand<object> MoveToNextCommand;
        public DelegateCommand<object> MoveToLastCommand;

        public DelegateCommand<object> DeleteCommand;
        public DelegateCommand<object> AddCommand;
        
        public DelegateCommand<object> RevertCommand;
        public DelegateCommand<object> SaveCommand;
        public DelegateCommand<object> CancelCommand;

        public DelegateCommand<object> SelectCommand;
       // public DelegateCommand<object> FilterCommand;
        public DelegateCommand<object> SelectAllCommand;


        public PromoMapViewPresenter()
        {
            MoveToFirstCommand = new DelegateCommand<object>(OnMoveToFirstCommandExecute, OnMoveToFirstCommandCanExecute);
            MoveToPreviousCommand = new DelegateCommand<object>(OnMoveToPreviousCommandExecute, OnMoveToPreviousCommandCanExecute);
            MoveToNextCommand = new DelegateCommand<object>(OnMoveToNextCommandExecute, OnMoveToNextCommandCanExecute);
            MoveToLastCommand = new DelegateCommand<object>(OnMoveToLastCommandExecute, OnMoveToLastCommandCanExecute);

            DeleteCommand = new DelegateCommand<object>(OnDeleteCommandExecute, OnDeleteCommandCanExecute);
            AddCommand = new DelegateCommand<object>(OnAddCommandExecute, OnAddCommandCanExecute);
            RevertCommand = new DelegateCommand<object>(OnRevertCommandExecute, OnRevertCommandCanExecute);
            SaveCommand = new DelegateCommand<object>(OnSaveCommandExecute, OnSaveCommandCanExecute);
            SelectAllCommand = new DelegateCommand<object>(OnSelectAllCommandExecute, OnSelectAllCommandCanExecute);
            
          //  FilterCommand = new DelegateCommand<object>(OnFilterCommandExecute, OnFilterCommandCanExecute);

            CancelCommand = new DelegateCommand<object>(OnCancelCommandExecute, OnCancelCommandCanExecute);
        }

        public PromoMapViewPresenter(IUnityContainer container, IRegionManager regionManager):this()
        {
            _container = container;
            _regionManager = regionManager;



            

           

        }

        public PromoMapView View
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

        public void OnShowPromoMapView()
        {
            //Item
            itemData = new EclipsePOS.WPF.SystemManager.Data.ItemsDataSet();
            EclipsePOS.WPF.SystemManager.Data.ItemsDataSetTableAdapters.itemTableAdapter taItem = new EclipsePOS.WPF.SystemManager.Data.ItemsDataSetTableAdapters.itemTableAdapter();
            taItem.Fill(itemData.item);
            View.SetItemsDataContext(itemData.item);
            _itemColView = CollectionViewSource.GetDefaultView(itemData.item) as CollectionView;
            this.FilterItemByOrganizationNo(View.Organization);

            //PromotionsMap
            promotionMapData = new EclipsePOS.WPF.SystemManager.Data.promotionMapDataSet();
            EclipsePOS.WPF.SystemManager.Data.promotionMapDataSetTableAdapters.promotion_mapTableAdapter promotionMapTa = new EclipsePOS.WPF.SystemManager.Data.promotionMapDataSetTableAdapters.promotion_mapTableAdapter(); 
            promotionMapTa.Fill(promotionMapData.promotion_map);
            View.SetPromoMapDataContext(promotionMapData.promotion_map);

            _promotionMapColView = CollectionViewSource.GetDefaultView(promotionMapData.promotion_map) as CollectionView;
            taManager.promotion_mapTableAdapter = promotionMapTa;
            this.FilterPromotionMapByOrganizationNo(View.Organization);

            

            View.SetMoveToFirstBtnDataContext(MoveToFirstCommand);
            View.SetMoveToPreviousBtnDataContext(MoveToPreviousCommand);
            View.SetMoveToNextBtnDataContext(MoveToNextCommand);
            View.SetMoveToLastBtnDataContext(MoveToLastCommand);

            View.SetDeleteBtnDataContext(DeleteCommand);
            View.SetSelectBtnDataContext(AddCommand);
            View.SetRevertBtnDataContext(RevertCommand);
            View.SetSaveBtnDataContext(SaveCommand);
            View.SetSelectAllBtnDataContext(SelectAllCommand);

           // View.SetFilterBtnDataContext(FilterCommand);

            View.SetCancelBtnDataContext(CancelCommand);

        }

        #region MoveToFirst Command

        public void OnMoveToFirstCommandExecute(object obj)
        {
            _itemColView.MoveCurrentToFirst();
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
            _itemColView.MoveCurrentToPrevious();
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
            _itemColView.MoveCurrentToNext();
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
            _itemColView.MoveCurrentToLast();
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
                System.Data.DataRow dataRow = ((System.Data.DataRowView)_promotionMapColView.CurrentItem).Row;
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
            if (!promotionMapData.HasErrors)
            {
                try
                {
                    EclipsePOS.WPF.SystemManager.Data.promotionMapDataSet.promotion_mapRow dataRow = promotionMapData.promotion_map.Newpromotion_mapRow();
                    dataRow.organization_no = View.Organization;
                    dataRow.promotion_no = View.PromoNumber;
                    dataRow.map_type = 0;
                    System.Data.DataRow itemDataRow = ((System.Data.DataRowView)_itemColView.CurrentItem).Row;
                    dataRow.promotion_map = itemDataRow["sku"].ToString();
                    
                    promotionMapData.promotion_map.Addpromotion_mapRow(dataRow);

                    _promotionMapColView.MoveCurrentToLast();
                    //View.SetSelectedItemCursor();
                }
                catch
                {
                }

            }


        }

        public bool OnAddCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion


        #region Select All Command

        public void OnSelectAllCommandExecute(object obj)
        {
            if (!promotionMapData.HasErrors)
            {
                
                    foreach (Object data in _itemColView)
                    {
                        try
                        {

                            EclipsePOS.WPF.SystemManager.Data.promotionMapDataSet.promotion_mapRow dataRow = promotionMapData.promotion_map.Newpromotion_mapRow();
                            dataRow.organization_no = View.Organization;
                            dataRow.promotion_no = View.PromoNumber;
                            dataRow.map_type = 0;


                            System.Data.DataRow itemDataRow = ((System.Data.DataRowView)data).Row;
                            dataRow.promotion_map = itemDataRow["sku"].ToString();

                            promotionMapData.promotion_map.Addpromotion_mapRow(dataRow);
                        }
                        catch
                        {
                        }

                        
                       
                    }
                 
                    _promotionMapColView.MoveCurrentToLast();

            }


        }

        public bool OnSelectAllCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion



        #region Revert Command

        public void OnRevertCommandExecute(object obj)
        {
            if (promotionMapData.HasChanges())
            {
                MessageBoxResult result = Microsoft.Windows.Controls.MessageBox.Show("Are sure you want to loose all your changes", "Revert command", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes )
                {
                    promotionMapData.RejectChanges();
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
            if (promotionMapData.HasErrors)
            {
                Microsoft.Windows.Controls.MessageBox.Show("Please correct the errors first", "Save command", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (promotionMapData.HasChanges())
                {
                    if (taManager.UpdateAll(promotionMapData) > 0)
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


        #region Cancel Command

        public void OnCancelCommandExecute(object obj)
        {
           
            IRegion mainRegion = _regionManager.Regions[Regions.OperationMain];

            //Remove the view on main region 
            object mainView = mainRegion.GetView("MainView");
            if (mainView != null)
            {
                mainRegion.Remove(mainView);
            }

            var view = _container.Resolve<PromotionView>();
            mainRegion.Add(view, "MainView");
            mainRegion.Activate(view);
            

        }



        public bool OnCancelCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            
            if (promotionMapData.HasChanges())
            {
                Microsoft.Windows.Controls.MessageBox.Show("Please save the data", "Cancel command", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
         

            return true;
        }

        #endregion

        #region Filter Command

        public void OnFilterCommandExecute(object obj)
        {
            //MessageBox.Show("Filter it");
           // this.FilterItems(View.GetFilterCriteria(), View.GetFilterText());
        }


        public bool OnFilterCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }
        #endregion


        public void FilterPromotionMapByOrganizationNo(string organizationNo)
        {

            BindingListCollectionView view1 = CollectionViewSource.GetDefaultView(promotionMapData.promotion_map) as BindingListCollectionView;

            if (view1 != null)
            {
                view1.CustomFilter = "organization_no = '" + organizationNo +"'" + " and promotion_no = " + View.PromoNumber.ToString();
                view1.SortDescriptions.Add(new SortDescription("promotion_map", ListSortDirection.Ascending));
            }

        }


        public void FilterItemByOrganizationNo(string organizationNo)
        {

            BindingListCollectionView view1 = CollectionViewSource.GetDefaultView(itemData.item) as BindingListCollectionView;

            if (view1 != null)
            {
                view1.CustomFilter = "organization_no = '" + organizationNo + "'";
                view1.SortDescriptions.Add(new SortDescription("sku", ListSortDirection.Ascending));

            }

        }

        public void FilterItems(string column, string val)
        {

            BindingListCollectionView view2 = CollectionViewSource.GetDefaultView(this.itemData.item) as BindingListCollectionView;

            if (view2 != null)
            {
                if (column.CompareTo("plu") == 0)
                {
                    if (val.Trim().Length > 0)
                    {
                        view2.CustomFilter = "organization_no = '" + View.Organization +"'" + " and " + column + " = " + val;
                        view2.SortDescriptions.Add(new SortDescription("plu", ListSortDirection.Ascending));
                    }
                }
                else
                {
                    view2.CustomFilter = "organization_no = '" + View.Organization + "' and " + column + " LIKE " + "'*" + val + "*'";
                    view2.SortDescriptions.Add(new SortDescription(column.Trim(), ListSortDirection.Ascending));
                }


            }

        }




    }
}
