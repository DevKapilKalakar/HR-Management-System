using Microsoft.AspDotNet.Mvc;
namespace HRM.Models.AssignProject
{
    public class AddAssignProject
    {
       
        public int EmployeeId { get; set; }
        public SelectList EmployeeList { get; set; }
        public int ProjectId { get; set; }
        public SelectList ProjectList { get; set; }
    }

}
