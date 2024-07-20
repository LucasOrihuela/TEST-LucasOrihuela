using Acudir.Test.Domain;
using Acudir.Test.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Acudir.Test.Apis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonasController : ControllerBase
    {
        private readonly IPersonaRepository _personaRepository;

        public PersonasController(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<Persona>> GetAll([FromQuery] string nombre, [FromQuery] int? edad)
        {
            var personas = _personaRepository.GetAll(nombre, edad);
            return Ok(personas);
        }

        [HttpPost]
        public ActionResult Add(Persona persona)
        {
            _personaRepository.Add(persona);
            return Ok();
        }

        [HttpPut]
        public ActionResult Update(Persona persona)
        {
            _personaRepository.Update(persona);
            return Ok();
        }
    }
}
