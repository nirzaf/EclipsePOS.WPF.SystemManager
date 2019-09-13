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

namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.Help
{
    /// <summary>
    /// Interaction logic for HelpView.xaml
    /// </summary>
    public partial class HelpView : UserControl, IHelpView
    {
        private HelpViewPresenter _presenter;

        public HelpView()
        {
            InitializeComponent();
            this.rootControl.SizeChanged += new SizeChangedEventHandler(rootControl_SizeChanged);
        }

        void rootControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.rootControl.Height = Math.Ceiling(Application.Current.MainWindow.ActualHeight * 0.94); 
        }
        public HelpView(HelpViewPresenter presenter)
            : this()
        {
            this._presenter = presenter;
            this._presenter.View = this;

            this.Loaded += new RoutedEventHandler(HelpView_Loaded);
        }

        void HelpView_Loaded(object sender, RoutedEventArgs e)
        {
            this.LoadResources();

           /* this.txtBlockDeptHeader.Text = Properties.Resource.HelpView_txtBlockDeptHeader;
            this.txtBlockDeptDetail.Text = Properties.Resource.HelpView_txtBlockDeptDetail;
            this.txtBlockItemGroupHeader.Text = Properties.Resource.HelpView_txtBlockItemGroupHeader;
            this.txtBlockItemGroupDetail.Text = Properties.Resource.HelpView_txtBlockItemGroupDetail;
            this.txtBlockItemListHeader.Text = Properties.Resource.HelpView_txtBlockItemListHeader;
            this.txtBlockItemListDetail.Text = Properties.Resource.HelpView_txtBlockItemListDetail;
            this.txtBlockChangeStoreGroupHeader.Text = Properties.Resource.HelpView_txtBlockDefaultStoreHeader;
            this.txtBlockChangeStoreGroupDetail.Text = Properties.Resource.HelpView_txtBlockDefaultStoreDetails;
        
            */ 
         }

        private void LoadResources()
        {
            base.Resources.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri(@"EclipsePOS.WPF.SystemManager.Infrastructure;;;component/Skins/BaseSkin.xaml", UriKind.Relative)));
        }

    }
}
