
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
    public class ApiVideoController:Controller 
    {
        private readonly IVideoRepository repo;
        public ApiVideoController(IVideoRepository repo)
        {
            this.repo=repo;
        }

        [HttpGet]
        public IEnumerable<Video> Get()
        {
            return repo.GetAll();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Video video)
        {
             video.DatePosted= DateTime.Now;
            await Task.Run(()=>this.repo.Add(video));
            this.repo.Commit();
            return StatusCode(200,video);
        }
    }
}