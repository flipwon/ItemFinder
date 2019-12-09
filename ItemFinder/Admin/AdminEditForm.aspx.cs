using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ItemFinderClassLibrary;
using ItemFinderClassLibrary.DAL;

namespace ItemFinder
{
    public partial class AdminEditForm : System.Web.UI.Page
    {
        DepartmentDao _departmentDao = new DepartmentDao(Properties.Settings.Default.conString);
        List<Department> _departments = new List<Department>();
        protected void Page_Load(object sender, EventArgs e)
        {
            _departments = _departmentDao.GetDepartments();
            DrpDepartment.DataTextField = "Name";
            DrpDepartment.DataValueField = "Id";
            DrpDepartment.DataSource = _departments;
            DrpDepartment.DataBind();
            DrpDepartment.SelectedIndex = 0;
            if (Session["Item"] is Item item)
            {
                TxtDescription.Text = item.Description;
                TxtName.Text = item.Name;
                TxtPrice.Text = item.Price.ToString();
            }
        }

        protected void ImgMap_OnClick(object sender, ImageClickEventArgs e)
        {
            
        }
    }
}