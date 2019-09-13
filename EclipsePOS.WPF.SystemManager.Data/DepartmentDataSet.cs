namespace EclipsePOS.WPF.SystemManager.Data
{


	public partial class DepartmentDataSet
	{


		public partial class departmentDataTable
		{
			public override void EndInit()
			{
				base.EndInit();

				ColumnChanged += new System.Data.DataColumnChangeEventHandler(departmentDataTable_ColumnChanged);
				TableNewRow += new System.Data.DataTableNewRowEventHandler(departmentDataTable_TableNewRow);
			}

			void departmentDataTable_TableNewRow(object sender, System.Data.DataTableNewRowEventArgs e)
			{
				this.CheckValues(e.Row as departmentRow);
			}

			void departmentDataTable_ColumnChanged(object sender, System.Data.DataColumnChangeEventArgs e)
			{
				this.CheckValues(e.Row as departmentRow);
			}


			private void CheckValues(departmentRow row)
			{
				// Check department_id
				if (row.IsNull("department_id") || row.department_id.Trim().Length == 0)
				{
					row.SetColumnError("department_id", "Please enter department id");
				}
				else
				{
					row.SetColumnError("department_id", "");
				}


				//Check department Name
				if (row.IsNull("department_name") || row.department_name.Trim().Length == 0)
				{
					row.SetColumnError("department_name", "Please enter department name");
				}
				else
				{
					row.SetColumnError("department_name", "");
				}
			}


		}
	}
}

namespace EclipsePOS.WPF.SystemManager.Data.DepartmentDataSetTableAdapters {
    
    
    public partial class departmentTableAdapter {
    }
}
