namespace EclipsePOS.WPF.SystemManager.Data
{


	public partial class surchargeDataSet
	{
		partial class surchargeDataTable
		{

			public override void EndInit()
			{
				base.EndInit();
				this.ColumnChanged += new System.Data.DataColumnChangeEventHandler(surchargeDataTable_ColumnChanged);
				this.TableNewRow += new System.Data.DataTableNewRowEventHandler(surchargeDataTable_TableNewRow);
			}

			void surchargeDataTable_TableNewRow(object sender, System.Data.DataTableNewRowEventArgs e)
			{
				this.CheckValues(e.Row as surchargeRow);
			}

			void surchargeDataTable_ColumnChanged(object sender, System.Data.DataColumnChangeEventArgs e)
			{
				this.CheckValues(e.Row as surchargeRow);
			}

			public void CheckValues(surchargeRow row)
			{

				if (row.IsNull("surcharge_code") || row.surcharge_code.Trim().Length == 0)
				{
					row.SetColumnError("surcharge_code", "Enter surcharge code");
				}
				else
				{
					row.SetColumnError("surcharge_code", "");
				}


				if (row.IsNull("surcharge_desc") || row.surcharge_desc.Trim().Length == 0)
				{
					row.SetColumnError("surcharge_desc", "Enter surcharge desc");
				}
				else
				{
					row.SetColumnError("surcharge_desc", "");
				}

				if (row.IsNull("amount") || row.amount <= 0)
				{
					row.SetColumnError("amount", "Enter amount");
				}
				else
				{
					row.SetColumnError("amount", "");
				}


				if (row.IsNull("surcharge_key_id") || row.surcharge_key_id == 0)
				{
					row.SetColumnError("surcharge_key_id", "Enter surcharge key number");
				}
				else
				{
					row.SetColumnError("surcharge_key_id", "");
				}


				if (row.IsNull("tax_group_id") || row.tax_group_id.Trim().Length == 0)
				{
					row.SetColumnError("tax_group_id", "Enter tax group");
				}
				else
				{
					row.SetColumnError("tax_group_id", "");
				}


			}
		}
	}
}
