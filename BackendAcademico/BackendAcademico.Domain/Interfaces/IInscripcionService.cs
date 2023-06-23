using BackendAcademico.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAcademico.Domain.Interfaces
{
    public interface IInscripcionService
    {
        Task<InscripcionModel> CreateInscripcion(InscripcionModel inscripcion, int materia, int estudiante);
        Task<InscripcionModel> GetInscripcion(int inscripcion);
        Task<IEnumerable<InscripcionModel>> GetInscripciones();
        Task<InscripcionModel> UpdateInscripcion(InscripcionModel inscripcionModel, int inscripcion);
        Task DeleteInscripcion(int inscripcion);
    }
}
