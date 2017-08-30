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
using System.IO;
namespace DeveloperForest.DAL
{
    public class ThemeDAL : IThemeDAL
    {
        public static string config = ConfigurationManager.ConnectionStrings["connStr"].ToString();
        SqlConnection con = new SqlConnection(config);
        Database db = new SqlDatabase(config);
        public int InsertTheme(Model.ThemeModel model)
        {
            try
            {
                DbCommand dbCommand = db.GetStoredProcCommand("sp_Themes");
                db.AddInParameter(dbCommand, "ThemeId", DbType.String, model.ThemeId);
                db.AddInParameter(dbCommand, "CategoryId", DbType.String, model.CategoryId);
                db.AddInParameter(dbCommand, "SubCategoryId", DbType.String, model.SubCategoryId);
                db.AddInParameter(dbCommand, "Title", DbType.String, model.Title);
                db.AddInParameter(dbCommand, "Description", DbType.String, model.Description);
                db.AddInParameter(dbCommand, "DownloadLink", DbType.String, model.Downloadlink);
                db.AddInParameter(dbCommand, "Demolink", DbType.String, model.DemoLink);
                db.AddInParameter(dbCommand, "CreatedBy", DbType.String, model.CreatedBy);
                db.AddInParameter(dbCommand, "ModifiedBy", DbType.String, model.ModifiedBy);
                db.AddInParameter(dbCommand, "ImageName", DbType.String, model.ImageName);
                db.AddInParameter(dbCommand, "RelatedLink1", DbType.String, model.RelatedLink1);
                db.AddInParameter(dbCommand, "RelatedLink2", DbType.String, model.RelatedLink2);
                db.AddInParameter(dbCommand, "RelatedLink3", DbType.String, model.RelatedLink3);
                db.AddInParameter(dbCommand, "RelatedLink4", DbType.String, model.RelatedLink4);
                db.AddInParameter(dbCommand, "RelatedLink5", DbType.String, model.RelatedLink5);
                con.Open();
                return db.ExecuteNonQuery(dbCommand);
            }
            finally
            {
                con.Close();
            }
        }


        public List<ThemeModel> ThemeList()
        {
            DbCommand dbCommand = db.GetSqlStringCommand(SQLBase.SQL_GET_Themes);
            DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];
            List<ThemeModel> ThemeList = dt.AsEnumerable().Select(row => new ThemeModel
            {
                ThemeId = (Int32)row["ThemeId"],
                Title = String.IsNullOrEmpty(row.Field<string>("Title")) ? "" : row.Field<string>("Title"),
                CategoryName = String.IsNullOrEmpty(row.Field<string>("CategoryName")) ? "" : row.Field<string>("CategoryName"),
                SubCategoryName = String.IsNullOrEmpty(row.Field<string>("SubCategoryName")) ? "" : row.Field<string>("SubCategoryName"),
                CategoryId = (Int32)row["CategoryId"],
                SubCategoryId = (Int32)row["SubCategoryId"],
                DemoLink = String.IsNullOrEmpty(row.Field<string>("DemoLink")) ? "" : row.Field<string>("DemoLink"),
                Downloadlink = String.IsNullOrEmpty(row.Field<string>("DownloadLink")) ? "" : row.Field<string>("DownloadLink"),
                Description = String.IsNullOrEmpty(row.Field<string>("Description")) ? "" : row.Field<string>("Description"),
                ImageName = String.IsNullOrEmpty(row.Field<string>("ImageName")) ? "" : row.Field<string>("ImageName"),
                PreImageName = String.IsNullOrEmpty(row.Field<string>("ImageName")) ? "" : row.Field<string>("ImageName"),
                BaseURL = ConfigurationManager.AppSettings["BaseURL"].ToString(),
                RelatedLink1 = String.IsNullOrEmpty(row.Field<string>("RelatedLink1")) ? "" : row.Field<string>("RelatedLink1"),
                RelatedLink2 = String.IsNullOrEmpty(row.Field<string>("RelatedLink2")) ? "" : row.Field<string>("RelatedLink2"),
                RelatedLink3 = String.IsNullOrEmpty(row.Field<string>("RelatedLink3")) ? "" : row.Field<string>("RelatedLink3"),
                RelatedLink4 = String.IsNullOrEmpty(row.Field<string>("RelatedLink4")) ? "" : row.Field<string>("RelatedLink4"),
                RelatedLink5 = String.IsNullOrEmpty(row.Field<string>("RelatedLink5")) ? "" : row.Field<string>("RelatedLink5")
            }).ToList();
            return ThemeList;
        }

        public string DeleteThemeById(int id)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("sp_DeleteThemeById");
            db.AddInParameter(dbCommand, "ThemeId", DbType.Int16, id);
            db.AddOutParameter(dbCommand, "ImageName", DbType.String, 300);
            var ImageName = db.ExecuteScalar(dbCommand);
            return ImageName.ToString();

        }
    }
}
