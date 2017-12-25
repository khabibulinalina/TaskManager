using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.DAL.Entities
{
    public enum Priority
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
