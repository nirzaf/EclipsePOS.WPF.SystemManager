using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EclipsePOS.WPF.SystemManager.Data;

namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.PosConfigInput
{
    public class InputConfigNoPresenter
    {
        private IInputConfigNoView _view;
        private EclipsePOS.WPF.SystemManager.Data.posConfigDataSet posConfigData;

        public IInputConfigNoView View
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

        public void OnShowInputConfigNo()
        {
            //PosConfig
            posConfigData = new EclipsePOS.WPF.SystemManager.Data.posConfigDataSet();
            EclipsePOS.WPF.SystemManager.Data.posConfigDataSetTableAdapters.pos_configTableAdapter posConfigTa = new EclipsePOS.WPF.SystemManager.Data.posConfigDataSetTableAdapters.pos_configTableAdapter();
            posConfigTa.Fill(posConfigData.pos_config);
            View.SetPosConfigDataContext(posConfigData.pos_config);

        }

    }
}
