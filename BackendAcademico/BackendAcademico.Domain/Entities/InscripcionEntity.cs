using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAcademico.Domain.Entities
{
    public class InscripcionEntity
    {
        [Key]
        [Required]
        public int Id_Inscripcion{get;set; }
        [ForeignKey("Id_Materia")]
        public virtual MateriaEntity Materia{ get; set; }
        [ForeignKey("Id_Estudiante")]
        public virtual EstudianteEntity Estudiante { get; set; }
        public string Descripcion { get; set; } 
    }
}
