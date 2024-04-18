using System;
using System.Collections.Generic;

namespace DCI_HELPDESK_API.Models;

public partial class HelpdeskDict
{
    public int HdId { get; set; }

    public string HdCategory { get; set; } = null!;

    public string HdCode { get; set; } = null!;

    public int? HdIndex { get; set; }

    public string? HdTitle { get; set; }

    public string? HdDesc { get; set; }

    public double HdRatio { get; set; }

    public string? HdRef { get; set; }

    public string? HdCreateBy { get; set; }

    public DateTime? HdCreateDate { get; set; }

    /// <summary>
    /// 1 = ใช้งาน, 0 = ไม่ใช้งาน
    /// </summary>
    public bool? HdActive { get; set; }

    public DateTime? HdUpdateDate { get; set; }

    public string? HdUpdateBy { get; set; }
}
