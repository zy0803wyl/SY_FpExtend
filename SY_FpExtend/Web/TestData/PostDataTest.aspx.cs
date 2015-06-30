﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RuRo.Web.TestData
{
    public partial class PostDataTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string us = username.Text.Trim();
            string pwd = password.Text.Trim();
            string mth = method.Text.Trim();
            string baseUrl = System.Configuration.ConfigurationManager.AppSettings["FpUrl"];
            Common.HttpHelper http = new Common.HttpHelper();
            Common.HttpItem item = new Common.HttpItem();
            Common.HttpResult res = new Common.HttpResult();


            item.Method = "POST";
            item.PostEncoding = System.Text.Encoding.UTF8;
            item.URL = baseUrl + "/api";
            item.Postdata = "";
        }
    }
}