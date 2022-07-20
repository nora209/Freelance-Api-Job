using App.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccessLayer.DOTS.IssueDOTS
{
    public class IssueWrite
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
