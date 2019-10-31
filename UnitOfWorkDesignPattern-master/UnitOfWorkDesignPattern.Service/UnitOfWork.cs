using UnitOfWorkDesignPattern.Data.Contexts;
using UnitOfWorkDesignPattern.Data.Interfaces;

namespace UnitOfWorkDesignPattern.Service
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;

        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Dispose()
        {
            _dataContext.Dispose();
            UserRepository = new UserRepository(_dataContext);
        }

        public IUserRepository UserRepository { get; set; }

        public int Complete()
        {
            return _dataContext.SaveChanges();
        }
    }
}