using System.Collections.Generic;
using System.Linq;
using RepositoryDesignPattern.Data.Contexts;
using RepositoryDesignPattern.Data.Interfaces;
using RepositoryDesignPattern.Data.Models;

namespace RepositoryDesignPattern.Service
{
    public class UserService : IUserRepository
    {
        private readonly DataContext _dataContext;

        public UserService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<User> List()
        {
            return _dataContext.Users.ToList();
        }

        public User Find(int id)
        {
            return _dataContext.Users.Find(id);
        }

        public User Insert(User user)
        {
            _dataContext.Users.Add(user);
            _dataContext.SaveChanges();

            return user;
        }

        public User Update(User user)
        {
            _dataContext.Users.Update(user);
            _dataContext.SaveChanges();

            return user;
        }

        public bool Delete(int id)
        {
            bool result = false;

            User user = Find(id);

            if (user != null)
            {
                _dataContext.Users.Remove(user);
                _dataContext.SaveChanges();

                result = true;
            }

            return result;
        }

        public IQueryable<User> Query()
        {
            return _dataContext.Users;
        }
    }
}