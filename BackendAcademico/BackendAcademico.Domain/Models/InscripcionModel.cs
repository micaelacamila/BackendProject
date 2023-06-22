using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAcademico.Domain.Models
{
    public class InscripcionModel
    {
        public int Id_Inscripcion { get; set; }
        public int Id_Materia { get; set; }
        public int Id_Estudiante { get; set; }
        public string Descripcion { get; set; }
    }
}
