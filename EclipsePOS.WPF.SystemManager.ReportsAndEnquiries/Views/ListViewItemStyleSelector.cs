using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.Views
{
    public class ListViewItemStyleSelector : StyleSelector
    {

        private int i;

        public override Style SelectStyle(object item, DependencyObject container)
        {
            ItemsControl ic = ItemsControl.ItemsControlFromItemContainer(container);

            if (item == ic.Items[0])
            {
                i = 0;
            }
            string key;

            if (i % 2 == 0)
            {
                key = "LstVwItmStyle1";
            }
            else
            {
                key = "LstVwItmStyle2";
            }
            i++;

            return (Style)(ic.FindResource(key));
        }


    }
}
