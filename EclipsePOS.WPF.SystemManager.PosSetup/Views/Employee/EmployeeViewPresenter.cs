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


namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.Employee
{
    public class EmployeeViewPresenter
    {
        private IEmployeeView _view;
        private CollectionView _colView;

        private EclipsePOS.WPF.SystemManager.Data.employeeDataSet employeeData;
        private EclipsePOS.WPF.SystemManager.Data.employeeRolesLookupDataSet employeeRolesData;
        private EclipsePOS.WPF.SystemManager.Data.organizationLookupDataSet organizationData;

        private EclipsePOS.WPF.SystemManager.Data.employeeDataSetTableAdapters.TableAdapterManager taManager = new EclipsePOS.WPF.SystemManager.Data.employeeDataSetTableAdapters.TableAdapterManager();
        public DelegateCommand<object> MoveToFirstCommand;
        public DelegateCommand<object> MoveToPreviousCommand;
        public DelegateCommand<object> MoveToNextCommand;
        public DelegateCommand<object> MoveToLastCommand;

        public DelegateCommand<object> DeleteCommand;
        public DelegateCommand<object> AddCommand;
        public DelegateCommand<object> RevertCommand;
        public DelegateCommand<object> SaveCommand;

         public EmployeeViewPresenter()
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

        public IEmployeeView View
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

        public void OnShowEmployee()
        {
            //Employee roles
            employeeRolesData = new EclipsePOS.WPF.SystemManager.Data.employeeRolesLookupDataSet();
            EclipsePOS.WPF.SystemManager.Data.employeeRolesLookupDataSetTableAdapters.employee_rolesTableAdapter employeeRolesTa = new EclipsePOS.WPF.SystemManager.Data.employeeRolesLookupDataSetTableAdapters.employee_rolesTableAdapter();
            employeeRolesTa.Fill(employeeRolesData.employee_roles);
            View.SetEmployeeRoleDataContext(employeeRolesData.employee_roles);

            
            //Organization
            organizationData = new EclipsePOS.WPF.SystemManager.Data.organizationLookupDataSet();
            EclipsePOS.WPF.SystemManager.Data.organizationLookupDataSetTableAdapters.organizationTableAdapter organizationTa = new EclipsePOS.WPF.SystemManager.Data.organizationLookupDataSetTableAdapters.organizationTableAdapter();
            organizationTa.Fill(organizationData.organization);
            View.SetOrganizationDataContext(organizationData.organization);

            //Employee
            employeeData = new EclipsePOS.WPF.SystemManager.Data.employeeDataSet();
            EclipsePOS.WPF.SystemManager.Data.employeeDataSetTableAdapters.employeeTableAdapter employeeTa = new  EclipsePOS.WPF.SystemManager.Data.employeeDataSetTableAdapters.employeeTableAdapter();
            employeeTa.Fill(employeeData.employee);
            View.SetEmployeeDataContext(employeeData.employee);

            _colView = CollectionViewSource.GetDefaultView(employeeData.employee) as CollectionView;
            taManager.employeeTableAdapter = employeeTa;


           

            View.SetMoveToFirstBtnDataContext(MoveToFirstCommand);
            View.SetMoveToPreviousBtnDataContext(MoveToPreviousCommand);
            View.SetMoveToNextBtnDataContext(MoveToNextCommand);
            View.SetMoveToLastBtnDataContext(MoveToLastCommand);

            View.SetDeleteBtnDataContext(DeleteCommand);
            View.SetAddBtnDataContext(AddCommand);
            View.SetRevertBtnDataContext(RevertCommand);
            View.SetSaveBtnDataContext(SaveCommand);

           // this.FilterEmployeeByOrganizationNo(PosSettings.Default.Organization);

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

            if (!employeeData.HasErrors)
            {

                EclipsePOS.WPF.SystemManager.Data.employeeDataSet.employeeRow dataRow = employeeData.employee.NewemployeeRow();

                dataRow.organization_no = View.SelectedOrganizationNo();
                dataRow.employee_no = "";
                dataRow.logon_no = "";
                dataRow.logon_pass= "";
                dataRow.role_id = "";
                dataRow.fname = "";
                dataRow.lname = "";
                dataRow.mi = "";
                dataRow.ssn = "";
                //dataRow.sal_grade = 0;

                employeeData.employee.AddemployeeRow(dataRow);

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
            if (employeeData.HasChanges())
            {
                MessageBoxResult result =  Microsoft.Windows.Controls.MessageBox.Show("Are sure you want to lose all your changes", "Revert command", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if ( result == MessageBoxResult.Yes)
                {
                    employeeData.RejectChanges();
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
            
            if (employeeData.HasErrors)
            {
                Microsoft.Windows.Controls.MessageBox.Show("Please correct the errors first", "Save command", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    if (employeeData.HasChanges())
                    {
                        if (taManager.UpdateAll(employeeData) > 0)
                        {
                            Microsoft.Windows.Controls.MessageBox.Show("Saved", "Save command", MessageBoxButton.OK, MessageBoxImage.Information);
                            
                        }
                    }
                }
                catch
                {
                    Microsoft.Windows.Controls.MessageBox.Show("Unable to save changes", "Save command", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.employeeData.RejectChanges();
                }
            }
        }

        public bool OnSaveCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion 

        public void FilterEmployeeByOrganizationNo(string organizationNo)
        {

            BindingListCollectionView view1 = CollectionViewSource.GetDefaultView(this.employeeData.employee ) as BindingListCollectionView;

            if (view1 != null)
            {
                view1.CustomFilter = "organization_no = '" + organizationNo.ToString() + "'";

                view1.GroupDescriptions.Clear();
                PropertyGroupDescription groupDescription = new PropertyGroupDescription();
                groupDescription.PropertyName = "role_id";
                view1.GroupDescriptions.Add(groupDescription);
            }

        }

        public void FilterEmployeeRoleIDByOrganizationNo(string organizationNo)
        {

            BindingListCollectionView view2 = CollectionViewSource.GetDefaultView(this.employeeRolesData.employee_roles) as BindingListCollectionView;

            if (view2 != null)
            {
                view2.CustomFilter = "organization_no = '" + organizationNo.ToString() + "'";

               

            }

        }


       /* public void SetUserPassword(string password)
        {
            EclipsePOS.WPF.SystemManager.Data.employeeDataSet.employeeRow dataRow = ((System.Data.DataRowView)_colView.CurrentItem).Row as EclipsePOS.WPF.SystemManager.Data.employeeDataSet.employeeRow;
            try
            {
                dataRow.logon_pass = int.Parse(password.Trim());
            }
            catch
            {
            }

        }
        * */


    }
}
