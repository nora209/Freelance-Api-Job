using App.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccessLayer.DOTS.PatientDOTs
{
    public class PatientWrite
    {
        //public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public List<int> IssuesID { get; set; }
    }
}
