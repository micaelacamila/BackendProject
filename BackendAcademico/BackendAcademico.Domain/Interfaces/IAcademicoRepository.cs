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

        //DB
        Task<bool> SaveChangesAsync();
    }
}
