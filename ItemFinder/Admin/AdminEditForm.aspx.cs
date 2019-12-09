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
        DepartmentDao _departmentDao =
            new DepartmentDao(Properties.Settings.Default.conString);

        List<Department> _departments = new List<Department>();
        private string _finalLocation;
        private int _itemId;

        protected void Page_Load(object sender, EventArgs e)
        {
            _itemId = Convert.ToInt32(Session["ItemId"]);
            _departments = _departmentDao.GetDepartments();
            DrpDepartment.DataTextField = "Name";
            DrpDepartment.DataValueField = "Id";
            DrpDepartment.DataSource = _departments;
            DrpDepartment.DataBind();
            DrpDepartment.SelectedIndex = 0;
            if (!IsPostBack)
            {
                if (Session["Item"] is Item item)
                {
                    TxtDescription.Text = item.Description;
                    TxtName.Text = item.Name;
                    TxtPrice.Text = item.Price.ToString();
                }
            }
        }

        protected void ImgMap_OnClick(object sender, ImageClickEventArgs e)
        {
            //get the image coords
            var coords = hidCoords.Value.Split(',');
            _finalLocation = hidCoords.Value;

            //offset for the image
            var x = float.Parse(coords[0]) - 13;
            var y = float.Parse(coords[1]) - 21;

            //set the pin based on offset coords
            ImgPin.Style.Add("Left", x + "px");
            ImgPin.Style.Add("Top", y + "px");

            //show the pin
            ImgPin.Visible = true;
        }

        protected void BtnUpdateItem_OnClick(object sender, EventArgs e)
        {
            var dao = new ItemDao(Properties.Settings.Default.conString);
            var item = new Item(int.Parse(DrpDepartment.SelectedValue),
                TxtName.Text, hidCoords.Value, TxtDescription.Text,
                float.Parse(TxtPrice.Text));

            dao.UpdateItem(item, _itemId);
        }
    }
}