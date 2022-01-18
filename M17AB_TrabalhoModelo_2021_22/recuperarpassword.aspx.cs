using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_TrabalhoModelo_2021_22
{
    public partial class recuperarpassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btRecuperar_Click(object sender, EventArgs e)
        {
            try
            {
                string password = tbPassword.Text.Trim();
                if (password == String.Empty)
                    throw new Exception();

            }
            catch
            {

            }
            Response.Redirect("index.aspx");
        }
    }
}