using HRM.Models.Admin;
using HRM.Models.Admin.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Contracts
{
    public interface IAdminService
    {
        Task<List<CandidateList>> GetCandidateListsAsync();
        Task CreateCandidateAsync(AddCandidate model);
        Task<EditCandidate> EditCandidateAsync(int id);
        Task UpdateCandidateAsync(EditCandidate model);
        Task DeleteCandidateAsync(int id);

        Task<List<EmployeePaymentList>> GetEmployeePaymentListAsync();

        Task<EditPayment> GetEmployeePaymentAsync(int id);

        Task UpdateEmployeePaymentAsync(EditPayment editPayment);
    }
}
