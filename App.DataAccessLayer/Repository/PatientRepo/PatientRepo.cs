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
    public class PatientRepo:GenericRepo<patient>, IPatientRepo
    {
        private readonly Context context;

        public patient GetPatientByIdWithIssues(int id)
        {
            return context.patients.Include(b=>b.Issues).FirstOrDefault(x => x.Id == id);
        }
        public PatientRepo(Context context):base(context)
        {
            this.context = context;
        }
    }
}
