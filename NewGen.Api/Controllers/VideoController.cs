
using Microsoft.AspNetCore.Mvc;
using NewGen.DomainModel.Repository;
using System.Collections.Generic;
using NewGen.DomainModel.Models;
using System.Linq;
using System.Net;

namespace NewGen.Api.Controllers
{
    public class VideoController:Controller 
    {
          private readonly IVideoRepository repo;
          public VideoController(IVideoRepository repo)
          {
                this.repo=repo;
          }

          [HttpGet]
          public IActionResult Index()
          {
              return View();
          }

          [HttpGet]
          public IActionResult List()
          {
              var list=repo.GetAll();
              return View(list);//View(new int[]{1,2,3,4,5});
          }

          [HttpGet]
          public IActionResult Manage()
          {
              return View();
          }

    }

}