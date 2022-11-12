using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tarefa_POO
{
    class Funcionário
    {
        string funcNome;
        string demitidoOUnão;
        string departamento;
        string dataAdmissão;
        string rg;
        double salary;
        bool demitidoTrueFalse;
       
        public string FuncNome { get => funcNome; set => funcNome = value; }
        public string Departamento { get => departamento; set => departamento = value; }
        public string DataAdmissão { get => dataAdmissão; set => dataAdmissão = value; }
        public string Rg { get => rg; set => rg = value; }
        public double Salary { get => salary; set => salary = value; }
        public bool DemitidoTrueFalse { get => demitidoTrueFalse; set => demitidoTrueFalse = value; }
        public string DemitidoOUnão { get => demitidoOUnão; set => demitidoOUnão = value; }

        public Funcionário() { }
        public Funcionário (string funcNome,
        string departamento,
        string dataAdmissão,
        string rg,
        double salary,
        bool demitidoOUnão)
        {
            FuncNome = funcNome;
            Departamento = departamento;
            DataAdmissão = dataAdmissão;
            Rg = rg;
            Salary = salary;
            DemitidoTrueFalse = demitidoTrueFalse;
        }

        public void Bonificar(double porcentagem)
        {
            Salary = salary * porcentagem;
            // Nescessário chamar o método Mostrar(); para atualizar as infos ou não?
        }

        public void Demitir ()
        {
            DemitidoTrueFalse = true;
            // Nescessário chamar o método Mostrar(); para atualizar as infos ou não?
        }

        public string  Mostrar ()
        {
            if (DemitidoTrueFalse == true)
            {
                DemitidoOUnão = "Demitido";
            }
            else
            {
                DemitidoOUnão = "Ativo";
            }
            return  "Nome do Funcionário: " + FuncNome + "" +
                    "\r\nRG: " + Rg + "" +
                    "\r\nDepartamento: " + Departamento + "" +
                    "\r\nData de Admissão: " + DataAdmissão + "" +
                    "\r\nSalário: " + Salary + "" +
                    "\r\nStatus de Emprego: " + DemitidoOUnão;            
        }
    }
}
