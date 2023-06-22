using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAcademico.Domain.Entities
{
    public class EstudianteEntity
    {
        [Key]
        [Required]
        public int Id_Estudiante { get; set; }
        [MaxLength(7)]
        public string CI { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public ICollection<InscripcionEntity> Inscripciones { get; set;}

    }
}
