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

namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.PosConfig
{
    /// <summary>
    /// Interaction logic for PosConfigView.xaml
    /// </summary>
    public partial class PosConfigView : UserControl, IPosConfigView
    {
        private PosConfigViewPresenter _presenter;

        public PosConfigView()
        {
            InitializeComponent();
        }

        public PosConfigView(PosConfigViewPresenter presenter)
        {
            this._presenter = presenter;
            this._presenter.View = this;

            this.Loaded += new RoutedEventHandler(PosConfigView_Loaded);
        }

        void PosConfigView_Loaded(object sender, RoutedEventArgs e)
        {
            this.LoadResources();
        }

        private void LoadResources()
        {
            base.Resources.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri(@"EclipsePOS.WPF.SystemManager.Infrastructure;;;component/Skins/BaseSkin.xaml", UriKind.Relative)));
        }


        #region Events

        public void OnPosConfigListView_SelectionChanged(object sender, RoutedEventArgs e)
        {

            object selectedItem = ((ListView)e.Source).SelectedItem;

        }


        #endregion

    }
}
