using BackendAcademico.Domain.Interfaces;
using BackendAcademico.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendAcademico.UI.Controllers
{
    [Route("api/[controller]")]
    public class EstudianteController:Controller
    {
        private IEstudianteService _estudianteService;
        public EstudianteController(IEstudianteService estudianteService)
        {
            _estudianteService = estudianteService;
        }
        [HttpPost]
        public async Task<ActionResult<EstudianteModel>> PostEstudianteAsync()
        {
            try
            {
                var newStudent = await _estudianteService.CreateEstudianteAsync();
                return Created($"api/estudiantes/{newStudent.Id_Estudiante}", newStudent);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Sorry, something unexpected happened");
            }
        }
    }

}
