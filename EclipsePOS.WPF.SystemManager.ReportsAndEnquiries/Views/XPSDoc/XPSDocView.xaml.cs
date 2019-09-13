using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Xps.Packaging;



namespace EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.Views.XPSDoc
{
    /// <summary>
    /// Interaction logic for XPSDocView.xaml
    /// </summary>
    public partial class XPSDocView : UserControl, IXPSDocView
    {
        private XPSDocViewPresenter _presenter;

        public XPSDocView()
        {
            InitializeComponent();
            this.rootControl.SizeChanged += new SizeChangedEventHandler(rootControl_SizeChanged);
        }

        void rootControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.rootControl.Height = Math.Ceiling(Application.Current.MainWindow.ActualHeight * 0.82); 
        }

        public XPSDocView(XPSDocViewPresenter presenter)
            : this()
        {
            this._presenter = presenter;
            this._presenter.View = this;
            this.Loaded += new RoutedEventHandler(XPSDocView_Loaded);
            //this.documentViewer.
        }

        void XPSDocView_Loaded(object sender, RoutedEventArgs e)
        {
            this.LoadResources();
            this._presenter.OnShowXPSDoc();
        }

        private void LoadResources()
        {
            base.Resources.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri(@"EclipsePOS.WPF.SystemManager.Infrastructure;;;component/Skins/BaseSkin.xaml", UriKind.Relative)));
        }

        public void DisplayDoc(XpsDocument doc)
        {
            if (doc != null)
            {
                this.documentViewer.Document = doc.GetFixedDocumentSequence();
                
            }
            else
            {
                MessageBox.Show("Null document received");
            }

            
        }

      



        public void DisplayDoc(IDocumentPaginatorSource document)
        {
            this.documentViewer.Document = document;
        }

        public void SetSaveToDiskBtnDataContext(object command)
        {
            this.btnSaveToDisk.DataContext = command;
        }


        public DocumentViewer GetDocument
        {
            get
            {
             return this.documentViewer;
            }
        }
       
    }
}
