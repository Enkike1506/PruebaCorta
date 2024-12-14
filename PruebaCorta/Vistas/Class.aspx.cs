using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PruebaCorta.CapaLogica;
using PruebaCorta.CapaModelo;
using System.Net;

namespace PruebaCorta.Vistas
{
    public partial class Class : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        public static void MostrarAlerta(Page page, string message)
        {
            string script = $"<script type='text/javascript'>alert('{message}');</script>";
            ClientScriptManager cs = page.ClientScript;
            cs.RegisterStartupScript(page.GetType(), "AlertScript", script);
        }

        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Class"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridViewClass.DataSource = dt;
                            GridViewClass.DataBind();
                        }
                    }
                }
            }
        }

        protected void bAdd_Click(object sender, EventArgs e)
        {
            ClsClass.SchoolId = int.Parse(tSchoolId.Text);
            ClsClass.ClassName = tName.Text;
            ClsClass.Description = tDescription.Text;
            if (Business_Class.AddClass(ClsClass.SchoolId, ClsClass.ClassName, ClsClass.Description) > 0)
            {
                MostrarAlerta(this, "Class added");
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error adding class");
            }
        }

        protected void bEdit_Click(object sender, EventArgs e)
        {
            ClsClass.ClassId = int.Parse(tId.Text);
            ClsClass.SchoolId = int.Parse(tSchoolId.Text);
            ClsClass.ClassName = tName.Text;
            ClsClass.Description = tDescription.Text;
            if (Business_Class.EditClass(ClsClass.ClassId, ClsClass.SchoolId, ClsClass.ClassName, ClsClass.Description) > 0)
            {
                MostrarAlerta(this, "Class edited");
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error editing class");
            }
        }

        protected void bDelete_Click(object sender, EventArgs e)
        {
            ClsClass.ClassId = int.Parse(tId.Text);
            if (Business_Class.DeleteClass(ClsClass.ClassId) > 0)
            {
                MostrarAlerta(this, "Class deleted");
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error deleting class");
            }
        }
    }
}