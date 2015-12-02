using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lumex.Tech;
using Global.Core.BLL;
using System.Data;

namespace Global.Core.DAL
{
    public class genologyDAL
    {
        internal System.Data.DataTable find(string UserId, LumexDBPlayer db)
        {
            DataTable dt = new DataTable();
            try
            {
                db.AddParameters("@UserId", UserId);
                // dt = db.ExecuteDataTable("SELECT [Serial],[UserId],[RefferId],[PleacementId],[PlacePosition],[StakeId],[StakeKey],[JoinDate],[isChecked],[CheckedDate],[ActiveDate],[JoinFrom],[ActiveFrom] FROM [dbo].[tblStakeJoining] where PleacementId=@UserId ");

                dt = db.ExecuteDataTable("[GET_PLACED_USER_BY_PLACEMENT_ID]", true);
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        internal DataTable getStakeJoiningList(LumexDBPlayer db)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = db.ExecuteDataTable("[GET_STAKE_JOINING_LIST]", false);
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        internal DataTable getMatchingNodeList(LumexDBPlayer db)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = db.ExecuteDataTable("SELECT [Serial],[NodeID],[ChildId],[Amount],[IsCalculate],[InsertDate],[CalculateDate],Position FROM [dbo].[tblMatchingNode]");
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        internal DataTable insertIntoNodeList(DataTable dt, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@UserId",dt.Rows[0][0].ToString());
                db.AddParameters("@Node", dt);
                DataTable dt1 = db.ExecuteDataTable("[INSERT_NODE_LIST]", true);
                return dt1;
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal DataTable getNodeList(LumexDBPlayer db)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = db.ExecuteDataTable("SELECT DISTINCT [NodeID] from [dbo].[tblMatchingNode]");
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        internal DataTable getNodeLeftRightAmount(string UserId, LumexDBPlayer db)
        {
            DataTable dt = new DataTable();
            try
            {
                db.AddParameters("@UserId", UserId);
                dt = db.ExecuteDataTable("SELECT ISNULL(sum(case Position when 'L' then ISNULL( Amount,0) end),0) as LeftAmount,ISNULL(sum(case Position when 'R' then ISNULL( Amount,0) end),0) as RightAmount FROM [dbo].[tblMatchingNode]where NodeID=@UserId and [IsCalculate]='No'");
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        internal DataTable CalculateMatchingCommission(string UserId, decimal leftAmount, decimal rightAmount, LumexDBPlayer db)
        {
            DataTable dt = new DataTable();
            try
            {
                db.AddParameters("@UserId", UserId);
                db.AddParameters("@TotalLeft", leftAmount);
                db.AddParameters("@TotalRight", rightAmount);
                db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());

                dt = db.ExecuteDataTable("[INSERT_RECEIVE_PAYMENT_WHEN_MATCHING_COMMISSION]", true);
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        internal DataTable getStakeJoiningParentList(LumexDBPlayer db)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = db.ExecuteDataTable("SELECT DISTINCT [PleacementId] FROM [dbo].[tblStakeJoining]");
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }
    }
}
