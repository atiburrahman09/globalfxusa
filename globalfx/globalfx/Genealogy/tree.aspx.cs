﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Global.Core.BLL;
using Lumex.Tech;

namespace globalfx.generic
{
    public partial class tree : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    //initializeTree();
                    DrawTree((string)LumexSessionManager.Get("ActiveUserId"));
                }
            }
            catch (Exception)
            {

                //   throw;
            }
        }
        string L = "0", R = "";
        private void DrawTree(string UserId)
        {
            try
            {
                DataTable userD = new DataTable();
                DataTable dt = new DataTable();
                genologyBLL genology = new genologyBLL();
                UserBLL userBll = new UserBLL();
                string UserName = "";
                string UserShowinfo = "";
                userD = userBll.GetUserInfoById(UserId);
                if (userD.Rows.Count != 0)
                {
                    btnlbl1.Text = UserId;
                    UserName = "Name:" + userD.Rows[0]["FirstName"].ToString() + " " + userD.Rows[0]["LastName"].ToString();
                    UserShowinfo = "Cell:" + userD.Rows[0]["MobileNo"].ToString() + "\n\rEmail: " +
                                             userD.Rows[0]["Email"].ToString() + "\n\rInvest Amount($): " + userD.Rows[0]["Insvest"].ToString() + "\n\rTotal Left($): " + userD.Rows[0]["TotalLeft"].ToString() + "\n\rTotal Right($): " + userD.Rows[0]["TotalRight"].ToString() + "\n\rCarry($): " + userD.Rows[0]["CarryForward"].ToString() + "[" + userD.Rows[0]["CarrySite"].ToString() + "]";

                    lbl1.Attributes.Add("data-content", UserShowinfo);
                    lbl1.Attributes.Add("data-title", UserName);

                    if (userD.Rows[0]["IsActive"].ToString() == "No")
                    {
                        lbl1.Attributes.Add("class", "btn btn-danger popover1");
                    }
                    else if (userD.Rows[0]["IsActive"].ToString() == "Yes")
                    {
                        lbl1.Attributes.Add("class", "btn btn-primary popover1");
                    }

                }

                initializeTree();
                find(btnlbl1.Text, out L, out R);
                string l2 = L.ToString();
                string r3 = R.ToString();
                if (l2 != "")
                {
                    userD = userBll.GetUserInfoById(l2);
                    if (userD.Rows.Count != 0)
                    {
                        btnlbl2L.Text = l2;
                        UserName = "Name:" + userD.Rows[0]["FirstName"].ToString() + " " + userD.Rows[0]["LastName"].ToString();
                        UserShowinfo = "Cell:" + userD.Rows[0]["MobileNo"].ToString() + "\nEmail: " +
                                            userD.Rows[0]["Email"].ToString() + "\nInvest Amount($): " + userD.Rows[0]["Insvest"].ToString() + "\nTotal Left($): " + userD.Rows[0]["TotalLeft"].ToString() + "\nTotal Right($): " + userD.Rows[0]["TotalRight"].ToString() + "\nCarry($): " + userD.Rows[0]["CarryForward"].ToString() + "[" + userD.Rows[0]["CarrySite"].ToString() + "]";


                        lbl2L.Attributes.Add("data-content", UserShowinfo);
                        lbl2L.Attributes.Add("data-title", UserName);
                        lbl2L.Attributes.Remove("class");
                        if (userD.Rows[0]["IsActive"].ToString() == "No")
                        {
                            lbl2L.Attributes.Add("class", "btn btn-danger popover1");
                        }
                        else if (userD.Rows[0]["IsActive"].ToString() == "Yes")
                        {
                            lbl2L.Attributes.Add("class", "btn btn-primary popover1");
                        }

                        ilbl2L.ImageUrl = "/assets/img/user.png";
                    }

                    find(l2, out L, out R);
                    string l4 = L.ToString();
                    string r5 = R.ToString();

                    if (l4 != "")
                    {
                        userD = userBll.GetUserInfoById(l4);
                        if (userD.Rows.Count != 0)
                        {
                            btnlbl21L.Text = l4;
                            UserName = "Name:" + userD.Rows[0]["FirstName"].ToString() + " " + userD.Rows[0]["LastName"].ToString();
                            UserShowinfo = "Cell:" + userD.Rows[0]["MobileNo"].ToString() + "\nEmail: " +
                                             userD.Rows[0]["Email"].ToString() + "\nInvest Amount($): " + userD.Rows[0]["Insvest"].ToString() + "\nTotal Left($): " + userD.Rows[0]["TotalLeft"].ToString() + "\nTotal Right($): " + userD.Rows[0]["TotalRight"].ToString() + "\nCarry($): " + userD.Rows[0]["CarryForward"].ToString() + "[" + userD.Rows[0]["CarrySite"].ToString() + "]";


                            lbl21L.Attributes.Add("data-content", UserShowinfo);
                            lbl21L.Attributes.Add("data-title", UserName);
                            lbl21L.Attributes.Remove("class");
                            if (userD.Rows[0]["IsActive"].ToString() == "No")
                            {
                                lbl21L.Attributes.Add("class", "btn btn-danger popover1");
                            }
                            else if (userD.Rows[0]["IsActive"].ToString() == "Yes")
                            {
                                lbl21L.Attributes.Add("class", "btn btn-primary popover1");
                            }
                            ilbl21L.ImageUrl = "/assets/img/user.png";

                        }
                        find(l4, out L, out R);
                        string l8 = L.ToString();
                        string r9 = R.ToString();

                        if (l8 != "")
                        {
                            userD = userBll.GetUserInfoById(l8);
                            if (userD.Rows.Count != 0)
                            {
                                btnlbl211L.Text = l8;
                                UserName = "Name:" + userD.Rows[0]["FirstName"].ToString() + " " + userD.Rows[0]["LastName"].ToString();
                                UserShowinfo = "Cell:" + userD.Rows[0]["MobileNo"].ToString() + "\nEmail: " +
                                             userD.Rows[0]["Email"].ToString() + "\nInvest Amount($): " + userD.Rows[0]["Insvest"].ToString() + "\nTotal Left($): " + userD.Rows[0]["TotalLeft"].ToString() + "\nTotal Right($): " + userD.Rows[0]["TotalRight"].ToString() + "\nCarry($): " + userD.Rows[0]["CarryForward"].ToString() + "[" + userD.Rows[0]["CarrySite"].ToString() + "]";


                                lbl211L.Attributes.Add("data-content", UserShowinfo);
                                lbl211L.Attributes.Add("data-title", UserName);
                                lbl211L.Attributes.Remove("class");
                                if (userD.Rows[0]["IsActive"].ToString() == "No")
                                {
                                    lbl211L.Attributes.Add("class", "btn btn-danger popover1");
                                }
                                else if (userD.Rows[0]["IsActive"].ToString() == "Yes")
                                {
                                    lbl211L.Attributes.Add("class", "btn btn-primary popover1");
                                }

                                ilbl211L.ImageUrl = "/assets/img/user.png";
                            }
                        }
                        if (r9 != "")
                        {
                            userD = userBll.GetUserInfoById(r9);
                            if (userD.Rows.Count != 0)
                            {
                                btnlbl212R.Text = r9;
                                UserName = "Name:" + userD.Rows[0]["FirstName"].ToString() + " " + userD.Rows[0]["LastName"].ToString();
                                UserShowinfo = "Cell:" + userD.Rows[0]["MobileNo"].ToString() + "\nEmail: " +
                                          userD.Rows[0]["Email"].ToString() + "\nInvest Amount($): " + userD.Rows[0]["Insvest"].ToString() + "\nTotal Left($): " + userD.Rows[0]["TotalLeft"].ToString() + "\nTotal Right($): " + userD.Rows[0]["TotalRight"].ToString() + "\nCarry($): " + userD.Rows[0]["CarryForward"].ToString() + "[" + userD.Rows[0]["CarrySite"].ToString() + "]";

                                lbl212R.Attributes.Add("data-content", UserShowinfo);
                                lbl212R.Attributes.Add("data-title", UserName);
                                lbl212R.Attributes.Remove("class");
                                if (userD.Rows[0]["IsActive"].ToString() == "No")
                                {
                                    lbl212R.Attributes.Add("class", "btn btn-danger popover1");
                                }
                                else if (userD.Rows[0]["IsActive"].ToString() == "Yes")
                                {
                                    lbl212R.Attributes.Add("class", "btn btn-primary popover1");
                                }

                                ilbl212R.ImageUrl = "/assets/img/user.png";
                            }
                        }
                    }
                    if (r5 != "")
                    {
                        userD = userBll.GetUserInfoById(r5);
                        if (userD.Rows.Count != 0)
                        {
                            btnlbl22R.Text = r5;
                            UserName = "Name:" + userD.Rows[0]["FirstName"].ToString() + " " + userD.Rows[0]["LastName"].ToString();
                            UserShowinfo = "Cell:" + userD.Rows[0]["MobileNo"].ToString() + "\nEmail: " +
                                          userD.Rows[0]["Email"].ToString() + "\nInvest Amount($): " + userD.Rows[0]["Insvest"].ToString() + "\nTotal Left($): " + userD.Rows[0]["TotalLeft"].ToString() + "\nTotal Right($): " + userD.Rows[0]["TotalRight"].ToString() + "\nCarry($): " + userD.Rows[0]["CarryForward"].ToString() + "[" + userD.Rows[0]["CarrySite"].ToString() + "]";


                            lbl22R.Attributes.Add("data-content", UserShowinfo);
                            lbl22R.Attributes.Add("data-title", UserName);
                            lbl22R.Attributes.Remove("class");
                            if (userD.Rows[0]["IsActive"].ToString() == "No")
                            {
                                lbl22R.Attributes.Add("class", "btn btn-danger popover1");
                            }
                            else if (userD.Rows[0]["IsActive"].ToString() == "Yes")
                            {
                                lbl22R.Attributes.Add("class", "btn btn-primary popover1");
                            }
                            ilbl22R.ImageUrl = "/assets/img/user.png";

                        }
                        find(r5, out L, out R);
                        string l10 = L.ToString();
                        string r11 = R.ToString();

                        if (l10 != "")
                        {
                            userD = userBll.GetUserInfoById(l10);
                            if (userD.Rows.Count != 0)
                            {
                                btnlbl221L.Text = l10;
                                UserName = "Name:" + userD.Rows[0]["FirstName"].ToString() + " " + userD.Rows[0]["LastName"].ToString();
                                UserShowinfo = "Cell:" + userD.Rows[0]["MobileNo"].ToString() + "\nEmail: " +
                                            userD.Rows[0]["Email"].ToString() + "\nInvest Amount($): " + userD.Rows[0]["Insvest"].ToString() + "\nTotal Left($): " + userD.Rows[0]["TotalLeft"].ToString() + "\nTotal Right($): " + userD.Rows[0]["TotalRight"].ToString() + "\nCarry($): " + userD.Rows[0]["CarryForward"].ToString() + "[" + userD.Rows[0]["CarrySite"].ToString() + "]";


                                lbl221L.Attributes.Add("data-content", UserShowinfo);
                                lbl221L.Attributes.Add("data-title", UserName);
                                lbl221L.Attributes.Remove("class");
                                if (userD.Rows[0]["IsActive"].ToString() == "No")
                                {
                                    lbl221L.Attributes.Add("class", "btn btn-danger popover1");
                                }
                                else if (userD.Rows[0]["IsActive"].ToString() == "Yes")
                                {
                                    lbl221L.Attributes.Add("class", "btn btn-primary popover1");
                                }

                                ilbl221L.ImageUrl = "/assets/img/user.png";
                            }
                        }
                        if (r11 != "")
                        {
                            userD = userBll.GetUserInfoById(r11);
                            if (userD.Rows.Count != 0)
                            {
                                btnlbl222R.Text = r11;
                                UserName = "Name:" + userD.Rows[0]["FirstName"].ToString() + " " + userD.Rows[0]["LastName"].ToString();
                                UserShowinfo = "Cell:" + userD.Rows[0]["MobileNo"].ToString() + "\nEmail: " +
                                            userD.Rows[0]["Email"].ToString() + "\nInvest Amount($): " + userD.Rows[0]["Insvest"].ToString() + "\nTotal Left($): " + userD.Rows[0]["TotalLeft"].ToString() + "\nTotal Right($): " + userD.Rows[0]["TotalRight"].ToString() + "\nCarry($): " + userD.Rows[0]["CarryForward"].ToString() + "[" + userD.Rows[0]["CarrySite"].ToString() + "]";

                                lbl222R.Attributes.Add("data-content", UserShowinfo);
                                lbl222R.Attributes.Add("data-title", UserName);
                                lbl222R.Attributes.Remove("class");
                                if (userD.Rows[0]["IsActive"].ToString() == "No")
                                {
                                    lbl222R.Attributes.Add("class", "btn btn-danger popover1");
                                }
                                else if (userD.Rows[0]["IsActive"].ToString() == "Yes")
                                {
                                    lbl222R.Attributes.Add("class", "btn btn-primary popover1");
                                }

                                ilbl222R.ImageUrl = "/assets/img/user.png";
                            }
                        }
                    }
                }
                if (r3 != "")
                {
                    userD = userBll.GetUserInfoById(r3);
                    if (userD.Rows.Count != 0)
                    {
                        btnlbl3R.Text = r3;
                        UserName = "Name:" + userD.Rows[0]["FirstName"].ToString() + " " + userD.Rows[0]["LastName"].ToString();
                        UserShowinfo = "Cell:" + userD.Rows[0]["MobileNo"].ToString() + "\nEmail: " +
                                          userD.Rows[0]["Email"].ToString() + "\nInvest Amount($): " + userD.Rows[0]["Insvest"].ToString() + "\nTotal Left($): " + userD.Rows[0]["TotalLeft"].ToString() + "\nTotal Right($): " + userD.Rows[0]["TotalRight"].ToString() + "\nCarry($): " + userD.Rows[0]["CarryForward"].ToString() + "[" + userD.Rows[0]["CarrySite"].ToString() + "]";

                        lbl3R.Attributes.Add("data-content", UserShowinfo);
                        lbl3R.Attributes.Add("data-title", UserName);
                        lbl3R.Attributes.Remove("class");
                        if (userD.Rows[0]["IsActive"].ToString() == "No")
                        {
                            lbl3R.Attributes.Add("class", "btn btn-danger popover1");
                        }
                        else if (userD.Rows[0]["IsActive"].ToString() == "Yes")
                        {
                            lbl3R.Attributes.Add("class", "btn btn-primary popover1");
                        }
                        ilbl3R.ImageUrl = "/assets/img/user.png";

                    }
                    find(r3, out L, out R);
                    string l6 = L.ToString();
                    string r7 = R.ToString();
                    if (l6 != "")
                    {
                        userD = userBll.GetUserInfoById(l6);
                        if (userD.Rows.Count != 0)
                        {
                            btnlbl31L.Text = l6;
                            UserName = "Name:" + userD.Rows[0]["FirstName"].ToString() + " " + userD.Rows[0]["LastName"].ToString();
                            UserShowinfo = "Cell:" + userD.Rows[0]["MobileNo"].ToString() + "\nEmail: " +
                                             userD.Rows[0]["Email"].ToString() + "\nInvest Amount($): " + userD.Rows[0]["Insvest"].ToString() + "\nTotal Left($): " + userD.Rows[0]["TotalLeft"].ToString() + "\nTotal Right($): " + userD.Rows[0]["TotalRight"].ToString() + "\nCarry($): " + userD.Rows[0]["CarryForward"].ToString() + "[" + userD.Rows[0]["CarrySite"].ToString() + "]";


                            lbl31L.Attributes.Add("data-content", UserShowinfo);
                            lbl31L.Attributes.Add("data-title", UserName);
                            lbl31L.Attributes.Remove("class");
                            if (userD.Rows[0]["IsActive"].ToString() == "No")
                            {
                                lbl31L.Attributes.Add("class", "btn btn-danger popover1");
                            }
                            else if (userD.Rows[0]["IsActive"].ToString() == "Yes")
                            {
                                lbl31L.Attributes.Add("class", "btn btn-primary popover1");
                            }
                            ilbl31L.ImageUrl = "/assets/img/user.png";

                        }
                        find(l6, out L, out R);
                        string l12 = L.ToString();
                        string r13 = R.ToString();
                        if (l12 != "")
                        {
                            userD = userBll.GetUserInfoById(l12);
                            if (userD.Rows.Count != 0)
                            {
                                btnlbl311L.Text = l12;
                                UserName = "Name:" + userD.Rows[0]["FirstName"].ToString() + " " + userD.Rows[0]["LastName"].ToString();
                                UserShowinfo = "Cell:" + userD.Rows[0]["MobileNo"].ToString() + "\nEmail: " +
                                          userD.Rows[0]["Email"].ToString() + "\nInvest Amount($): " + userD.Rows[0]["Insvest"].ToString() + "\nTotal Left($): " + userD.Rows[0]["TotalLeft"].ToString() + "\nTotal Right($): " + userD.Rows[0]["TotalRight"].ToString() + "\nCarry($): " + userD.Rows[0]["CarryForward"].ToString() + "[" + userD.Rows[0]["CarrySite"].ToString() + "]";


                                lbl311L.Attributes.Add("data-content", UserShowinfo);
                                lbl311L.Attributes.Add("data-title", UserName);
                                lbl311L.Attributes.Remove("class");
                                if (userD.Rows[0]["IsActive"].ToString() == "No")
                                {
                                    lbl311L.Attributes.Add("class", "btn btn-danger popover1");
                                }
                                else if (userD.Rows[0]["IsActive"].ToString() == "Yes")
                                {
                                    lbl311L.Attributes.Add("class", "btn btn-primary popover1");
                                }
                                ilbl311L.ImageUrl = "/assets/img/user.png";

                            }
                        }
                        if (r13 != "")
                        {
                            userD = userBll.GetUserInfoById(r13);
                            if (userD.Rows.Count != 0)
                            {
                                btnlbl312R.Text = r13;
                                UserName = "Name:" + userD.Rows[0]["FirstName"].ToString() + " " + userD.Rows[0]["LastName"].ToString();
                                UserShowinfo = "Cell:" + userD.Rows[0]["MobileNo"].ToString() + "\nEmail: " +
                                            userD.Rows[0]["Email"].ToString() + "\nInvest Amount($): " + userD.Rows[0]["Insvest"].ToString() + "\nTotal Left($): " + userD.Rows[0]["TotalLeft"].ToString() + "\nTotal Right($): " + userD.Rows[0]["TotalRight"].ToString() + "\nCarry($): " + userD.Rows[0]["CarryForward"].ToString() + "[" + userD.Rows[0]["CarrySite"].ToString() + "]";


                                lbl312R.Attributes.Add("data-content", UserShowinfo);
                                lbl312R.Attributes.Add("data-title", UserName);
                                lbl312R.Attributes.Remove("class");
                                if (userD.Rows[0]["IsActive"].ToString() == "No")
                                {
                                    lbl312R.Attributes.Add("class", "btn btn-danger popover1");
                                }
                                else if (userD.Rows[0]["IsActive"].ToString() == "Yes")
                                {
                                    lbl312R.Attributes.Add("class", "btn btn-primary popover1");
                                }
                                ilbl312R.ImageUrl = "/assets/img/user.png";

                            }
                        }
                    }
                    if (r7 != "")
                    {
                        userD = userBll.GetUserInfoById(r7);
                        if (userD.Rows.Count != 0)
                        {
                            btnlbl32R.Text = r7;
                            UserName = "Name:" + userD.Rows[0]["FirstName"].ToString() + " " + userD.Rows[0]["LastName"].ToString();
                            UserShowinfo = "Cell:" + userD.Rows[0]["MobileNo"].ToString() + "\nEmail: " +
                                          userD.Rows[0]["Email"].ToString() + "\nInvest Amount($): " + userD.Rows[0]["Insvest"].ToString() + "\nTotal Left($): " + userD.Rows[0]["TotalLeft"].ToString() + "\nTotal Right($): " + userD.Rows[0]["TotalRight"].ToString() + "\nCarry($): " + userD.Rows[0]["CarryForward"].ToString() + "[" + userD.Rows[0]["CarrySite"].ToString() + "]";


                            lbl32R.Attributes.Add("data-content", UserShowinfo);
                            lbl32R.Attributes.Add("data-title", UserName);
                            lbl32R.Attributes.Remove("class");
                            if (userD.Rows[0]["IsActive"].ToString() == "No")
                            {
                                lbl32R.Attributes.Add("class", "btn btn-danger popover1");
                            }
                            else if (userD.Rows[0]["IsActive"].ToString() == "Yes")
                            {
                                lbl32R.Attributes.Add("class", "btn btn-primary popover1");
                            }
                            ilbl32R.ImageUrl = "/assets/img/user.png";

                        }
                        find(r7, out L, out R);
                        string l14 = L.ToString();
                        string r15 = R.ToString();
                        if (l14 != "")
                        {
                            userD = userBll.GetUserInfoById(l14);
                            if (userD.Rows.Count != 0)
                            {
                                btnlbl321L.Text = l14;
                                UserName = "Name:" + userD.Rows[0]["FirstName"].ToString() + " " + userD.Rows[0]["LastName"].ToString();
                                UserShowinfo = "Cell:" + userD.Rows[0]["MobileNo"].ToString() + "\nEmail: " +
                                            userD.Rows[0]["Email"].ToString() + "\nInvest Amount($): " + userD.Rows[0]["Insvest"].ToString() + "\nTotal Left($): " + userD.Rows[0]["TotalLeft"].ToString() + "\nTotal Right($): " + userD.Rows[0]["TotalRight"].ToString() + "\nCarry($): " + userD.Rows[0]["CarryForward"].ToString() + "[" + userD.Rows[0]["CarrySite"].ToString() + "]";


                                lbl321L.Attributes.Add("data-content", UserShowinfo);
                                lbl321L.Attributes.Add("data-title", UserName);
                                lbl321L.Attributes.Remove("class");
                                if (userD.Rows[0]["IsActive"].ToString() == "No")
                                {
                                    lbl321L.Attributes.Add("class", "btn btn-danger popover1");
                                }
                                else if (userD.Rows[0]["IsActive"].ToString() == "Yes")
                                {
                                    lbl321L.Attributes.Add("class", "btn btn-primary popover1");
                                }

                                ilbl321L.ImageUrl = "/assets/img/user.png";
                            }
                        }
                        if (r15 != "")
                        {
                            userD = userBll.GetUserInfoById(r15);
                            if (userD.Rows.Count != 0)
                            {
                                btnlbl322R.Text = r15;
                                UserName = "Name:" + userD.Rows[0]["FirstName"].ToString() + " " + userD.Rows[0]["LastName"].ToString();
                                UserShowinfo = "Cell:" + userD.Rows[0]["MobileNo"].ToString() + "\nEmail: " +
                                            userD.Rows[0]["Email"].ToString() + "\nInvest Amount($): " + userD.Rows[0]["Insvest"].ToString() + "\nTotal Left($): " + userD.Rows[0]["TotalLeft"].ToString() + "\nTotal Right($): " + userD.Rows[0]["TotalRight"].ToString() + "\nCarry($): " + userD.Rows[0]["CarryForward"].ToString() + "[" + userD.Rows[0]["CarrySite"].ToString() + "]";


                                lbl322R.Attributes.Add("data-content", UserShowinfo);
                                lbl322R.Attributes.Add("data-title", UserName);
                                lbl322R.Attributes.Remove("class");
                                if (userD.Rows[0]["IsActive"].ToString() == "No")
                                {
                                    lbl322R.Attributes.Add("class", "btn btn-danger popover1");
                                }
                                else if (userD.Rows[0]["IsActive"].ToString() == "Yes")
                                {
                                    lbl322R.Attributes.Add("class", "btn btn-primary popover1");
                                }

                                ilbl322R.ImageUrl = "/assets/img/user.png";
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

                //throw;
            }
        }

        private void find(string UserId, out string Left, out string Right)
        {

            Left = "";
            Right = "";
            genologyBLL genology = new genologyBLL();

            DataTable dt = genology.find(UserId);


            if (dt.Rows.Count > 1)
            {
                if (dt.Rows[0]["PlacePosition"].ToString().Trim() == "L")
                {
                    Left = dt.Rows[0]["UserId"].ToString();
                }
                else if (dt.Rows[0]["PlacePosition"].ToString().Trim() == "R")
                {
                    Right = dt.Rows[0]["UserId"].ToString(); ;
                }

                if (dt.Rows[1]["PlacePosition"].ToString().Trim() == "L")
                {
                    Left = dt.Rows[1]["UserId"].ToString();
                }
                else if (dt.Rows[1]["PlacePosition"].ToString().Trim() == "R")
                {
                    Right = dt.Rows[1]["UserId"].ToString(); ;
                }
            }
            else if (dt.Rows.Count == 1)
            {
                if (dt.Rows[0]["PlacePosition"].ToString() == "L")
                {
                    Left = dt.Rows[0]["UserId"].ToString();
                }
                if (dt.Rows[0]["PlacePosition"].ToString() == "R")
                {
                    Right = dt.Rows[0]["UserId"].ToString();
                }
            }

        }

        private void initializeTree()
        {
            try
            {
                // btnlbl1.Text = (string)LumexSessionManager.Get("ActiveUserId");
                btnlbl2L.Text = "Add New";
                btnlbl3R.Text = "Add New";
                btnlbl21L.Text = "Add New";
                btnlbl22R.Text = "Add New";
                btnlbl31L.Text = "Add New";
                btnlbl32R.Text = "Add New";
                btnlbl211L.Text = "Add New";
                btnlbl212R.Text = "Add New";
                btnlbl311L.Text = "Add New";
                btnlbl312R.Text = "Add New";
                btnlbl221L.Text = "Add New";
                btnlbl222R.Text = "Add New";
                btnlbl321L.Text = "Add New";
                btnlbl322R.Text = "Add New";

                ilbl2L.ImageUrl = "/assets/img/add_user.png";
                ilbl3R.ImageUrl = "/assets/img/add_user.png";
                ilbl21L.ImageUrl = "/assets/img/add_user.png";
                ilbl22R.ImageUrl = "/assets/img/add_user.png";
                ilbl31L.ImageUrl = "/assets/img/add_user.png";
                ilbl32R.ImageUrl = "/assets/img/add_user.png";
                ilbl211L.ImageUrl = "/assets/img/add_user.png";
                ilbl212R.ImageUrl = "/assets/img/add_user.png";
                ilbl311L.ImageUrl = "/assets/img/add_user.png";
                ilbl312R.ImageUrl = "/assets/img/add_user.png";
                ilbl221L.ImageUrl = "/assets/img/add_user.png";
                ilbl222R.ImageUrl = "/assets/img/add_user.png";
                ilbl321L.ImageUrl = "/assets/img/add_user.png";
                ilbl322R.ImageUrl = "/assets/img/add_user.png";




                //lbl2L.Attributes.Add("data-original-title", "Help");
                //lbl3R.Attributes.Add("data-original-title", "Help");
                //lbl21L.Attributes.Add("data-original-title", "Help!!");
                //lbl22R.Attributes.Add("data-original-title", "Help !!");
                //lbl31L.Attributes.Add("data-original-title", "Help !!");
                //lbl32R.Attributes.Add("data-original-title", "Help !!");
                //lbl211L.Attributes.Add("data-original-title", "Help !!");
                //lbl212R.Attributes.Add("data-original-title", "Help !!");
                //lbl311L.Attributes.Add("data-original-title", "Help !!");
                //lbl312R.Attributes.Add("data-original-title", "Help !!");
                //lbl221L.Attributes.Add("data-original-title", "Help !!");
                //lbl222R.Attributes.Add("data-original-title", "Help !!");
                //lbl321L.Attributes.Add("data-original-title", "Help !!");
                //lbl322R.Attributes.Add("data-original-title", "Help !!");



                lbl2L.Attributes.Add("data-content", "Click Add New to add new Investor.");
                lbl3R.Attributes.Add("data-content", "Click Add New to add new Investor.");
                lbl21L.Attributes.Add("data-content", "Click Add New to add new Investor.");
                lbl22R.Attributes.Add("data-content", "Click Add New to add new Investor.");
                lbl31L.Attributes.Add("data-content", "Click Add New to add new Investor.");
                lbl32R.Attributes.Add("data-content", "Click Add New to add new Investor.");
                lbl211L.Attributes.Add("data-content", "Click Add New to add new Investor.");
                lbl212R.Attributes.Add("data-content", "Click Add New to add new Investor.");
                lbl311L.Attributes.Add("data-content", "Click Add New to add new Investor.");
                lbl312R.Attributes.Add("data-content", "Click Add New to add new Investor.");
                lbl221L.Attributes.Add("data-content", "Click Add New to add new Investor.");
                lbl222R.Attributes.Add("data-content", "Click Add New to add new Investor.");
                lbl321L.Attributes.Add("data-content", "Click Add New to add new Investor.");
                lbl322R.Attributes.Add("data-content", "Click Add New to add new Investor.");

                lbl2L.Attributes.Add("data-title", "Help");
                lbl3R.Attributes.Add("data-title", "Help");
                lbl21L.Attributes.Add("data-title", "Help!!");
                lbl22R.Attributes.Add("data-title", "Help !!");
                lbl31L.Attributes.Add("data-title", "Help !!");
                lbl32R.Attributes.Add("data-title", "Help !!");
                lbl211L.Attributes.Add("data-title", "Help !!");
                lbl212R.Attributes.Add("data-title", "Help !!");
                lbl311L.Attributes.Add("data-title", "Help !!");
                lbl312R.Attributes.Add("data-title", "Help !!");
                lbl221L.Attributes.Add("data-title", "Help !!");
                lbl222R.Attributes.Add("data-title", "Help !!");
                lbl321L.Attributes.Add("data-title", "Help !!");
                lbl322R.Attributes.Add("data-title", "Help !!");

                lbl2L.Attributes.Add("class", "btn popover1");
                lbl3R.Attributes.Add("class", "btn popover1");
                lbl21L.Attributes.Add("class", "btn popover1");
                lbl22R.Attributes.Add("class", "btn popover1");
                lbl31L.Attributes.Add("class", "btn popover1");
                lbl32R.Attributes.Add("class", "btn popover1");
                lbl211L.Attributes.Add("class", "btn popover1");
                lbl212R.Attributes.Add("class", "btn popover1");
                lbl311L.Attributes.Add("class", "btn popover1");
                lbl312R.Attributes.Add("class", "btn popover1");
                lbl221L.Attributes.Add("class", "btn popover1");
                lbl222R.Attributes.Add("class", "btn popover1");
                lbl321L.Attributes.Add("class", "btn popover1");
                lbl322R.Attributes.Add("class", "btn popover1");
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }

        protected void btnlbl1_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkbtn = (LinkButton)sender;

                if (lnkbtn.Text != "Add New")
                {
                    DrawTree(lnkbtn.Text);
                }
                else
                {
                    var position = lnkbtn.ID[lnkbtn.ID.Length - 1];
                    string placementId = getPlacementId(lnkbtn);
                    var refaralId = (string)LumexSessionManager.Get("ActiveUserId");
                    if (placementId != "Add New")
                    {
                        string query = urlencrp.DESEncrypt(position + "#" + placementId + "#" + refaralId); // QueryStringModule.Encrypt("user=123&account=456");

                        //  string decrypt = QueryStringModule.Decrypt()
                        //string encrurldata =
                        //    dataEncryptbll.EncryptRijndael(
                        //        position + "#" + placementId + "#" + refaralId, dataEncryptbll.addforvarifycore);
                        string encrurldata = "";
                        var myurl = "/page/registration.aspx?u=" + query;
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow",
                            "window.open(" + "'" + myurl + "'" + ",'_newtab');", true);

                    }
                    else
                    {
                        string message = " <span class='actionTopic'> The Placement ID is not valid. Thanks" + "</span>.";
                        MyAlertBox(
                            "var callbackOk = function () { window.location = \"/a/initialdata/initialDataElement.aspx\"; }; WarningAlert(\"" +
                            "Warning" + "\", \"" + message + "\", \"\");");


                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private string getPlacementId(LinkButton lnkbtn)
        {
            try
            {
                string placementid = "";
                string id = lnkbtn.ID.Remove(0, 3);
                if (id == "lbl2L")
                {
                    placementid = btnlbl1.Text;
                }
                else if (id == "lbl3R")
                {
                    placementid = btnlbl1.Text;
                }
                else if (id == "lbl21L")
                {
                    placementid = btnlbl2L.Text;
                }
                else if (id == "lbl22R")
                {
                    placementid = btnlbl2L.Text;
                }
                else if (id == "lbl31L")
                {
                    placementid = btnlbl3R.Text;
                }
                else if (id == "lbl32R")
                {
                    placementid = btnlbl3R.Text;
                }
                else if (id == "lbl211L")
                {
                    placementid = btnlbl21L.Text;
                }
                else if (id == "lbl212R")
                {
                    placementid = btnlbl21L.Text;
                }
                else if (id == "lbl221L")
                {
                    placementid = btnlbl22R.Text;
                }
                else if (id == "lbl222R")
                {
                    placementid = btnlbl22R.Text;
                }
                else if (id == "lbl311L")
                {
                    placementid = btnlbl31L.Text;
                }
                else if (id == "lbl312R")
                {
                    placementid = btnlbl31L.Text;
                }
                else if (id == "lbl321L")
                {
                    placementid = btnlbl32R.Text;
                }
                else if (id == "lbl322R")
                {
                    placementid = btnlbl32R.Text;
                }

                return placementid;
            }
            catch (Exception)
            {

                throw;
            }

        }



        protected void btnSearchTree_Click(object sender, EventArgs e)
        {

            // DrawTree(txtbxUserId.Text);
            try
            {
                searchDownLink((string)LumexSessionManager.Get("ActiveUserId"), txtbxUserId.Text);
            }
            catch (Exception)
            {

                // throw;
            }
            finally
            {
                MyAlertBox("MyOverlayStop();");
            }

        }

        private void searchDownLink(string MainUser, string SearchUser)
        {
            try
            {
                genologyBLL genology = new genologyBLL();
                DataTable dt = genology.getStakeJoiningList();
                viststack.Push(MainUser);
                bool status = getChildNode(dt);
                if (status)
                {
                    DrawTree(txtbxUserId.Text);
                }
                else
                {

                    string message =
                          "Please <span class='actionTopic'>Correct User ID or Your Downlink User ID </span>";
                    MyAlertBox(
                        "var callbackOk = function () { MyOverlayStart(); window.location = \"/a/account/withdraw.aspx\"; }; WarningAlert(\"" +
                        "Warning!!" + "\", \"" + message + "\", \"\");");
                }
                // Current = MainUser;
            }
            catch (Exception)
            {

                throw;
            }

        }
        Stack<string> viststack = new Stack<string>();
        bool srcstatus = false;
        private bool getChildNode(DataTable alldata)
        {
            try
            {

                string MainUser = viststack.Pop();
                DataView view = new DataView(alldata);
                view.RowFilter = "PleacementId = '" + MainUser + "'";

                if (view.Count > 1)
                {
                    if (view[0]["UserId"].ToString() == txtbxUserId.Text)
                    {
                        srcstatus = true;

                    }
                    else
                    {
                        viststack.Push(view[0]["UserId"].ToString());
                    }

                    if (view[1]["UserId"].ToString() == txtbxUserId.Text)
                    {
                        srcstatus = true;
                        return srcstatus;
                    }
                    else
                    {
                        viststack.Push(view[1]["UserId"].ToString());
                    }
                }
                else if (view.Count == 1)
                {
                    if (view[0]["UserId"].ToString() == txtbxUserId.Text)
                    {
                        srcstatus = true;
                        return srcstatus;
                    }
                    else
                    {
                        viststack.Push(view[0]["UserId"].ToString());
                    }

                }
                if (srcstatus)
                {

                    viststack.Clear();
                    alldata = null;
                    return srcstatus;

                }
                else
                {
                    if (viststack.Count > 0)
                    {
                        getChildNode(alldata);
                    }


                }


                return srcstatus;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}