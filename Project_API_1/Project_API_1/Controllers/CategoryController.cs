using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Project_API_1.Models;
using System.Web.Http.Cors;


namespace Project_API_1.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]

    [RoutePrefix("category")]
    public class CategoryController : ApiController
    {
        private ShopEntities db = new ShopEntities();

        // GET api/Category
        [Route("get-all.{ext}")]
        [Route("get-all")]
        [Route("")]
        public IQueryable<Category> GetCategories()
        {
            return db.Categories;
        }

        // GET api/Category/5
        [ResponseType(typeof(Category))]
        public async Task<IHttpActionResult> GetCategory(long id)
        {
            Category category = await db.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [Route("get-test")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //[Route("delete")]
        //public HttpResponseMessage Xoa()
        //{
        //    var response = Request.CreateResponse(HttpStatusCode.OK, "value");
        //    return response;
        //}
        // PUT api/Category/5
        public async Task<IHttpActionResult> PutCategory(long id, Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != category.CategoryID)
            {
                return BadRequest();
            }

            db.Entry(category).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
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

        // POST api/Category
        [ResponseType(typeof(Category))]
        public async Task<IHttpActionResult> PostCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Categories.Add(category);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = category.CategoryID }, category);
        }

        // DELETE api/Category/5
        [Route("delete")]
        [HttpPost]
        public string Xoa([FromBody] string id)
        {
            //Category category = await db.Categories.FindAsync(id);
            //if (category == null)
            //{
            //    return NotFound();
            //}
            //return Ok(category);
            return id;
        }
        //[Route("delete")]
        //public async Task<IHttpActionResult> DeleteCategory([FromUri()]long id)
        //{
        //    Category category = await db.Categories.FindAsync(id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Categories.Remove(category);
        //    await db.SaveChangesAsync();

        //    return Ok(category);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoryExists(long id)
        {
            return db.Categories.Count(e => e.CategoryID == id) > 0;
        }
    }
}