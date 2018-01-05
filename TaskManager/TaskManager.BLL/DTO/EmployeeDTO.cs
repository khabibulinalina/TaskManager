using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.DAL.Entities;

namespace TaskManager.BLL.DTO
{
    public class EmployeeDTO:BaseEntityDTO
    {
        public EmployeeDTO(Employee employee)
        {
            Name = employee.Name;
            Mail = employee.Mail;
            DateOfBirthday = employee.DateOfBirthday;
            Position = (PositionsDTO)((int) employee.Position);
        }

        public String Name { get; set; }
        public String Mail { get; set; }
        public DateTime DateOfBirthday { get; set; }
        public PositionsDTO Position { get; set; }
    }
}
