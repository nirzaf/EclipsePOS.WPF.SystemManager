using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;


namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.StartupSetting
{
    public interface ISettings
    {
        void SetOrganizationDataContext(IEnumerable data);
        void SetStoreDataContext(IEnumerable data);
        void SetStationDataContext(IEnumerable data);
        void SetPosConfigDataContext(IEnumerable data);

        void SetSaveBtnDataContext(object command);

        void SaveSettings();

        string Organization { get; set; }
        string Store { get; set; }
        int Station { get; set; }

    }
}
