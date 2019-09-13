using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.PosConfigInput
{
    public interface IInputConfigNoView
    {
        int ShowInputDialog();
        void SetPosConfigDataContext(IEnumerable data);
    }
}
