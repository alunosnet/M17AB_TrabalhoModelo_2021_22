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
    public partial class Emprestimos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //validar sessão
            if(UserLogin.ValidarSessao(Session,Request,"1")==false)
                Response.Redirect("~/index.aspx");


            ConfigurarGrid();
            AtualizarGrid();
        }

        private void ConfigurarGrid()
        {
            GvLivros.RowCommand += GvLivros_RowCommand;
        }

        private void GvLivros_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //reservar um livro
            int linha = int.Parse(e.CommandArgument as string);
            int idlivro = int.Parse(GvLivros.Rows[linha].Cells[1].Text);
            int idutilizador = int.Parse(Session["id"].ToString());
            if (e.CommandName == "reservar")
            {
                Emprestimo emp = new Emprestimo();
                emp.adicionarReserva(idlivro, idutilizador, DateTime.Now.AddDays(7));
                AtualizarGrid();
            }
        }

        private void AtualizarGrid()
        {
            GvLivros.Columns.Clear();
            GvLivros.DataSource = null;
            GvLivros.DataBind();

            Livro livro = new Livro();
            GvLivros.DataSource = livro.listaTodosLivrosDisponiveis();

            //botão reservar
            ButtonField bt = new ButtonField();
            bt.HeaderText = "Reservar";
            bt.Text = "Reservar";
            bt.ButtonType = ButtonType.Button;
            bt.CommandName = "reservar";
            bt.ControlStyle.CssClass = "btn btn-danger";
            GvLivros.Columns.Add(bt);
            GvLivros.DataBind();
        }
    }
}