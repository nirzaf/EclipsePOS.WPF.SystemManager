using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EclipsePOS.WPF.SystemManager.Inventory.Views.Plu
{
    class PluViewPresenter
    {
        private IPluView _view;


        public PluViewPresenter()
        {
        }

        public PluViewPresenter(IPluView view):this()
        {
        }

        public IPluView View
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
