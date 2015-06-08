using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using GeekQuiz.Models;

namespace GeekQuiz.Controllers
{
    [Authorize]
    public class TriviaController : ApiController
    {
        private TriviaContext db = new TriviaContext();

        protected override void Dispose(bool disposing)
        {
            if(disposing)
                db.Dispose();

            base.Dispose(disposing);
        }

        [ResponseType(typeof(TriviaQuestion))]
        public async Task<IHttpActionResult> Get()
        {
            var userId = User.Identity.Name;

            var nextQuestion = await NextQuestionAsync(userId);

            if (nextQuestion == null)
                return NotFound();

            return Ok(nextQuestion);
        }

        [ResponseType(typeof(TriviaAnswer))]
        public async Task<IHttpActionResult> Post(TriviaAnswer answer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            answer.UserId = User.Identity.Name;

            var isCorrect = await StoreAsync(answer);

            return Ok(isCorrect);
        }

        private async Task<TriviaQuestion> NextQuestionAsync(string userId)
        {
            var lastQuestionId = await db.TriviaAnswers
                .Where(a => a.UserId == userId)
                .GroupBy(a => a.QuestionId)
                .Select(g => new {QuestionId = g.Key, Count = g.Count()})
                .OrderByDescending(q => new {q.Count, QuestionId = q.QuestionId})
                .Select(q => q.QuestionId)
                .FirstOrDefaultAsync();

            var questionsCount = await db.TriviaQuestions.CountAsync();

            var nextQuestionId = (lastQuestionId%questionsCount) + 1;

            return await db.TriviaQuestions.FindAsync(CancellationToken.None, nextQuestionId);
        }

        private async Task<bool> StoreAsync(TriviaAnswer answer)
        {
            db.TriviaAnswers.Add(answer);

            await db.SaveChangesAsync();

            var selectedOption = await db.TriviaOptions.FirstOrDefaultAsync(o => o.Id == answer.OptionId &&
                                                                                 o.QuestionId == answer.QuestionId);

            return selectedOption.IsCorrect;
        }
    }
}
