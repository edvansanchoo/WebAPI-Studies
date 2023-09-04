namespace WebAPI_Studies.Domain.Model
{
    public interface IEmployeeRepository
    {
        void Add(EmployeeModel employeeModel);

        List<EmployeeModel> GetAll();
        EmployeeModel? GetById(int id);
    }
}
