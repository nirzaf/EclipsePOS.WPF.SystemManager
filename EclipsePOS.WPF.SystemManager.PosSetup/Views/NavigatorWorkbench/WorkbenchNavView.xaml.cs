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

namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.NavigatorWorkbench
{
    /// <summary>
    /// Interaction logic for WorkbenchNavView.xaml
    /// </summary>
    public partial class WorkbenchNavView : UserControl, IWorkbenchNavView
    {
        private WorkbenchNavPresenter _presenter;

        public WorkbenchNavView()
        {
            InitializeComponent();
            this.LoadResources();
            this.rootControl.SizeChanged += new SizeChangedEventHandler(rootControl_SizeChanged);
        }

        void rootControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
          //  this.rootControl.Height = Math.Ceiling(Application.Current.MainWindow.ActualHeight * 0.98);
        }

        public WorkbenchNavView(WorkbenchNavPresenter presenter)
            : this()
        {
            this._presenter = presenter;
            this._presenter.View = this;

        }


        private void LoadResources()
        {
            base.Resources.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri(@"EclipsePOS.WPF.SystemManager.Infrastructure;;;component/Skins/BaseSkin.xaml", UriKind.Relative)));
        }


        public void SetPosConfigContext(ICommand command)
        {
            this.btnPosConfig.DataContext = command;
        }

  


        public void SetPosParamContext(ICommand command)
        {
            this.btnPosParams.DataContext = command;
        }

       

        public void SetMenuRootContext(ICommand command)
        {
            this.btnMenuRoot.DataContext = command;
        }

        public void SetStartPosContext(ICommand command)
        {
            this.btnStartPos.DataContext = command;
        }

       

     //   public void SetStartupSettingsContext(ICommand command)
     //   {
     //       this.btnPosStartupSettings.DataContext = command;
     //   }

       

    }
}
