using blogbackend.Model;
using blogbackend.Repository;
using Microsoft.AspNetCore.Mvc;
namespace blogbackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly PatientRepository _repository;


        public PatientController(PatientRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public ActionResult<IEnumerable<Patient>> GetAllProducts()
        {
            var products = _repository.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<Patient> GetProductById(int id)
        {
            var patient = _repository.GetById(id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

        [HttpPost]
        public ActionResult<Patient> CreateProduct(Patient patient)
        {
            _repository.Create(patient);
            return CreatedAtAction(nameof(GetProductById), new { id = patient.Id }, patient);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Patient patient)
        {
            if (id != patient.Id)
            {
                return BadRequest();
            }

            _repository.Update(patient);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePatient(int id)
        {
            var existingPatient = _repository.GetById(id);
            if (existingPatient == null)
            {
                return NotFound();
            }

            _repository.Delete(id);

            return NoContent();
        }

    }
}
