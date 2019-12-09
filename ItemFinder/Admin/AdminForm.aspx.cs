using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Design;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ItemFinderClassLibrary;
using ItemFinderClassLibrary.DAL;

namespace ItemFinder
{
    public partial class AdminForm : System.Web.UI.Page
    {
        private readonly ItemDao _itemDao = new ItemDao(Properties.Settings.Default.conString);
        private DataTable _itemDataTable = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        protected void GrdCourse_OnSorting(object sender, GridViewSortEventArgs e)
        {
            LoadData();

            //Sorting the GridView based on the column the user selected
            _itemDataTable.DefaultView.Sort = e.SortExpression;
            GrdAdmin.DataSource = _itemDataTable;
            GrdAdmin.DataBind();
        }

        protected void BtnUpdate_OnClick(object sender, EventArgs e)
        {
            GridViewRow currentRow = (GridViewRow)(((Button)sender)).NamingContainer;
            var id = int.Parse(((HiddenField)GrdAdmin.Rows[currentRow.RowIndex].FindControl("ItemId")).Value);
            Item item = _itemDao.GetItem(id);
            Session["Item"] = item;
            Response.Redirect("AdminEditForm.aspx");
        }

        protected void LoadData()
        {
            //Setting up the GridView based on the DataTable
            _itemDataTable = _itemDao.PullAllData();
            GrdAdmin.DataSource = _itemDataTable;
            GrdAdmin.DataBind();
        }
    }
}