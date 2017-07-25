using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi_Identity_CodeAlong.Models;

namespace WebApi_Identity_CodeAlong.Controllers
{
    public class PostsController : ApiController
    {
        static List<Post> posts = new List<Post>();

        private int NextID()
        {
            if (posts.Count == 0)
                return 1;
            return posts.Max(p => p.ID) + 1;
        }
        // GET: api/Posts
        public IEnumerable<Post> Get()
        {
            return posts;
        }

        // GET: api/Posts/5
        public Post Get(int id)
        {
            return posts.SingleOrDefault(p => p.ID == id);
        }

        // POST: api/Posts
        public void Post([FromBody]Post value)
        {
            if (value == null)
            {
                return;
            }
            else
            {
                if (value.ID == null)
                {
                    value.ID = NextID();
                    posts.Add(value);
                }
            }
        }

        // PUT: api/Posts/5
        public void Put(int id, [FromBody]Post value)
        {
        }

        // DELETE: api/Posts/5
        public void Delete(int id)
        {
        }
    }
}
