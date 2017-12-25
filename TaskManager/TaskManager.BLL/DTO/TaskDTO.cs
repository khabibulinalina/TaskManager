using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.BLL.DTO
{
    public class TaskDTO:BaseEntityDTO
    {
        public String Title { get; set; }
        public String Descriprion { get; set; }
        public EmployeeDTO Employee { get; set; }
        public PriorityDTO Priority { get; set; }
    }
}
