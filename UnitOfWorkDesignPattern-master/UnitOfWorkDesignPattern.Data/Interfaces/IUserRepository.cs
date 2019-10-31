using System.Collections.Generic;
using UnitOfWorkDesignPattern.Data.Models;

namespace UnitOfWorkDesignPattern.Data.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> TodayCreated();
    }
}