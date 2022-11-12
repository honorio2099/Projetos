using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Contador_de_Clicks
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           LabelSESSresp.Text = Session["qtdClicks"].ToString();

           if (ViewState["qtdClicksVS"] != null)
            {
              LabelViewresp.Text = Session["qtdClicksVS"].ToString();
            }
        }
    }
}