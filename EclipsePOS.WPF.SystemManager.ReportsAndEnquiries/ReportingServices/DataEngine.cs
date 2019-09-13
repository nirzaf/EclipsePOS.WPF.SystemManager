using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.ReportingServices
{
    public static class DataEngine
    {

        public static ReportData Load(IDataReader dataReader, string[] groupColumns)
        {
            DataTable tmp = new DataTable();
            for (int i = 0; i <= dataReader.FieldCount - 1; i++)
            {
                Type t = dataReader.GetFieldType(i);
                tmp.Columns.Add(dataReader.GetName(i), t);
            }

            List<GroupItem> groups = new List<GroupItem>();
            GroupItem parentGroup = null;
            for (int i = 0; i < groupColumns.Length; i++)
            {
                GroupItem g = new GroupItem(dataReader.GetOrdinal(groupColumns[i]), i, parentGroup);
                groups.Add(g);
                parentGroup = g;
            }

            GroupData reportGroup = new GroupData(-1, "Report", 0, dataReader);
            // prepare empty data buffer
            object[] rowData = new object[dataReader.FieldCount];

            int rowIndex = 0;
            while (dataReader.Read())
            {
                //update totals for a report
                reportGroup.UpdateValues(dataReader);

                //update group computes and if needed start a new group
                bool newGroup = false;
                for (int i = 0; i < groups.Count; i++)
                    newGroup = groups[i].UpdateGroupData(dataReader, rowIndex, newGroup);

                dataReader.GetValues(rowData);
                tmp.LoadDataRow(rowData, true);
                rowIndex++;
            }
            dataReader.Close();
            reportGroup.Count = tmp.Rows.Count;

            if (groups.Count > 0)
                return new ReportData(tmp, groups[0].DataGroups, reportGroup);
            else
                return new ReportData(tmp, null, reportGroup);

        }

    }
}
