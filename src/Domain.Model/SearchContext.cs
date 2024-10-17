﻿namespace Domain.Model;

using Domain.Model.Enum;

public class SearchContext
{
    public Type? Type { get; set; }

    public string? Manufacturer { get; set; }

    public string? Model { get; set; }

    public int? Year { get; set; }
}