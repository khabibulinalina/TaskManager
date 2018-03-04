using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace TaskManager.WEB.Controllers
{
    public class TaskController : Controller

    {
        TaskServices _taskService;
        UserService _userService;

        public TaskController(TaskServices taskServices, UserService userService)
        {
            _taskService = taskServices;
            _userService = userService;

        }

        public IActionResult Index()
        {
            var taskList = _taskService.GetAllTasks();
            var viewModels = taskList.Select(e => CreateTaskViewModel(e));

            return View(viewModels);
        }

        private TaskViewModel CreateTaskViewModel(TaskDTO task)
        {
            var userName = _userService.GetUserById(task.UserID).UserName;
            var viewModel = new TaskViewModel
            {
                Id = task.Id,
                Title = task.Title,
                Descriprion = task.Descriprion,
                Priority = task.Priority,
                UserName = userName
            };
            return viewModel;
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
               .Select(e => new SelectListItem { Selected = false, Text = e.UserName, Value = e.Id });
        }

        [HttpPost]
        public IActionResult Create(CreateTaskViewModel model)
        {
            if (ModelState.IsValid)
            {
                var task = new TaskDTO { Title = model.TaskDTO.Title, Descriprion = model.TaskDTO.Descriprion, Priority = model.TaskDTO.Priority, UserID = model.TaskDTO.UserID };

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

        public ActionResult Details(String id)
        {
            var task = _taskService.GetTaskById(id);
            var model = CreateTaskViewModel(task);
            return View(model);
        }

        
        public ActionResult TaskList()
        {
            var tasks = _taskService.GetAllTasks();
            var model = new FilterViewModel
            {
                 Tasks   = tasks,
                CurrentFilter = BLL.DTO.Filter.DateOfCreate
            };
            
            //var taskFirst = tasks.FirstOrDefault();
            //var user = _userService.GetUserById(taskFirst.UserID);

            //var model = new TaskListWithFirstModel
            //{
            //    taskList = tasks,
            //    firstTask = new TaskViewModel()
            //    {
            //        Id = taskFirst.Id,
            //        Descriprion = taskFirst.Descriprion,
            //        Priority = taskFirst.Priority,
            //        Title = taskFirst.Title,
            //        UserName = user.UserName
            //    },

            //};
            return View(model);
        }

        public ActionResult Filter(FilterViewModel model)
        {
            var tasks = _taskService.GetAllTasks();
           
            switch (@model.CurrentFilter)
            {
                case BLL.DTO.Filter.DateOfCreate:
                    var filteredByDateViewModel = new FilterViewModel
                    {
                        Tasks = tasks,
                        CurrentFilter = BLL.DTO.Filter.DateOfCreate
                    };
                return View("TaskList", filteredByDateViewModel);

                case BLL.DTO.Filter.Name:
                    var filteredByNameViewModel = new FilterViewModel
                    {
                        Tasks = tasks.OrderBy(task => task.Title),
                        CurrentFilter = BLL.DTO.Filter.Name
                    };
                return View("TaskList", filteredByNameViewModel);

                case BLL.DTO.Filter.Priority:
                    var filteredByPriorityViewModel = new FilterViewModel
                    {
                        Tasks = tasks.OrderBy(task => task.Priority),
                        CurrentFilter = BLL.DTO.Filter.Priority
                    };
                return View("TaskList", filteredByPriorityViewModel);


                default: throw new InvalidEnumArgumentException();
            }
        }

        public ActionResult PartialViewTaskList(string id)
        {
            var task = _taskService.GetTaskById(id);
            var viewModel = CreateTaskViewModel(task);

            return PartialView(viewModel);
        }
    }
}
