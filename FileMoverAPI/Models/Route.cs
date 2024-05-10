using System;
using System.Collections.Generic;

namespace FileMoverAPI.Models;

public partial class Route
{
    public int Id { get; set; }

    public DateTime ModifiedDateTime { get; set; }

    public string? ModifiedByUser { get; set; }

    public int FilePrefixTypeId { get; set; }

    public int? SourceId { get; set; }

    public int DestinationId { get; set; }

    public bool SendEmailProvider { get; set; }

    public bool SendEmailConsumer { get; set; }

    public bool OverwriteFile { get; set; }

    public bool AddDtstamp { get; set; }

    public bool RemoveDtstamp { get; set; }

    public int? DeleteAfter { get; set; }

    public virtual FileServer Destination { get; set; } = null!;

    public virtual FilePrefixType FilePrefixType { get; set; } = null!;

    public virtual FileServer? Source { get; set; }
}
