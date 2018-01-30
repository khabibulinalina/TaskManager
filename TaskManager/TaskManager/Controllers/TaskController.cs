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
using Microsoft.AspNetCore.Authorization;

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
          var model = new CreateTaskViewModel();
          SetupRegisterViewModel(model);

            return View(model);
        }
        private void SetupRegisterViewModel(CreateTaskViewModel model)
        {
             model.ListEmployee = _userService.GetAllUser()
                .Select(e => new SelectListItem {Selected = false, Text = e.UserName, Value = e.Id});
        }

        [HttpPost]
        public IActionResult Create(CreateTaskViewModel model)
        {
                if (ModelState.IsValid)
                {
                    var task = new TaskDTO { Title = model.TaskDTO.Title, Descriprion = model.TaskDTO.Descriprion, Priority = model.TaskDTO.Priority, User = model.TaskDTO.User};

                    _taskService.CreateTask(task);

                Console.WriteLine(model);
                    // save model.Form
                    return RedirectToAction("Index");
                }
                 
                return View(model);


        }
        [HttpGet]
        public ActionResult Search()
        {
            return View();
        }

        
        public ActionResult TaskSearch(string name)
        {
            var tasks = _taskService.GetTaskByName(name);
                return PartialView(tasks);
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
