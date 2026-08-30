using System;
using System.Collections.Generic;

namespace To_Do_List.Models;

public partial class TblUser
{
    public string UserEmail { get; set; } = null!;

    public string UserPassword { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public int? UserPhone { get; set; }

    public string ConfirmPassword { get; set; } = null!;

    public virtual ICollection<TblCategory> TblCategories { get; set; } = new List<TblCategory>();

    public virtual ICollection<TblTask> TblTasks { get; set; } = new List<TblTask>();
}
