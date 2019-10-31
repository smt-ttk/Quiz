using System;
using System.Collections.Generic;
using System.Linq;
using UnitOfWorkDesignPattern.Data.Contexts;
using UnitOfWorkDesignPattern.Data.Interfaces;
using UnitOfWorkDesignPattern.Data.Models;

namespace UnitOfWorkDesignPattern.Service
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<User> TodayCreated()
        {
            return _dataContext.Users.Where(a => a.CreateDate >= DateTime.Today && a.CreateDate <= DateTime.Today.AddDays(1).AddTicks(-1));
        }
    }
}