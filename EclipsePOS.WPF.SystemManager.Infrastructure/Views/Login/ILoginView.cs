using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace EclipsePOS.WPF.SystemManager.Infrastructure.Views.Login
{
    public interface ILoginView
    {
        void ShowMessage(string message);

        void LoadResources();

        void ShowLoginDialog();

    }
}
