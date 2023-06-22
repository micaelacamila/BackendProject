using BackendAcademico.Domain.Entities;
using BackendAcademico.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAcademico.Domain.Interfaces
{
    public interface IEstudianteService
    {
        Task<EstudianteModel> CreateEstudianteAsync();
        Task<EstudianteModel> GetEstudianteAsync(int id);
        Task<IEnumerable<EstudianteModel>> GetAllEstudiantesAsync();


    }
}
