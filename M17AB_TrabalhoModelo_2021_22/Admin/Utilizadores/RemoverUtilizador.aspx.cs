using M17AB_TrabalhoModelo_2021_22.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_TrabalhoModelo_2021_22.Admin.Utilizadores
{
    public partial class RemoverUtilizador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //validar sessão
            if (Session["perfil"] == null ||
                Session["perfil"].ToString() != "0" ||
                Session["ip"].ToString() != Request.UserHostAddress ||
                Session["useragent"].ToString() != Request.UserAgent)
            {
                Session.Clear();
                Response.Redirect("~/index.aspx");
            }
            if (IsPostBack) return;

            try
            {
                int id = int.Parse(Request["id"].ToString());
                Utilizador uti = new Utilizador();

                DataTable dados = uti.devolveDadosUtilizador(id);

                if (dados == null || dados.Rows.Count != 1)
                {
                    throw new Exception("O utilizador não existe");
                }

                lbNome.Text = dados.Rows[0]["nome"].ToString();
                lbId.Text = dados.Rows[0]["id"].ToString();
            }

            catch
            {
                Response.Redirect("~/Admin/Utilizadores/utilizadores.aspx");
            }
        }

        protected void btnRemover_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Request["id"].ToString());
            Utilizador uti = new Utilizador();

            uti.removerUtilizador(id);
            Response.Redirect("~/Admin/Utilizadores/utilizadores.aspx");
        }
    }
}