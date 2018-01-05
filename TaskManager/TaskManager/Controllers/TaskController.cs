using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;
using TaskManager.BLL;
using TaskManager.BLL.Services;

namespace TaskManager.Controllers
{
    public class TaskController : Controller

    {
        TaskServices _taskService;

        public TaskController(TaskServices taskServices)
        {
            _taskService = taskServices;
        }

        public IActionResult Index()
        {
           
            return View(_taskService.GetAllTasks());
        }
        public IActionResult Create()
        {

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
