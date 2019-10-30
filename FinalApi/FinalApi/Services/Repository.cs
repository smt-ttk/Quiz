using FinalApi.Context;
using FinalApi.Interfaces;
using FinalApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalApi.Services
{
    public class Repository : IRepository
    {

        private readonly DataContext _dataContext;

        public Repository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public bool Delete(int id)
        {
            var deger=Find(id);
            var kontrol = false;
            if (deger != null)
            {
                _dataContext.Users.Remove(deger);
                _dataContext.SaveChanges();
                kontrol = true;
            }
            return kontrol;
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

        public IEnumerable<User> List()
        {
            return _dataContext.Users.ToList();
        }

        public User Update(User user)
        {
            _dataContext.Users.Update(user);
            _dataContext.SaveChanges();
            return user;
        }
    }
}
