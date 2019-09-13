using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EclipsePOS.WPF.SystemManager.Infrastructure.Services
{
    public interface IAuthenticationService
    {
        bool Authenticate();
       // Guid CurrentUserId { get; }
        User CurrentUser { get; }
    }
}
