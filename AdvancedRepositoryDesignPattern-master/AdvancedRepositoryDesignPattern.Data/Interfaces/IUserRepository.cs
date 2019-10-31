using System.Collections.Generic;
using AdvancedRepositoryDesignPattern.Data.Models;

namespace AdvancedRepositoryDesignPattern.Data.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> TodayCreated();
    }
}