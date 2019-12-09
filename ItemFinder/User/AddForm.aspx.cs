using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ItemFinderClassLibrary;
using ItemFinderClassLibrary.DAL;

namespace ItemFinder
{
    public partial class AddForm : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            var depDao = new DepartmentDao(Properties.Settings.Default.conString);
            var dept = depDao.GetDepartments();
            drpDepartment.DataTextField = "Name";
            drpDepartment.DataValueField = "Id";
            drpDepartment.DataSource = dept;
            drpDepartment.DataBind();
            drpDepartment.SelectedIndex = 0;
        }

        protected void ImgMap_OnClick(object sender, ImageClickEventArgs e)
        {
            //get the image coords
            var coords = hidCoords.Value.Split(',');
            hidFinalCoords.Value = hidCoords.Value;

            //offset for the image
            int x = int.Parse(coords[0]) - 13;
            int y = int.Parse(coords[1]) - 117;

            //set the pin based on offset coords
            imgPin.Style.Add("Left", x + "px");
            imgPin.Style.Add("Top", y + "px");

            //show the pin
            imgPin.Visible = true;
        }

        protected void btnAddItem_OnClick(object sender, EventArgs e)
        {
            ItemDao dao = new ItemDao(Properties.Settings.Default.conString);
            Item item = new Item(int.Parse(drpDepartment.SelectedValue), txtName.Text, hidFinalCoords.Value, txtDescription.Text,
                float.Parse(txtPrice.Text));

            dao.AddItem(item);
        }
    }
}