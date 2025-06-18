using mylittle_project.Domain.Entities;
using System;
using System.Collections.Generic;

public class Filter
{
    public Guid Id { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
    public string Type { get; set; }           // toggle, range, multiselect
    public string Category { get; set; }

    public double? RangeStart { get; set; }
    public double? RangeEnd { get; set; }
    public double? Step { get; set; }

    public string? Options { get; set; }       // Comma-separated values (Red,Blue,Green)

    public Guid StoreId { get; set; }
    public Store Store { get; set; }
}
