﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace I4PRJ_SmartStorage.Models.Domain
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        [DisplayName("Category")]
        public string Name { get; set; }

        [DisplayName("Updated")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:G}")]
        [Editable(false)]
        public DateTime Updated { get; set; }

        [DisplayName("By")]
        [Editable(false)]
        public string ByUser { get; set; }

        public bool IsDeleted { get; set; }
    }
}