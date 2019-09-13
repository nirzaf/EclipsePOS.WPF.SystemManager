using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Composite.Presentation.Events;
using Microsoft.Practices.Composite.Presentation.Commands;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows;

namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.MenuPanels
{
    public class MenuPanelsViewPresenter
    {
        private IMenuPanelsView _view;
        private CollectionView _colView;

        private EclipsePOS.WPF.SystemManager.Data.menuPanelsDataSet menuPanelsData;
        //private EclipsePOS.WPF.SystemManager.Data.employeeRolesLookupDataSet employeeRolesData;
        //private EclipsePOS.WPF.SystemManager.Data.organizationLookupDataSet organizationData;

        private EclipsePOS.WPF.SystemManager.Data.menuPanelsDataSetTableAdapters.TableAdapterManager taManager = new EclipsePOS.WPF.SystemManager.Data.menuPanelsDataSetTableAdapters.TableAdapterManager();
       
        public DelegateCommand<object> MoveToFirstCommand;
        public DelegateCommand<object> MoveToPreviousCommand;
        public DelegateCommand<object> MoveToNextCommand;
        public DelegateCommand<object> MoveToLastCommand;

        public DelegateCommand<object> DeleteCommand;
        public DelegateCommand<object> AddCommand;
        public DelegateCommand<object> RevertCommand;
        public DelegateCommand<object> SaveCommand;


        public MenuPanelsViewPresenter()
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

        public IMenuPanelsView View
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

        public void OnShowMenuPanels()
        {

            //Menu Panels
            menuPanelsData = new EclipsePOS.WPF.SystemManager.Data.menuPanelsDataSet();
            EclipsePOS.WPF.SystemManager.Data.menuPanelsDataSetTableAdapters.menu_panelsTableAdapter menuPanelsTa = new EclipsePOS.WPF.SystemManager.Data.menuPanelsDataSetTableAdapters.menu_panelsTableAdapter();
            menuPanelsTa.Fill(menuPanelsData.menu_panels);
            View.SetMenuPanelsDataContext(menuPanelsData.menu_panels);

            _colView = CollectionViewSource.GetDefaultView(menuPanelsData.menu_panels) as CollectionView;
            taManager.menu_panelsTableAdapter  = menuPanelsTa;

            //Employee roles
            //employeeRolesData = new EclipsePOS.WPF.SystemManager.Data.employeeRolesLookupDataSet();
            //EclipsePOS.WPF.SystemManager.Data.employeeRolesLookupDataSetTableAdapters.employee_rolesTableAdapter employeeRolesTa = new EclipsePOS.WPF.SystemManager.Data.employeeRolesLookupDataSetTableAdapters.employee_rolesTableAdapter();
            //employeeRolesTa.Fill(employeeRolesData.employee_roles);
            //View.SetEmployeeRoleDataContext(employeeRolesData.employee_roles);

            
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
          //  System.Data.DataRow dataRow = ((System.Data.DataRowView)_colView.CurrentItem).Row;
          //  dataRow.Delete();

        }

        public bool OnDeleteCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return false;
        }

        #endregion


        #region Add Command

        public void OnAddCommandExecute(object obj)
        {
            if (!menuPanelsData.HasErrors)
            {

                //EclipsePOS.WPF.SystemManager.Data.employeeDataSet.employeeRow dataRow = employeeData.employee.NewemployeeRow();

                //dataRow.organization_id = 1;
                //dataRow.employee_no = "";
                
                //employeeData.employee.AddemployeeRow(dataRow);

               // _colView.MoveCurrentToLast();
               // View.SetSelectedItemCursor();
            }

        }

        public bool OnAddCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return false;
        }

        #endregion


        #region Revert Command

        public void OnRevertCommandExecute(object obj)
        {
            if (menuPanelsData.HasChanges())
            {
                MessageBoxResult result = Microsoft.Windows.Controls.MessageBox.Show("Are sure you want to lose all your changes", "Revert command", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if ( result == MessageBoxResult.Yes)
                {
                    menuPanelsData.RejectChanges();
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
            if (menuPanelsData.HasErrors)
            {
                Microsoft.Windows.Controls.MessageBox.Show("Please correct the errors first", "Save commad", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (menuPanelsData.HasChanges())
                {
                    if (taManager.UpdateAll(menuPanelsData) > 0)
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




    }
}
