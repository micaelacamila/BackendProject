using BackendAcademico.Domain.Entities;
using BackendAcademico.Domain.Interfaces;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            return await _dbContext.Estudiantes.FirstOrDefaultAsync(s =>
            s.Nombres == name || s.Apellidos == lastName || s.CI == ci || s.Fecha_Nacimiento==birthDate);
        }


        public async Task<IEnumerable<EstudianteEntity>> GetEstudiantes()
        {
            return await _dbContext.GetEstudiantesFromDb();
        }

        public Task<EstudianteEntity> GetEstudiante(int id)
        {
            throw new NotImplementedException();
        }

        //Materia
        public async Task<IEnumerable<MateriaEntity>> GetMaterias()
        {
            return await _dbContext.GetMateriasFromDb();
        }

        public Task<MateriaEntity> GetMateria(int id)
        {
            throw new NotImplementedException();
        }
    }
}
