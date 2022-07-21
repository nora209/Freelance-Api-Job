using App.BusinessLayer.DTOs;
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
}
