using QuestionnaireMW.Context;
using QuestionnaireMW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionnaireMW.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly QuestionnaireContext _context;
        public UserRepository(QuestionnaireContext context)
        {
            try
            {
                _context = context;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public void AddUser(User item)
        {
            try
            {
                _context.Users.Add(item);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        

        public User UserLogin(string UserEmail, string UserPassword)
        {
            try
            {
                return _context.Users.SingleOrDefault(data => data.UserEmail == UserEmail && data.UserPassword == UserPassword);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

       
    }
}
