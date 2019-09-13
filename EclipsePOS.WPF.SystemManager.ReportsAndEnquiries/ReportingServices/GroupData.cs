using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Markup;
using System.Windows;

[assembly: XmlnsDefinition("http://www.eclipse_software.com.sg/WPF", "EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.ReportingServices")]
namespace EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.ReportingServices
{
    public class GroupData
    {

        int level;

        /// <summary>
        /// The level in a group hierarchy 
        /// </summary>
        public int Level
        {
            get { return level; }
        }

        private List<GroupData> nestedDataGroups;

        /// <summary>
        /// Inner data group's.
        /// </summary>
        public List<GroupData> NestedDataGroups
        {
            get
            {
                if (nestedDataGroups == null)
                    nestedDataGroups = new List<GroupData>();

                return nestedDataGroups;
            }
        }


        string key;

        /// <summary>
        /// The grouping key value for this data group.
        /// </summary>
        public string Key
        {
            get { return key; }
        }

        int count;
        /// <summary>
        /// Holds the number of rows in a group
        /// </summary>
        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        int startRow;

        /// <summary>
        /// Pointer to a starting row for this group data in a Datatable
        /// </summary>
        public int StartRow
        {
            get { return startRow; }
        }

        public bool HasNestedGroups
        {
            get { return (nestedDataGroups != null && nestedDataGroups.Count > 0); }
        }

        Dictionary<string, ComputeField> computes = new Dictionary<string, ComputeField>();

        /// <summary>
        /// Initializes the fields and local computes
        /// </summary>
        public GroupData(int level, string key, int startRow, IDataReader dataReader)
        {
            this.level = level;
            this.startRow = startRow;
            this.key = key;

            //For demo purposes I will aggregate all (and only) decimal fields
            for (int i = 0; i <= dataReader.FieldCount - 1; i++)
            {
                //MessageBox.Show(dataReader.GetName(i)+"@"+dataReader.GetFieldType(i).ToString() );
                Type t = dataReader.GetFieldType(i);
                if (t == typeof(decimal))
                    computes.Add(dataReader.GetName(i), new DecimalAggregateField(i));
                if (t == typeof(double))
                    computes.Add(dataReader.GetName(i), new DoubleAggregateField(i));


            }

            
        }

        /// <summary>
        /// Used during report rendering phase and  not for calculations 
        /// </summary>
        public object GetComputedValue(string name)
        {
            if (computes.ContainsKey(name))
            {
                ComputeField compField = computes[name] as ComputeField;
                return compField.Value;
            }
            return key;
        }

        /// <summary>
        /// Updates calculated values for each compute field
        /// </summary>
        /// <param name="dataReader"></param>
        public void UpdateValues(IDataReader dataReader)
        {
            count++;
            foreach (ComputeField cf in computes.Values)
                cf.UpdateValue(dataReader);
        }

    }
}
