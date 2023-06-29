using HRM.Contracts;
using HRM.Domain.Entities;
using HRM.Infrastructure;
using HRM.Models.EmployeeInfo;
using Microsoft.EntityFrameworkCore;


namespace HRM.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetEmployeeInfo>> GetAllEmployeesAsync()
        {
            var employees = await _unitOfWork.Employees.All().Select(u => new GetEmployeeInfo
            {
                Name = u.Name,
                Id = u.Id,
                Phone = u.Phone,
                Qualification = u.Qualification

            }).ToListAsync();
            return employees;
        }

        public async Task CreateEmployeesAsync(CreateEmployeeInfo model)
        {
            var employees = new Employee
            {
                Name = model.Name,
                Qualification = model.Qualification,
                Phone = model.Phone,
                Skills = model.Skills,
                LoginId = model.LoginId,
                Password = model.Password,
                Experience = model.Experience,
                Salary = "0"
            };
            _unitOfWork.Employees.Add(employees);
            await _unitOfWork.SaveAsync();
        }

        public async Task<EditEmployeeInfo> EditEmployeeAsync(int id)
        {
            var employee = await _unitOfWork.Employees.All().Select(u => new EditEmployeeInfo
            {
                Id = u.Id,
                Experience = u.Experience,
                LoginId = u.LoginId,
                Password = u.Password,
                Name = u.Name,
                Phone = u.Phone,
                Qualification = u.Qualification,
                Skills = u.Skills
            }).FirstOrDefaultAsync(u => u.Id == id);
            return employee;
        }

        public async Task UpdateEmployeeAsync(EditEmployeeInfo model)
        {
            var employee = await _unitOfWork.Employees.All().FirstOrDefaultAsync(a => a.Id == model.Id);
            if (employee == null) { return; }

            employee.Name = model.Name;
            employee.Phone = model.Phone;
            employee.Qualification = model.Qualification;
            employee.Skills = model.Skills;
            employee.Phone = model.Phone;
            employee.Experience = model.Experience;
            employee.LoginId = model.LoginId;
            employee.Password = model.Password;


            _unitOfWork.Employees.Update(employee);
            await _unitOfWork.SaveAsync();

        }

        public async Task<GetEmployeeDetails> DetailsEmployeeAsync(int id)
        {
            var employee = await _unitOfWork.Employees.All().Select(u => new GetEmployeeDetails
            {
                Id = u.Id,
                Experience = u.Experience,
                LoginId = u.LoginId,
                Password = u.Password,
                Name = u.Name,
                Phone = u.Phone,
                Qualification = u.Qualification,
                Skills = u.Skills,
            }).FirstOrDefaultAsync(u => u.Id == id);
            return employee;
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = await _unitOfWork.Employees.All().FirstOrDefaultAsync(a => a.Id == id);
            if (employee == null) { return; }


            _unitOfWork.Employees.Delete(employee);
            await _unitOfWork.SaveAsync();
        }

    }
}
 