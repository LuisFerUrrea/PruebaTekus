﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicativoWeb.Models.Response
{
    public interface IMyResponse
    {
        int Success { get; set; }
        string Message { get; set; }
        object Data { get; set; }
    }
}
