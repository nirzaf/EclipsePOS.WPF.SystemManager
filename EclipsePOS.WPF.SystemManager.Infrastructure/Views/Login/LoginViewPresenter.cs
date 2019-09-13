using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EclipsePOS.WPF.SystemManager.Infrastructure.Services;


namespace EclipsePOS.WPF.SystemManager.Infrastructure.Views.Login
{
    public class LoginViewPresenter:ILoginViewPresenter
    {
        public LoginViewPresenter(ILoginView view)
        {
            View = view;
            View.LoadResources();

        }

        public ILoginView View
        {
            get;
            private set;
        }

       
        public void Show()
        {
            View.ShowLoginDialog(); 
            
        }

        
       
    }
}
