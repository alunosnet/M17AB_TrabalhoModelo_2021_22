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
    public partial class EditarLivro : System.Web.UI.Page
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

            //consultar a bd para recolher os dados do livro
            if (IsPostBack) return;
            try
            {
                int id=int.Parse(Request["id"].ToString());
                //consulta bd
                Livro lv = new Livro();
                DataTable dados = lv.devolveLivro(id);
                if (dados == null || dados.Rows.Count != 1)
                {
                    throw new Exception("Livro não existe");
                }
                tbNome.Text = dados.Rows[0]["nome"].ToString();
                tbAutor.Text = dados.Rows[0]["autor"].ToString();
                tbAno.Text = dados.Rows[0]["ano"].ToString();
                tbData.Text = DateTime.Parse(dados.Rows[0]["data_aquisicao"].ToString()).ToString("yyyy-MM-dd");
                tbPreco.Text = Decimal.Parse(dados.Rows[0]["preco"].ToString()).ToString();
                tbTipo.Text = dados.Rows[0]["tipo"].ToString();
                imgCapa.ImageUrl = @"~\Public\Images\" + id + ".jpg";
            }
            catch
            {
                lbErro.Text = "O livro indicado não existe.";
                ScriptManager.RegisterStartupScript(this, typeof(Page),
                    "Redirecionar", "returnMain('/Admin/Livros/Livros.aspx')", true);
            }
        }
        //Atualizar
        protected void btAdicionar_Click(object sender, EventArgs e)
        {
            //validar os dados
            try
            {
                string nome = tbNome.Text.Trim();
                if (string.IsNullOrEmpty(nome) || nome.Length < 3)
                {
                    throw new Exception("O nome não é válido.");
                }
                string autor = tbAutor.Text.Trim();
                if (string.IsNullOrEmpty(autor) || autor.Length < 3)
                {
                    throw new Exception("O autor não é válido.");
                }
                int ano = int.Parse(tbAno.Text);
                if (ano > DateTime.Now.Year || ano < 0)
                {
                    throw new Exception("O ano não é válido.");
                }
                DateTime data = DateTime.Parse(tbData.Text);
                if (data > DateTime.Now)
                {
                    throw new Exception("A data não pode ser superior a data atual.");
                }
                decimal preco = decimal.Parse(tbPreco.Text);
                if (preco < 0 || preco >= 100)
                {
                    throw new Exception("O preço deve ser suprrior ou igual a zero.");
                }
                string tipo = tbTipo.Text;
                int estado = 1;

                int id = int.Parse(Request["id"].ToString());
                //adicionar à bd
                Livro lv = new Livro(id, nome, ano, data, preco, autor, tipo, estado);
                lv.Atualizar();

                //guardar o ficheiro da capa
                if (fuCapa.HasFile)
                {
                    string ficheiro = Server.MapPath(@"~\Public\Images\");
                    ficheiro += id + ".jpg";
                    fuCapa.SaveAs(ficheiro);
                }
            }
            catch (Exception ex)
            {
                lbErro.Text = "Ocorreu o seguinte erro: " + ex.Message;
                return;
            }
            
            lbErro.Text = "Registo atualizado com sucesso";
            ScriptManager.RegisterStartupScript(this, typeof(Page),
                    "Redirecionar", "returnMain('/Admin/Livros/Livros.aspx')", true);
        }
    }
}