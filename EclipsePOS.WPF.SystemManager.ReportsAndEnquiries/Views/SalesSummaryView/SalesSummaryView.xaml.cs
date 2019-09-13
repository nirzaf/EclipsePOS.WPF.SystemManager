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

namespace EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.Views.SalesSummaryView
{
    /// <summary>
    /// Interaction logic for SalesSummaryView.xaml
    /// </summary>
    public partial class SalesSummaryView : UserControl, ISalesSummaryView
    {
        private SalesSummaryViewPresenter _presenter;

        public SalesSummaryView()
        {
            InitializeComponent();
        }

        public SalesSummaryView(SalesSummaryViewPresenter presenter):this()
        {
            _presenter = presenter;
            _presenter.View = this;

            this.Loaded += new RoutedEventHandler(SalesSummaryView_Loaded);
        }

        void SalesSummaryView_Loaded(object sender, RoutedEventArgs e)
        {
            this.LoadResources();
        }

        private void LoadResources()
        {
            base.Resources.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri(@"EclipsePOS.WPF.SystemManager.Infrastructure;;;component/Skins/BaseSkin.xaml", UriKind.Relative)));
        }
    }
}
