using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TaskManager.BLL.DTO;
using TaskManager.DAL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TaskManager.DAL.Interfaces;

namespace TaskManager.BLL.Services
{
    public class TaskServices
    {
       
        private IRepository<Task> repo;


        public  TaskServices(IRepository<Task> taskRepository)
        {
            repo = taskRepository;
        }

        public IEnumerable<TaskDTO> GetAllTasks()
        {
            var temp = repo.GetAll();
            
            return temp.Select(t => new TaskDTO(t));
        }
        
       
        public void CreateTask(TaskDTO item)
        {
            throw new NotImplementedException();
        }

        public void DeleteTask(TaskDTO item)
        {
            throw new NotImplementedException();
        }

       

        public TaskDTO GetTaskById(int id)
        {
            throw new NotImplementedException();
        }

        

        public void UpdateTask(TaskDTO item)
        {
            throw new NotImplementedException();
        }
    }
}
