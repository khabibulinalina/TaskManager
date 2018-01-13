using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;
using TaskManager.BLL;
using TaskManager.BLL.Services;
using TaskManager.BLL.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using TaskManager.DAL.Entities;

namespace TaskManager.Controllers
{
    public class TaskController : Controller

    {
        TaskServices _taskService;
        UserService _userService;

        public TaskController(TaskServices taskServices, UserService userService )
        {
            _taskService = taskServices;
            _userService = userService;
            
        }

        public IActionResult Index()
        {
            
            return View(_taskService.GetAllTasks());
        }

        [HttpGet]
        public IActionResult Create()
        {
           var temp = _userService.GetAllUser();
            
           var sl = new SelectList(temp, "Id", "UserName");
           ViewBag.Temp = sl;

            return View();
        }

        [HttpPost]
        public IActionResult Create(string title, string description, PriorityDTO priority, UserDTO user)
        {
                  
           var task = new TaskDTO { Title = title, Descriprion = description, Priority = priority, User = user };

            if (ModelState.IsValid)
            {
                _taskService.CreateTask(task);
                return RedirectToAction("Index");
            }
            else
                return View(task);
           
             
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
