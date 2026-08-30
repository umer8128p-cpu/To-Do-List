using System;
using System.Collections.Generic;

namespace To_Do_List.Models;

public partial class TblTeamsUserTask
{
    public int Id { get; set; }

    public int Team { get; set; }

    public string TeamUser { get; set; } = null!;

    public int Task { get; set; }

    public virtual TblTeamTask TaskNavigation { get; set; } = null!;

    public virtual TblTeam TeamNavigation { get; set; } = null!;

    public virtual TblUser TeamUserNavigation { get; set; } = null!;
}
