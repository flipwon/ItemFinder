using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ItemFinder
{
    public partial class ItemFinder : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Checking to see what the users role is, and if it isn't admin, than
            //the user wont have access to the admin dashboard hyperlink
            if (Session["role"] == null)
            {
                HypAdminDash.Visible = false;
                HypAdminReg.Visible = false;

            }
            else if (Session["role"].ToString().Equals("Admin"))
            {
                HypAdminDash.Visible = true;
                HypAdminReg.Visible = true;
            }
            else
            {
                HypAdminDash.Visible = false;
                HypAdminReg.Visible = false;
            }
        }

        protected void LnkLogout_OnClick(object sender, EventArgs e)
        {
            //Resetting the session variable as well as logging out the current user
            Session["role"] = "";
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }
    }
}