using M17AB_TrabalhoModelo_2021_22.Classes;
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
            if (UserLogin.ValidarSessao(Session, Request, "1") == false)
                Response.Redirect("~/index.aspx");

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