using HRM.Domain.Entities;

namespace HRM.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool isDisposed;
        private readonly DatabaseContext _dbContext;

        private IBaseRepository<Employee> _employees;
        private IBaseRepository<Candidate> _candidate;
        private IBaseRepository<Project> _project;
        private IBaseRepository<EmployeeAssignProject> _eloyeeAssignProject;
        public UnitOfWork(DatabaseContext dbContext) 
        {
            _dbContext = dbContext;    
        }

        public IBaseRepository<Employee> Employees => _employees ??= new BaseRepository<Employee>(_dbContext);
        public IBaseRepository<Candidate> Candidates => _candidate ??= new BaseRepository<Candidate>(_dbContext);
        public IBaseRepository<Project> Projects => _project ??= new BaseRepository<Project>(_dbContext);
        public IBaseRepository<EmployeeAssignProject> EmployeeAssignProjects=> _eloyeeAssignProject ??= new BaseRepository<EmployeeAssignProject>(_dbContext);

        protected virtual void Dispose(bool disposing) 
        {
            if (!isDisposed && disposing) 
            { 
                _dbContext.Dispose();
            }
            isDisposed = true;
        }

        public async Task<int> SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
            return 1;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
