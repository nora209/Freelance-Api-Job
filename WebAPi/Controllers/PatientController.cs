using App.BusinessLayer.DTOs;
using App.BusinessLayer.Manager;
using App.DataAccessLayer.Models;
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

            var patientIssue = unitOfWork.PatientsRepo.GetPatientByIdWithIssues(id);
            if (patientIssue == null)
            {
                return NotFound();
            }
            var Patient = autoMapper.Map<PatientRead>(patientIssue);
            // listOfPatient= autoMapper.Map<PatientRead>(ListOfIssues);
            return Patient;
        }
        [HttpPut("{id}")]
        public ActionResult PutPatient(int id, PatientWrite patientWrite)
        {
            var PatientToEdit = unitOfWork.PatientsRepo.GetById(id);
            if (id != PatientToEdit.Id)
            {
                return BadRequest();
            }

            if (PatientToEdit is null)
            {
                return NotFound();
            }
            //Issue issues = unitOfWork.issueRepo.GetById(PatientToEdit.Id);
            autoMapper.Map(patientWrite, PatientToEdit);
            // PatientToEdit = issues;
            //unitOfWork.patientREpo.Update(PatientToEdit);
            unitOfWork.PatientsRepo.SaveChanges();
            return Ok("Updated");
        }

        [HttpPost]
        public ActionResult<Patient> PostPatient(PatientWrite _patient)
        {
            Patient patient1 = autoMapper.Map<Patient>(_patient);
            //filter issue where it ids in array _patient
            patient1.Issues = context.Issues.Where(i => _patient.IssuesID.Contains(i.Id)).ToList();
            unitOfWork.PatientsRepo.Insert(patient1);
            unitOfWork.PatientsRepo.SaveChanges();
            return CreatedAtAction("GetPatient", new { id = patient1.Id }, value: "added");
        }
        [HttpDelete("{id}")]
        public IActionResult DeletePatient(int id)
        {
            unitOfWork.PatientsRepo.Delete(id);
            if (!unitOfWork.PatientsRepo.SaveChanges())
            {
                return NotFound();
            }

            return Ok("Deleted");
        }

    }
}
