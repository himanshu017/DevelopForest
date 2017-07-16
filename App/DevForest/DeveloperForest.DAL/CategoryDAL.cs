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
namespace DeveloperForest.DAL
{
    public class CategoryDAL : ICategoryDAL
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr"].ConnectionString);

        public int InsertCategory(Model.CategoryModel model)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_MasterCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CategoryName", model.CategoryName);
                cmd.Parameters.AddWithValue("@CreatedBy", model.CreatedBy);
                cmd.Parameters.AddWithValue("@ModifiedBy", model.ModifiedBy);
                con.Open();
                return cmd.ExecuteNonQuery();
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
            SqlDataAdapter adp = new SqlDataAdapter("Select CategoryId,CategoryName from MasterCategory", con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt.AsEnumerable().Select(m=>m.)
        }
    }
}
