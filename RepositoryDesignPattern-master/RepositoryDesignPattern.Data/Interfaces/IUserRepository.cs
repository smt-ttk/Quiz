using System.Collections.Generic;
using System.Linq;
using RepositoryDesignPattern.Data.Models;

namespace RepositoryDesignPattern.Data.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> List();
        User Find(int id);
        User Insert(User user);
        User Update(User user);
        bool Delete(int id);
        IQueryable<User> Query();
    }
}