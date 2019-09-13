using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Runtime.InteropServices;

using Microsoft.Practices.Composite.Presentation.Commands;


namespace EclipsePOS.WPF.SystemManager.Infrastructure.Constants
{
    public class Commands
    {
        public static CompositeCommand ShowPosSetupTaskView = new CompositeCommand();
        public static CompositeCommand ShowInventoryTaskView = new CompositeCommand();
        public static CompositeCommand ShowDataSourceTaskView = new CompositeCommand();
        public static CompositeCommand ShowEnquiryAndReportsTaskView = new CompositeCommand();

        //Beep sound
		[DllImport("kernel32.dll")]
		public static extern bool Beep(int freq,int duration);
    }
}
