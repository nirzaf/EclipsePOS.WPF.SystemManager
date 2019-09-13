using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;


namespace EclipsePOS.WPF.SystemManager.Infrastructure.Services
{
    public class AuthenticationService:IAuthenticationService
    {
        
      //  private ILoginViewPresenter _loginPresenter = null;
      //  private Guid _currentUserId;
        private User _currentUser;
        private IUnityContainer _container;

        public AuthenticationService(IUnityContainer container)
        {
           // this._loginPresenter = loginPresenter;
            this._container = container;
        }

        

        public bool IsAuthenticated()
        {
            if (_currentUser == null)
                return false;
            else
                return true;
        }

        #region IAuthenticationService Members

        public bool Authenticate() 
        {
            _currentUser = _container.Resolve<User>();

           if (String.IsNullOrEmpty (_currentUser.UserName) ) 
           {
               ILoginViewPresenter _loginPresenter = _container.Resolve<ILoginViewPresenter>();
                _loginPresenter.Show();
           
           }
           
            bool isAuthenticated = false;
            _currentUser = _container.Resolve<User>();
            
            if (!String.IsNullOrEmpty(_currentUser.UserName))
            {
                isAuthenticated = true;
            }
           
            return isAuthenticated;
             
        }

           
        public User CurrentUser
        {
            get { return _currentUser; }
        }


        #endregion
    }
}
