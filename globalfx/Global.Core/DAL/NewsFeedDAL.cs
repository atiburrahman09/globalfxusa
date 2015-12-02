﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lumex.Tech;

namespace Global.Core.DAL
{
    public class NewsFeedDAL
    {
        internal System.Data.DataTable SaveNewsInfo(BLL.NewsFeedBLL newsFeedBLL, Lumex.Tech.LumexDBPlayer db)
        {
            DataTable dt = new DataTable();
            try
            {
                
                db.AddParameters("@NewsBody", newsFeedBLL.BodyText);
                db.AddParameters("@NewsTitale", newsFeedBLL.Title);
                db.AddParameters("@ValidDate", newsFeedBLL.Value);
                db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId"));
                db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());
                dt = db.ExecuteDataTable("INSERT INTO [dbo].[tblNewsFeed]([NewsBody],[NewsTitale],[ValidDate],[CreatedBy],[CreatedDate])VALUES(@NewsBody,@NewsTitale,@ValidDate,@CreatedBy,GETDATE())");
            
            }
            catch (Exception)
            {
                //throw;
            }
            return dt;
        }

        internal System.Data.DataTable GetNewsFeedList(Lumex.Tech.LumexDBPlayer db)
        {
            bool status = true;
            DataTable dt = new DataTable();
            try
            {
                dt = db.ExecuteDataTable("SELECT [Serial],[NewsBody],[NewsTitale],[ValidDate],[CreatedBy],[CreatedDate]FROM [dbo].[tblNewsFeed]");
            }
            catch (Exception)
            {

                throw;

            }

            return dt; 
        }

        internal System.Data.DataTable GetNewsFeedDataById(BLL.NewsFeedBLL newsFeedBLL, Lumex.Tech.LumexDBPlayer db)
        {
            bool status = true;
            DataTable dt = new DataTable();
            try
            {
                db.AddParameters("@Serial", newsFeedBLL.NewsFeedId);
                dt = db.ExecuteDataTable("SELECT [Serial],[NewsBody],[NewsTitale],[ValidDate],[CreatedBy],[CreatedDate]FROM [dbo].[tblNewsFeed] where Serial=@Serial");
            }
            catch (Exception)
            {

                throw;

            }

            return dt; 
        }

        internal bool UpdateNewsInfo(BLL.NewsFeedBLL newsFeedBLL, LumexDBPlayer db)
        {
            DataTable dt = new DataTable();
           bool status = false;
            try
            {
                db.AddParameters("@Serial", newsFeedBLL.Serial);
                db.AddParameters("@NewsBody", newsFeedBLL.BodyText);
                db.AddParameters("@NewsTitale", newsFeedBLL.Title);
                db.AddParameters("@ValidDate",  newsFeedBLL.Value);
                //db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId"));
                //db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());
                db.ExecuteDataTable("UPDATE [dbo].[tblNewsFeed] SET NewsBody=@NewsBody, NewsTitale=@NewsTitale, ValidDate=@ValidDate WHERE Serial=@Serial");
                status = true;
            }
            catch (Exception)
            {

                throw;
            }
            return status;
        }
    }
}