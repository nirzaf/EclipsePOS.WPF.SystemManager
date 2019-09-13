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
using System.Windows.Threading;

namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.ExportData
{
    /// <summary>
    /// Interaction logic for ExportDataView.xaml
    /// </summary>
    public partial class ExportDataView : Window, IExportDataView
    {
        private ExportDataPresenter _presenter;
        private int response = -1;

        public ExportDataView()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(ExportDataView_Loaded);
            this.Closing += new System.ComponentModel.CancelEventHandler(ExportDataView_Closing);

            this.txtBoxPath.Text = Properties.Settings.Default.ExportFolder;


        }

        void ExportDataView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, (DispatcherOperationCallback)delegate(object o)
            {
                Hide();
                return null;
            }, null);

        }

        public ExportDataView(ExportDataPresenter presenter)
            : this()
        {
            this._presenter = presenter;
            this._presenter.View = this;
        }

        void ExportDataView_Loaded(object sender, RoutedEventArgs e)
        {
            this.LoadResources();

            _presenter.OnShowExportDataView();
        }

        public void LoadResources()
        {
            // Merge resoure directory
            base.Resources.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri(@"EclipsePOS.WPF.SystemManager.Infrastructure;;;component/Skins/BaseSkin.xaml", UriKind.Relative)));

        }

        


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

            // e..Cancel = true;
            //work around for not being able to hide a window during closing. This behavior was needed in WPF to ensure consistent window
            //visiblity state
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, (DispatcherOperationCallback)delegate(object o)
            {
                Hide();
                return null;
            }, null);


        }

        public int ShowInputDialog()
        {

            if (this.Owner == null)
            {
                this.Owner = Application.Current.MainWindow;
            }

            this.ShowDialog();

            return response;
        }


        public void SetOKBtnDataContext(object command)
        {
            this.btnOK.DataContext = command;
        }



        public void SetFolderPickerBtnDataContext(object command)
        {
            this.btnFolderPicker.DataContext = command;
        }


        public void CloseDialog()
        {
            this.Close();
        }

        public void StartBusyIndicator()
        {
            this.busyIndicator.IsBusy = true;
        }


        public void EndBusyIndicator()
        {
            this.busyIndicator.IsBusy = false;
        }

        public string OutputFolderPath()
        {
            return this.txtBoxPath.Text.Trim();
        }

        public void SetPath(string path)
        {
            this.txtBoxPath.Text = path;
        }


    }
}
