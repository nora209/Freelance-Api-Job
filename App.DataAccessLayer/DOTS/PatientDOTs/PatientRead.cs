using App.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccessLayer.DOTS.PatientDOTs
{
    public record PatientRead
    {
        public int Id { get; init; }
        public string Name { get; init; } = null!;
        public int Age { get; init; }
        public List<IssueChildRead> Issues { get; init; }
    }
    public record IssueChildRead
    {
        public int Id { init; get; }
        public string Name { init; get; }
    }
}
