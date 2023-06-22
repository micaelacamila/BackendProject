using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAcademico.Domain.Models
{
    public class MateriaModel
    {
        public int Id_Materia { get; set; }
        public string Sigla { get; set; }
        public string Nombre { get; set;}
        public IEnumerable<InscripcionModel> Inscripciones { get; set;}

    }
}
