using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.BLL.DTO
{
    public class EmployeeDTO:BaseEntityDTO
    {
        public String Name { get; set; }
        public String Mail { get; set; }
        public DateTime DateOfBirthday { get; set; }
        public PositionsDTO Position { get; set; }
    }
}
