using System;

namespace UnitOfWorkDesignPattern.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; set; }
        int Complete();
    }
}