using System;
using System.Collections.Generic;

namespace To_Do_List.Models;

public partial class TblTeam
{
    public int TeamId { get; set; }

    public string TeamName { get; set; } = null!;

    public int MembersNum { get; set; }

    public string TeamAdmin { get; set; } = null!;
}
