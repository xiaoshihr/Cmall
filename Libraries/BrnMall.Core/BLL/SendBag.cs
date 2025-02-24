﻿/**  版本信息模板在安装目录下，可自行修改。
* SendBag.cs
*
* 功 能： N/A
* 类 名： SendBag
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/4/7 星期四 14:13:25   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Collections.Generic;
using BrnMall.Core.Common;
using BrnMall.Core.Model;
namespace BrnMall.Core.BLL
{
	/// <summary>
	/// 用户表
	/// </summary>
	public partial class SendBag
	{
		private readonly BrnMall.Core.DAL.SendBag dal=new BrnMall.Core.DAL.SendBag();
		public SendBag()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			return dal.Exists(ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(BrnMall.Core.Model.SendBag model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(BrnMall.Core.Model.SendBag model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			return dal.Delete(ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			return dal.DeleteList(IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public BrnMall.Core.Model.SendBag GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public BrnMall.Core.Model.SendBag GetModelByCache(int ID)
		{
			
			string CacheKey = "SendBagModel-" + ID;
            object objModel = BrnMall.Core.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ID);
					if (objModel != null)
					{
                        int ModelCache = BrnMall.Core.Common.ConfigHelper.GetConfigInt("ModelCache");
                        BrnMall.Core.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (BrnMall.Core.Model.SendBag)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<BrnMall.Core.Model.SendBag> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<BrnMall.Core.Model.SendBag> DataTableToList(DataTable dt)
		{
			List<BrnMall.Core.Model.SendBag> modelList = new List<BrnMall.Core.Model.SendBag>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				BrnMall.Core.Model.SendBag model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}
        /// <summary>
		/// 获得数据列表
		/// </summary>
		public List<BrnMall.Core.Model.SendBag> DataTableToList1(DataTable dt)
        {
            List<BrnMall.Core.Model.SendBag> modelList = new List<BrnMall.Core.Model.SendBag>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                BrnMall.Core.Model.SendBag model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel1(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}

        /// <summary>
        /// 获得关健字查询分页数据(搜索用到)
        /// </summary>
        public DataSet GetSearch(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetSearch(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }
        /// <summary>
        /// 分页获取实体类
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="strWhere"></param>
        /// <param name="filedOrder"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public List<Model.SendBag> GetModelList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            DataSet ds = dal.GetSearch(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
            return DataTableToList1(ds.Tables[0]);
        }
        /// <summary>
        /// 分页获取实体类
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="strWhere"></param>
        /// <param name="filedOrder"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public List<Model.SendBag> GetModelListByS(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            DataSet ds = dal.GetSearchByS(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
            return DataTableToList1(ds.Tables[0]);
        }
        public int GetRecordSum(string strWhere)
        {
            return dal.GetRecordSum(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

