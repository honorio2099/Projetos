using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tarefa___ex_1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonConvênio_Click(object sender, EventArgs e)
        {            
            if (DropDownListConvênio.SelectedIndex == 1)
            {
                LabelrespValueconvenio.Text = "25,50";
            }
            if (DropDownListConvênio.SelectedIndex == 2)
            {
                LabelrespValueconvenio.Text = "31,80";
            }
            if (DropDownListConvênio.SelectedIndex == 3)
            {
                LabelrespValueconvenio.Text = "98,30";
            }
        }

        protected void ButtonMédico_Click(object sender, EventArgs e)
        {
            if (DropDownListMédico.SelectedIndex == 1)
            {
                LblrespEspecialidade.Text = "Pediatra";
                lblrespValueMedico.Text = "100,00";
                lblrespQTDvagas.Text = "10";
            }

            if (DropDownListMédico.SelectedIndex == 2)
            {
                LblrespEspecialidade.Text = "Dematorlogista";
                lblrespValueMedico.Text = "90,00";
                lblrespQTDvagas.Text = "30";
            }

            if (DropDownListMédico.SelectedIndex == 3)
            {
                LblrespEspecialidade.Text = "Pneumologista";
                lblrespValueMedico.Text = "150,00";
                lblrespQTDvagas.Text = "12";
            }
        }

        protected void Buttoncalculate_Click(object sender, EventArgs e)
        {
            try
            {
                double vleconvenio, vleMedico, calculation;
                int qtdvagas;

                //////////////////////////////////////////////////////////////
                if (RadioButtonEmergência.Checked == false && RadioButtonNormal.Checked == false)
                {
                    Lblerror1.Visible = true;
                    Lblerror2.Visible = true;
                    LabelerrorMSG.Visible = true;
                }
                else
                {
                    Lblerror1.Visible = false;
                    Lblerror2.Visible = false;
                    LabelerrorMSG.Visible = false;

                    if (DropDownListMédico.SelectedIndex == 1)
                    {
                        qtdvagas = Convert.ToInt32(lblrespQTDvagas.Text);
                        if (qtdvagas < 0)
                        {
                            LabelErro.Text = "Você deve escolher outro médico";
                            lblrespValueMedico.Text = "";
                        }
                    }
                    else
                    {
                        LabelErro.Text = "";
                        lblrespValueMedico.Text = "100,00";
                        vleconvenio = Convert.ToDouble(LabelrespValueconvenio.Text);
                        vleMedico = Convert.ToDouble(lblrespValueMedico.Text);

                        if (RadioButtonEmergência.Checked)
                        {
                            calculation = vleconvenio + vleMedico + 50;
                        }
                        else
                        {
                            calculation = vleconvenio + vleMedico;
                        }
                        TextBoxCalculate.Text = calculation.ToString();
                    }

                    if (DropDownListMédico.SelectedIndex == 2)
                    {
                        qtdvagas = Convert.ToInt32(lblrespQTDvagas.Text);
                        if (qtdvagas < 0)
                        {
                            LabelErro.Text = "Você deve escolher outro médico";
                            lblrespValueMedico.Text = "";
                        }
                    }
                    else
                    {
                        LabelErro.Text = "";
                        lblrespValueMedico.Text = "90,00";
                        vleconvenio = Convert.ToDouble(LabelrespValueconvenio.Text);
                        vleMedico = Convert.ToDouble(lblrespValueMedico.Text);

                        if (RadioButtonEmergência.Checked)
                        {
                            calculation = vleconvenio + vleMedico + 50;
                        }
                        else
                        {
                            calculation = vleconvenio + vleMedico;
                        }
                        TextBoxCalculate.Text = calculation.ToString();
                    }

                    if (DropDownListMédico.SelectedIndex == 3)
                    {
                        qtdvagas = Convert.ToInt32(lblrespQTDvagas.Text);
                        if (qtdvagas < 0)
                        {
                            LabelErro.Text = "Você deve escolher outro médico";
                            lblrespValueMedico.Text = "";
                        }
                    }
                    else
                    {
                        LabelErro.Text = "";
                        lblrespValueMedico.Text = "150,00";
                        vleconvenio = Convert.ToDouble(LabelrespValueconvenio.Text);
                        vleMedico = Convert.ToDouble(lblrespValueMedico.Text);

                        if (RadioButtonEmergência.Checked)
                        {
                            calculation = vleconvenio + vleMedico + 50;
                        }
                        else
                        {
                            calculation = vleconvenio + vleMedico;
                        }
                        TextBoxCalculate.Text = calculation.ToString();
                    }
                }
                //////////////////////////////////////////////////////////////
            }
            catch
            {
                LabelErro.Text = "Se tiver selecionado Convênio ou Médico, favor apertar OK!";
            }
        }

        protected void ButtonCadastrar_Click(object sender, EventArgs e)
        {
            LabelMensagem.Text = "Consulta Efetuada com Sucesso " + TextBoxname.Text + "!!!";
            TextBoxCalculate.Text = "";
            LabelErro.Text = "";
            lblrespValueMedico.Text = "";
            LabelrespValueconvenio.Text = "";
            lblrespQTDvagas.Text = "";
            LblrespEspecialidade.Text = "";
        }

    }
}