using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccessLayer.Models
{
    public class patient
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }
     // public Issue Issue { get; set; }
       public virtual ICollection<Issue> Issues { get; set; }
    }
}
