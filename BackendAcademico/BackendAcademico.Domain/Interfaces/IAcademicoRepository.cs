using BackendAcademico.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAcademico.Domain.Interfaces
{
    public interface IAcademicoRepository
    {
        //Estudiantes
        Task<int> CreateEstudiante(EstudianteEntity estudiante);
        Task<IEnumerable<EstudianteEntity>> GetEstudiantes();
        Task<EstudianteEntity> GetEstudiante(int id);

        //Materias
        Task<IEnumerable<MateriaEntity>> GetMaterias();
        Task<MateriaEntity> GetMateria(int id);
    }
}
