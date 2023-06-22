using AutoMapper;
using BackendAcademico.Domain.Entities;
using BackendAcademico.Domain.Interfaces;
using BackendAcademico.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAcademico.Application.Services
{
    public class EstudianteService : IEstudianteService
    {
        private IAcademicoRepository _academicoRepository;
        private IMapper _mapper;
        public EstudianteService(IAcademicoRepository academicoRepository, IMapper mapper)
        {
            _academicoRepository = academicoRepository;
            _mapper = mapper;
        }

        public async Task<EstudianteModel> CreateEstudianteAsync()
        {
            var estudianteModel = this.Estudiante();
            var estudianteEntity = _mapper.Map<EstudianteEntity>(estudianteModel);
            var id=await _academicoRepository.CreateEstudiante(estudianteEntity);
            if (id>0)
            {
                estudianteEntity.Id_Estudiante = id;
                return _mapper.Map<EstudianteModel>(estudianteEntity);
            }
            throw new Exception("Database Error.");
        }

        public async Task<IEnumerable<EstudianteModel>> GetAllEstudiantesAsync()
        {
            var estudiantesEntity= await _academicoRepository.GetEstudiantes();
            return _mapper.Map<IEnumerable<EstudianteModel>>(estudiantesEntity);
        }

        public Task<EstudianteModel> GetEstudianteAsync(int id)
        {
            throw new NotImplementedException();
        }
        private EstudianteModel Estudiante()
        {
            EstudianteModel estudiante = new EstudianteModel
            {
                Nombres = GenerateRandomName(),
                Apellidos = GenerateRandomLastName(),
                CI = GenerateRandomCI(),
                Fecha_Nacimiento = GenerateRandomFN()
            };
            return estudiante;
        }

        private DateTime GenerateRandomFN()
        {
            DateTime fechaInicio = new DateTime(1984, 1, 1);
            DateTime fechaFin = new DateTime(2000, 12, 31);

            Random random = new Random();
            TimeSpan rangoFechas = fechaFin - fechaInicio;
            int totalDias = (int)rangoFechas.TotalDays;

            DateTime fechaAleatoria = fechaInicio.AddDays(random.Next(totalDias));
            return fechaAleatoria;
        }

        private string GenerateRandomCI()
        {
            Random random = new Random();
            string CIAleatorio = string.Empty;

            for (int i = 0; i < 7; i++)
            {
                int digitoAleatorio = random.Next(0, 10); 
                CIAleatorio += digitoAleatorio.ToString();
            }
            return CIAleatorio;
        }

        private string GenerateRandomLastName()
        {
            var randomApellidos = new string[] { "Carvajal", "Lopez", "Conde", "Roque", "Rocha","Martinez", "Lucana", "Arce", "Quintana", "Rodriguez", "Alvarez", "Quispe", "Mamani", "Rojas","Vaca", "Barba", "Soria", "Gonzales", "Palacios", "Reyes" };
            Random random = new Random();
            int randomInd = random.Next(0, randomApellidos.Length);
            var elementoAleatorio = randomApellidos[randomInd];
            return elementoAleatorio;
        }

        private string GenerateRandomName()
        {
            var randomNombres = new string[] { "Juan", "Maria", "Rodrigo", "Jose", "Marco", "Osvaldo","Juana", "Rocio", "Lucia", "Mariel", "Tito", "Andres", "Roxana", "Leticia", "Ruth", "Mario","Miriam", "Ruben", "Daniel", "Omar", "Carlos" };
            Random random = new Random();
            int randomInd = random.Next(0, randomNombres.Length);
            var elementoAleatorio = randomNombres[randomInd];
            return elementoAleatorio;
        }
    }
}
