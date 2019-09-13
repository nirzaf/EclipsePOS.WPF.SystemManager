using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Composite.Presentation.Events;
using Microsoft.Practices.Composite.Presentation.Commands;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows;

namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.MenuConfig
{
    public class MenuConfigViewPresenter
    {

        private IMenuConfigView _view;
        private CollectionView _colView;
        

        private EclipsePOS.WPF.SystemManager.Data.menuConfigDataSet menuConfigData;
        private EclipsePOS.WPF.SystemManager.Data.menuRootLookupDataSet menuRootData;
        private EclipsePOS.WPF.SystemManager.Data.menuPanelsDataSet menuPanelsData;
        //private EclipsePOS.WPF.SystemManager.Data.menuConfigDataSet menuConfigData;

        private EclipsePOS.WPF.SystemManager.Data.menuConfigDataSetTableAdapters.TableAdapterManager menuConfigTaManager = new EclipsePOS.WPF.SystemManager.Data.menuConfigDataSetTableAdapters.TableAdapterManager(); 
        //private EclipsePOS.WPF.SystemManager.Data.menuConfigDataSetTableAdapters.TableAdapterManager menuConfigTaManager = new EclipsePOS.WPF.SystemManager.Data.menuConfigDataSetTableAdapters.TableAdapterManager();

        public DelegateCommand<object> MoveToFirstCommand;
        public DelegateCommand<object> MoveToPreviousCommand;
        public DelegateCommand<object> MoveToNextCommand;
        public DelegateCommand<object> MoveToLastCommand;

        public DelegateCommand<object> DeleteCommand;
        public DelegateCommand<object> AddCommand;
        public DelegateCommand<object> RevertCommand;
        public DelegateCommand<object> SaveCommand;

       // public DelegateCommand<object> AddEventCommand;
       // public DelegateCommand<object> RemoveEventCommand;

        public MenuConfigViewPresenter()
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

        

        public IMenuConfigView View
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

        public void OnShowMenuConfigView()
        {

            //MenuConfig
            menuConfigData = new  EclipsePOS.WPF.SystemManager.Data.menuConfigDataSet();
            EclipsePOS.WPF.SystemManager.Data.menuConfigDataSetTableAdapters.menu_configTableAdapter menuConfigTa = new  EclipsePOS.WPF.SystemManager.Data.menuConfigDataSetTableAdapters.menu_configTableAdapter();
            menuConfigTa.Fill(menuConfigData.menu_config);
            View.SetMenuConfigDataContext(menuConfigData.menu_config);

            _colView = CollectionViewSource.GetDefaultView(menuConfigData.menu_config) as CollectionView;
            menuConfigTaManager.menu_configTableAdapter = menuConfigTa;

            //MenuRootLookupData
             menuRootData = new EclipsePOS.WPF.SystemManager.Data.menuRootLookupDataSet();
             EclipsePOS.WPF.SystemManager.Data.menuRootLookupDataSetTableAdapters.menu_rootTableAdapter menuRootTa = new  EclipsePOS.WPF.SystemManager.Data.menuRootLookupDataSetTableAdapters.menu_rootTableAdapter();
             menuRootTa.Fill(menuRootData.menu_root);
             View.SetMenuIDDataContext(menuRootData.menu_root);


            //MenuPanelsData
            menuPanelsData = new EclipsePOS.WPF.SystemManager.Data.menuPanelsDataSet();
            EclipsePOS.WPF.SystemManager.Data.menuPanelsDataSetTableAdapters.menu_panelsTableAdapter menuPanelsTa = new  EclipsePOS.WPF.SystemManager.Data.menuPanelsDataSetTableAdapters.menu_panelsTableAdapter();
            menuPanelsTa.Fill(menuPanelsData.menu_panels);
            View.SetMenuPanelsDataContext(menuPanelsData.menu_panels);

            //MenuPanelsData
            //menuConfigData = new  EclipsePOS.WPF.SystemManager.Data.menuConfigDataSet();
            //EclipsePOS.WPF.SystemManager.Data.menuConfigDataSetTableAdapters.menu_configTableAdapter menuConfigTa = new EclipsePOS.WPF.SystemManager.Data.menuConfigDataSetTableAdapters.menu_configTableAdapter() ;
            //menuConfigTa.Fill(menuConfigData.menu_config);
            //View.SetMenuConfigDataContext(menuConfigData.menu_config);


            View.SetMoveToFirstBtnDataContext(MoveToFirstCommand);
            View.SetMoveToPreviousBtnDataContext(MoveToPreviousCommand);
            View.SetMoveToNextBtnDataContext(MoveToNextCommand);
            View.SetMoveToLastBtnDataContext(MoveToLastCommand);

            View.SetDeleteBtnDataContext(DeleteCommand);
            View.SetAddBtnDataContext(AddCommand);
            View.SetRevertBtnDataContext(RevertCommand);
            View.SetSaveBtnDataContext(SaveCommand);

            
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
            System.Data.DataRow dataRow = ((System.Data.DataRowView)_colView.CurrentItem).Row;
            dataRow.Delete();

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
            if (!menuConfigData.HasErrors)
            {

                EclipsePOS.WPF.SystemManager.Data.menuConfigDataSet.menu_configRow dataRow = menuConfigData.menu_config.Newmenu_configRow();

                //dataRow.menu_no = 0;
                //dataRow.config_no = 0;
                //dataRow.menu_name = "";

                //menuRootData.menu_root.Addmenu_rootRow(dataRow);

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
            if (menuConfigData.HasChanges())
                if (MessageBoxResult.Yes == MessageBox.Show("Are sure you want to loose all your changes", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning))
                {
                    menuConfigData.RejectChanges();
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
            if (menuConfigData.HasErrors)
            {
                MessageBox.Show("Please correct the errors first");
            }
            else
            {
                if (menuConfigData.HasChanges())
                {
                    if (menuConfigTaManager.UpdateAll(menuConfigData) > 0)
                    {
                        MessageBox.Show("Saved");
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


    }
}
