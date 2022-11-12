using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonCalcular_Click(object sender, EventArgs e)
        {
            double piscina, suite, total, venda, porcentagem;
            int qtdVagas;

                qtdVagas = Convert.ToInt32(LblrespQTDVagas.Text);
                if (qtdVagas < 1)
                {
                    LblErro.Text = "A quantidade de vagas disponíveis é zero " + TextBoxDono.Text;
                    Lblrespporcentagem.Text = "";
                    LblrespQTDrooms.Text = "";
                    TextBoxVenda.Text = "";
                }
                else
                {
                    LblErro.Text = "";
                    venda = Convert.ToDouble(TextBoxVenda.Text.Replace('.', ','));
                    porcentagem = Convert.ToDouble(Lblrespporcentagem.Text);
                    total = venda * porcentagem;
                    if (Session["piscina"] != null)
                    {
                        piscina = Convert.ToDouble(Session["piscina"]);
                        total = total + piscina;
                    }
                    if (Session["suite"] != null)
                    {
                        suite = Convert.ToDouble(Session["suite"]);
                        total = total + (total * suite);
                    }
                    TextBoxAluguel.Text = total.ToString();
                }                
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["piscina"] = RadioButtonList1.SelectedValue;
        }

        protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["suite"] = RadioButtonList2.SelectedValue;
        }

        protected void ButtonCadastrar_Click(object sender, EventArgs e)
        {
            LblMSG.Text = "Casa cadastrada com Sucesso " + TextBoxDono.Text;
            LblErro.Text = "";
            Lblrespporcentagem.Text = "";
            LblrespQTDrooms.Text = "";
            LblrespQTDVagas.Text = "";
            TextBoxVenda.Text = "";
            TextBoxAluguel.Text = "";
        }

        protected void DropDownListImóvel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListImóvel.SelectedIndex == 1)
            {
                LblrespQTDVagas.Text = "4";
                LblrespQTDrooms.Text = "5";
                Lblrespporcentagem.Text = "0.25";
            }

            if (DropDownListImóvel.SelectedIndex == 2)
            {
                LblrespQTDVagas.Text = "2";
                LblrespQTDrooms.Text = "3";
                Lblrespporcentagem.Text = "0.17";
            }

            if (DropDownListImóvel.SelectedIndex == 3)
            {
                LblrespQTDVagas.Text = "2";
                LblrespQTDrooms.Text = "2";
                Lblrespporcentagem.Text = "0.10";
            }
        }
    }
}