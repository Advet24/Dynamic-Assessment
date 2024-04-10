﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Responses
{
    public class QuesResponse<T>
    {
        public int Status { get; set; }
        public string? Message { get; set; }

        public List<T> Results { get; set; }
        public string? Error { get; set; }
    }
}
