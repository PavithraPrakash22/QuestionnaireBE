using Microsoft.EntityFrameworkCore;
using QuestionnaireMW.Context;
using QuestionnaireMW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionnaireMW.Repository
{
    public class AnswerResponseRepository : IAnswerResponseRepository
    {
        private readonly QuestionnaireContext _context;
        public AnswerResponseRepository(QuestionnaireContext context)
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
        public void AddAnswerResponse(AnswerResponse item)
        {
            try
            {
                _context.AnswerResponses.Add(item);
                var result = _context.Users.SingleOrDefault(i => i.UserId == item.UserId);
                result.UserResponseCount = item.UserResponseCount;
                _context.Entry(result).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<AnswerResponse> getAnswerResponse(int UserId)
        {
            try
            {
                return _context.AnswerResponses.Where(i => i.UserId == UserId).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
