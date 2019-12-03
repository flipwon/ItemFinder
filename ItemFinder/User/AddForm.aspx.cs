using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ItemFinder
{
    public partial class AddForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ImgMap_OnClick(object sender, ImageClickEventArgs e)
        {
            //set the location labels
            lblTestCoord.Text = hidCoords.Value;
        }
    }
}