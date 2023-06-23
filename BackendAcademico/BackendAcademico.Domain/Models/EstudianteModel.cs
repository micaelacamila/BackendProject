using BackendAcademico.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAcademico.Domain.Models
{
    public class EstudianteModel
    {
        public int Id_Estudiante { get; set; }
        [MaxLength(7)]
       // [Required]
        public string CI { get; set; }
        //[Required]
        public string Nombres { get; set; }
        //[Required]
        public string Apellidos { get; set; }
        //[Required]
        public DateTime Fecha_Nacimiento { get; set; }
        public IEnumerable<InscripcionModel> Inscripciones { get; set; }

    }
}
