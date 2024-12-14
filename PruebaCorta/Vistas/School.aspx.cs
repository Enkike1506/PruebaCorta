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

namespace PruebaCorta.Vistas
{
    public partial class School : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM School"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridViewSchool.DataSource = dt;
                            GridViewSchool.DataBind();
                        }
                    }
                }
            }
        }

        protected void bAdd_Click(object sender, EventArgs e)
        {
            ClsSchool.SchoolName = tName.Text;
            ClsSchool.Description = tDescription.Text;
            ClsSchool.Address = tAddress.Text;
            ClsSchool.Phone = tPhone.Text;
            ClsSchool.PostCode = tPostCode.Text;
            ClsSchool.PostAddress = tPostAddress.Text;
            if (Business_School.AddSchool(ClsSchool.SchoolName, ClsSchool.Description, ClsSchool.Address, ClsSchool.Phone, ClsSchool.PostCode, ClsSchool.PostAddress) > 0)
            {
                MostrarAlerta(this, "School added");
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error adding school");
            }
        }

        protected void bEdit_Click(object sender, EventArgs e)
        {
            ClsSchool.SchoolId = int.Parse(tId.Text);
            ClsSchool.SchoolName = tName.Text;
            ClsSchool.Description = tDescription.Text;
            ClsSchool.Address = tAddress.Text;
            ClsSchool.Phone = tPhone.Text;
            ClsSchool.PostCode = tPostCode.Text;
            ClsSchool.PostAddress = tPostAddress.Text;
            if (Business_School.EditSchool(ClsSchool.SchoolId, ClsSchool.SchoolName, ClsSchool.Description, ClsSchool.Address, ClsSchool.Phone, ClsSchool.PostCode, ClsSchool.PostAddress) > 0)
            {
                MostrarAlerta(this, "School edited");
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error editing school");
            }
        }

        protected void bDelete_Click(object sender, EventArgs e)
        {
            ClsSchool.SchoolId = int.Parse(tId.Text);
            if (Business_School.DeleteSchool(ClsSchool.SchoolId) > 0)
            {
                MostrarAlerta(this, "School deleted");
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error deleting school");
            }
        }
    }
}