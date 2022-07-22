using App.BusinessLayer.DTOs;
using App.BusinessLayer.Manager;
using Microsoft.AspNetCore.Mvc;

namespace WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly PatientsManager _patientsManager;

        public PatientController(PatientsManager patientsManager)
        {
            _patientsManager = patientsManager;
        }

        [HttpGet]
        public ActionResult<List<PatientRead>> GetPatients()
        {
            return _patientsManager.GetPatients();
        }

        [HttpGet("{id}")]
        public ActionResult<PatientRead> GetPatientByID(int id)
        {
            var patient = _patientsManager.GetPatientByID(id);
            if (patient is null)
            {
                return NotFound();
            }
            return patient;
        }

        [HttpPut("{id}")]
        public ActionResult PutPatient(int id, PatientWrite patientWriteDto)
        {
            if (!_patientsManager.DoesPatientExist(id))
            {
                return NotFound();
            }

            _patientsManager.PutPatient(id, patientWriteDto);

            return NoContent();
        }

        [HttpPost]
        public ActionResult PostPatient(PatientWrite patientWriteDto)
        {
            var newlyAddedId = _patientsManager.PostPatient(patientWriteDto);
            return CreatedAtAction("GetPatient", new { id = newlyAddedId }, value: "added");
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePatient(int id)
        {
            if (_patientsManager.DoesPatientExist(id))
            {
                return NotFound();
            }

            _patientsManager.DeletePatient(id);

            return NoContent();
        }

    }
}
