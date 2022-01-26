using M17AB_TrabalhoModelo_2021_22.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_TrabalhoModelo_2021_22.User.Emprestimos
{
    public partial class historico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //validar sessão
            if (Session["perfil"] == null ||
                Session["perfil"].ToString() != "1" ||
                Session["ip"].ToString() != Request.UserHostAddress ||
                Session["useragent"].ToString() != Request.UserAgent)
            {
                Session.Clear();
                Response.Redirect("~/index.aspx");
            }
            AtualizarGrid();
        }
        private void AtualizarGrid()
        {
            gvHistorico.Columns.Clear();
            gvHistorico.DataSource = null;
            gvHistorico.DataBind();

            int idutilizador = int.Parse(Session["id"].ToString());
            Emprestimo emprestimo = new Emprestimo();
            gvHistorico.DataSource = emprestimo.listaTodosEmprestimosComNomes(idutilizador);
            gvHistorico.DataBind();
        }
    }
}