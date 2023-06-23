using BackendAcademico.Application.Services;
using BackendAcademico.Domain.Interfaces;
using BackendAcademico.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendAcademico.UI.Controllers
{
    [Route("api/[controller]")]
    public class InscripcionController:Controller
    {
        private IInscripcionService _inscripcionService;
        public InscripcionController(IInscripcionService inscripcionService)
        {
            _inscripcionService = inscripcionService;
        }
        [HttpPost("{estudianteId:int}/{materiaId:int}")]
        public async Task<ActionResult<InscripcionModel>> PostInscripcionAsync(int estudianteId, int materiaId, [FromBody] InscripcionModel inscripcion)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var inscripcionCreated = await _inscripcionService.CreateInscripcion(inscripcion, materiaId,estudianteId);
                return Created($"/api/Inscripcion/{inscripcionCreated.Id_Estudiante}/{inscripcionCreated.Id_Materia}", inscripcionCreated);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Sorry, something unexpected happened"+ex.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InscripcionModel>>> GetInscripcionesAsync()
        {
            try
            {
                var inscripciones = await _inscripcionService.GetInscripciones();
                return Ok(inscripciones);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Sorry, something unexpected happened. "+ex.Message);
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<InscripcionModel>> GetInscripcionAsync(int id)
        {
            try
            {
                var inscripcion = await _inscripcionService.GetInscripcion(id);
                return Ok(inscripcion);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Sorry, something unexpected happened. " + ex.Message);
            }
        }
        [HttpPut("{inscripcionId:int}")]
        public async Task<ActionResult<InscripcionModel>> UpdateInscripcionAsync(int inscripcionId, [FromBody] InscripcionModel inscripcion)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var inscripcionUpdated = _inscripcionService.UpdateInscripcion(inscripcion, inscripcionId);
                return Ok(inscripcionUpdated); 
            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Sorry, something unexpected happened. " + ex.Message);
            }
        }
        [HttpDelete("{inscripcionId:int}")]
        public async Task<ActionResult> DeleteInscripcion(int inscripcionId)
        {
            try
            {
                await _inscripcionService.DeleteInscripcion(inscripcionId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Sorry, something unexpected happened. " + ex.Message);
            }
        }


    }
}
