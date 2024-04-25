using System;
using System.Collections.Generic;

namespace DCI_HELPDESK_API.Models;

public partial class HelpdeskDict
{
    public int DictId { get; set; }

    public string DictCategory { get; set; } = null!;

    public string DictCode { get; set; } = null!;

    public int? DictIndex { get; set; }

    public string? DictTitle { get; set; }

    public string? DictDesc { get; set; }

    public double? DictRatio { get; set; }

    public string? DictRef { get; set; }

    public string? DictCreateBy { get; set; }

    public DateTime? DictCreateDate { get; set; }

    /// <summary>
    /// 1 = ใช้งาน, 0 = ไม่ใช้งาน
    /// </summary>
    public bool? DictActive { get; set; }

    public DateTime? DictUpdateDate { get; set; }

    public string? DictUpdateBy { get; set; }
}
