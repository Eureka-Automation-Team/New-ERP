using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eureka.Services;
using Microsoft.AspNetCore.Mvc;

namespace Eureka.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ISecuritieSrv _repository;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Login(string username, string password)
        {
            return View();
        }
    }
}