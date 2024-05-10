using System;
using System.Collections.Generic;

namespace FileMoverAPI.Models;

public partial class FileServer
{
    public int Id { get; set; }

    public DateTime DateTimeStamp { get; set; }

    public DateTime ModifiedDateTime { get; set; }

    public string? ModifiedByUser { get; set; }

    public string FileServerType { get; set; } = null!;

    public string? SftUrl { get; set; }

    public string? SftFolder { get; set; }

    public string? SftUserName { get; set; }

    public string? SftPassword { get; set; }

    public string? SftPasswordHash { get; set; }

    public string? FolderPath { get; set; }

    public string? FolderType { get; set; }

    public string? Comment { get; set; }

    public DateTime? PasswordUpdate { get; set; }

    public int? PasswordExpireDays { get; set; }

    public int? ContactId { get; set; }

    public virtual ICollection<FilePrefixType> FilePrefixTypes { get; set; } = new List<FilePrefixType>();

    public virtual ICollection<Route> RouteDestinations { get; set; } = new List<Route>();

    public virtual ICollection<Route> RouteSources { get; set; } = new List<Route>();
}
