using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Data;
//using System.Windows.Documents;
//using System.Printing;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Windows.Xps.Packaging;
using System.IO;
using EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.BarcodeLib;



[assembly: XmlnsDefinition("http://www.eclipse_software.com.sg/WPF", "EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.ReportingServices")]

namespace EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.ReportingServices
{
    public class ReportEngine
    {
        static List<FormattedRun> displayItems;

        static ParserContext xamlContext;
        /// <summary>
        /// Helps in namespace mapping during Xaml loading for each template
        /// </summary>
        public static ParserContext XamlContext
        {
            get
            { 
                if (xamlContext == null)
                {
                    xamlContext = new ParserContext();
                    xamlContext.XmlnsDictionary.Add("", "http://schemas.microsoft.com/winfx/2006/xaml/presentation");
                    xamlContext.XmlnsDictionary.Add("c", "http://www.eclipse_software.com.sg/WPF");
                }
                return xamlContext;
            }
        }

        /// <summary>
        /// Creates report part according to specific template , and "binds" the data 
        /// </summary>
        internal static T createReportPart<T>(string template, object data) where T : TextElement
        {
            T templatedItem;

            MemoryStream ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(template));
            templatedItem = (T)XamlReader.Load(ms, XamlContext);
            if (data != null)
            {

                DocumentWalker dw = new DocumentWalker();
                dw.VisualVisited += new DocumentVisitedEventHandler(dw_VisualVisited);
               
                displayItems = new List<FormattedRun>();
                
                if (typeof(T) == typeof(Paragraph))
                        dw.TraverseParagraph(templatedItem as Paragraph);

                else if (typeof(T) == typeof(Section))
                {
                    Section sec = templatedItem as Section;
                    foreach (Block b in sec.Blocks)
                    {
                        Paragraph p = b as Paragraph;
                        if (p != null)
                            dw.TraverseParagraph(p);
                    }
                }
                else if (typeof(T) == typeof(TableRow))
                {
                    TableRow tr = templatedItem as TableRow;
                    foreach (TableCell tc in tr.Cells)
                        dw.TraverseBlockCollection(tc.Blocks);
                }
                else if (typeof(T) == typeof(TableRowGroup))
                {
                    TableRowGroup trg = templatedItem as TableRowGroup;
                    foreach (TableRow tr in trg.Rows)
                    {
                        foreach (TableCell tc in tr.Cells)
                            dw.TraverseBlockCollection(tc.Blocks);
                    }
                }

                foreach (FormattedRun fRun in displayItems)
                {
                    if (data is DataRow)
                    {
                        DataRow row = data as DataRow;
                        if (row.Table.Columns.Contains(fRun.PropertyName))
                            fRun.Data = row[fRun.PropertyName];
                    }
                    else if (data is GroupData)
                    {
                        GroupData gd = data as GroupData;
                        fRun.Data = gd.GetComputedValue(fRun.PropertyName);
                    }
                }
            }

            return templatedItem;
        }

        static void dw_VisualVisited(object sender, object visitedObject, bool start)
        {
            FormattedRun fRun = visitedObject as FormattedRun;
            if (fRun != null)
                displayItems.Add(fRun);
        }


        void copyFromRowGroup(string template, TableRowGroup trg, GroupData r)
        {
            TableRowGroup gf = createReportPart<TableRowGroup>(template, r);
            TableRow[] rows = new TableRow[gf.Rows.Count];

            gf.Rows.CopyTo(rows, 0);
            gf.Rows.Clear();

            for (int j = 0; j < rows.Length; j++)
            {
                TableRow tr = rows[j];
                trg.Rows.Add(tr);
            }
        }

        void addGroup(ReportDefinition rd, TableRowGroup trg, GroupData group, DataTable rData)
        {
            copyFromRowGroup(rd.Groups[group.Level].HeaderTemplate, trg, group);
            if (group.HasNestedGroups)
            {
                foreach (GroupData g in group.NestedDataGroups)
                    addGroup(rd, trg, g, rData);
            }
            else
            {
                int endRow = group.StartRow + group.Count;
                for (int i = group.StartRow; i < endRow; i++)
                {
                    DataRow r = rData.Rows[i];
                    trg.Rows.Add(createReportPart<TableRow>(rd.ItemTemplate, r));
                }
            }
            copyFromRowGroup(rd.Groups[group.Level].FooterTemplate, trg, group);

        }

        public XpsDocument CreateReport(ReportDefinition rd, ReportData rData)
        {
            //int pageWidth = 700;//just for testing !! get it from your printer
            int pageWidth = (int)XpsPrintHelper.GetImagebleWidth();  //XpsPrintHelper.GetPageWidth();
            FlowDocument fd = new FlowDocument();
            fd.Name = rd.ReportName;
            fd.ColumnWidth = pageWidth;
            fd.Blocks.Add(createReportPart<Section>(rd.HeaderTemplate, rData.ReportGroup));
          
            TableRowGroup trg = new TableRowGroup();

            for (int i = 0; i < rData.Groups.Count; i++)
            {
                addGroup(rd, trg, rData.Groups[i], rData.Rows);
            }
            MemoryStream tableStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(rd.TableDefinition));
            Table table = (Table)XamlReader.Load(tableStream, XamlContext);
            table.RowGroups.Add(trg);
            fd.Blocks.Add(table);
            
            fd.Blocks.Add(createReportPart<Section>(rd.FooterTemplate, rData.ReportGroup));
          
            return ReportPaginator.CreateXpsDocument(fd, rd.Page);
                      

        }

        public FlowDocument CreateFlowDocumentReport(ReportDefinition rd, ReportData rData)
        {
            int pageWidth =(int)XpsPrintHelper.GetImagebleWidth(); //700;//just for testing !! get it from your printer
            FlowDocument fd = new FlowDocument();
            fd.ColumnWidth = pageWidth;
            fd.Blocks.Add(createReportPart<Section>(rd.HeaderTemplate, rData.ReportGroup));
            TableRowGroup trg = new TableRowGroup();

            for (int i = 0; i < rData.Groups.Count; i++)
            {
                addGroup(rd, trg, rData.Groups[i], rData.Rows);
            }
            MemoryStream tableStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(rd.TableDefinition));
            Table table = (Table)XamlReader.Load(tableStream, XamlContext);
            table.RowGroups.Add(trg);
            fd.Blocks.Add(table);
            fd.Blocks.Add(createReportPart<Section>(rd.FooterTemplate, rData.ReportGroup));
            //return ReportPaginator.CreateXpsDocument(fd, rd.Page);
           

            // Open the file that contains the FlowDocument...
           // FileStream xamlFile = new FileStream("../Debug/Data/SalesSummaryReport", FileMode.Open, FileAccess.Read);
            // and parse the file with the XamlReader.Load method.
           // FlowDocument fd = XamlReader.Load(xamlFile) as FlowDocument;
           // xamlFile.Close();

            return fd;
        }



        public XpsDocument CreateLabels( List<WPFBarcode> listBarcode, int numberAcross, int numberDown, double topMargin, double sideMargin)
        {
            //int pageWidth = 700;//just for testing !! get it from your printer
            int pageWidth = (int)XpsPrintHelper.GetImagebleWidth(); //XpsPrintHelper.GetPageWidth();
            FlowDocument fd = new FlowDocument();

            fd.ColumnWidth = pageWidth; //pageWidth-2*sideMargin*96;
            
            Table table1 = new Table();
           
            // ...and add it to the FlowDocument Blocks collection.
            fd.Blocks.Add(table1);
            
            // Set some global formatting properties for the table.
            table1.CellSpacing = 0;
           // table1.to
            
            
            
            // Create columns and add them to the table's Columns collection.
            /// Create a local print server

            double colWidth = (pageWidth - 2 * sideMargin* 96 ) / numberAcross;
           
            
            for (int x = 0; x < numberAcross; x++)
            {
                TableColumn tcol = new TableColumn();
                tcol.Width = new GridLength(colWidth);
                table1.Columns.Add(tcol);

                //For debuging only
                // Set alternating background colors for the middle colums.
                //  if (x % 2 == 0)
                //      table1.Columns[x].Background = Brushes.Beige;
                //  else
                //    table1.Columns[x].Background = Brushes.LightSteelBlue;
            }
            
            int row = -1;
            int col = numberAcross+1;
            // Create and add an empty TableRowGroup to hold the table's Rows.
            table1.RowGroups.Add(new TableRowGroup());


            foreach (WPFBarcode b in listBarcode)
            {

                
                // Add the first (title) row.
                if (col >= numberAcross)
                {
                    row++;
                    table1.RowGroups[0].Rows.Add(new TableRow());
                    col = 0;
                }

                // Alias the current working row for easy reference.
                TableRow currentRow = table1.RowGroups[0].Rows[row];

              
                // Add the header row with content, 
                try
                {
                    Image img = b.Encode();

                    TableCell tableCell = new TableCell(new BlockUIContainer(img));
                  //TableCell tableCell = new TableCell(new BlockUIContainer(b.Generate_vector_image_canvas()));
                    currentRow.Cells.Add(tableCell);
                  //tableCell.BorderBrush = Brushes.Red;
                  //tableCell.BorderThickness = new Thickness(.5);
               

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    break;
                    
                }
               
                
                
                col++;
                

            }
            
            PageDefinition pd = new PageDefinition();
         
            pd.FooterHeight =  0;
            pd.Margin = new Size(sideMargin * 96, topMargin*96);
            pd.HeaderHeight = 0; 

            return ReportPaginator.CreateXpsDocument(fd, pd);
        }



    }
}
