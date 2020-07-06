using QuestionnaireMW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionnaireMW.Repository
{
    public interface IAnswerResponseRepository
    {
        void AddAnswerResponse(AnswerResponse item);
        List<AnswerResponse> getAnswerResponse(int UserId);
    }
}
