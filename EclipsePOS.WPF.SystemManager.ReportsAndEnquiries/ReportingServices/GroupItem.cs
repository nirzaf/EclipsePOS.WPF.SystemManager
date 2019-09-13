using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Markup;

[assembly: XmlnsDefinition("http://www.eclipse_software.com.sg/WPF", "EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.ReportingServices")]
namespace EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.ReportingServices
{
    public class GroupItem
    {
        int ordinal;
        int level;

        GroupItem upperGroup;
        public GroupItem(int ordinal, int level, GroupItem upperGroup)
        {
            this.ordinal = ordinal;
            this.upperGroup = upperGroup;
            this.level = level;
        }

        string lastKey = "DUMMYKEY";
        GroupData currentDataGroup;

        //currently usefull only for root group level
        List<GroupData> dataGroups = new List<GroupData>();

        /// <summary>
        /// The datag for this group level
        /// </summary>
        public List<GroupData> DataGroups
        {
            get { return dataGroups; }
        }

        public void AddChildDataGroup(GroupData gData)
        {
            this.currentDataGroup.NestedDataGroups.Add(gData);
        }

        /// <summary>
        /// If the grouping key value is changed or parent group is new new Group data is created. 
        /// The calculated values are always updated
        /// </summary>
        public bool UpdateGroupData(IDataReader reader, int rowIndex, bool forceNewGroup)
        {
            bool newGroup = false;
            string newKey = reader.GetValue(ordinal).ToString();
            if (forceNewGroup || newKey != lastKey)
            {
                lastKey = newKey;
                currentDataGroup = new GroupData(level, newKey, rowIndex, reader);
                newGroup = true;
                this.dataGroups.Add(currentDataGroup);
                if (this.upperGroup != null)
                    upperGroup.AddChildDataGroup(currentDataGroup);
            }
            currentDataGroup.UpdateValues(reader);
            return newGroup;
        }

    }
}
