using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Composite.Presentation.Events;
using Microsoft.Practices.Composite.Presentation.Commands;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows;

using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Unity;

using EclipsePOS.WPF.SystemManager.PosSetup.Views.PromotionMap;
using EclipsePOS.WPF.SystemManager.Infrastructure.Constants;
using EclipsePOS.WPF.SystemManager.PosSetup.Util;



namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.Promotion
{
    public class PromotionViewPresenter
    {
        private IUnityContainer _container;
        private IRegionManager _regionManager;

        private IPromotionView _view;
        private CollectionView _colView;

        private EclipsePOS.WPF.SystemManager.Data.promotionDataSet promotionData;
        private EclipsePOS.WPF.SystemManager.Data.organizationLookupDataSet organizationData;



        private EclipsePOS.WPF.SystemManager.Data.promotionDataSetTableAdapters.TableAdapterManager taManager = new  EclipsePOS.WPF.SystemManager.Data.promotionDataSetTableAdapters.TableAdapterManager();

        public DelegateCommand<object> MoveToFirstCommand;
        public DelegateCommand<object> MoveToPreviousCommand;
        public DelegateCommand<object> MoveToNextCommand;
        public DelegateCommand<object> MoveToLastCommand;

        public DelegateCommand<object> DeleteCommand;
        public DelegateCommand<object> AddCommand;
        public DelegateCommand<object> RevertCommand;
        public DelegateCommand<object> SaveCommand;
        
        public DelegateCommand<object> PromoMappsCommand;

        public PromotionViewPresenter()
        {
            MoveToFirstCommand = new DelegateCommand<object>(OnMoveToFirstCommandExecute, OnMoveToFirstCommandCanExecute);
            MoveToPreviousCommand = new DelegateCommand<object>(OnMoveToPreviousCommandExecute, OnMoveToPreviousCommandCanExecute);
            MoveToNextCommand = new DelegateCommand<object>(OnMoveToNextCommandExecute, OnMoveToNextCommandCanExecute);
            MoveToLastCommand = new DelegateCommand<object>(OnMoveToLastCommandExecute, OnMoveToLastCommandCanExecute);

            DeleteCommand = new DelegateCommand<object>(OnDeleteCommandExecute, OnDeleteCommandCanExecute);
            AddCommand = new DelegateCommand<object>(OnAddCommandExecute, OnAddCommandCanExecute);
            RevertCommand = new DelegateCommand<object>(OnRevertCommandExecute, OnRevertCommandCanExecute);
            SaveCommand = new DelegateCommand<object>(OnSaveCommandExecute, OnSaveCommandCanExecute);

            PromoMappsCommand = new DelegateCommand<object>(OnPromoMappsCommandExecute, OnPromoMappsCommandCanExecute);
        }

        public PromotionViewPresenter(IUnityContainer container, IRegionManager regionManager)
            : this()
        {
            _container = container;
            _regionManager = regionManager;
        }


        public IPromotionView View
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

        public void OnShowPromotion()
        {

            //Promotions
            promotionData = new  EclipsePOS.WPF.SystemManager.Data.promotionDataSet();
            EclipsePOS.WPF.SystemManager.Data.promotionDataSetTableAdapters.promotionTableAdapter promotionTa = new EclipsePOS.WPF.SystemManager.Data.promotionDataSetTableAdapters.promotionTableAdapter();
            promotionTa.Fill(promotionData.promotion);
            View.SetPromotionDataContext(promotionData.promotion);

            _colView = CollectionViewSource.GetDefaultView(promotionData.promotion) as CollectionView;
            taManager.promotionTableAdapter = promotionTa;

            //Organization
            organizationData = new EclipsePOS.WPF.SystemManager.Data.organizationLookupDataSet();
            EclipsePOS.WPF.SystemManager.Data.organizationLookupDataSetTableAdapters.organizationTableAdapter organizationTa = new EclipsePOS.WPF.SystemManager.Data.organizationLookupDataSetTableAdapters.organizationTableAdapter();
            organizationTa.Fill(organizationData.organization);
            View.SetOrganizationDataContext(organizationData.organization);

            View.SetMoveToFirstBtnDataContext(MoveToFirstCommand);
            View.SetMoveToPreviousBtnDataContext(MoveToPreviousCommand);
            View.SetMoveToNextBtnDataContext(MoveToNextCommand);
            View.SetMoveToLastBtnDataContext(MoveToLastCommand);

            View.SetDeleteBtnDataContext(DeleteCommand);
            View.SetAddBtnDataContext(AddCommand);
            View.SetRevertBtnDataContext(RevertCommand);
            View.SetSaveBtnDataContext(SaveCommand);

            View.SetPromoMappsBtnDataContext(PromoMappsCommand);

            //this.FilterPromotionByOrganizationNo(PosSettings.Default.Organization);

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

            if (!promotionData.HasErrors)
            {

                EclipsePOS.WPF.SystemManager.Data.promotionDataSet.promotionRow dataRow = promotionData.promotion.NewpromotionRow();
                dataRow.organization_no = View.SelectedOrganizationNo();
                dataRow.promotion_no = 0;
                dataRow.promotion_type = 0;
                dataRow.promotion_val1 = 0;
                dataRow.promotion_val2 = 0;
                dataRow.promotion_val3 = 0;
                dataRow.promotion_val4 = 0;
                dataRow.promotion_val5 = 0;
                dataRow.promotion_dval1 = 0;
                dataRow.promotion_dval2 = 0;
                dataRow.promotion_dval3 = 0;
                dataRow.promotion_dval4 = 0;
                dataRow.promotion_dval5 = 0;
                dataRow.valid_date_from = DateTime.Now;
                dataRow.valid_date_to = System.DateTime.MaxValue;  
                dataRow.promotion_string = "";
                dataRow.promotion_class = " ";

                promotionData.promotion.AddpromotionRow(dataRow);

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
            if (promotionData.HasChanges())
            {
                MessageBoxResult result = Microsoft.Windows.Controls.MessageBox.Show("Are sure you want to loose all your changes", "Revert command", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    promotionData.RejectChanges();
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
            if (promotionData.HasErrors)
            {
                Microsoft.Windows.Controls.MessageBox.Show("Please correct the errors first", "Save command", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (promotionData.HasChanges())
                {
                    if (taManager.UpdateAll(promotionData) > 0)
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


        #region PromoMapps Command

        public void OnPromoMappsCommandExecute(object obj)
        {
            try
            {
                var view = _container.Resolve<PromoMapView>();
                PromoMapView promoMap = view as PromoMapView;
                System.Data.DataRow dataRow = ((System.Data.DataRowView)_colView.CurrentItem).Row;

                if (dataRow == null) return;

                IRegion mainRegion = _regionManager.Regions[Regions.OperationMain];

                //Remove the view on main region 
                object mainView = mainRegion.GetView("MainView");
                if (mainView != null)
                {
                    mainRegion.Remove(mainView);
                }

                

                promoMap.Organization = dataRow["organization_no"].ToString();
                promoMap.PromoNumber = int.Parse(dataRow["promotion_no"].ToString());
                promoMap.PromoName = dataRow["promotion_string"].ToString();
                promoMap.ValidDateFrom = dataRow["valid_date_from"].ToString();
                promoMap.ValidDateTo = dataRow["valid_date_to"].ToString();
                mainRegion.Add(view, "MainView");
                mainRegion.Activate(view);
            }
            catch
            {
            }


        }



        public bool OnPromoMappsCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            if (promotionData.HasErrors)
            {
                Microsoft.Windows.Controls.MessageBox.Show("Please correct the errors first and save the data", "Add SKU command", MessageBoxButton.OK, MessageBoxImage.Error );
                return false;
            }
            else
            {
                if (promotionData.HasChanges())
                {
                    Microsoft.Windows.Controls.MessageBox.Show("Please save the data", "Add SKU command", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
                
            return true;
        }

        #endregion 



        public void FilterPromotionByOrganizationNo(string organizationNo)
        {

            BindingListCollectionView view1 = CollectionViewSource.GetDefaultView(promotionData.promotion) as BindingListCollectionView;

            if (view1 != null)
            {
                view1.CustomFilter = "organization_no = '" + organizationNo + "'";

            }

        }


    }
}
