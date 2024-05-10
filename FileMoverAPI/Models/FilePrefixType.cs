using System;
using System.Collections.Generic;

namespace FileMoverAPI.Models;

public partial class FilePrefixType
{
    public int FilePrefixTypeId { get; set; }

    public DateTime DateTimeStamp { get; set; }

    public DateTime ModifiedDateTime { get; set; }

    public string? ModifiedByUser { get; set; }

    public int? ApplicationId { get; set; }

    public string FilePrefixTypeName { get; set; } = null!;

    public bool CompressFile { get; set; }

    public string? Comment { get; set; }

    public int? ContactId { get; set; }

    public int? SourceId { get; set; }

    public virtual ICollection<Route> Routes { get; set; } = new List<Route>();

    public virtual FileServer? Source { get; set; }
}
