using FinalApi.Models;
using System.Collections.Generic;

namespace FinalApi.Interfaces
{
    public interface IRepository
    {
        //IEnumerable<User> List();//bütük kayıtları listeler
        List<User> List();
        User Insert(User user);
        User Update(User user);
        User Find(int id);
        User FindUserName(string username);
        bool Delete(int id);



    }
}
