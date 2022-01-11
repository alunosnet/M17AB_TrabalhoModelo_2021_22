using M17AB_TrabalhoModelo_2021_22.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_TrabalhoModelo_2021_22.User
{
    public partial class User : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                divEditar.Visible = false;
                MostrarPerfil();
            }
        }

        private void MostrarPerfil()
        {
            int id = int.Parse(Session["id"].ToString());
            Utilizador utilizador = new Utilizador();
            DataTable dados=utilizador.devolveDadosUtilizador(id);
            if (divPerfil.Visible)
            {
                lbNome.Text = dados.Rows[0]["nome"].ToString();
                lbMorada.Text= dados.Rows[0]["morada"].ToString();
                lbNif.Text= dados.Rows[0]["nif"].ToString();
            }
            else
            {
                tbNome.Text = dados.Rows[0]["nome"].ToString();
                tbMorada.Text = dados.Rows[0]["morada"].ToString();
                tbNif.Text = dados.Rows[0]["nif"].ToString();
            }
        }

        protected void btEditar_Click(object sender, EventArgs e)
        {
            divPerfil.Visible = false;
            divEditar.Visible = true;
            MostrarPerfil();
        }

        protected void btAtualizar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Session["id"].ToString());
            string nome = tbNome.Text;
            string morada = tbMorada.Text;
            string nif = tbNif.Text;
            //validar dados
            Utilizador utilizador = new Utilizador();
            utilizador.nome = nome;
            utilizador.morada = morada;
            utilizador.nif = nif;
            utilizador.id = id;
            utilizador.atualizarUtilizador();
            divPerfil.Visible = true;
            divEditar.Visible = false;
            MostrarPerfil();
        }

        protected void btCancelar_Click(object sender, EventArgs e)
        {
            divPerfil.Visible = true;
            divEditar.Visible = false;
            MostrarPerfil();
        }
    }
}