using App.DataAccessLayer.Models;
using App.DataAccessLayer.Repository.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccessLayer.Repository.IssueRepo
{ 
    public interface IIssueRepo:IGenericRepo<Issue>
    {
    }
}
