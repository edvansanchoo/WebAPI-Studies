using Microsoft.AspNetCore.Identity;
using WebAPI_Studies.api.Application.Services;
using WebAPI_Studies.api.Application.ViewModel;
using WebAPI_Studies.api.Domain.Model;
using WebAPI_Studies.api.Infrastructure;

namespace WebAPI_Studies.api.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ConnectionContext _context;

        public UserRepository(ConnectionContext context)
        {
            _context = context;
        }

        public bool Add(UserViewModel userViewModel)
        {
            try
            {
                _context.User.Add(new UserModel(userViewModel.username, Password.HashPassword(userViewModel.password)));
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        public bool Delete(int id)
        {
            UserModel userDb = GetById(id);
            if (userDb != null)
            {
                _context.User.Remove(userDb);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Edit(UserViewModel userViewModel)
        {
            UserModel userDb = GetById(userViewModel.id);
            if (userDb != null)
            {
                userDb.username = userViewModel.username;
                userDb.password = Password.HashPassword(userViewModel.password);

                _context.Update(userDb);
                _context.SaveChanges();
                return true;
            }
            return false;

        }

        public List<UserModel> GetAll()
        {
            return _context.User.ToList();
        }

        public UserModel? GetById(int id)
        {
            return _context.User.Find(id);
        }

        public UserModel? GetByUserNameAndPassWord(string username, string password)
        {
            var user = _context.User.
                Where(u => u.username == username)
                .SingleOrDefault();

            if (user != null && Password.VerifyPassword(password, user.password))
            {
                return user;
            }

            return null;
        }
    }
}
