﻿using System;
using SmartStorage.DAL.Models;

namespace SmartStorage.DAL.Interfaces.Models
{
  public interface ITransaction
  {
    string ByUser { get; set; }
    Inventory FromInventory { get; set; }
    int? FromInventoryId { get; set; }
    Product Product { get; set; }
    int ProductId { get; set; }
    double Quantity { get; set; }
    Inventory ToInventory { get; set; }
    int ToInventoryId { get; set; }
    int TransactionId { get; set; }
    DateTime? Updated { get; set; }
  }
}