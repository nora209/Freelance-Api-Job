using App.DataAccessLayer.Database;
using App.DataAccessLayer.Models;
using App.DataAccessLayer.Repository.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccessLayer.Repository.IssueRepo
{
    public class IssueRepo : GenericRepo<Issue>, IIssueRepo
    {
        private readonly HospitalContext _context;

        public IssueRepo(HospitalContext context) : base(context)
        {
            _context = context;
        }

        public List<Issue> GetIssuesByIds(List<int> Ids)
        {
            return _context.Issues.Where(i => Ids.Contains(i.Id)).ToList();
        }
    }
}
