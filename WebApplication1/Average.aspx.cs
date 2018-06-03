using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Model;

namespace WebApplication1
{
    public partial class Average : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string aver = Request.QueryString["average"];
            if (!String.IsNullOrEmpty(aver))
            {
                if (aver.Equals("instructor"))
                {
                    instructorGrid.Visible = true;
                } else if (aver.Equals("course"))
                {
                    courseGrid.Visible = true;
                }

            }
        }

        protected void instAverBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Average?average=instructor");

        }

        protected void courseAverBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Average?average=course");
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable instructorGrid_GetData()
        {
            PennCoursesEntities1 db = new PennCoursesEntities1();

            var query = from s in db.course_evals
                        group s.InstructorQuality by s.InstructorName into ins
                        select new
                        {
                            Instructor = ins.Key,
                            Average = ins.Average(),
                            CourseNumber = ins.Count()

                        };
            query = query.OrderByDescending(q => q.Average);
            return query;

         
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

            var query = from s in db.course_evals
                        group new { s.CourseQuality, s.StudentNumber } by s.CourseName into crs
                        select new
                        {
                            Course = crs.Key,
                            Average = crs.Average(s => s.CourseQuality),
                            CourseNumber = crs.Count(),
                            AverageSNum = crs.Average(s => s.StudentNumber)

                        };
            query = query.OrderByDescending(q => q.Average);
            return query;
        }
    }
}