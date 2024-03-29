﻿using M17AB_TrabalhoModelo_2021_22.Classes;
using M17AB_TrabalhoModelo_2021_22.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_TrabalhoModelo_2021_22.Admin.Utilizadores
{
    public partial class BloquearUtilizador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //validar sessão
            if (UserLogin.ValidarSessao(Session, Request, "0") == false)
                Response.Redirect("~/index.aspx");
            try
            {
                int id = int.Parse(Request["id"].ToString());
                Utilizador utilizador = new Utilizador();
                utilizador.ativarDesativarUtilizador(id);
                Response.Redirect("~/Admin/Utilizadores/Utilizadores.aspx");

            }
            catch
            {

                Response.Redirect("~/Admin/Utilizadores/Utilizadores.aspx");
            }
        }
    }
}