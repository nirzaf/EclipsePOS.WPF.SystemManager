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


namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.DataSource
{
    /// <summary>
    /// Interaction logic for DataSourceView.xaml
    /// </summary>
    public partial class DataSourceView : UserControl, IDataSourceView
    {
        private DataSourceViewPresenter _presenter;

        public DataSourceView()
        {
            InitializeComponent();
            this.rootControl.SizeChanged += new SizeChangedEventHandler(rootControl_SizeChanged);
        }

        void rootControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.rootControl.Height = Math.Ceiling(Application.Current.MainWindow.ActualHeight * 0.90); 
        }

        public DataSourceView(DataSourceViewPresenter presenter)
            : this()
        {
            this._presenter = presenter;
            this._presenter.View = this;
            this.Loaded += new RoutedEventHandler(DataSourceView_Loaded);
        }

        void DataSourceView_Loaded(object sender, RoutedEventArgs e)
        {
            this.LoadResources();
        }

        public void LoadResources()
        {
            txtBlockWarMessage.Text = Properties.Resource.DataSourceView_txtBlockWarMessage;
            
           /* txtBlockDemoDBHeader.Text  = Properties.Resource.DataSourceView_txtBlockDemoDBHeader;
            txtBlockDemoDBDetail.Text = Properties.Resource.DataSourceView_txtBlockDemoDBDetail;
            txtBlockNewDBHeader.Text = Properties.Resource.DataSourceView_txtBlockNewDBHeader;
            txtBlockNewDBDetail.Text = Properties.Resource.DataSourceView_txtBlockNewDBDetail;
            txtBlockExistingDBHeader.Text = Properties.Resource.DataSourceView_txtBlockExistingDBHeader;
            txtBlockExistingDBDetail.Text = Properties.Resource.DataSourceView_txtBlockExistingDBDetail;
            txtBlockBackupDBDetail.Text = Properties.Resource.DataSourceView_txtBlockBackupDBDetail;
            txtBlockBackupDBHeader.Text = Properties.Resource.DataSourceView_txtBlockBackupDBHeader;
            txtBlockExportDataDetail.Text = Properties.Resource.DataSourceView_txtBlockExportDataDetail;
            txtBlockExportDataHeader.Text = Properties.Resource.DataSourceView_txtBlockExportDataHeader;
            txtBlockImportDataDetail.Text = Properties.Resource.DataSourceView_txtBlockImportDataDetail;
            txtBlockImportDataHeader.Text = Properties.Resource.DataSourceView_txtBlockImportDataHeader;
            */ 

            // Merge resoure directory
            base.Resources.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri(@"EclipsePOS.WPF.SystemManager.Infrastructure;;;component/Skins/BaseSkin.xaml", UriKind.Relative)));
        
        }

        public void SetCurrDataSourcePath(string path)
        {
            txtBlockCurrDBPath.Text = path;
        }
        /*
        public void SetDemoDataBaseBtnDataContext(object command)
        {
            this.btnDemoDatabase.DataContext = command;
        }

        public void SetNewDataBaseBtnDataContext(object command)
        {
            this.btnNewDatabase.DataContext = command;
        }

        public void SetExistingDataBaseBtnDataContext(object command)
        {
            this.btnExistingDatabase.DataContext = command;
        }

        public void SetBackupDataBaseBtnDataContext(object command)
        {
            this.btnBackupDatabase.DataContext = command;
        }
        
        public void SetExportDataBtnDataContext(object command)
        {
            this.btnExportData.DataContext = command;
        }
        
        public void SetImportDataBtnDataContext(object command)
        {
            this.btnImportData.DataContext = command;
        }
        */

    }
}
