﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperForest.IDAL;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using DeveloperForest.Model;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace DeveloperForest.DAL
{
    public class CategoryDAL : ICategoryDAL
    {
        public static string config = ConfigurationManager.ConnectionStrings["connStr"].ToString();
        SqlConnection con = new SqlConnection(config);

        public int InsertCategory(Model.CategoryModel model)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_MasterCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CategoryId", model.CategoryId);
                cmd.Parameters.AddWithValue("@CategoryName", model.CategoryName);
                cmd.Parameters.AddWithValue("@CreatedBy", model.CreatedBy);
                cmd.Parameters.AddWithValue("@ModifiedBy", model.ModifiedBy);
                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
            finally
            {
                con.Close();
            }
        }

        public int InsertSubCategory(CategoryModel model)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_MasterSubCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SubCategoryName", model.CategoryName);
                cmd.Parameters.AddWithValue("@CategoryID", model.CreatedBy);
                cmd.Parameters.AddWithValue("@CreatedBy", model.ModifiedBy);
                cmd.Parameters.AddWithValue("@ModifiedBy", model.ModifiedBy);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }

        public List<CategoryModel> CategoryList()
        {
            Database db = new SqlDatabase(config);
            DbCommand dbCommand = db.GetSqlStringCommand(SQLBase.SQL_GET_Categories);
            DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];
            List<CategoryModel> target = dt.AsEnumerable().Select(row => new CategoryModel
            {
                CategoryId = (Int32)row["CategoryId"],
                CategoryName = String.IsNullOrEmpty(row.Field<string>("CategoryName")) ? "not found" : row.Field<string>("CategoryName")
                
            }).ToList();
            return target;
        }


        public int DeleteCategory(int CategoryID)
        {
            Database db = new SqlDatabase(config);
            DbCommand dbCommand = db.GetSqlStringCommand(SQLBase.SQL_DeleteCategoriesByID);
            db.AddInParameter(dbCommand, "CategoryId", DbType.String, CategoryID);
            return db.ExecuteNonQuery(dbCommand);
           
        }

    }
}
