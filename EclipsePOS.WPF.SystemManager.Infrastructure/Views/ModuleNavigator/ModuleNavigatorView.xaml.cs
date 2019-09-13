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
using Microsoft.Practices.Composite.Regions;
using EclipsePOS.WPF.SystemManager.Infrastructure.Constants;

namespace EclipsePOS.WPF.SystemManager.Infrastructure.Views.ModuleNavigator
{
    /// <summary>
    /// Interaction logic for ModuleNavigatorView.xaml
    /// </summary>
    public partial class ModuleNavigatorView : UserControl, IModuleNavigatorView
    {
        public ModuleNavigatorView()
        {
            InitializeComponent();

            LoadResources();
            
            

        }

        private void LoadResources()
        {
            // Merge resoure directory
            base.Resources.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri(@"EclipsePOS.WPF.SystemManager.Infrastructure;;;component/Skins/BaseSkin.xaml", UriKind.Relative)));
        
        }

        public void ShowDisplay()
        {
           
        }
    }
}
