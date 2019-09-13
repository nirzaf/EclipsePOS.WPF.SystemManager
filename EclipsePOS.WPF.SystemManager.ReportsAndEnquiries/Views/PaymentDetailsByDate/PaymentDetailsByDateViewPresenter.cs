using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Composite.Events;
using Microsoft.Practices.Composite.Presentation.Commands;
using Microsoft.Practices.Composite.Regions;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows;
using EclipsePOS.WPF.SystemManager.Data;
using EclipsePOS.WPF.SystemManager.Infrastructure.Constants;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using Microsoft.Practices.Unity;
using EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.ReportingServices;
using EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.Views.XPSDoc;
using System.Windows.Markup;
using System.IO;
using System.Windows.Documents;
using EclipsePOS.WPF.SystemManager.Data.Util;
using System.Windows.Threading;
using System.Threading;
using System.Windows.Xps.Packaging;



namespace EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.Views.PaymentDetailsByDate
{
    public class PaymentDetailsByDateViewPresenter
    {
        private IPaymentDetailsByDateView _view;
        private EclipsePOS.WPF.SystemManager.Data.organizationLookupDataSet organizationData;
        public DelegateCommand<object> RunCommand;
        private IUnityContainer _container;
        private IRegionManager _regionManager;
        private EclipsePOS.WPF.SystemManager.Data.storeDataSet storeData;
        public delegate void RunRportDelegate();

        private XpsDocument xpsRep;
       
        public PaymentDetailsByDateViewPresenter(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;

            RunCommand = new DelegateCommand<object>(OnRunCommandExecute, OnRunCommandCanExecute);
           
        }


        public IPaymentDetailsByDateView View
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

        public void OnShowPaymentDetailsByDate()
        {
            storeData = new storeDataSet();
            EclipsePOS.WPF.SystemManager.Data.storeDataSetTableAdapters.retail_storeTableAdapter storeTa = new EclipsePOS.WPF.SystemManager.Data.storeDataSetTableAdapters.retail_storeTableAdapter();
            storeTa.Fill(storeData.retail_store);
            View.SetRetailStoreFromDataContext(storeData.retail_store);
            View.SetRetailStoreToDataContext(storeData.retail_store);

            organizationData = new EclipsePOS.WPF.SystemManager.Data.organizationLookupDataSet();
            EclipsePOS.WPF.SystemManager.Data.organizationLookupDataSetTableAdapters.organizationTableAdapter organizationTa = new EclipsePOS.WPF.SystemManager.Data.organizationLookupDataSetTableAdapters.organizationTableAdapter();
            organizationTa.Fill(organizationData.organization);
            View.SetOrganizationFromDataContext(organizationData.organization);

            View.SetOrganizationToDataContext(organizationData.organization);
            View.SetRunBtnDataContext(RunCommand);
        }

        #region Run Command

        public void OnRunCommandExecute(object obj)
        {
            
            RunRportDelegate runRpt = new RunRportDelegate(this.RunReportHelper);
            runRpt.BeginInvoke(null, null);
            
        }

        public bool OnRunCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }
        #endregion

        private void RunReportHelper()
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Send, (SendOrPostCallback)delegate { View.StartSyncAnimation(); }, null);


            SqlConnection con = new SqlConnection(PosSettings.Default.possiteConnectionString); //DataModule.CurrDataSourcePath);
            try
            {
                con.Open();
                string query = "select store_name, trans_tender.trans_no, (amount-change_amt) amt, tender_desc, " +
                               "cast ([possite].[dbo].[ufn_GetDateOnly](start_time) as varchar(12) ) as trans_date " +
                                "from trans_tender join trans " +
                                "on  (trans_tender.trans_no = trans.trans_no and  trans_tender.organization_no = trans.organization_no and " +
                                "trans_tender.store_no = trans.store_no  ) " +
                                "join retail_store on " +
                                "(trans.store_no=retail_store.store_no and trans.organization_no = retail_store.organization_no ) " +
                                "where trans.state = 2 " +
                                "and trans.organization_no >= @organizationFrom and trans.organization_no <= @organizationTo " +
                               " and trans.store_no >= @storeFrom and trans.store_no <= @storeTo " +
                               " and [possite].[dbo].[ufn_GetDateOnly](start_time) >= @salesDateFrom and [possite].[dbo].[ufn_GetDateOnly](start_time) <= @salesDateTo " + 
                                "order by store_name, trans_date, trans_tender.trans_no ";
    
                    
                SqlCommand comm = new SqlCommand(query, con);
                comm.Parameters.Add("@organizationFrom", SqlDbType.Char).Value = View.OrganizationNoFrom;
                comm.Parameters.Add("@organizationTo", SqlDbType.Char).Value = View.OrganizationNoTo;
                comm.Parameters.Add("@storeFrom", SqlDbType.Char).Value = View.StoreNoFrom;
                comm.Parameters.Add("@storeTo", SqlDbType.Char).Value = View.StoreNoTo;
                comm.Parameters.Add("@salesDateFrom", SqlDbType.DateTime).Value = View.SalesDateFrom;
                comm.Parameters.Add("@salesDateTo", SqlDbType.DateTime).Value = View.SalesDateTo;
                
                SqlDataAdapter dataAdapter = new SqlDataAdapter(comm);
                DataTable dataTable1 = new DataTable("trans_items");
                dataAdapter.Fill(dataTable1);
                SqlDataReader dataReader = comm.ExecuteReader();

            
                ReportData rData = DataEngine.Load(dataReader, new string[] { "store_name", "trans_date" } );
                ReportDefinition rDef = new ReportDefinition();
                rDef.ReportName = "PaymentDetailsByDate";

                rDef.Page.Margin = new Size(40, 70);
                //Header definition
                rDef.HeaderTemplate = "<Section><Paragraph TextAlignment=\"Center\" FontWeight=\"Bold\" FontSize=\"12\">Payment details by date Report</Paragraph></Section>";


                //Table definition
                rDef.TableDefinition = @"<Table>
                                          <Table.Columns>
                                            <TableColumn />
                                            <TableColumn />
                                            <TableColumn />
                                           </Table.Columns>
                                         </Table>";

                //Item definition
                rDef.ItemTemplate = "<TableRow>" +
                                    "<TableCell >" +
                                        "<Paragraph FontSize=\"12\">" +
                                            "<c:FormattedRun PropertyName=\"trans_no\"/>" +
                                        "</Paragraph>" +
                                    "</TableCell>" +
                                    "<TableCell >" +
                                        "<Paragraph FontSize=\"12\" >" +
                                            "<c:FormattedRun PropertyName=\"tender_desc\"/>" +
                                        "</Paragraph>" +
                                    "</TableCell>" +
                                    "<TableCell>" +
                                        "<Paragraph TextAlignment=\"Right\" FontSize=\"12\">" +
                                            "<c:FormattedRun PropertyName=\"amt\"/>" +
                                        "</Paragraph>" +
                                    "</TableCell>" +
                                "</TableRow>";

                //Footer definition
                rDef.FooterTemplate = "<Section><Paragraph TextAlignment=\"Center\" FontSize=\"12\">*** End of Payment Details Report ***</Paragraph></Section>";

                rDef.Page.HeaderTemplate = "<Section>" +
                                                "<Paragraph TextAlignment=\"Right\" FontSize=\"12\" >" +
                                                            "Page @PageNumber from @PageCount" +
                                                "</Paragraph>" +
                                           "</Section>";
                string strDate = System.DateTime.Now.ToShortDateString();
                string strTime = System.DateTime.Now.ToShortTimeString();
                rDef.Page.FooterTemplate = "<Section>" +
                                                "<Paragraph TextAlignment=\"Right\" FontSize=\"12\" >" +
                                                            "Date: " + strDate + "  " + "Time: " + strTime +
                                                "</Paragraph>" +
                                           "</Section>";



                //Group definitions
                GroupDefinition def1 = new GroupDefinition();
                def1.HeaderTemplate = "<TableRowGroup>" +
                                        "<TableRow>" +
                                            "<TableCell ColumnSpan=\"3\">" +
                                                "<Paragraph FontWeight=\"Bold\" FontSize=\"12\">Store: " +
                                                    "<c:FormattedRun PropertyName=\"store_name\"/> " +
                                                "</Paragraph>" +
                                            "</TableCell>" +
                                        "</TableRow>" +
                                        "<TableRow>" +
                                            "<TableCell>" +
                                                "<Paragraph FontWeight=\"Bold\" FontSize=\"12\">Receipt no</Paragraph>" +
                                            "</TableCell>" +
                                             "<TableCell>" +
                                                "<Paragraph FontWeight=\"Bold\" FontSize=\"12\">Payment Description</Paragraph>" +
                                            "</TableCell>" +
                                            "<TableCell>" +
                                                "<Paragraph FontWeight=\"Bold\" TextAlignment=\"Right\" FontSize=\"12\">Payment Amount</Paragraph>" +
                                            "</TableCell>" +
                                          "</TableRow>" +
                                    "</TableRowGroup>";




                def1.FooterTemplate = "<TableRowGroup > " +
                                            "<TableRow>" +
                                                "<TableCell>" +
                                                    "<Paragraph FontWeight=\"Bold\" FontSize=\"12\">" +
                                                    "Total for:" +
                                                    "<c:FormattedRun PropertyName=\"store_name\"/> " +
                                                    "</Paragraph>" +
                                                "</TableCell>" +
                                                "<TableCell>" +
                                                "</TableCell>" +
                                                "<TableCell>" +
                                                    "<Paragraph TextAlignment=\"Right\" FontWeight=\"Bold\" FontSize=\"12\">" +
                                                        "<c:FormattedRun PropertyName=\"amt\"/>" +
                                                    "</Paragraph>" +
                                                "</TableCell>" +
                                               "</TableRow>" +
                                        "</TableRowGroup>";


                def1.NewPageOnGroupBreak = true;


                GroupDefinition groupDefByDate = new GroupDefinition();
                groupDefByDate.HeaderTemplate = "<TableRowGroup>" +
                                        "<TableRow>" +
                                            "<TableCell ColumnSpan=\"3\">" +
                                                "<Paragraph FontWeight=\"Bold\" FontSize=\"12\">Date: " +
                                                    "<c:FormattedRun PropertyName=\"trans_date\"/> " +
                                                "</Paragraph>" +
                                            "</TableCell>" +
                                        "</TableRow>" +
                                        "</TableRowGroup>";




                groupDefByDate.FooterTemplate = "<TableRowGroup > " +
                                            "<TableRow>" +
                                                "<TableCell>" +
                                                    "<Paragraph FontWeight=\"Bold\" FontSize=\"12\">" +
                                                    "Total for :" +
                                                    "<c:FormattedRun PropertyName=\"trans_date\"/> " +  
                                                    "</Paragraph>" +
                                                "</TableCell>" +
                                                "<TableCell>" +
                                                "</TableCell>" +
                                                "<TableCell>" +
                                                    "<Paragraph TextAlignment=\"Right\" FontWeight=\"Bold\" FontSize=\"12\">" +
                                                        "<c:FormattedRun PropertyName=\"amt\"/>" +
                                                    "</Paragraph>" +
                                                "</TableCell>" +
                                               "</TableRow>" +
                                        "</TableRowGroup>";


                groupDefByDate.NewPageOnGroupBreak = true;


             
                List<GroupDefinition> grpDef = new List<GroupDefinition>();
                grpDef.Add(def1);
                grpDef.Add(groupDefByDate);

                rDef.Groups = grpDef;



                ReportEngine repEngine = _container.Resolve<ReportEngine>() as ReportEngine;
                this.xpsRep = repEngine.CreateReport(rDef, rData);

                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Send, (SendOrPostCallback)delegate { this.DisplayReport(); }, null);
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Send, (SendOrPostCallback)delegate { View.EndSyncAnimation(); }, null);
         

        }



        private void DisplayReport()
        {

            IRegion mainRegion = _regionManager.Regions[Regions.ReportsMain];

            //Remove the view on main region 
            object mainView = mainRegion.GetView("MainView");
            if (mainView != null)
            {
                mainRegion.Remove(mainView);
            }

            XPSDocView view = _container.Resolve<XPSDocView>() as XPSDocView;
            view.DisplayDoc(this.xpsRep);
            mainRegion.Add(view, "MainView");
            mainRegion.Activate(view);
        }

    }
}
