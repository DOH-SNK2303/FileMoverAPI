using System;
using System.Collections.Generic;

namespace FileMoverAPI.Models;

public partial class VwSourceRoute
{
    public int Id { get; set; }

    public int FilePrefixTypeId { get; set; }

    public string FilePrefixTypeName { get; set; } = null!;

    public int? SourceId { get; set; }

    public string FileServerType { get; set; } = null!;

    public string? SftUrl { get; set; }

    public string? SftFolder { get; set; }

    public string? SftUserName { get; set; }

    public string? SftPassword { get; set; }

    public string? SftPasswordHash { get; set; }

    public DateTime? PasswordUpdate { get; set; }

    public int? PasswordExpireDays { get; set; }

    public string? FolderPath { get; set; }

    public string? FolderType { get; set; }

    public string? Comment { get; set; }

    public int? ProviderContactId { get; set; }

    public int? ConsumerContactId { get; set; }

    public bool SendEmailProvider { get; set; }

    public bool SendEmailConsumer { get; set; }

    public bool OverwriteFile { get; set; }

    public bool AddDtstamp { get; set; }

    public bool RemoveDtstamp { get; set; }
}
