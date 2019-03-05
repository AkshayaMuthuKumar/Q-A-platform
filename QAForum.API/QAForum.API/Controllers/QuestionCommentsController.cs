using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using QAForum.API.DAL;
using QAForum.API.Models;

namespace QAForum.API.Controllers
{
    public class QuestionCommentsController : BaseApiController
    {
        private ForumDbContext db = new ForumDbContext();

        // GET: api/QuestionComments
        public IQueryable<QuestionComment> GetQuestionComment()
        {
            return db.QuestionComment;
        }

        // GET: api/QuestionComments/5
        [ResponseType(typeof(QuestionComment))]
        public async Task<IHttpActionResult> GetQuestionComment(int id)
        {
            QuestionComment questionComment = await db.QuestionComment.FindAsync(id);
            if (questionComment == null)
            {
                return NotFound();
            }

            return Ok(questionComment);
        }

        // PUT: api/QuestionComments/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutQuestionComment(int id, QuestionComment questionComment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != questionComment.Id)
            {
                return BadRequest();
            }

            db.Entry(questionComment).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionCommentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/QuestionComments
        [ResponseType(typeof(QuestionComment))]
        public async Task<IHttpActionResult> PostQuestionComment(QuestionComment questionComment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            questionComment.UserId = base.UserId;
            questionComment.CreatedDate = DateTime.Now;
            db.QuestionComment.Add(questionComment);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = questionComment.Id }, questionComment);
        }

        // DELETE: api/QuestionComments/5
        [ResponseType(typeof(QuestionComment))]
        public async Task<IHttpActionResult> DeleteQuestionComment(int id)
        {
            QuestionComment questionComment = await db.QuestionComment.FindAsync(id);
            if (questionComment == null)
            {
                return NotFound();
            }

            db.QuestionComment.Remove(questionComment);
            await db.SaveChangesAsync();

            return Ok(questionComment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuestionCommentExists(int id)
        {
            return db.QuestionComment.Count(e => e.Id == id) > 0;
        }
    }
}