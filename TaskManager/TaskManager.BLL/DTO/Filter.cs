using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.BLL.DTO
{
    public enum Filter
    {
        [Display(Name = "По приоритеиту")]
        Priority,
        [Display(Name = "По названию")]
        Name,
        [Display(Name = "По дате создания")]
        DateOfCreate
    }
}
