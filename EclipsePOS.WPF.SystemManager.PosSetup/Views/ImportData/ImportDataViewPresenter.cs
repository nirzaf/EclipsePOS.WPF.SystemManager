using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Composite.Events;
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
using System.Threading;
using System.Windows.Threading;

using EclipsePOS.WPF.SystemManager.PosSetup.Views.FolderPicker;




namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.ImportData
{
    public class ImportDataViewPresenter
    {
        private IImportDataView _view;
        public DelegateCommand<object> OKCommand;
        public DelegateCommand<object> FolderPickerCommand;

        private IUnityContainer _container;
        private IRegionManager _regionManager;

        public delegate void RunImportDelegate();




        public ImportDataViewPresenter(IUnityContainer container, IRegionManager regionManager)
        {
            this._container = container;
            this._regionManager = regionManager;

            OKCommand = new DelegateCommand<object>(OnOKCommandExecute, OnOKCommandCanExecute);
            FolderPickerCommand = new DelegateCommand<object>(OnFolderPickerCommandExecute, OnFolderPickerCommandCanExecute);
        }

        public IImportDataView View
        {
            get
            {
                return _view;
            }
            set
            {
                this._view = value;
            }
        }


        public void OnShowImportDataView()
        {
            View.SetOKBtnDataContext(OKCommand);
            View.SetFolderPickerBtnDataContext(FolderPickerCommand);
        }


        #region Folder Picker Command

        public void OnFolderPickerCommandExecute(object obj)
        {
            IFolderPicker view1 = _container.Resolve<FolderPickerView>();
            int response = view1.ShowInputDialog();
            if (response > 0)
            {
                View.SetPath(view1.Path);
            }

        }

        public bool OnFolderPickerCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion

        #region OK Command

        public void OnOKCommandExecute(object obj)
        {

            Properties.Settings.Default.ImportFolder = View.InputFolderPath();
            Properties.Settings.Default.Save();


            RunImportDelegate runImp = new RunImportDelegate(this.ImportData);
            runImp.BeginInvoke(null, null);


            //View.StartBusyIndicator();
            //this.ImportData();
            //View.EndBusyIndicator();
            //View.CloseDialog();

        }

        public bool OnOKCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion

        #region Import data
        private void ImportData()
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
            this.EmployeeRoleData();
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
            this.PosKeyData();

            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Send, (SendOrPostCallback)delegate { View.EndBusyIndicator(); }, null);
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Send, (SendOrPostCallback)delegate { View.CloseDialog(); }, null);

        }
        #endregion 



        #region ImportHelper


        private void OrganizationData()
        {
            //Organization
            try
            {
                EclipsePOS.WPF.SystemManager.Data.organizationDataSet orgDataSetXml = new organizationDataSet();
                orgDataSetXml.ReadXml(View.InputFolderPath() + "\\Organization.xml", XmlReadMode.ReadSchema);

                EclipsePOS.WPF.SystemManager.Data.organizationDataSet orgDataSetRDB = new organizationDataSet();
                EclipsePOS.WPF.SystemManager.Data.organizationDataSetTableAdapters.organizationTableAdapter orgTableAdapter = new  EclipsePOS.WPF.SystemManager.Data.organizationDataSetTableAdapters.organizationTableAdapter();

                orgTableAdapter.Fill(orgDataSetRDB.organization);
                orgDataSetRDB.Merge(orgDataSetXml);
                orgTableAdapter.Update(orgDataSetRDB);
            }
            catch (Exception e)
            {
                //Microsoft.Windows.Controls.MessageBox.Show(e.ToString());
                return;
            }

        }

        //Deprtment
        private void DepartmentData()
        {
            try
            {
                EclipsePOS.WPF.SystemManager.Data.DepartmentDataSet deptDatasetXml = new DepartmentDataSet();
                deptDatasetXml.ReadXml(View.InputFolderPath() + "\\Department.xml", XmlReadMode.ReadSchema);

                EclipsePOS.WPF.SystemManager.Data.DepartmentDataSet deptDatasetRDB = new DepartmentDataSet();
                EclipsePOS.WPF.SystemManager.Data.DepartmentDataSetTableAdapters.departmentTableAdapter deptTableAdapter = new EclipsePOS.WPF.SystemManager.Data.DepartmentDataSetTableAdapters.departmentTableAdapter();

                deptTableAdapter.Fill(deptDatasetRDB.department);
                deptDatasetRDB.Merge(deptDatasetXml);
                deptTableAdapter.Update(deptDatasetRDB);
            }
            catch (Exception e)
            {
                //Microsoft.Windows.Controls.MessageBox.Show(e.ToString());
                return;
            }

        }


        //Item_group
        private void ItemGroupData()
        {
            try
            {
                EclipsePOS.WPF.SystemManager.Data.ItemGroupDataSet itemGroupDataSetXml = new ItemGroupDataSet();
                itemGroupDataSetXml.ReadXml(View.InputFolderPath() + "\\ItemGroup.xml", XmlReadMode.ReadSchema);

                EclipsePOS.WPF.SystemManager.Data.ItemGroupDataSet itemGroupDataSetRDB = new ItemGroupDataSet();
                EclipsePOS.WPF.SystemManager.Data.ItemGroupDataSetTableAdapters.ItemGroupTableAdapter itemGroupTableAdapter = new  EclipsePOS.WPF.SystemManager.Data.ItemGroupDataSetTableAdapters.ItemGroupTableAdapter();
                itemGroupTableAdapter.Fill(itemGroupDataSetRDB.ItemGroup);
                
                itemGroupDataSetRDB.Merge(itemGroupDataSetXml);
                itemGroupTableAdapter.Update(itemGroupDataSetRDB);
            }
            catch (Exception e)
            {
                //Microsoft.Windows.Controls.MessageBox.Show(e.ToString());
                return;
            }

        }

        //TaxGroup
        private void TaxGroupData()
        {
            try
            {
                EclipsePOS.WPF.SystemManager.Data.taxGroupDataSet taxGroupDataSetXml = new  taxGroupDataSet();
                taxGroupDataSetXml.ReadXml(View.InputFolderPath() + "\\Tax_group.xml", XmlReadMode.ReadSchema);

                EclipsePOS.WPF.SystemManager.Data.taxGroupDataSet taxGroupDataSetRDB = new taxGroupDataSet();
                EclipsePOS.WPF.SystemManager.Data.taxGroupDataSetTableAdapters.tax_groupTableAdapter taxGroupTableAdapter = new  EclipsePOS.WPF.SystemManager.Data.taxGroupDataSetTableAdapters.tax_groupTableAdapter();
                taxGroupTableAdapter.Fill(taxGroupDataSetRDB.tax_group);

                taxGroupDataSetRDB.Merge(taxGroupDataSetXml);
                taxGroupTableAdapter.Update(taxGroupDataSetRDB);
            }
            catch (Exception e)
            {
                //Microsoft.Windows.Controls.MessageBox.Show(e.ToString());
                return;
            }

        }


        //Tax
        private void TaxData()
        {
            try
            {
                EclipsePOS.WPF.SystemManager.Data.taxDataSet taxDataSetXml = new  taxDataSet();
                taxDataSetXml.ReadXml(View.InputFolderPath() + "\\Tax.xml", XmlReadMode.ReadSchema);

                EclipsePOS.WPF.SystemManager.Data.taxDataSet taxDataSetRDB = new  taxDataSet();
                EclipsePOS.WPF.SystemManager.Data.taxDataSetTableAdapters.taxTableAdapter taxTableAdapter = new EclipsePOS.WPF.SystemManager.Data.taxDataSetTableAdapters.taxTableAdapter();
                taxTableAdapter.Fill(taxDataSetRDB.tax);

                taxDataSetRDB.Merge(taxDataSetXml);
                taxTableAdapter.Update(taxDataSetRDB);
            }
            catch (Exception e)
            {
                //Microsoft.Windows.Controls.MessageBox.Show(e.ToString());
                return;
            }

        }


        //Item
        private void ItemData()
        {
            try
            {
                EclipsePOS.WPF.SystemManager.Data.ItemsDataSet itemDataSetXml = new  ItemsDataSet();
                itemDataSetXml.ReadXml(View.InputFolderPath() + "\\Item.xml", XmlReadMode.ReadSchema);

                EclipsePOS.WPF.SystemManager.Data.ItemsDataSet itemDataSetRDB = new  ItemsDataSet();
                EclipsePOS.WPF.SystemManager.Data.ItemsDataSetTableAdapters.itemTableAdapter  itemTableAdapter = new  EclipsePOS.WPF.SystemManager.Data.ItemsDataSetTableAdapters.itemTableAdapter();
                itemTableAdapter.Fill(itemDataSetRDB.item);

                itemDataSetRDB.Merge(itemDataSetXml);
                itemTableAdapter.Update(itemDataSetRDB);
            }
            catch (Exception e)
            {
                //Microsoft.Windows.Controls.MessageBox.Show(e.ToString());
                return;
            }

        }


        //Store
        private void StoreData()
        {
            try
            {
                EclipsePOS.WPF.SystemManager.Data.storeDataSet dataSetXml = new  storeDataSet();
                dataSetXml.ReadXml(View.InputFolderPath() + "\\Store.xml", XmlReadMode.ReadSchema);

                EclipsePOS.WPF.SystemManager.Data.storeDataSet dataSetRDB = new  storeDataSet();
                EclipsePOS.WPF.SystemManager.Data.storeDataSetTableAdapters.retail_storeTableAdapter tableAdapter = new  EclipsePOS.WPF.SystemManager.Data.storeDataSetTableAdapters.retail_storeTableAdapter();
                tableAdapter.Fill(dataSetRDB.retail_store);

                dataSetRDB.Merge(dataSetXml);
                tableAdapter.Update(dataSetRDB);
            }
            catch (Exception e)
            {
                //Microsoft.Windows.Controls.MessageBox.Show(e.ToString());
                return;
            }

        }


        //Station
        private void StationData()
        {
            try
            {
                EclipsePOS.WPF.SystemManager.Data.stationDataSet dataSetXml = new  stationDataSet();
                dataSetXml.ReadXml(View.InputFolderPath() + "\\Station.xml", XmlReadMode.ReadSchema);

                EclipsePOS.WPF.SystemManager.Data.stationDataSet dataSetRDB = new  stationDataSet();
                EclipsePOS.WPF.SystemManager.Data.stationDataSetTableAdapters.posTableAdapter  tableAdapter = new EclipsePOS.WPF.SystemManager.Data.stationDataSetTableAdapters.posTableAdapter();
                tableAdapter.Fill(dataSetRDB.pos);

                dataSetRDB.Merge(dataSetXml);
                tableAdapter.Update(dataSetRDB);
            }
            catch (Exception e)
            {
                //Microsoft.Windows.Controls.MessageBox.Show(e.ToString());
                return;
            }

        }

        //Customer
        private void CustomerData()
        {
            try
            {
                EclipsePOS.WPF.SystemManager.Data.customerDataSet dataSetXml = new  customerDataSet();
                dataSetXml.ReadXml(View.InputFolderPath() + "\\Customer.xml", XmlReadMode.ReadSchema);

                EclipsePOS.WPF.SystemManager.Data.customerDataSet dataSetRDB = new  customerDataSet();
                EclipsePOS.WPF.SystemManager.Data.customerDataSetTableAdapters.customerTableAdapter  tableAdapter = new  EclipsePOS.WPF.SystemManager.Data.customerDataSetTableAdapters.customerTableAdapter();
                tableAdapter.Fill(dataSetRDB.customer);

                dataSetRDB.Merge(dataSetXml);
                tableAdapter.Update(dataSetRDB);
            }
            catch (Exception e)
            {
                //Microsoft.Windows.Controls.MessageBox.Show(e.ToString());
                return;
            }

        }


        //EmployeeRoles
        private void EmployeeRoleData()
        {
            try
            {
                EclipsePOS.WPF.SystemManager.Data.employeeRolesDataSet dataSetXml = new  employeeRolesDataSet();
                dataSetXml.ReadXml(View.InputFolderPath() + "\\EmployeeRoles.xml", XmlReadMode.ReadSchema);

                EclipsePOS.WPF.SystemManager.Data.employeeRolesDataSet dataSetRDB = new  employeeRolesDataSet();
                EclipsePOS.WPF.SystemManager.Data.employeeRolesDataSetTableAdapters.employee_rolesTableAdapter tableAdapter = new  EclipsePOS.WPF.SystemManager.Data.employeeRolesDataSetTableAdapters.employee_rolesTableAdapter();
                tableAdapter.Fill(dataSetRDB.employee_roles);

                dataSetRDB.Merge(dataSetXml);
                tableAdapter.Update(dataSetRDB);
            }
            catch (Exception e)
            {
                //Microsoft.Windows.Controls.MessageBox.Show(e.ToString());
                return;
            }

        }


        //EmployeeRolesEvent
        private void EmployeeRolesEventData()
        {
            try
            {
                EclipsePOS.WPF.SystemManager.Data.employeeRoleEventDataSet dataSetXml = new  employeeRoleEventDataSet();
                dataSetXml.ReadXml(View.InputFolderPath() + "\\EmployeeRoleEvents.xml", XmlReadMode.ReadSchema);

                EclipsePOS.WPF.SystemManager.Data.employeeRoleEventDataSet dataSetRDB = new  employeeRoleEventDataSet();
                EclipsePOS.WPF.SystemManager.Data.employeeRoleEventDataSetTableAdapters.employee_role_eventTableAdapter tableAdapter = new EclipsePOS.WPF.SystemManager.Data.employeeRoleEventDataSetTableAdapters.employee_role_eventTableAdapter();
                tableAdapter.Fill(dataSetRDB.employee_role_event);

                dataSetRDB.Merge(dataSetXml);
                tableAdapter.Update(dataSetRDB);
            }
            catch (Exception e)
            {
                //Microsoft.Windows.Controls.MessageBox.Show(e.ToString());
                return;
            }

        }

        //Currency code 
        private void CurrencyCodeData()
        {
            try
            {
                EclipsePOS.WPF.SystemManager.Data.currencyCodeDataSet dataSetXml = new  currencyCodeDataSet();
                dataSetXml.ReadXml(View.InputFolderPath() + "\\CurrencyCode.xml", XmlReadMode.ReadSchema);

                EclipsePOS.WPF.SystemManager.Data.currencyCodeDataSet dataSetRDB = new  currencyCodeDataSet();
                EclipsePOS.WPF.SystemManager.Data.currencyCodeDataSetTableAdapters.currency_codeTableAdapter tableAdapter = new  EclipsePOS.WPF.SystemManager.Data.currencyCodeDataSetTableAdapters.currency_codeTableAdapter();
                tableAdapter.Fill(dataSetRDB.currency_code);

                dataSetRDB.Merge(dataSetXml);
                tableAdapter.Update(dataSetRDB);
            }
            catch (Exception e)
            {
                //Microsoft.Windows.Controls.MessageBox.Show(e.ToString());
                return;
            }

        }


        //Currency
        private void CurrencyData()
        {
            try
            {
                EclipsePOS.WPF.SystemManager.Data.currencyDataSet  dataSetXml = new  currencyDataSet();
                dataSetXml.ReadXml(View.InputFolderPath() + "\\Currency.xml", XmlReadMode.ReadSchema);

                EclipsePOS.WPF.SystemManager.Data.currencyDataSet dataSetRDB = new  currencyDataSet();
                EclipsePOS.WPF.SystemManager.Data.currencyDataSetTableAdapters.currencyTableAdapter  tableAdapter = new  EclipsePOS.WPF.SystemManager.Data.currencyDataSetTableAdapters.currencyTableAdapter();
                tableAdapter.Fill(dataSetRDB.currency);

                dataSetRDB.Merge(dataSetXml);
                tableAdapter.Update(dataSetRDB);
            }
            catch (Exception e)
            {
                //Microsoft.Windows.Controls.MessageBox.Show(e.ToString());
                return;
            }

        }

        //Promotion
        private void PromotionData()
        {
            try
            {
                EclipsePOS.WPF.SystemManager.Data.promotionDataSet dataSetXml = new  promotionDataSet();
                dataSetXml.ReadXml(View.InputFolderPath() + "\\Promotion.xml", XmlReadMode.ReadSchema);

                EclipsePOS.WPF.SystemManager.Data.promotionDataSet dataSetRDB = new  promotionDataSet();
                EclipsePOS.WPF.SystemManager.Data.promotionDataSetTableAdapters.promotionTableAdapter tableAdapter = new  EclipsePOS.WPF.SystemManager.Data.promotionDataSetTableAdapters.promotionTableAdapter();
                tableAdapter.Fill(dataSetRDB.promotion);

                dataSetRDB.Merge(dataSetXml);
                tableAdapter.Update(dataSetRDB);
            }
            catch (Exception e)
            {
                //Microsoft.Windows.Controls.MessageBox.Show(e.ToString());
                return;
            }

        }


        //PromotionMap
        private void PromotionMapData()
        {
            try
            {
                EclipsePOS.WPF.SystemManager.Data.promotionMapDataSet dataSetXml = new  promotionMapDataSet();
                dataSetXml.ReadXml(View.InputFolderPath() + "\\PromotionMap.xml", XmlReadMode.ReadSchema);

                EclipsePOS.WPF.SystemManager.Data.promotionMapDataSet dataSetRDB = new  promotionMapDataSet();
                EclipsePOS.WPF.SystemManager.Data.promotionMapDataSetTableAdapters.promotion_mapTableAdapter tableAdapter = new  EclipsePOS.WPF.SystemManager.Data.promotionMapDataSetTableAdapters.promotion_mapTableAdapter();
                tableAdapter.Fill(dataSetRDB.promotion_map);

                dataSetRDB.Merge(dataSetXml);
                tableAdapter.Update(dataSetRDB);
            }
            catch (Exception e)
            {
                //Microsoft.Windows.Controls.MessageBox.Show(e.ToString());
                return;
            }

        }


        //TableGroup
        private void TableGroupData()
        {
            try
            {
                EclipsePOS.WPF.SystemManager.Data.tableGroupDataSet dataSetXml = new  tableGroupDataSet();
                dataSetXml.ReadXml(View.InputFolderPath() + "\\TableGroup.xml", XmlReadMode.ReadSchema);

                EclipsePOS.WPF.SystemManager.Data.tableGroupDataSet dataSetRDB = new  tableGroupDataSet();
                EclipsePOS.WPF.SystemManager.Data.tableGroupDataSetTableAdapters.table_groupTableAdapter  tableAdapter = new  EclipsePOS.WPF.SystemManager.Data.tableGroupDataSetTableAdapters.table_groupTableAdapter();
                tableAdapter.Fill(dataSetRDB.table_group);

                dataSetRDB.Merge(dataSetXml);
                tableAdapter.Update(dataSetRDB);
            }
            catch (Exception e)
            {
                //Microsoft.Windows.Controls.MessageBox.Show(e.ToString());
                return;
            }

        }


        //Table
        private void TableDetailsData()
        {
            try
            {
                EclipsePOS.WPF.SystemManager.Data.tableDetailsDataSet dataSetXml = new  tableDetailsDataSet();
                dataSetXml.ReadXml(View.InputFolderPath() + "\\TableDetails.xml", XmlReadMode.ReadSchema);

                EclipsePOS.WPF.SystemManager.Data.tableDetailsDataSet dataSetRDB = new  tableDetailsDataSet();
                EclipsePOS.WPF.SystemManager.Data.tableDetailsDataSetTableAdapters.table_detailsTableAdapter tableAdapter = new  EclipsePOS.WPF.SystemManager.Data.tableDetailsDataSetTableAdapters.table_detailsTableAdapter();
                tableAdapter.Fill(dataSetRDB.table_details);

                dataSetRDB.Merge(dataSetXml);
                tableAdapter.Update(dataSetRDB);
            }
            catch (Exception e)
            {
                //Microsoft.Windows.Controls.MessageBox.Show(e.ToString());
                return;
            }

        }


        //Configurations
        private void ConfigurationData()
        {
            try
            {
                EclipsePOS.WPF.SystemManager.Data.posConfigDataSet dataSetXml = new  posConfigDataSet();
                dataSetXml.ReadXml(View.InputFolderPath() + "\\PosConfig.xml", XmlReadMode.ReadSchema);

                EclipsePOS.WPF.SystemManager.Data.posConfigDataSet dataSetRDB = new  posConfigDataSet();
                EclipsePOS.WPF.SystemManager.Data.posConfigDataSetTableAdapters.pos_configTableAdapter tableAdapter = new  EclipsePOS.WPF.SystemManager.Data.posConfigDataSetTableAdapters.pos_configTableAdapter();
                tableAdapter.Fill(dataSetRDB.pos_config);

                dataSetRDB.Merge(dataSetXml);
                tableAdapter.Update(dataSetRDB);
            }
            catch (Exception e)
            {
                //Microsoft.Windows.Controls.MessageBox.Show(e.ToString());
                return;
            }

        }

        //Parameters
        private void ParametersData()
        {
            try
            {
                EclipsePOS.WPF.SystemManager.Data.posParamDataSet dataSetXml = new  posParamDataSet();
                dataSetXml.ReadXml(View.InputFolderPath() + "\\PosParam.xml", XmlReadMode.ReadSchema);

                EclipsePOS.WPF.SystemManager.Data.posParamDataSet dataSetRDB = new  posParamDataSet();
                EclipsePOS.WPF.SystemManager.Data.posParamDataSetTableAdapters.pos_paramTableAdapter tableAdapter = new  EclipsePOS.WPF.SystemManager.Data.posParamDataSetTableAdapters.pos_paramTableAdapter();
                tableAdapter.Fill(dataSetRDB.pos_param);

                dataSetRDB.Merge(dataSetXml);
                tableAdapter.Update(dataSetRDB);
            }
            catch (Exception e)
            {
                //Microsoft.Windows.Controls.MessageBox.Show(e.ToString());
                return;
            }

        }


        //MenuPanels
        private void MenuPanelsData()
        {
            try
            {
                EclipsePOS.WPF.SystemManager.Data.menuPanelsDataSet dataSetXml = new  menuPanelsDataSet();
                dataSetXml.ReadXml(View.InputFolderPath() + "\\MenuPanels.xml", XmlReadMode.ReadSchema);

                EclipsePOS.WPF.SystemManager.Data.menuPanelsDataSet dataSetRDB = new  menuPanelsDataSet();
                EclipsePOS.WPF.SystemManager.Data.menuPanelsDataSetTableAdapters.menu_panelsTableAdapter tableAdapter = new  EclipsePOS.WPF.SystemManager.Data.menuPanelsDataSetTableAdapters.menu_panelsTableAdapter();
                tableAdapter.Fill(dataSetRDB.menu_panels);

                dataSetRDB.Merge(dataSetXml);
                tableAdapter.Update(dataSetRDB);
            }
            catch (Exception e)
            {
                //Microsoft.Windows.Controls.MessageBox.Show(e.ToString());
                return;
            }

        }


        //PosKey
        private void PosKeyData()
        {
            try
            {
                EclipsePOS.WPF.SystemManager.Data.posKeyDataSet dataSetXml = new  posKeyDataSet();
                dataSetXml.ReadXml(View.InputFolderPath() + "\\PosKey.xml", XmlReadMode.ReadSchema);

                EclipsePOS.WPF.SystemManager.Data.posKeyDataSet dataSetRDB = new  posKeyDataSet();
                EclipsePOS.WPF.SystemManager.Data.posKeyDataSetTableAdapters.pos_keyTableAdapter tableAdapter = new  EclipsePOS.WPF.SystemManager.Data.posKeyDataSetTableAdapters.pos_keyTableAdapter();
                tableAdapter.Fill(dataSetRDB.pos_key);

                dataSetRDB.Merge(dataSetXml);
                tableAdapter.Update(dataSetRDB);
            }
            catch (Exception e)
            {
                //Microsoft.Windows.Controls.MessageBox.Show(e.ToString());
                return;
            }

        }

        #endregion
    }
}
