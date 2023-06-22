using BackendAcademico.Application.Services;
using BackendAcademico.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackendAcademico.UI.Controllers
{
    [Route("api/[controller]")]
    public class MateriaController:Controller
    {
        public IMateriaService _materiaService;
        public MateriaController(IMateriaService materiaService)
        {
            _materiaService = materiaService;
        }
        [HttpGet]
        public async Task<IActionResult> GetMaterias()
        {
            try
            {
                var materias = await _materiaService.GetMateriasAsync();
                return Ok(materias);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Sorry, something unexpected happened");
            }
        }
    }
}
