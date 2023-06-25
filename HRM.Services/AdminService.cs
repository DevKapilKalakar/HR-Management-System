using HRM.Contracts;
using HRM.Domain.Entities;
using HRM.Infrastructure;
using HRM.Models.Admin;
using HRM.Models.Admin.Payments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HRM.Services
{
    public class AdminService:IAdminService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    public async Task<List<CandidateList>> GetCandidateListsAsync()
        {
            var Candidate = await _unitOfWork.Candidates.All().Select(u => new CandidateList
            {

                Id = u.Id,
                CandidateName = u.CandidateName,
                PhoneNumber = u.PhoneNumber,
                Email = u.Email,    

            }).ToListAsync();
            return Candidate;
         }

        public async Task CreateCandidateAsync(AddCandidate model)
        {
            var candidates = new Candidate
            {
               CandidateName= model.CandidateName,
               PhoneNumber= model.PhoneNumber,
               Email= model.Email,
            };
            _unitOfWork.Candidates.Add(candidates);
            await _unitOfWork.SaveAsync();
        }
        public async Task<EditCandidate> EditCandidateAsync(int id)
        {
            var canndidate = await _unitOfWork.Candidates.All().Select(u => new EditCandidate
            {
                Id = u.Id,
              PhoneNumber = u.PhoneNumber,
              Email = u.Email,  
              CandidateName=u.CandidateName,
            }).FirstOrDefaultAsync(u => u.Id == id);
            return canndidate;
        }

        public async Task UpdateCandidateAsync(EditCandidate model)
        {
            var canndidate = await _unitOfWork.Candidates.All().FirstOrDefaultAsync(a => a.Id == model.Id);
            if (canndidate == null) { return; }
            canndidate.PhoneNumber=model.PhoneNumber;
            canndidate.Email=model.Email;
            canndidate.CandidateName = model.CandidateName;
             _unitOfWork.Candidates.Update(canndidate);
            await _unitOfWork.SaveAsync(); 

        }

        public async Task DeleteCandidateAsync(int id)
        {
            var canndidate = await _unitOfWork.Candidates.All().FirstOrDefaultAsync(a => a.Id == id);
            if (canndidate == null) { return; }


            _unitOfWork.Candidates.Delete(canndidate);
            await _unitOfWork.SaveAsync();
        }

       

        public async Task<List<EmployeePaymentList>> GetEmployeePaymentListAsync()
        {
            var payments = await _unitOfWork.Employees.All().Select(u => new EmployeePaymentList
            {
                Id = u.Id,
                  EmployeeName = u.Name,
                  Salary = u.Salary,
            }).ToListAsync();
            return payments;
        }

        public async Task<EditPayment> GetEmployeePaymentAsync(int id)
        {
            var payment = await _unitOfWork.Employees.All().FirstOrDefaultAsync(e => e.Id == id); 
            return new EditPayment
            {
                Id = payment.Id,
                Salary = payment.Salary,
            };
        }

        public async Task UpdateEmployeePaymentAsync(EditPayment editPayment)
        {
            var payment = await _unitOfWork.Employees.All().FirstOrDefaultAsync(e => e.Id == editPayment.Id);
            if (payment == null) { return; }
            payment.Salary = editPayment.Salary;
            _unitOfWork.Employees.Update(payment);
            await _unitOfWork.SaveAsync();
        }

    }

}
