using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
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

namespace EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.ReportingServices
{
    public class XpsPrintHelper
    {

        private static LocalPrintServer ps;
        private static PrintQueue pq;
        static XpsPrintHelper()
        {
            if (ps == null )
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
    }
}
