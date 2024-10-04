using System;
using System.Collections.Generic;

namespace JobPortal.Jobs;

public partial class JobPortal
{
    public int JobId { get; set; }

    public string? Title { get; set; }

    public string? Dec { get; set; }

    public string? Skills { get; set; }
}
