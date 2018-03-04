using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.BLL.DTO
{
   public class TaskListWithFirstModel
   {
       public IEnumerable<TaskDTO> taskList { get; set; }
       public TaskViewModel firstTask { get; set; }
    }
}
