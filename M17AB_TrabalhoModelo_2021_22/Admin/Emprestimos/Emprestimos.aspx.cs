using M17AB_TrabalhoModelo_2021_22.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_TrabalhoModelo_2021_22.Admin.Emprestimos
{
    public partial class Emprestimos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //validar sessão
            if(Session["perfil"]==null || 
                Session["perfil"].ToString()!="0" ||
                Session["ip"].ToString() != Request.UserHostAddress ||
                Session["useragent"].ToString()!= Request.UserAgent)
            {
                Session.Clear();
                Response.Redirect("~/index.aspx");
            }

            ConfigurarGrid();

            if (IsPostBack) return;

            AtualizarGrid();
            AtualizarDDLivros();
            AtualizarDDLeitores();

        }

        private void AtualizarDDLeitores()
        {
            Utilizador utilizador = new Utilizador();
            DDLeitor.Items.Clear();
            DataTable dados = utilizador.listaTodosUtilizadoresDisponiveis();
            foreach(DataRow linha in dados.Rows)
            {
                DDLeitor.Items.Add(
                    new ListItem(linha["nome"].ToString(),
                                linha["id"].ToString()
                    ));
            }
        }

        private void AtualizarDDLivros()
        {
            Livro lv = new Livro();
            DDLivro.Items.Clear();
            DataTable dados = lv.listaTodosLivrosDisponiveis();
            foreach (DataRow linha in dados.Rows)
            {
                DDLivro.Items.Add(
                    new ListItem(linha["nome"].ToString(),
                                linha["nlivro"].ToString()
                    ));
            }
        }

        private void AtualizarGrid()
        {
            Emprestimo emp = new Emprestimo();
            GvEmprestimos.Columns.Clear();
            GvEmprestimos.DataSource = null;
            GvEmprestimos.DataBind();
//            GvEmprestimos.DataSource = emp.listaTodosEmprestimosComNomes();

            //botão do comando
            //receber
            ButtonField bfReceber = new ButtonField();
            bfReceber.HeaderText = "Receber livro"; //texto cabeçalho
            bfReceber.Text = "Receber";             //texto botão
            bfReceber.ButtonType = ButtonType.Button;   //tipo
            bfReceber.CommandName = "receber";
            bfReceber.ControlStyle.CssClass = "btn btn-info";
            GvEmprestimos.Columns.Add(bfReceber);
            //email
            ButtonField bfEmail = new ButtonField();
            bfEmail.HeaderText = "Enviar email"; //texto cabeçalho
            bfEmail.Text = "Email";             //texto botão
            bfEmail.ButtonType = ButtonType.Button;   //tipo
            bfEmail.CommandName = "email";
            bfEmail.ControlStyle.CssClass = "btn btn-info";
            GvEmprestimos.Columns.Add(bfEmail);

            GvEmprestimos.DataSource = emp.listaTodosEmprestimosComNomes();
            GvEmprestimos.AutoGenerateColumns = true;
            GvEmprestimos.DataBind();

        }

        private void ConfigurarGrid()
        {
            //paginação
            GvEmprestimos.AllowPaging = true;
            GvEmprestimos.PageSize = 5;
            GvEmprestimos.PageIndexChanging += GvEmprestimos_PageIndexChanging;
            //botões comando
            GvEmprestimos.RowCommand += GvEmprestimos_RowCommand;
        }

        private void GvEmprestimos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //muda de página
            if (e.CommandName == "Page") return;

            //linha
            int linha = int.Parse(e.CommandArgument.ToString());
            //id do empréstimo
            int idemprestimo = int.Parse(GvEmprestimos.Rows[linha].Cells[2].Text);
            Emprestimo emp = new Emprestimo();
            if (e.CommandName == "receber")
            {
                emp.alterarEstadoEmprestimo(idemprestimo);
                AtualizarDDLeitores();
                AtualizarDDLivros();
                AtualizarGrid();
            }
            if (e.CommandName == "email")
            {
                string email = ConfigurationManager.AppSettings["MeuEmail"].ToString();
                string password = ConfigurationManager.AppSettings["MinhaPassword"].ToString();
                string assunto = "Empréstimo de livro";
                string texto = "Caro leitor deve devolver o livro que tem emprestado.";
                DataTable dados = emp.devolveDadosEmprestimo(idemprestimo);
                int idleitor = int.Parse(dados.Rows[0]["idutilizador"].ToString());
                DataTable dadosLeitor = new Utilizador().devolveDadosUtilizador(idleitor);
                string emailLeitor = dadosLeitor.Rows[0]["email"].ToString();
                Helper.enviarMail(email,password,emailLeitor,assunto,texto);
            }
        }

        private void GvEmprestimos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvEmprestimos.PageIndex = e.NewPageIndex;
            AtualizarGrid();
        }

        protected void btAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                Emprestimo emp = new Emprestimo();
                int nlivro = int.Parse(DDLivro.SelectedValue);
                int nleitor = int.Parse(DDLeitor.SelectedValue);
                DateTime data = DateTime.Parse(tbData.Text);
                emp.adicionarEmprestimo(nlivro, nleitor, data);
                AtualizarDDLeitores();
                AtualizarDDLivros();
                AtualizarGrid();
                lbErro.Text = "O empréstimo foi registado com sucesso.";
            }catch(Exception erro)
            {
                lbErro.Text = "Ocorreu o seguinte erro: "+erro.Message;
                lbErro.CssClass = "alert alert-danger";
            }
        }
    }
}