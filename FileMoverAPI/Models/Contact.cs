using System;
using System.Collections.Generic;

namespace FileMoverAPI.Models;

public partial class Contact
{
    public int ContactId { get; set; }

    public DateTime DateTimeStamp { get; set; }

    public DateTime ModifiedDateTime { get; set; }

    public string? ModifiedByUser { get; set; }

    public string ContactFirstName { get; set; } = null!;

    public string ContactLastName { get; set; } = null!;

    public string? EmailAddress { get; set; }

    public string? Telephone { get; set; }

    public string Organization { get; set; } = null!;
}
