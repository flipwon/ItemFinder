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


        protected void Page_Load(object sender, EventArgs e)
        {
            departments = departmentDao.GetDepartments();
            items = itemDao.GetItems();
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
                departments.Find(d => d.StoreId == selectedItem.DepartmentId);
            LblName.Text = selectedItem.Name;
            LblDept.Text = selectedDepartment.Name;

            if (!string.IsNullOrEmpty(selectedItem.Description))
                LblDesc.Text = selectedItem.Description;
            else
                LblDesc.Text = "-";
            
            if (selectedItem.Price != -1)
                LblPrice.Text = selectedItem.Price.ToString();
            else
                LblPrice.Text = "-";

            SetPin(selectedItem.Location);
        }


        void SetPin(string coordString)
        {

            //get the image coords
            var coords = coordString.Split(',');
            hidFinalCoords.Value = hidCoords.Value;
            Debug.WriteLine(coords[0] + "," + coords[1]);
            //offset for the image
            float x = float.Parse(coords[0]) - 13;
            float y = float.Parse(coords[1]) - 117;

            //set the pin based on offset coords
            imgPin.Style.Add("Left", x + "px");
            imgPin.Style.Add("Top", y + "px");

            //show the pin
            imgPin.Visible = true;
        }
    }
}