namespace WebAPI_Studies.api.Domain.Model
{
    public interface IEmployeeRepository
    {
        void Add(EmployeeModel employeeModel);

        List<EmployeeModel> GetAll();
        EmployeeModel? GetById(int id);
    }
}
