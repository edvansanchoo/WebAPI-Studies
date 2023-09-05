using WebAPI_Studies.api.Domain.Model;
using WebAPI_Studies.api.Infrastructure;

namespace WebAPI_Studies.api.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();
        public void Add(EmployeeModel employeeModel)
        {
            _context.Employees.Add(employeeModel);
            _context.SaveChanges();
        }

        public List<EmployeeModel> GetAll()
        {
            return _context.Employees.ToList();
        }

        public EmployeeModel GetById(int id)
        {
            return _context.Employees.Find(id);
        }
    }
}
