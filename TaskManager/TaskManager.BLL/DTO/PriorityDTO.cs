using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TaskManager.BLL.DTO
{
    public enum PriorityDTO
    {
        [Display(Name = "Критическая")]
        Critical,
        [Display(Name = "Важная")]
        Important,
        [Display(Name = "Обычная")]
        Normal,
        [Display(Name = "Не важная")]
        UnImportant

    }
}
