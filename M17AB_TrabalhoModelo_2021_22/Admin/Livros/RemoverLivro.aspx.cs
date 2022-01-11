using M17AB_TrabalhoModelo_2021_22.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_TrabalhoModelo_2021_22.Admin.Livros
{
    public partial class RemoverLivro : System.Web.UI.Page
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
            try
            {
                //querystring id
                int id = int.Parse(Request["id"].ToString());

                //consulta bd
                Livro lv = new Livro();
                DataTable dados = lv.devolveLivro(id);
                if (dados == null || dados.Rows.Count != 1)
                {
                    throw new Exception("Livro não existe");
                }
                lbNLivro.Text = dados.Rows[0]["nlivro"].ToString();
                lbNome.Text = dados.Rows[0]["nome"].ToString();
                imgCapa.ImageUrl = @"~\Public\Images\" + id + ".jpg";
                imgCapa.Width = 200;
            }
            catch
            {
                Response.Redirect("~/Admin/Livros/Livros.aspx");
            }
        }

        protected void btRemover_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Request["id"].ToString());
            Livro lv = new Livro();
            lv.removerLivro(id);
            //apagar a capa
            string ficheiro = Server.MapPath(@"~\Public\Images\");
            ficheiro += id + ".jpg";
            if (File.Exists(ficheiro))
                File.Delete(ficheiro);
            Response.Redirect("~/Admin/Livros/Livros.aspx");
        }
    }
}