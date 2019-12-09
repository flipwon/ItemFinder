using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ItemFinderClassLibrary.Logic;

namespace ItemFinder.Admin
{
    public partial class AdminRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnRegister_OnClick(object sender, EventArgs e)
        {
            UserDao dao = new UserDao();

            (int, int) result = dao.AddRecord(TxtUser.Text, TxtPassword.Text, DrpRole.SelectedValue);
            LblStatus.Text = "User ID: " + result.Item1 + "Count: " + result.Item2;
            
            if (result.Item2 > 0)
                Response.Redirect("/Login.aspx");
        }

        protected void BtnLogin_OnClick(object sender, EventArgs e)
        {
            bool result = LoginHelper.IsUserAuthentic(TxtUser.Text, TxtPassword.Text);

            LblStatus.Text = result ? "Authenticated" : "Not Authenticated";
        }
    }
}