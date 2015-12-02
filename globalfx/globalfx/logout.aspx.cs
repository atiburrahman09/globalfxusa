using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

using System.Web.UI.WebControls;
using Lumex.Tech;

namespace globalfx
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                LumexSessionManager.RemoveAll();
                Response.Redirect("/login.aspx");
            }
            catch (Exception)
            {
                
                //throw;
            }

        }
    }
}