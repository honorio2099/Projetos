using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ddlRefeicao_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btnRefeicaoOK_Click(object sender, EventArgs e)
    {
        if (ddlRefeicao.SelectedIndex == 0)
        {
            lblMistura.Text = "Bife";
            lblQtdDisponivel.Text = "23";
            lblPrecoVenda.Text = "9,30";
        }
        if (ddlRefeicao.SelectedIndex == 1)
        {
            lblMistura.Text = "Frango Assado";
            lblQtdDisponivel.Text = "12";
            lblPrecoVenda.Text = "14,60";
        }
        if (ddlRefeicao.SelectedIndex == 2)
        {
            lblMistura.Text = "Pernil";
            lblQtdDisponivel.Text = "5";
            lblPrecoVenda.Text = "15,00";
        }
    }

    protected void btnCalcularTotal_Click(object sender, EventArgs e)
    {
        try 
        { 
        int qtdDes, qtdDis;
        double preco, totalpagar;
        //qtd's desejadas e e disponíveis
        qtdDes = Convert.ToInt32(txtQtdDesejada.Text);
        qtdDis = Convert.ToInt32(txtQtdDesejada.Text);
        // preço refeição
        preco = Convert.ToDouble(lblPrecoVenda.Text);
        // verificar é possível vender (qtdDes <= qtdDis)
        if (qtdDes <= qtdDis)
        {
            totalpagar = qtdDes * preco;

            if (ddlFormaEntrega.SelectedIndex == 0)
            {
                totalpagar = totalpagar + (totalpagar * 0.10);
            }
            if (ddlFormaEntrega.SelectedIndex == 1)
            {
                totalpagar = totalpagar;
            }
            if (ddlFormaEntrega.SelectedIndex == 2)
            {
                totalpagar = totalpagar - (totalpagar * 0.10);
            }

            lblTotalPagar.Text = totalpagar.ToString("#0.00");
        }
        else
        {
            lblErro.Text = "Quantidade Insuficiente!! (Escolha um número abaixo disso.)";
            txtQtdDesejada.Text = "";
            lblTotalPagar.Text = "";
        }
        }
        catch
        {
            lblErro.Text = "Favor verificar os campos digitados";
        }
    }

    protected void btnComprar_Click(object sender, EventArgs e)
    {
        lblComprar.Text = "Compra efetuada com Sucesso!!!";
        lblErro.Text = "";
        lblMistura.Text = "";
        lblPrecoVenda.Text = "";
        lblQtdDisponivel.Text = "";
        lblTotalPagar.Text = "";
    }
}