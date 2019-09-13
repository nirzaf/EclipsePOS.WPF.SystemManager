using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Composite.Presentation.Events;
using Microsoft.Practices.Composite.Presentation.Commands;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows;


namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.Station
{
        
    public class StationViewPresenter
    {
        private IStationView _view;
        private CollectionView _colView;

        private EclipsePOS.WPF.SystemManager.Data.stationDataSet stationData;
        private EclipsePOS.WPF.SystemManager.Data.organizationLookupDataSet organizationData;
        private EclipsePOS.WPF.SystemManager.Data.storeDataSet storeData;


        private EclipsePOS.WPF.SystemManager.Data.stationDataSetTableAdapters.TableAdapterManager taManager = new EclipsePOS.WPF.SystemManager.Data.stationDataSetTableAdapters.TableAdapterManager();
        public DelegateCommand<object> MoveToFirstCommand;
        public DelegateCommand<object> MoveToPreviousCommand;
        public DelegateCommand<object> MoveToNextCommand;
        public DelegateCommand<object> MoveToLastCommand;

        public DelegateCommand<object> DeleteCommand;
        public DelegateCommand<object> AddCommand;
        public DelegateCommand<object> RevertCommand;
        public DelegateCommand<object> SaveCommand;


        public StationViewPresenter()
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

        public IStationView View
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

        public void OnShowStation()
        {
            //Organization
            organizationData = new EclipsePOS.WPF.SystemManager.Data.organizationLookupDataSet();
            EclipsePOS.WPF.SystemManager.Data.organizationLookupDataSetTableAdapters.organizationTableAdapter organizationTa = new EclipsePOS.WPF.SystemManager.Data.organizationLookupDataSetTableAdapters.organizationTableAdapter();
            organizationTa.Fill(organizationData.organization);
            View.SetOrganizationDataContext(organizationData.organization);

            //Store data
            storeData = new EclipsePOS.WPF.SystemManager.Data.storeDataSet();
            EclipsePOS.WPF.SystemManager.Data.storeDataSetTableAdapters.retail_storeTableAdapter storeTa = new EclipsePOS.WPF.SystemManager.Data.storeDataSetTableAdapters.retail_storeTableAdapter();
            storeTa.Fill(storeData.retail_store);
            View.SetStoreNoDataContext(storeData.retail_store);


            //Station data
            stationData = new EclipsePOS.WPF.SystemManager.Data.stationDataSet();
            EclipsePOS.WPF.SystemManager.Data.stationDataSetTableAdapters.posTableAdapter posTa = new EclipsePOS.WPF.SystemManager.Data.stationDataSetTableAdapters.posTableAdapter();
            posTa.Fill(stationData.pos);
            View.SetStationDataContext(stationData.pos);

            _colView = CollectionViewSource.GetDefaultView(stationData.pos) as CollectionView;
            taManager.posTableAdapter = posTa;

            

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
            if (_colView.IsEmpty || _colView.IsCurrentBeforeFirst || _colView.IsCurrentAfterLast )
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

            if (!stationData.HasErrors)
            {

                EclipsePOS.WPF.SystemManager.Data.stationDataSet.posRow dataRow = stationData.pos.NewposRow();

                dataRow.organization_no = View.SelectedOrganizationNo();
                dataRow.pos_no = 0;
                dataRow.store_no = "";
                dataRow.num_drawers = 1;
                dataRow.short_desc = "";
                dataRow.create_date = System.DateTime.Today;
                dataRow.modify_date = System.DateTime.Today;

                stationData.pos.AddposRow(dataRow);

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
            if (stationData.HasChanges())
            {
                MessageBoxResult result = Microsoft.Windows.Controls.MessageBox.Show("Are sure you want to loose all your changes", "Revert command", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes )
                {
                    stationData.RejectChanges();
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
            if (stationData.HasErrors)
            {
                Microsoft.Windows.Controls.MessageBox.Show("Please correct the errors first", "Save command", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    if (stationData.HasChanges())
                    {
                        if (taManager.UpdateAll(stationData) > 0)
                        {
                            Microsoft.Windows.Controls.MessageBox.Show("Saved", "Save command", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                }
                catch (Exception e)
                {
                    Microsoft.Windows.Controls.MessageBox.Show("Unable to save changes"+ "\n" +e.ToString(), "Save command", MessageBoxButton.OK, MessageBoxImage.Error);
                    stationData.RejectChanges();
                }
            }
        }

        public bool OnSaveCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion 

        public void FilterStationByOrganizationNo(string organizationNo)
        {

            BindingListCollectionView view1 = CollectionViewSource.GetDefaultView(this.stationData.pos) as BindingListCollectionView;

            if (view1 != null)
            {
                view1.CustomFilter = "organization_no = '" + organizationNo.ToString()+ "'";

                view1.GroupDescriptions.Clear();
                PropertyGroupDescription groupDescription = new PropertyGroupDescription();
                groupDescription.PropertyName = "store_no";
                view1.GroupDescriptions.Add(groupDescription);

            }

        }

        public void FilterStoreByOrganizationNo(string organizationNo)
        {

            BindingListCollectionView view1 = CollectionViewSource.GetDefaultView(this.storeData.retail_store) as BindingListCollectionView;

            if (view1 != null)
            {
                view1.CustomFilter = "organization_no = '" + organizationNo.ToString() + "'";
                
                view1.GroupDescriptions.Clear();
                PropertyGroupDescription groupDescription = new PropertyGroupDescription();
                groupDescription.PropertyName = "store_no";
                view1.GroupDescriptions.Add(groupDescription);

            }

        }

    }
}
