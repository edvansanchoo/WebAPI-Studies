using WebAPI_Studies.Domain.Model;

namespace WebAPI_Studies.Infrastructure.Repositories
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
