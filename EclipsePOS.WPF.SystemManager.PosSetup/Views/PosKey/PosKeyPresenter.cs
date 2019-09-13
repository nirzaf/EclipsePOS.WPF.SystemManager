using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.PosKey
{
    public class PosKeyPresenter
    {
        private IPosKey _view;

        public IPosKey View
        {
            set
            {
                _view = value;
            }
            get
            {
                return _view;
            }
        }
    }
}
