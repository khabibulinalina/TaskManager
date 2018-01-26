using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.BLL.DTO
{
    public class CreateTaskViewModel
    {
        public TaskDTO TaskDTO { get; set; }
        public string SelectedUser { get; set; }
        public IEnumerable<SelectListItem> ListEmployee { get; set; }
    }
}
