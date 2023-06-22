using AutoMapper;
using BackendAcademico.Domain.Interfaces;
using BackendAcademico.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAcademico.Application.Services
{
    public class MateriasService : IMateriaService
    {
        private IAcademicoRepository _academicoRepository;
        private IMapper _mapper;
        public MateriasService(IAcademicoRepository academicoRepository, IMapper mapper)
        {
            _academicoRepository = academicoRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<MateriaModel>> GetMateriasAsync()
        {
            var materiasEntity = await _academicoRepository.GetMaterias();
            return _mapper.Map<IEnumerable<MateriaModel>>(materiasEntity);
        }
    }
}
