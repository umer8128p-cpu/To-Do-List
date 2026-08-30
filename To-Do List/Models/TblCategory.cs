using System;
using System.Collections.Generic;

namespace To_Do_List.Models;

public partial class TblCategory
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? User { get; set; }

    public virtual ICollection<TblTask> TblTasks { get; set; } = new List<TblTask>();

    public virtual TblUser? UserNavigation { get; set; }
}
