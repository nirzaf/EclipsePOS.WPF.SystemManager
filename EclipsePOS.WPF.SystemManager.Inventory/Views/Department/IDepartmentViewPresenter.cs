﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EclipsePOS.WPF.SystemManager.Inventory.Views.Department
{
    public interface IDepartmentViewPresenter
    {
        IDepartmentView View { set; get; } 
    }
}