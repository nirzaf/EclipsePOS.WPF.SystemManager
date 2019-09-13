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

namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.NavigatorDataSource
{
    /// <summary>
    /// Interaction logic for DataSourceNavView.xaml
    /// </summary>
    public partial class DataSourceNavView : UserControl, IDataSourceNavView
    {
        private DataSourceNavPresenter _presenter;

        public DataSourceNavView()
        {
            InitializeComponent();
            this.LoadResources();

            this.rootControl.SizeChanged += new SizeChangedEventHandler(rootControl_SizeChanged);

            this.Loaded += new RoutedEventHandler(DataSourceNavView_Loaded);

        }

        void DataSourceNavView_Loaded(object sender, RoutedEventArgs e)
        {
            _presenter.OnShowDataSorce();
        }

        void rootControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
           // this.rootControl.Height = Math.Ceiling(Application.Current.MainWindow.ActualHeight * 0.90);
        }

        public DataSourceNavView(DataSourceNavPresenter prsenter)
            : this()
        {
            this._presenter = prsenter;
            this._presenter.View = this;


        }

        private void LoadResources()
        {
            base.Resources.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri(@"EclipsePOS.WPF.SystemManager.Infrastructure;;;component/Skins/BaseSkin.xaml", UriKind.Relative)));
        }

        
       

        public void SetNewDataBaseBtnDataContext(object command)
        {
            this.btnNewDatabse.DataContext = command;
        }

        public void SetExistingDataBaseBtnDataContext(object command)
        {
            this.btnExistingDatabse.DataContext = command;
        }

        public void SetBackupDataBaseBtnDataContext(object command)
        {
            this.btnBackup.DataContext = command;
        }

        public void SetExportDataBtnDataContext(object command)
        {
            this.btnExport.DataContext = command;
        }

        public void SetImportDataBtnDataContext(object command)
        {
            this.btnImport.DataContext = command;
        }
        
       

    }
}
