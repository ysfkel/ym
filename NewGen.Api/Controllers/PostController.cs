
using Microsoft.AspNetCore.Mvc;
using NewGen.DomainModel.Repository;
using System.Collections.Generic;
using NewGen.DomainModel.Models;
using System.Linq;
using System.Net;

namespace NewGen.Api.Controllers
{
    public class PostController:Controller 
    {
        private readonly IPostRepository repo;
        public PostController(IPostRepository repo)
        {
            this.repo=repo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

         [HttpGet]
        public IActionResult Details(int Id)
        {
            var item= this.repo.GetAll().Where(x=>x.Id==Id).Single();
             item.Text=WebUtility.HtmlDecode(item.Text);
            return View(item);
        }

        public IActionResult Create()
        {
            return View();
        }
    
       public IActionResult List()
       {
           var list=repo.GetAll();//.Where(x=>x.Id==75).ToList();
           foreach (var item in list)
           {
          item.Text=WebUtility.HtmlDecode(item.Text);
           }
             return View(list);
       }

        [HttpPost]
        public IActionResult Index(Post post)
        {
            this.repo.Add(post);
            this.repo.Commit();
            return View();
        }
    }
}