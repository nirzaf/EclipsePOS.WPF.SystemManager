using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EclipsePOS.WPF.SystemManager.Infrastructure.Services
{
    public class User
    { 
        private string userName;
        private string password;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

       // private Guid id;

       //         public Guid Id
       // {
       //     get { return id; }
       //     set { id = value; }
       // }

        

      //  public User(string userName, Guid id)
      //  {
      //      UserName = userName;
      //      Id = id;
      //      
      //  }

        public User()
        {
            UserName = null;
           
        }


    }
}
