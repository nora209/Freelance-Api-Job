using App.BusinessLayer.DTOs;
using App.DataAccessLayer.Models;
using App.DataAccessLayer.UnitOfWork;
using AutoMapper;

namespace App.BusinessLayer.Manager;

public class PatientsManager
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PatientsManager(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public List<PatientRead> GetPatients()
    {
        var listFromDb = _unitOfWork.PatientsRepo.GetAll();
        var listToShow = _mapper.Map<List<PatientRead>>(listFromDb);
        return listToShow;
    }

    public PatientRead? GetPatientByID(int id)
    {
        var patientWithIssuesFromDb = _unitOfWork.PatientsRepo.GetPatientByIdWithIssues(id);
        var patientToShow = _mapper.Map<PatientRead?>(patientWithIssuesFromDb);
        return patientToShow;
    }

    public void PutPatient(int id, PatientWrite patientWriteDto)
    {
        var patientToEdit = _unitOfWork.PatientsRepo.GetById(id);
        _mapper.Map(patientWriteDto, patientToEdit);

        var assignedIssues = _unitOfWork.IssuesRepo.GetIssuesByIds(patientWriteDto.IssuesIds);
        patientToEdit.Issues = assignedIssues;

        _unitOfWork.PatientsRepo.SaveChanges();
    }

    public int PostPatient(PatientWrite patientWriteDto)
    {
        var patientToAdd = _mapper.Map<Patient>(patientWriteDto);

        //filter issues where their ids ar in array patientWriteDto.IssuesId
        patientToAdd.Issues = _unitOfWork.IssuesRepo.GetIssuesByIds(patientWriteDto.IssuesIds);

        _unitOfWork.PatientsRepo.Insert(patientToAdd);
        _unitOfWork.PatientsRepo.SaveChanges();

        return patientToAdd.Id;
    }

    public void DeletePatient(int id)
    {
        _unitOfWork.PatientsRepo.Delete(id);
        _unitOfWork.PatientsRepo.SaveChanges();
    }

    public bool DoesPatientExist(int id)
    {
        var patientFromDb = _unitOfWork.PatientsRepo.GetById(id);
        return patientFromDb is not null;
    }
}
