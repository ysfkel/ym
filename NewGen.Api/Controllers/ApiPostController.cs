
using Microsoft.AspNetCore.Mvc;
using NewGen.DomainModel.Repository;
using System.Collections.Generic;
using NewGen.DomainModel.Models;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Net;

namespace NewGen.Api.Controllers
{
    [Route("api/[Controller]")]
    public class ApiPostController:Controller 
    {
        private readonly IPostRepository repo;
        public ApiPostController(IPostRepository repo)
        {
            this.repo=repo;
        }

        [HttpGet]
        public IEnumerable<Post> Get()
        {
            return repo.GetAll().Where(x=>x.Id==67).ToList();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Post post)
        {
            post.DatePosted=DateTime.Now;
          //  post.Text=WebUtility.HtmlEncode(post.Text);
            await Task.Run(()=>this.repo.Add(post));
            this.repo.Commit();
            return StatusCode(200);
        }
    }
}