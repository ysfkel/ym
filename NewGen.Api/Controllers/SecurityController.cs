
using Microsoft.AspNetCore.Mvc;
using NewGen.DomainModel.Repository;
using System.Collections.Generic;
using NewGen.DomainModel.Models;
using System.Linq;
using System.Net;

namespace NewGen.Api.Controllers
{
    public class SecurityController:Controller 
    {
          [HttpGet]
          public IActionResult Index()
          {
              return View();
          }

          [HttpPost]
          public IActionResult Login()
          {
             return RedirectToAction("Create","Post");
          }
    }

}