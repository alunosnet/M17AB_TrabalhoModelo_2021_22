using M17AB_TrabalhoModelo_2021_22.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_TrabalhoModelo_2021_22.Admin.Livros
{
    public partial class Livros : System.Web.UI.Page
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

            ConfigurarGrid();

            AtualizarGrid();
        }

        private void AtualizarGrid()
        {
            /* Livro lv = new Livro();
             GvLivros.DataSource = lv.ListaTodosLivros();
             GvLivros.DataBind();*/
            //limpar as colunas
            GvLivros.Columns.Clear();
            //consultar bd
            Livro lv = new Livro();
            DataTable dados = lv.ListaTodosLivros();
           //adicionar duas colunas (remover/editar)
           DataColumn dcRemover=new DataColumn();
            dcRemover.ColumnName = "Remover";
            dcRemover.DataType = Type.GetType("System.String");
            dados.Columns.Add(dcRemover);

            DataColumn dcEditar = new DataColumn();
            dcEditar.ColumnName = "Editar";
            dcEditar.DataType = Type.GetType("System.String");
            dados.Columns.Add(dcEditar);

            //colunas da gridview
            GvLivros.DataSource = dados;
            GvLivros.AutoGenerateColumns = false;

            //Remover
            HyperLinkField hlRemover=new HyperLinkField();
            //cabeçalho
            hlRemover.HeaderText = "Remover";
            //campo da datatable
            hlRemover.DataTextField = "Remover";
            //texto clicável
            hlRemover.Text = "Remover...";
            //format string
            hlRemover.DataNavigateUrlFormatString = "RemoverLivro.aspx?id={0}";
            //campo da format string
            hlRemover.DataNavigateUrlFields = new string[] {"nlivro" };
            //adicionar a grid
            GvLivros.Columns.Add(hlRemover);

            //Editar
            HyperLinkField hlEditar= new HyperLinkField();
            hlEditar.HeaderText = "Editar";
            hlEditar.DataTextField = "Editar";
            hlEditar.Text = "Editar...";
            hlEditar.DataNavigateUrlFormatString = "EditarLivro.aspx?id={0}";
            hlEditar.DataNavigateUrlFields = new string[] { "nlivro" };
            GvLivros.Columns.Add(hlEditar);
            
            //nlivro
            BoundField bfNlivro=new BoundField();
            bfNlivro.HeaderText = "Nº Livro";
            bfNlivro.DataField = "nlivro";
            GvLivros.Columns.Add(bfNlivro);
            //Nome
            BoundField bfNome=new BoundField();
            bfNome.HeaderText = "Nome";
            bfNome.DataField = "nome";
            GvLivros.Columns.Add(bfNome);
            
            //Ano
            BoundField bfAno = new BoundField();
            bfAno.HeaderText = "Ano";
            bfAno.DataField = "ano";
            GvLivros.Columns.Add(bfAno);
            //Data Aquisição
            BoundField bfData = new BoundField();
            bfData.HeaderText = "Data de Aquisição";
            bfData.DataField = "data_aquisicao";
            bfData.DataFormatString = "{0:dd-MM-yyyy}";
            GvLivros.Columns.Add(bfData);
            //Preço
            BoundField bfPreco = new BoundField();
            bfPreco.HeaderText = "Preço";
            bfPreco.DataField = "preco";
            bfPreco.DataFormatString = "{0:C}";
            GvLivros.Columns.Add(bfPreco);
            //Autor
            BoundField bfAutor= new BoundField();
            bfAutor.HeaderText = "Autor";
            bfAutor.DataField = "autor";
            GvLivros.Columns.Add(bfAutor);
            //tipo
            BoundField bfTipo = new BoundField();
            bfTipo.HeaderText = "Tipo";
            bfTipo.DataField = "tipo";
            GvLivros.Columns.Add(bfTipo);
            //Estado
            BoundField bfEstado = new BoundField();
            bfEstado.HeaderText = "Estado";
            bfEstado.DataField = "estado";
            GvLivros.Columns.Add(bfEstado);
            //Capa
            ImageField capa = new ImageField();
            capa.HeaderText = "Capa";
            int aleatorio = new Random().Next(99999);
            capa.DataImageUrlFormatString = "~/Public/Images/{0}.jpg?"+aleatorio;
            capa.DataImageUrlField = "nlivro";
            capa.ControlStyle.Width = 200;
            GvLivros.Columns.Add(capa);
            
            //refresh gridview
            GvLivros.DataBind();
        }

        private void ConfigurarGrid()
        {
            //paginação
            GvLivros.AllowPaging= true;
            GvLivros.PageSize = 5;
            GvLivros.PageIndexChanging += GvLivros_PageIndexChanging;
        }

        private void GvLivros_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvLivros.PageIndex=e.NewPageIndex;
            AtualizarGrid();
        }

        protected void btAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                //TODO: Validar os dados
                string nome = tbNome.Text.Trim();
                if(string.IsNullOrEmpty(nome) || nome.Length < 3)
                {
                    throw new Exception("O nome não é válido.");
                }
                string autor = tbAutor.Text.Trim();
                if (string.IsNullOrEmpty(autor) || autor.Length < 3)
                {
                    throw new Exception("O autor não é válido.");
                }
                int ano = int.Parse(tbAno.Text);
                if (ano > DateTime.Now.Year ||ano<0)
                {
                    throw new Exception("O ano não é válido.");
                }
                DateTime data = DateTime.Parse(tbData.Text);
                if (data > DateTime.Now)
                {
                    throw new Exception("A data não pode ser superior a data atual.");
                }
                decimal preco = decimal.Parse(tbPreco.Text);
                if(preco<0 || preco >= 100)
                {
                    throw new Exception("O preço deve ser suprrior ou igual a zero.");
                }
                string tipo = tbTipo.Text;
                int estado = 1;
                //adicionar à bd
                Livro lv = new Livro(0, nome, ano, data, preco, autor, tipo, estado);
                int nlivro = lv.Adicionar();

                //guardar o ficheiro da capa
                string ficheiro = Server.MapPath(@"~\Public\Images\");
                ficheiro += nlivro + ".jpg";
                fuCapa.SaveAs(ficheiro);
            }catch(Exception ex)
            {
                lbErro.Text = "Ocorreu o seguinte erro: " + ex.Message;
                return;
            }
            //limpar o form
            tbAno.Text = "";
            tbNome.Text = "";
            tbAutor.Text = "";
            tbTipo.Text = "";
            tbPreco.Text = "";
            tbData.Text = "";

            //atualizar a grid
            AtualizarGrid();

            lbErro.Text = "Registo inserido com sucesso";
        }
    }
}