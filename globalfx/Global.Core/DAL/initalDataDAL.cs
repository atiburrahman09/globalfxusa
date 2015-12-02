﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Global.Core.BLL;
using System.Data;
using Lumex.Tech;

namespace Global.Core.BLL
{
    public class initalDataDAL
    {
        internal bool checkDuplicateLookupGroup(BLL.initialDataBLL lookUpDataBLL, Lumex.Tech.LumexDBPlayer db)
        {
            bool status = true;
            DataTable dt = new DataTable();
            try
            {

                db.AddParameters("@ElementName", lookUpDataBLL.ElementGroupName.Trim());
                dt = db.ExecuteDataTable("[CHECK_DUPLICATE_ELEMENT_GROUP]", true);
                if (dt.Rows.Count > 0)
                {
                    status = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return status;
        }



        internal DataTable SaveLookUpGroup(initialDataBLL lookUpDataBLL, LumexDBPlayer db)
        {
            DataTable dt = new DataTable();
            try
            {
                db.AddParameters("@ElementGrpName", lookUpDataBLL.ElementGroupName.Trim());
                db.AddParameters("@Description", lookUpDataBLL.ElementGroupDes.Trim());
                db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId"));
                db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());
                dt = db.ExecuteDataTable("[INSERT_ELEMENT_GROUP]", true);
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        internal DataTable GetElementGroupList(LumexDBPlayer db)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = db.ExecuteDataTable("[GET_ELEMENT_GROUP_LIST]", false);


            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        internal void UpdateLookUpGroup(initialDataBLL lookUpDataBLL, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@ElementGrpId", lookUpDataBLL.ElementGroupId.Trim());
                db.AddParameters("@ElementGrpName", lookUpDataBLL.ElementGroupName.Trim());
                db.AddParameters("@Description", lookUpDataBLL.ElementGroupDes.Trim());
                db.AddParameters("@ModifiedBy", LumexSessionManager.Get("ActiveUserId"));
                db.AddParameters("@ModifiedFrom", LumexLibraryManager.GetTerminal());
                db.ExecuteNonQuery("[UPDATE_ELEMENT_GROUP]", true);
            }
            catch (Exception)
            {

                throw;
            }

        }

        internal DataTable GetElementGroupNameIdList(LumexDBPlayer db)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = db.ExecuteDataTable("[GET_ELEMENT_GROUP_NAME_ID_LIST]", false);


            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        internal bool checkDuplicateLookupData(initialDataBLL lookUpDataBLL, LumexDBPlayer db)
        {
            bool status = true;
            DataTable dt = new DataTable();
            try
            {
                db.AddParameters("@ElementGrpId", lookUpDataBLL.ElementGroupId.Trim());
                db.AddParameters("@ElementName", lookUpDataBLL.ElementDataName.Trim());
                dt = db.ExecuteDataTable("[CHECK_DUPLICATE_ELEMENT_DATA]", true);
                if (dt.Rows.Count > 0)
                {
                    status = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return status;
        }

        internal DataTable SaveLookUpElementData(initialDataBLL lookUpDataBLL, LumexDBPlayer db)
        {
            DataTable dt = new DataTable();
            try
            {

                db.AddParameters("@ElementName", lookUpDataBLL.ElementDataName.Trim());
                db.AddParameters("@ElementGrpId", lookUpDataBLL.ElementGroupId.Trim());
                db.AddParameters("@Suffix", lookUpDataBLL.ElementDataDescp.Trim());
                db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId"));
                db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());
                dt = db.ExecuteDataTable("[INSERT_ELEMENT_DATA]", true);
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }



        internal DataTable GetElementDataListByGroupId(initialDataBLL lookUpDataBLL, LumexDBPlayer db)
        {
            DataTable dt = new DataTable();
            try
            {
                db.AddParameters("@GroupId", lookUpDataBLL.ElementGroupId.Trim());
                dt = db.ExecuteDataTable("[GET_ELEMENT_DATA_LIST_BY_GROUP_ID]", true);


            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        internal void UpdateLookUpElementData(initialDataBLL lookUpDataBLL, LumexDBPlayer db)
        {
            try
            {

                db.AddParameters("@ElementId", lookUpDataBLL.ElementDataId.Trim());
                db.AddParameters("@ElementName", lookUpDataBLL.ElementDataName.Trim());
                db.AddParameters("@ElementGrpId", lookUpDataBLL.ElementGroupId.Trim());
                db.AddParameters("@Suffix", lookUpDataBLL.ElementDataDescp.Trim());
                db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId"));
                db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());
                db.ExecuteNonQuery("[UPDATE_ELEMENT_DATA]", true);
            }
            catch (Exception)
            {

                throw;
            }

        }

        internal DataTable GetlookupdataNameIdbyGroup(initialDataBLL lookUpDataBLL, LumexDBPlayer db)
        {
            DataTable dt = new DataTable();
            try
            {
                db.AddParameters("@GroupId", lookUpDataBLL.ElementGroupId.Trim());
                dt = db.ExecuteDataTable("[GET_ELEMENT_NAME_ID_LIST_BY_GROUP_ID]", true);


            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        internal DataTable GetElementDataList(LumexDBPlayer db)
        {
            DataTable dt = new DataTable();
            try
            {
                // db.AddParameters("@GroupId", lookUpDataBLL.ElementGroupId.Trim());
                dt = db.ExecuteDataTable("[GET_ELEMENT_DATA_LIST]", false);


            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }



        internal DataTable GetElementDataById(initialDataBLL initialDataBLL, LumexDBPlayer db)
        {
            DataTable dt = new DataTable();
            try
            {
                db.AddParameters("@Id", initialDataBLL.ElementDataId.Trim());
                dt = db.ExecuteDataTable("[GET_ELEMENT_DATA_BY_ID]", true);


            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }
    }
}
