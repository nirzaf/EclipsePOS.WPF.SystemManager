using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Packaging;
using System.Printing;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Documents.Serialization;
using System.Windows.Media;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;
using System.Windows.Xps.Serialization;
using System.Windows;

using EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.BarcodeLib;

namespace EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.Views.ItemLabels
{
    public class LabelPrintHelper
    {

        private  static LocalPrintServer ps;
        private  static PrintQueue pq;

        public LabelPrintHelper()
        {
            if (ps == null)
            {
                ps = new LocalPrintServer();
                pq = ps.DefaultPrintQueue;
            }   
                
        
        }

        // -------------------- GetPrintXpsDocumentWriter() -------------------
        /// <summary>
        ///   Returns an XpsDocumentWriter for the default print queue.</summary>
        /// <returns>
        ///   An XpsDocumentWriter for the default print queue.</returns>
        public static XpsDocumentWriter GetPrintXpsDocumentWriter()
        {
            // Create a local print server
            //LocalPrintServer ps = new LocalPrintServer();

            // Get the default print queue
            //PrintQueue pq = ps.DefaultPrintQueue;


            // Get an XpsDocumentWriter for the default print queue
            XpsDocumentWriter xpsdw = PrintQueue.CreateXpsDocumentWriter(pq);
            return xpsdw;
        }// end:GetPrintXpsDocumentWriter()


        public static Size GetPageSize()
        {
            double height = (double)pq.DefaultPrintTicket.PageMediaSize.Height;
            double width = (double)pq.DefaultPrintTicket.PageMediaSize.Width;
            return new Size(width, height);

        }

        public static double GetPageHight()
        {
            return (double)pq.DefaultPrintTicket.PageMediaSize.Height;
        }

        public static double GetPageWidth()
        {
            return (double)pq.DefaultPrintTicket.PageMediaSize.Width;
        }


        // ---------------------- GetPrintTicketFromPrinter -----------------------
        /// <summary>
        ///   Returns a PrintTicket based on the current default printer.</summary>
        /// <returns>
        ///   A PrintTicket for the current local default printer.</returns>
        private PrintTicket GetPrintTicketFromPrinter()
        {
            PrintQueue printQueue = null;

            LocalPrintServer localPrintServer = new LocalPrintServer();

            // Retrieving collection of local printer on user machine
            PrintQueueCollection localPrinterCollection =
                localPrintServer.GetPrintQueues();

            System.Collections.IEnumerator localPrinterEnumerator =
                localPrinterCollection.GetEnumerator();

            if (localPrinterEnumerator.MoveNext())
            {
                // Get PrintQueue from first available printer
                printQueue = (PrintQueue)localPrinterEnumerator.Current;
            }
            else
            {
                // No printer exist, return null PrintTicket
                return null;
            }

            // Get default PrintTicket from printer
            PrintTicket printTicket = printQueue.DefaultPrintTicket;

            PrintCapabilities printCapabilites = printQueue.GetPrintCapabilities();

            // Modify PrintTicket
            if (printCapabilites.CollationCapability.Contains(Collation.Collated))
            {
                printTicket.Collation = Collation.Collated;
            }

            if (printCapabilites.DuplexingCapability.Contains(
                    Duplexing.TwoSidedLongEdge))
            {
                printTicket.Duplexing = Duplexing.TwoSidedLongEdge;
            }

            if (printCapabilites.StaplingCapability.Contains(Stapling.StapleDualLeft))
            {
                printTicket.Stapling = Stapling.StapleDualLeft;
            }

            return printTicket;
        }// end:GetPrintTicketFromPrinter()



        public static double GetImagebleHight()
        {

            PrintCapabilities printCapabilites = pq.GetPrintCapabilities();
            return printCapabilites.PageImageableArea.ExtentHeight;

        }

        public static double GetImagebleWidth()
        {

            PrintCapabilities printCapabilites = pq.GetPrintCapabilities();
            return printCapabilites.PageImageableArea.ExtentWidth;

        }


        public XpsDocument CreateLabels(List<WPFBarcode> listBarcode, int numberAcross, int numberDown, double topMargin, double sideMargin)
        {
            //int pageWidth = 700;//just for testing !! get it from your printer
            int pageWidth = (int)LabelPrintHelper.GetImagebleWidth(); //XpsPrintHelper.GetPageWidth();
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

            double colWidth = (pageWidth - 2 * sideMargin * 96) / numberAcross;


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
            int col = numberAcross + 1;
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

            pd.FooterHeight = 0;
            pd.Margin = new Size(sideMargin * 96, topMargin * 96);
            pd.HeaderHeight = 0;

            return LabelPaginator.CreateXpsDocument(fd, pd);
        }

         
    }
}
