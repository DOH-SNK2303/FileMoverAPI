using System;
using System.Collections.Generic;

namespace FileMoverAPI.Models;

public partial class EventLog
{
    public int EventId { get; set; }

    public DateTime DateTimeStamp { get; set; }

    public int EventTypeId { get; set; }

    public string EventDetails { get; set; } = null!;

    public string EventActor { get; set; } = null!;

    public string FileMoveOptions { get; set; } = null!;

    public int? FileCount { get; set; }
}
