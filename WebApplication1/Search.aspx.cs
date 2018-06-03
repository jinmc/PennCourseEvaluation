using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Model;

namespace WebApplication1
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable searchGrid_GetData()
        {
            PennCoursesEntities1 db = new PennCoursesEntities1();

            string keyWord = Request.QueryString["keyword"];

            if (!String.IsNullOrEmpty(keyWord))
            {
                var query = db.course_evals.Where(c => c.InstructorName.Contains(keyWord) || c.CourseName.Contains(keyWord));
                return query;
            }

            return null;
        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            string kw = keywordTBox.Text.ToUpper();
            Response.Redirect($"~/Search?keyword={kw}");
        }

        protected void searchGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;

        }
    }
}