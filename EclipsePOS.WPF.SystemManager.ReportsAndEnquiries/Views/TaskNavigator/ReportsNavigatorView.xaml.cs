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

namespace EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.Views.TaskNavigator
{
    /// <summary>
    /// Interaction logic for ReportsNavigatorView.xaml
    /// </summary>
    public partial class ReportsNavigatorView : UserControl, IReportsNavigatorView
    {
        private ReportsNavigatorPresenter _presenter;

        public ReportsNavigatorView()
        {
            InitializeComponent();
        }

        public ReportsNavigatorView(ReportsNavigatorPresenter presenter):this()
        {
            _presenter = presenter;
            _presenter.View = this;

            this.Loaded += new RoutedEventHandler(ReportsNavigatorView_Loaded);
            this.rootControl.SizeChanged += new SizeChangedEventHandler(rootControl_SizeChanged);
            
        }

        void rootControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //this.rootControl.Height = Math.Ceiling(Application.Current.MainWindow.ActualHeight * 0.785);
        }

        void ReportsNavigatorView_Loaded(object sender, RoutedEventArgs e)
        {
            this.LoadResources();
        }

        private void LoadResources()
        {
            base.Resources.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri(@"EclipsePOS.WPF.SystemManager.Infrastructure;;;component/Skins/BaseSkin.xaml", UriKind.Relative)));
        }

        public void SetDataContextSalesSummaryReportView(ICommand command)
        {
            this.btnSalesSummay.DataContext = command;
        }

        public void SetDataContextSalesDetailsByDate(ICommand command)
        {
            this.btnSalesDetail.DataContext = command;
        }

        public void SetDataContextSalesBySalesPerson(ICommand command)
        {
            this.btnSalesBySalesPerson.DataContext = command;
        }


        public void SetDataContextPaymentDetailsByDate(ICommand command)
        {
            this.btnCollectionDetail.DataContext = command;
        }

        public void SetDataContextPaymentSummary(ICommand command)
        {
            this.btnCollectionSummary.DataContext = command;
        }

        public void SetDataContextTaxDetails(ICommand command)
        {
            this.btnTaxDetail.DataContext = command;
        }

        public void SetDataContextItemLabels(ICommand command)
        {
            this.btnItemLabels.DataContext = command;
        }

        public void SetDataContextInventory(ICommand command)
        {
            this.btnCurrentInventory.DataContext = command;
        }

        public void SetDataContextInventoryDetails(ICommand command)
        {
            this.btnCurrentInventoryDetails.DataContext = command;
        }

        public void SetDataContextStockDiary(ICommand command)
        {
            this.btnStockDiary.DataContext = command;
        }

        public void SetDataContextStockDiaryDetails(ICommand command)
        {
            this.btnStockDiaryDetails.DataContext = command;
        }
    }
}
