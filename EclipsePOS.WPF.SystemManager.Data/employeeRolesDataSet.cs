namespace EclipsePOS.WPF.SystemManager.Data
{


	public partial class employeeRolesDataSet
	{


		public partial class employee_rolesDataTable
		{
			public override void EndInit()
			{
				base.EndInit();
				ColumnChanged += new System.Data.DataColumnChangeEventHandler(employee_rolesDataTable_ColumnChanged);
				TableNewRow += new System.Data.DataTableNewRowEventHandler(employee_rolesDataTable_TableNewRow);
			}

			void employee_rolesDataTable_TableNewRow(object sender, System.Data.DataTableNewRowEventArgs e)
			{
				CheckValues(e.Row as employee_rolesRow);
			}

			void employee_rolesDataTable_ColumnChanged(object sender, System.Data.DataColumnChangeEventArgs e)
			{
				CheckValues(e.Row as employee_rolesRow);
			}

			public void CheckValues(employee_rolesRow row)
			{
				//Check role name
				if (row.IsNull("role_name") || row.role_name.Trim().Length == 0)
				{
					row.SetColumnError("role_name", "Enter role name");
				}
				else
				{
					row.SetColumnError("role_name", "");
				}

				//Check role name
				if (row.IsNull("role_id") || row.role_id.Trim().Length == 0 || string.Equals(row.role_id.Trim(), "-1"))
				{
					row.SetColumnError("role_id", "Enter role id");
				}
				else
				{
					row.SetColumnError("role_id", "");
				}
			}


		}
	}
}
