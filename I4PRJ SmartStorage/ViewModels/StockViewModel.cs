﻿using System.Collections.Generic;
using I4PRJ_SmartStorage.Models.Domain;

namespace I4PRJ_SmartStorage.ViewModels
{
  public class StockViewModel
  {
    public List<Stock> Stocks { get; set; }

    public Stock Stock { get; set; }
    
    public Inventory Inventory { get; set; }
  }
}