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

namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.NavigatorOrganization
{
    /// <summary>
    /// Interaction logic for OrganizationNavView.xaml
    /// </summary>
    public partial class OrganizationNavView : UserControl, IOrganizationNavView
    {
        private OrganizationNavPresenter _prsenter;
        public OrganizationNavView()
        {
            InitializeComponent();
            this.LoadResources();
            this.rootControl.SizeChanged += new SizeChangedEventHandler(rootControl_SizeChanged);
        }

        void rootControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
           // this.rootControl.Height = Math.Ceiling(Application.Current.MainWindow.ActualHeight * 0.875);
        }

        public OrganizationNavView(OrganizationNavPresenter presenter)
            : this()
        {
            this._prsenter = presenter;
            presenter.View = this;
        }

        private void LoadResources()
        {
            base.Resources.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri(@"EclipsePOS.WPF.SystemManager.Infrastructure;;;component/Skins/BaseSkin.xaml", UriKind.Relative)));
        }


        public void SetOrganizationContext(ICommand command)
        {
            this.btnOrganization.DataContext = command;
        }

       

        public void SetStoreContext(ICommand command)
        {
            this.btnStore.DataContext = command;
        }

        public void SetStationContext(ICommand command)
        {
            this.btnStation.DataContext = command;
        }

      
        public void SetStartupSettingsContext(ICommand command)
        {
            this.btnPosStartupSettings.DataContext = command;
        }
    

        

    }
}
