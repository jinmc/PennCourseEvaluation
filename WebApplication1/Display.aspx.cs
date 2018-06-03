using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Model;

namespace WebApplication1
{
    public partial class Display : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var sort = Request.QueryString["sort"];

            if (!String.IsNullOrEmpty(sort))
            {
                testLbl.Text = sort;
                courseGrid.Visible = true;
            }

        }


        protected void sort2Btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Display?sort=sort2");
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable courseGrid_GetData()
        {
            PennCoursesEntities1 db = new PennCoursesEntities1();

            string sort = Request.QueryString["sort"];
            string asc = Request.QueryString["ASC"];

            var query = db.course_evals.Select(s => s);

            if (sort.Equals("sort1") && asc.Equals("true"))
            {
                query = query.OrderBy(q => q.Difficulty);
            } else if (sort.Equals("sort1") && asc.Equals("false"))
            {
                query = query.OrderByDescending(q => q.Difficulty);
            } else if (sort.Equals("sort2") && asc.Equals("true"))
            {
                query = query.OrderBy(q => q.CourseQuality);
            } else if (sort.Equals("sort2") && asc.Equals("false"))
            {
                query = query.OrderByDescending(q => q.CourseQuality);
            }


            return query;
        }

        protected void sort1ASCBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Display?sort=sort1&ASC=true");
        }

        protected void sort2DESCBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Display?sort=sort2&ASC=false");
        }

        protected void sort2ASCBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Display?sort=sort2&ASC=true");
        }

        protected void sort1DESCBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Display?sort=sort1&ASC=false");
        }

        protected void courseGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
        }
    }
}