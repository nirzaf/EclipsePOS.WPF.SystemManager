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

namespace EclipsePOS.WPF.SystemManager.Infrastructure.Views.Defaults
{
    /// <summary>
    /// Interaction logic for MainRegionView.xaml
    /// </summary>
    public partial class MainRegionView : UserControl
    {
        public MainRegionView()
        {
            InitializeComponent();
            
        }

        private void rootControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.rootControl.Height = Math.Ceiling(Application.Current.MainWindow.ActualHeight * 0.82); 
        }
    }
}
