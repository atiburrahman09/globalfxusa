﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Global.Core;
using Global.Core.BLL;
using Lumex.Tech;

namespace globalfx
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = GetNewsFeedData();
            rptrNewsFeed.DataSource = dt;
            rptrNewsFeed.DataBind();
        }

        private DataTable GetNewsFeedData()
        {
            DataTable dt = new DataTable();
            NewsFeedBLL newsFeedBll = new NewsFeedBLL();
            try
            {

                dt = newsFeedBll.GetNewsFeedList();
                if (dt.Rows.Count > 0)
                {
                    rptrNewsFeed.DataSource = dt;
                    rptrNewsFeed.DataBind();
                }
            }
            catch (Exception)
            {

                //throw;
            }
            return dt;
        }
    }

}