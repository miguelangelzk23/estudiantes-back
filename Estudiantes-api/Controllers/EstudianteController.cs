using Estudiantes_negocio;
using Estudiantes_repositorio.Models;
using Estudiantes_repositorio.RequestModels;
using Estudiantes_repositorio.ResultModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Estudiantes_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        private EstudianteNegocio _negocio;
         public EstudianteController(EstudianteNegocio negocio) {

            _negocio = negocio;
        }
          Newtonsoft.Json.JsonSerializerSettings settings = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            Formatting = Formatting.Indented
        };

        [HttpGet("consultar-estudiantes")]
        public async Task<IActionResult> ConsultarEstudiantes()
        {
            List<Estudiante> ListaEstudiantes = new List<Estudiante>();
            ListaEstudiantes = await  _negocio.ConsultarEstudiante();
            return Ok(ListaEstudiantes); 
        }

        [HttpPost("crear-estudiante")]
        public async Task<IActionResult> CrearEstudiante([FromBody] CreateEstudiante dataInput )
        {
            int Result = await _negocio.CrearEstudiante(dataInput);
            return Ok(Result);
        }

        [HttpGet("consultar-materias")]
        public async Task<IActionResult> consultarMaterias()
        {
            List<ResultMaterias> Result = await _negocio.ConsultarMaterias();
            return Ok(JsonConvert.SerializeObject(Result, settings));
        }

        [HttpPost("materias-estudiante")]
        public async Task<IActionResult> AsignarMateriasEstudiante([FromBody] List<AsignarMateria> dataInput)
        {
            bool Result = await _negocio.AsignarMateriaEstudiante(dataInput);
            return Ok(Result);
        }

       
    }
}
