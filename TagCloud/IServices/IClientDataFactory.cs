﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagCloud.IServices
{
    public interface IClientDataFactory
    {
        Settings settings { get; set; }
        ClientData CreateData();
    }
}