using App.DataAccessLayer.Repository.IssueRepo;
using App.DataAccessLayer.Repository.PatientRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccessLayer.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IPatientRepo patientREpo{ get; }
        public IIssueRepo issueRepo { get; }
    }
}
