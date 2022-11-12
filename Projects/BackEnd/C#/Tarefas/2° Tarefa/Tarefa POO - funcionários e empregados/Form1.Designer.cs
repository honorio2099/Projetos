
namespace Tarefa_POO
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonAno = new System.Windows.Forms.Button();
            this.comboBoxDropDown = new System.Windows.Forms.ComboBox();
            this.labelInfoDropDrown = new System.Windows.Forms.Label();
            this.labelSpace1 = new System.Windows.Forms.Label();
            this.labelSpace2 = new System.Windows.Forms.Label();
            this.labelNomeResp = new System.Windows.Forms.Label();
            this.labelIdadeResp = new System.Windows.Forms.Label();
            this.labelSalárioResp = new System.Windows.Forms.Label();
            this.labelSeçãoResp = new System.Windows.Forms.Label();
            this.labelFuncInfoResp = new System.Windows.Forms.Label();
            this.labelSpace3 = new System.Windows.Forms.Label();
            this.buttonDemitir = new System.Windows.Forms.Button();
            this.buttonBonificar = new System.Windows.Forms.Button();
            this.labelSpace4 = new System.Windows.Forms.Label();
            this.labelFornecedor = new System.Windows.Forms.Label();
            this.labelfornecedorResp = new System.Windows.Forms.Label();
            this.labelNome = new System.Windows.Forms.Label();
            this.labelIdade = new System.Windows.Forms.Label();
            this.labelSeção = new System.Windows.Forms.Label();
            this.labelSalário = new System.Windows.Forms.Label();
            this.labelFuncInfo = new System.Windows.Forms.Label();
            this.labelFornecedorTitle = new System.Windows.Forms.Label();
            this.labelOBS = new System.Windows.Forms.Label();
            this.labelProblemas = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonAno
            // 
            this.buttonAno.Location = new System.Drawing.Point(34, 79);
            this.buttonAno.Name = "buttonAno";
            this.buttonAno.Size = new System.Drawing.Size(112, 40);
            this.buttonAno.TabIndex = 0;
            this.buttonAno.Text = "Passar um Ano";
            this.buttonAno.UseVisualStyleBackColor = true;
            this.buttonAno.Click += new System.EventHandler(this.buttonAno_Click);
            // 
            // comboBoxDropDown
            // 
            this.comboBoxDropDown.FormattingEnabled = true;
            this.comboBoxDropDown.Items.AddRange(new object[] {
            "Funcionário",
            "Empregado",
            "Administrador",
            "Fornecedor"});
            this.comboBoxDropDown.Location = new System.Drawing.Point(34, 42);
            this.comboBoxDropDown.Name = "comboBoxDropDown";
            this.comboBoxDropDown.Size = new System.Drawing.Size(403, 21);
            this.comboBoxDropDown.TabIndex = 1;
            this.comboBoxDropDown.SelectedIndexChanged += new System.EventHandler(this.comboBoxDropDown_SelectedIndexChanged);
            // 
            // labelInfoDropDrown
            // 
            this.labelInfoDropDrown.AutoSize = true;
            this.labelInfoDropDrown.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInfoDropDrown.Location = new System.Drawing.Point(31, 26);
            this.labelInfoDropDrown.Name = "labelInfoDropDrown";
            this.labelInfoDropDrown.Size = new System.Drawing.Size(403, 13);
            this.labelInfoDropDrown.TabIndex = 2;
            this.labelInfoDropDrown.Text = "Escolha o Associado/Funcionário de Empresa na qual deseja saber as informações:";
            // 
            // labelSpace1
            // 
            this.labelSpace1.AutoSize = true;
            this.labelSpace1.Location = new System.Drawing.Point(31, 122);
            this.labelSpace1.Name = "labelSpace1";
            this.labelSpace1.Size = new System.Drawing.Size(115, 13);
            this.labelSpace1.TabIndex = 3;
            this.labelSpace1.Text = "==================";
            // 
            // labelSpace2
            // 
            this.labelSpace2.AutoSize = true;
            this.labelSpace2.Location = new System.Drawing.Point(31, 161);
            this.labelSpace2.Name = "labelSpace2";
            this.labelSpace2.Size = new System.Drawing.Size(115, 13);
            this.labelSpace2.TabIndex = 4;
            this.labelSpace2.Text = "==================";
            // 
            // labelNomeResp
            // 
            this.labelNomeResp.AutoSize = true;
            this.labelNomeResp.Location = new System.Drawing.Point(79, 135);
            this.labelNomeResp.Name = "labelNomeResp";
            this.labelNomeResp.Size = new System.Drawing.Size(58, 13);
            this.labelNomeResp.TabIndex = 5;
            this.labelNomeResp.Text = "nomeResp";
            // 
            // labelIdadeResp
            // 
            this.labelIdadeResp.AutoSize = true;
            this.labelIdadeResp.Location = new System.Drawing.Point(79, 148);
            this.labelIdadeResp.Name = "labelIdadeResp";
            this.labelIdadeResp.Size = new System.Drawing.Size(59, 13);
            this.labelIdadeResp.TabIndex = 6;
            this.labelIdadeResp.Text = "IdadeResp";
            // 
            // labelSalárioResp
            // 
            this.labelSalárioResp.AutoSize = true;
            this.labelSalárioResp.Location = new System.Drawing.Point(79, 187);
            this.labelSalárioResp.Name = "labelSalárioResp";
            this.labelSalárioResp.Size = new System.Drawing.Size(64, 13);
            this.labelSalárioResp.TabIndex = 7;
            this.labelSalárioResp.Text = "SalárioResp";
            this.labelSalárioResp.Click += new System.EventHandler(this.labelSalário_Click);
            // 
            // labelSeçãoResp
            // 
            this.labelSeçãoResp.AutoSize = true;
            this.labelSeçãoResp.Location = new System.Drawing.Point(79, 174);
            this.labelSeçãoResp.Name = "labelSeçãoResp";
            this.labelSeçãoResp.Size = new System.Drawing.Size(63, 13);
            this.labelSeçãoResp.TabIndex = 8;
            this.labelSeçãoResp.Text = "SeçãoResp";
            this.labelSeçãoResp.Click += new System.EventHandler(this.labelSeçãoResp_Click);
            // 
            // labelFuncInfoResp
            // 
            this.labelFuncInfoResp.AutoSize = true;
            this.labelFuncInfoResp.Location = new System.Drawing.Point(224, 161);
            this.labelFuncInfoResp.Name = "labelFuncInfoResp";
            this.labelFuncInfoResp.Size = new System.Drawing.Size(74, 13);
            this.labelFuncInfoResp.TabIndex = 9;
            this.labelFuncInfoResp.Text = "FuncInfoResp";
            // 
            // labelSpace3
            // 
            this.labelSpace3.AutoSize = true;
            this.labelSpace3.Location = new System.Drawing.Point(31, 200);
            this.labelSpace3.Name = "labelSpace3";
            this.labelSpace3.Size = new System.Drawing.Size(115, 13);
            this.labelSpace3.TabIndex = 10;
            this.labelSpace3.Text = "==================";
            // 
            // buttonDemitir
            // 
            this.buttonDemitir.Location = new System.Drawing.Point(179, 69);
            this.buttonDemitir.Name = "buttonDemitir";
            this.buttonDemitir.Size = new System.Drawing.Size(99, 50);
            this.buttonDemitir.TabIndex = 11;
            this.buttonDemitir.Text = "Demitir o Funcionário";
            this.buttonDemitir.UseVisualStyleBackColor = true;
            this.buttonDemitir.Click += new System.EventHandler(this.buttonDemitir_Click);
            // 
            // buttonBonificar
            // 
            this.buttonBonificar.Location = new System.Drawing.Point(317, 69);
            this.buttonBonificar.Name = "buttonBonificar";
            this.buttonBonificar.Size = new System.Drawing.Size(90, 50);
            this.buttonBonificar.TabIndex = 12;
            this.buttonBonificar.Text = "Bonificar o Funcionário";
            this.buttonBonificar.UseVisualStyleBackColor = true;
            this.buttonBonificar.Click += new System.EventHandler(this.buttonBonificar_Click);
            // 
            // labelSpace4
            // 
            this.labelSpace4.AutoSize = true;
            this.labelSpace4.Location = new System.Drawing.Point(31, 267);
            this.labelSpace4.Name = "labelSpace4";
            this.labelSpace4.Size = new System.Drawing.Size(115, 13);
            this.labelSpace4.TabIndex = 13;
            this.labelSpace4.Text = "==================";
            // 
            // labelFornecedor
            // 
            this.labelFornecedor.Location = new System.Drawing.Point(33, 226);
            this.labelFornecedor.Name = "labelFornecedor";
            this.labelFornecedor.Size = new System.Drawing.Size(100, 41);
            this.labelFornecedor.TabIndex = 14;
            this.labelFornecedor.Text = "Valor da diferença entre o crédito e a dívida:";
            this.labelFornecedor.Click += new System.EventHandler(this.labelFornecedor_Click);
            // 
            // labelfornecedorResp
            // 
            this.labelfornecedorResp.AutoSize = true;
            this.labelfornecedorResp.Location = new System.Drawing.Point(69, 254);
            this.labelfornecedorResp.Name = "labelfornecedorResp";
            this.labelfornecedorResp.Size = new System.Drawing.Size(51, 13);
            this.labelfornecedorResp.TabIndex = 15;
            this.labelfornecedorResp.Text = "diferença";
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.Location = new System.Drawing.Point(31, 135);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(38, 13);
            this.labelNome.TabIndex = 16;
            this.labelNome.Text = "Nome:";
            // 
            // labelIdade
            // 
            this.labelIdade.AutoSize = true;
            this.labelIdade.Location = new System.Drawing.Point(31, 148);
            this.labelIdade.Name = "labelIdade";
            this.labelIdade.Size = new System.Drawing.Size(37, 13);
            this.labelIdade.TabIndex = 17;
            this.labelIdade.Text = "Idade:";
            // 
            // labelSeção
            // 
            this.labelSeção.AutoSize = true;
            this.labelSeção.Location = new System.Drawing.Point(31, 174);
            this.labelSeção.Name = "labelSeção";
            this.labelSeção.Size = new System.Drawing.Size(44, 13);
            this.labelSeção.TabIndex = 18;
            this.labelSeção.Text = "Seção: ";
            // 
            // labelSalário
            // 
            this.labelSalário.AutoSize = true;
            this.labelSalário.Location = new System.Drawing.Point(31, 187);
            this.labelSalário.Name = "labelSalário";
            this.labelSalário.Size = new System.Drawing.Size(45, 13);
            this.labelSalário.TabIndex = 19;
            this.labelSalário.Text = "Salário: ";
            // 
            // labelFuncInfo
            // 
            this.labelFuncInfo.AutoSize = true;
            this.labelFuncInfo.Location = new System.Drawing.Point(224, 135);
            this.labelFuncInfo.Name = "labelFuncInfo";
            this.labelFuncInfo.Size = new System.Drawing.Size(144, 13);
            this.labelFuncInfo.TabIndex = 20;
            this.labelFuncInfo.Text = "Informações de Funcionário: ";
            // 
            // labelFornecedorTitle
            // 
            this.labelFornecedorTitle.AutoSize = true;
            this.labelFornecedorTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFornecedorTitle.Location = new System.Drawing.Point(33, 213);
            this.labelFornecedorTitle.Name = "labelFornecedorTitle";
            this.labelFornecedorTitle.Size = new System.Drawing.Size(67, 13);
            this.labelFornecedorTitle.TabIndex = 21;
            this.labelFornecedorTitle.Text = "Fornecedor -";
            // 
            // labelOBS
            // 
            this.labelOBS.Location = new System.Drawing.Point(31, 280);
            this.labelOBS.Name = "labelOBS";
            this.labelOBS.Size = new System.Drawing.Size(226, 57);
            this.labelOBS.TabIndex = 22;
            this.labelOBS.Text = "Obs: Apenas Empregados e Administradores possuem Seção e Salário. Já o Funcionári" +
    "o comum possui informações totalmente diferentes e únicas.";
            // 
            // labelProblemas
            // 
            this.labelProblemas.Location = new System.Drawing.Point(459, 9);
            this.labelProblemas.Name = "labelProblemas";
            this.labelProblemas.Size = new System.Drawing.Size(314, 54);
            this.labelProblemas.TabIndex = 23;
            this.labelProblemas.Text = resources.GetString("labelProblemas.Text");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelProblemas);
            this.Controls.Add(this.labelOBS);
            this.Controls.Add(this.labelFornecedorTitle);
            this.Controls.Add(this.labelFuncInfo);
            this.Controls.Add(this.labelSalário);
            this.Controls.Add(this.labelSeção);
            this.Controls.Add(this.labelIdade);
            this.Controls.Add(this.labelNome);
            this.Controls.Add(this.labelfornecedorResp);
            this.Controls.Add(this.labelFornecedor);
            this.Controls.Add(this.labelSpace4);
            this.Controls.Add(this.buttonBonificar);
            this.Controls.Add(this.buttonDemitir);
            this.Controls.Add(this.labelSpace3);
            this.Controls.Add(this.labelFuncInfoResp);
            this.Controls.Add(this.labelSeçãoResp);
            this.Controls.Add(this.labelSalárioResp);
            this.Controls.Add(this.labelIdadeResp);
            this.Controls.Add(this.labelNomeResp);
            this.Controls.Add(this.labelSpace2);
            this.Controls.Add(this.labelSpace1);
            this.Controls.Add(this.labelInfoDropDrown);
            this.Controls.Add(this.comboBoxDropDown);
            this.Controls.Add(this.buttonAno);
            this.Name = "Form1";
            this.Text = "Informações sobre funcionários e Associados de uma Empresa";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAno;
        private System.Windows.Forms.ComboBox comboBoxDropDown;
        private System.Windows.Forms.Label labelInfoDropDrown;
        private System.Windows.Forms.Label labelSpace1;
        private System.Windows.Forms.Label labelSpace2;
        private System.Windows.Forms.Label labelNomeResp;
        private System.Windows.Forms.Label labelIdadeResp;
        private System.Windows.Forms.Label labelSalárioResp;
        private System.Windows.Forms.Label labelSeçãoResp;
        private System.Windows.Forms.Label labelFuncInfoResp;
        private System.Windows.Forms.Label labelSpace3;
        private System.Windows.Forms.Button buttonDemitir;
        private System.Windows.Forms.Button buttonBonificar;
        private System.Windows.Forms.Label labelSpace4;
        private System.Windows.Forms.Label labelFornecedor;
        private System.Windows.Forms.Label labelfornecedorResp;
        private System.Windows.Forms.Label labelNome;
        private System.Windows.Forms.Label labelIdade;
        private System.Windows.Forms.Label labelSeção;
        private System.Windows.Forms.Label labelSalário;
        private System.Windows.Forms.Label labelFuncInfo;
        private System.Windows.Forms.Label labelFornecedorTitle;
        private System.Windows.Forms.Label labelOBS;
        private System.Windows.Forms.Label labelProblemas;
    }
}

