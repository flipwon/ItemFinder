using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ItemFinder.ItemFinderDataSetTableAdapters;

namespace ItemFinder
{
    public partial class UserForm : System.Web.UI.Page
    {
        ItemFinderDataSet.StoreDataTable _storeDataTable = new ItemFinderDataSet.StoreDataTable();
        ItemFinderDataSet.DepartmentDataTable _departmentDataTable = new ItemFinderDataSet.DepartmentDataTable();
        ItemFinderDataSet.ItemDataTable _itemDataTable = new ItemFinderDataSet.ItemDataTable();


        ItemTableAdapter _itemTableAdapter = new ItemTableAdapter();
        ItemFinderDataSet _dataSet = new ItemFinderDataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            _itemTableAdapter.Fill(_dataSet.Item);
            _itemDataTable = _itemTableAdapter.GetData();

            if (!IsPostBack)
            {
                _itemDataTable = _itemTableAdapter.GetData();
                //var items = _itemDataTable.Rows[0].Field<string>(2); //how to get a row
            }
        }

        protected void TxtSearch_OnTextChanged(object sender, EventArgs e)
        {
            var searchString = TxtSearch.Text;
            var filtered = _itemDataTable.AsEnumerable()
                .Where(r => r.Field<string>("ItemName").Contains(searchString));

            var filteredList = filtered.ToList();

            LblName.Text = filteredList.Count > 0 ? filteredList[0].ItemName : "";
        }
    }
}