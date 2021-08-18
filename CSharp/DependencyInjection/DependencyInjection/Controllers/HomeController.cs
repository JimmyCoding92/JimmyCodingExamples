using DependencyInjection.Models;
using DependencyInjection.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISingletonService singletonService;
        private readonly ITransientService transientService;
        private readonly IScopedService scopedService;
        private readonly IDependencyService dependencyService;

        public HomeController(ISingletonService singletonService, ITransientService transientService, IScopedService scopedService, IDependencyService dependencyService)
        {
            this.singletonService = singletonService;
            this.transientService = transientService;
            this.scopedService = scopedService;
            this.dependencyService = dependencyService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Singleton()
        {
            return View("Singleton", new IdModel()
            {
                ControllerId = singletonService.GetId(),
                DependencyServiceId = dependencyService.GetSingletonId()
            });
        }

        public IActionResult Transient()
        {
            return View("Transient", new IdModel()
            {
                ControllerId = transientService.GetId(),
                DependencyServiceId = dependencyService.GetTransientId()
            });
        }

        public IActionResult Scoped()
        {
            //var requestService = HttpContext.RequestServices;
            //using (IServiceScope Scope = requestService.CreateScope())
            //{
            //}

            return View("Scoped", new IdModel()
            {
                ControllerId = scopedService.GetId(),
                DependencyServiceId = dependencyService.GetScopedId()
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
