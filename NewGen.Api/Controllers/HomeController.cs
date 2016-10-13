
using Microsoft.AspNetCore.Mvc;
using NewGen.DomainModel.Repository;
using System.Collections.Generic;
using NewGen.DomainModel.Models;
using System.Linq;
using System.Net;

namespace NewGen.Api.Controllers
{
    public class HomeController:Controller 
    {
          [HttpGet]
          public IActionResult Index()
          {
              return View();
          }

          public IActionResult About()
          {
              return View();
          }
    }

}