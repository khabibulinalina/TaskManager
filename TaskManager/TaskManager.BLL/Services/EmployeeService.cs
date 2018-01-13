using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TaskManager.BLL.DTO;
using TaskManager.DAL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TaskManager.DAL.Interfaces;
using TaskManager.BLL.Helpers;

namespace TaskManager.BLL.Services
{
   // public class EmployeeService
   // {

   //     private IRepository<Employee> repo;


   //     public EmployeeService(IRepository<Employee> employeeRepository)
   //     {
   //         repo = employeeRepository;
   //     }


   //     public IEnumerable<EmployeeDTO> GetAllEmployee()
   //     {
   //         var temp = repo.GetAll();

   //         return temp.Select(t => new EmployeeDTO(t));
   //     }


       
   //}
}
