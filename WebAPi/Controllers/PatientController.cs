


using App.DataAccessLayer;
using App.DataAccessLayer.AutoMapper;
using App.DataAccessLayer.Database;
using App.DataAccessLayer.DOTS.PatientDOTs;
using App.DataAccessLayer.Models;
using App.DataAccessLayer.UnitOfWork;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly Context context;
        private readonly IMapper autoMapper;
        public PatientController(IUnitOfWork _unitOfWork, Context _context, IMapper _automap)
        {
            unitOfWork = _unitOfWork;
            context = _context;
            autoMapper = _automap;
        }
        [HttpGet]
        public ActionResult<List<patient>> GetPatients()
        {
            return unitOfWork.patientREpo.GetAll();
            
        }
        
        [HttpGet("{id}")]
        public ActionResult<PatientRead> GetPatientByID(int id)
        {

            var patientIssue = unitOfWork.patientREpo.GetPatientByIdWithIssues(id);
           if(patientIssue == null)
            {
                return NotFound();
            }
            var Patient = autoMapper.Map<PatientRead >(patientIssue);
           // listOfPatient= autoMapper.Map<PatientRead>(ListOfIssues);
            return Patient;
        }
        [HttpPut("{id}")]
        public ActionResult PutPatient(int id, PatientWrite patientWrite)
        {
            var PatientToEdit = unitOfWork.patientREpo.GetById(id);
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
            unitOfWork.patientREpo.SaveChanges();
            return Ok("Updated");
        }

        [HttpPost]
        public ActionResult<patient> PostPatient(PatientWrite _patient)
        {
            patient patient1 = autoMapper.Map<patient>(_patient);
            //filter issue where it ids in array _patient
            patient1.Issues= context.issues.Where(i => _patient.IssuesID.Contains(i.Id)).ToList();
            unitOfWork.patientREpo.Insert(patient1);
            unitOfWork.patientREpo.SaveChanges();
            return CreatedAtAction("GetPatient", new { id = patient1.Id }, value: "added");
        }
        [HttpDelete("{id}")]
        public IActionResult DeletePatient(int id)
        {
            unitOfWork.patientREpo.Delete(id);
            if (!unitOfWork.patientREpo.SaveChanges())
            {
                return NotFound();
            }

            return Ok("Deleted");
        }

    }
}
