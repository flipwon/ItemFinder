/*
 * Author: Travis Tower
 * Group Project: Add Form Code
 * December 9, 2019
*/

using System;
using System.Diagnostics;
using System.Web.UI;
using System.Web.UI.WebControls;
using ItemFinder.DAL;
using ItemFinderClassLibrary;
using System.Windows.Forms;


namespace ItemFinder.User
{
    public partial class AddForm : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //Setting up Dao as well as the list of all departments
            if (!IsPostBack)
            {
                var depDao = new DepartmentDao(Properties.Settings.Default.conString);
                var dept = depDao.GetDepartments();
                dept = depDao.GetDepartments();

                //Setting the dropdown to the list of departments as well as selecting
                //a default value from the start
                foreach (Department d in dept)
                {
                    ListItem l = new ListItem(d.Name, depDao.GetDepartmentId(d.Name).ToString());
                    drpDepartment.Items.Add(l);
                }

                drpDepartment.SelectedIndex = 0;
            }
        
        }

        protected void ImgMap_OnClick(object sender, ImageClickEventArgs e)
        {
            //Get the image co-ordinates
            var coords = hidCoords.Value.Split(',');
            hidFinalCoords.Value = hidCoords.Value;

            //Offset for the image
            var x = float.Parse(coords[0]) - 13;
            var y = float.Parse(coords[1]) - 117;

            //Set the pin based on offset coords
            imgPin.Style.Add("Left", x + "px");
            imgPin.Style.Add("Top", y + "px");

            //Show the pin
            imgPin.Visible = true;

            btnAddItem.Enabled = true;
        }

        protected void btnAddItem_OnClick(object sender, EventArgs e)
        {
            //Creating a new item dao to update an existing item  in the database
            ItemDao dao = new ItemDao(Properties.Settings.Default.conString);

            if (!float.TryParse(txtPrice.Text, out float price))
                price = -1;

            Item item = new Item(int.Parse(drpDepartment.SelectedValue), TxtName.Text, 
                hidFinalCoords.Value, txtDescription.Text, price);

            //Inserting item table as well as redirecting back to the admin form
            dao.AddItem(item);

            MessageBox.Show("Item added successfully.", "Item Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Response.Redirect("/User/UserForm.aspx");
        }
    }
}