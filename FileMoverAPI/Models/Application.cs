using System;
using System.Collections.Generic;

namespace FileMoverAPI.Models;

public partial class Application
{
    public int ApplicationId { get; set; }

    public Guid AppGuid { get; set; }

    public DateTime DateTimeStamp { get; set; }

    public DateTime ModifiedDateTime { get; set; }

    public string ModifiedByUser { get; set; } = null!;

    public string ApplicationName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool Active { get; set; }
}
