using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ItemFinderClassLibrary;

namespace ItemFinder
{
    public partial class AdminEditForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var item = Session["Item"] as Item;
            TxtDescription.Text = item.Description;
            TxtName.Text = item.Name;
            TxtPrice.Text = item.Price.ToString();
        }

        protected void ImgMap_OnClick(object sender, ImageClickEventArgs e)
        {
            
        }
    }
}