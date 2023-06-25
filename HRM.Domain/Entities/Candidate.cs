using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Domain.Entities
{
    public class Candidate
    {
        [Key]
        public int Id { get; set; }
        public string CandidateName { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
