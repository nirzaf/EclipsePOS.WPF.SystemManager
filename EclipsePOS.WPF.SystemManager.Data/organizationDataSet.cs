namespace EclipsePOS.WPF.SystemManager.Data
{


	public partial class organizationDataSet
	{


		public partial class organizationDataTable
		{

			public override void EndInit()
			{
				base.EndInit();

				ColumnChanged += new System.Data.DataColumnChangeEventHandler(organizationDataTable_ColumnChanged);
				TableNewRow += new System.Data.DataTableNewRowEventHandler(organizationDataTable_TableNewRow);
			}

			void organizationDataTable_TableNewRow(object sender, System.Data.DataTableNewRowEventArgs e)
			{
				this.CheckValues(e.Row as organizationRow);
			}

			void organizationDataTable_ColumnChanged(object sender, System.Data.DataColumnChangeEventArgs e)
			{
				this.CheckValues(e.Row as organizationRow);
			}


			private void CheckValues(organizationRow row)
			{
				// Check config no
				if (row.IsNull("organization_no") || row.organization_no.Trim().Length == 0)
				{
					row.SetColumnError("organization_no", "Please enter a valid organization no");
				}
				else
				{
					row.SetColumnError("organization_no", "");
				}


				//Check Name
				if (row.IsNull("organization_name") || row.organization_name.Trim().Length == 0)
				{
					row.SetColumnError("organization_name", "Please enter organization name");
				}
				else
				{
					row.SetColumnError("organization_name", "");
				}

				//Currency code
				if (row.IsNull("home_currency") || row.home_currency.Trim().Length == 0)
				{
					row.SetColumnError("home_currency", "Please enter currency code");
				}
				else
				{
					row.SetColumnError("home_currency", "");
				}
			}

		}


	}
}
