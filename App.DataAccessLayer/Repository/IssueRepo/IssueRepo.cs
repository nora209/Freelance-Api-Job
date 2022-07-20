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
    public class IssueRepo:GenericRepo<Issue>, IIssueRepo
    {
        public IssueRepo(Context context):base(context)
        {

        }
    }
}
