using App.DataAccessLayer.Database;
using App.DataAccessLayer.Models;
using App.DataAccessLayer.Repository.GenericRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccessLayer.Repository.PatientRepo
{
    public class PatientRepo:GenericRepo<Patient>, IPatientRepo
    {
        private readonly HospitalContext context;

        public Patient? GetPatientByIdWithIssues(int id)
        {
            return context.Patients.Include(b=>b.Issues).FirstOrDefault(x => x.Id == id);
        }
        public PatientRepo(HospitalContext context):base(context)
        {
            this.context = context;
        }
    }
}
