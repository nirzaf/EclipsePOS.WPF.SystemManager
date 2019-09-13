using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;
using System.Windows.Media;
using System.IO;
using System.IO.Packaging;
using System.Windows.Xps.Serialization;
using System.Windows.Markup;

[assembly: XmlnsDefinition("http://www.eclipse_software.com.sg/WPF", "EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.ReportingServices")]

namespace EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.ReportingServices
{
    public class ReportPaginator : DocumentPaginator
    {
        
        Size pageSize;

        /// <summary>
        /// Reference to a original flowdoc paginator
        /// </summary>
        DocumentPaginator paginator;

        PageDefinition pageDef;

        /// <summary>
        /// Real total page count number
        /// </summary>
        int pageCount;

        /// <summary>
        /// Minimal space between page header/footer and page content
        /// </summary>
        int minimalOffset = 25;
        //int minimalOffset = 0;

        /// <summary>
        /// Helper method to create page header o footer from flow document template
        /// </summary>
        /// <param name="fd"></param>
        /// <param name="pageDef"></param>
        /// <returns></returns>
        public static XpsDocument CreateXpsDocument(FlowDocument fd, PageDefinition pageDef)
        {
             
            MemoryStream ms = new MemoryStream();
            Package pkg = Package.Open(ms, FileMode.Create, FileAccess.ReadWrite);

            string pack = "pack://" + fd.Name + System.Guid.NewGuid().ToString() + ".xps";
         
            PackageStore.AddPackage(new Uri(pack), pkg);
            XpsDocument doc = new XpsDocument(pkg, CompressionOption.SuperFast, pack);
          
            XpsSerializationManager rsm = new XpsSerializationManager(new XpsPackagingPolicy(doc), false);
            
            DocumentPaginator paginator = ((IDocumentPaginatorSource)fd).DocumentPaginator;
           // Size size = new Size(800, 1024); 
           // ReportPaginator rp = new ReportPaginator(paginator, PrintHelper.GetPageSize(), pageDef);
           // ReportPaginator rp = new ReportPaginator(paginator, size, pageDef);
            ReportPaginator rp = new ReportPaginator(paginator, XpsPrintHelper.GetPageSize(), pageDef);
            
            rsm.SaveAsXaml(rp);
            
            return doc;
        }


        public ReportPaginator(DocumentPaginator paginator, Size pageSize, PageDefinition pd)
        {
            this.pageSize = pageSize;
            this.paginator = paginator;
            this.pageDef = pd;
            //decrease original page 
            paginator.PageSize = new Size(pageSize.Width - pd.Margin.Width * 2, pageSize.Height - 2 * minimalOffset - pd.HeaderHeight - pd.FooterHeight - pd.Margin.Height * 2);



        }

        public ContainerVisual getPartVisual(string template, int pageNo)
        {
            template = template.Replace("@PageNumber", (pageNo + 1).ToString());
            template = template.Replace("@PageCount", pageCount.ToString());
            Section ph = ReportEngine.createReportPart<Section>(template, null);

            FlowDocument tmpDoc = new FlowDocument();
            tmpDoc.ColumnWidth = double.PositiveInfinity;
            tmpDoc.PageWidth = paginator.PageSize.Width;

            tmpDoc.Blocks.Add(ph);
            DocumentPage dp = ((IDocumentPaginatorSource)tmpDoc).DocumentPaginator.GetPage(0);
            return (ContainerVisual)dp.Visual;

        }

        /// <summary>
        /// This is the most importan method , modifies the original 
        /// </summary>
        public override DocumentPage GetPage(int pageNumber)
        {
            DocumentPage page = paginator.GetPage(pageNumber);

            if (pageNumber == 0)
            {
                paginator.ComputePageCount();
                pageCount = paginator.PageCount;
            }

            ContainerVisual newpage = new ContainerVisual();
            if (pageDef.HeaderTemplate != null)
            {
                ContainerVisual v = getPartVisual(pageDef.HeaderTemplate, pageNumber);
                v.Offset = new Vector(pageDef.Margin.Width, pageDef.Margin.Height);
                newpage.Children.Add(v);
            }

            ContainerVisual smallerPage = new ContainerVisual();
            smallerPage.Children.Add(page.Visual);
            smallerPage.Offset = new Vector(pageDef.Margin.Width, pageDef.HeaderHeight + pageDef.Margin.Height + minimalOffset);
            newpage.Children.Add(smallerPage);

            if (pageDef.FooterTemplate != null)
            {
                ContainerVisual footer = getPartVisual(pageDef.FooterTemplate, pageNumber);
                footer.Offset = new Vector(pageDef.Margin.Width, pageSize.Height - pageDef.FooterHeight - pageDef.Margin.Height - minimalOffset);
                newpage.Children.Add(footer);
            }

            DocumentPage dp = new DocumentPage(newpage, new Size(pageSize.Width, pageSize.Height), page.BleedBox, page.ContentBox);

            return dp;

        }


        #region DefaultOverrides
        public override bool IsPageCountValid
        {
            get { return paginator.IsPageCountValid; }
        }

        public override int PageCount
        {
            get { return paginator.PageCount; }
        }

        public override Size PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }

        public override IDocumentPaginatorSource Source
        {
            get { return paginator.Source; }
        }
        #endregion


    }
}
