using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
        ItemDao itemDao = new ItemDao(Properties.Settings.Default.conString);
        DepartmentDao departmentDao = new DepartmentDao(Properties.Settings.Default.conString);
        List<Item> items = new List<Item>();
        List<Department> departments = new List<Department>();

        private string location;

        protected void Page_Load(object sender, EventArgs e)
        {
            departments = departmentDao.GetDepartments();
            items = itemDao.GetItems();
            if (!IsPostBack)
            {
                
            }
        }

        protected void TxtSearch_OnTextChanged(object sender, EventArgs e)
        {
            LblName.Visible = false;
            LblDept.Visible = false;
            LblDesc.Visible = false;
            LblPrice.Visible = false;

            List<Item> filteredItems = items.FindAll(item => item.Name.ToUpper().Contains(TxtSearch.Text.ToUpper()));
            LblName.Text = filteredItems[0].Name;
            DrpSearch.DataTextField = "Name";
            DrpSearch.DataValueField = "Name";
            DrpSearch.DataSource = filteredItems;
            DrpSearch.DataBind();
            DrpSearch.SelectedIndex = 0;
            LblName.Text = DrpSearch.SelectedValue;
        }

        protected void BtnSearch_OnClick(object sender, EventArgs e)
        {
            LblName.Visible = true;
            LblDept.Visible = true;
            LblDesc.Visible = true;
            LblPrice.Visible = true;
            Item selectedItem = items.Find(item =>
                item.Name.ToUpper().Contains(DrpSearch.SelectedValue.ToUpper()));
            Department selectedDepartment =
                departments.Find(d => d.Id == selectedItem.DepartmentId);
            LblName.Text = $"Item Name: {selectedItem.Name}";
            LblDept.Text = $"Department Name: {selectedDepartment.Name}";
            LblDesc.Text = $"Item Description: {selectedItem.Description}";
            LblPrice.Text = $"Item Price: ${selectedItem.Price}";
            SetPin(selectedItem.Location);
        }


        protected void BtnAddItem_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/User/AddForm.aspx");
        }

        void SetPin(string coordString)
        {

            //get the image coords
            var coords = coordString.Split(',');
            hidFinalCoords.Value = hidCoords.Value;
            Debug.WriteLine(coords[0] + "," + coords[1]);
            //offset for the image
            float x = float.Parse(coords[0]) - 13;
            float y = float.Parse(coords[1]) - 21;

            //set the pin based on offset coords
            imgPin.Style.Add("Left", x + "px");
            imgPin.Style.Add("Top", y + "px");

            //show the pin
            imgPin.Visible = true;
        }
    }
}