using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAcademico.Domain.Entities
{
    public class MateriaEntity
    {
        [Key]
        [Required]
        public int Id_Materia { get; set; }
        public string Sigla { get; set; }
        public string Nombre { get; set; }
        public ICollection<InscripcionEntity> Inscripciones { get; set; }
    }
}
