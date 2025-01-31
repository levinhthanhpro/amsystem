﻿using System;
using System.Collections.Generic;

namespace AMS.Data.Models;

public partial class Category
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<AssetType> AssetTypes { get; set; } = new List<AssetType>();
}
