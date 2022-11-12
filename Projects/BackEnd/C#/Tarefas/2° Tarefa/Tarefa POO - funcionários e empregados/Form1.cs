using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tarefa_POO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonAno_Click(object sender, EventArgs e)
        {
            // dar a possibilidade de mudar cada idade ou mudar de todas
            // (afinal está passando um ano) de uma vez, diretamente no Pessoa?
            Pessoa passarAno = new Pessoa();
            passarAno.Niver();
        }

        private void comboBoxDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            // coloco o valor do imposto de renda por aqui? não né?
            // afinal, eu já fiz o esquema do set, talvez o imposto de renda
            // no construtor seja desnecessário né? ou não?
            Funcionário funcionário = new Funcionário("Renato", "Logística", "12/4/2012",
            "67.299.364-2", 1500, false);
            Empregado empregado = new Empregado("Josefino",64, 2700, 0.7,17);
            Fornecedor fornecedor = new Fornecedor("Zé Bob",45, 340, 300); 
            // 340 = Crédito, 300 = Dívida, não sei qual seria um valor interessante
            // para colocar
            Administrador administrador = new Administrador("Carol",32, 3999, 0.22, 48, 250);
            // o 250 é o ajudasCusto e eu não sei qual seria a quantidade ideal para colocar


            // Variáveis -

            // Funcionário 
            string FuncInfo = funcionário.Mostrar();           
            // Empregado 
            string EmpregadoNome = empregado.Nome;
            string EmpregadoIdade = empregado.Idade.ToString();
            string EmpregadoNumSeção = empregado.NumSeção.ToString();
            string EmpregadoSalário = empregado.calcularSal().ToString();
            // Administrador           
            string AdministradorNome = administrador.Nome; 
            string AdministradorIdade = administrador.Idade.ToString();
            string AdministradorNumSeção = administrador.NumSeção.ToString();
            string AdministradorSalário = administrador.calcularSal().ToString();
            // Fornecedor 
            string fornecedorNome = fornecedor.Nome;
            string fornecedorIdade = fornecedor.Idade.ToString();

            if (comboBoxDropDown.SelectedIndex != 0)
            {
                FuncInfo = "";
            }
            if (comboBoxDropDown.SelectedIndex == 0)
            {
                // Funcionário             
                labelFuncInfoResp.Text = FuncInfo;
            }
            if (comboBoxDropDown.SelectedIndex == 1)
            {
                // Empregado                
                labelNomeResp.Text = EmpregadoNome;
                labelIdadeResp.Text = EmpregadoIdade;
                labelSeçãoResp.Text = EmpregadoNumSeção;
                labelSalárioResp.Text = EmpregadoSalário;               
            }
            if (comboBoxDropDown.SelectedIndex != 1)
            {
                EmpregadoNome = "";
                EmpregadoIdade = ""; 
                EmpregadoNumSeção = "";
                EmpregadoSalário = "";
            }
      
            if (comboBoxDropDown.SelectedIndex == 2)
            {
                // Administrador
                labelNomeResp.Text = AdministradorNome;
                labelIdadeResp.Text = AdministradorIdade;
                labelSeçãoResp.Text = AdministradorNumSeção;
                labelSalárioResp.Text = AdministradorSalário;
            }
            if (comboBoxDropDown.SelectedIndex != 2)
            {
                AdministradorNome = "";
                AdministradorIdade = "";
                AdministradorNumSeção = "";
                AdministradorSalário = "";
            }
            if (comboBoxDropDown.SelectedIndex == 3)
            {
                // Fornecedor
                labelNomeResp.Text = fornecedorNome;
                labelIdadeResp.Text = fornecedorIdade;
                labelfornecedorResp.Text = fornecedor.ObterValor().ToString();
            }
            if (comboBoxDropDown.SelectedIndex != 3)
            {
                fornecedorNome = "";
                fornecedorIdade = "";
                labelfornecedorResp.Text = "";               
            }
        }

        private void labelSalário_Click(object sender, EventArgs e)
        {

        }

        private void buttonDemitir_Click(object sender, EventArgs e)
        {
            Funcionário funcionário = new Funcionário();
            funcionário.Demitir();
        }

        private void buttonBonificar_Click(object sender, EventArgs e)
        {
            Funcionário funcionário = new Funcionário();
            funcionário.Bonificar(2.7); 
            // porcentagem de bonificação do Funcionário, coloquei uma quantidade aleatória
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void labelSeçãoResp_Click(object sender, EventArgs e)
        {

        }

        private void labelFornecedor_Click(object sender, EventArgs e)
        {

        }
    }
}
