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

namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.PosParam
{
    /// <summary>
    /// Interaction logic for PosParmView.xaml
    /// </summary>
    public partial class PosParmView : UserControl, IPosParam
    {
        private PosParmPresenter _presenter;

        public PosParmView()
        {
            InitializeComponent();
        }

        public PosParmView(PosParmPresenter presenter)
            : this()
        {
            this._presenter = presenter;

            this.Loaded += new RoutedEventHandler(PosParmView_Loaded);

        }

        void PosParmView_Loaded(object sender, RoutedEventArgs e)
        {
            this.LoadResources();
            
        }

        private void LoadResources()
        {
            base.Resources.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri(@"EclipsePOS.WPF.SystemManager.Infrastructure;;;component/Skins/BaseSkin.xaml", UriKind.Relative)));
        }

    }
}
