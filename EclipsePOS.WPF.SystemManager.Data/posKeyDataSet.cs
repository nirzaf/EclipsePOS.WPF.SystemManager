namespace EclipsePOS.WPF.SystemManager.Data
{


	public partial class posKeyDataSet
	{
		public partial class pos_keyDataTable
		{
			public override void EndInit()
			{
				base.EndInit();
				this.ColumnChanged += new System.Data.DataColumnChangeEventHandler(pos_keyDataTable_ColumnChanged);
				this.TableNewRow += new System.Data.DataTableNewRowEventHandler(pos_keyDataTable_TableNewRow);
			}

			void pos_keyDataTable_TableNewRow(object sender, System.Data.DataTableNewRowEventArgs e)
			{
				this.CheckValues(e.Row as pos_keyRow);
			}

			void pos_keyDataTable_ColumnChanged(object sender, System.Data.DataColumnChangeEventArgs e)
			{
				this.CheckValues(e.Row as pos_keyRow);
			}

			public void CheckValues(pos_keyRow row)
			{
				//Check image
				if (row.IsNull("image") || row.image.Trim().Length == 0)
				{
					row.SetColumnError("image", "Enter key text 2");
				}
				else
				{
					row.SetColumnError("image", "");
				}

				//key class
				if (row.IsNull("key_class") || row.key_class.Trim().Length == 0)
				{
					row.SetColumnError("key_class", "Enter key class");
				}
				else
				{
					row.SetColumnError("key_class", "");
				}

				//Check key code
				if (row.IsNull("key_code") || row.key_code <= 0)
				{
					row.SetColumnError("key_code", "Enter key code");
				}
				else
				{
					row.SetColumnError("key_code", "");
				}

				//Check key text
				if (row.IsNull("key_text") || row.key_text.Trim().Length == 0)
				{
					row.SetColumnError("key_text", "Enter key text 1");
				}
				else
				{
					row.SetColumnError("key_text", "");
				}

				//Check key value
				// if (row.IsNull("key_val") || row.key_val <= 0)
				// {
				//     row.SetColumnError("key_val", "Enter key value");
				// }
				// else
				// {
				//    row.SetColumnError("key_val", "");
				// }

				//Check param
				if (row.IsNull("param") || row.param.Trim().Length == 0)
				{
					row.SetColumnError("param", "Enter function text");
				}
				else
				{
					row.SetColumnError("param", "");
				}


				//Check attr
				if (row.IsNull("attr") || row.attr == 0)
				{
					row.SetColumnError("attr", "Select access key value");
				}
				else
				{
					row.SetColumnError("attr", "");
				}



			}

		}
	}
}
