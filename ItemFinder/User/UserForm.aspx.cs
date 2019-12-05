using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ItemFinder.ItemFinderDataSetTableAdapters;
using ItemFinderClassLibrary;
using ItemFinderClassLibrary.DAL;

namespace ItemFinder
{
    public partial class UserForm : System.Web.UI.Page
    {
        ItemFinderDataSet.StoreDataTable _storeDataTable = new ItemFinderDataSet.StoreDataTable();
        ItemFinderDataSet.DepartmentDataTable _departmentDataTable = new ItemFinderDataSet.DepartmentDataTable();
        ItemFinderDataSet.ItemDataTable _itemDataTable = new ItemFinderDataSet.ItemDataTable();
        ItemDao itemDao = new ItemDao(Properties.Settings.Default.conString);
        DepartmentDao departmentDao = new DepartmentDao(Properties.Settings.Default.conString);
        List<Item> items = new List<Item>();
        List<Department> departments = new List<Department>();

        ItemTableAdapter _itemTableAdapter = new ItemTableAdapter();
        ItemFinderDataSet _dataSet = new ItemFinderDataSet();

        private string location;

        protected void Page_Load(object sender, EventArgs e)
        {
            _itemTableAdapter.Fill(_dataSet.Item);
            _itemDataTable = _itemTableAdapter.GetData();
            departments = departmentDao.GetDepartments();
            items = itemDao.GetItems();
            LblName.Text = items[1].Name;
            LblDept.Text = departments[0].Name;
            if (!IsPostBack)
            {
                _itemDataTable = _itemTableAdapter.GetData();
                //var items = _itemDataTable.Rows[0].Field<string>(2); //how to get a row
            }
        }

        protected void TxtSearch_OnTextChanged(object sender, EventArgs e)
        {
            //List<Item> filteredItems = items.FindAll(item => item.Name.Contains(TxtSearch.Text));
            //LblName.Text = filteredItems[0].Name;
            //DrpSearch.DataSource = filteredItems;
            //DrpSearch.DataBind();
            //DrpSearch.SelectedIndex = 0;
        }

        protected void BtnSearch_OnClick(object sender, EventArgs e)
        {
            List<Item> filteredItems = items.FindAll(item => item.Name.ToUpper().Contains(TxtSearch.Text.ToUpper()));
            LblName.Text = filteredItems[0].Name;
            DrpSearch.DataSource = filteredItems;
            DrpSearch.DataBind();
            DrpSearch.SelectedIndex = 0;
        }


        protected void BtnAddItem_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/User/AddForm.aspx");
        }
    }
}