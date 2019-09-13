using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.PosKey
{
    public interface IPosKey
    {
        void SetDataContext(object data);
        void SetFocusToFirstElement();
    }
}
