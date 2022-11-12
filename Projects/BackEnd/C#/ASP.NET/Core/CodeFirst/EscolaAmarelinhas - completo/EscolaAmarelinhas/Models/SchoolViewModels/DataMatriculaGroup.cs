using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaAmarelinhas.Models.SchoolViewModels
{
    public class DataMatriculaGroup
    {
        [DataType(DataType.Date)]
        public DateTime? DataMatricula { get; set; }

        public int AlunosCount { get; set; }
    }
}
