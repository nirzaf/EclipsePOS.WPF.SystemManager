using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EclipsePOS.WPF.SystemManager.Inventory.Views.Help
{
    public class HelpViewPresenter
    {
        private IHelpView _view;

        public IHelpView View
        {
            get
            {
                return _view;
            }
            set
            {
                _view = value;
            }
        }


    }
}
