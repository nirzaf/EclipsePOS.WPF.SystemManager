using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Composite.Presentation.Events;
using Microsoft.Practices.Composite.Presentation.Commands;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows;
using System.Collections.ObjectModel;
using System.Data;

namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.EmployeeRoles
{
    public class EmployeeRolesViewPresenter
    {
        private IEmployeeRolesView _view;
        private CollectionView _colView;
        private CollectionView _colViewSelectedRoleEvents;
        private CollectionView _colViewManagedRoleEvent;
        private ObservableCollection<String> managedRoleEvent;
        private int roleEventCount = 0;
        private Dictionary<String, int> eventId = new Dictionary<string, int>();

        private EclipsePOS.WPF.SystemManager.Data.employeeRolesDataSet rolesData;
        private EclipsePOS.WPF.SystemManager.Data.employeeRoleEventDataSet roleEventData;
        private EclipsePOS.WPF.SystemManager.Data.organizationLookupDataSet organizationData;


        private EclipsePOS.WPF.SystemManager.Data.employeeRolesDataSetTableAdapters.TableAdapterManager rolesTaManager = new EclipsePOS.WPF.SystemManager.Data.employeeRolesDataSetTableAdapters.TableAdapterManager();
        private EclipsePOS.WPF.SystemManager.Data.employeeRoleEventDataSetTableAdapters.TableAdapterManager roleEventTaManager = new EclipsePOS.WPF.SystemManager.Data.employeeRoleEventDataSetTableAdapters.TableAdapterManager();
        
        public DelegateCommand<object> MoveToFirstCommand;
        public DelegateCommand<object> MoveToPreviousCommand;
        public DelegateCommand<object> MoveToNextCommand;
        public DelegateCommand<object> MoveToLastCommand;

        public DelegateCommand<object> DeleteCommand;
        public DelegateCommand<object> AddCommand;
        public DelegateCommand<object> RevertCommand;
        public DelegateCommand<object> SaveCommand;

        public DelegateCommand<object> AddEventCommand;
        public DelegateCommand<object> RemoveEventCommand;

        public EmployeeRolesViewPresenter()
        {
            MoveToFirstCommand = new DelegateCommand<object>(OnMoveToFirstCommandExecute, OnMoveToFirstCommandCanExecute);
            MoveToPreviousCommand = new DelegateCommand<object>(OnMoveToPreviousCommandExecute, OnMoveToPreviousCommandCanExecute);
            MoveToNextCommand = new DelegateCommand<object>(OnMoveToNextCommandExecute, OnMoveToNextCommandCanExecute);
            MoveToLastCommand = new DelegateCommand<object>(OnMoveToLastCommandExecute, OnMoveToLastCommandCanExecute);

            DeleteCommand = new DelegateCommand<object>(OnDeleteCommandExecute, OnDeleteCommandCanExecute);
            AddCommand = new DelegateCommand<object>(OnAddCommandExecute, OnAddCommandCanExecute);
            RevertCommand = new DelegateCommand<object>(OnRevertCommandExecute, OnRevertCommandCanExecute);
            SaveCommand = new DelegateCommand<object>(OnSaveCommandExecute, OnSaveCommandCanExecute);

            AddEventCommand = new DelegateCommand<object>(OnAddEventCommandExecute, OnAddEventCommandCanExecute);
            RemoveEventCommand = new DelegateCommand<object>(OnRemoveEventCommandExecute, OnRemoveEventCommandCanExecute);

            managedRoleEvent = new ObservableCollection<string>();
            managedRoleEvent.Add("VoidSale");
            managedRoleEvent.Add("PaidIn");
            managedRoleEvent.Add("PaidOut");
            managedRoleEvent.Add("TrainingMode");
            managedRoleEvent.Add("TerminalReports");
            managedRoleEvent.Add("ChangePrice");
            managedRoleEvent.Add("VoidItemLine");
            managedRoleEvent.Add("Store" );
            managedRoleEvent.Add("Recall");
            managedRoleEvent.Add("ReturnSale");
            managedRoleEvent.Add("Discount");
            managedRoleEvent.Add("Promotion");
            managedRoleEvent.Add("Customer");

            managedRoleEvent.Add("SystemManager");
            managedRoleEvent.Add("LogOff");
            managedRoleEvent.Add("Shutdown");
           
            managedRoleEvent.Add("CreditTender");
            managedRoleEvent.Add("AltCurrencyTender");
            managedRoleEvent.Add("CheckTender");
            managedRoleEvent.Add("DebtTender");
            managedRoleEvent.Add("DebitCardTender");
            managedRoleEvent.Add("MergeOrder");

            eventId.Add("VoidSale", 1);
            eventId.Add("PaidIn", 2);
            eventId.Add("PaidOut", 3);
            eventId.Add("TrainingMode", 4);
            eventId.Add("TerminalReports", 5);
            eventId.Add("ChangePrice", 6);
            eventId.Add("VoidItemLine", 7);
            eventId.Add("Store", 8);
            eventId.Add("Recall", 9);
            eventId.Add("ReturnSale", 10);
            eventId.Add("Discount", 11);
            eventId.Add("Promotion", 12);
            eventId.Add("Customer", 13);

            eventId.Add("SystemManager", 14);
            eventId.Add("LogOff", 15);
            eventId.Add("Shutdown", 16);

            eventId.Add("CreditTender", 17);
            eventId.Add("AltCurrencyTender", 18);
            eventId.Add("CheckTender", 19);
            eventId.Add("DebtTender", 20);
            eventId.Add("DebitCardTender", 21);
            eventId.Add("MergeOrder", 22);
    

            //_colViewManagedRoleEvent = CollectionViewSource.GetDefaultView(this.managedRoleEvent) as CollectionView;
        }

        public IEmployeeRolesView View
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

        public void OnShowEmployeeRoles()
        {

            //Emloyee roles
            rolesData = new EclipsePOS.WPF.SystemManager.Data.employeeRolesDataSet();
            EclipsePOS.WPF.SystemManager.Data.employeeRolesDataSetTableAdapters.employee_rolesTableAdapter rolesTa = new  EclipsePOS.WPF.SystemManager.Data.employeeRolesDataSetTableAdapters.employee_rolesTableAdapter();
            rolesTa.Fill(rolesData.employee_roles);
            View.SetEmployeeRolesDataContext(rolesData.employee_roles);

            _colView = CollectionViewSource.GetDefaultView(rolesData.employee_roles) as CollectionView;
            rolesTaManager.employee_rolesTableAdapter = rolesTa;

            roleEventData = new EclipsePOS.WPF.SystemManager.Data.employeeRoleEventDataSet();
            EclipsePOS.WPF.SystemManager.Data.employeeRoleEventDataSetTableAdapters.employee_role_eventTableAdapter roleEventTa = new EclipsePOS.WPF.SystemManager.Data.employeeRoleEventDataSetTableAdapters.employee_role_eventTableAdapter();
            roleEventTa.Fill(roleEventData.employee_role_event);
            View.SetEmployeeRoleEventDataContext(roleEventData.employee_role_event);

            _colViewSelectedRoleEvents = CollectionViewSource.GetDefaultView(roleEventData.employee_role_event) as CollectionView;
            roleEventTaManager.employee_role_eventTableAdapter = roleEventTa;


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

           // string appPath = System.IO.Path.GetDirectoryName(
           // System.Reflection.Assembly.GetExecutingAssembly().CodeBase)+"\\ManagedPosEvents.xml";
            View.SetManagedPosEventDataContext(managedRoleEvent);//appPath);

            View.SetAddEventDataContext(AddEventCommand);
            View.SetRemoveEventDataContext(RemoveEventCommand);

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


        public void OnFilter()
        {
            try
            {
                BindingListCollectionView view1 = CollectionViewSource.GetDefaultView(roleEventData.employee_role_event) as BindingListCollectionView;
                //view1.CustomFilter = "role_id = 1001";
                System.Data.DataRow employeeRow = ((System.Data.DataRowView)_colView.CurrentItem).Row;

                view1.CustomFilter = "role_id = '" + employeeRow["role_id"].ToString()+ "' and " + " organization_no = '" + View.SelectedOrganizationId() + "'" ;
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
            }
        }

        public bool EmployeeRolesEventsFilter(object data)
        {
            EclipsePOS.WPF.SystemManager.Data.employeeRoleEventDataSet.employee_role_eventRow eventsRow = data as EclipsePOS.WPF.SystemManager.Data.employeeRoleEventDataSet.employee_role_eventRow;
            System.Data.DataRow employeeRow = ((System.Data.DataRowView)_colView.CurrentItem).Row;

            return (eventsRow.role_id == employeeRow["role_id"].ToString());

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
            string role_id = ""; 

            try
            {

                System.Data.DataRow dataRow = ((System.Data.DataRowView)_colView.CurrentItem).Row;

                role_id = dataRow["role_id"].ToString();

                dataRow.Delete();
            }
            catch
            {
            }

          
            try
            {
                DataTable dt = roleEventData.employee_role_event; //posParamData.pos_param;
                foreach (DataRow dr in dt.Rows)
                {
                    if (string.Equals(dr["role_id"].ToString(), role_id) )
                    {
                        dr.Delete();
                    }

                }
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
            if (string.IsNullOrEmpty(View.SelectedOrganizationId()))
            {
                Microsoft.Windows.Controls.MessageBox.Show("Please set the default organization and try this option again", "Add command", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!rolesData.HasErrors)
            {

                EclipsePOS.WPF.SystemManager.Data.employeeRolesDataSet.employee_rolesRow dataRow = rolesData.employee_roles.Newemployee_rolesRow();

                dataRow.role_id = "";    
                dataRow.role_name = "";
                dataRow.organization_no = View.SelectedOrganizationId();
                
                rolesData.employee_roles.Addemployee_rolesRow(dataRow);

                _colView.MoveCurrentToLast();
                View.SetSelectedItemCursor();
                this.View.SetFocusToRoleName();
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
            if (rolesData.HasChanges() || this.roleEventData.HasChanges())
            {
                MessageBoxResult result = Microsoft.Windows.Controls.MessageBox.Show("Are you sure you want to lose all your changes", "Revert command", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    rolesData.RejectChanges();
                    roleEventData.RejectChanges();
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
            if (rolesData.HasErrors)
            {
                Microsoft.Windows.Controls.MessageBox.Show("Please correct the errors first", "Save command", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                try
                {
                    if (rolesData.HasChanges())
                    {
                        if (rolesTaManager.UpdateAll(rolesData) > 0)
                        {
                            Microsoft.Windows.Controls.MessageBox.Show("Saved roles", "Save command", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    if (roleEventData.HasChanges() )
                    {
                        if (roleEventTaManager.UpdateAll(roleEventData) > 0)
                        {
                            Microsoft.Windows.Controls.MessageBox.Show("Saved role events", "Save command", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    
                } catch (Exception ex)
                {
                    if (roleEventData.HasChanges())
                    {
                        if (roleEventTaManager.UpdateAll(roleEventData) > 0)
                        {
                            Microsoft.Windows.Controls.MessageBox.Show("Saved role events", "Save command", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }

                    if (rolesData.HasChanges())
                    {

                        if (rolesTaManager.UpdateAll(rolesData) > 0)
                        {
                            Microsoft.Windows.Controls.MessageBox.Show("Saved roles", "Save command", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
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

        #region Add Event Command

        public void OnAddEventCommandExecute(object obj)
        {
            if (View.SelectedRoleEvent() != null && View.SelectedRoleEvent().Length > 0)
            {

                foreach (object objV in this._colViewSelectedRoleEvents)
                {
                    string existingEvent = ((System.Data.DataRowView)objV)["role_event_name"].ToString();
                    string selectedEvent  = View.SelectedRoleEvent().ToString (); 
                    if ( existingEvent.CompareTo(selectedEvent ) == 0 )
                    {
                        View.MoveToNextManagedEvent();
                        return;
                    }
                }
               
                System.Data.DataRow employeeRow = ((System.Data.DataRowView)_colView.CurrentItem).Row;
                string roleID = employeeRow["role_id"].ToString();
                if (roleID.Length == 0)
                {
                    Microsoft.Windows.Controls.MessageBox.Show("Please save the role profiles before creating role events", "Add command", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                EclipsePOS.WPF.SystemManager.Data.employeeRoleEventDataSet.employee_role_eventRow dataRow = roleEventData.employee_role_event.Newemployee_role_eventRow();

                dataRow.role_event_id = eventId[View.SelectedRoleEvent()];
                dataRow.role_id = roleID;
                dataRow.role_event_name = View.SelectedRoleEvent();
                dataRow.organization_no = View.SelectedOrganizationId(); 

                roleEventData.employee_role_event.Addemployee_role_eventRow(dataRow);
               
                View.MoveToNextManagedEvent();

                
            }
           
        }

        public bool OnAddEventCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion 

        #region Remove Event Command

        public void OnRemoveEventCommandExecute(object obj)
        {
           
               // System.Data.DataRow dataRow = ((System.Data.DataRowView)_colViewSelectedRoleEvents.CurrentItem).Row;
               // dataRow.Delete();
            View.RemoveSelectedRoleEvent();
           
         }

        public bool OnRemoveEventCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion 

        public void FilterEmployeeRolesByOrganizationNo(string organizationNo)
        {

            BindingListCollectionView view1 = CollectionViewSource.GetDefaultView(this.rolesData.employee_roles) as BindingListCollectionView;

            if (view1 != null)
            {
                view1.CustomFilter = "organization_no = '" + organizationNo.ToString() + "'";

                //view1.GroupDescriptions.Clear();
               // PropertyGroupDescription groupDescription = new PropertyGroupDescription();
               // groupDescription.PropertyName = "param_catogory";
               // view1.GroupDescriptions.Add(groupDescription);
            }

        }


    }
}
