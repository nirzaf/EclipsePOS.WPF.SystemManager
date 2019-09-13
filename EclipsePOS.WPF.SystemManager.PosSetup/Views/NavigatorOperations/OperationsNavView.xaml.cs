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

namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.NavigatorOperations
{
    /// <summary>
    /// Interaction logic for OperationsNavView.xaml
    /// </summary>
    public partial class OperationsNavView : UserControl, IOperationsNavView
    {
        private OperationsNavPresenter _presenter;

        public OperationsNavView()
        {
            InitializeComponent();
            this.LoadResources();
            this.rootControl.SizeChanged += new SizeChangedEventHandler(rootControl_SizeChanged);
        }

        void rootControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
          //  this.rootControl.Height = Math.Ceiling(Application.Current.MainWindow.ActualHeight * 0.98);
        }

        public OperationsNavView(OperationsNavPresenter presnter):this()
        {
            this._presenter = presnter;
            this._presenter.View = this;
        }


        private void LoadResources()
        {
            base.Resources.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri(@"EclipsePOS.WPF.SystemManager.Infrastructure;;;component/Skins/BaseSkin.xaml", UriKind.Relative)));
        }
       

        public void SetUsersContext(ICommand command)
        {
            this.btnUsers.DataContext = command;
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

      

        public void SetCustomerContext(ICommand command)
        {
            this.btnCustomer.DataContext = command;
        }

        public void SetSurchargesContext(ICommand command)
        {
            this.btnSurcharges.DataContext = command;
        }

        public void SetCardMediaContext(ICommand command)
        {
            this.btnCardMedia.DataContext = command;
        }

    }
}
