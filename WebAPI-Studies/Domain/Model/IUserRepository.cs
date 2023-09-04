using WebAPI_Studies.Application.ViewModel;

namespace WebAPI_Studies.Domain.Model
{
    public interface IUserRepository
    {
        bool Add(UserViewModel user);
        bool Edit(UserViewModel user);
        List<UserModel> GetAll();
        UserModel? GetById(int id);
        UserModel? GetByUserNameAndPassWord(string username, string password);

        bool Delete(int id);

    }
}
