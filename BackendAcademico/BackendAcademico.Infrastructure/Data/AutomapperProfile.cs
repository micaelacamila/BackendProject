using AutoMapper;
using BackendAcademico.Domain.Entities;
using BackendAcademico.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAcademico.Infrastructure.Data
{
    public class AutomapperProfile:Profile
    {
        public AutomapperProfile()
        {
            this.CreateMap<EstudianteEntity, EstudianteModel>()
                //.ForMember( des => des.Phone, opt => opt.MapFrom(src => src.Phone + "#" + src.Name ))
                .ReverseMap();
            this.CreateMap<MateriaEntity,MateriaModel>()
                .ReverseMap();

            this.CreateMap<InscripcionEntity, InscripcionModel>()
                .ForMember(mod => mod.Id_Materia, ent => ent.MapFrom(entSrc => entSrc.Materia.Id_Materia))
                .ForMember(mod => mod.Id_Estudiante, ent => ent.MapFrom(entSrc => entSrc.Estudiante.Id_Estudiante))
                .ReverseMap()
                .ForMember(ent => ent.Materia, mod => mod.MapFrom(modSrc => new MateriaEntity() { Id_Materia= modSrc.Id_Materia }))
                .ForMember(ent => ent.Estudiante, mod => mod.MapFrom(modSrc => new EstudianteEntity() { Id_Estudiante = modSrc.Id_Estudiante }));

        }

    }
}
