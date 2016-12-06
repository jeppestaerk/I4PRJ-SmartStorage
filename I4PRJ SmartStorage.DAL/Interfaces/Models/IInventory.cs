﻿using System;

namespace SmartStorage.DAL.Interfaces.Models
{
  public interface IInventory
  {
    string ByUser { get; set; }
    int InventoryId { get; set; }
    bool IsDeleted { get; set; }
    string Name { get; set; }
    DateTime? Updated { get; set; }
  }
}