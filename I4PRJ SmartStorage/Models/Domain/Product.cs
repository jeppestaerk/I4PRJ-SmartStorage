﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace I4PRJ_SmartStorage.Models.Domain
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        [DisplayName("Product")]
        public string Name { get; set; }
        /*
        [Required]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Range(0, Double.MaxValue)]
        public double Size { get; set; }
        */
        [DisplayName("Purchase Price")]
        [DataType(DataType.Currency)]
        [Range(0, Double.MaxValue)]
        public double PurchasePrice { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [DisplayName("Updated")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:G}")]
        [Editable(false)]
        public DateTime Updated { get; set; }

        [DisplayName("By")]
        [Editable(false)]
        public string ByUser { get; set; }

        public bool IsDeleted { get; set; }

        //[Timestamp]
        //[HiddenInput(DisplayValue = false)]
        //public byte[] Version { get; set; }
    }
}