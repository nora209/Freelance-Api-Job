using App.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccessLayer.DOTS.IssueDOTS
{
    public record IssueRead
    {
        public int Id { get; init; }
        public string Name { get; init; } = null!;
    }
}
