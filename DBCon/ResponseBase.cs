﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnectionCustom.Data
{
    public class ResponseBase
    {
        [NotMapped]
        public int? status { get; set; }
        [NotMapped]
        public string? message { get; set; }
    }
}
