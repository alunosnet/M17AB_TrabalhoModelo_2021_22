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
    public partial class utilizadores : System.Web.UI.Page
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
            if (!IsPostBack)
                AtualizaGrid();
        }

        protected void btAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                //validar o form
                string email = tbEmail.Text.Trim();
                if(email==String.Empty || email.Contains("@")==false ||
                    email.Contains('.') == false)
                {
                    throw new Exception("O email indicado não é válido");
                }
                string nome = tbNome.Text;
                string nif = tbNif.Text;
                string morada = tbMorada.Text;
                string password = tbPassword.Text;
                int perfil = int.Parse(ddPerfil.SelectedValue);
                //adicionar à bd
                Utilizador utilizador = new Utilizador();
                utilizador.nome = nome;
                utilizador.email = email;
                utilizador.nif = nif;
                utilizador.morada = morada;
                utilizador.password = password;
                utilizador.perfil = perfil;
                utilizador.Adicionar();
                //limpar o form
                tbEmail.Text = "";
                tbNome.Text="";
                tbNif.Text = "";
                tbMorada.Text = "";
                tbPassword.Text = "";
                //atualizar a grid
                AtualizaGrid();
            }
            catch(Exception erro)
            {
                lbErro.Text = "Ocorreu o seguinte erro: " + erro.Message;
            }
        }

        private void AtualizaGrid()
        {
            //limpar gridview
            gvUtilizadores.Columns.Clear();
            gvUtilizadores.DataSource = null;
            gvUtilizadores.DataBind();

            Utilizador utilizador = new Utilizador();
            DataTable dados = utilizador.ListaTodosUtilizadores();

            gvUtilizadores.DataSource = dados;
            gvUtilizadores.AutoGenerateColumns = false;

            //remover
            DataColumn dcRemover = new DataColumn();
            dcRemover.ColumnName = "Remover";
            dcRemover.DataType = Type.GetType("System.String");
            dados.Columns.Add(dcRemover);
            //editar
            DataColumn dcEditar = new DataColumn();
            dcEditar.ColumnName = "Editar";
            dcEditar.DataType = Type.GetType("System.String");
            dados.Columns.Add(dcEditar);
            //bloquear
            DataColumn dcBloquear = new DataColumn();
            dcBloquear.ColumnName = "Bloquear";
            dcBloquear.DataType = Type.GetType("System.String");
            dados.Columns.Add(dcBloquear);
            //histórico
            DataColumn dcHistorico = new DataColumn();
            dcHistorico.ColumnName = "Historico";
            dcHistorico.DataType = Type.GetType("System.String");
            dados.Columns.Add(dcHistorico);

            //Formatação Gridview
            //remover
            HyperLinkField hlRemover = new HyperLinkField();
            hlRemover.HeaderText = "Remover";
            hlRemover.DataTextField = "Remover";    //columnname do datatable
            hlRemover.Text = "Remover";
            //RemoverUtilizador.aspx?id={0}
            hlRemover.DataNavigateUrlFormatString = "RemoverUtilizador.aspx?id={0}";
            hlRemover.DataNavigateUrlFields = new string[] { "id" };
            hlRemover.ControlStyle.CssClass = "btn btn-danger";
            gvUtilizadores.Columns.Add(hlRemover);
            //editar
            HyperLinkField hlEditar = new HyperLinkField();
            hlEditar.HeaderText = "Editar";
            hlEditar.DataTextField = "Editar";    //columnname do datatable
            hlEditar.Text = "Editar";
            hlEditar.DataNavigateUrlFormatString = "EditarUtilizador.aspx?id={0}";
            hlEditar.DataNavigateUrlFields = new string[] { "id" };
            hlEditar.ControlStyle.CssClass = "btn btn-info";
            gvUtilizadores.Columns.Add(hlEditar);
            //bloquear
            HyperLinkField hlBloquear = new HyperLinkField();
            hlBloquear.HeaderText = "Bloquear";
            hlBloquear.DataTextField = "Bloquear";    //columnname do datatable
            hlBloquear.Text = "Bloquear";
            hlBloquear.DataNavigateUrlFormatString = "BloquearUtilizador.aspx?id={0}";
            hlBloquear.DataNavigateUrlFields = new string[] { "id" };
            hlBloquear.ControlStyle.CssClass = "btn btn-danger";
            gvUtilizadores.Columns.Add(hlBloquear);
            //histórico
            HyperLinkField hlHistorico = new HyperLinkField();
            hlHistorico.HeaderText = "Histórico";
            hlHistorico.DataTextField = "Historico";    //columnname do datatable
            hlHistorico.Text = "Histórico";
            hlHistorico.DataNavigateUrlFormatString = "HistoricoUtilizador.aspx?id={0}";
            hlHistorico.DataNavigateUrlFields = new string[] { "id" };
            hlHistorico.ControlStyle.CssClass = "btn btn-success";
            gvUtilizadores.Columns.Add(hlHistorico);

            //id
            BoundField bfId = new BoundField();
            bfId.HeaderText = "Id";
            bfId.DataField = "id";
            bfId.Visible = false;
            gvUtilizadores.Columns.Add(bfId);
            //email
            BoundField bfEmail = new BoundField();
            bfEmail.HeaderText = "Email";
            bfEmail.DataField = "email";
            gvUtilizadores.Columns.Add(bfEmail);
            //nome
            BoundField bfNome = new BoundField();
            bfNome.HeaderText = "Nome";
            bfNome.DataField = "nome";
            gvUtilizadores.Columns.Add(bfNome);
            //Morada
            BoundField bfMorada = new BoundField();
            bfMorada.HeaderText = "Morada";
            bfMorada.DataField = "morada";
            gvUtilizadores.Columns.Add(bfMorada);
            //nif
            BoundField bfNif = new BoundField();
            bfNif.HeaderText = "Nif";
            bfNif.DataField = "nif";
            gvUtilizadores.Columns.Add(bfNif);
            //estado
            BoundField bfEstado = new BoundField();
            bfEstado.HeaderText = "Estado";
            bfEstado.DataField = "estado";
            gvUtilizadores.Columns.Add(bfEstado);
            //perfil
            BoundField bfPerfil = new BoundField();
            bfPerfil.HeaderText = "Perfil";
            bfPerfil.DataField = "perfil";
            gvUtilizadores.Columns.Add(bfPerfil);
            //Como fazer para aparecer a palavra Admin ou utilizador em vez 0 e 1?
            gvUtilizadores.DataBind();
        }
    }
}