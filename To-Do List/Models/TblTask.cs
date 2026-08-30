using System;
using System.Collections.Generic;

namespace To_Do_List.Models;

public partial class TblTask
{
    public int TaskId { get; set; }

    public string TaskTitle { get; set; } = null!;

    public string TaskDiscription { get; set; } = null!;

    public int? TaskCategory { get; set; }

    public string TaskUser { get; set; } = null!;

    public DateOnly? TaskDate { get; set; }

    public TimeOnly TaskTime { get; set; }

    public string Priority { get; set; } = null!;

    public string? Status { get; set; }

    public DateOnly? CompletedDate { get; set; }

    public virtual TblCategory? TaskCategoryNavigation { get; set; }

    public virtual TblUser TaskUserNavigation { get; set; } = null!;
}
