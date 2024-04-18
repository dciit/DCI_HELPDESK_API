using System;
using System.Collections.Generic;

namespace DCI_HELPDESK_API.Models;

public partial class HelpdeskJob
{
    public int JobId { get; set; }

    public string HdCode { get; set; } = null!;

    public string? JobHolder { get; set; }

    public int? JobFac { get; set; }

    public string? JobLocation { get; set; }

    public string? JobReqBy { get; set; }

    public DateTime? JobReqDate { get; set; }

    public string? JobReceivedBy { get; set; }

    public DateTime? JobReceivedDate { get; set; }

    public DateTime? JobCloseDate { get; set; }

    public string? JobStatus { get; set; }

    public DateTime UpdateDate { get; set; }

    public string? UpdateBy { get; set; }
}
