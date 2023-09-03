using WebAPI_Studies.Models;

namespace WebAPI_Studies.Model
{
    public interface IEmployeeRepository
    {
        void Add(EmployeeModel employeeModel);

        List<EmployeeModel> GetAll();
    }
}
