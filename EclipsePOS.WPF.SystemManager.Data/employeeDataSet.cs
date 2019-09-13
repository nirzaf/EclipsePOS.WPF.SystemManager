namespace EclipsePOS.WPF.SystemManager.Data
{


	public partial class employeeDataSet
	{

		public partial class employeeDataTable
		{
			public override void EndInit()
			{
				base.EndInit();
				this.ColumnChanged += new System.Data.DataColumnChangeEventHandler(employeeDataTable_ColumnChanged);
				TableNewRow += new System.Data.DataTableNewRowEventHandler(employeeDataTable_TableNewRow);
			}

			void employeeDataTable_TableNewRow(object sender, System.Data.DataTableNewRowEventArgs e)
			{
				CheckValues(e.Row as employeeRow);
			}

			void employeeDataTable_ColumnChanged(object sender, System.Data.DataColumnChangeEventArgs e)
			{
				CheckValues(e.Row as employeeRow);
			}

			public void CheckValues(employeeRow row)
			{
				//Check employee no
				// if (row.IsNull("employee_no") || row.employee_no.Trim().Length == 0)
				// {
				//     row.SetColumnError("employee_no", "Enter employee no");
				// }
				// else
				// {
				//     row.SetColumnError("employee_no", "");
				// }

				//Logon no
				if (row.IsNull("logon_no") || row.logon_no.Length <= 2)
				{
					row.SetColumnError("logon_no", "Enter logon no");
				}
				else
				{
					row.SetColumnError("logon_no", "");
				}

				//Check logon pass
				if (row.IsNull("logon_pass") || row.logon_pass.Length <= 2)
				{
					row.SetColumnError("logon_pass", "Enter a password with at least 3 digits long");
				}
				else
				{
					row.SetColumnError("logon_pass", "");
				}

				//Check role id
				if (row.IsNull("role_id") || row.role_id.Trim().Length == 0)
				{
					row.SetColumnError("role_id", "Select an employee role");
				}
				else
				{
					row.SetColumnError("role_id", "");
				}

				//Check First Name
				if (row.IsNull("fname") || row.fname.Trim().Length == 0)
				{
					row.SetColumnError("fname", "Enter first name");
				}
				else
				{
					row.SetColumnError("fname", "");
				}

				//Check Employee no
				if (row.IsNull("employee_no") || row.employee_no.Length == 0)
				{
					row.SetColumnError("employee_no", "Enter employee no");
				}
				else
				{
					row.SetColumnError("employee_no", "");
				}


			}
		}

	}
}
