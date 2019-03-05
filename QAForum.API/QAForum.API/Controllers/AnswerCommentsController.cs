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
    public class AnswerCommentsController : BaseApiController
    {
        private ForumDbContext db = new ForumDbContext();

        // GET: api/AnswerComments
        public IQueryable<AnswerComment> GetAnswwerComment()
        {
            return db.AnswwerComment;
        }

        // GET: api/AnswerComments/5
        [ResponseType(typeof(AnswerComment))]
        public async Task<IHttpActionResult> GetAnswerComment(int id)
        {
            AnswerComment answerComment = await db.AnswwerComment.FindAsync(id);
            if (answerComment == null)
            {
                return NotFound();
            }

            return Ok(answerComment);
        }

        // PUT: api/AnswerComments/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAnswerComment(int id, AnswerComment answerComment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != answerComment.Id)
            {
                return BadRequest();
            }

            db.Entry(answerComment).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnswerCommentExists(id))
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

        // POST: api/AnswerComments
        [ResponseType(typeof(AnswerComment))]
        public async Task<IHttpActionResult> PostAnswerComment(AnswerComment answerComment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            answerComment.UserId = base.UserId;
            answerComment.CreatedDate = DateTime.Now;
            db.AnswwerComment.Add(answerComment);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = answerComment.Id }, answerComment);
        }

        // DELETE: api/AnswerComments/5
        [ResponseType(typeof(AnswerComment))]
        public async Task<IHttpActionResult> DeleteAnswerComment(int id)
        {
            AnswerComment answerComment = await db.AnswwerComment.FindAsync(id);
            if (answerComment == null)
            {
                return NotFound();
            }

            db.AnswwerComment.Remove(answerComment);
            await db.SaveChangesAsync();

            return Ok(answerComment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AnswerCommentExists(int id)
        {
            return db.AnswwerComment.Count(e => e.Id == id) > 0;
        }
    }
}