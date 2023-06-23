using BackendAcademico.Domain.Entities;
using BackendAcademico.Domain.Interfaces;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAcademico.Infrastructure.Data
{
    public class BackendAcademicoRepository : IAcademicoRepository
    {
        private BackendAcademicoDBContext _dbContext;
        public BackendAcademicoRepository(BackendAcademicoDBContext dBContext)
        {
            _dbContext= dBContext;
        }

        //Estudiante 

        public async Task<int> CreateEstudiante(EstudianteEntity estudiante)
        {
            var existingStudent = await GetStudentByUniqueValuesAsync(estudiante.Nombres, estudiante.Apellidos, estudiante.CI, estudiante.Fecha_Nacimiento);

            if (existingStudent != null)
            {
                throw new Exception("Al menos uno de los valores ya existe");
            }

            using var connection = _dbContext.Database.GetDbConnection();
            var sql = "INSERT INTO estudiante (CI, Nombres, Apellidos, Fecha_Nacimiento) VALUES (@CI, @Nombres, @Apelllidos, @Fecha_Nacimiento); SELECT LAST_INSERT_ID();";
            var parameters = new { CI = estudiante.CI, Nombres=estudiante.Nombres, Apelllidos=estudiante.Apellidos, Fecha_Nacimiento=estudiante.Fecha_Nacimiento };

            var id = await connection.ExecuteScalarAsync<int>(sql, parameters);

            return id;
        }

        private async Task<EstudianteEntity> GetStudentByUniqueValuesAsync(string name, string lastName, string ci,DateTime birthDate)
        {
            /*var sql = "SELECT * FROM estudiante WHERE Nombres = @Name OR Apellidos = @LastName OR CI = @CI or Fecha_Nacimiento = @BirthDate";
            var parameters = new { Name = name, LastName = lastName, CI = ci , BirthDate = birthDate};

            return await _dbConnection.QuerySingleOrDefaultAsync<EstudianteEntity>(sql, parameters);*/
            return await _dbContext.Estudiantes.FirstOrDefaultAsync(s =>s.Nombres == name || s.Apellidos == lastName || s.CI == ci || s.Fecha_Nacimiento==birthDate);
        }


        public async Task<IEnumerable<EstudianteEntity>> GetEstudiantes()
        {
            return await _dbContext.GetEstudiantesFromDb();
        }

        public async Task<EstudianteEntity> GetEstudiante(int id)
        {
            var estudiantes = await GetEstudiantes();
            return estudiantes.FirstOrDefault(e => e.Id_Estudiante == id);
        }

        //Materia
        public async Task<IEnumerable<MateriaEntity>> GetMaterias()
        {
            return await _dbContext.GetMateriasFromDb();
        }

        public async Task<MateriaEntity> GetMateria(int id)
        {
            IQueryable<MateriaEntity> query = _dbContext.Materias;
            query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(e => e.Id_Materia == id);
        }

        //Inscripcion
        public async Task<int> CreateInscripcion(InscripcionEntity inscripcion)
        {
            //EF
            _dbContext.Entry(inscripcion.Materia).State = EntityState.Unchanged;
            _dbContext.Entry(inscripcion.Estudiante).State = EntityState.Unchanged;
            _dbContext.Inscripciones.Add(inscripcion);
            return inscripcion.Id_Inscripcion;
            //Dapper
           /* using var connection = _dbContext.Database.GetDbConnection();
            var sql = "INSERT INTO inscripcion (Id_Materia, Id_Estudiante, Descripcion) VALUES (@Id_Materia, @Id_Estudiante, @Descripcion); SELECT LAST_INSERT_ID();";
            var parameters = new { Id_Materia = inscripcion.Materia.Id_Materia, Id_Estudiante = inscripcion.Estudiante.Id_Estudiante, Descripcion = inscripcion.Descripcion};

            var id = await connection.ExecuteScalarAsync<int>(sql, parameters);

            return id;*/
        }

        public async Task<InscripcionEntity> GetInscripcionEntity(int id)
        {
            //EF
            var inscripcion = await _dbContext.Inscripciones.FirstOrDefaultAsync(i => i.Id_Inscripcion == id);
            return inscripcion;
        }

        public async Task<IEnumerable<InscripcionEntity>> GetInscripcions()
        {
            return await _dbContext.GetInscripcionesFromDb();
        }

        public async Task UpdateInscripcion(int inscripcionId, InscripcionEntity inscripcion)
        {
            //Dapper
            var toUpdate = await GetInscripcionEntity(inscripcionId);
            inscripcion.Descripcion = inscripcion.Descripcion ?? toUpdate.Descripcion;
            inscripcion.Estudiante = toUpdate.Estudiante;
            inscripcion.Materia = toUpdate.Materia;
            using var connection = _dbContext.Database.GetDbConnection();
            var parameters = new
            {
                p_Descripcion = inscripcion.Descripcion,
                p_Id_Materia = inscripcion.Materia,
                p_Id_Estudiante = inscripcion.Estudiante
            };
            await connection.ExecuteAsync("ActualizarInscripcion", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteInscripcion(int id)
        {
            //Dapper
            using var connection = _dbContext.Database.GetDbConnection();
            var parameter = new { p_Id=id };
            await connection.ExecuteAsync("EliminarInscripcion", parameter, commandType: CommandType.StoredProcedure);
        }
        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                var result = await _dbContext.SaveChangesAsync();
                return result > 0 ? true : false;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}