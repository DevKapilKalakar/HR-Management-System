using HRM.Models.EmployeeInfo;

namespace HRM.Contracts
{
    public interface IEmployeeService
    {
        Task<List<GetEmployeeInfo>> GetAllEmployeesAsync();
        Task CreateEmployeesAsync(CreateEmployeeInfo model);
        Task<EditEmployeeInfo> EditEmployeeAsync(int id);
        Task UpdateEmployeeAsync(EditEmployeeInfo model);
        Task<GetEmployeeDetails> DetailsEmployeeAsync(int id);
        Task DeleteEmployeeAsync(int id);
    }
}
