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
    public class InscripcionService : IInscripcionService
    {
        private IMapper _mapper;
        private IAcademicoRepository _repository;
        public InscripcionService(IMapper mapper, IAcademicoRepository academicoRepository)
        {
            _mapper = mapper;
            _repository = academicoRepository;
        }

        public async Task<InscripcionModel> CreateInscripcion(InscripcionModel inscripcion, int materia, int estudiante)
        {
            await ValidateMateriaAsync(materia);
            await ValidateEstudianteAsync(estudiante);
            inscripcion.Id_Materia = materia;
            inscripcion.Id_Estudiante = estudiante;
            var inscripcionEntity = _mapper.Map<InscripcionEntity>(inscripcion);
            inscripcionEntity.Materia = await _repository.GetMateria(inscripcionEntity.Materia.Id_Materia);
            inscripcionEntity.Estudiante = await _repository.GetEstudiante(inscripcionEntity.Estudiante.Id_Estudiante);
            var id= await _repository.CreateInscripcion(inscripcionEntity);
            var ans = await _repository.SaveChangesAsync();
            if (ans)
            {
                var model= _mapper.Map<InscripcionModel>(inscripcionEntity);
                return model;
            }
            throw new Exception("Database Error.");
        }

        public async Task DeleteInscripcion(int id)
        {
            //await ValidateEstudianteAsync(estudiante);
            //await ValidateMateriaAsync(materia);
            await _repository.DeleteInscripcion(id);
        }

        public async Task<InscripcionModel> GetInscripcion(int id)
        {
            var entity = _repository.GetInscripcionEntity(id);
            if(entity == null)
            {
                throw new Exception("Id de inscripcion invalido");

            }
            return _mapper.Map<InscripcionModel>(entity);
        }

        public async Task<IEnumerable<InscripcionModel>> GetInscripciones()
        {
            var inscripciones = await _repository.GetInscripcions();
            return _mapper.Map < IEnumerable<InscripcionModel>>(inscripciones);
        }

        public async Task<InscripcionModel> UpdateInscripcion(InscripcionModel inscripcionModel, int id)
        {
            //await ValidateEstudianteAsync(estudiante);
            //await ValidateMateriaAsync(materia);
            var inscripcionEntity = _mapper.Map<InscripcionEntity>(inscripcionModel);
            await _repository.UpdateInscripcion(id, inscripcionEntity);
            return _mapper.Map<InscripcionModel>(inscripcionEntity);
        }
        private async Task ValidateEstudianteAsync(int estudiante)
        {
            var estudianteEntity = await _repository.GetEstudiante(estudiante);
            if (estudianteEntity == null) {
                throw new Exception("Id de estudiante inválido");
            }
        }

        private async Task ValidateMateriaAsync(int materia)
        {
            var materiaEntity = await _repository.GetMateria(materia);
            if (materiaEntity == null)
            {
                throw new Exception("Id de materia inválido");
            }
        }
    }
}
