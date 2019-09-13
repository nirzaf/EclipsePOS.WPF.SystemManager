using System;
using System.Collections.Generic;
//using System.Linq;
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
using EclipsePOS.WPF.SystemManager.Infrastructure;
using System.Windows.Markup;
using System.IO;
using System.Windows.Documents;
using EclipsePOS.WPF.SystemManager.Data.Util;
using System.Windows.Threading;
using System.Threading;
using System.Windows.Xps.Packaging;

//[assembly: XmlnsDefinition("http://www.eclipse_software.com.sg/WPF", "EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.ReportingServices")]

namespace EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.Views.SalesSummary
{
    public class SalesSummaryViewPresenter
    {
        ISalesSummaryView _view;

        private EclipsePOS.WPF.SystemManager.Data.storeDataSet storeData;
        private EclipsePOS.WPF.SystemManager.Data.organizationLookupDataSet organizationData;

        public DelegateCommand<object> RunCommand;
        public DelegateCommand<object> SaveCommand;
        private IUnityContainer _container;
        private IRegionManager _regionManager;

        public delegate void RunRportDelegate();

        private XpsDocument xpsRep;
        private FlowDocument fdRep;

        public SalesSummaryViewPresenter(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;

            RunCommand = new DelegateCommand<object>(OnRunCommandExecute, OnRunCommandCanExecute);
            SaveCommand = new DelegateCommand<object>(OnSaveCommandExecute, OnSaveCommandCanExecute);

        }


        public ISalesSummaryView View
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

        public void OnShowSalesSummaryView()
        {
            storeData = new storeDataSet();
            EclipsePOS.WPF.SystemManager.Data.storeDataSetTableAdapters.retail_storeTableAdapter storeTa = new EclipsePOS.WPF.SystemManager.Data.storeDataSetTableAdapters.retail_storeTableAdapter();
            storeTa.Fill(storeData.retail_store);
            View.SetRetailStoreFromDataContext(storeData.retail_store);
            View.SetRetailStoreToDataContext(storeData.retail_store);

            organizationData = new EclipsePOS.WPF.SystemManager.Data.organizationLookupDataSet();
            EclipsePOS.WPF.SystemManager.Data.organizationLookupDataSetTableAdapters.organizationTableAdapter organizationTa = new  EclipsePOS.WPF.SystemManager.Data.organizationLookupDataSetTableAdapters.organizationTableAdapter();
            organizationTa.Fill(organizationData.organization);
            View.SetOrganizationFromDataContext(organizationData.organization);
            View.SetOrganizationToDataContext(organizationData.organization);


            View.SetRunBtnDataContext(RunCommand);
            View.SetSaveBtnDataContext(SaveCommand);
        }

        #region Run Command

        public void OnRunCommandExecute(object obj)
        {
            //MessageBox.Show(DataModule.CurrDataSourcePath);

            RunRportDelegate runRpt = new RunRportDelegate(this.RunReportHelper);
            runRpt.BeginInvoke(null, null);


        }

        public bool OnRunCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }
        #endregion

          #region Run Command

        public void OnSaveCommandExecute(object obj)
        {
            MessageBox.Show("OK");
        }

         public bool OnSaveCommandCanExecute(object obj)
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
                 string query = "select store_name, cast( [possite].[dbo].[ufn_GetDateOnly](start_time) as varchar(12 ) ) as sales_date, sum(ext_amount) amt,  sum(promo.amt) as promo_amt, [possite].[dbo].[ufn_Addition](sum(ext_amount), sum(promo.amt) ) as net_sales " +
                                "from trans_item join trans on " +
                                "(trans.trans_no = trans_item.trans_no and trans.organization_no = trans_item.organization_no and  " +
                                "trans.store_no = trans_item.store_no )" +
                                "left outer join " +
                                "(SELECT trans_promotion.organization_no, trans_promotion.store_no,  trans_promotion.trans_no, trans_promotion.line_no, sum(trans_promotion.promotion_amount) amt " +
                                "FROM trans_promotion " +
                                "group by trans_promotion.organization_no, trans_promotion.store_no, trans_promotion.trans_no, trans_promotion.line_no) " +
                                "AS promo " +  
                                "on (trans_item.organization_no=promo.organization_no and trans_item.store_no = promo.store_no and trans_item.trans_no=promo.trans_no and trans_item.line_no = promo.line_no) " +
                                "left outer join retail_store on " +
                                "(trans.store_no=retail_store.store_no and trans.organization_no = retail_store.organization_no ) " +
                                "where trans.state = 2 " +
                                " and trans_item.state = 2 " +
                                " and trans.organization_no >= @organizationFrom and trans.organization_no <= @organizationTo " +
                                " and trans.store_no >= @storeFrom and trans.store_no <= @storeTo " +
                                " and [possite].[dbo].[ufn_GetDateOnly](start_time) >= @salesDateFrom and [possite].[dbo].[ufn_GetDateOnly](start_time) <= @salesDateTo " +
                                "group by store_name, [possite].[dbo].[ufn_GetDateOnly](start_time)" +
                                "order by store_name, sales_date";

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

                 // Open the file that contains the FlowDocument...
                 // FileStream xamlFile = new FileStream("../Debug/Data/SalesSummaryReport", FileMode.Open, FileAccess.Read);
                 // and parse the file with the XamlReader.Load method.
                 // FlowDocument fd = XamlReader.Load(xamlFile) as FlowDocument;
                 // xamlFile.Close();
                 // object obj1 = fd.FindName("reportHeader");
                 // MessageBox.Show(obj1.ToString());


                 ReportData rData = DataEngine.Load(dataReader, new string[] { "store_name" });
                 ReportDefinition rDef = new ReportDefinition();
                 rDef.ReportName = "SalesSummary";
                 rDef.Page.Margin = new Size(40, 70);
                 //Header definition
                 rDef.HeaderTemplate = "<Section><Paragraph TextAlignment=\"Center\" FontWeight=\"Bold\" FontSize=\"12\">Sales Summay Report</Paragraph></Section>";


                 //Table definition
                 rDef.TableDefinition = @"<Table>
                                          <Table.Columns>
                                            <TableColumn />
                                            <TableColumn />
                                            <TableColumn />
                                            <TableColumn />
                                           </Table.Columns>
                                         </Table>";

                 //Item definition
                 rDef.ItemTemplate = "<TableRow>" +
                                         "<TableCell BorderThickness=\"0,0,0,0\" BorderBrush=\"Black\" >" +
                                             "<Paragraph FontSize=\"12\"  TextAlignment=\"Center\" >" +
                                                 "<c:FormattedRun PropertyName=\"sales_date\"/>" +
                                             "</Paragraph>" +
                                         "</TableCell>" +
                                          "<TableCell BorderThickness=\"0,0,0,0\" BorderBrush=\"Black\"  >" +
                                             "<Paragraph FontSize=\"12\"  TextAlignment=\"Center\" >" +
                                                 "<c:FormattedRun PropertyName=\"amt\"/>" +
                                             "</Paragraph>" +
                                         "</TableCell>" +
                                          "<TableCell BorderThickness=\"0,0,0,0\" BorderBrush=\"Black\"  >" +
                                             "<Paragraph FontSize=\"12\"  TextAlignment=\"Center\" >" +
                                                 "<c:FormattedRun PropertyName=\"promo_amt\"/>" +
                                             "</Paragraph>" +
                                         "</TableCell>" +
                                         "<TableCell BorderThickness=\"0,0,0,0\" BorderBrush=\"Black\"  >" +
                                             "<Paragraph FontSize=\"12\"  TextAlignment=\"Center\" >" +
                                                 "<c:FormattedRun PropertyName=\"net_sales\"/>" +
                                             "</Paragraph>" +
                                         "</TableCell>" +
                                     "</TableRow>";

                 //Footer definition
                 rDef.FooterTemplate = "<Section>" +
                                         "<Paragraph TextAlignment=\"Center\" FontSize=\"12\">*** End of Sales Summary Report ***</Paragraph> " +
                                       "</Section>";


                 rDef.Page.HeaderTemplate = "<Section>" +
                                                 "<Paragraph TextAlignment=\"Right\" FontSize=\"12\" >" +
                                                             "Page @PageNumber from @PageCount" +
                                                 "</Paragraph>" +
                                            "</Section>";

                 string strDate = System.DateTime.Now.ToShortDateString();
                 string strTime = System.DateTime.Now.ToShortTimeString();
                 // string strUser = InfrastructureModule.GetCurrentUser();
                 rDef.Page.FooterTemplate = "<Section>" +
                                                 "<Paragraph TextAlignment=\"Right\" FontSize=\"12\" >" +
                                                             "Date: " + strDate + "  " + "Time: " + strTime +
                                                 "</Paragraph>" +
                                            "</Section>";
                 //rDef.Page.Margin = new Size(96, 96);

                 //Group definitions
                 GroupDefinition def1 = new GroupDefinition();
                 def1.HeaderTemplate = "<TableRowGroup>" +
                                         "<TableRow>" +
                                             "<TableCell ColumnSpan=\"3\">" +
                                               "<Paragraph FontWeight=\"Bold\" FontSize=\"12\">Store :" +
                                                 "<c:FormattedRun PropertyName=\"store_no\"/> " +
                                               "</Paragraph>" +
                                             "</TableCell>" +
                                         "</TableRow>" +
                                          "<TableRow>" +
                                             "<TableCell >" +
                                             "</TableCell>" +
                                         "</TableRow>" +
                                         "<TableRow>" +
                                             "<TableCell BorderThickness=\"0,0,0,0\" BorderBrush=\"Black\" >" +
                                                 "<Paragraph FontWeight=\"Bold\" FontSize=\"12\" TextAlignment=\"Center\">Date</Paragraph>" +
                                             "</TableCell>" +
                                             "<TableCell BorderThickness=\"0,0,0,0\" BorderBrush=\"Black\">" +
                                                 "<Paragraph FontWeight=\"Bold\" FontSize=\"12\" TextAlignment=\"Center\" >Sales amount</Paragraph>" +
                                             "</TableCell>" +
                                             "<TableCell BorderThickness=\"0,0,0,0\" BorderBrush=\"Black\">" +
                                                 "<Paragraph FontWeight=\"Bold\" FontSize=\"12\" TextAlignment=\"Center\" >Discount</Paragraph>" +
                                             "</TableCell>" +
                                                "<TableCell BorderThickness=\"0,0,0,0\" BorderBrush=\"Black\">" +
                                                 "<Paragraph FontWeight=\"Bold\" FontSize=\"12\" TextAlignment=\"Center\" >Total Sales Amount</Paragraph>" +
                                             "</TableCell>" +
                                          "</TableRow>" +
                                     "</TableRowGroup>";




                 def1.FooterTemplate = "<TableRowGroup > " +
                                             "<TableRow>" +
                                             "<TableCell> " +
                                             "</TableCell>" +
                                             "</TableRow> " +
                                             "<TableRow>" +
                                                 "<TableCell BorderThickness=\"0,0,0,0\" BorderBrush=\"Black\">" +
                                                     "<Paragraph FontWeight=\"Bold\" FontSize=\"12\" TextAlignment=\"Center\">" +
                                                     "Total Sales:" +
                                                     "</Paragraph>" +
                                                 "</TableCell>" +
                                                 "<TableCell BorderThickness=\"0,0,0,0\" BorderBrush=\"Black\">" +
                                                     "<Paragraph FontWeight=\"Bold\" FontSize=\"12\" TextAlignment=\"Center\" >" +
                                                         "<c:FormattedRun PropertyName=\"amt\"/>" +
                                                     "</Paragraph>" +
                                                 "</TableCell>" +
                                                  "<TableCell BorderThickness=\"0,0,0,0\" BorderBrush=\"Black\">" +
                                                     "<Paragraph FontWeight=\"Bold\" FontSize=\"12\" TextAlignment=\"Center\" >" +
                                                         "<c:FormattedRun PropertyName=\"promo_amt\"/>" +
                                                     "</Paragraph>" +
                                                 "</TableCell>" +
                                                 "<TableCell BorderThickness=\"0,0,0,0\" BorderBrush=\"Black\">" +
                                                     "<Paragraph FontWeight=\"Bold\" FontSize=\"12\" TextAlignment=\"Center\" >" +
                                                         "<c:FormattedRun PropertyName=\"net_sales\"/>" +
                                                     "</Paragraph>" +
                                                 "</TableCell>" +
                                             "</TableRow>" +
                                         "</TableRowGroup>";


                 def1.NewPageOnGroupBreak = true;

                 /*
                 GroupDefinition def2 = new GroupDefinition();
                 def2.HeaderTemplate = "<TableRowGroup>" +
                                     "<TableRow>" +
                                     "<TableCell ColumnSpan=\"3\">" +
                                         "<Paragraph FontWeight=\"Bold\">Trans id: " +
                                             "<c:FormattedRun PropertyName=\"Trans id\"/> " +
                                         "</Paragraph>" +
                                     "</TableCell>" +
                                 "</TableRow>" +

                                 "<TableRow>" +
                                     "<TableCell>" +
                                         "<Paragraph FontWeight=\"Bold\">Trans Id</Paragraph>" +
                                     "</TableCell>" +
                                     "<TableCell>" +
                                         "<Paragraph FontWeight=\"Bold\">SKU</Paragraph>" +
                                     "</TableCell>" +
                                     "<TableCell>" +
                                         "<Paragraph FontWeight=\"Bold\" TextAlignment=\"Right\">Amount</Paragraph>" +
                                     "</TableCell>" +
                                 "</TableRow>" +
                                     "</TableRowGroup>"; 




                 def2.FooterTemplate = @"<TableRowGroup >
                                             <TableRow>
                                                 <TableCell>
                                                     <Paragraph>
                                                     Total:
                                                     </Paragraph>
                                                 </TableCell>
                                             </TableRow>
                                             <TableRow>
                                                 <TableCell ></TableCell>
                                             </TableRow>
                                         </TableRowGroup>";
                 def2.NewPageOnGroupBreak = true;
                  * 
                  */

                 List<GroupDefinition> grpDef = new List<GroupDefinition>();
                 grpDef.Add(def1);
                 //grpDef.Add(def2);

                 rDef.Groups = grpDef;



                 ReportEngine repEngine = _container.Resolve<ReportEngine>() as ReportEngine;
                 //View.DisplayDocument(repEngine.CreateReport.CreateFlowDocumentReport(rDef, rData) );
                 // View.DisplayDocument(repEngine.CreateReport(rDef, rData));
                 this.xpsRep = repEngine.CreateReport(rDef, rData);
                 this.fdRep = repEngine.CreateFlowDocumentReport(rDef, rData);
                 

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
