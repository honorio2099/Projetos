using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            double num;
            num = Convert.ToDouble(TextBox1.Text.Replace('.',','));

            if (num > 0)
            {
                Label1.Text = "Número Positivo";
            }
            if (num == 0)
            {
                Label1.Text = "O Número é igual a Zero";
            }
            if (num < 0)
            {
                Label1.Text = "Número Negativo";
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            double num;
            num = Convert.ToDouble(TextBox1.Text.Replace('.', ','));

            if (num < 0)
            {
                Label1.Text = "Número Negativo";
            }
            else
            {
                if (num > 0)
                {
                    Label1.Text = "Número Positivo";
                }
                else
                {
                    Label1.Text = "O Número é igual a Zero";
                }
            }
        }
    }
}