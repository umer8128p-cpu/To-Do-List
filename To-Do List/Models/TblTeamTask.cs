using System;
using System.Collections.Generic;

namespace To_Do_List.Models;

public partial class TblTeamTask
{
    public int TId { get; set; }

    public string TTitle { get; set; } = null!;

    public string TDiscription { get; set; } = null!;

    public string TStatus { get; set; } = null!;

    public DateOnly TDate { get; set; }

    public TimeOnly TTime { get; set; }

    public DateOnly TCompletedDate { get; set; }
}
