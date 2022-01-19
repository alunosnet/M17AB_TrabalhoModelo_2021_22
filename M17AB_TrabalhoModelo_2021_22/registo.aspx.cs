using M17AB_TrabalhoModelo_2021_22.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_TrabalhoModelo_2021_22
{
    public partial class registo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btRegistar_Click(object sender, EventArgs e)
        {
            try
            {
                //validar dados
                string nome = tbNome.Text;
                string email = tbEmail.Text;
                string morada = tbMorada.Text;
                string nif = tbNif.Text;
                string ppasse = tbPassword.Text;
                int perfil = 1;

                //validar recaptcha
                var respostaRecaptcha = Request.Form["g-Recaptcha-Response"];
                var valido = ReCaptcha.Validate(respostaRecaptcha);
                if (valido == false)
                    throw new Exception("Tem de provar que não é um robot");

                //inserir o utilizador na bd
                Utilizador util = new Utilizador();
                util.nome = nome;
                util.email = email;
                util.morada = morada;
                util.nif = nif;
                util.password = ppasse;
                util.perfil = perfil;
                util.Adicionar();
                lbErro.Text = "Registado com sucesso.";

                //redirecionar
                ScriptManager.RegisterStartupScript(this, typeof(Page),
                    "Redirecionar", "returnMain('/index.aspx')", true);
            }
            catch(Exception erro)
            {
                lbErro.Text = "Ocorreu o seguinte erro: " + erro.Message;
            }
        }
    }
}