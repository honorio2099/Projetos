using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _2nd_MVC.Models
{
    public class Funcionarios
    {
        int idFunc;
        string funcNome, funcRg, funcCpf;
        double funcSalario;

        [Display(Name = "Id do Funcionário: ")]
        public int IdFunc { get => idFunc; set => idFunc = value; }

        [Display(Name = "Nome do Funcionário - ")]
        public string FuncNome { get => funcNome; set => funcNome = value; }

        [Display(Name = "RG: ")]
        public string FuncRg { get => funcRg; set => funcRg = value; }

        [Display(Name = "CPF: ")]
        public string FuncCpf { get => funcCpf; set => funcCpf = value; }

        [Display(Name = "Salário R$: ")]
        public double FuncSalario { get => funcSalario; set => funcSalario = value; }
    }
}