using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccessLayer.Models
{
    public class Issue
    {

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public virtual ICollection<Patient> Patients { get; set; } = new HashSet<Patient>();

    }
}
