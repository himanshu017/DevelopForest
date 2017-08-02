using System;
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
                cmd.Parameters.AddWithValue("@CSSClass", model.CSSClass);
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
                Database db = new SqlDatabase(config);
                DbCommand dbCommand = db.GetStoredProcCommand("sp_MasterSubCategory");
                db.AddInParameter(dbCommand, "SubCategoryId", DbType.String, model.SubCategoryId);
                db.AddInParameter(dbCommand, "SubCategoryName", DbType.String, model.SubCategoryName);
                db.AddInParameter(dbCommand, "CategoryID", DbType.String, model.CategoryId);
                db.AddInParameter(dbCommand, "CreatedBy", DbType.String, model.CreatedBy);
                db.AddInParameter(dbCommand, "ModifiedBy", DbType.String, model.ModifiedBy);
                con.Open();
                return db.ExecuteNonQuery(dbCommand);
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
                CategoryName = String.IsNullOrEmpty(row.Field<string>("CategoryName")) ? "not found" : row.Field<string>("CategoryName"),
                CSSClass= String.IsNullOrEmpty(row.Field<string>("CSSClass")) ? "" : row.Field<string>("CSSClass"),
                CurrentIndex= (Int16)row["CurrentIndex"]
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
        public List<CategoryModel> SubCategoryList()
        {
            Database db = new SqlDatabase(config);
            DbCommand dbCommand = db.GetSqlStringCommand(SQLBase.SQL_GET_SubCategories);
            DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];
            List<CategoryModel> SubCategoryList = dt.AsEnumerable().Select(row => new CategoryModel
            {
                SubCategoryId = (Int32)row["SubCategoryID"],
                SubCategoryName = String.IsNullOrEmpty(row.Field<string>("SubCategoryName")) ? "not found" : row.Field<string>("SubCategoryName"),
                CategoryId = (Int32)row["CategoryId"],
                CategoryName = String.IsNullOrEmpty(row.Field<string>("CategoryName")) ? "not found" : row.Field<string>("CategoryName"),
                CurrentIndex = (Int16)row["CurrentIndex"]
            }).ToList();
            return SubCategoryList;
        }

        public int DeleteSubCategory(int SubCategoryId)
        {
            Database db = new SqlDatabase(config);
            DbCommand dbCommand = db.GetSqlStringCommand(SQLBase.SQL_DeleteSubCategoriesById);
            db.AddInParameter(dbCommand, "SubCategoryId", DbType.String, SubCategoryId);
            return db.ExecuteNonQuery(dbCommand);
        }

        public bool UpdateCategoryIndex(CategoryModel list)
        {
            Database db = new SqlDatabase(config);
            DbCommand dbCommand = db.GetSqlStringCommand(SQLBase.SQL_Update_Category_Index);
           
                db.AddInParameter(dbCommand, "CategoryID", DbType.Int32, list.CategoryId);
                db.AddInParameter(dbCommand, "Index", DbType.Int16, list.CurrentIndex);
                db.ExecuteNonQuery(dbCommand);
            return true;
        }

        public void UpdateThemeTrends(bool IsTrending ,int ThemeID)
        {
            Database db = new SqlDatabase(config);
            DbCommand dbCommand = db.GetSqlStringCommand(SQLBase.SQL_Update_ThemeTrends);

            db.AddInParameter(dbCommand, "IsTrending", DbType.Boolean, IsTrending);
            db.AddInParameter(dbCommand, "ThemeID", DbType.Int32, ThemeID);
            db.ExecuteNonQuery(dbCommand);
        }

        public bool UpdateSubCategoryIndex(CategoryModel list)
        {
            Database db = new SqlDatabase(config);
            DbCommand dbCommand = db.GetSqlStringCommand(SQLBase.SQL_Update_SubCategory_Index);

            db.AddInParameter(dbCommand, "SubCategoryID", DbType.Int32, list.SubCategoryId);
            db.AddInParameter(dbCommand, "Index", DbType.Int16, list.CurrentIndex);
            db.ExecuteNonQuery(dbCommand);
            return true;
        }
    }
}
