using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Composite.Presentation.Events;
using Microsoft.Practices.Composite.Presentation.Commands;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Unity;
using EclipsePOS.WPF.SystemManager.Infrastructure.Constants;
using EclipsePOS.WPF.SystemManager.PosSetup.Views.PosConfigInput;
using EclipsePOS.WPF.SystemManager.PosSetup.Util;
using EclipsePOS.WPF.SystemManager.Data;
using System.Xml;
using System.Xml.Linq;
using EclipsePOS.WPF.SystemManager.PosSetup.Views.FolderPicker;
using System.Windows.Threading;
using System.Threading;



namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.ExportData
{
    public class ExportDataPresenter
    {

        private IExportDataView _view;
        public DelegateCommand<object> OKCommand;
        public DelegateCommand<object> FolderPickerCommand;

        private IUnityContainer _container;
        private IRegionManager _regionManager;

        public delegate void RunExportDelegate();



        public ExportDataPresenter(IUnityContainer container, IRegionManager regionManager)
        {
            this._container = container;
            this._regionManager = regionManager;

            OKCommand = new DelegateCommand<object>(OnOKCommandExecute, OnOKCommandCanExecute);
            FolderPickerCommand = new DelegateCommand<object>(OnFolderPickerCommandExecute, OnFolderPickerCommandCanExecute);
        }


        public IExportDataView View
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


        public void OnShowExportDataView()
        {

            View.SetFolderPickerBtnDataContext(FolderPickerCommand);
            View.SetOKBtnDataContext(OKCommand);
        }


        #region OK Command

        public void OnOKCommandExecute(object obj)
        {

            RunExportDelegate runExp = new RunExportDelegate(this.ExportData);
            runExp.BeginInvoke(null, null);

            
          //  this.ExportData();
          //  View.StartBusyIndicator();
          //  this.ExportData();
          //  View.EndBusyIndicator();
          //  View.CloseDialog();
        
        }

        public bool OnOKCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion

        #region Folder Picker Command

        public void OnFolderPickerCommandExecute(object obj)
        {
             IFolderPicker view1 = _container.Resolve<FolderPickerView>();
             int response = view1.ShowInputDialog();
             if (response > 0)
             {
                 Properties.Settings.Default.ExportFolder = view1.Path;
                 Properties.Settings.Default.Save();

                 View.SetPath(view1.Path);
             }

        }

        public bool OnFolderPickerCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion


        #region Export data
        private void ExportData()
        {

           Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Send, (SendOrPostCallback)delegate { View.StartBusyIndicator(); }, null);

            //Inventory
            this.OrganizationData();
            this.DepartmentData();
            this.ItemGroupData();
            this.TaxGroupData();
            this.TaxData();
            this.ItemData();
            
            //Operations+Sttings
            this.StoreData();
            this.StationData();
            this.CustomerData();
            this.EmployeeRoles();
            this.EmployeeRolesEventData();
            this.CurrencyCodeData();
            this.CurrencyData();
            this.PromotionData();
            this.PromotionMapData();
            this.TableGroupData();
            this.TableDetailsData();
            //Configurations
            this.ConfigurationData();
            this.ParametersData();
            this.MenuPanelsData();
            this.PosKeysData();

            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Send, (SendOrPostCallback)delegate { View.EndBusyIndicator(); }, null);
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Send, (SendOrPostCallback)delegate { View.CloseDialog(); }, null);

            //View.CloseDialog();
        }
        #endregion 



        #region Export Helper 
        
        
        //Organization
        private void OrganizationData()
        {
            try
            {
                EclipsePOS.WPF.SystemManager.Data.organizationDataSet orgDataSet = new organizationDataSet();
                EclipsePOS.WPF.SystemManager.Data.organizationDataSetTableAdapters.organizationTableAdapter orgTableAdapter = new EclipsePOS.WPF.SystemManager.Data.organizationDataSetTableAdapters.organizationTableAdapter();
                orgTableAdapter.Fill(orgDataSet.organization);
                orgDataSet.WriteXml(View.OutputFolderPath() + "\\Organization.xml", XmlWriteMode.WriteSchema);
            }
            catch (Exception e)
            {
                //Microsoft.Windows.Controls.MessageBox.Show(e.ToString());
            }
        }

       
        
        //Department
            
        private void DepartmentData()
        {
            try
            {
                EclipsePOS.WPF.SystemManager.Data.DepartmentDataSet deptDataset = new DepartmentDataSet();
                EclipsePOS.WPF.SystemManager.Data.DepartmentDataSetTableAdapters.departmentTableAdapter deptTableAdapter = new EclipsePOS.WPF.SystemManager.Data.DepartmentDataSetTableAdapters.departmentTableAdapter();
                deptTableAdapter.Fill(deptDataset.department);
                deptDataset.WriteXml(View.OutputFolderPath() + "\\Department.xml", XmlWriteMode.WriteSchema);
            }
            catch (Exception e)
            {
               //Microsoft.Windows.Controls.MessageBox.Show(e.ToString());
                
            }
        }

        //ItemGroup

        private void ItemGroupData()
        {
            try
            {
                EclipsePOS.WPF.SystemManager.Data.ItemGroupDataSet groupDataSet = new ItemGroupDataSet();
                EclipsePOS.WPF.SystemManager.Data.ItemGroupDataSetTableAdapters.ItemGroupTableAdapter groupTableAdapter = new EclipsePOS.WPF.SystemManager.Data.ItemGroupDataSetTableAdapters.ItemGroupTableAdapter();
                groupTableAdapter.Fill(groupDataSet.ItemGroup);
                groupDataSet.WriteXml(View.OutputFolderPath() + "\\ItemGroup.xml", XmlWriteMode.WriteSchema);
            }
            catch (Exception e)
            {
               // Microsoft.Windows.Controls.MessageBox.Show(e.ToString());

            }
        }


        //Tax Group Data
        private void TaxGroupData()
        {
            try
            {
                EclipsePOS.WPF.SystemManager.Data.taxGroupDataSet taxGroupDataSet = new  taxGroupDataSet();
                EclipsePOS.WPF.SystemManager.Data.taxGroupDataSetTableAdapters.tax_groupTableAdapter taxGroupTableAdapter = new EclipsePOS.WPF.SystemManager.Data.taxGroupDataSetTableAdapters.tax_groupTableAdapter();
                taxGroupTableAdapter.Fill(taxGroupDataSet.tax_group);
                taxGroupDataSet.WriteXml(View.OutputFolderPath() + "\\Tax_group.xml", XmlWriteMode.WriteSchema);
            }
            catch (Exception e)
            {
                //Microsoft.Windows.Controls.MessageBox.Show(e.ToString());

            }
        }


        //Tax Data
        private void TaxData()
        {
            try
            {
                EclipsePOS.WPF.SystemManager.Data.taxDataSet taxDataSet = new  taxDataSet();
                EclipsePOS.WPF.SystemManager.Data.taxDataSetTableAdapters.taxTableAdapter  taxTableAdapter = new  EclipsePOS.WPF.SystemManager.Data.taxDataSetTableAdapters.taxTableAdapter();
                taxTableAdapter.Fill(taxDataSet.tax);
                taxDataSet.WriteXml(View.OutputFolderPath() + "\\Tax.xml", XmlWriteMode.WriteSchema);
            }
            catch (Exception e)
            {
               //Microsoft.Windows.Controls.MessageBox.Show(e.ToString());

            }
        }


        //Item Data
        private void ItemData()
        {
            try
            {
                EclipsePOS.WPF.SystemManager.Data.ItemsDataSet itemDataSet = new  ItemsDataSet();
                EclipsePOS.WPF.SystemManager.Data.ItemsDataSetTableAdapters.itemTableAdapter itemTableAdapter = new  EclipsePOS.WPF.SystemManager.Data.ItemsDataSetTableAdapters.itemTableAdapter();
                itemTableAdapter.Fill(itemDataSet.item);
                itemDataSet.WriteXml(View.OutputFolderPath() + "\\Item.xml", XmlWriteMode.WriteSchema);
            }
            catch (Exception e)
            {
                //Microsoft.Windows.Controls.MessageBox.Show(e.ToString());

            }
        }



        //Store  Data
        private void StoreData()
        {
            try
            {
                EclipsePOS.WPF.SystemManager.Data.storeDataSet storeDataSet = new  storeDataSet();
                EclipsePOS.WPF.SystemManager.Data.storeDataSetTableAdapters.retail_storeTableAdapter  storeTableAdapter = new  EclipsePOS.WPF.SystemManager.Data.storeDataSetTableAdapters.retail_storeTableAdapter();
                storeTableAdapter.Fill(storeDataSet.retail_store);
                storeDataSet.WriteXml(View.OutputFolderPath() + "\\Store.xml", XmlWriteMode.WriteSchema);
            }
            catch (Exception e)
            {
                //Microsoft.Windows.Controls.MessageBox.Show(e.ToString());

            }
        }

        //Station Data
        private void StationData()
        {
            try
            {
                EclipsePOS.WPF.SystemManager.Data.stationDataSet stationDataSet = new stationDataSet();
                EclipsePOS.WPF.SystemManager.Data.stationDataSetTableAdapters.posTableAdapter  stationTableAdapter = new  EclipsePOS.WPF.SystemManager.Data.stationDataSetTableAdapters.posTableAdapter();
                stationTableAdapter.Fill(stationDataSet.pos);
                stationDataSet.WriteXml(View.OutputFolderPath() + "\\Station.xml", XmlWriteMode.WriteSchema);
            }
            catch (Exception e)
            {
                //Microsoft.Windows.Controls.MessageBox.Show(e.ToString());

            }
        }



        //Customer Data
        private void CustomerData()
        {
            try
            {
                EclipsePOS.WPF.SystemManager.Data.customerDataSet customerDataSet = new  customerDataSet();
                EclipsePOS.WPF.SystemManager.Data.customerDataSetTableAdapters.customerTableAdapter customerTableAdapter = new  EclipsePOS.WPF.SystemManager.Data.customerDataSetTableAdapters.customerTableAdapter();
                customerTableAdapter.Fill(customerDataSet.customer);
                customerDataSet.WriteXml(View.OutputFolderPath() + "\\Customer.xml", XmlWriteMode.WriteSchema);
            }
            catch (Exception e)
            {
                //Microsoft.Windows.Controls.MessageBox.Show(e.ToString());

            }
        }

        //Employee Roles
        private void EmployeeRoles()
        {
            try
            {
                EclipsePOS.WPF.SystemManager.Data.employeeRolesDataSet  employeeRolesDataSet = new  employeeRolesDataSet();
                EclipsePOS.WPF.SystemManager.Data.employeeRolesDataSetTableAdapters.employee_rolesTableAdapter employeeRolesTableAdapter = new EclipsePOS.WPF.SystemManager.Data.employeeRolesDataSetTableAdapters.employee_rolesTableAdapter();
                employeeRolesTableAdapter.Fill(employeeRolesDataSet.employee_roles);
                employeeRolesDataSet.WriteXml(View.OutputFolderPath() + "\\EmployeeRoles.xml", XmlWriteMode.WriteSchema);
            }
            catch (Exception e)
            {
                //Microsoft.Windows.Controls.MessageBox.Show(e.ToString());

            }
        }

        //EmployeeRolesEvents Data
        private void EmployeeRolesEventData()
        {
            try
            {
                EclipsePOS.WPF.SystemManager.Data.employeeRoleEventDataSet employeeRolesEventDataSet = new  employeeRoleEventDataSet();
                EclipsePOS.WPF.SystemManager.Data.employeeRoleEventDataSetTableAdapters.employee_role_eventTableAdapter employeeRolesEventTableAdapter = new  EclipsePOS.WPF.SystemManager.Data.employeeRoleEventDataSetTableAdapters.employee_role_eventTableAdapter();
                employeeRolesEventTableAdapter.Fill(employeeRolesEventDataSet.employee_role_event);
                employeeRolesEventDataSet.WriteXml(View.OutputFolderPath() + "\\EmployeeRoleEvents.xml", XmlWriteMode.WriteSchema);
            }
            catch (Exception e)
            {
                //Microsoft.Windows.Controls.MessageBox.Show(e.ToString());

            }
        }


        //CurrencyCode Data
        private void CurrencyCodeData()
        {
            try
            {
                EclipsePOS.WPF.SystemManager.Data.currencyCodeDataSet  currencyCodeDataSet = new  currencyCodeDataSet();
                EclipsePOS.WPF.SystemManager.Data.currencyCodeDataSetTableAdapters.currency_codeTableAdapter currencyCodeTableAdapter = new  EclipsePOS.WPF.SystemManager.Data.currencyCodeDataSetTableAdapters.currency_codeTableAdapter();
                currencyCodeTableAdapter.Fill(currencyCodeDataSet.currency_code);
                currencyCodeDataSet.WriteXml(View.OutputFolderPath() + "\\CurrencyCode.xml", XmlWriteMode.WriteSchema);
            }
            catch (Exception e)
            {
                //Microsoft.Windows.Controls.MessageBox.Show(e.ToString());

            }
        }


        //Currency Data
        private void CurrencyData()
        {
            try
            {
                EclipsePOS.WPF.SystemManager.Data.currencyDataSet currencyDataSet = new  currencyDataSet();
                EclipsePOS.WPF.SystemManager.Data.currencyDataSetTableAdapters.currencyTableAdapter currencyTableAdapter = new  EclipsePOS.WPF.SystemManager.Data.currencyDataSetTableAdapters.currencyTableAdapter();
                currencyTableAdapter.Fill(currencyDataSet.currency);
                currencyDataSet.WriteXml(View.OutputFolderPath() + "\\Currency.xml", XmlWriteMode.WriteSchema);
            }
            catch (Exception e)
            {
                //Microsoft.Windows.Controls.MessageBox.Show(e.ToString());

            }
        }


        //Promotion Data
        private void PromotionData()
        {
            try
            {
                EclipsePOS.WPF.SystemManager.Data.promotionDataSet promotionDataSet = new  promotionDataSet();
                EclipsePOS.WPF.SystemManager.Data.promotionDataSetTableAdapters.promotionTableAdapter promotionTableAdapter = new  EclipsePOS.WPF.SystemManager.Data.promotionDataSetTableAdapters.promotionTableAdapter();
                promotionTableAdapter.Fill(promotionDataSet.promotion);
                promotionDataSet.WriteXml(View.OutputFolderPath() + "\\Promotion.xml", XmlWriteMode.WriteSchema);
            }
            catch (Exception e)
            {
                //Microsoft.Windows.Controls.MessageBox.Show(e.ToString());

            }
        }

        //Promotion Data
        private void PromotionMapData()
        {
            try
            {
                EclipsePOS.WPF.SystemManager.Data.promotionMapDataSet promotionMapDataSet = new  promotionMapDataSet();
                EclipsePOS.WPF.SystemManager.Data.promotionMapDataSetTableAdapters.promotion_mapTableAdapter  promotionMapTableAdapter = new  EclipsePOS.WPF.SystemManager.Data.promotionMapDataSetTableAdapters.promotion_mapTableAdapter();
                promotionMapTableAdapter.Fill(promotionMapDataSet.promotion_map);
                promotionMapDataSet.WriteXml(View.OutputFolderPath() + "\\PromotionMap.xml", XmlWriteMode.WriteSchema);
            }
            catch (Exception e)
            {
                //Microsoft.Windows.Controls.MessageBox.Show(e.ToString());

            }
        }

        //TableGroup Data
        private void TableGroupData()
        {
            try
            {
                EclipsePOS.WPF.SystemManager.Data.tableGroupDataSet tableGroupDataSet = new  tableGroupDataSet();
                EclipsePOS.WPF.SystemManager.Data.tableGroupDataSetTableAdapters.table_groupTableAdapter  tableGroupTableAdapter = new  EclipsePOS.WPF.SystemManager.Data.tableGroupDataSetTableAdapters.table_groupTableAdapter();
                tableGroupTableAdapter.Fill(tableGroupDataSet.table_group);
                tableGroupDataSet.WriteXml(View.OutputFolderPath() + "\\TableGroup.xml", XmlWriteMode.WriteSchema);
            }
            catch (Exception e)
            {
                //Microsoft.Windows.Controls.MessageBox.Show(e.ToString());

            }
        }

        //Table Data
        private void TableDetailsData()
        {
            try
            {
                EclipsePOS.WPF.SystemManager.Data.tableDetailsDataSet tableDetailsDataSet = new  tableDetailsDataSet();
                EclipsePOS.WPF.SystemManager.Data.tableDetailsDataSetTableAdapters.table_detailsTableAdapter tableDetailsTableAdapter = new  EclipsePOS.WPF.SystemManager.Data.tableDetailsDataSetTableAdapters.table_detailsTableAdapter();
                tableDetailsTableAdapter.Fill(tableDetailsDataSet.table_details);
                tableDetailsDataSet.WriteXml(View.OutputFolderPath() + "\\TableDetails.xml", XmlWriteMode.WriteSchema);
            }
            catch (Exception e)
            {
                //Microsoft.Windows.Controls.MessageBox.Show(e.ToString());

            }
        }


        //Pos Config Data
        private void ConfigurationData()
        {
            try
            {
                EclipsePOS.WPF.SystemManager.Data.posConfigDataSet posConfigDataSet = new  posConfigDataSet();
                EclipsePOS.WPF.SystemManager.Data.posConfigDataSetTableAdapters.pos_configTableAdapter posConfigTableAdapter = new  EclipsePOS.WPF.SystemManager.Data.posConfigDataSetTableAdapters.pos_configTableAdapter();
                posConfigTableAdapter.Fill(posConfigDataSet.pos_config);
                posConfigDataSet.WriteXml(View.OutputFolderPath() + "\\PosConfig.xml", XmlWriteMode.WriteSchema);
            }
            catch (Exception e)
            {
                //Microsoft.Windows.Controls.MessageBox.Show(e.ToString());

            }
        }


        //Param
        private void ParametersData()
        {
            try
            {
                EclipsePOS.WPF.SystemManager.Data.posParamDataSet posParamDataSet = new  posParamDataSet();
                EclipsePOS.WPF.SystemManager.Data.posParamDataSetTableAdapters.pos_paramTableAdapter posParamTableAdapter = new  EclipsePOS.WPF.SystemManager.Data.posParamDataSetTableAdapters.pos_paramTableAdapter();
                posParamTableAdapter.Fill(posParamDataSet.pos_param);
                posParamDataSet.WriteXml(View.OutputFolderPath() + "\\PosParam.xml", XmlWriteMode.WriteSchema);
            }
            catch (Exception e)
            {
                //Microsoft.Windows.Controls.MessageBox.Show(e.ToString());

            }
        }


        //Menu Panels
        private void MenuPanelsData()
        {
            try
            {
                EclipsePOS.WPF.SystemManager.Data.menuPanelsDataSet menuPanelsDataSet = new  menuPanelsDataSet();
                EclipsePOS.WPF.SystemManager.Data.menuPanelsDataSetTableAdapters.menu_panelsTableAdapter menuPanelsTableAdapter = new  EclipsePOS.WPF.SystemManager.Data.menuPanelsDataSetTableAdapters.menu_panelsTableAdapter();
                menuPanelsTableAdapter.Fill(menuPanelsDataSet.menu_panels);
                menuPanelsDataSet.WriteXml(View.OutputFolderPath() + "\\MenuPanels.xml", XmlWriteMode.WriteSchema);
            }
            catch (Exception e)
            {
                //Microsoft.Windows.Controls.MessageBox.Show(e.ToString());

            }
        }



        //Pos Keys
        private void PosKeysData()
        {
            try
            {
                EclipsePOS.WPF.SystemManager.Data.posKeyDataSet posKeyDataSet = new  posKeyDataSet();
                EclipsePOS.WPF.SystemManager.Data.posKeyDataSetTableAdapters.pos_keyTableAdapter posKeyTableAdapter = new  EclipsePOS.WPF.SystemManager.Data.posKeyDataSetTableAdapters.pos_keyTableAdapter();
                posKeyTableAdapter.Fill(posKeyDataSet.pos_key);
                posKeyDataSet.WriteXml(View.OutputFolderPath() + "\\PosKey.xml", XmlWriteMode.WriteSchema);
            }
            catch (Exception e)
            {
                //Microsoft.Windows.Controls.MessageBox.Show(e.ToString());

            }
        }


        #endregion 



    }
}
