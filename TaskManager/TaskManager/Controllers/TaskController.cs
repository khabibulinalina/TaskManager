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

namespace TaskManager.Controllers
{
    public class TaskController : Controller

    {
        TaskServices _taskService;
        EmployeeService _employeeService;

        public TaskController(TaskServices taskServices, EmployeeService employeeService)
        {
            _taskService = taskServices;
            _employeeService = employeeService;
            
        }

        public IActionResult Index()
        {
            
            return View(_taskService.GetAllTasks());
        }
        [HttpGet]
        public IActionResult Create()
        {
           var temp = _employeeService.GetAllEmployee();

            var sl = new SelectList(temp, "Id", "Name");
            ViewBag.Temp = sl;

            return View();
        }

        [HttpPost]
        public IActionResult Create(string title, string description, PriorityDTO priority, EmployeeDTO empl)
        {
                  
           var task = new TaskDTO{ Title= title, Descriprion = description, Priority = priority, Employee = empl};
           _taskService.CreateTask(task);
           
            return RedirectToAction("Index");
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
