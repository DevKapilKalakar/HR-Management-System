using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Models.AssignProject
{
    public class AllAssignProject
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string ProjectName { get; set; }


    }
}
