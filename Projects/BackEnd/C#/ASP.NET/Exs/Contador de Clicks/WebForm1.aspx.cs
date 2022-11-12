using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Contador_de_Clicks
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        // variável global para não precisar iniciá-la com zero caso seja variável local
        int qtdClicks;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonClick_Click(object sender, EventArgs e)
        {
            if (Session["qtdClicks"] != null)
            //recuperar o valor que foi armazenado na SESSION
            qtdClicks = (int)Session["qtdClicks"];
            // se qtdClicks fosse local (estivesse aqui) teria que ser iniciada com zero
            qtdClicks = qtdClicks + 1;
            //armazenar o valor da variável qtdClicks na SESSION
            Session["qtdClicks"] = qtdClicks;
            ViewState["qtdClicksVS"] = qtdClicks;
            LabelrespSESSClicks.Text = qtdClicks.ToString();
            //exibir o valor do ViewState
            LabelrespViewClicks.Text = ViewState["qtdClicksVS"].ToString();
        }

        protected void ButtonTela_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm2.aspx");
        }
    }
}