﻿using System;
using System.Collections.Generic;

namespace AMS.Data.Models;

public partial class MaintenanceImage
{
    public int Id { get; set; }

    public string? ImageName { get; set; }

    public string? ImageUrl { get; set; }

    public int MaintenanceId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Maintenance Maintenance { get; set; } = null!;
}