using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.BLL.DTO
{
    public class FilterViewModel
    {
        public IEnumerable<TaskDTO> Tasks { get; set; }
        public Filter CurrentFilter { get; set; }
    }
}
