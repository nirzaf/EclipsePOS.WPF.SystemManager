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
using Microsoft.Practices.Composite.Presentation.Commands;
//using EclipsePOS.WPF.SystemManager.Infrastructure.Constants;
//using System.Windows;

namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.TaskNavigator
{
    /// <summary>
    /// Interaction logic for PosSetupTaskNavigatorView.xaml
    /// </summary>
    public partial class PosNavigatorView : UserControl, IPosNavigatorView
    {
        private PosNavigatorViewPresenter _presenter;

        // public DelegateCommand<object> ShowOrganizationCommand;// = new DelegateCommand<object>(OnShowOrganizationsCommandExecute, OnShowOrganizationsCommandCanExecute);

        public PosNavigatorView()
        {
            InitializeComponent();

        }

        public PosNavigatorView(PosNavigatorViewPresenter presenter):this()
        {
            this._presenter = presenter;

            this._presenter.View = this;
            this.Loaded += new RoutedEventHandler(PosNavigatorView_Loaded);

        }

        void PosNavigatorView_Loaded(object sender, RoutedEventArgs e)
        {
            this.LoadResources();
            //_presenter.on

        }

        private void LoadResources()
        {
            base.Resources.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri(@"EclipsePOS.WPF.SystemManager.Infrastructure;;;component/Skins/BaseSkin.xaml", UriKind.Relative)));
        }

     

        public void SetOrganizationContext(ICommand command)
        {
            this.btnOrganization.DataContext = command;
        }

        public void SetPosConfigContext(ICommand command)
        {
            this.btnPosConfig.DataContext = command;
        }
        
        public void SetUsersContext(ICommand command)
        {
            this.btnUsers.DataContext = command;
        }

        public void SetStoreContext(ICommand command)
        {
            this.btnStore.DataContext = command;
        }

        public void SetStationContext(ICommand command)
        {
            this.btnStation.DataContext = command;
        }

        public void SetPosParamContext(ICommand command)
        {
            this.btnPosParams.DataContext = command;
        }

        public void SetEmployeeRolesContext(ICommand command)
        {
            this.btnEmployeeRoles.DataContext = command;
        }

        public void SetEmployeeContext(ICommand command)
        {
            this.btnEmployees.DataContext = command;
        }

        public void SetPromotionContext(ICommand command)
        {
            this.btnPromotions.DataContext = command;
        }

        public void SetMenuRootContext(ICommand command)
        {
            this.btnMenuRoot.DataContext = command;
        }
        
        public void SetPosWorkbenchContext(ICommand command)
        {
            //this.btnPosWorkBench.DataContext = command;
        }
        
        public void SetTableGroupContext(ICommand command)
        {
            this.btnTableGroup.DataContext = command;
        }
       
        public void SetTableContext(ICommand command)
        {
            this.btnTable.DataContext = command;
        }
       

        public void SetTaxGroupContext(ICommand command)
        {
            this.btnTaxGroups.DataContext = command;
        }

        public void SetTaxContext(ICommand command)
        {
            this.btnTax.DataContext = command;
        }

        public void SetCurrencyCodeContext(ICommand command)
        {
            this.btnCurrencyCode.DataContext = command;
        }

        public void SetCurrencyRateContext(ICommand command)
        {
            this.btnCurrencyRate.DataContext = command;
        }

        public void SetDataSourceContext(ICommand command)
        {
            this.btnManageDataSource.DataContext = command;
        }

        public void SetStartupSettingsContext(ICommand command)
        {
            this.btnPosStartupSettings.DataContext = command;
        }

        public void SetCustomerContext(ICommand command)
        {
            this.btnCustomer.DataContext = command;
        }
    }
}
