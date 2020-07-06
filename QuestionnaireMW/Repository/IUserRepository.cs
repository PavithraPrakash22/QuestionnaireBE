using QuestionnaireMW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionnaireMW.Repository
{
    public interface IUserRepository
    {
        void AddUser(User item);
        User UserLogin(string UserEmail, string UserPassword);
    }
}
