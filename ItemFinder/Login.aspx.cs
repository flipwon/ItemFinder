using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using ItemFinderClassLibrary.Logic;

namespace ItemFinder
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_OnClick(object sender, EventArgs e)
        {
            LblError.Visible = false;
            string userName = TxtUserName.Text;
            string password = TxtPassword.Text;

            if (LoginHelper.IsUserAuthentic(userName, password))
            {
                string roles = LoginHelper.GetUserRole(userName);
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, userName, DateTime.Now,
                    DateTime.Now.AddMinutes(10), false, roles);
                string strTicket = FormsAuthentication.Encrypt(ticket);
                Response.Cookies.Add(new System.Web.HttpCookie(FormsAuthentication.FormsCookieName, strTicket));
                Response.Redirect(FormsAuthentication.GetRedirectUrl(userName, false));
            }
            else
            {
                LblError.Visible = true;
                LblError.Text = "Incorrect user and/or password!";
            }
        }
    }
}